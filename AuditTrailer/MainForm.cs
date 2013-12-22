using AuditTrailer.UserManagement;
namespace AuditTrailer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using StoreManagement;
    using AuditTrailer.Application.Model;
    using TripManagement;
    using Forms;

    public partial class MainForm : AuthorisedBaseForm
    {

        public MainForm(User user) : base(user)
        {
        }

        private void manageStoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	var userSettingsForm = new ManageYourSettings(LoggedInUser);
        	userSettingsForm.Show();
        	
            //var manageStoresForm = new ManageStores(LoggedInUser);
            //manageStoresForm.Show();
        }

        protected override void LoadForm()
        {
            InitializeComponent();
        }

        private void addTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseForm addTripForm = new AddTrip(LoggedInUser);
            addTripForm.Show();

        }

        private void addStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseForm addStoreForm = new AddStoreForm(LoggedInUser);
            addStoreForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Dictionary<ToolStripMenuItem, RoleEnum> rolesRequired = new Dictionary<ToolStripMenuItem, RoleEnum>
                {
                    { addStoreToolStripMenuItem, RoleEnum.Moderator },
                    { addTripToolStripMenuItem, RoleEnum.User }
                };
            var results = rolesRequired.Select(
                s =>
                { 
                	return new { Item = s.Key, Allowed = SecurityManager.IsUserAllowedToAccessResource(LoggedInUser, s.Value)};
                });
            var allowedResources = results.Where(result => result.Allowed);
            var blockedResources = results.Where(result => !result.Allowed);
            
            foreach (var allowedResource in allowedResources) 
            {
            	allowedResource.Item.Visible = true;
            }
            
           	foreach (var blockedResource in blockedResources) 
            {
            	blockedResource.Item.Visible = false;
            }
            
                	
        }
    }
}
