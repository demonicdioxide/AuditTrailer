namespace AuditTrailer.Application.Authorisation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;

    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SecurityManager
    {
    	private readonly Random _rng = new Random();
		private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    	
        private DatabaseConnection connection;
        
        public int AmountOfLoginAttemptsAllowed
        {
        	get
        	{
        		return 5;
        	}
        }

        public SecurityManager(DatabaseConnection connection)
        {
            this.connection = connection;
        }
        
        public string InsertForgottenPasswordRequestForUser(User user)
        {
        	var command = connection.CreateCommand(@"INSERT INTO ForgottenPasswordRequest
        											SELECT @UserID, @Code, 0");
        	string code = GenerateForgottenPasswordCodeForUser(user);
        	command.Parameters.AddWithValue("@UserID", user.ID);
        	command.Parameters.AddWithValue("@Code", code);
        	int affectedRows = command.ExecuteNonQuery();
        	if (affectedRows != 1) 
        	{
        		throw new Exception();
        	}
        	
        	return code;
        	
        }
        
        private string GenerateForgottenPasswordCodeForUser(User user)
        {
        	int size = 10;
    	    char[] buffer = new char[size];

		    for (int i = 0; i < size; i++)
		    {
		        buffer[i] = _chars[_rng.Next(_chars.Length)];
		    }
		    return new string(buffer);
        }
        
        public void DeleteAllForgottenPasswordRequestsForUser(User user)
        {
        	var command = connection.CreateCommand(@"UPDATE ForgottenPasswordRequest SET Deleted = 1 WHERE UserID = @UserID");
        	command.Parameters.AddWithValue("@UserID", user.ID);
        	command.ExecuteNonQuery();
        }
        
        public string GetForgottenPasswordCodeForUser(User user)
        {
        	var command = connection.CreateCommand(@"SELECT Code FROM ForgottenPasswordRequest WHERE UserID = @UserID AND Deleted = @Deleted");
        	command.Parameters.AddWithValue("@UserID", user.ID);
        	command.Parameters.AddWithValue("@Deleted", false);
        	using (var reader = command.ExecuteReader())
        	{
        		reader.Read();
        		return reader["Code"].ToString();
        	}
        }
        
        public bool IsForgottenPasswordCodeCorrect(User user, string code)
        {
        	return GetForgottenPasswordCodeForUser(user).Equals(code);
        }

        public bool CanUserLogin(string email, string password)
        {

            var command = connection.CreateCommand("SELECT UserID FROM User WHERE Email = @Email");
            command.Parameters.AddWithValue("@Email", email);
            int userID;

            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return false;
                }

                reader.Read();
                userID = int.Parse(reader["UserID"].ToString());
            }

            command = connection.CreateCommand("SELECT PasswordHash FROM User WHERE UserID = @UserID");
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        reader.Read();
                        string passwordHash = reader["PasswordHash"].ToString();
                        string generatedPassword = CreatePasswordHash(password);
                        if (passwordHash.Equals(generatedPassword))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            var user = new User();
            using (var connection = DatabaseConnector.Create())
            {
                var command = connection.CreateCommand("SELECT * FROM User WHERE Email = @Email");
                command.Parameters.AddWithValue("@Email", email);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.ID = int.Parse(reader["UserID"].ToString());
                        user.FirstName = reader["FirstName"].ToString();
                        user.Surname = reader["Surname"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Role = GetRoleByUser(user);
                        return user;
                    }

                    return null; // no user found.
                }
            }
        }

        public RoleEnum GetRoleByUser(User user)
        {
            var command = connection.CreateCommand(@"SELECT * FROM UserRole UR WHERE UR.UserID = @UserID");
            command.Parameters.AddWithValue("@UserID", user.ID);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int enumIntegerValue = int.Parse(reader["RoleID"].ToString());
                    return (RoleEnum)enumIntegerValue;
                }
            }

            throw new SecurityException("User has no membership");
        }
        
        public string GetRoleDisplayName(RoleEnum role)
        {
        	var command = connection.CreateCommand(@"SELECT R.DisplayName FROM Role R WHERE R.RoleID = @RoleID");
        	command.Parameters.AddWithValue("@RoleID", (int)role);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                	return reader["DisplayName"].ToString();
                }
            }
            
            //assumption: if we cannot find it, return the same thing as what enum says
            return role.ToString();
        }

        public bool IsUserAllowedToAccessResource(User user, RoleEnum requiredRoleEnum)
        {
            return user.Role >= requiredRoleEnum;
        }

        public User GetUserByID(int id)
        {
            var user = new User();
            using (var connection = DatabaseConnector.Create())
            {
                var command = connection.CreateCommand("SELECT * FROM User WHERE UserID = @UserID");
                command.Parameters.AddWithValue("@UserID", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.ID = int.Parse(reader["UserID"].ToString());
                        user.FirstName = reader["FirstName"].ToString();
                        user.Surname = reader["Surname"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Role = GetRoleByUser(user);
                        return user;
                    }

                    return null; // no user found.
                }
            }
        }

        public string CreatePasswordHash(string password)
        {
            using (var provider = SHA256CryptoServiceProvider.Create())
            {
                var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
 
                return builder.ToString();
            }
        }
        
        public void UpdateUsersPassword(User user, string newPassword)
        {
        	var command = connection.CreateCommand(@"UPDATE User Set PasswordHash = @PasswordHash WHERE UserID = @UserID");
        	command.Parameters.AddWithValue("@UserID", user.ID);
        	string newPasswordHash = CreatePasswordHash(newPassword);
        	command.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
        	int rows = command.ExecuteNonQuery();
        	if (rows != 1) 
        	{
        		throw new SecurityException();
        	}
        }
        
        public PasswordStrengthValidationResult DoesPasswordMeetRequirements(string password)
        {
        	PasswordStrengthValidationResult result = new PasswordStrengthValidationResult();
        	result.ValidationErrors = new List<string>();
        	result.PasswordStrongEnough = false; // safety, assume it's not strong enough to begin with
        	
        	if (password.Length < 6) 
        	{
        		result.ValidationErrors.Add("Password is less than 6 characters long");
        	}
        	
        	if (!password.Any(c => char.IsDigit(c)))
        	{
        		result.ValidationErrors.Add("Password does not contain any numbers");
        	}
        	
        	if (!password.Any(c => char.IsUpper(c)))
        	{
        		result.ValidationErrors.Add("Password does not contain an upper-case character");
        	}
        	
        	return result;
        }
    }
}
