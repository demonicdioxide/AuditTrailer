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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.Name = nameTextBox.Text;
            store.Location = locationTextBox.Text;
            store.OpeningStartTime = TimeSpan.Parse(startTimeTextBox.Text);
            store.OpeningEndTime = TimeSpan.Parse(endTextBox.Text);
            _collectionManager.AddStore(store);
        }
    }
}
