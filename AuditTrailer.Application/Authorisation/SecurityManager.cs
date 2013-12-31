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
        private DatabaseConnection connection;

        public SecurityManager(DatabaseConnection connection)
        {
            this.connection = connection;
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

            return false;
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
    }
}
