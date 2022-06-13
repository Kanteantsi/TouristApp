namespace Tourist__Office
{
    partial class TourGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TourGroupForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReloadTourGroupTable = new System.Windows.Forms.ToolStripButton();
            this.BackToMainApp = new System.Windows.Forms.ToolStripButton();
            this.TourGroupTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TourGroupTable)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadTourGroupTable,
            this.BackToMainApp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReloadTourGroupTable
            // 
            this.ReloadTourGroupTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReloadTourGroupTable.Image = ((System.Drawing.Image)(resources.GetObject("ReloadTourGroupTable.Image")));
            this.ReloadTourGroupTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadTourGroupTable.Name = "ReloadTourGroupTable";
            this.ReloadTourGroupTable.Size = new System.Drawing.Size(130, 22);
            this.ReloadTourGroupTable.Text = "ReloadTourGroupTable";
            this.ReloadTourGroupTable.Click += new System.EventHandler(this.ReloadTourGroupTable_Click);
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
            // TourGroupTable
            // 
            this.TourGroupTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TourGroupTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TourGroupTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TourGroupTable.Location = new System.Drawing.Point(0, 25);
            this.TourGroupTable.Name = "TourGroupTable";
            this.TourGroupTable.Size = new System.Drawing.Size(1904, 1016);
            this.TourGroupTable.TabIndex = 1;
            this.TourGroupTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TourGroupTable_CellContentClick);
            this.TourGroupTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TourGroupTable_CellValueChanged);
            this.TourGroupTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TourGroupTable_UserAddedRow);
            // 
            // TourGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TourGroupTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TourGroupForm";
            this.Text = "TourGroupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TourGroupForm_FormClosing);
            this.Load += new System.EventHandler(this.TourGroupForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TourGroupTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ReloadTourGroupTable;
        private System.Windows.Forms.ToolStripButton BackToMainApp;
        private System.Windows.Forms.DataGridView TourGroupTable;
    }
}