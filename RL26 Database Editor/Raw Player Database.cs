using System.Data;

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
            DataTable? dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Enabled", typeof(bool));
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("Gender", typeof(int));
                dt.Columns.Add("Licensed", typeof(bool));
                dt.Columns.Add("Hidden", typeof(bool));
                dt.Columns.Add("Commentary Name Hash", typeof(uint));
                dt.Columns.Add("Club", typeof(int));
                dt.Columns.Add("DOB - Day", typeof(int));
                dt.Columns.Add("DOB - Month", typeof(int));
                dt.Columns.Add("DOB - Year", typeof(int));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("Jersey Number", typeof(int));
                dt.Columns.Add("Jersey Name", typeof(string));
                dt.Columns.Add("Primary Role", typeof(int));
                dt.Columns.Add("Secondary Role", typeof(int));
                dt.Columns.Add("Tertiary Role", typeof(int));
                dt.Columns.Add("State Of Origin", typeof(int));
                dt.Columns.Add("State Of Origin Rep Number", typeof(int));
                dt.Columns.Add("State Of Origin Other Number", typeof(int));
                dt.Columns.Add("City V's Country", typeof(int));
                dt.Columns.Add("All Stars", typeof(int));
                dt.Columns.Add("World Cup", typeof(bool));
                dt.Columns.Add("Preferred Hand", typeof(byte));
                dt.Columns.Add("Preferred Foot", typeof(byte));
                dt.Columns.Add("Representative Country", typeof(int));
                dt.Columns.Add("Country Of Birth", typeof(int));
                dt.Columns.Add("Contract Expiry", typeof(int));
                dt.Columns.Add("Height", typeof(int));
                dt.Columns.Add("Weight", typeof(int));
                dt.Columns.Add("Reputation", typeof(int));
                dt.Columns.Add("Ego", typeof(int));
                dt.Columns.Add("Loyalty", typeof(int));
                dt.Columns.Add("Perks", typeof(int));
                dt.Columns.Add("Strength", typeof(int));
                dt.Columns.Add("Agility", typeof(int));
                dt.Columns.Add("Fitness", typeof(int));
                dt.Columns.Add("Acceleration", typeof(int));
                dt.Columns.Add("Discipline", typeof(int));
                dt.Columns.Add("Durability", typeof(int));
                dt.Columns.Add("Sprint Speed", typeof(int));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Enabled"] = Global.player[i].isPlayerEnabled;
                    dt.Rows[dt.Rows.Count - 1]["Id"] = Global.player[i].id;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Global.player[i].gender;
                    dt.Rows[dt.Rows.Count - 1]["Licensed"] = Global.player[i].licensed;
                    dt.Rows[dt.Rows.Count - 1]["Hidden"] = Global.player[i].hidden;
                    dt.Rows[dt.Rows.Count - 1]["Commentary Name Hash"] = Global.player[i].commentaryNameHash;
                    dt.Rows[dt.Rows.Count - 1]["Club"] = Global.player[i].club;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Day"] = Global.player[i].dob.day;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Month"] = Global.player[i].dob.month;
                    dt.Rows[dt.Rows.Count - 1]["DOB - Year"] = Global.player[i].dob.year;
                    dt.Rows[dt.Rows.Count - 1]["Age"] = Global.player[i].age;
                    dt.Rows[dt.Rows.Count - 1]["Jersey Number"] = Global.player[i].jerseyNumber;
                    dt.Rows[dt.Rows.Count - 1]["Jersey Name"] = Global.player[i].jerseyName;
                    dt.Rows[dt.Rows.Count - 1]["Primary Role"] = Global.player[i].primaryRole;
                    dt.Rows[dt.Rows.Count - 1]["Secondary Role"] = Global.player[i].secondaryRole;
                    dt.Rows[dt.Rows.Count - 1]["Tertiary Role"] = Global.player[i].tertiaryRole;
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin"] = Global.player[i].stateOfOrigin;
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin Rep Number"] = Global.player[i].originRepNumber;
                    dt.Rows[dt.Rows.Count - 1]["State Of Origin Other Number"] = Global.player[i].originOtherNumber;
                    dt.Rows[dt.Rows.Count - 1]["City V's Country"] = Global.player[i].cityVsCountry;
                    dt.Rows[dt.Rows.Count - 1]["All Stars"] = Global.player[i].allStars;
                    dt.Rows[dt.Rows.Count - 1]["World Cup"] = Global.player[i].WorldCup;
                    dt.Rows[dt.Rows.Count - 1]["Preferred Hand"] = Global.player[i].preferredHand;
                    dt.Rows[dt.Rows.Count - 1]["Preferred Foot"] = Global.player[i].preferredFoot;
                    dt.Rows[dt.Rows.Count - 1]["Representative Country"] = Global.player[i].repCountry;
                    dt.Rows[dt.Rows.Count - 1]["Country Of Birth"] = Global.player[i].countryOfBirth;
                    dt.Rows[dt.Rows.Count - 1]["Contract Expiry"] = Global.player[i].contractExpiry;
                    dt.Rows[dt.Rows.Count - 1]["Height"] = Global.player[i].appearance.height;
                    dt.Rows[dt.Rows.Count - 1]["Weight"] = Global.player[i].appearance.weight;
                    dt.Rows[dt.Rows.Count - 1]["Reputation"] = Global.player[i].attributes.reputation;
                    dt.Rows[dt.Rows.Count - 1]["Ego"] = Global.player[i].attributes.ego;
                    dt.Rows[dt.Rows.Count - 1]["Loyalty"] = Global.player[i].attributes.loyalty;
                    dt.Rows[dt.Rows.Count - 1]["Perks"] = Global.player[i].attributes.perk;
                    dt.Rows[dt.Rows.Count - 1]["Strength"] = Global.player[i].technicalAbility.strength;
                    dt.Rows[dt.Rows.Count - 1]["Agility"] = Global.player[i].technicalAbility.agility;
                    dt.Rows[dt.Rows.Count - 1]["Fitness"] = Global.player[i].technicalAbility.stamina;
                    dt.Rows[dt.Rows.Count - 1]["Acceleration"] = Global.player[i].technicalAbility.acceleration;
                    dt.Rows[dt.Rows.Count - 1]["Discipline"] = Global.player[i].technicalAbility.discipline;
                    dt.Rows[dt.Rows.Count - 1]["Durability"] = Global.player[i].technicalAbility.durability;
                    dt.Rows[dt.Rows.Count - 1]["Sprint Speed"] = Global.player[i].technicalAbility.sprintSpeed;
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