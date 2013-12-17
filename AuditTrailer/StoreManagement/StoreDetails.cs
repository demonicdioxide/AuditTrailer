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
    using AuditTrailer.Common;
    using AuditTrailer.Forms;

    public partial class StoreDetails : AuthorisedBaseForm
    {
        private Store store;

        public StoreDetails(User user, Store store)
            : base(user)
        {
            this.store = store;
        }

        protected override void LoadForm()
        {
            InitializeComponent();
        }

        private void StoreDetails_Load(object sender, EventArgs e)
        {
            LoadStoreDetailsIntoForm();
            LoadTripDetails();
        }

        private void LoadTripDetails()
        {
            TripManager tripManager = new TripManager(DatabaseConnector.Create());
            var trips = tripManager.GetTripsForStore(store);
            tripsGridView.DataSource =
                trips.Select(
                    t =>
                    new
                        {
                            User = t.User.FullName,
                            MedicineBought = t.MedicineBought,
                            BoxSize = t.BoxSizeBought,
                            Amount = t.AmountBought,
                            Date = t.DateOccurred
                        }).ToList();
        }

        private void LoadStoreDetailsIntoForm()
        {
            this.Text += string.Format(" {0} - {1}", store.Name, store.Location);
            nameTextBox.Text = store.Name;
            locationTextBox.Text = store.Location;
            startTimeTextBox.Text = TimeSpanUtilities.ToStringWitHoursAndMinutes(store.OpeningStartTime);
            endTimeTextBox.Text = TimeSpanUtilities.ToStringWitHoursAndMinutes(store.OpeningEndTime);
            isOnlineStoreCheckBox.Checked = store.IsOnlineStore;
        }
    }
}
