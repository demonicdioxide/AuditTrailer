using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Managers
{
    using AuditTrailer.Application.Database;
    using System.Data.SQLite;
    using AuditTrailer.Application.Model;

    public class CollectionManager
    {

        private DatabaseConnection connection;

        public CollectionManager(DatabaseConnection connection)
        {
            this.connection = connection;
        }

        public CollectionManager()
        {
            connection = DatabaseConnector.Create();
        }

        public IEnumerable<PainReliever> GetAllPainReliefMedicine()
        {
            var command = connection.CreateCommand(@"SELECT P.PainRelieverID, P.Name, MA.AnalgesicID As [MainPainReliever], 
													P.MainAnalgesicAmount, SA.AnalgesicID As [SecondaryPainReliever], P.SecondaryAnalgesicAmount, 
													P.IsPrescriptionOnly, AM.Name As [AliasedMedicineName]
													FROM Medicine P
													JOIN Analgesic MA ON P.MainAnalgesicID = MA.AnalgesicID
													JOIN Analgesic SA ON P.SecondaryAnalgesicID = SA.AnalgesicID
													LEFT JOIN Medicine AM ON AM.PainRelieverID = P.AliasedMedicineID");
            var reader = command.ExecuteReader();
            var listOfReliefMedicine = new List<PainReliever>();
            while (reader.Read())
            {
            	var reliefMedicine = HydrateToMedicine(reader);
                listOfReliefMedicine.Add(reliefMedicine);

            }
            return listOfReliefMedicine;
        }
        
        public PainReliever GetPainRelieverByName(string name)
        {
            var command = connection.CreateCommand(@"SELECT P.PainRelieverID, P.Name, MA.AnalgesicID As [MainPainReliever], 
													P.MainAnalgesicAmount, SA.AnalgesicID As [SecondaryPainReliever], P.SecondaryAnalgesicAmount, 
													P.IsPrescriptionOnly, AM.Name As [AliasedMedicineName]
													FROM Medicine P
													JOIN Analgesic MA ON P.MainAnalgesicID = MA.AnalgesicID
													JOIN Analgesic SA ON P.SecondaryAnalgesicID = SA.AnalgesicID
													LEFT JOIN Medicine AM ON AM.PainRelieverID = P.AliasedMedicineID
													WHERE P.Name = @Name");
        	command.Parameters.AddWithValue("@Name", name);
            var reader = command.ExecuteReader();
            var listOfReliefMedicine = new List<PainReliever>();
            while (reader.Read())
            {
            	var reliefMedicine = HydrateToMedicine(reader);
            	return reliefMedicine;

            }
            
            throw new Exception("Cannot find any medicines called " + name);
        }
        
        private PainReliever HydrateToMedicine(SQLiteDataReader reader)
        {
        	    var reliefMedicine = new PainReliever();
                reliefMedicine.ID = int.Parse(reader["PainRelieverID"].ToString());
                reliefMedicine.Name = reader["Name"].ToString();
                int mainRelieverID = int.Parse(reader["MainPainReliever"].ToString());
                int secondaryRelieverID = int.Parse(reader["SecondaryPainReliever"].ToString());
                reliefMedicine.MainAnalgesicAmount = double.Parse(reader["MainAnalgesicAmount"].ToString());
                reliefMedicine.SecondaryAnalgesicAmount = double.Parse(reader["SecondaryAnalgesicAmount"].ToString());
                var mainReliever = GetAllAnalgesics().First(a => a.ID.Equals(mainRelieverID));
                var secondaryReliever = GetAllAnalgesics().First(a => a.ID.Equals(secondaryRelieverID));
                reliefMedicine.MainAnalgesic = mainReliever;
                reliefMedicine.SecondaryAnalgesic = secondaryReliever;
                reliefMedicine.BoxSizes = GetBoxSizesForMedicine(reliefMedicine);
                reliefMedicine.IsPrescriptionOnly = bool.Parse(reader["IsPrescriptionOnly"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["AliasedMedicineName"].ToString()))
                {
                	reliefMedicine.AliasedMedicine = reader["AliasedMedicineName"].ToString();
                }
                return reliefMedicine;
        }

        public IEnumerable<BoxSize> GetBoxSizesForMedicine(PainReliever reliever)
        {
            var command = connection.CreateCommand(@"SELECT B.* FROM MedicineBoxSize MBZ 
            JOIN BoxSize B ON B.BoxSizeID = MBZ.BoxSizeID WHERE MBZ.MedicineID = @MedicineID");
            command.Parameters.AddWithValue("@MedicineID", reliever.ID);
            var reader = command.ExecuteReader();
            var listOfBoxSizesForMedicine = new List<BoxSize>();
            while (reader.Read())
            {
                var boxSize = new BoxSize();
                boxSize.ID = int.Parse(reader["BoxSizeID"].ToString());
                boxSize.Name = int.Parse(reader["Name"].ToString());
                listOfBoxSizesForMedicine.Add(boxSize);
            }

            return listOfBoxSizesForMedicine;
        }

        public IEnumerable<Analgesic> GetAllAnalgesics()
        {
            var command = connection.CreateCommand(@"SELECT * FROM Analgesic A");
            var reader = command.ExecuteReader();
            var listOfReliefMedicine = new List<Analgesic>();
            while (reader.Read())
            {
                var analgesic = new Analgesic();
                analgesic.ID = int.Parse(reader["AnalgesicID"].ToString());
                analgesic.Name = reader["Name"].ToString();
                listOfReliefMedicine.Add(analgesic);
            }

            return listOfReliefMedicine;
        }

        public IEnumerable<Store> GetAllStores()
        {
            var command = connection.CreateCommand(@"SELECT S.*, T.DateOccurred As [LastDate] FROM Store S 
														LEFT JOIN Trip T ON T.StoreID = S.StoreID
														GROUP BY S.Name, S.Location");
            var reader = command.ExecuteReader();
            var listOfStores = new List<Store>();
            while (reader.Read())
            {
                var store = new Store();
                store.ID = int.Parse(reader["StoreID"].ToString());
                store.Name = reader["Name"].ToString();
                store.Location = reader["Location"].ToString();
                // had problems parsing it into a TimeSpan
                //convert it into a datetime and then use the timespan from that
                //.NET will then do most of the work for us.
                var openingTimeStart = reader["CommonOpeningTimeStart"];
                store.OpeningStartTime = string.IsNullOrEmpty(openingTimeStart.ToString()) ? null : (TimeSpan?)DateTime.Parse(openingTimeStart.ToString()).TimeOfDay;
                var openingTimeEnd = reader["CommonOpeningTimeEnd"];
                store.OpeningEndTime = string.IsNullOrEmpty(openingTimeEnd.ToString()) ? null : (TimeSpan?)DateTime.Parse(openingTimeEnd.ToString()).TimeOfDay;
                store.IsOnlineStore = bool.Parse(reader["IsOnlineStore"].ToString());
                store.Notes = reader["Notes"].ToString();
                int defaultRating = 0;
                var rating = reader["PackagingRating"];
                store.PackagingRating = string.IsNullOrEmpty(rating.ToString()) ? defaultRating : int.Parse(rating.ToString());
                string lastTripDate = reader["LastDate"].ToString();
                store.LastTripDate = string.IsNullOrEmpty(lastTripDate) ? DateTime.MinValue : DateTime.Parse(lastTripDate);
                listOfStores.Add(store);
            }

            return listOfStores;
        }

        public void AddStore(Store store)
        {
            int lastID = 0;
            string commandText = "SELECT StoreID FROM Store S ORDER BY S.StoreID DESC LIMIT 1";
            var command = connection.CreateCommand(commandText);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lastID = int.Parse(reader["StoreID"].ToString());
                }
            }

            commandText = @"INSERT INTO Store
                            SELECT @StoreID, @Name, @Location, @OpeningStartTime, @OpeningEndTime, @IsOnlineStore, @PackagingRating, @Notes";
            command = connection.CreateCommand(commandText);
            command.Parameters.AddWithValue("@StoreID", lastID + 1);
            command.Parameters.AddWithValue("@Name", store.Name);
            command.Parameters.AddWithValue("@Location", store.Location);
            command.Parameters.AddWithValue("@OpeningStartTime", store.OpeningStartTime);
            command.Parameters.AddWithValue("@OpeningEndTime", store.OpeningEndTime);
            command.Parameters.AddWithValue("@IsOnlineStore", store.IsOnlineStore);
            command.Parameters.AddWithValue("@PackagingRating", store.PackagingRating);
            command.Parameters.AddWithValue("@Notes", store.Notes);
            int numberAffected = command.ExecuteNonQuery();
            if (numberAffected != 1)
            {
                throw new InvalidOperationException();
            }
        }

    }
}
