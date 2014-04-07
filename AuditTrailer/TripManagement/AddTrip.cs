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
            _medicines = _collectionManager.GetAllPainReliefMedicine().Where(p => !p.IsPrescriptionOnly);
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
            	if (dropdownBox.SelectedItem.ToString().Contains("-"))
            	{
                	var storeParts = dropdownBox.SelectedItem.ToString().Split('-').Select(s => s.Trim());
                	var store = _stores.First(f => f.Name.Equals(storeParts.First()) && f.Location.Equals(storeParts.Last()));            		
                	_lastSelectedStore = store;
            	}
            	else
            	{
            		_lastSelectedStore = _stores.First(f => f.Name.Equals(dropdownBox.SelectedItem.ToString()));
            	}

                lastTrip = GetLastTripForStore(_lastSelectedStore);
            }

            // after all this, is it null? If so they really have not been there
            if (lastTrip == null)
            {
                lastVisitedLabel.Text = "Last visited: never"; 
            }
            else
            {
            	lastVisitedLabel.Text = "Last visited: " + lastTrip.DateOccurred.ToLongDateString();
                _storeTrips.Add(dropdownBox.SelectedItem.ToString(), lastTrip);
            }

            lastVisitedLabel.Visible = true;
            
        }

        private void AddTrip_Load(object sender, EventArgs e)
        {
            dropdownStores.DataSource = _stores.Select(s =>
        	                                           {
        	                                           	if (!string.IsNullOrEmpty(s.Location))
        	                                           	{
        	                                           		return s.Name + " - " + s.Location;
        	                                           	}
        	                                           	
        	                                           	return s.Name;
        	                                           }).ToList();
            medicineComboBox.DataSource = _medicines.Select(p => p.Name).ToList();
            onlineToolTip.SetToolTip(dateOccureddtPicker, "If an online store, this will be the date the medicine was picked up from MailBoxEtc");
        }

        private Trip GetLastTripForStore(Store store)
        {
            return _tripManager.GetTripsForStore(store).OrderByDescending(t => t.DateOccurred).LastOrDefault();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
        	if (dropdownStores.SelectedItem == null || _lastSelectedStore == null) 
        	{
        		MessageBox.Show("You need to select a store!");
        		return;
        	}
        	
        	if (dateOccureddtPicker.Value.Equals(DateTime.MinValue))
        	{
        		MessageBox.Show("You should enter in a date that is valid!");
        		return;
        	}
        	
        	if (medicineComboBox.SelectedItem == null || _lastSelectedMedicine == null) 
        	{
        		MessageBox.Show("You need to select a medicine!");
        		return;
        	}
        	
        	if (boxSizeDropDown.SelectedItem == null) 
        	{
        		MessageBox.Show("You must select a box size!");
        		return;
        	}
        	
            var trip = new Trip();
            trip.User = LoggedInUser;
            trip.DateOccurred = dateOccureddtPicker.Value;
            trip.Store = _lastSelectedStore;
            trip.MedicineDetails = new Tuple<string, int, int>(
                _lastSelectedMedicine.Name, int.Parse(boxSizeDropDown.SelectedItem.ToString()), (int)amountBoughtNumericTextBox.Value);
            trip.PainRelieverBought = _lastSelectedMedicine;
            trip.Notes = notesTextBox.Text;
			_tripManager.AddTrip(trip);
            MessageBox.Show("Successfully added trip!");
            ClearStates();
        }

        private void medicineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox medicine = (ComboBox)sender;
            var name = medicine.SelectedItem.ToString();
            _lastSelectedMedicine = _medicines.First(f => f.Name.Equals(name));
            boxSizeDropDown.DataSource = _lastSelectedMedicine.BoxSizes.Select(b => b.Name).ToList();

        }
        
        private void ClearStates()
        {
        	dropdownStores.SelectedText = string.Empty;
        	dropdownStores.Text = string.Empty;
        	amountBoughtNumericTextBox.Value = 0;
        	dateOccureddtPicker.Value = DateTime.Today;
        	notesTextBox.Text = string.Empty;
        	boxSizeDropDown.SelectedText = string.Empty;
        	boxSizeDropDown.Text = string.Empty;
        	medicineComboBox.SelectedText = string.Empty;
        }
        
        void ToolTip1Popup(object sender, PopupEventArgs e)
        {        	
        }
    }
}
