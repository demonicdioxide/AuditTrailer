using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuditTrailer.TripManagement
{
    using System.Data.SQLite;

    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Managers;
    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    using Authorisation;

    public partial class AddTrip : AuthorisedBaseForm
    {
        private CollectionManager _collectionManager;

        private TripManager _tripManager;

        private DatabaseConnection _databaseConnection;

        private IEnumerable<Store> _stores;

        private IEnumerable<PainReliever> _medicines;
 
        private Dictionary<string, Trip> _storeTrips;

        private Store _lastSelectedStore;

        private PainReliever _lastSelectedMedicine;
 
        public AddTrip(User loggedInUser) : base(loggedInUser)
        {
            InitializeComponent();
            _databaseConnection = DatabaseConnector.Create();
            _collectionManager = new CollectionManager(_databaseConnection);
            _tripManager = new TripManager(_databaseConnection);
            _stores = _collectionManager.GetAllStores();
            _medicines = _collectionManager.GetAllPainReliefMedicine();
            _storeTrips = new Dictionary<string, Trip>();
            lastVisitedLabel.Visible = false;
        }

        private void dropdownStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox dropdownBox = (ComboBox)sender;
            Trip lastTrip;

            // do we have it in the cache?
            if (!_storeTrips.TryGetValue(dropdownBox.SelectedItem.ToString(), out lastTrip))
            {
                // no? lets go get it from the database
                var storeParts = dropdownBox.SelectedItem.ToString().Split('-').Select(s => s.Trim());
                var store = _stores.First(f => f.Name.Equals(storeParts.First()) && f.Location.Equals(storeParts.Last()));
                _lastSelectedStore = store;
                lastTrip = GetLastTripForStore(store);
            }

            // after all this, is it null? If so they really have not been there
            if (lastTrip == null)
            {
                lastVisitedLabel.Text = "Last visited: never"; 
            }
            else
            {
                lastVisitedLabel.Text = "Last visited: " + lastTrip.DateOccurred.ToString("dd/MM/yyyy HH:mm");
                _storeTrips.Add(dropdownBox.SelectedItem.ToString(), lastTrip);
            }

            lastVisitedLabel.Visible = true;
            
        }

        private void AddTrip_Load(object sender, EventArgs e)
        {
            dropdownStores.DataSource = _stores.Select(s => s.Name + " - " + s.Location).ToList();
            medicineComboBox.DataSource = _medicines.Select(p => p.Name).ToList();
        }

        private Trip GetLastTripForStore(Store store)
        {
            return _tripManager.GetTripsForStore(store).OrderByDescending(t => t.DateOccurred).LastOrDefault();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var trip = new Trip();
            trip.User = LoggedInUser;
            trip.DateOccurred = dateOccureddtPicker.Value;
            trip.Store = _lastSelectedStore;
            trip.MedicineDetails = new Tuple<string, int, int>(
                _lastSelectedMedicine.Name, int.Parse(boxSizeDropDown.SelectedItem.ToString()), (int)amountBoughtNumericTextBox.Value);
            trip.PainRelieverBought = _lastSelectedMedicine;
            _tripManager.AddTrip(trip);
            MessageBox.Show("Successfully added trip!");
        }

        private void medicineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox medicine = (ComboBox)sender;
            var name = medicine.SelectedItem.ToString();
            _lastSelectedMedicine = _medicines.First(f => f.Name.Equals(name));
            boxSizeDropDown.DataSource = _lastSelectedMedicine.BoxSizes.Select(b => b.Name).ToList();

        }
    }
}
