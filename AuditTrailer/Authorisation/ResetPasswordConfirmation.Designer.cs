/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 24/12/2013
 * Time: 17:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AuditTrailer.Authorisation
{
	partial class ResetPasswordConfirmation
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
			this.confirmPasswordLabel = new System.Windows.Forms.Label();
			this.resetCodeTextBox = new System.Windows.Forms.TextBox();
			this.resetCodeLabel = new System.Windows.Forms.Label();
			this.submitResetCodeButton = new System.Windows.Forms.Button();
			this.submitPasswordChangeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// passwordLabel
			// 
			this.passwordLabel.Enabled = false;
			this.passwordLabel.Location = new System.Drawing.Point(12, 99);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(100, 23);
			this.passwordLabel.TabIndex = 0;
			this.passwordLabel.Text = "Password:";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Enabled = false;
			this.passwordTextBox.Location = new System.Drawing.Point(143, 99);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(140, 20);
			this.passwordTextBox.TabIndex = 1;
			// 
			// confirmPasswordTextBox
			// 
			this.confirmPasswordTextBox.Enabled = false;
			this.confirmPasswordTextBox.Location = new System.Drawing.Point(143, 125);
			this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
			this.confirmPasswordTextBox.PasswordChar = '*';
			this.confirmPasswordTextBox.Size = new System.Drawing.Size(140, 20);
			this.confirmPasswordTextBox.TabIndex = 3;
			// 
			// confirmPasswordLabel
			// 
			this.confirmPasswordLabel.Enabled = false;
			this.confirmPasswordLabel.Location = new System.Drawing.Point(13, 125);
			this.confirmPasswordLabel.Name = "confirmPasswordLabel";
			this.confirmPasswordLabel.Size = new System.Drawing.Size(100, 23);
			this.confirmPasswordLabel.TabIndex = 2;
			this.confirmPasswordLabel.Text = "Confirm password:";
			// 
			// resetCodeTextBox
			// 
			this.resetCodeTextBox.Location = new System.Drawing.Point(143, 9);
			this.resetCodeTextBox.Name = "resetCodeTextBox";
			this.resetCodeTextBox.Size = new System.Drawing.Size(140, 20);
			this.resetCodeTextBox.TabIndex = 4;
			// 
			// resetCodeLabel
			// 
			this.resetCodeLabel.Location = new System.Drawing.Point(12, 9);
			this.resetCodeLabel.Name = "resetCodeLabel";
			this.resetCodeLabel.Size = new System.Drawing.Size(100, 23);
			this.resetCodeLabel.TabIndex = 5;
			this.resetCodeLabel.Text = "Reset code:";
			// 
			// submitResetCodeButton
			// 
			this.submitResetCodeButton.Location = new System.Drawing.Point(143, 35);
			this.submitResetCodeButton.Name = "submitResetCodeButton";
			this.submitResetCodeButton.Size = new System.Drawing.Size(140, 35);
			this.submitResetCodeButton.TabIndex = 6;
			this.submitResetCodeButton.Text = "Verify Reset Code";
			this.submitResetCodeButton.UseVisualStyleBackColor = true;
			this.submitResetCodeButton.Click += new System.EventHandler(this.SubmitResetCodeButtonClick);
			// 
			// submitPasswordChangeButton
			// 
			this.submitPasswordChangeButton.Location = new System.Drawing.Point(143, 152);
			this.submitPasswordChangeButton.Name = "submitPasswordChangeButton";
			this.submitPasswordChangeButton.Size = new System.Drawing.Size(140, 35);
			this.submitPasswordChangeButton.TabIndex = 7;
			this.submitPasswordChangeButton.Text = "Submit password change";
			this.submitPasswordChangeButton.UseVisualStyleBackColor = true;
			this.submitPasswordChangeButton.Click += new System.EventHandler(this.SubmitPasswordChangeButtonClick);
			// 
			// ResetPasswordConfirmation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 213);
			this.Controls.Add(this.submitPasswordChangeButton);
			this.Controls.Add(this.submitResetCodeButton);
			this.Controls.Add(this.resetCodeLabel);
			this.Controls.Add(this.resetCodeTextBox);
			this.Controls.Add(this.confirmPasswordTextBox);
			this.Controls.Add(this.confirmPasswordLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.passwordLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ResetPasswordConfirmation";
			this.Text = "Reset password for:";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button submitPasswordChangeButton;
		private System.Windows.Forms.Button submitResetCodeButton;
		private System.Windows.Forms.Label resetCodeLabel;
		private System.Windows.Forms.TextBox resetCodeTextBox;
		private System.Windows.Forms.Label confirmPasswordLabel;
		private System.Windows.Forms.TextBox confirmPasswordTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label passwordLabel;
	}
}
