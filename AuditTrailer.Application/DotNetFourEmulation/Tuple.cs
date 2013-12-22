/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 22/12/2013
 * Time: 21:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application.DotNetFourEmulation
{
	/// <summary>
	/// Description of Tuple.
	/// </summary>
	public class Tuple<T1, T2, T3>
	{
		public T1 First { get; set;}
		public T2 Second { get; set; }
		public T3 Third { get; set; }
		
		public Tuple(T1 first, T2 second, T3 third)
		{
			First = first;
			Second = second;
			Third = third;
		}
	}
}
