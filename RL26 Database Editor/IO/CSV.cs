using System.Text;

namespace RL26_Database_Editor
{
    /// <summary>
    /// CSV IO Class.
    /// </summary>
    /// <remarks>
    ///   RL26 Database Editor. Written by Wouldubeinta
    ///   Copyright (C) 2025 Wouldy Mods.
    ///   
    ///   This program is free software; you can redistribute it and/or
    ///   modify it under the terms of the GNU General Public License
    ///   as published by the Free Software Foundation; either version 3
    ///   of the License, or (at your option) any later version.
    ///   
    ///   This program is distributed in the hope that it will be useful,
    ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
    ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ///   GNU General Public License for more details.
    ///   
    ///   You should have received a copy of the GNU General Public License
    ///   along with this program; if not, write to the Free Software
    ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
    /// 
    ///   The author may be contacted at:
    ///   Discord: Wouldubeinta
    /// </remarks>
    /// <history>
    /// [Wouldubeinta]	   01/09/2025	Created
    /// </history>
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
