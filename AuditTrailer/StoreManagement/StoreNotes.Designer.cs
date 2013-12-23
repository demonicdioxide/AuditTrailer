/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AuditTrailer.StoreManagement
{
	partial class StoreNotes
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
			this.label1 = new System.Windows.Forms.Label();
			this.notesTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.packagingRatingTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Notes:";
			// 
			// notesTextBox
			// 
			this.notesTextBox.Location = new System.Drawing.Point(120, 13);
			this.notesTextBox.Multiline = true;
			this.notesTextBox.Name = "notesTextBox";
			this.notesTextBox.ReadOnly = true;
			this.notesTextBox.Size = new System.Drawing.Size(259, 100);
			this.notesTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Packaging Rating:";
			// 
			// packagingRatingTextBox
			// 
			this.packagingRatingTextBox.Location = new System.Drawing.Point(120, 135);
			this.packagingRatingTextBox.Name = "packagingRatingTextBox";
			this.packagingRatingTextBox.ReadOnly = true;
			this.packagingRatingTextBox.Size = new System.Drawing.Size(62, 20);
			this.packagingRatingTextBox.TabIndex = 3;
			// 
			// StoreNotes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 199);
			this.Controls.Add(this.packagingRatingTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.notesTextBox);
			this.Controls.Add(this.label1);
			this.Name = "StoreNotes";
			this.Text = "Store Notes for:";
			this.Load += new System.EventHandler(this.StoreNotesLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox packagingRatingTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox notesTextBox;
		private System.Windows.Forms.Label label1;
	}
}
