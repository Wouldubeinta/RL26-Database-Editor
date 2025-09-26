namespace RL26_Database_Editor
{
    partial class Mainform
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            writeDatabaseToolStripMenuItem = new ToolStripMenuItem();
            saveDatabaseToolStripMenuItem = new ToolStripMenuItem();
            compressDatabaseToolStripMenuItem = new ToolStripMenuItem();
            rawDatabasesToolStripMenuItem = new ToolStripMenuItem();
            rawTeamPlayersDBToolStripMenuItem = new ToolStripMenuItem();
            rawTeamLineupDBToolStripMenuItem = new ToolStripMenuItem();
            rawTeamNinesLineupDBToolStripMenuItem = new ToolStripMenuItem();
            RawTeamFeederClubsDB_ToolStripMenuItem = new ToolStripMenuItem();
            RawTeamFedFromClubsDB_ToolStripMenuItem = new ToolStripMenuItem();
            rawTeamDBToolStripMenuItem = new ToolStripMenuItem();
            rawPlayerDBToolStripMenuItem = new ToolStripMenuItem();
            rawPlayerSkillsDBToolStripMenuItem = new ToolStripMenuItem();
            SearchToolStripTextBox = new ToolStripTextBox();
            searchPlayerToolStripMenuItem = new ToolStripMenuItem();
            databaseQuerysToolStripMenuItem = new ToolStripMenuItem();
            allPlayerStatsToolStripMenuItem = new ToolStripMenuItem();
            aboutDatabaseToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            Progress_toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ProgressLabel = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            Teams_dataGridView = new DataGridView();
            Players_dataGridView = new DataGridView();
            Team_contextMenuStrip = new ContextMenuStrip(components);
            exportTeamListToolStripMenuItem = new ToolStripMenuItem();
            Player_contextMenuStrip = new ContextMenuStrip(components);
            exportPlayerListToolStripMenuItem = new ToolStripMenuItem();
            sfd_ExportTeamList = new SaveFileDialog();
            sfd_ExportPlayerList = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Teams_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Players_dataGridView).BeginInit();
            Team_contextMenuStrip.SuspendLayout();
            Player_contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, writeDatabaseToolStripMenuItem, rawDatabasesToolStripMenuItem, SearchToolStripTextBox, searchPlayerToolStripMenuItem, databaseQuerysToolStripMenuItem, aboutDatabaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1387, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.close_16;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // writeDatabaseToolStripMenuItem
            // 
            writeDatabaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveDatabaseToolStripMenuItem, compressDatabaseToolStripMenuItem });
            writeDatabaseToolStripMenuItem.Name = "writeDatabaseToolStripMenuItem";
            writeDatabaseToolStripMenuItem.Size = new Size(88, 23);
            writeDatabaseToolStripMenuItem.Text = "Save Options";
            // 
            // saveDatabaseToolStripMenuItem
            // 
            saveDatabaseToolStripMenuItem.Image = (Image)resources.GetObject("saveDatabaseToolStripMenuItem.Image");
            saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            saveDatabaseToolStripMenuItem.Size = new Size(180, 22);
            saveDatabaseToolStripMenuItem.Text = "Save Database";
            saveDatabaseToolStripMenuItem.Click += saveDatabaseToolStripMenuItem_Click;
            // 
            // compressDatabaseToolStripMenuItem
            // 
            compressDatabaseToolStripMenuItem.Image = Properties.Resources.winzip;
            compressDatabaseToolStripMenuItem.Name = "compressDatabaseToolStripMenuItem";
            compressDatabaseToolStripMenuItem.Size = new Size(180, 22);
            compressDatabaseToolStripMenuItem.Text = "Compress Database";
            compressDatabaseToolStripMenuItem.Click += compressDatabaseToolStripMenuItem_Click;
            // 
            // rawDatabasesToolStripMenuItem
            // 
            rawDatabasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rawTeamPlayersDBToolStripMenuItem, rawTeamLineupDBToolStripMenuItem, rawTeamNinesLineupDBToolStripMenuItem, RawTeamFeederClubsDB_ToolStripMenuItem, RawTeamFedFromClubsDB_ToolStripMenuItem, rawTeamDBToolStripMenuItem, rawPlayerDBToolStripMenuItem, rawPlayerSkillsDBToolStripMenuItem });
            rawDatabasesToolStripMenuItem.Name = "rawDatabasesToolStripMenuItem";
            rawDatabasesToolStripMenuItem.Size = new Size(97, 23);
            rawDatabasesToolStripMenuItem.Text = "Raw Databases";
            // 
            // rawTeamPlayersDBToolStripMenuItem
            // 
            rawTeamPlayersDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamPlayersDBToolStripMenuItem.Name = "rawTeamPlayersDBToolStripMenuItem";
            rawTeamPlayersDBToolStripMenuItem.Size = new Size(232, 22);
            rawTeamPlayersDBToolStripMenuItem.Text = "Raw Team Players DB";
            rawTeamPlayersDBToolStripMenuItem.Click += rawTeamPlayersDBToolStripMenuItem_Click;
            // 
            // rawTeamLineupDBToolStripMenuItem
            // 
            rawTeamLineupDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamLineupDBToolStripMenuItem.Name = "rawTeamLineupDBToolStripMenuItem";
            rawTeamLineupDBToolStripMenuItem.Size = new Size(232, 22);
            rawTeamLineupDBToolStripMenuItem.Text = "Raw Team Lineup DB";
            rawTeamLineupDBToolStripMenuItem.Click += rawTeamLineupDBToolStripMenuItem_Click;
            // 
            // rawTeamNinesLineupDBToolStripMenuItem
            // 
            rawTeamNinesLineupDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamNinesLineupDBToolStripMenuItem.Name = "rawTeamNinesLineupDBToolStripMenuItem";
            rawTeamNinesLineupDBToolStripMenuItem.Size = new Size(232, 22);
            rawTeamNinesLineupDBToolStripMenuItem.Text = "Raw Team Nines Lineup DB";
            rawTeamNinesLineupDBToolStripMenuItem.Click += rawTeamNinesLineupDBToolStripMenuItem_Click;
            // 
            // RawTeamFeederClubsDB_ToolStripMenuItem
            // 
            RawTeamFeederClubsDB_ToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            RawTeamFeederClubsDB_ToolStripMenuItem.Name = "RawTeamFeederClubsDB_ToolStripMenuItem";
            RawTeamFeederClubsDB_ToolStripMenuItem.Size = new Size(232, 22);
            RawTeamFeederClubsDB_ToolStripMenuItem.Text = "Raw Team Feeder Clubs DB";
            RawTeamFeederClubsDB_ToolStripMenuItem.Click += RawTeamFeederClubsDB_ToolStripMenuItem_Click;
            // 
            // RawTeamFedFromClubsDB_ToolStripMenuItem
            // 
            RawTeamFedFromClubsDB_ToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            RawTeamFedFromClubsDB_ToolStripMenuItem.Name = "RawTeamFedFromClubsDB_ToolStripMenuItem";
            RawTeamFedFromClubsDB_ToolStripMenuItem.Size = new Size(232, 22);
            RawTeamFedFromClubsDB_ToolStripMenuItem.Text = "Raw Team Fed From Clubs DB";
            RawTeamFedFromClubsDB_ToolStripMenuItem.Click += RawTeamFedFromClubsDB_ToolStripMenuItem_Click;
            // 
            // rawTeamDBToolStripMenuItem
            // 
            rawTeamDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawTeamDBToolStripMenuItem.Name = "rawTeamDBToolStripMenuItem";
            rawTeamDBToolStripMenuItem.Size = new Size(232, 22);
            rawTeamDBToolStripMenuItem.Text = "Raw Team DB";
            rawTeamDBToolStripMenuItem.Click += rawTeamDBToolStripMenuItem_Click;
            // 
            // rawPlayerDBToolStripMenuItem
            // 
            rawPlayerDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawPlayerDBToolStripMenuItem.Name = "rawPlayerDBToolStripMenuItem";
            rawPlayerDBToolStripMenuItem.Size = new Size(232, 22);
            rawPlayerDBToolStripMenuItem.Text = "Raw Player DB";
            rawPlayerDBToolStripMenuItem.Click += rawPlayerDBToolStripMenuItem_Click;
            // 
            // rawPlayerSkillsDBToolStripMenuItem
            // 
            rawPlayerSkillsDBToolStripMenuItem.Image = Properties.Resources.RawDatabase;
            rawPlayerSkillsDBToolStripMenuItem.Name = "rawPlayerSkillsDBToolStripMenuItem";
            rawPlayerSkillsDBToolStripMenuItem.Size = new Size(232, 22);
            rawPlayerSkillsDBToolStripMenuItem.Text = "Raw Player Skills DB";
            rawPlayerSkillsDBToolStripMenuItem.Click += rawPlayerSkillsDBToolStripMenuItem_Click;
            // 
            // SearchToolStripTextBox
            // 
            SearchToolStripTextBox.Alignment = ToolStripItemAlignment.Right;
            SearchToolStripTextBox.Name = "SearchToolStripTextBox";
            SearchToolStripTextBox.Size = new Size(349, 23);
            SearchToolStripTextBox.KeyDown += SearchToolStripTextBox_KeyDown;
            // 
            // searchPlayerToolStripMenuItem
            // 
            searchPlayerToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            searchPlayerToolStripMenuItem.Name = "searchPlayerToolStripMenuItem";
            searchPlayerToolStripMenuItem.Size = new Size(89, 23);
            searchPlayerToolStripMenuItem.Text = "Search Player";
            searchPlayerToolStripMenuItem.Click += searchPlayerToolStripMenuItem_Click;
            // 
            // databaseQuerysToolStripMenuItem
            // 
            databaseQuerysToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { allPlayerStatsToolStripMenuItem });
            databaseQuerysToolStripMenuItem.Name = "databaseQuerysToolStripMenuItem";
            databaseQuerysToolStripMenuItem.Size = new Size(107, 23);
            databaseQuerysToolStripMenuItem.Text = "Database Querys";
            // 
            // allPlayerStatsToolStripMenuItem
            // 
            allPlayerStatsToolStripMenuItem.Image = Properties.Resources.PlusMinus;
            allPlayerStatsToolStripMenuItem.Name = "allPlayerStatsToolStripMenuItem";
            allPlayerStatsToolStripMenuItem.Size = new Size(180, 22);
            allPlayerStatsToolStripMenuItem.Text = "All Player Stats";
            allPlayerStatsToolStripMenuItem.Click += allPlayerStatsToolStripMenuItem_Click;
            // 
            // aboutDatabaseToolStripMenuItem
            // 
            aboutDatabaseToolStripMenuItem.Name = "aboutDatabaseToolStripMenuItem";
            aboutDatabaseToolStripMenuItem.Size = new Size(52, 23);
            aboutDatabaseToolStripMenuItem.Text = "About";
            aboutDatabaseToolStripMenuItem.Click += aboutDatabaseToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { Progress_toolStripStatusLabel, toolStripStatusLabel2, ProgressLabel, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 577);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1387, 24);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // Progress_toolStripStatusLabel
            // 
            Progress_toolStripStatusLabel.ForeColor = Color.DarkGreen;
            Progress_toolStripStatusLabel.Name = "Progress_toolStripStatusLabel";
            Progress_toolStripStatusLabel.Size = new Size(0, 19);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(1018, 19);
            toolStripStatusLabel2.Spring = true;
            // 
            // ProgressLabel
            // 
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(0, 19);
            ProgressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(350, 18);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Teams_dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(Players_dataGridView);
            splitContainer1.Size = new Size(1387, 550);
            splitContainer1.SplitterDistance = 702;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 3;
            // 
            // Teams_dataGridView
            // 
            Teams_dataGridView.AllowUserToAddRows = false;
            Teams_dataGridView.AllowUserToDeleteRows = false;
            Teams_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Teams_dataGridView.Dock = DockStyle.Fill;
            Teams_dataGridView.Location = new Point(0, 0);
            Teams_dataGridView.Margin = new Padding(4, 3, 4, 3);
            Teams_dataGridView.MultiSelect = false;
            Teams_dataGridView.Name = "Teams_dataGridView";
            Teams_dataGridView.ReadOnly = true;
            Teams_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Teams_dataGridView.Size = new Size(702, 550);
            Teams_dataGridView.TabIndex = 0;
            Teams_dataGridView.MouseClick += Team_dataGridView_MouseClick;
            Teams_dataGridView.MouseDoubleClick += Team_dataGridView_DoubleClick;
            // 
            // Players_dataGridView
            // 
            Players_dataGridView.AllowUserToAddRows = false;
            Players_dataGridView.AllowUserToDeleteRows = false;
            Players_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Players_dataGridView.Dock = DockStyle.Fill;
            Players_dataGridView.Location = new Point(0, 0);
            Players_dataGridView.Margin = new Padding(4, 3, 4, 3);
            Players_dataGridView.MultiSelect = false;
            Players_dataGridView.Name = "Players_dataGridView";
            Players_dataGridView.ReadOnly = true;
            Players_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Players_dataGridView.Size = new Size(680, 550);
            Players_dataGridView.TabIndex = 0;
            Players_dataGridView.MouseClick += Players_dataGridView_MouseClick;
            Players_dataGridView.MouseDoubleClick += Players_dataGridView_DoubleClick;
            // 
            // Team_contextMenuStrip
            // 
            Team_contextMenuStrip.Items.AddRange(new ToolStripItem[] { exportTeamListToolStripMenuItem });
            Team_contextMenuStrip.Name = "contextMenuStrip1";
            Team_contextMenuStrip.Size = new Size(161, 26);
            Team_contextMenuStrip.Opening += Team_contextMenuStrip_Opening;
            // 
            // exportTeamListToolStripMenuItem
            // 
            exportTeamListToolStripMenuItem.Name = "exportTeamListToolStripMenuItem";
            exportTeamListToolStripMenuItem.Size = new Size(160, 22);
            exportTeamListToolStripMenuItem.Text = "Export Team List";
            exportTeamListToolStripMenuItem.Click += exportTeamListToolStripMenuItem_Click;
            // 
            // Player_contextMenuStrip
            // 
            Player_contextMenuStrip.Items.AddRange(new ToolStripItem[] { exportPlayerListToolStripMenuItem });
            Player_contextMenuStrip.Name = "contextMenuStrip2";
            Player_contextMenuStrip.Size = new Size(164, 26);
            Player_contextMenuStrip.Opening += Player_contextMenuStrip_Opening;
            // 
            // exportPlayerListToolStripMenuItem
            // 
            exportPlayerListToolStripMenuItem.Name = "exportPlayerListToolStripMenuItem";
            exportPlayerListToolStripMenuItem.Size = new Size(163, 22);
            exportPlayerListToolStripMenuItem.Text = "Export Player List";
            exportPlayerListToolStripMenuItem.Click += exportPlayerListToolStripMenuItem_Click;
            // 
            // sfd_ExportTeamList
            // 
            sfd_ExportTeamList.DefaultExt = "csv";
            sfd_ExportTeamList.FileName = "TeamList.csv";
            sfd_ExportTeamList.Filter = "Team List CSV (*.csv)|*.csv";
            // 
            // sfd_ExportPlayerList
            // 
            sfd_ExportPlayerList.DefaultExt = "csv";
            sfd_ExportPlayerList.FileName = "PlayerList.csv";
            sfd_ExportPlayerList.Filter = "Player List CSV (*.csv)|*.csv";
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1387, 601);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Mainform";
            Text = "RL26 Database Editor";
            Load += Mainform_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Teams_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Players_dataGridView).EndInit();
            Team_contextMenuStrip.ResumeLayout(false);
            Player_contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDatabaseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Progress_toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripTextBox SearchToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem searchPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamLineupDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawTeamPlayersDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawPlayerDBToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Team_contextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip Player_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rawTeamNinesLineupDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTeamListToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_ExportTeamList;
        private System.Windows.Forms.ToolStripMenuItem exportPlayerListToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_ExportPlayerList;
        private System.Windows.Forms.ToolStripMenuItem RawTeamFeederClubsDB_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RawTeamFedFromClubsDB_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawPlayerSkillsDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseQuerysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allPlayerStatsToolStripMenuItem;
        private System.Windows.Forms.DataGridView Teams_dataGridView;
        private System.Windows.Forms.DataGridView Players_dataGridView;
    }
}

