namespace Tourist__Office
{
    partial class WorkWithRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkWithRequests));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReloadRequestsTable = new System.Windows.Forms.ToolStripButton();
            this.ToMainApp = new System.Windows.Forms.ToolStripButton();
            this.RequestsForManagerTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestsForManagerTable)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadRequestsTable,
            this.ToMainApp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReloadRequestsTable
            // 
            this.ReloadRequestsTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReloadRequestsTable.Image = ((System.Drawing.Image)(resources.GetObject("ReloadRequestsTable.Image")));
            this.ReloadRequestsTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadRequestsTable.Name = "ReloadRequestsTable";
            this.ReloadRequestsTable.Size = new System.Drawing.Size(121, 22);
            this.ReloadRequestsTable.Text = "ReloadRequestsTable";
            this.ReloadRequestsTable.Click += new System.EventHandler(this.ReloadRequestsTable_Click);
            // 
            // ToMainApp
            // 
            this.ToMainApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToMainApp.Image = ((System.Drawing.Image)(resources.GetObject("ToMainApp.Image")));
            this.ToMainApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToMainApp.Name = "ToMainApp";
            this.ToMainApp.Size = new System.Drawing.Size(72, 22);
            this.ToMainApp.Text = "ToMainApp";
            this.ToMainApp.Click += new System.EventHandler(this.ToMainApp_Click);
            // 
            // RequestsForManagerTable
            // 
            this.RequestsForManagerTable.AllowUserToAddRows = false;
            this.RequestsForManagerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RequestsForManagerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestsForManagerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestsForManagerTable.Location = new System.Drawing.Point(0, 25);
            this.RequestsForManagerTable.Name = "RequestsForManagerTable";
            this.RequestsForManagerTable.Size = new System.Drawing.Size(1904, 1016);
            this.RequestsForManagerTable.TabIndex = 1;
            this.RequestsForManagerTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestsForManagerTable_CellContentClick);
            this.RequestsForManagerTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestsForManagerTable_CellValueChanged);
            // 
            // WorkWithRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.RequestsForManagerTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorkWithRequests";
            this.Text = "WorkWithRequests";
            this.Load += new System.EventHandler(this.WorkWithRequests_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestsForManagerTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ReloadRequestsTable;
        private System.Windows.Forms.ToolStripButton ToMainApp;
        private System.Windows.Forms.DataGridView RequestsForManagerTable;
    }
}