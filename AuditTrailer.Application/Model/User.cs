namespace AuditTrailer.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + Surname;
            }
        }
		
		public string Username { get; set; }

        public RoleEnum Role { get; set; }
    }
}
