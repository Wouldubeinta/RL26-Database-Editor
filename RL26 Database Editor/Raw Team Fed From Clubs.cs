using System.Data;

namespace RL26_Database_Editor
{
    public partial class Raw_Team_Fed_From_Clubs : Form
    {
        public Raw_Team_Fed_From_Clubs()
        {
            InitializeComponent();
        }

        private void Raw_Team_Fed_From_Clubs_Load(object sender, EventArgs e)
        {
            DataTable dt = null;

            try
            {
                dt = new DataTable();

                dt.Columns.Add("Index", Type.GetType("System.String"));
                dt.Columns.Add("Team Id", Type.GetType("System.String"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));
                dt.Columns.Add("Fed From Clubs Amount", Type.GetType("System.String"));

                for (int i = 0; i < 7; i++)
                {
                    int value = i + 1;
                    dt.Columns.Add("Fed From Clubs ID - " + value.ToString(), Type.GetType("System.String"));
                }

                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Team Id"] = Global.team[i].id.ToString();
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                    dt.Rows[dt.Rows.Count - 1]["Fed From Clubs Amount"] = Global.team[i].fedFromClubsAmount.ToString();

                    for (int j = 0; j < Global.team[i].fedFromClubsAmount; j++)
                    {
                        int value = j + 1;
                        dt.Rows[dt.Rows.Count - 1]["Fed From Clubs ID - " + value.ToString()] = Global.team[i].fedFromClubs[j].fedFromClubsId.ToString();
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
                for (int j = 0; j < 7; j++)
                {
                    Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fedFromClubs[j].isFedFromClubs = false;
                }
            }

            for (int i = 0; i < Global.team_amount; i++)
            {
                Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fedFromClubsAmount = Convert.ToByte(dataGridView1.Rows[i].Cells[4].Value);

                for (int j = 0; j < Global.team[i].fedFromClubsAmount; j++)
                {
                    if (!(dataGridView1.Rows[i].Cells[j + 5].Value is DBNull))
                    {
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fedFromClubs[j].isFedFromClubs = true;
                        Global.team[Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)].fedFromClubs[j].fedFromClubsId = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 5].Value);
                    }
                }

                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count;
                toolStripProgressBar1.Value = (i);
                toolStripProgressBar1.PerformStep();
            }

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
