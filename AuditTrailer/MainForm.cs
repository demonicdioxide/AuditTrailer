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
            var manageStoresForm = new ManageStores(LoggedInUser);
            manageStoresForm.Show();
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
    }
}
