using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuditTrailer.StoreManagement
{
    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Managers;
    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    using Authorisation;
    
    public partial class AddStoreForm : AuthorisedBaseForm
    {

        private CollectionManager _collectionManager;

        public AddStoreForm(User loggedInUser) : base(loggedInUser)
        {
            InitializeComponent();
            _collectionManager = new CollectionManager(DatabaseConnector.Create());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.Name = nameTextBox.Text;
            store.Location = locationTextBox.Text;
            store.OpeningStartTime = startTimeTextBox.Enabled ? (TimeSpan?)TimeSpan.Parse(startTimeTextBox.Text) : null;
            store.OpeningEndTime = endTextBox.Enabled ? (TimeSpan?)TimeSpan.Parse(endTextBox.Text) : null;
            store.IsOnlineStore = isOnlineStoreCheckBox.Checked;
            _collectionManager.AddStore(store);
            MessageBox.Show("Successfully added store!");
            ClearStates();
        }
        
        private void ClearStates()
        {
        	nameTextBox.Text = string.Empty;
        	locationTextBox.Text = string.Empty;
        	isOnlineStoreCheckBox.Checked = false;
        	endTextBox.Text = string.Empty;
        	startTimeTextBox.Text = string.Empty;
        }
        
        void IsOnlineStoreCheckBoxCheckedChanged(object sender, EventArgs e)
        {
        	if (((CheckBox)sender).Checked) 
        	{
        		locationTextBox.Enabled = false;
        		startTimeTextBox.Enabled = false;
        		endTextBox.Enabled = false;
        	}
        	else
        	{
        		locationTextBox.Enabled = true;
        		startTimeTextBox.Enabled = true;
        		endTextBox.Enabled = true;	
        	}

        }
    }
}
