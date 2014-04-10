/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 22/12/2013
 * Time: 23:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application
{
	/// <summary>
	/// Description of MedicineConstants.
	/// </summary>
	public class MedicineConstants
	{
		public static int NUROFEN_PLUS_DAILY_DOSAGE = 4;
		public static int SOLPADEINE_MAX_SOLUBLE_DAILY_DOSAGE = 4;
		public static int SOLPDAEINE_MAX_DAILY_DOSAGE = 4;
		public static int AMOUNT_OF_DOSAGES_TAKEN_DAILY_FOR_EVERYTHING_ELSE = 1;
		public static int AMOUNT_OF_DOSAGES_TAKEN_DAILY_FOR_NUROFEN_PLUS = 2;
		public static int GetDailyDosageForMedicine(string name)
		{
			int dosage = 0;
			int dosageAmountMultiplier = AMOUNT_OF_DOSAGES_TAKEN_DAILY_FOR_EVERYTHING_ELSE;
			switch (name) 
			{
				case "Nurofen Plus":
					dosage = NUROFEN_PLUS_DAILY_DOSAGE;
					dosageAmountMultiplier = AMOUNT_OF_DOSAGES_TAKEN_DAILY_FOR_NUROFEN_PLUS;
					break;
				case "Solpadeine Max Soluble Tablets":
					dosage = SOLPADEINE_MAX_SOLUBLE_DAILY_DOSAGE;
					break;
				case "Solpadeine Max Tablets":
					dosage = SOLPDAEINE_MAX_DAILY_DOSAGE;
					break;
				default:
					throw new Exception("Cannot parse " + name + " as a standard used medicine");
				
			}
			
			dosage = dosage * dosageAmountMultiplier;
			return dosage;
		}
	}
}
