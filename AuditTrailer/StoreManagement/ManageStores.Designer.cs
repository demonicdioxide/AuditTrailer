﻿namespace AuditTrailer.StoreManagement
{
    partial class ManageStores
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
        	this.storeCollectionCombox = new System.Windows.Forms.ComboBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.locationComboBox = new System.Windows.Forms.ComboBox();
        	this.viewMoreDetailsButton = new System.Windows.Forms.Button();
        	this.label3 = new System.Windows.Forms.Label();
        	this.sortByComboBox = new System.Windows.Forms.ComboBox();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(8, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(128, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "The following stores exist:";
        	// 
        	// storeCollectionCombox
        	// 
        	this.storeCollectionCombox.FormattingEnabled = true;
        	this.storeCollectionCombox.Location = new System.Drawing.Point(11, 83);
        	this.storeCollectionCombox.Name = "storeCollectionCombox";
        	this.storeCollectionCombox.Size = new System.Drawing.Size(121, 21);
        	this.storeCollectionCombox.TabIndex = 1;
        	this.storeCollectionCombox.SelectedIndexChanged += new System.EventHandler(this.storeCollectionCombox_SelectedIndexChanged);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(8, 67);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(38, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Name:";
        	// 
        	// locationComboBox
        	// 
        	this.locationComboBox.FormattingEnabled = true;
        	this.locationComboBox.Location = new System.Drawing.Point(148, 83);
        	this.locationComboBox.Name = "locationComboBox";
        	this.locationComboBox.Size = new System.Drawing.Size(121, 21);
        	this.locationComboBox.TabIndex = 3;
        	this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
        	this.locationComboBox.TextChanged += new System.EventHandler(this.locationComboBox_TextChanged);
        	// 
        	// viewMoreDetailsButton
        	// 
        	this.viewMoreDetailsButton.Location = new System.Drawing.Point(293, 80);
        	this.viewMoreDetailsButton.Name = "viewMoreDetailsButton";
        	this.viewMoreDetailsButton.Size = new System.Drawing.Size(128, 24);
        	this.viewMoreDetailsButton.TabIndex = 4;
        	this.viewMoreDetailsButton.Text = "View Store Details";
        	this.viewMoreDetailsButton.UseVisualStyleBackColor = true;
        	this.viewMoreDetailsButton.Click += new System.EventHandler(this.viewMoreDetailsButton_Click);
        	// 
        	// label3
        	// 
        	this.label3.Location = new System.Drawing.Point(11, 34);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(134, 18);
        	this.label3.TabIndex = 5;
        	this.label3.Text = "Sort by descending:";
        	// 
        	// sortByComboBox
        	// 
        	this.sortByComboBox.FormattingEnabled = true;
        	this.sortByComboBox.Items.AddRange(new object[] {
			"Creation Date",
			"Last Trip Date"});
        	this.sortByComboBox.Location = new System.Drawing.Point(148, 31);
        	this.sortByComboBox.Name = "sortByComboBox";
        	this.sortByComboBox.Size = new System.Drawing.Size(121, 21);
        	this.sortByComboBox.TabIndex = 6;
        	this.sortByComboBox.SelectionChangeCommitted += new System.EventHandler(this.SortByComboBoxSelectionChangeCommitted);
        	// 
        	// ManageStores
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(433, 127);
        	this.Controls.Add(this.sortByComboBox);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.viewMoreDetailsButton);
        	this.Controls.Add(this.locationComboBox);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.storeCollectionCombox);
        	this.Controls.Add(this.label1);
        	this.Name = "ManageStores";
        	this.Text = "ManageStores";
        	this.Load += new System.EventHandler(this.ManageStores_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sortByComboBox;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox storeCollectionCombox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Button viewMoreDetailsButton;
    }
}