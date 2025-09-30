using System.Data;

namespace RL26_Database_Editor
{
    public partial class Team_Nines_Lineup_List : Form
    {
        private readonly DataGridView MainDataGridView4;
        private readonly int TeamIndex;

        public Team_Nines_Lineup_List(DataGridView MainDataGridView4, int TeamIndex)
        {
            InitializeComponent();
            this.MainDataGridView4 = MainDataGridView4;
            this.TeamIndex = TeamIndex;
        }

        private void Team_Nines_Lineup_List_Load(object sender, EventArgs e)
        {
            TeamLineup();
        }

        private void TeamLineup()
        {
            DataTable dt = null;

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

                for (int i = 0; i < Global.team[TeamIndex].playerAmount; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].players[i].playerId);
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(SelectedIndex);
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PlayerLineup()
        {
            DataTable dt = null;
            string[] Positions = new string[14] { "1", "2", "3", "4", "5", "6", "7", "8", "9", " 10 - Int1", "11 - Int2", "12 - Int3", "13 - Int4", "14 - Int5" };

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Position", Type.GetType("System.String"));
                dt.Columns.Add("Player Id", Type.GetType("System.Int32"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));
                dt.Columns.Add("Primary Role", Type.GetType("System.String"));
                dt.Columns.Add("Secondary Role", Type.GetType("System.String"));
                dt.Columns.Add("Tertiary Role", Type.GetType("System.String"));

                if (MainDataGridView4.Rows.Count != 0)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].nineLineups[i].nineLineupId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Position"] = Positions[i];
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                    }
                }

                MainDataGridView4.DataSource = dt;

                for (int i = 0; i < MainDataGridView4.Columns.Count; i++)
                {
                    MainDataGridView4.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int index1 = dataGridView1.CurrentCell.RowIndex;
                int index2 = MainDataGridView4.CurrentCell.RowIndex;

                Global.team[TeamIndex].nineLineups[index2].nineLineupId = Convert.ToInt32(dataGridView1.Rows[index1].Cells[1].Value);

                PlayerLineup();

                if (index2 != 13)
                {
                    MainDataGridView4.Rows[index2 + 1].Selected = true;
                    MainDataGridView4.Focus();
                    MainDataGridView4.CurrentCell = MainDataGridView4.Rows[index2 + 1].Cells[0];
                    MainDataGridView4.Rows[index2 + 1].Visible = true;
                }
            }
        }
    }
}
