﻿using System.ComponentModel;
using System.Data;

namespace RL26_Database_Editor
{
    internal class RefreshList
    {
        public static void Update_TeamList(DataGridView Teams_dataGridView)
        {
            ListSortDirection[] sd = new ListSortDirection[5];
            bool[] none = new bool[5];

            for (int i = 1; i < 5; i++)
            {
                SortOrder sortOrder = Teams_dataGridView.Columns[i].HeaderCell.SortGlyphDirection;

                if (sortOrder != SortOrder.None)
                    sd[i] = sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                else
                    none[i] = true;
            }

            Refresh_TeamList(Teams_dataGridView);

            for (int i = 1; i < 5; i++)
            {
                if (!none[i])
                    Teams_dataGridView.Sort(Teams_dataGridView.Columns[i], sd[i]);
            }
        }

        public static void Update_PlayerList(DataGridView Players_dataGridView)
        {
            ListSortDirection[] sd = new ListSortDirection[5];
            bool[] none = new bool[5];

            for (int i = 1; i < 5; i++)
            {
                SortOrder sortOrder = Players_dataGridView.Columns[i].HeaderCell.SortGlyphDirection;

                if (sortOrder != SortOrder.None)
                    sd[i] = sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                else
                    none[i] = true;
            }

            Refresh_PlayerList(Players_dataGridView);

            for (int i = 0; i < 5; i++)
            {
                if (!none[i])
                    Players_dataGridView.Sort(Players_dataGridView.Columns[i], sd[i]);
            }
        }

        private static void Refresh_TeamList(DataGridView Teams_dataGridView)
        {
            Teams_dataGridView.DataSource = null;

            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.genderImages();

                dt.Columns.Add("Gender", typeof(Image));
                dt.Columns.Add("Team Index", Type.GetType("System.Int32"));
                dt.Columns.Add("Team ID", Type.GetType("System.Int32"));
                dt.Columns.Add("Location Name", Type.GetType("System.String"));
                dt.Columns.Add("Club Name", Type.GetType("System.String"));

                for (int i = 0; i < Global.team_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Imagelist[Global.team[i].gender];
                    dt.Rows[dt.Rows.Count - 1]["Team Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Team ID"] = Global.team[i].id;
                    dt.Rows[dt.Rows.Count - 1]["Location Name"] = Global.team[i].locationName;
                    dt.Rows[dt.Rows.Count - 1]["Club Name"] = Global.team[i].clubName;
                }

                Teams_dataGridView.DataSource = dt;

                Teams_dataGridView.Columns[0].Width = 70;
                Teams_dataGridView.Columns[1].Width = 95;
                Teams_dataGridView.Columns[2].Width = 95;
                Teams_dataGridView.Columns[3].Width = 185;
                Teams_dataGridView.Columns[4].Width = 185;

                Teams_dataGridView.Rows[Global.teamRowIndex].Selected = true;
                Teams_dataGridView.CurrentCell = Teams_dataGridView.Rows[Global.teamRowIndex].Cells[0];
                Teams_dataGridView.Rows[Global.teamRowIndex].Visible = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private static void Refresh_PlayerList(DataGridView Players_dataGridView)
        {
            Players_dataGridView.DataSource = null;

            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.genderImages();

                dt.Columns.Add("Gender", typeof(Image));
                dt.Columns.Add("Player Index", Type.GetType("System.Int32"));
                dt.Columns.Add("Player ID", Type.GetType("System.Int32"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));

                for (int i = 0; i < Global.player_amount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Gender"] = Imagelist[Global.player[i].gender];
                    dt.Rows[dt.Rows.Count - 1]["Player Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["Player ID"] = Global.player[i].id;
                    dt.Rows[dt.Rows.Count - 1]["First Name"] = Global.player[i].firstName;
                    dt.Rows[dt.Rows.Count - 1]["Last Name"] = Global.player[i].lastName;
                }

                Players_dataGridView.DataSource = dt;

                Players_dataGridView.Columns[0].Width = 70;
                Players_dataGridView.Columns[1].Width = 95;
                Players_dataGridView.Columns[2].Width = 95;
                Players_dataGridView.Columns[3].Width = 155;
                Players_dataGridView.Columns[4].Width = 155;

                Players_dataGridView.Rows[Global.playerRowIndex].Selected = true;
                Players_dataGridView.CurrentCell = Players_dataGridView.Rows[Global.playerRowIndex].Cells[0];
                Players_dataGridView.Rows[Global.playerRowIndex].Visible = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
