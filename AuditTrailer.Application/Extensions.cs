/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

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
		
		/// <summary>
		/// Returns a distinct set of elements from the source list using a given Func.
		/// </summary>
		/// <param name="source">The source list</param>
		/// <param name="keySelector">The Func that defines what particular property to use to define if something is unique or distinct in this list.</param>
		/// <param name="comparer">The comparer to use to work out if the property provided previously is actually distinct, null for using the default comparer</param>
		/// <returns>A distinct list of elements from that original source list, filtered down using the given property/func to figure out if an element is distinct.</returns>
		 public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
																     Func<TSource, TKey> keySelector,
																     IEqualityComparer<TKey> comparer = null)
		 {
		     HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
		     foreach (TSource element in source)
		     {
		         if (knownKeys.Add(keySelector(element)))
		         {
		             yield return element;
		         }
		     }
		 }
	}
}
