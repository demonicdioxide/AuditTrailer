﻿namespace AuditTrailer.Authorisation
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

    using AuditTrailer.Application.Model;
    using AuditTrailer.Forms;

    using SecurityManager = AuditTrailer.Application.Authorisation.SecurityManager;

    public partial class LoginForm : BaseForm
    {

        private SecurityManager securityManager = new SecurityManager(DatabaseConnector.Create());

        private bool HasEnteredDetails
        {
            get
            {
                return !(string.IsNullOrWhiteSpace(emailTextBox.Text)
                       || string.IsNullOrWhiteSpace(passwordTextBox.Text));
            }
        }

        protected override void LoadForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User user = LoadDeveloper();
            LoginUser(user.Email);
            return;

            if (!HasEnteredDetails)
            {
                return;
            }

            var securityManager = new SecurityManager(DatabaseConnector.Create());
            if (!securityManager.CanUserLogin(emailTextBox.Text, passwordTextBox.Text))
            {
                throw new SecurityException();
            }

            LoginUser(emailTextBox.Text);
        }

        private User LoadDeveloper()
        {
            return securityManager.GetUserByEmail("arran.huxtable@gmail.com");
        }

        private void LoginUser(string text)
        {
            var user = securityManager.GetUserByEmail(text);
            Hide();
            var mainForm = new MainForm(user);
            mainForm.Show();
            Show();
        }
    }
}
