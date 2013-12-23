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
			if (firstArgument.Equals("reminderemail", StringComparison.OrdinalIgnoreCase))
			{
				SendReminderEmail(args.ElementAt(1));
			}
			else if (firstArgument.Equals("backup"))
			{
				BackupDatabase();
			}
			else
			{
				EnterLogEntryInformation();
			}
			Environment.Exit(0); // successful exit.
		}
		
		private static void BackupDatabase()
		{
			string uniqueFileName = DateTime.Now.ToString("ddMMyyyy.HH.mm.db");
			File.Copy(@"C:\AuditTrailer.db", @"C:\Audit Trailer\Backups\" + uniqueFileName);
		}
		
		private static void EnterLogEntryInformation()
		{
			CollectionManager _collectionManager = new CollectionManager(DatabaseConnector.Create());
			ReminderManager _reminderManager = new ReminderManager();
			IEnumerable<PainReliever> medicines = _collectionManager.GetAllPainReliefMedicine().Where(p => !p.IsPrescriptionOnly);
			PainReliever nurofenPlus = medicines.First(t => t.Name.Equals("Nurofen Plus"));
			PainReliever solpadeineSoluble = medicines.First(t => t.Name.Equals("Solpadeine Max Soluble Tablets"));
			PainReliever solpadeineMax = medicines.First(t => t.Name.Equals("Solpadeine Max Tablets"));
			MedicineLogEntry nurofenForMidday = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.NUROFEN_PLUS_DAILY_DOSAGE,
				DateTaken = DateTime.Today.Add(TimeSpan.FromHours(13)),
				Medicine = nurofenPlus
			};
			MedicineLogEntry nurofenForEvening = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.NUROFEN_PLUS_DAILY_DOSAGE,
				DateTaken = DateTime.Today.Add(TimeSpan.FromHours(23)),
				Medicine = nurofenPlus
			};
			MedicineLogEntry solpaMaxSolubleForMidday = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.SOLPADEINE_MAX_SOLUBLE_DAILY_DOSAGE,
				DateTaken = DateTime.Today.Add(TimeSpan.FromHours(13)),
				Medicine = solpadeineSoluble
			};
			MedicineLogEntry solpaMaxForEvening = new MedicineLogEntry
			{
				AmountTaken = MedicineConstants.SOLPDAEINE_MAX_DAILY_DOSAGE,
				DateTaken = DateTime.Today.Add(TimeSpan.FromHours(23)),
				Medicine = solpadeineMax
			};
			var logEntries = new[] { nurofenForMidday, solpaMaxSolubleForMidday,
				solpaMaxForEvening, nurofenForEvening };
			foreach (var logEntry in logEntries) 
			{
				_reminderManager.InsertMedicineLogEntry(logEntry);
			}
		}
		
		private static void SendReminderEmail(string userEmail)
		{
			ReminderManager _reminderManager = new ReminderManager();
			SecurityManager _securityManager = new SecurityManager(DatabaseConnector.Create());
			User user = _securityManager.GetUserByEmail(userEmail);
			var reminderInformation = _reminderManager.GetMedicineReminderInformation(user);
			DateTime closetDate = reminderInformation.Min(d => d.Third);
			var difference = DateTime.Now.Subtract(closetDate.AddDays(-7));
			if (difference.Days.Between(-2, 2, true))
			{
				EmailSender sender = new EmailSender
				{
					Recipient = userEmail
				};
				Templator templator = new Templator
				{
					ReminderDate = closetDate.AddDays(-7)
				};
				string message = templator.RenderToEmailString();
				sender.SendEmail(message);
			}
		}
	}
}