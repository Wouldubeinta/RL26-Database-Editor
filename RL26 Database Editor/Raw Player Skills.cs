using System.Data;

namespace RL26_Database_Editor
{
    public partial class Raw_Player_Skills : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Raw_Player_Skills(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private void Raw_Player_Skills_Load(object sender, EventArgs e)
        {
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Gender", typeof(int));
                dt.Columns.Add("Grubber Kick", typeof(int));
                dt.Columns.Add("Punt Kick", typeof(int));
                dt.Columns.Add("Chip Kick", typeof(int));
                dt.Columns.Add("Bomb Kick", typeof(int));
                dt.Columns.Add("Field Goal Kick", typeof(int));
                dt.Columns.Add("Place Kick", typeof(int));
                dt.Columns.Add("Basic Pass", typeof(int));
                dt.Columns.Add("Long Pass", typeof(int));
                dt.Columns.Add("Offload", typeof(int));
                dt.Columns.Add("Dummy Pass", typeof(int));
                dt.Columns.Add("Fend", typeof(int));
                dt.Columns.Add("Side Step", typeof(int));
                dt.Columns.Add("Break Tackle", typeof(int));
                dt.Columns.Add("Tackle", typeof(int));
                dt.Columns.Add("Drive Tackle", typeof(int));
                dt.Columns.Add("Dive Tackle", typeof(int));
                dt.Columns.Add("Impact Tackle", typeof(int));
                dt.Columns.Add("Contested Collect", typeof(int));
                dt.Columns.Add("Dive Collect", typeof(int));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.player[i].id;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Global.player[i].gender;
                    dt.Rows[dt.Rows.Count - 1]["Grubber Kick"] = Global.player[i].skills.kickingSkills.grubberKick;
                    dt.Rows[dt.Rows.Count - 1]["Punt Kick"] = Global.player[i].skills.kickingSkills.puntKick;
                    dt.Rows[dt.Rows.Count - 1]["Chip Kick"] = Global.player[i].skills.kickingSkills.chipKick;
                    dt.Rows[dt.Rows.Count - 1]["Bomb Kick"] = Global.player[i].skills.kickingSkills.bombKick;
                    dt.Rows[dt.Rows.Count - 1]["Field Goal Kick"] = Global.player[i].skills.kickingSkills.fieldgoalKick;
                    dt.Rows[dt.Rows.Count - 1]["Place Kick"] = Global.player[i].skills.kickingSkills.placeKick;
                    dt.Rows[dt.Rows.Count - 1]["Basic Pass"] = Global.player[i].skills.passingSkills.basicPass;
                    dt.Rows[dt.Rows.Count - 1]["Long Pass"] = Global.player[i].skills.passingSkills.longPass;
                    dt.Rows[dt.Rows.Count - 1]["Offload"] = Global.player[i].skills.passingSkills.offload;
                    dt.Rows[dt.Rows.Count - 1]["Dummy Pass"] = Global.player[i].skills.evasionSkills.dummyPass;
                    dt.Rows[dt.Rows.Count - 1]["Fend"] = Global.player[i].skills.evasionSkills.fend;
                    dt.Rows[dt.Rows.Count - 1]["Side Step"] = Global.player[i].skills.evasionSkills.sideStep;
                    dt.Rows[dt.Rows.Count - 1]["Break Tackle"] = Global.player[i].skills.evasionSkills.breakTackle;
                    dt.Rows[dt.Rows.Count - 1]["Tackle"] = Global.player[i].skills.tackleSkills.tackle;
                    dt.Rows[dt.Rows.Count - 1]["Drive Tackle"] = Global.player[i].skills.tackleSkills.driveTackle;
                    dt.Rows[dt.Rows.Count - 1]["Dive Tackle"] = Global.player[i].skills.tackleSkills.diveTackle;
                    dt.Rows[dt.Rows.Count - 1]["Impact Tackle"] = Global.player[i].skills.tackleSkills.impactTackle;
                    dt.Rows[dt.Rows.Count - 1]["Contested Collect"] = Global.player[i].skills.miscSkills.contestedCollect;
                    dt.Rows[dt.Rows.Count - 1]["Dive Collect"] = Global.player[i].skills.miscSkills.diveCollect;
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

            for (int i = 0; i < Global.player_amount; i++)
            {
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[2].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].gender = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.grubberKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.puntKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.chipKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.bombKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.fieldgoalKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.kickingSkills.placeKick = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.passingSkills.basicPass = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.passingSkills.longPass = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.passingSkills.offload = Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.evasionSkills.dummyPass = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.evasionSkills.fend = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.evasionSkills.sideStep = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.evasionSkills.breakTackle = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.tackleSkills.tackle = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.tackleSkills.driveTackle = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.tackleSkills.diveTackle = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.tackleSkills.impactTackle = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.miscSkills.contestedCollect = Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].skills.miscSkills.diveCollect = Convert.ToInt32(dataGridView1.Rows[i].Cells[23].Value);

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = i;
                toolStripProgressBar1.PerformStep();
            }

            RefreshList.Update_PlayerList(Players_dataGridView);
            toolStripProgressBar1.Value = 0;
            MessageBox.Show("Changers have been saved to this player", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Save_Changers_toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}