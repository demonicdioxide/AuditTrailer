/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 10:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AuditTrailer.Application;
using AuditTrailer.Application.Authorisation;
using AuditTrailer.Application.Database;
using AuditTrailer.Application.Email;
using AuditTrailer.Application.Email.Templating;
using AuditTrailer.Application.Logging;
using AuditTrailer.Application.Managers;
using AuditTrailer.Application.Model;

namespace AuditTrailerScheduler
{
	class Program
	{
		public static void Main(string[] args)
		{

			string firstArgument = args.FirstOrDefault();
			firstArgument = string.IsNullOrEmpty(firstArgument) ? string.Empty : firstArgument;
			if (!string.IsNullOrEmpty(firstArgument))
			{
				Log.Write(args.First(), LogLevel.Debug);
				//Log.Write(args[1], LogLevel.Debug);
			}
			
			if (firstArgument.Equals("backup"))
			{
				BackupDatabase();
			}
			else
			{
				Log.Write("Entering obsolete medicine log entry, please fix!", LogLevel.Warning);
				EnterLogEntryInformation();
			}
			SendReminderEmail("arran.huxtable@gmail.com");
			Environment.Exit(0); // successful exit.
		}
		
		private static void BackupDatabase()
		{
			string uniqueFileName = DateTime.Now.ToString("ddMMyyyy.HH.mm") + ".db";
			string originalPath = Path.Combine(@"C:\", "AuditTrailer.Debug.db");
			string newPath = Path.Combine(@"C:\", "AuditTrailer", "Backups", uniqueFileName);
			File.Copy(originalPath, newPath);
		}
		
		[Obsolete]
		private static void EnterLogEntryInformation()
		{
			CollectionManager _collectionManager = new CollectionManager(DatabaseConnector.Create());
			ReminderManager _reminderManager = new ReminderManager();
			SecurityManager _securityManager = new SecurityManager(DatabaseConnector.Create());
			Log.Write("Before entering log entry...", LogLevel.Debug);
			IEnumerable<PainReliever> medicines = _collectionManager.GetAllPainReliefMedicine().Where(p => !p.IsPrescriptionOnly);
			PainReliever nurofenPlus = medicines.First(t => t.Name.Equals("Nurofen Plus"));
			PainReliever solpadeineSoluble = medicines.First(t => t.Name.Equals("Solpadeine Max Soluble Tablets"));
			PainReliever solpadeineMax = medicines.First(t => t.Name.Equals("Solpadeine Max Tablets"));
			DateTime yesterday = DateTime.Today.AddDays(-1);
			MedicineLogEntry nurofenForMidday = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.NUROFEN_PLUS_DAILY_DOSAGE,
				DateTaken = yesterday.Add(TimeSpan.FromHours(13)),
				Medicine = nurofenPlus
			};
			MedicineLogEntry nurofenForEvening = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.NUROFEN_PLUS_DAILY_DOSAGE,
				DateTaken = yesterday.Add(TimeSpan.FromHours(23)),
				Medicine = nurofenPlus
			};
			MedicineLogEntry solpaMaxSolubleForMidday = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.SOLPADEINE_MAX_SOLUBLE_DAILY_DOSAGE,
				DateTaken = yesterday.Add(TimeSpan.FromHours(13)),
				Medicine = solpadeineSoluble
			};
			MedicineLogEntry solpaMaxForEvening = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.SOLPDAEINE_MAX_DAILY_DOSAGE,
				DateTaken = yesterday.Add(TimeSpan.FromHours(23)),
				Medicine = solpadeineMax
			};
			var logEntries = new[] { nurofenForMidday, solpaMaxSolubleForMidday,
				solpaMaxForEvening, nurofenForEvening };
			foreach (var logEntry in logEntries) 
			{
				_reminderManager.InsertMedicineLogEntry(logEntry);
			}
			Log.Write("After entering log entry...", LogLevel.Debug);
		}
		
		private static void SendReminderEmail(string userEmail)
		{
			ReminderManager _reminderManager = new ReminderManager();
			SecurityManager _securityManager = new SecurityManager(DatabaseConnector.Create());
			User user = _securityManager.GetUserByEmail(userEmail);
			Log.Write("User found", LogLevel.Debug);
			var reminderInformation = _reminderManager.GetMedicineReminderInformation(user);
			if (reminderInformation != null && reminderInformation.ShouldRemnderUser)
			{
				EmailSender sender = new EmailSender
				{
					Recipient = userEmail
				};
				Templator templator = new Templator
				{
					ReminderResponse = reminderInformation
				};
				string message = templator.RenderReminderEmailToString();
				sender.SendEmail(message);
			}
		}
	
	}
}