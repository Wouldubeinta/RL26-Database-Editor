namespace RL26_Database_Editor
{
    partial class Raw_Team_Nines_Lineup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raw_Team_Nines_Lineup));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importCSVDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveChangers_toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.SaveChangers_toolStripDropDownButton,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 22);
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(184, 20);
            this.toolStripDropDownButton1.Text = "Team Nines Lineup DB Options";
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
            // SaveChangers_toolStripDropDownButton
            // 
            this.SaveChangers_toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveChangers_toolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveChangers_toolStripDropDownButton.Image")));
            this.SaveChangers_toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveChangers_toolStripDropDownButton.Name = "SaveChangers_toolStripDropDownButton";
            this.SaveChangers_toolStripDropDownButton.Size = new System.Drawing.Size(97, 20);
            this.SaveChangers_toolStripDropDownButton.Text = "Save Changers";
            this.SaveChangers_toolStripDropDownButton.Click += new System.EventHandler(this.SaveChangers_toolStripDropDownButton_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(369, 17);
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
            this.dataGridView1.Size = new System.Drawing.Size(967, 502);
            this.dataGridView1.TabIndex = 3;
            // 
            // Import_CSV_ofd
            // 
            this.Import_CSV_ofd.DefaultExt = "csv";
            this.Import_CSV_ofd.FileName = "TeamNinesLineupDB.csv";
            this.Import_CSV_ofd.Filter = "Team Nines Lineup CSV DB (*.csv)|*.csv";
            // 
            // Export_CSV_sfd
            // 
            this.Export_CSV_sfd.DefaultExt = "csv";
            this.Export_CSV_sfd.FileName = "TeamNinesLineupDB.csv";
            this.Export_CSV_sfd.Filter = "Team Nines Lineup CSV DB (*.csv)|*.csv";
            // 
            // Raw_Team_Nines_Lineup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 524);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Raw_Team_Nines_Lineup";
            this.Text = "Raw Team Nines Lineup";
            this.Load += new System.EventHandler(this.Raw_Team_Nines_Lineup_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton SaveChangers_toolStripDropDownButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog Import_CSV_ofd;
        private System.Windows.Forms.SaveFileDialog Export_CSV_sfd;
    }
}