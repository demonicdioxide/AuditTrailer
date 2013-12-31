using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AuditTrailer.Application.Authorisation;
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
        	medicineGroupBox.Text += " - " + _runOutMappings.Min(medicine => medicine.Value).AddDays(-7).ToLongDateString();
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
        
        void SubmitButtonClick(object sender, EventArgs e)
        {
        	bool hasEnteredPassword = !string.IsNullOrEmpty(passwordTextBox.Text);
        	bool hasConfirmedPassword = !string.IsNullOrEmpty(confirmPasswordTextBox.Text);
        	if (hasEnteredPassword && !hasConfirmedPassword) 
        	{
        		MessageBox.Show("You must enter in your new password twice!");
        	}
        	
        	if (hasEnteredPassword && hasConfirmedPassword) 
        	{
        		string passwordInFirstBox = passwordTextBox.Text;
				string passwordInConfirmBox = confirmPasswordTextBox.Text;
				if (passwordInFirstBox.Equals(passwordInConfirmBox))
				{
					
					PasswordStrengthValidationResult result = SecurityManager.DoesPasswordMeetRequirements(passwordInFirstBox);
					
					if (result.PasswordStrongEnough) 
					{
						SecurityManager.UpdateUsersPassword(LoggedInUser, passwordInFirstBox);
						MessageBox.Show("Updated your details!");
						passwordTextBox.Text = string.Empty;
						confirmPasswordTextBox.Text = string.Empty;
						passwordTextBox.Enabled = false;
						confirmPasswordTextBox.Enabled = false;
					}
					else
					{
						passwordTextBox.Text = string.Empty;
						confirmPasswordTextBox.Text = string.Empty;
						
						StringBuilder messageBuilder = new StringBuilder();
						messageBuilder.Append("Password entered does not meet our password strength requirements for the following reasons: ");
						messageBuilder.AppendLine();
						foreach (var validationError in result.ValidationErrors) 
						{
							messageBuilder.AppendLine(validationError);
						}
						
						MessageBox.Show(messageBuilder.ToString());
						
					}
					

				}
				else
				{
					MessageBox.Show("Password in both boxes do not match!");
					passwordTextBox.Text = string.Empty;
					confirmPasswordTextBox.Text = string.Empty;
			
				}
        	}
        }
    }
}
