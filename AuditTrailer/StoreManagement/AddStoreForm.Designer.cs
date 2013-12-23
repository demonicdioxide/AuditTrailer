namespace AuditTrailer.StoreManagement
{
    partial class AddStoreForm
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
        	this.submitButton = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.nameTextBox = new System.Windows.Forms.TextBox();
        	this.locationTextBox = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.startTimeTextBox = new System.Windows.Forms.MaskedTextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.endTextBox = new System.Windows.Forms.MaskedTextBox();
        	this.isOnlineStoreCheckBox = new System.Windows.Forms.CheckBox();
        	this.extraDetailsGroupBox = new System.Windows.Forms.GroupBox();
        	this.packagingRatingUpDownBox = new System.Windows.Forms.NumericUpDown();
        	this.label6 = new System.Windows.Forms.Label();
        	this.notesTextBox = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.extraDetailsGroupBox.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.packagingRatingUpDownBox)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// submitButton
        	// 
        	this.submitButton.Location = new System.Drawing.Point(57, 157);
        	this.submitButton.Name = "submitButton";
        	this.submitButton.Size = new System.Drawing.Size(119, 57);
        	this.submitButton.TabIndex = 0;
        	this.submitButton.Text = "Submit";
        	this.submitButton.UseVisualStyleBackColor = true;
        	this.submitButton.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(38, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Name:";
        	// 
        	// nameTextBox
        	// 
        	this.nameTextBox.Location = new System.Drawing.Point(126, 6);
        	this.nameTextBox.Name = "nameTextBox";
        	this.nameTextBox.Size = new System.Drawing.Size(129, 20);
        	this.nameTextBox.TabIndex = 2;
        	// 
        	// locationTextBox
        	// 
        	this.locationTextBox.Location = new System.Drawing.Point(126, 37);
        	this.locationTextBox.Name = "locationTextBox";
        	this.locationTextBox.Size = new System.Drawing.Size(129, 20);
        	this.locationTextBox.TabIndex = 4;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 40);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(51, 13);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "Location:";
        	// 
        	// startTimeTextBox
        	// 
        	this.startTimeTextBox.Location = new System.Drawing.Point(126, 68);
        	this.startTimeTextBox.Mask = "00:00";
        	this.startTimeTextBox.Name = "startTimeTextBox";
        	this.startTimeTextBox.Size = new System.Drawing.Size(129, 20);
        	this.startTimeTextBox.TabIndex = 5;
        	this.startTimeTextBox.ValidatingType = typeof(System.DateTime);
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 71);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(101, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Opening Start Time:";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(12, 102);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(98, 13);
        	this.label4.TabIndex = 8;
        	this.label4.Text = "Opening End Time:";
        	// 
        	// endTextBox
        	// 
        	this.endTextBox.Location = new System.Drawing.Point(126, 99);
        	this.endTextBox.Mask = "00:00";
        	this.endTextBox.Name = "endTextBox";
        	this.endTextBox.Size = new System.Drawing.Size(129, 20);
        	this.endTextBox.TabIndex = 7;
        	this.endTextBox.ValidatingType = typeof(System.DateTime);
        	// 
        	// isOnlineStoreCheckBox
        	// 
        	this.isOnlineStoreCheckBox.AutoSize = true;
        	this.isOnlineStoreCheckBox.Location = new System.Drawing.Point(126, 126);
        	this.isOnlineStoreCheckBox.Name = "isOnlineStoreCheckBox";
        	this.isOnlineStoreCheckBox.Size = new System.Drawing.Size(101, 17);
        	this.isOnlineStoreCheckBox.TabIndex = 9;
        	this.isOnlineStoreCheckBox.Text = "Is Online Store?";
        	this.isOnlineStoreCheckBox.UseVisualStyleBackColor = true;
        	this.isOnlineStoreCheckBox.CheckedChanged += new System.EventHandler(this.IsOnlineStoreCheckBoxCheckedChanged);
        	// 
        	// extraDetailsGroupBox
        	// 
        	this.extraDetailsGroupBox.Controls.Add(this.packagingRatingUpDownBox);
        	this.extraDetailsGroupBox.Controls.Add(this.label6);
        	this.extraDetailsGroupBox.Controls.Add(this.notesTextBox);
        	this.extraDetailsGroupBox.Controls.Add(this.label5);
        	this.extraDetailsGroupBox.Location = new System.Drawing.Point(279, 6);
        	this.extraDetailsGroupBox.Name = "extraDetailsGroupBox";
        	this.extraDetailsGroupBox.Size = new System.Drawing.Size(384, 208);
        	this.extraDetailsGroupBox.TabIndex = 10;
        	this.extraDetailsGroupBox.TabStop = false;
        	this.extraDetailsGroupBox.Text = "Extra details:";
        	// 
        	// packagingRatingUpDownBox
        	// 
        	this.packagingRatingUpDownBox.Location = new System.Drawing.Point(113, 128);
        	this.packagingRatingUpDownBox.Name = "packagingRatingUpDownBox";
        	this.packagingRatingUpDownBox.Size = new System.Drawing.Size(120, 20);
        	this.packagingRatingUpDownBox.TabIndex = 3;
        	// 
        	// label6
        	// 
        	this.label6.Location = new System.Drawing.Point(7, 130);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(100, 23);
        	this.label6.TabIndex = 2;
        	this.label6.Text = "Packaging Rating:";
        	// 
        	// notesTextBox
        	// 
        	this.notesTextBox.Location = new System.Drawing.Point(113, 17);
        	this.notesTextBox.Multiline = true;
        	this.notesTextBox.Name = "notesTextBox";
        	this.notesTextBox.Size = new System.Drawing.Size(251, 92);
        	this.notesTextBox.TabIndex = 1;
        	// 
        	// label5
        	// 
        	this.label5.Location = new System.Drawing.Point(7, 20);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(100, 23);
        	this.label5.TabIndex = 0;
        	this.label5.Text = "Notes:";
        	// 
        	// AddStoreForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(685, 240);
        	this.Controls.Add(this.extraDetailsGroupBox);
        	this.Controls.Add(this.isOnlineStoreCheckBox);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.endTextBox);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.startTimeTextBox);
        	this.Controls.Add(this.locationTextBox);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.nameTextBox);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.submitButton);
        	this.Name = "AddStoreForm";
        	this.Text = "Add new store";
        	this.Load += new System.EventHandler(this.AddStoreFormLoad);
        	this.extraDetailsGroupBox.ResumeLayout(false);
        	this.extraDetailsGroupBox.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.packagingRatingUpDownBox)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown packagingRatingUpDownBox;
        private System.Windows.Forms.GroupBox extraDetailsGroupBox;

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox startTimeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox endTextBox;
        private System.Windows.Forms.CheckBox isOnlineStoreCheckBox;
    }
}