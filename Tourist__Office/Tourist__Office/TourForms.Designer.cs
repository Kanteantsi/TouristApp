namespace Tourist__Office
{
    partial class TourForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TourForms));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReloadTourTable = new System.Windows.Forms.ToolStripButton();
            this.BackToMainApp = new System.Windows.Forms.ToolStripButton();
            this.TourTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TourTable)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadTourTable,
            this.BackToMainApp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReloadTourTable
            // 
            this.ReloadTourTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReloadTourTable.Image = ((System.Drawing.Image)(resources.GetObject("ReloadTourTable.Image")));
            this.ReloadTourTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadTourTable.Name = "ReloadTourTable";
            this.ReloadTourTable.Size = new System.Drawing.Size(103, 22);
            this.ReloadTourTable.Text = "Reload Tour Table";
            this.ReloadTourTable.Click += new System.EventHandler(this.ReloadTourTable_Click);
            // 
            // BackToMainApp
            // 
            this.BackToMainApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BackToMainApp.Image = ((System.Drawing.Image)(resources.GetObject("BackToMainApp.Image")));
            this.BackToMainApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackToMainApp.Name = "BackToMainApp";
            this.BackToMainApp.Size = new System.Drawing.Size(97, 22);
            this.BackToMainApp.Text = "BackToMainApp";
            this.BackToMainApp.Click += new System.EventHandler(this.BackToMainApp_Click);
            // 
            // TourTable
            // 
            this.TourTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TourTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TourTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TourTable.Location = new System.Drawing.Point(0, 25);
            this.TourTable.Name = "TourTable";
            this.TourTable.Size = new System.Drawing.Size(1904, 1016);
            this.TourTable.TabIndex = 1;
            this.TourTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TourTable_CellContentClick_1);
            this.TourTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TourTable_CellValueChanged_1);
            this.TourTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TourTable_UserAddedRow_1);
            // 
            // TourForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TourTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TourForms";
            this.Text = "TourForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TourForms_FormClosing);
            this.Load += new System.EventHandler(this.TourForms_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TourTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ReloadTourTable;
        private System.Windows.Forms.DataGridView TourTable;
        private System.Windows.Forms.ToolStripButton BackToMainApp;
    }
}