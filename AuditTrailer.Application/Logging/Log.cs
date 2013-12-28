/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 28/12/2013
 * Time: 10:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace AuditTrailer.Application.Logging
{
	/// <summary>
	/// Description of Log.
	/// </summary>
	public class Log
	{		
		public static void Write(string message, LogLevel level)
		{
			using (var streamWriter = new StreamWriter(@"log.txt"))
			{
				streamWriter.WriteLine();
				streamWriter.WriteLine("Level: " + level.ToString());
				streamWriter.WriteLine("Date: " + DateTime.Now);
				streamWriter.WriteLine(message);
			}
		}
		
		public static void WriteException(Exception ex, string message)
		{
			Write(message + " " + ex.ToString(), LogLevel.Critical);
		}
	}
}
