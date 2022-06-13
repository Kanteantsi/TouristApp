namespace Tourist__Office
{
    partial class ClientsWorkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsWorkForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReloadClientTable = new System.Windows.Forms.ToolStripButton();
            this.BackToMainApp = new System.Windows.Forms.ToolStripButton();
            this.ClientsTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadClientTable,
            this.BackToMainApp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReloadClientTable
            // 
            this.ReloadClientTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReloadClientTable.Image = ((System.Drawing.Image)(resources.GetObject("ReloadClientTable.Image")));
            this.ReloadClientTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadClientTable.Name = "ReloadClientTable";
            this.ReloadClientTable.Size = new System.Drawing.Size(111, 22);
            this.ReloadClientTable.Text = "Reload Client Table";
            this.ReloadClientTable.Click += new System.EventHandler(this.ReloadClientTable_Click);
            // 
            // BackToMainApp
            // 
            this.BackToMainApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BackToMainApp.Image = ((System.Drawing.Image)(resources.GetObject("BackToMainApp.Image")));
            this.BackToMainApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackToMainApp.Name = "BackToMainApp";
            this.BackToMainApp.Size = new System.Drawing.Size(106, 22);
            this.BackToMainApp.Text = "Back To Main App";
            this.BackToMainApp.Click += new System.EventHandler(this.BackToMainApp_Click);
            // 
            // ClientsTable
            // 
            this.ClientsTable.AllowUserToAddRows = false;
            this.ClientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ClientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsTable.Location = new System.Drawing.Point(0, 25);
            this.ClientsTable.Name = "ClientsTable";
            this.ClientsTable.Size = new System.Drawing.Size(1904, 1016);
            this.ClientsTable.TabIndex = 1;
            this.ClientsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsTable_CellContentClick);
            this.ClientsTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsTable_CellValueChanged);
            this.ClientsTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ClientsTable_DataError);
            // 
            // ClientsWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.ClientsTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ClientsWorkForm";
            this.Text = "ClientsWorkForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientsWorkForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientsWorkForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ReloadClientTable;
        private System.Windows.Forms.ToolStripButton BackToMainApp;
        private System.Windows.Forms.DataGridView ClientsTable;
    }
}