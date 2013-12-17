namespace AuditTrailer.Application.Database
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DatabaseConnection : IDisposable
    {
        private readonly SQLiteConnection connection;

        public DatabaseConnection(SQLiteConnection connection)
        {
            connection.Open();
            this.connection = connection;
        }

        public void CommitChanges()
        {
            
        }

        public SQLiteCommand CreateCommand(string text)
        {
            return new SQLiteCommand(text, connection);
        }

        public SQLiteTransaction CreateTranscation()
        {
            return connection.BeginTransaction();
        }

        public void CommitCommandUsingTranscation(SQLiteCommand command)
        {
            using (var transcation = connection.BeginTransaction())
            {
                transcation.Commit();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
