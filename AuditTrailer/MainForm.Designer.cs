namespace AuditTrailer
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.storeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storeManagementToolStripMenuItem,
            this.tripManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // storeManagementToolStripMenuItem
            // 
            this.storeManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageStoresToolStripMenuItem,
            this.addStoreToolStripMenuItem});
            this.storeManagementToolStripMenuItem.Name = "storeManagementToolStripMenuItem";
            this.storeManagementToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.storeManagementToolStripMenuItem.Text = "Store Management";
            // 
            // manageStoresToolStripMenuItem
            // 
            this.manageStoresToolStripMenuItem.Name = "manageStoresToolStripMenuItem";
            this.manageStoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.manageStoresToolStripMenuItem.Text = "Manage Stores";
            this.manageStoresToolStripMenuItem.Click += new System.EventHandler(this.manageStoresToolStripMenuItem_Click);
            // 
            // tripManagementToolStripMenuItem
            // 
            this.tripManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTripToolStripMenuItem});
            this.tripManagementToolStripMenuItem.Name = "tripManagementToolStripMenuItem";
            this.tripManagementToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.tripManagementToolStripMenuItem.Text = "Trip Management";
            // 
            // addTripToolStripMenuItem
            // 
            this.addTripToolStripMenuItem.Name = "addTripToolStripMenuItem";
            this.addTripToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.addTripToolStripMenuItem.Text = "Add Trip";
            this.addTripToolStripMenuItem.Click += new System.EventHandler(this.addTripToolStripMenuItem_Click);
            // 
            // addStoreToolStripMenuItem
            // 
            this.addStoreToolStripMenuItem.Name = "addStoreToolStripMenuItem";
            this.addStoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addStoreToolStripMenuItem.Text = "Add Store";
            this.addStoreToolStripMenuItem.Click += new System.EventHandler(this.addStoreToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 280);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem storeManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStoreToolStripMenuItem;
    }
}

