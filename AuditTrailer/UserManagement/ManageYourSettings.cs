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
    using AuditTrailer.Application;
    
    public partial class ManageYourSettings : AuthorisedBaseForm
    {
    	private ReminderManager _reminderManager;
    	private CollectionManager _collectionManager;
    	private IEnumerable<ReminderResponse> _runOutMappings;
    	
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
        	_runOutMappings = _reminderManager.GetMedicineReminderForUser(LoggedInUser);
        	var medicines = _collectionManager.GetAllPainReliefMedicine().Select(s => 
             {	
				if (s.HasAlias) 
				{
					return _collectionManager.GetPainRelieverByName(s.AliasedMedicine);
				}
				
				return s;
        	                                                                     }).DistinctBy(p => p.Name);
        	medicineComboBox.DataSource = medicines.Select(m => m.Name).ToList();
			medicineGroupBox.Text += " - " + _runOutMappings.Min(m => m.ExpiryDate).AddDays(-LoggedInUser.ReminderRangeInDays).ToLongDateString();
        }
        
        void RoleLabelClick(object sender, EventArgs e)
        {
        	
        }
        
        void MedicineComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
        	string comboBoxValue = ((ComboBox)sender).SelectedItem.ToString();
			ReminderResponse reminderResponseForMedicine = _runOutMappings.SingleOrDefault(s => s.Medicine.Name.Equals(comboBoxValue));
        	if (reminderResponseForMedicine != null)
        	{
	        	reminderRunOutDateLabel.Visible = true;
	        	reminderRunOutDateLabel.Text = reminderResponseForMedicine.ExpiryDate.ToLongDateString();
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
					
					bool isGlobalAdministrator = LoggedInUser.Role == RoleEnum.GlobalAdministrator;
					// global administrators are exempt from the password strength checker
					PasswordStrengthValidationResult result = isGlobalAdministrator ? GetSuccessfulResult() : SecurityManager.DoesPasswordMeetRequirements(passwordInFirstBox);
					
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
        
        private PasswordStrengthValidationResult GetSuccessfulResult()
        {
        	return new PasswordStrengthValidationResult
        	{
        		PasswordStrongEnough = true,
        		ValidationErrors = new List<string>()
        	};
        }
    }
}
