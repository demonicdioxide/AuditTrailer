using System.Threading;
using AuditTrailer.Application.Database;
using AuditTrailer.Application.Email;
using AuditTrailer.Application.Email.Templating;

namespace AuditTrailer.Authorisation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Windows.Forms;
    using Application.Database;

	using AuditTrailer.Application.Configuration;
    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    using SecurityManager = AuditTrailer.Application.Authorisation.SecurityManager;

    public partial class LoginForm : BaseForm
    {
    	private int attemptedLogins;
        private SecurityManager securityManager;

        private bool HasEnteredDetails
        {
            get
            {
                return !(string.IsNullOrEmpty(emailTextBox.Text)
                       || string.IsNullOrEmpty(passwordTextBox.Text));
            }
        }

        protected override void LoadForm()
        {
            InitializeComponent();
            securityManager = new SecurityManager(DatabaseConnector.Create());
            attemptedLogins = 0;
			usernameToolTip.SetToolTip(emailLabel, "This is either your username or email address");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!HasEnteredDetails)
            {
            	MessageBox.Show("You must enter in your username and password to login!");
                return;
            }

            if (!securityManager.CanUserLogin(emailTextBox.Text, passwordTextBox.Text))
            {
            	// unneeded but defensive check
            	if (securityManager.AmountOfLoginAttemptsAllowed <= attemptedLogins) 
            	{
            		MessageBox.Show("You have entered incorrect details too many time! You are blocked from logging in!");
            		loginButton.Enabled = false;
            		return;
            	}
            	
            	attemptedLogins++;
            	MessageBox.Show("Incorrect login details, you have: " + (securityManager.AmountOfLoginAttemptsAllowed - attemptedLogins).ToString() + " attempts left!");
            	passwordTextBox.Text = string.Empty;
            	
            	
            	if (securityManager.AmountOfLoginAttemptsAllowed <= attemptedLogins) 
            	{
            		MessageBox.Show("You have entered incorrect details too many time! You are blocked from logging in!");
            		loginButton.Enabled = false;
            		return;
            	}
            	
            	return;
            }

            LoginUser(emailTextBox.Text);
        }
        
        private void LoginUser(string text)
        {
			User user = null;
            user = securityManager.GetUserByEmail(text);
			if (user == null) 
			{
				user = securityManager.GetUserByUsername(text);				
			}
            Hide();
			ApplicationConfiguration.SetApplicationConfiguration(privateModeCheckBox.Checked);
            var mainForm = new MainForm(user);
			
            mainForm.Show();
        }
        
        void ResetPasswordButtonClick(object sender, EventArgs e)
        {
        	
        	if (string.IsNullOrEmpty(emailTextBox.Text))
        	{
        		MessageBox.Show("You must enter in your email address into the email text box to begin with the reset password process!");
        		return;
        	}
        	
        	var dialogResult = MessageBox.Show("Would you like a password reset code to be emailed to you?", "Password reset", MessageBoxButtons.YesNo);
        	if (dialogResult == DialogResult.Yes) 
        	{
        		User user = null;
				user = securityManager.GetUserByEmail(emailTextBox.Text.Trim());
				if (user == null) 
				{
					user = securityManager.GetUserByUsername(emailTextBox.Text.Trim());
					if (user == null)
					{
						MessageBox.Show("User by the email or username of: " + emailTextBox.Text.Trim() + " does not exist!");
						return;
					}
				}
        		securityManager.DeleteAllForgottenPasswordRequestsForUser(user);
        		string code = securityManager.InsertForgottenPasswordRequestForUser(user);
        		var templator = new Templator { ForgottenPasswordCode = code };
        		string message = templator.RenderForgottenPasswordEmailToString();
        		var emailSender = new EmailSender { Recipient = user.Email };
        		
        		// send it async so we don't block the thread.
        		emailSender.SendEmail(message);
        		
        		passwordTextBox.Text = string.Empty;
				ApplicationConfiguration.SetApplicationConfiguration(privateModeCheckBox.Checked);
        		var resetConfirmationForm = new ResetPasswordConfirmation(user.Email);
        		resetConfirmationForm.ShowDialog();
        		if (resetConfirmationForm.WasResetSuccessful) 
        		{
        			attemptedLogins = 0;
        			loginButton.Enabled = true;
        		}
        		
        	}
        }
        
        void PasswordTextBoxKeyDown(object sender, KeyEventArgs e)
        {
        	if	(e.KeyCode == Keys.Enter)
        	{
        		loginButton_Click(sender, EventArgs.Empty);
        	}
        }
    }
}
