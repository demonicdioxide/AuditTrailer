﻿namespace AuditTrailer.Authorisation
{
    using System.Windows.Forms;

    using AuditTrailer.Forms;

    public partial class LoginForm : BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	this.loginButton = new System.Windows.Forms.Button();
        	this.emailTextBox = new System.Windows.Forms.TextBox();
        	this.passwordTextBox = new System.Windows.Forms.TextBox();
        	this.emailLabel = new System.Windows.Forms.Label();
        	this.passwordLabel = new System.Windows.Forms.Label();
        	this.resetPasswordButton = new System.Windows.Forms.Button();
        	this.usernameToolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.privateModeCheckBox = new System.Windows.Forms.CheckBox();
        	this.SuspendLayout();
        	// 
        	// loginButton
        	// 
        	this.loginButton.Location = new System.Drawing.Point(12, 101);
        	this.loginButton.Name = "loginButton";
        	this.loginButton.Size = new System.Drawing.Size(107, 38);
        	this.loginButton.TabIndex = 3;
        	this.loginButton.Text = "Submit";
        	this.loginButton.UseVisualStyleBackColor = true;
        	this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
        	// 
        	// emailTextBox
        	// 
        	this.emailTextBox.Location = new System.Drawing.Point(74, 19);
        	this.emailTextBox.Name = "emailTextBox";
        	this.emailTextBox.Size = new System.Drawing.Size(220, 20);
        	this.emailTextBox.TabIndex = 1;
        	// 
        	// passwordTextBox
        	// 
        	this.passwordTextBox.Location = new System.Drawing.Point(74, 45);
        	this.passwordTextBox.Name = "passwordTextBox";
        	this.passwordTextBox.PasswordChar = '*';
        	this.passwordTextBox.Size = new System.Drawing.Size(220, 20);
        	this.passwordTextBox.TabIndex = 2;
        	this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBoxKeyDown);
        	// 
        	// emailLabel
        	// 
        	this.emailLabel.AutoSize = true;
        	this.emailLabel.Location = new System.Drawing.Point(12, 19);
        	this.emailLabel.Name = "emailLabel";
        	this.emailLabel.Size = new System.Drawing.Size(58, 13);
        	this.emailLabel.TabIndex = 3;
        	this.emailLabel.Text = "Username:";
        	// 
        	// passwordLabel
        	// 
        	this.passwordLabel.AutoSize = true;
        	this.passwordLabel.Location = new System.Drawing.Point(12, 45);
        	this.passwordLabel.Name = "passwordLabel";
        	this.passwordLabel.Size = new System.Drawing.Size(56, 13);
        	this.passwordLabel.TabIndex = 4;
        	this.passwordLabel.Text = "Password:";
        	// 
        	// resetPasswordButton
        	// 
        	this.resetPasswordButton.Location = new System.Drawing.Point(187, 101);
        	this.resetPasswordButton.Name = "resetPasswordButton";
        	this.resetPasswordButton.Size = new System.Drawing.Size(107, 38);
        	this.resetPasswordButton.TabIndex = 4;
        	this.resetPasswordButton.Text = "Forgotten Password?";
        	this.resetPasswordButton.UseVisualStyleBackColor = true;
        	this.resetPasswordButton.Click += new System.EventHandler(this.ResetPasswordButtonClick);
        	// 
        	// privateModeCheckBox
        	// 
        	this.privateModeCheckBox.Checked = true;
        	this.privateModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.privateModeCheckBox.Location = new System.Drawing.Point(100, 71);
        	this.privateModeCheckBox.Name = "privateModeCheckBox";
        	this.privateModeCheckBox.Size = new System.Drawing.Size(104, 24);
        	this.privateModeCheckBox.TabIndex = 5;
        	this.privateModeCheckBox.Text = "Private Mode?";
        	this.privateModeCheckBox.UseVisualStyleBackColor = true;
        	// 
        	// LoginForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(328, 185);
        	this.Controls.Add(this.privateModeCheckBox);
        	this.Controls.Add(this.resetPasswordButton);
        	this.Controls.Add(this.passwordLabel);
        	this.Controls.Add(this.emailLabel);
        	this.Controls.Add(this.passwordTextBox);
        	this.Controls.Add(this.emailTextBox);
        	this.Controls.Add(this.loginButton);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "LoginForm";
        	this.Text = "Login to the Audit Trailer";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.CheckBox privateModeCheckBox;
        private System.Windows.Forms.ToolTip usernameToolTip;
        private System.Windows.Forms.Button resetPasswordButton;

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
    }
}