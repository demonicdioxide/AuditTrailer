/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

using Nustache.Core;
using AuditTrailer.Application.Model;

namespace AuditTrailer.Application.Email.Templating
{
	/// <summary>
	/// Description of Templator.
	/// </summary>
	public class Templator
	{
		public ReminderResponse ReminderResponse { get; set; }
		
		public string ForgottenPasswordCode { get; set; }
		
		public string RenderReminderEmailToString()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "RunOutDate", ReminderResponse.ExpiryDate.ToLongDateString() },
				{ "Name", ReminderResponse.Medicine.Name }
			};
			string path = Path.Combine(ConfigurationManager.AppSettings["templates.folder"], "remindertemplate.htm");
			return Render.FileToString(path, data, RenderContextBehaviour.GetDefaultRenderContextBehaviour());
		}
		
		public string RenderForgottenPasswordEmailToString()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "ForgottenPasswordCode", ForgottenPasswordCode }
			};
			string path = Path.Combine(ConfigurationManager.AppSettings["templates.folder"], "forgottenpasswordtemplate.htm");
			return Render.FileToString(path, data, RenderContextBehaviour.GetDefaultRenderContextBehaviour());
		}
	}
}
