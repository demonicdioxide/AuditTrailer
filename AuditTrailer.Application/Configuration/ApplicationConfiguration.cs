/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 19/04/2014
 * Time: 09:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace AuditTrailer.Application.Configuration
{
	/// <summary>
	/// Description of ApplicationConfiguration.
	/// </summary>
	public class ApplicationConfiguration
	{
		private static bool _inPrivateMode;
		public static void SetApplicationConfiguration(bool inPrivateMode)
		{
			_inPrivateMode = inPrivateMode;
		}
		
		public static bool InPrivateMode { get { return _inPrivateMode; } }
	}
}
