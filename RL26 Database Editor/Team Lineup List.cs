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
            DataTable? dt = null;

            try
            {
                dt = new DataTable();
                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("Rating", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

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
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred, report it to Wouldy : {ex}", "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Lineup()
        {
            DataTable? dt = null;
            string[] Positions = ["1 - Fullback", "2 - RWing", "3 - RCentre", "4 - LCentre", "5 - LWing", "6 - Five Eighth", "7 - Halfback", "8 - Prop", "9 - Hooker", "10 - FrontRow", "11 - RSecondRow", "12 - LSecondRow", "13 - Lock", "14 - Sub 1", "15 - Sub 2", "16 - Sub 3", "17 - Sub 4", "18 - Sub 5", "19 - Sub 6"];

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Position", typeof(string));
                dt.Columns.Add("Shirt Number", typeof(byte));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                if (MainDataGridView2.Rows.Count != 0)
                {
                    for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM_NRL2026; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[Team_Index].lineupsNew[i].lineupId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Position"] = Positions[i];
                        dt.Rows[dt.Rows.Count - 1]["Shirt Number"] = Global.team[Team_Index].lineupsNew[i].shirtNumber;
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred, report it to Wouldy : {ex}", "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int index1 = dataGridView1.CurrentCell.RowIndex;
                int index2 = MainDataGridView2.CurrentCell.RowIndex;

                Global.team[Team_Index].lineupsNew[index2].lineupId = Convert.ToInt32(dataGridView1.Rows[index1].Cells[1].Value);

                Lineup();

                if (index2 != 18)
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
