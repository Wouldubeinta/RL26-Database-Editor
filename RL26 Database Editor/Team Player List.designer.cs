namespace RL26_Database_Editor
{
    partial class Team_Player_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Team_Player_List));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new MyDataGridView();
            menuStrip1 = new MenuStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            searchToolStripMenuItem = new ToolStripMenuItem();
            CountryOfBirth_toolStripComboBox = new ToolStripComboBox();
            Roles_toolStripComboBox = new ToolStripComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            refreshPlayersToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 27);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1050, 598);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.AllowDrop = true;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1042, 570);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Original Disk Players";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(4, 3);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1034, 564);
            dataGridView1.TabIndex = 0;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, searchToolStripMenuItem, CountryOfBirth_toolStripComboBox, Roles_toolStripComboBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1050, 27);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Alignment = ToolStripItemAlignment.Right;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(298, 23);
            toolStripTextBox1.KeyPress += toolStripTextBox1_KeyPress;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(89, 23);
            searchToolStripMenuItem.Text = "Search Player";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // CountryOfBirth_toolStripComboBox
            // 
            CountryOfBirth_toolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CountryOfBirth_toolStripComboBox.Name = "CountryOfBirth_toolStripComboBox";
            CountryOfBirth_toolStripComboBox.Size = new Size(140, 23);
            CountryOfBirth_toolStripComboBox.SelectedIndexChanged += CountryOfBirth_toolStripComboBox_SelectedIndexChanged;
            // 
            // Roles_toolStripComboBox
            // 
            Roles_toolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Roles_toolStripComboBox.Items.AddRange(new object[] { "Fullback", "Winger", "Centre", "Five-Eighth", "HalfBack", "Prop", "Hooker", "Second Rower", "Lock", "All Roles" });
            Roles_toolStripComboBox.Name = "Roles_toolStripComboBox";
            Roles_toolStripComboBox.Size = new Size(121, 23);
            Roles_toolStripComboBox.SelectedIndexChanged += Roles_toolStripComboBox_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { refreshPlayersToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(154, 26);
            // 
            // refreshPlayersToolStripMenuItem
            // 
            refreshPlayersToolStripMenuItem.Name = "refreshPlayersToolStripMenuItem";
            refreshPlayersToolStripMenuItem.Size = new Size(153, 22);
            refreshPlayersToolStripMenuItem.Text = "Refresh Players";
            refreshPlayersToolStripMenuItem.Click += refreshPlayersToolStripMenuItem_Click;
            // 
            // Team_Player_List
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 625);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Team_Player_List";
            Text = "Team Player List";
            Load += Team_Player_List_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private MyDataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox CountryOfBirth_toolStripComboBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshPlayersToolStripMenuItem;
        private ToolStripComboBox Roles_toolStripComboBox;
    }
}