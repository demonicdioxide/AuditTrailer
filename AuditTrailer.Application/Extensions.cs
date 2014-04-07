/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application
{
	/// <summary>
	/// Description of Extensions.
	/// </summary>
	public static class Extensions
	{
		public static bool Between(this int num, int lower, int upper, bool inclusive)
		{
		    return inclusive
		        ? lower <= num && num <= upper
		        : lower < num && num < upper;
		}
		
		public static bool IsMoreThan(this int number, int comparsion)
		{
			return number > comparsion;
		}
	}
}
