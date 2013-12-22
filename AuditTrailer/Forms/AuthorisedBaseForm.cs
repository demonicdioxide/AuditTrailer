/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 22/12/2013
 * Time: 21:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using AuditTrailer.Application.Authorisation;
using AuditTrailer.Application.Database;
using AuditTrailer.Application.Model;

namespace AuditTrailer.Forms
{
	/// <summary>
	/// Description of AuthorisedBaseForm.
	/// </summary>
	public partial class AuthorisedBaseForm : BaseForm
	{
		public User LoggedInUser { get; set; }

		public SecurityManager SecurityManager
        {
            get
            {
                return new SecurityManager(DatabaseConnector.Create());
            }
        }

        public AuthorisedBaseForm(User loggedInUser)
        {
            LoggedInUser = loggedInUser;
            //LoadForm();
        }

        private AuthorisedBaseForm()
        {
            //InitializeComponent();
        }
	}
}
