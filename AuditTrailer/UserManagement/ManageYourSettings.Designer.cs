namespace AuditTrailer.UserManagement
{
    partial class ManageYourSettings
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
        	this.button1 = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.roleLabel = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(27, 162);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "button1";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(100, 23);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Your Role:";
        	// 
        	// roleLabel
        	// 
        	this.roleLabel.Location = new System.Drawing.Point(74, 9);
        	this.roleLabel.Name = "roleLabel";
        	this.roleLabel.Size = new System.Drawing.Size(335, 23);
        	this.roleLabel.TabIndex = 2;
        	this.roleLabel.Text = "label2";
        	// 
        	// ManageYourSettings
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(421, 304);
        	this.Controls.Add(this.roleLabel);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.button1);
        	this.Name = "ManageYourSettings";
        	this.Text = "ManageYourSettings";
        	this.Load += new System.EventHandler(this.ManageYourSettings_Load);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.Button button1;
    }
}