/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 22/12/2013
 * Time: 22:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using AuditTrailer.Application.Database;
using AuditTrailer.Application.DotNetFourEmulation;
using AuditTrailer.Application.Model;

namespace AuditTrailer.Application.Managers
{
	/// <summary>
	/// Description of ReminderManager.
	/// </summary>
	public class ReminderManager
	{
		private DatabaseConnection _connection;
		private Dictionary<string, int> _dosageMapping;
		
		public ReminderManager()
		{
			_connection = DatabaseConnector.Create();
			_dosageMapping = new Dictionary<string, int>()
			{
				{ "Nurofen Plus", MedicineConstants.NUROFEN_PLUS_DAILY_DOSAGE },
				{ "Solpadeine Max Soluble Tablets", MedicineConstants.SOLPADEINE_MAX_SOLUBLE_DAILY_DOSAGE },
				{ "Solpadeine Max Tablets", MedicineConstants.SOLPDAEINE_MAX_DAILY_DOSAGE }
			};
		}
		
		public IEnumerable<Tuple<string, int, DateTime>> GetMedicineReminderInformation(User user)
		{
			var command = _connection.CreateCommand(@"SELECT SUM(T.[AmountOfBoxesBought] * B.Name) As [Amount Of Tablets], M.Name As [MedicineName], T.BoughtMedicineID As [MedicineID] FROM Trip T
													JOIN Medicine M ON M.PainRelieverID = T.BoughtMedicineID
													JOIN BoxSize B ON B.BoxSizeID = T.BoxSizeID
													WHERE T.UserID = @UserID
													GROUP BY M.PainRelieverID");
			command.Parameters.AddWithValue("@UserID", user.ID);
			var _information = new List<Tuple<string, int, DateTime>>();
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					int amountOfTablets = int.Parse(reader["Amount Of Tablets"].ToString());
					int medicineID = int.Parse(reader["MedicineID"].ToString());
					int amountAlreadyTaken = GetAmountAlreadyTaken(medicineID);
					int actualTabletsRemaining = amountOfTablets - amountAlreadyTaken;
					string nameOfMedicine = reader["MedicineName"].ToString();
					int dosage = _dosageMapping[nameOfMedicine] * MedicineConstants.AMOUNT_OF_DOSAGES_TAKEN_DAILY;
					DateTime runOutDate = DateTime.Now.AddDays(actualTabletsRemaining / (dosage)).AddDays(-1);
					_information.Add(new Tuple<string, int, DateTime>(nameOfMedicine, actualTabletsRemaining, runOutDate));
				}
			}
			
			return _information;
		}
		
		public int GetAmountAlreadyTaken(int medicineID)
		{
			var command = _connection.CreateCommand(@"SELECT SUM(M.HowManyTaken) As [TakenAmount] FROM MedicineLog M WHERE M.MedicineID = @MedicineID");
			command.Parameters.AddWithValue("@MedicineID", medicineID);
			using (var reader = command.ExecuteReader())
			{
				reader.Read();
				var taken = reader["TakenAmount"];
				return string.IsNullOrEmpty(taken.ToString()) ? 0 : int.Parse(taken.ToString());
			}
		}
		
		public void InsertMedicineLogEntry(MedicineLogEntry entry)
		{
			var command = _connection.CreateCommand(@"INSERT INTO MedicineLog
													SELECT @LastID, @MedicineID, @AmountTaken, @DateTaken");
			var lastIDCommand = _connection.CreateCommand("SELECT MedicineLogID FROM MedicineLog ORDER BY MedicineLogID DESC LIMIT 1");
			int lastID = 0;
			using (var reader = lastIDCommand.ExecuteReader())
			{
				reader.Read();
				if (reader.HasRows) 
				{
					lastID = int.Parse(reader["MedicineLogID"].ToString());
				}

			}
			
			lastID = lastID + 1;
			command.Parameters.AddWithValue("@LastID", lastID);
			command.Parameters.AddWithValue("@MedicineID", entry.Medicine.ID);
			command.Parameters.AddWithValue("@AmountTaken", entry.AmountTaken);
			command.Parameters.AddWithValue("@DateTaken", entry.DateTaken);
			int affectedRecords = command.ExecuteNonQuery();
			if (affectedRecords != 1) 
			{
				throw new Exception();
			}
		}
		
		
	}
}
