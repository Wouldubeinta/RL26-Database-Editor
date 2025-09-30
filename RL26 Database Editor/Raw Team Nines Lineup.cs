using System.Data;

namespace RL26_Database_Editor
{
    public partial class Raw_Team_Nines_Lineup : Form
    {
        private readonly DataGridView Teams_dataGridView;

        public Raw_Team_Nines_Lineup(DataGridView Teams_dataGridView)
        {
            InitializeComponent();
            this.Teams_dataGridView = Teams_dataGridView;
        }

        private void Raw_Team_Nines_Lineup_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            string[] Positions = new string[14] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10 - Int1", "11 - Int2", "12 - Int3", "13 - Int4", "14 - Int5" };

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", Type.GetType("System.String"));
                dt.Columns.Add("Team Id", Type.GetType("System.String"));
                dt.Columns.Add("Full Name", Type.GetType("System.String"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));
                dt.Columns.Add("Team Nines Captain ID", Type.GetType("System.String"));
                dt.Columns.Add("Team Nines GoalKicker ID", Type.GetType("System.String"));
                dt.Columns.Add("Team Nines PlayMaker1 ID", Type.GetType("System.String"));
                dt.Columns.Add("Team Nines PlayMaker2 ID", Type.GetType("System.String"));

                for (int i = 0; i < Positions.Length; i++)
                {
                    dt.Columns.Add(Positions[i], Type.GetType("System.String"));
                }

                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Id"] = Global.team[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Full Name"] = Global.team[i].fullName;
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    dt.Rows[dt.Rows.Count - 1]["Team Nines Captain ID"] = Global.team[i].nineRoles[0].nineRoleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Nines GoalKicker ID"] = Global.team[i].nineRoles[1].nineRoleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Nines PlayMaker1 ID"] = Global.team[i].nineRoles[2].nineRoleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Nines PlayMaker2 ID"] = Global.team[i].nineRoles[3].nineRoleId.ToString();

                    for (int j = 0; j < 14; j++)
                    {
                        dt.Rows[dt.Rows.Count - 1][Positions[j]] = Global.team[i].nineLineups[j].nineLineupId.ToString();
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

        private void SaveChangers()
        {
            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineRoles[j].isNinesRoleId = false;
                }

                for (int j = 0; j < 14; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineLineups[j].isNineLineupId = false;
                }
            }

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 5].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineRoles[j].isNinesRoleId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineRoles[j].nineRoleId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 5].Value);
                    }
                }

                for (int j = 0; j < 14; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 9].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineLineups[j].isNineLineupId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].nineLineups[j].nineLineupId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 9].Value);
                    }
                }

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = (i);
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
