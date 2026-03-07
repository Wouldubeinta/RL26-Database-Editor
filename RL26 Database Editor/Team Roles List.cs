using System.Data;

namespace RL26_Database_Editor
{
    public partial class Team_Roles_List : Form
    {
        private readonly DataGridView MainDataGridView3;
        private readonly int TeamIndex;

        public Team_Roles_List(DataGridView MainDataGridView3, int TeamIndex)
        {
            InitializeComponent();
            this.MainDataGridView3 = MainDataGridView3;
            this.TeamIndex = TeamIndex;
        }

        private void Team_Roles_List_Load(object sender, EventArgs e)
        {
            TeamRoles();
        }

        private void TeamRoles()
        {
            DataTable? dt = null;
            string[] Positions = ["1 - Fullback", "5 - LWing", "4 - LCentre", "3 - RCentre", "2 - RWing", "6 - Five Eighth", "7 - Halfback", "8 - Prop", "9 - Hooker", "10 - FrontRow", "11 - RSecondRow", "12 - LSecondRow", "13 - Lock", "14 - Sub 1", "15 - Sub 2", "16 - Sub 3", "17 - Sub 4", "18 - Sub 5", "19 - Sub 6"];

            try
            {
                dt = new DataTable();
                dt.Columns.Add("Position", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("Rating", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM_NRL2026; i++)
                {
                    int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].lineupsNew[i].lineupId);
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Position"] = Positions[i];
                    dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                    dt.Rows[dt.Rows.Count - 1]["Rating"] = Rating.PlayerRating(SelectedIndex);
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                }

                dataGridView1.DataSource = dt;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred, report it to Wouldy : {ex}", "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PlayerRoles()
        {
            DataTable? dt = null;

            try
            {
                string[] PlyRoles = ["Captain", "GoalKicker", "PlayMaker1", "PlayMaker2"];

                dt = new DataTable();

                dt.Columns.Add("Roles", typeof(string));
                dt.Columns.Add("Player Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(string));
                dt.Columns.Add("Secondary Role", typeof(string));
                dt.Columns.Add("Tertiary Role", typeof(string));

                if (MainDataGridView3.Rows.Count != 0)
                {
                    for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM_ROLES; i++)
                    {
                        int SelectedIndex = SearchID.PlayersIndex(Global.team[TeamIndex].rolesNew[i].roleId);
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Roles"] = PlyRoles[i];
                        dt.Rows[dt.Rows.Count - 1]["Player Id"] = Global.player[SelectedIndex].id;
                        dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[SelectedIndex].firstName;
                        dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[SelectedIndex].lastName;
                        dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Roles.playerRoles(Global.player[SelectedIndex].primaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Roles.playerRoles(Global.player[SelectedIndex].secondaryRole);
                        dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Roles.playerRoles(Global.player[SelectedIndex].tertiaryRole);
                    }
                }

                MainDataGridView3.DataSource = dt;

                for (int i = 0; i < MainDataGridView3.Columns.Count; i++)
                {
                    MainDataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                int index2 = MainDataGridView3.CurrentCell.RowIndex;

                Global.team[TeamIndex].rolesOld[index2].roleId = Convert.ToInt32(dataGridView1.Rows[index1].Cells[1].Value);

                PlayerRoles();

                if (index2 != 3)
                {
                    MainDataGridView3.Rows[index2 + 1].Selected = true;
                    MainDataGridView3.Focus();
                    MainDataGridView3.CurrentCell = MainDataGridView3.Rows[index2 + 1].Cells[0];
                    MainDataGridView3.Rows[index2 + 1].Visible = true;
                }
            }
        }
    }
}
