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
			var command = _connection.CreateCommand(@"SELECT SUM(T.[AmountOfBoxesBought] * B.Name) - SUM(ML.HowManyTaken) As [Amount Of Tablets] FROM Trip T
													JOIN Medicine M ON M.PainRelieverID = T.BoughtMedicineID
													JOIN BoxSize B ON B.BoxSizeID = T.BoxSizeID
													JOIN MedicineLog ML ON ML.MedicineID = T.[BoughtMedicineID]
													WHERE T.UserID = @UserID
													GROUP BY M.PainRelieverID");
			command.Parameters.AddWithValue("@UserID", user.ID);
			var _information = new List<Tuple<string, int, DateTime>>();
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					int amountOfTablets = int.Parse(reader["Amount Of Tablets"].ToString());
					
					
					string nameOfMedicine = reader["MedicineName"].ToString();
					int dosage = _dosageMapping[nameOfMedicine] * MedicineConstants.AMOUNT_OF_DOSAGES_TAKEN_DAILY;
					DateTime runOutDate = DateTime.Now.AddDays(amountOfTablets / (dosage));
					_information.Add(new Tuple<string, int, DateTime>(nameOfMedicine, amountOfTablets, runOutDate));
				}
			}
			
			return _information;
		}
		
		
	}
}
