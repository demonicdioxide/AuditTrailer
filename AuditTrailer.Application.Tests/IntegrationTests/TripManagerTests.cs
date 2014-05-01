/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 19/04/2014
 * Time: 10:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using AuditTrailer.Application.Managers;
using NUnit.Framework;

namespace AuditTrailer.Application.Tests.IntegrationTests
{
	/// <summary>
	/// Description of TripManagerTests.
	/// </summary>
	[TestFixture]
	public class TripManagerTests
	{
		[Test]
		public void GivenOneBoxOfNurofenReturnsFourDays()
		{
			TripManager manager = new TripManager(Database.DatabaseConnector.Create());
			int days = manager.GetDaysLastingForMedicine("Nurofen Plus", 1, 32);
			Assert.That(days.Equals(4));
		}
	
	}
}
