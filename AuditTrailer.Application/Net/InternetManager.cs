/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 14/04/2014
 * Time: 20:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.NetworkInformation;

namespace AuditTrailer.Application.Net
{
	/// <summary>
	/// Description of InternetManager.
	/// </summary>
	public class InternetManager
	{
		
		public bool HasBasicInternetConnection()
		{
			bool hasBasicConnection = false; // assume no
			using (Ping pinger = new Ping()) {
				// lets contact the router first
				bool hasRouterConnection = pinger.Send("192.168.0.1").Status == IPStatus.Success;
				if (hasRouterConnection) {
					// so we can connect to the outside world?
					hasBasicConnection = pinger.Send("www.google.com").Status == IPStatus.Success;
					
				}
			}
			
			return hasBasicConnection;
		}
	}
}
