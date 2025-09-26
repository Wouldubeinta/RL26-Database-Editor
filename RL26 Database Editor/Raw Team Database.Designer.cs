namespace RL26_Database_Editor
{
    partial class Raw_Team_Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raw_Team_Database));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importCSVDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Import_CSV_ofd = new System.Windows.Forms.OpenFileDialog();
            this.Export_CSV_sfd = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(997, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCSVDBToolStripMenuItem,
            this.exportCSVDBToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(112, 20);
            this.toolStripDropDownButton1.Text = "Team DB Options";
            // 
            // importCSVDBToolStripMenuItem
            // 
            this.importCSVDBToolStripMenuItem.Name = "importCSVDBToolStripMenuItem";
            this.importCSVDBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importCSVDBToolStripMenuItem.Text = "Import CSV DB";
            this.importCSVDBToolStripMenuItem.Click += new System.EventHandler(this.importCSVDBToolStripMenuItem_Click);
            // 
            // exportCSVDBToolStripMenuItem
            // 
            this.exportCSVDBToolStripMenuItem.Name = "exportCSVDBToolStripMenuItem";
            this.exportCSVDBToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportCSVDBToolStripMenuItem.Text = "Export CSV DB";
            this.exportCSVDBToolStripMenuItem.Click += new System.EventHandler(this.exportCSVDBToolStripMenuItem_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(100, 20);
            this.toolStripSplitButton1.Text = "Save Changers";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(468, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(997, 530);
            this.dataGridView1.TabIndex = 0;
            // 
            // Import_CSV_ofd
            // 
            this.Import_CSV_ofd.DefaultExt = "csv";
            this.Import_CSV_ofd.FileName = "TeamDB.csv";
            this.Import_CSV_ofd.Filter = "Team CSV DB (*.csv)|*.csv";
            // 
            // Export_CSV_sfd
            // 
            this.Export_CSV_sfd.DefaultExt = "csv";
            this.Export_CSV_sfd.FileName = "TeamDB.csv";
            this.Export_CSV_sfd.Filter = "Team CSV DB (*.csv)|*.csv";
            // 
            // Raw_Team_Database
            // 
            this.ClientSize = new System.Drawing.Size(997, 552);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Raw_Team_Database";
            this.Text = "Raw Team Database";
            this.Load += new System.EventHandler(this.Raw_Team_Database_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem importCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVDBToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Import_CSV_ofd;
        private System.Windows.Forms.SaveFileDialog Export_CSV_sfd;


    }
}