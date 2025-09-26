using System.Text;

namespace RL26_Database_Editor
{
    public static class CSV
    {
        public static void FromCSV(DataGridView dGV, string filename)
        {
            System.Data.OleDb.OleDbConnection? MyConnection = null;

            try
            {
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""", Path.GetDirectoryName(filename)));
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(filename) + "]", MyConnection);
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);

                dGV.DataSource = DtSet.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (MyConnection != null)
                {
                    MyConnection.Close();
                }

                MessageBox.Show("Importing csv file has finished", "Import CSV Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void ToCSV(DataGridView dGV, string filename)
        {
            ToolStripProgressBar PB = new();
            ToCSV(dGV, filename, PB);
            PB.Dispose();
        }

        public static void ToCSV(DataGridView dGV, string filename, ToolStripProgressBar PB)
        {
            try
            {
                int columnCount = dGV.ColumnCount;
                int rowCount = dGV.RowCount;
                string columnNames = string.Empty;
                string[] output = new string[rowCount + 1];
                string gender = string.Empty;

                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += dGV.Columns[i].Name.ToString() + ",";
                }

                output[0] += columnNames;
                int lengthC = output[0].Length;
                output[0] = output[0].Remove(lengthC - 1, 1);

                for (int i = 1; (i - 1) < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dGV.Rows[i - 1].Cells[j].Value != null)
                        {
                            if (dGV.Rows[i - 1].Cells[j].Value.GetType() == typeof(Bitmap))
                            {
                                Bitmap bm = (Bitmap)dGV.Rows[i - 1].Cells[j].Value;
                                gender = "Male";
                                if (bm.Width == 13)
                                    gender = "Female";

                                output[i] += gender.TrimEnd(new char[] { (char)0 }) + ",";
                            }
                            else
                                output[i] += dGV.Rows[i - 1].Cells[j].Value.ToString().TrimEnd(new char[] { (char)0 }) + ",";

                            if (j == columnCount - 1)
                            {
                                int lengthR = output[i].Length;
                                output[i] = output[i].Remove(lengthR - 1, 1);
                            }
                        }
                        else
                            output[i] += string.Empty;
                    }

                    PB.Maximum = dGV.Rows.Count;
                    PB.Value = (i - 1);
                    PB.PerformStep();
                }

                File.WriteAllLines(filename, output, Encoding.Default);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                PB.Value = 0;
                MessageBox.Show("Exporting to csv has finished", "Export CSV Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
