
namespace Tourist__Office
{
    partial class ClientsGroupList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsGroupList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToMainApp = new System.Windows.Forms.ToolStripButton();
            this.ClientsGroupLists = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGroupLists)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToMainApp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToMainApp
            // 
            this.ToMainApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToMainApp.Image = ((System.Drawing.Image)(resources.GetObject("ToMainApp.Image")));
            this.ToMainApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToMainApp.Name = "ToMainApp";
            this.ToMainApp.Size = new System.Drawing.Size(78, 22);
            this.ToMainApp.Text = "To Main App";
            this.ToMainApp.Click += new System.EventHandler(this.ToMainApp_Click);
            // 
            // ClientsGroupLists
            // 
            this.ClientsGroupLists.AllowUserToAddRows = false;
            this.ClientsGroupLists.AllowUserToDeleteRows = false;
            this.ClientsGroupLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsGroupLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsGroupLists.Location = new System.Drawing.Point(0, 25);
            this.ClientsGroupLists.Name = "ClientsGroupLists";
            this.ClientsGroupLists.Size = new System.Drawing.Size(1904, 1016);
            this.ClientsGroupLists.TabIndex = 1;
            // 
            // ClientsGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.ClientsGroupLists);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ClientsGroupList";
            this.Text = "ClientsGroupList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientsGroupList_FormClosing);
            this.Load += new System.EventHandler(this.ClientsGroupList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGroupLists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToMainApp;
        private System.Windows.Forms.DataGridView ClientsGroupLists;
    }
}