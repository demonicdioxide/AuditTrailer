using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Managers
{
    using System.IO;
    using System.Security;

    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Model;
    public class TripManager
    {
        private DatabaseConnection connection;

        private BoxSizeManager _boxSizeManager;

        private CollectionManager _collectionManager;
        public TripManager(DatabaseConnection connection)
        {
            this.connection = connection;
            _boxSizeManager = new BoxSizeManager(connection);
            _collectionManager = new CollectionManager(connection);
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

            var boxSize = _boxSizeManager.GetBoxSize(trip.BoxSizeBought);
            var medicineBoxSize = _boxSizeManager.GetMedicineBoxSize(trip.PainRelieverBought, trip.BoxSizeBought);

            if (medicineBoxSize.ID == 0)
            {
                throw new SecurityException("Box Size is not applicable for this medication");
            }

            command = connection.CreateCommand(
                @"INSERT INTO Trip 
                    SELECT @LastID, @DateOccurred, @BoxSizeBought, @AmountBought, @MedicineID, @StoreID, @UserID, @Notes");
            command.Parameters.AddWithValue("@LastID", lastID + 1);
            command.Parameters.AddWithValue("@DateOccurred", trip.DateOccurred);
            command.Parameters.AddWithValue("@BoxSizeBought", medicineBoxSize.BoxSizeID);
            command.Parameters.AddWithValue("@AmountBought", trip.AmountBought);
            command.Parameters.AddWithValue("@MedicineID", trip.PainRelieverBought.ID);
            command.Parameters.AddWithValue("@StoreID", trip.Store.ID);
            command.Parameters.AddWithValue("@UserID", trip.User.ID);
            command.Parameters.AddWithValue("@Notes", trip.Notes);
            int numberAdded = command.ExecuteNonQuery();
            if (numberAdded != 1)
            {
                throw new InvalidDataException();
            }

        }

        public IEnumerable<Trip> GetTripsForStore(Store store)
        {
            var trips = new List<Trip>();
            string commandText = @"SELECT T.TripID, T.DateOccurred, M.Name, BZ.Name As [BoxSize], T.AmountOfBoxesBought, U.FirstName As [FirstName], U.Surname, T.Notes FROM Trip T 
                                    JOIN Medicine M ON M.PainRelieverID = T.BoughtMedicineID
                                    JOIN User U ON U.UserID = T.UserID
                                    JOIN BoxSize BZ ON BZ.BoxSizeID = T.BoxSizeID 
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
                        int.Parse(reader["BoxSize"].ToString()), int.Parse(reader["AmountOfBoxesBought"].ToString()));
                    trip.DateOccurred = DateTime.Parse(reader["DateOccurred"].ToString());
                    trip.Notes = string.IsNullOrEmpty(reader["Notes"].ToString()) ? string.Empty : reader["Notes"].ToString();
                    trips.Add(trip);
                }
            }

            return trips;
        }
    }
}
