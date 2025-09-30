using System.Data;

namespace RL26_Database_Editor
{
    public partial class Team_Lineup_List : Form
    {
        private readonly DataGridView MainDataGridView2;
        private readonly int Team_Index;

        public Team_Lineup_List(DataGridView MainDataGridView2, int Team_Index)
        {
            InitializeComponent();
            this.MainDataGridView2 = MainDataGridView2;
            this.Team_Index = Team_Index;
        }

        private void Team_Player_List_Load(object sender, EventArgs e)
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

                for (int i = 0; i < Global.team[Team_Index].playerAmount; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].players[i].playerId);
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

        private void Lineup()
        {
            DataTable dt = null;
            string[] Positions = new string[17] { "1 - Fullback", "2 - RWing", "3 - RCentre", "4 - LCentre", "5 - LWing", "6 - Five Eighth", "7 - Halfback", "8 - Prop", "9 - Hooker", "10 - FrontRow", "11 - RSecondRow", "12 - LSecondRow", "13 - Lock", "14 - Int1", "15 - Int2", "16 - Int3", "17 - Int4" };

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Position", Type.GetType("System.String"));
                dt.Columns.Add("Shirt Number", Type.GetType("System.Byte"));
                dt.Columns.Add("Player Id", Type.GetType("System.Int32"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));
                dt.Columns.Add("Primary Role", Type.GetType("System.String"));
                dt.Columns.Add("Secondary Role", Type.GetType("System.String"));
                dt.Columns.Add("Tertiary Role", Type.GetType("System.String"));

                if (MainDataGridView2.Rows.Count != 0)
                {
                    for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].lineups[i].lineupId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Position"] = Positions[i];
                        dt.Rows[dt.Rows.Count - 1]["Shirt Number"] = Global.team[Team_Index].lineups[i].shirtNumber;
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                    }
                }

                MainDataGridView2.DataSource = dt;

                for (int i = 0; i < MainDataGridView2.Columns.Count; i++)
                {
                    MainDataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                int index2 = MainDataGridView2.CurrentCell.RowIndex;

                Global.team[Team_Index].lineups[index2].lineupId = Convert.ToInt32(dataGridView1.Rows[index1].Cells[2].Value);
                Global.team[Team_Index].lineups[index2].shirtNumber = Convert.ToByte(dataGridView1.Rows[index1].Cells[1].Value);

                Lineup();

                if (index2 != 16)
                {
                    MainDataGridView2.Rows[index2 + 1].Selected = true;
                    MainDataGridView2.Focus();
                    MainDataGridView2.CurrentCell = MainDataGridView2.Rows[index2 + 1].Cells[0];
                    MainDataGridView2.Rows[index2 + 1].Visible = true;
                }
            }
        }
    }
}
