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
            DataTable dt = null;
            string[] Positions = new string[17] { "1 - Fullback", "5 - LWing", "4 - LCentre", "3 - RCentre", "2 - RWing", "6 - Five Eight", "7 - Halfback", "8 - Prop", "9 - Hooker", "10 - FrontRow", "11 - Second Row 1", "12 - Second Row 2", "13 - Lock", "14 - Int1", "15 - Int2", "16 - Int3", "17 - Int4" };

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", Type.GetType("System.String"));
                dt.Columns.Add("Team Id", Type.GetType("System.String"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));
                dt.Columns.Add("Team Captain Id", Type.GetType("System.String"));
                dt.Columns.Add("Team GoalKicker Id", Type.GetType("System.String"));
                dt.Columns.Add("Team PlayMaker1 Id", Type.GetType("System.String"));
                dt.Columns.Add("Team PlayMaker2 Id", Type.GetType("System.String"));

                for (int i = 0; i < 17; i++)
                {
                    dt.Columns.Add(Positions[i], Type.GetType("System.String"));
                }


                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Id"] = Global.team[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    dt.Rows[dt.Rows.Count - 1]["Team Captain Id"] = Global.team[i].roles[0].roleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team GoalKicker Id"] = Global.team[i].roles[1].roleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker1 Id"] = Global.team[i].roles[2].roleId.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team PlayMaker2 Id"] = Global.team[i].roles[3].roleId.ToString();

                    for (int j = 0; j < 17; j++)
                    {
                        dt.Rows[dt.Rows.Count - 1][Positions[j]] = Global.team[i].lineups[j].lineupId.ToString();
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
            dataGridView1.Rows[0].Cells[0].Selected = true;

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].roles[j].isRoleId = false;
                }

                for (int j = 0; j < 17; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineups[j].isLineupId = false;
                }
            }

            for (int i = 0; i < Global.team_amount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].roles[j].isRoleId = true;
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].roles[j].roleId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 4].Value);
                }

                for (int j = 0; j < 17; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 8].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineups[j].isLineupId = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lineups[j].lineupId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 8].Value);
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