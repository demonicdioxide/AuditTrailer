namespace AuditTrailer.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Membership
    {
        public User User { get; set;  }

        public string Role { get; set; }
    }
}
