﻿/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 10:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

using AuditTrailer.Application;
using AuditTrailer.Application.Database;
using AuditTrailer.Application.Managers;
using AuditTrailer.Application.Model;

namespace AuditTrailerScheduler
{
	class Program
	{
		public static void Main(string[] args)
		{
			CollectionManager _collectionManager = new CollectionManager(DatabaseConnector.Create());
			ReminderManager _reminderManager = new ReminderManager();
			IEnumerable<PainReliever> medicines = _collectionManager.GetAllPainReliefMedicine().Where(p => !p.IsPrescriptionOnly);
			PainReliever nurofenPlus = medicines.First(t => t.Name.Equals("Nurofen Plus"));
			PainReliever solpadeineSoluble = medicines.First(t => t.Name.Equals("Solpadeine Max Soluble Tablets"));
			PainReliever solpadeineMax = medicines.First(t => t.Name.Equals("Solpdaeine Max Tablets"));
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
	}
}