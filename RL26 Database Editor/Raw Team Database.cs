using System.Data;

namespace RL26_Database_Editor
{
    public partial class Raw_Team_Database : Form
    {
        private readonly DataGridView Teams_dataGridView;

        public Raw_Team_Database(DataGridView Teams_dataGridView)
        {
            InitializeComponent();
            this.Teams_dataGridView = Teams_dataGridView;
        }

        private void Raw_Team_Database_Load(object sender, EventArgs e)
        {
            DataTable dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Team Index", Type.GetType("System.String"));
                dt.Columns.Add("Team ID", Type.GetType("System.String"));
                dt.Columns.Add("Full Name", Type.GetType("System.String"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));
                dt.Columns.Add("Abbreviated Name", Type.GetType("System.String"));
                dt.Columns.Add("Logo", Type.GetType("System.String"));
                dt.Columns.Add("Primary R Colour", Type.GetType("System.String"));
                dt.Columns.Add("Primary G Colour", Type.GetType("System.String"));
                dt.Columns.Add("Primary B Colour", Type.GetType("System.String"));
                dt.Columns.Add("Secondary R Colour", Type.GetType("System.String"));
                dt.Columns.Add("Secondary G Colour", Type.GetType("System.String"));
                dt.Columns.Add("Secondary B Colour", Type.GetType("System.String"));
                dt.Columns.Add("Hud Text R Colour", Type.GetType("System.String"));
                dt.Columns.Add("Hud Text G Colour", Type.GetType("System.String"));
                dt.Columns.Add("Hud Text B Colour", Type.GetType("System.String"));
                dt.Columns.Add("Team Type", Type.GetType("System.String"));
                dt.Columns.Add("Affiliations", Type.GetType("System.String"));
                dt.Columns.Add("Supporters", Type.GetType("System.String"));
                dt.Columns.Add("Commentary Team Location Hash", Type.GetType("System.String"));
                dt.Columns.Add("Commentary Team Mascot Hash", Type.GetType("System.String"));
                dt.Columns.Add("Alternate Numbering", Type.GetType("System.String"));
                dt.Columns.Add("Alternate Numbering System", Type.GetType("System.String"));

                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Team Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Full Name"] = Global.team[i].fullName;
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    dt.Rows[dt.Rows.Count - 1]["Abbreviated Name"] = Global.team[i].abbreviatedName;
                    dt.Rows[dt.Rows.Count - 1]["Logo"] = Global.team[i].logo;
                    dt.Rows[dt.Rows.Count - 1]["Primary R Colour"] = Global.team[i].primaryColour.r.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Primary G Colour"] = Global.team[i].primaryColour.g.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Primary B Colour"] = Global.team[i].primaryColour.b.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Secondary R Colour"] = Global.team[i].secondaryColour.r.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Secondary G Colour"] = Global.team[i].secondaryColour.g.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Secondary B Colour"] = Global.team[i].secondaryColour.b.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Hud Text R Colour"] = Global.team[i].hudTextColour.r.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Hud Text G Colour"] = Global.team[i].hudTextColour.g.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Hud Text B Colour"] = Global.team[i].hudTextColour.b.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Type"] = Global.team[i].clubType.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Affiliations"] = Global.team[i].affiliations.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Supporters"] = Global.team[i].supporters.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Commentary Team Location Hash"] = Global.team[i].commentaryTeamLocationHash.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Commentary Team Mascot Hash"] = Global.team[i].commentaryTeamMascotHash.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Alternate Numbering"] = Global.team[i].alternateNumbering.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Alternate Numbering System"] = Global.team[i].alternateNumberingSystem.ToString();
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
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fullNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[2].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fullName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].locationNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].locationName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].clubNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[4].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].clubName = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].abbreviatedNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[5].Value.ToString().Length);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].abbreviatedName = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[6].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[7].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[8].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[9].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[10].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[11].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.r = Convert.ToByte(dataGridView1.Rows[i].Cells[12].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.g = Convert.ToByte(dataGridView1.Rows[i].Cells[13].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hudTextColour.b = Convert.ToByte(dataGridView1.Rows[i].Cells[14].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].clubType = Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].affiliations = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].supporters = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].commentaryTeamLocationHash = Convert.ToUInt32(dataGridView1.Rows[i].Cells[18].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].commentaryTeamMascotHash = Convert.ToUInt32(dataGridView1.Rows[i].Cells[19].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].alternateNumbering = Convert.ToBoolean(dataGridView1.Rows[i].Cells[20].Value);
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].alternateNumberingSystem = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);

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

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            SaveChangers();
        }
    }
}