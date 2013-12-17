using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Managers
{
    using System.IO;

    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Model;

    public class TripManager
    {
        private DatabaseConnection connection;

        public TripManager(DatabaseConnection connection)
        {
            this.connection = connection;
        }

        public void AddTrip(Trip trip)
        {
            string commandText = "SELECT TripID FROM Trip ORDER BY TripID DESC LIMIT 1";
            int lastID = 0;
            var command = connection.CreateCommand(commandText);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lastID = int.Parse(reader["TripID"].ToString());
                }
            }

            command = connection.CreateCommand(
                @"INSERT INTO Trip 
                    SELECT @LastID, @DateOccurred, @BoxSizeBought, @AmountBought, @MedicineID, @StoreID, @UserID");
            command.Parameters.AddWithValue("@LastID", lastID + 1);
            command.Parameters.AddWithValue("@DateOccurred", trip.DateOccurred);
            command.Parameters.AddWithValue("@BoxSizeBought", trip.BoxSizeBought);
            command.Parameters.AddWithValue("@AmountBought", trip.AmountBought);
            command.Parameters.AddWithValue("@MedicineID", trip.PainRelieverBought.ID);
            command.Parameters.AddWithValue("@StoreID", trip.Store.ID);
            command.Parameters.AddWithValue("@UserID", trip.User.ID);
            int numberAdded = command.ExecuteNonQuery();
            if (numberAdded != 1)
            {
                throw new InvalidDataException();
            }

        }

        public IEnumerable<Trip> GetTripsForStore(Store store)
        {
            var trips = new List<Trip>();
            string commandText = @"SELECT T.TripID, T.DateOccurred, M.Name, T.BoxSizeBought, T.AmountOfBoxesBought, U.FirstName As [FirstName], U.Surname FROM Trip T 
                                    JOIN Medicine M ON M.PainRelieverID = T.BoughtMedicineID
                                    JOIN User U ON U.UserID = T.UserID
                                    WHERE T.StoreID = @StoreID";
            var command = connection.CreateCommand(commandText);
            command.Parameters.AddWithValue("@StoreID", store.ID);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Trip trip = new Trip();
                    trip.User = new User();
                    trip.User.FirstName = reader["FirstName"].ToString();
                    trip.User.Surname = reader["Surname"].ToString();
                    trip.Store = store;
                    trip.MedicineDetails = new Tuple<string, int, int>(reader["Name"].ToString(),
                        int.Parse(reader["BoxSizeBought"].ToString()), int.Parse(reader["AmountOfBoxesBought"].ToString()));
                    trip.DateOccurred = DateTime.Parse(reader["DateOccurred"].ToString());
                    trips.Add(trip);
                }
            }

            return trips;
        }
    }
}
