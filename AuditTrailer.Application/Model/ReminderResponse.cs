/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 10/04/2014
 * Time: 19:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application.Model
{
	/// <summary>
	/// Description of ReminderResponse.
	/// </summary>
	public class ReminderResponse
	{
		public bool ShouldRemnderUser { get; set; }
		public DateTime ExpiryDate { get; set; }
		public PainReliever Medicine { get; set ;}
	}
}
