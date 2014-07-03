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

    public partial class ManageStores : AuthorisedBaseForm
    {
        private IEnumerable<Store> AllStores { get; set; } 
        private CollectionManager _collectionManager { get; set; }
        private TripManager _tripManager { get; set; }

        public ManageStores(User loggedInUser) : base(loggedInUser)
        {
            _collectionManager = new CollectionManager();
            _tripManager = new TripManager(DatabaseConnector.Create());
        }

        public void GetAllStores()
        {
        	// this needs to be more generic, but this hack will work for now
        	string sort = sortByComboBox.SelectedText.ToLower();
        	
        	switch (sort) 
        	{
        		case "last trip date":
        			AllStores = _collectionManager.GetAllStores().OrderByDescending(s => s.LastTripDate).ToList();
        			break;
        		default:
        			AllStores = _collectionManager.GetAllStores().ToList();
        			break;
        	}
        }

        private void ManageStores_Load(object sender, EventArgs e)
        {
            GetAllStores();
            LoadStores();
            viewMoreDetailsButton.Enabled = false;
        }

        private void LoadStores()
        {
        	storeCollectionCombox.Items.Clear();
            var distinctStores = AllStores.GroupBy(s => s.Name).Select(s => s.First());
            foreach (var store in distinctStores)
            {
                storeCollectionCombox.Items.Add(store);
            }
        }

        private void storeCollectionCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            locationComboBox.Items.Clear();
            locationComboBox.Text = string.Empty;
            CalculateLocationDropdown((ComboBox)sender);
            if (!((Store)storeCollectionCombox.SelectedItem).IsOnlineStore)
            {
            	viewMoreDetailsButton.Enabled = false;	
            	locationComboBox.Enabled = true;
            }
            else
            {
            	viewMoreDetailsButton.Enabled = true;
            	locationComboBox.Enabled = false;
            }
            
        }

        private void CalculateLocationDropdown(ComboBox sender)
        {
            var selectedStore = (Store)sender.SelectedItem;
            // get all stores with the same name
            var allSimilarStores = AllStores.Where(a => a.Name.Equals(selectedStore.Name));
            foreach (var similarStore in allSimilarStores)
            {
                locationComboBox.Items.Add(similarStore.Location);
            }
        }

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        	var selectedStore = (Store)storeCollectionCombox.SelectedItem;
        	if ((locationComboBox.SelectedItem != null && !string.IsNullOrEmpty(locationComboBox.Text)) || selectedStore.IsOnlineStore)
            {
                viewMoreDetailsButton.Enabled = true;
            }
        }

        private void viewMoreDetailsButton_Click(object sender, EventArgs e)
        {
            var store = CalculateStoreFromDropdowns();
            BaseForm storeDetailsForm = new StoreDetails(LoggedInUser, store);
            storeDetailsForm.Show();
        }

        private Store CalculateStoreFromDropdowns()
        {
            var selectedStoreInFirstDropdown = (Store)storeCollectionCombox.SelectedItem;
            
            if (selectedStoreInFirstDropdown.IsOnlineStore) 
            {
            	return selectedStoreInFirstDropdown;
            }
            
            // all stores that match the 'parent' name
            var allStoresThatHaveThatName = AllStores.Where(s => s.Name.Equals(selectedStoreInFirstDropdown.Name));

            // now filter down to the ones that have the location from the second dropdown

            var selectedLocation = locationComboBox.SelectedItem.ToString(); // we expect it to be a string, not a class/object

            var allStoresAtThatLocationToo = allStoresThatHaveThatName.Where(s => s.Location.Equals(selectedLocation));

            // we will only be expecting one
            return allStoresAtThatLocationToo.Single();
        }

        protected override void LoadForm()
        {
            InitializeComponent();
        }

        private void locationComboBox_TextChanged(object sender, EventArgs e)
        {
        	if (string.IsNullOrEmpty(locationComboBox.Text) && !((Store)storeCollectionCombox.SelectedItem).IsOnlineStore)
            {
                viewMoreDetailsButton.Enabled = false;
            }
        }
		void SortByComboBoxSelectionChangeCommitted(object sender, System.EventArgs e)
		{
			GetAllStores();
			LoadStores();
		}
    }
}
