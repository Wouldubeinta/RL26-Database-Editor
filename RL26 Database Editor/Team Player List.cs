using System.Data;

namespace RL26_Database_Editor
{
    public partial class Team_Player_List : Form
    {
        private readonly DataGridView MainDataGridView1;
        private readonly int TeamIndex;

        public Team_Player_List(DataGridView MainDataGridView1, int TeamIndex)
        {
            InitializeComponent();
            this.MainDataGridView1 = MainDataGridView1;
            this.TeamIndex = TeamIndex;
        }

        private void Team_Player_List_Load(object sender, EventArgs e)
        {
            OriginalPlayers();
            Gender_toolStripComboBox.SelectedIndex = 2;
        }

        private void OriginalPlayers()
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", Type.GetType("System.Int32"));
                dt.Columns.Add("Player Id", Type.GetType("System.Int32"));
                dt.Columns.Add("Rating", Type.GetType("System.Int32"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));
                dt.Columns.Add("Primary Role", Type.GetType("System.String"));
                dt.Columns.Add("Secondary Role", Type.GetType("System.String"));
                dt.Columns.Add("Tertiary Role", Type.GetType("System.String"));
                int index = -1;

                for (int i = 0; i < Global.player_amount; i++)
                {
                    if (Global.player[i].gender == Gender_toolStripComboBox.SelectedIndex)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(i);
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[i].primaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[i].secondaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[i].tertiaryRole);
                    }
                    else if (Gender_toolStripComboBox.SelectedIndex == 2)
                    {
                        index++;
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Index"] = index;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[i].id;
                        dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(i);
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[i].primaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[i].secondaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[i].tertiaryRole);
                    }
                }

                dataGridView1.DataSource = dt;
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

                for (int j = index; j < RowCount; j++)
                {
                    if ((dataGridView1.Rows[j].Cells[3].Value.ToString() + " " + dataGridView1.Rows[j].Cells[4].Value.ToString()).Contains(toolStripTextBox1.Text))
                    {
                        dataGridView1.Rows[j].Selected = true;
                        dataGridView1.Focus();
                        dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[0];
                        dataGridView1.Rows[j].Visible = true;
                        valueResult = false;
                        break;
                    }
                }

                if (valueResult != false)
                {
                    dataGridView1.Focus();
                    dataGridView1.Rows[0].Visible = true;
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                    dataGridView1.Refresh();
                    MessageBox.Show("Could not find player name.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            OriginalPlayers();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && MainDataGridView1.Rows.Count > 0)
            {
                int index1 = dataGridView1.CurrentCell.RowIndex;
                int index2 = MainDataGridView1.CurrentCell.RowIndex;

                int SelectedIndex = SearchID.PlayersIndex(Convert.ToInt32(dataGridView1.Rows[index1].Cells[1].Value));
                Global.team[TeamIndex].players[index2].playerId = Global.player[SelectedIndex].id;

                Players();

                if (index2 != MainDataGridView1.Rows.Count - 1)
                {
                    MainDataGridView1.Rows[index2 + 1].Selected = true;
                    MainDataGridView1.Focus();
                    MainDataGridView1.CurrentCell = MainDataGridView1.Rows[index2 + 1].Cells[0];
                    MainDataGridView1.Rows[index2 + 1].Visible = true;
                }
            }
        }

        private void Players()
        {
            DataTable? Playersdt = null;

            try
            {
                Playersdt = new DataTable();

                Playersdt.Columns.Add("Index", Type.GetType("System.Int32"));
                Playersdt.Columns.Add("Player Id", Type.GetType("System.Int32"));
                Playersdt.Columns.Add("First Name", Type.GetType("System.String"));
                Playersdt.Columns.Add("Last Name", Type.GetType("System.String"));
                Playersdt.Columns.Add("Primary Role", Type.GetType("System.String"));
                Playersdt.Columns.Add("Secondary Role", Type.GetType("System.String"));
                Playersdt.Columns.Add("Tertiary Role", Type.GetType("System.String"));


                for (int i = 0; i < Global.team[TeamIndex].playerAmount; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].players[i].playerId);
                    Playersdt.Rows.Add();
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Index"] = i;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                    Playersdt.Rows[Playersdt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                }

                MainDataGridView1.DataSource = Playersdt;

                for (int i = 0; i < MainDataGridView1.Columns.Count; i++)
                {
                    MainDataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void refreshPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OriginalPlayers();
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
