/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using AuditTrailer.Application.Logging;
using AuditTrailer.Application.Net;

namespace AuditTrailer.Application.Email
{
	/// <summary>
	/// Description of EmailSender.
	/// </summary>
	public class EmailSender
	{
		public string Recipient { get; set; }
		private InternetManager NetManager { get; set; }
		
		public EmailSender()
		{
			NetManager = new InternetManager();
		}
		
		
		public void SendEmail(string email)
		{
			if (!NetManager.HasBasicInternetConnection()) {
				Log.Write("Not sending email due to no internet connection", LogLevel.Warning);
				return;
			}
			
			var client = new SmtpClient();
			
			client.Host = "smtp.gmail.com";
			client.Port = 587;
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			string username = ConfigurationManager.AppSettings["gmail.username"];
			string password = ConfigurationManager.AppSettings["gmail.password"];
			client.Credentials = new NetworkCredential(username, password);
			using (var message = new MailMessage(username, Recipient))
			{
				message.From = new MailAddress(username, "Audit Trailer Reminder");
				message.Subject = "Audit Trailer Reminder";
				message.Body = email;
				message.IsBodyHtml = true;
				client.Send(message);
			}
			
		}
		
		public void SendEmailAsync(string email)
		{
			var client = new SmtpClient();
			
			client.Host = "smtp.gmail.com";
			client.Port = 587;
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			string username = ConfigurationManager.AppSettings["gmail.username"];
			string password = ConfigurationManager.AppSettings["gmail.password"];
			client.Credentials = new NetworkCredential(username, password);
			using (var message = new MailMessage(username, Recipient))
			{
				message.From = new MailAddress(username, "Audit Trailer Reminder");
				message.Subject = "Audit Trailer Reminder";
				message.Body = email;
				message.IsBodyHtml = true;
				client.SendAsync(message, message);
			}
		}
	}
}
