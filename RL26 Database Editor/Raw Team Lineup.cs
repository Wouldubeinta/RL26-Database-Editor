using System.Data;

namespace RL26_Database_Editor
{
    public partial class Raw_Team_Lineup : Form
    {
        private readonly DataGridView Teams_dataGridView;

        public Raw_Team_Lineup(DataGridView Teams_dataGridView)
        {
            InitializeComponent();
            this.Teams_dataGridView = Teams_dataGridView;
        }

        private void Raw_Team_Lineup_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;
            string[] Positions = ["1 - Fullback", "5 - LWing", "4 - LCentre", "3 - RCentre", "2 - RWing", "6 - Five Eight", "7 - Halfback", "8 - Prop", "9 - Hooker", "10 - FrontRow", "11 - Second Row 1", "12 - Second Row 2", "13 - Lock", "14 - Sub 1", "15 - Sub 2", "16 - Sub 3", "17 - Sub 4", "18 - Sub 5", "19 - Sub 6"];

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Team Id", typeof(int));
                dt.Columns.Add("Location Name", typeof(string));
                dt.Columns.Add("Club Name", typeof(string));
                dt.Columns.Add("Team Captain Id", typeof(int));
                dt.Columns.Add("Team GoalKicker Id", typeof(int));
                dt.Columns.Add("Team PlayMaker1 Id", typeof(int));
                dt.Columns.Add("Team PlayMaker2 Id", typeof(int));

                for (int i = 0; i < Global.MIN_PLAYERS_PER_TEAM_NRL2026; i++)
                {
                    dt.Columns.Add(Positions[i], typeof(int));
                }


                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Team Id"] = Global.team[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    dt.Rows[dt.Rows.Count - 1]["Team Captain Id"] = Global.team[i].rolesNew[0].roleId;
                    dt.Rows[dt.Rows.Count - 1]["Team GoalKicker Id"] = Global.team[i].rolesNew[1].roleId;
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker1 Id"] = Global.team[i].rolesNew[2].roleId;
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker2 Id"] = Global.team[i].rolesNew[3].roleId;

                    for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_NRL2026; j++)
                    {
                        dt.Rows[dt.Rows.Count - 1][Positions[j]] = Global.team[i].lineupsNew[j].lineupId;
                    }
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

        private void SaveChangers()
        {
            dataGridView1.Rows[0].Cells[0].Selected = true;

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_ROLES; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesOld[j].isRoleId = false;
                }

                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsOld[j].isLineupId = false;
                }

                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_ROLES; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesNew[j].isRoleId = false;
                }

                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_NRL2026; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsNew[j].isLineupId = false;
                }
            }

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_ROLES; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesOld[j].isRoleId = true;
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesOld[j].roleId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 4].Value);

                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesNew[j].isRoleId = true;
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].rolesNew[j].roleId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 4].Value);
                }

                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 8].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsOld[j].isLineupId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsOld[j].lineupId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 8].Value);
                    }
                }

                for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM_NRL2026; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 8].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsNew[j].isLineupId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineupsNew[j].lineupId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 8].Value);
                    }
                }

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = i;
                toolStripProgressBar1.PerformStep();
            }

            RefreshList.Update_TeamList(Teams_dataGridView);
            toolStripProgressBar1.Value = 0;
            MessageBox.Show("Changers have been saved to this team", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void importCSVDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Import_CSV_ofd.ShowDialog() == DialogResult.OK)
            {
                CSV.FromCSV(dataGridView1, Import_CSV_ofd.FileName);
            }
        }

        private void exportCSVDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Export_CSV_sfd.ShowDialog() == DialogResult.OK)
            {
                CSV.ToCSV(dataGridView1, Export_CSV_sfd.FileName, toolStripProgressBar1);
            }
        }

        private void SaveChangers_toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}