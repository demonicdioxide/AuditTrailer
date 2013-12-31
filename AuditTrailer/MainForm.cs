﻿/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 16:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using AuditTrailer.Application.Model;
using AuditTrailer.Forms;
using AuditTrailer.StoreManagement;
using AuditTrailer.TripManagement;
using AuditTrailer.UserManagement;

namespace AuditTrailer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : AuthorisedBaseForm
	{
		
		public MainForm(User user) : base(user)
        {
        	this.Text = "Logged in as: " + LoggedInUser.FullName;
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		private void PerformPermissionsCheck()
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
		
		protected override void LoadForm()
		{
			InitializeComponent();
		}
		
		void AddTripToolStripMenuItemClick(object sender, EventArgs e)
		{
			BaseForm addTripForm = new AddTrip(LoggedInUser);
            addTripForm.Show();
		}
		
		void YourSettingsToolStripMenuItemClick(object sender, EventArgs e)
		{
			var userSettingsForm = new ManageYourSettings(LoggedInUser);
        	userSettingsForm.Show();
		}
		
		void ManageStoresToolStripMenuItemClick(object sender, EventArgs e)
		{
			var manageStoresForm = new ManageStores(LoggedInUser);
            manageStoresForm.Show();
		}
		
		void AddStoresToolStripMenuItemClick(object sender, EventArgs e)
		{
			BaseForm addStoreForm = new AddStoreForm(LoggedInUser);
            addStoreForm.Show();
		}
	}
}
