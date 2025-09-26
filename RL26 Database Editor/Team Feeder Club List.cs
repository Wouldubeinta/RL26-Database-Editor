using System.Data;

namespace RL26_Database_Editor
{
    public partial class Team_Feeder_Club_List : Form
    {
        private readonly DataGridView MainDataGridView1;
        private readonly int Team_Index;

        public Team_Feeder_Club_List(DataGridView MainDataGridView1, int Team_Index)
        {
            InitializeComponent();
            this.MainDataGridView1 = MainDataGridView1;
            this.Team_Index = Team_Index;
        }

        private void Team_Feeder_Club_List_Load(object sender, EventArgs e)
        {
            Gender_toolStripComboBox.SelectedIndex = 2;
            OriginalTeams();
        }

        private void OriginalTeams()
        {
            DataTable dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Team Index", Type.GetType("System.Int32"));
                dt.Columns.Add("Team ID", Type.GetType("System.Int32"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));
                int index = -1;

                for (int i = 0; i < Global.team_amount; i++)
                {
                    if (Global.team[i].gender == Gender_toolStripComboBox.SelectedIndex)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Team Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                        dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    }
                    else if (Gender_toolStripComboBox.SelectedIndex == 2)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Team Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                        dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    }
                }

                dataGridView1.DataSource = dt;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            bool valueResult = true;

            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                int RowIndex = dataGridView1.CurrentCell.RowIndex;
                int ColCount = dataGridView1.Columns.Count;
                int RowCount = dataGridView1.Rows.Count;
                int index = dataGridView1.CurrentCell.RowIndex + 1;

                if (RowIndex == 0)
                    index = 0;

                if (index > RowCount - 1)
                    index = 0;

                for (int i = 0; i < ColCount; i++)
                {
                    for (int j = index; j < RowCount; j++)
                    {
                        if (dataGridView1.Rows[j].Cells[i].Value.ToString().Contains(toolStripTextBox1.Text))
                        {
                            dataGridView1.Rows[j].Selected = true;
                            dataGridView1.Focus();
                            dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[0];
                            dataGridView1.Rows[j].Visible = true;
                            valueResult = false;
                            break;
                        }
                    }
                }
                if (valueResult != false)
                {
                    MessageBox.Show("No results found");
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Search();
        }

        private class MyDataGridView : DataGridView
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    e = new KeyEventArgs(Keys.Tab);
                base.OnKeyDown(e);
            }
        }

        private void Gender_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OriginalTeams();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && MainDataGridView1.Rows.Count > 0)
            {
                int index1 = dataGridView1.CurrentCell.RowIndex;
                int index2 = MainDataGridView1.CurrentCell.RowIndex;

                Global.team[Team_Index].feederClubs[index2].feederClubsId = Convert.ToInt32(dataGridView1.Rows[index1].Cells[1].Value);

                Teams();

                if (index2 != MainDataGridView1.Rows.Count - 1)
                {
                    MainDataGridView1.Rows[index2 + 1].Selected = true;
                    MainDataGridView1.Focus();
                    MainDataGridView1.CurrentCell = MainDataGridView1.Rows[index2 + 1].Cells[0];
                    MainDataGridView1.Rows[index2 + 1].Visible = true;
                }
            }
        }

        private void Teams()
        {
            DataTable dt = null;

            try
            {
                if (Global.team[Team_Index].feederClubsAmount > 0)
                {
                    dt = new DataTable();

                    dt.Columns.Add("FeederClubs Index", Type.GetType("System.Int32"));
                    dt.Columns.Add("Team ID", Type.GetType("System.Int32"));
                    dt.Columns.Add("Location Name", Type.GetType("System.String"));
                    dt.Columns.Add("Club Name", Type.GetType("System.String"));

                    for (int i = 0; i < Global.team[Team_Index].feederClubsAmount; i++)
                    {
                        int selectedIndex = SearchID.TeamsIndex(Global.team[Team_Index].feederClubs[i].feederClubsId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["FeederClubs Index"] = i;
                        dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[Team_Index].feederClubs[i].feederClubsId;
                        dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[selectedIndex].locationName;
                        dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[selectedIndex].clubName;
                    }

                    MainDataGridView1.DataSource = dt;

                    for (int i = 0; i < MainDataGridView1.Columns.Count; i++)
                    {
                        MainDataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void refreshTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginalTeams();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
