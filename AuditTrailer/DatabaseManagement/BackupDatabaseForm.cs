/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 04/01/2014
 * Time: 23:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using AuditTrailer.Application.Model;
using AuditTrailer.Authorisation;
using AuditTrailer.Forms;

namespace AuditTrailer.DatabaseManagement
{
	/// <summary>
	/// Description of BackupDatabaseForm.
	/// </summary>
	public partial class BackupDatabaseForm : AuthorisedBaseForm
	{
		public BackupDatabaseForm(User user) : base(user)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		protected override void LoadForm()
		{
			InitializeComponent();
		}
	}
}
