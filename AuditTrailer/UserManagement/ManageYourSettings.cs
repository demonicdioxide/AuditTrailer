using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuditTrailer.UserManagement
{
    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    public partial class ManageYourSettings : AuthorisedBaseForm
    {
        public ManageYourSettings(User user) : base(user)
        {
            InitializeComponent();
        }

        private void ManageYourSettings_Load(object sender, EventArgs e)
        {
        	roleLabel.Text = SecurityManager.GetRoleDisplayName(LoggedInUser.Role);
        }
    }
}
