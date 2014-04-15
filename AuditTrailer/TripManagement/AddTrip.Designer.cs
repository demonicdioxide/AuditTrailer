namespace AuditTrailer.TripManagement
{
    partial class AddTrip
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
        	this.btnSubmit = new System.Windows.Forms.Button();
        	this.dropdownStores = new System.Windows.Forms.ComboBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.lastVisitedLabel = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.dateOccureddtPicker = new System.Windows.Forms.DateTimePicker();
        	this.medicineComboBox = new System.Windows.Forms.ComboBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.amountBoughtNumericTextBox = new System.Windows.Forms.NumericUpDown();
        	this.label5 = new System.Windows.Forms.Label();
        	this.boxSizeDropDown = new System.Windows.Forms.ComboBox();
        	this.onlineToolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.label6 = new System.Windows.Forms.Label();
        	this.notesTextBox = new System.Windows.Forms.TextBox();
        	((System.ComponentModel.ISupportInitialize)(this.amountBoughtNumericTextBox)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// btnSubmit
        	// 
        	this.btnSubmit.Location = new System.Drawing.Point(390, 202);
        	this.btnSubmit.Name = "btnSubmit";
        	this.btnSubmit.Size = new System.Drawing.Size(107, 64);
        	this.btnSubmit.TabIndex = 0;
        	this.btnSubmit.Text = "Submit Trip";
        	this.btnSubmit.UseVisualStyleBackColor = true;
        	this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
        	// 
        	// dropdownStores
        	// 
        	this.dropdownStores.FormattingEnabled = true;
        	this.dropdownStores.Location = new System.Drawing.Point(113, 6);
        	this.dropdownStores.Name = "dropdownStores";
        	this.dropdownStores.Size = new System.Drawing.Size(200, 21);
        	this.dropdownStores.TabIndex = 1;
        	this.dropdownStores.SelectedIndexChanged += new System.EventHandler(this.dropdownStores_SelectedIndexChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(28, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(35, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Store:";
        	// 
        	// lastVisitedLabel
        	// 
        	this.lastVisitedLabel.AutoSize = true;
        	this.lastVisitedLabel.Location = new System.Drawing.Point(330, 9);
        	this.lastVisitedLabel.Name = "lastVisitedLabel";
        	this.lastVisitedLabel.Size = new System.Drawing.Size(63, 13);
        	this.lastVisitedLabel.TabIndex = 3;
        	this.lastVisitedLabel.Text = "Last visited:";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 49);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(80, 13);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "Date Occurred:";
        	// 
        	// dateOccureddtPicker
        	// 
        	this.dateOccureddtPicker.Location = new System.Drawing.Point(113, 42);
        	this.dateOccureddtPicker.Name = "dateOccureddtPicker";
        	this.dateOccureddtPicker.Size = new System.Drawing.Size(200, 20);
        	this.dateOccureddtPicker.TabIndex = 5;
        	// 
        	// medicineComboBox
        	// 
        	this.medicineComboBox.FormattingEnabled = true;
        	this.medicineComboBox.Location = new System.Drawing.Point(113, 78);
        	this.medicineComboBox.Name = "medicineComboBox";
        	this.medicineComboBox.Size = new System.Drawing.Size(200, 21);
        	this.medicineComboBox.TabIndex = 6;
        	this.medicineComboBox.SelectedIndexChanged += new System.EventHandler(this.medicineComboBox_SelectedIndexChanged);
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 81);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(90, 13);
        	this.label3.TabIndex = 7;
        	this.label3.Text = "Medicine Bought:";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(12, 145);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(83, 13);
        	this.label4.TabIndex = 8;
        	this.label4.Text = "Amount Bought:";
        	// 
        	// amountBoughtNumericTextBox
        	// 
        	this.amountBoughtNumericTextBox.Location = new System.Drawing.Point(113, 143);
        	this.amountBoughtNumericTextBox.Name = "amountBoughtNumericTextBox";
        	this.amountBoughtNumericTextBox.Size = new System.Drawing.Size(200, 20);
        	this.amountBoughtNumericTextBox.TabIndex = 9;
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(28, 117);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(51, 13);
        	this.label5.TabIndex = 11;
        	this.label5.Text = "Box Size:";
        	// 
        	// boxSizeDropDown
        	// 
        	this.boxSizeDropDown.FormattingEnabled = true;
        	this.boxSizeDropDown.Location = new System.Drawing.Point(113, 114);
        	this.boxSizeDropDown.Name = "boxSizeDropDown";
        	this.boxSizeDropDown.Size = new System.Drawing.Size(200, 21);
        	this.boxSizeDropDown.TabIndex = 12;
        	// label6
        	// 
        	this.label6.Location = new System.Drawing.Point(28, 178);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(74, 25);
        	this.label6.TabIndex = 13;
        	this.label6.Text = "Notes:";
        	// 
        	// notesTextBox
        	// 
        	this.notesTextBox.Location = new System.Drawing.Point(113, 175);
        	this.notesTextBox.Multiline = true;
        	this.notesTextBox.Name = "notesTextBox";
        	this.notesTextBox.Size = new System.Drawing.Size(200, 91);
        	this.notesTextBox.TabIndex = 14;
        	// 
        	// AddTrip
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(509, 278);
        	this.Controls.Add(this.notesTextBox);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.boxSizeDropDown);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.amountBoughtNumericTextBox);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.medicineComboBox);
        	this.Controls.Add(this.dateOccureddtPicker);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.lastVisitedLabel);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.dropdownStores);
        	this.Controls.Add(this.btnSubmit);
        	this.Name = "AddTrip";
        	this.Text = "AddTrip";
        	this.Load += new System.EventHandler(this.AddTrip_Load);
        	((System.ComponentModel.ISupportInitialize)(this.amountBoughtNumericTextBox)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip onlineToolTip;

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox dropdownStores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastVisitedLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateOccureddtPicker;
        private System.Windows.Forms.ComboBox medicineComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown amountBoughtNumericTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox boxSizeDropDown;
    }
}