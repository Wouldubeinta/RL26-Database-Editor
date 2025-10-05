using System.Data;
using System.DirectoryServices.ActiveDirectory;

namespace RL26_Database_Editor
{
    public partial class Raw_Player_Database : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Raw_Player_Database(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private void Raw_Player_Database_Load(object sender, EventArgs e)
        {
            DataTable dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", Type.GetType("System.String"));
                dt.Columns.Add("Enabled", Type.GetType("System.Boolean"));
                dt.Columns.Add("Id", Type.GetType("System.String"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));
                dt.Columns.Add("Gender", Type.GetType("System.String"));
                dt.Columns.Add("Licensed", Type.GetType("System.Boolean"));
                dt.Columns.Add("Hidden", Type.GetType("System.Boolean"));
                dt.Columns.Add("Commentary Name Hash", Type.GetType("System.String"));
                dt.Columns.Add("Club", Type.GetType("System.String"));
                dt.Columns.Add("DOB - Day", Type.GetType("System.String"));
                dt.Columns.Add("DOB - Month", Type.GetType("System.String"));
                dt.Columns.Add("DOB - Year", Type.GetType("System.String"));
                dt.Columns.Add("Age", Type.GetType("System.String"));
                dt.Columns.Add("Jersey Number", Type.GetType("System.String"));
                dt.Columns.Add("Jersey Name", Type.GetType("System.String"));
                dt.Columns.Add("Primary Role", Type.GetType("System.String"));
                dt.Columns.Add("Secondary Role", Type.GetType("System.String"));
                dt.Columns.Add("Tertiary Role", Type.GetType("System.String"));
                dt.Columns.Add("State Of Origin", Type.GetType("System.String"));
                dt.Columns.Add("State Of Origin Rep Number", Type.GetType("System.String"));
                dt.Columns.Add("State Of Origin Other Number", Type.GetType("System.String"));
                dt.Columns.Add("City V's Country", Type.GetType("System.String"));
                dt.Columns.Add("All Stars", Type.GetType("System.String"));
                dt.Columns.Add("World Cup", Type.GetType("System.Boolean"));
                dt.Columns.Add("Preferred Hand", Type.GetType("System.String"));
                dt.Columns.Add("Preferred Foot", Type.GetType("System.String"));
                dt.Columns.Add("Representative Country", Type.GetType("System.String"));
                dt.Columns.Add("Country Of Birth", Type.GetType("System.String"));
                dt.Columns.Add("Contract Expiry", Type.GetType("System.String"));
                dt.Columns.Add("Height", Type.GetType("System.String"));
                dt.Columns.Add("Weight", Type.GetType("System.String"));
                dt.Columns.Add("Reputation", Type.GetType("System.String"));
                dt.Columns.Add("Ego", Type.GetType("System.String"));
                dt.Columns.Add("Loyalty", Type.GetType("System.String"));
                dt.Columns.Add("Perks", Type.GetType("System.String"));
                dt.Columns.Add("Strength", Type.GetType("System.String"));
                dt.Columns.Add("Agility", Type.GetType("System.String"));
                dt.Columns.Add("Fitness", Type.GetType("System.String"));
                dt.Columns.Add("Acceleration", Type.GetType("System.String"));
                dt.Columns.Add("Discipline", Type.GetType("System.String"));
                dt.Columns.Add("Durability", Type.GetType("System.String"));
                dt.Columns.Add("Sprint Speed", Type.GetType("System.String"));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Enabled"] = Global.player[i].isPlayerEnabled;
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.player[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Global.player[i].gender.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Licensed"] = Global.player[i].licensed;
                    dt.Rows[dt.Rows.Count - 1]["Hidden"] = Global.player[i].hidden;
                    dt.Rows[dt.Rows.Count - 1]["Commentary Name Hash"] = Global.player[i].commentaryNameHash.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Club"] = Global.player[i].club.ToString();
                    dt.Rows[dt.Rows.Count - 1]["DOB - Day"] = Global.player[i].dob.day.ToString();
                    dt.Rows[dt.Rows.Count - 1]["DOB - Month"] = Global.player[i].dob.month.ToString();
                    dt.Rows[dt.Rows.Count - 1]["DOB - Year"] = Global.player[i].dob.year.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Age"] = Global.player[i].age.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Jersey Number"] = Global.player[i].jerseyNumber.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Jersey Name"] = Global.player[i].jerseyName.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Global.player[i].primaryRole.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Global.player[i].secondaryRole.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Global.player[i].tertiaryRole.ToString();
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin"] = Global.player[i].stateOfOrigin.ToString();
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin Rep Number"] = Global.player[i].originRepNumber.ToString();
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin Other Number"] = Global.player[i].originOtherNumber.ToString();
                    dt.Rows[dt.Rows.Count - 1]["City V's Country"] = Global.player[i].cityVsCountry.ToString();
                    dt.Rows[dt.Rows.Count - 1]["All Stars"] = Global.player[i].allStars.ToString();
                    dt.Rows[dt.Rows.Count - 1]["World Cup"] = Global.player[i].WorldCup;
                    dt.Rows[dt.Rows.Count - 1]["Preferred Hand"] = Global.player[i].preferredHand.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Preferred Foot"] = Global.player[i].preferredFoot.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Representative Country"] = Global.player[i].repCountry.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Country Of Birth"] = Global.player[i].countryOfBirth.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Contract Expiry"] = Global.player[i].contractExpiry.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Height"] = Global.player[i].appearance.height.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Weight"] = Global.player[i].appearance.weight.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Reputation"] = Global.player[i].attributes.reputation.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Ego"] = Global.player[i].attributes.ego.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Loyalty"] = Global.player[i].attributes.loyalty.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Perks"] = Global.player[i].attributes.perk.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Strength"] = Global.player[i].technicalAbility.strength.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Agility"] = Global.player[i].technicalAbility.agility.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Fitness"] = Global.player[i].technicalAbility.stamina.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Acceleration"] = Global.player[i].technicalAbility.acceleration.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Discipline"] = Global.player[i].technicalAbility.discipline.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Durability"] = Global.player[i].technicalAbility.durability.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Sprint Speed"] = Global.player[i].technicalAbility.sprintSpeed.ToString();
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
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].isPlayerEnabled = Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].id = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[3].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].firstName = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[4].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].lastName = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].gender = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].licensed = Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].isLicensed = true;
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].hidden = Convert.ToBoolean(dataGridView1.Rows[i].Cells[7].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].commentaryNameHash = Convert.ToUInt32(dataGridView1.Rows[i].Cells[8].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].club = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.day = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.month = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].dob.year = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].age = Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyNameSize = Convert.ToByte(dataGridView1.Rows[i].Cells[15].Value.ToString().Length);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].jerseyName = dataGridView1.Rows[i].Cells[15].Value.ToString();
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].primaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].secondaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].tertiaryRole = Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].stateOfOrigin = Convert.ToInt32(dataGridView1.Rows[i].Cells[19].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].originRepNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[20].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].originOtherNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].cityVsCountry = Convert.ToInt32(dataGridView1.Rows[i].Cells[22].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].allStars = Convert.ToInt32(dataGridView1.Rows[i].Cells[23].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].WorldCup = Convert.ToBoolean(dataGridView1.Rows[i].Cells[24].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].preferredHand = Convert.ToByte(dataGridView1.Rows[i].Cells[25].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].preferredFoot = Convert.ToByte(dataGridView1.Rows[i].Cells[26].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].repCountry = Convert.ToInt32(dataGridView1.Rows[i].Cells[27].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].countryOfBirth = Convert.ToInt32(dataGridView1.Rows[i].Cells[28].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].contractExpiry = Convert.ToInt32(dataGridView1.Rows[i].Cells[29].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].appearance.height = Convert.ToInt32(dataGridView1.Rows[i].Cells[30].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].appearance.weight = Convert.ToInt32(dataGridView1.Rows[i].Cells[31].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.reputation = Convert.ToInt32(dataGridView1.Rows[i].Cells[32].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.ego = Convert.ToInt32(dataGridView1.Rows[i].Cells[33].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.loyalty = Convert.ToInt32(dataGridView1.Rows[i].Cells[34].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].attributes.perk = Convert.ToInt32(dataGridView1.Rows[i].Cells[35].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.strength = Convert.ToInt32(dataGridView1.Rows[i].Cells[36].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.agility = Convert.ToInt32(dataGridView1.Rows[i].Cells[37].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.stamina = Convert.ToInt32(dataGridView1.Rows[i].Cells[38].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.acceleration = Convert.ToInt32(dataGridView1.Rows[i].Cells[39].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.discipline = Convert.ToInt32(dataGridView1.Rows[i].Cells[40].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.durability = Convert.ToInt32(dataGridView1.Rows[i].Cells[41].Value);
                Global.player[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].technicalAbility.sprintSpeed = Convert.ToInt32(dataGridView1.Rows[i].Cells[42].Value);

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = (i);
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