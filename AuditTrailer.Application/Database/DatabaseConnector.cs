namespace AuditTrailer.Application.Database
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Data.SQLite;
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseConnector
    {

        private static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString.AuditTrail");

        public static DatabaseConnection Create()
        {
            return new DatabaseConnection(new SQLiteConnection(connectionString));
        }
    }
}
