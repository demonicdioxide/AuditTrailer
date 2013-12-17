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

        /// <summary>
        /// Whether they are a 'global' administrator or not - global admins have access to everything.
        /// </summary>
        public bool IsSystemAdministrator { get; set; }
    }
}
