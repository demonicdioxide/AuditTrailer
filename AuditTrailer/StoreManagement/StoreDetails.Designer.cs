namespace AuditTrailer.StoreManagement
{
    partial class StoreDetails
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
        	this.label2 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.startTimeTextBox = new System.Windows.Forms.TextBox();
        	this.locationTextBox = new System.Windows.Forms.TextBox();
        	this.nameTextBox = new System.Windows.Forms.TextBox();
        	this.endTimeTextBox = new System.Windows.Forms.TextBox();
        	this.tripsGridView = new System.Windows.Forms.DataGridView();
        	this.isOnlineStoreCheckBox = new System.Windows.Forms.CheckBox();
        	this.viewNotesButton = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.tripsGridView)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 12);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(38, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Name:";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 35);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(51, 13);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "Location:";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(12, 70);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(162, 13);
        	this.label4.TabIndex = 2;
        	this.label4.Text = "Most common opening time start:";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(12, 101);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(160, 13);
        	this.label5.TabIndex = 4;
        	this.label5.Text = "Most common opening time end:";
        	// 
        	// startTimeTextBox
        	// 
        	this.startTimeTextBox.Location = new System.Drawing.Point(181, 67);
        	this.startTimeTextBox.Name = "startTimeTextBox";
        	this.startTimeTextBox.Size = new System.Drawing.Size(100, 20);
        	this.startTimeTextBox.TabIndex = 5;
        	// 
        	// locationTextBox
        	// 
        	this.locationTextBox.Location = new System.Drawing.Point(181, 32);
        	this.locationTextBox.Name = "locationTextBox";
        	this.locationTextBox.Size = new System.Drawing.Size(100, 20);
        	this.locationTextBox.TabIndex = 6;
        	// 
        	// nameTextBox
        	// 
        	this.nameTextBox.Location = new System.Drawing.Point(181, 9);
        	this.nameTextBox.Name = "nameTextBox";
        	this.nameTextBox.Size = new System.Drawing.Size(100, 20);
        	this.nameTextBox.TabIndex = 7;
        	// 
        	// endTimeTextBox
        	// 
        	this.endTimeTextBox.Location = new System.Drawing.Point(181, 98);
        	this.endTimeTextBox.Name = "endTimeTextBox";
        	this.endTimeTextBox.Size = new System.Drawing.Size(100, 20);
        	this.endTimeTextBox.TabIndex = 8;
        	// 
        	// tripsGridView
        	// 
        	this.tripsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.tripsGridView.Location = new System.Drawing.Point(12, 124);
        	this.tripsGridView.Name = "tripsGridView";
        	this.tripsGridView.Size = new System.Drawing.Size(646, 150);
        	this.tripsGridView.TabIndex = 9;
        	// 
        	// isOnlineStoreCheckBox
        	// 
        	this.isOnlineStoreCheckBox.AutoSize = true;
        	this.isOnlineStoreCheckBox.Location = new System.Drawing.Point(374, 8);
        	this.isOnlineStoreCheckBox.Name = "isOnlineStoreCheckBox";
        	this.isOnlineStoreCheckBox.Size = new System.Drawing.Size(101, 17);
        	this.isOnlineStoreCheckBox.TabIndex = 11;
        	this.isOnlineStoreCheckBox.Text = "Is Online Store?";
        	this.isOnlineStoreCheckBox.UseVisualStyleBackColor = true;
        	// 
        	// viewNotesButton
        	// 
        	this.viewNotesButton.Location = new System.Drawing.Point(374, 35);
        	this.viewNotesButton.Name = "viewNotesButton";
        	this.viewNotesButton.Size = new System.Drawing.Size(151, 48);
        	this.viewNotesButton.TabIndex = 12;
        	this.viewNotesButton.Text = "View More Details (Notes)";
        	this.viewNotesButton.UseVisualStyleBackColor = true;
        	this.viewNotesButton.Click += new System.EventHandler(this.ViewNotesButtonClick);
        	// 
        	// StoreDetails
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(670, 279);
        	this.Controls.Add(this.viewNotesButton);
        	this.Controls.Add(this.isOnlineStoreCheckBox);
        	this.Controls.Add(this.tripsGridView);
        	this.Controls.Add(this.endTimeTextBox);
        	this.Controls.Add(this.nameTextBox);
        	this.Controls.Add(this.locationTextBox);
        	this.Controls.Add(this.startTimeTextBox);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Name = "StoreDetails";
        	this.Text = "Store Details for:";
        	this.Load += new System.EventHandler(this.StoreDetails_Load);
        	((System.ComponentModel.ISupportInitialize)(this.tripsGridView)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button viewNotesButton;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.DataGridView tripsGridView;
        private System.Windows.Forms.CheckBox isOnlineStoreCheckBox;
    }
}