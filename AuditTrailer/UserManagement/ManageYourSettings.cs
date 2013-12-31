using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AuditTrailer.Application.Managers;

namespace AuditTrailer.UserManagement
{
    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    public partial class ManageYourSettings : AuthorisedBaseForm
    {
    	private ReminderManager _reminderManager;
    	private CollectionManager _collectionManager;
    	private Dictionary<string, DateTime> _runOutMappings;
    	
        public ManageYourSettings(User user) : base(user)
        {
            InitializeComponent();
            _reminderManager = new ReminderManager();
            _collectionManager = new CollectionManager();
        }

        private void ManageYourSettings_Load(object sender, EventArgs e)
        {
        	reminderRunOutDateLabel.Visible = false;
        	roleLabel.Text = SecurityManager.GetRoleDisplayName(LoggedInUser.Role);
        	_runOutMappings = _reminderManager.GetMedicineReminderInformation(LoggedInUser).ToDictionary(t => t.First, t => t.Third);
        	var medicines = _collectionManager.GetAllPainReliefMedicine().Where(r => !r.IsPrescriptionOnly);
        	medicineComboBox.DataSource = medicines.Select(m => m.Name).ToList();
        }
        
        void RoleLabelClick(object sender, EventArgs e)
        {
        	
        }
        
        void MedicineComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
        	DateTime runOutTime;
        	string comboBoxValue = ((ComboBox)sender).SelectedItem.ToString();
        	if (_runOutMappings.TryGetValue(comboBoxValue, out runOutTime))
        	{
	        	reminderRunOutDateLabel.Visible = true;
	        	reminderRunOutDateLabel.Text = runOutTime.ToLongDateString();
        	}
    	    else 
    	    {
        	    reminderRunOutDateLabel.Visible = true;
				reminderRunOutDateLabel.Text = "N/A";        	    
    	    }

        }
    }
}
