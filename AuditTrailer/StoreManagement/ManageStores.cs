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

        public ManageStores(User loggedInUser) : base(loggedInUser)
        {
            _collectionManager = new CollectionManager();
        }

        public void GetAllStores()
        {
            AllStores =  _collectionManager.GetAllStores();
        }

        private void ManageStores_Load(object sender, EventArgs e)
        {
            GetAllStores();
            LoadStores();
        }

        private void LoadStores()
        {
            var distinctStores = AllStores.GroupBy(s => s.Name).Select(s => s.First());
            foreach (var store in distinctStores)
            {
                storeCollectionCombox.Items.Add(store);
            }
        }

        private void storeCollectionCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateLocationDropdown((ComboBox)sender);
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
    }
}
