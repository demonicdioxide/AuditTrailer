/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 24/12/2013
 * Time: 17:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AuditTrailer.Application.Authorisation;
using AuditTrailer.Application.Database;
using AuditTrailer.Application.Model;
using AuditTrailer.Forms;
using System.Collections;
using System.Collections.Generic;
namespace AuditTrailer.Authorisation
{
	/// <summary>
	/// Description of ResetPasswordConfirmation.
	/// </summary>
	public partial class ResetPasswordConfirmation : BaseForm
	{
		private SecurityManager securityManager;
		private string userEmailAddress;
		private User user;
		private bool successfulReset;
		public bool WasResetSuccessful
		{
			get
			{
				return successfulReset;
			}
		}
		
		public ResetPasswordConfirmation(string userEmail)
		{
			securityManager = new SecurityManager(DatabaseConnector.Create());
			userEmailAddress = userEmail;
			user = securityManager.GetUserByEmail(userEmailAddress);
			this.Text += " " + user.Email;
			successfulReset = false;
		}
		
		protected override void LoadForm()
		{
			InitializeComponent();
		}
		
		void SubmitResetCodeButtonClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(resetCodeTextBox.Text.Trim()))
			{
		    	MessageBox.Show("You must enter a reset code to verify!");
		    	return;
			}
			
			bool isCodeCorrect = securityManager.IsForgottenPasswordCodeCorrect(user, resetCodeTextBox.Text.Trim());
			if (!isCodeCorrect) 
			{
				MessageBox.Show("Reset password code is not correct! You must now resubmit the request!");
				securityManager.DeleteAllForgottenPasswordRequestsForUser(user);
				Close();
			}
			
			passwordTextBox.Enabled = true;
			passwordLabel.Enabled = true;
			confirmPasswordLabel.Enabled = true;
			confirmPasswordTextBox.Enabled = true;
			resetCodeTextBox.Enabled = false;
			resetCodeLabel.Enabled = false;
			submitResetCodeButton.Enabled = false;
		}
		
		void SubmitPasswordChangeButtonClick(object sender, EventArgs e)
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
					
					bool isGlobalAdministrator = user.Role == RoleEnum.GlobalAdministrator;
					// global administrators are exempt from the password strength checker
					PasswordStrengthValidationResult result = isGlobalAdministrator ? GetSuccessfulResult() : securityManager.DoesPasswordMeetRequirements(passwordInFirstBox);
					
					if (result.PasswordStrongEnough) 
					{
						securityManager.UpdateUsersPassword(user, passwordInFirstBox);
						MessageBox.Show("Updated your details!");
						securityManager.DeleteAllForgottenPasswordRequestsForUser(user);
						successfulReset = true;
						return;
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
