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
        	this.label1 = new System.Windows.Forms.Label();
        	this.roleLabel = new System.Windows.Forms.Label();
        	this.medicineGroupBox = new System.Windows.Forms.GroupBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.reminderRunOutDateLabel = new System.Windows.Forms.Label();
        	this.medicineComboBox = new System.Windows.Forms.ComboBox();
        	this.medicineGroupBox.SuspendLayout();
        	this.SuspendLayout();
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
        	this.roleLabel.Location = new System.Drawing.Point(118, 9);
        	this.roleLabel.Name = "roleLabel";
        	this.roleLabel.Size = new System.Drawing.Size(291, 23);
        	this.roleLabel.TabIndex = 2;
        	this.roleLabel.Text = "yourRole";
        	this.roleLabel.Click += new System.EventHandler(this.RoleLabelClick);
        	// 
        	// medicineGroupBox
        	// 
        	this.medicineGroupBox.Controls.Add(this.label3);
        	this.medicineGroupBox.Controls.Add(this.reminderRunOutDateLabel);
        	this.medicineGroupBox.Controls.Add(this.medicineComboBox);
        	this.medicineGroupBox.Location = new System.Drawing.Point(12, 35);
        	this.medicineGroupBox.Name = "medicineGroupBox";
        	this.medicineGroupBox.Size = new System.Drawing.Size(460, 71);
        	this.medicineGroupBox.TabIndex = 5;
        	this.medicineGroupBox.TabStop = false;
        	this.medicineGroupBox.Text = "Medicine";
        	// 
        	// label3
        	// 
        	this.label3.Location = new System.Drawing.Point(225, 19);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(100, 23);
        	this.label3.TabIndex = 2;
        	this.label3.Text = "Run out date:";
        	// 
        	// reminderRunOutDateLabel
        	// 
        	this.reminderRunOutDateLabel.Location = new System.Drawing.Point(360, 19);
        	this.reminderRunOutDateLabel.Name = "reminderRunOutDateLabel";
        	this.reminderRunOutDateLabel.Size = new System.Drawing.Size(100, 23);
        	this.reminderRunOutDateLabel.TabIndex = 1;
        	this.reminderRunOutDateLabel.Text = "label3";
        	// 
        	// medicineComboBox
        	// 
        	this.medicineComboBox.FormattingEnabled = true;
        	this.medicineComboBox.Location = new System.Drawing.Point(6, 19);
        	this.medicineComboBox.Name = "medicineComboBox";
        	this.medicineComboBox.Size = new System.Drawing.Size(213, 21);
        	this.medicineComboBox.TabIndex = 0;
        	this.medicineComboBox.SelectedIndexChanged += new System.EventHandler(this.MedicineComboBoxSelectedIndexChanged);
        	// 
        	// ManageYourSettings
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(484, 249);
        	this.Controls.Add(this.medicineGroupBox);
        	this.Controls.Add(this.roleLabel);
        	this.Controls.Add(this.label1);
        	this.Name = "ManageYourSettings";
        	this.Text = "Your Settings";
        	this.Load += new System.EventHandler(this.ManageYourSettings_Load);
        	this.medicineGroupBox.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox medicineComboBox;
        private System.Windows.Forms.Label reminderRunOutDateLabel;
        private System.Windows.Forms.GroupBox medicineGroupBox;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Label label1;

        #endregion

    }
}