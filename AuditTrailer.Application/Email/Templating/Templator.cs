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
using System.IO;
using System.Linq;

using Nustache.Core;

namespace AuditTrailer.Application.Email.Templating
{
	/// <summary>
	/// Description of Templator.
	/// </summary>
	public class Templator
	{
		public DateTime ReminderDate { get; set; }
		
		public string ForgottenPasswordCode { get; set; }
		
		public string RenderReminderEmailToString()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "RunOutDate", ReminderDate.ToLongDateString() }
			};
			string path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Email"), Path.Combine("Templating", "remindertemplate.htm"));
			return Render.FileToString(path, data, RenderContextBehaviour.GetDefaultRenderContextBehaviour());
		}
		
		public string RenderForgottenPasswordEmailToString()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "ForgottenPasswordCode", ForgottenPasswordCode }
			};
			string path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Email"), Path.Combine("Templating", "forgottenpasswordtemplate.htm"));
			return Render.FileToString(path, data, RenderContextBehaviour.GetDefaultRenderContextBehaviour());
		}
	}
}
