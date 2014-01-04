/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 31/12/2013
 * Time: 16:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AuditTrailer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
			this.storeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tripManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addTripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yourSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.databaseManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainFormMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainFormMenuStrip
			// 
			this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.storeManagementToolStripMenuItem,
									this.tripManagementToolStripMenuItem,
									this.userManagementToolStripMenuItem,
									this.logOutToolStripMenuItem,
									this.databaseManagementToolStripMenuItem});
			this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainFormMenuStrip.Name = "mainFormMenuStrip";
			this.mainFormMenuStrip.Size = new System.Drawing.Size(620, 24);
			this.mainFormMenuStrip.TabIndex = 0;
			this.mainFormMenuStrip.Text = "menuStrip1";
			// 
			// storeManagementToolStripMenuItem
			// 
			this.storeManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.manageStoresToolStripMenuItem,
									this.addStoreToolStripMenuItem});
			this.storeManagementToolStripMenuItem.Name = "storeManagementToolStripMenuItem";
			this.storeManagementToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
			this.storeManagementToolStripMenuItem.Text = "Store Management";
			// 
			// manageStoresToolStripMenuItem
			// 
			this.manageStoresToolStripMenuItem.Name = "manageStoresToolStripMenuItem";
			this.manageStoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.manageStoresToolStripMenuItem.Text = "Manage Stores";
			this.manageStoresToolStripMenuItem.Click += new System.EventHandler(this.ManageStoresToolStripMenuItemClick);
			// 
			// addStoreToolStripMenuItem
			// 
			this.addStoreToolStripMenuItem.Name = "addStoreToolStripMenuItem";
			this.addStoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.addStoreToolStripMenuItem.Text = "Add Store";
			this.addStoreToolStripMenuItem.Click += new System.EventHandler(this.AddStoresToolStripMenuItemClick);
			// 
			// tripManagementToolStripMenuItem
			// 
			this.tripManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addTripToolStripMenuItem});
			this.tripManagementToolStripMenuItem.Name = "tripManagementToolStripMenuItem";
			this.tripManagementToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
			this.tripManagementToolStripMenuItem.Text = "Trip Management";
			// 
			// addTripToolStripMenuItem
			// 
			this.addTripToolStripMenuItem.Name = "addTripToolStripMenuItem";
			this.addTripToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			this.addTripToolStripMenuItem.Text = "Add Trip";
			this.addTripToolStripMenuItem.Click += new System.EventHandler(this.AddTripToolStripMenuItemClick);
			// 
			// userManagementToolStripMenuItem
			// 
			this.userManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.manageUsersToolStripMenuItem,
									this.yourSettingsToolStripMenuItem});
			this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
			this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
			this.userManagementToolStripMenuItem.Text = "User Management";
			// 
			// manageUsersToolStripMenuItem
			// 
			this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
			this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.manageUsersToolStripMenuItem.Text = "Manage Users";
			// 
			// yourSettingsToolStripMenuItem
			// 
			this.yourSettingsToolStripMenuItem.Name = "yourSettingsToolStripMenuItem";
			this.yourSettingsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.yourSettingsToolStripMenuItem.Text = "Your Settings";
			this.yourSettingsToolStripMenuItem.Click += new System.EventHandler(this.YourSettingsToolStripMenuItemClick);
			// 
			// logOutToolStripMenuItem
			// 
			this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
			this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.logOutToolStripMenuItem.Text = "Log Out";
			this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItemClick);
			// 
			// databaseManagementToolStripMenuItem
			// 
			this.databaseManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.backupToolStripMenuItem});
			this.databaseManagementToolStripMenuItem.Name = "databaseManagementToolStripMenuItem";
			this.databaseManagementToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
			this.databaseManagementToolStripMenuItem.Text = "Database Management";
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.backupToolStripMenuItem.Text = "Backup";
			this.backupToolStripMenuItem.Click += new System.EventHandler(this.BackupToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 298);
			this.ControlBox = false;
			this.Controls.Add(this.mainFormMenuStrip);
			this.MainMenuStrip = this.mainFormMenuStrip;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.mainFormMenuStrip.ResumeLayout(false);
			this.mainFormMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem databaseManagementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yourSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addTripToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tripManagementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addStoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageStoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem storeManagementToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainFormMenuStrip;
	}
}
