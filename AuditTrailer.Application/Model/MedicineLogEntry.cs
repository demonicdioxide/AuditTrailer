/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application.Model
{
	/// <summary>
	/// Description of MedicineLogEntry.
	/// </summary>
	public class MedicineLogEntry
	{
		public PainReliever Medicine { get; set; }
		public int AmountTaken { get; set; }
		public DateTime DateTaken { get; set; }
	}
}
