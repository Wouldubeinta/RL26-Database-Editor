namespace RL26_Database_Editor
{
    public class SearchID
    {
        public static int TeamsIndex(int index)
        {
            int selectedIndex = 1;

            try
            {
                for (int i = 0; i < Global.team_amount; i++)
                {
                    if (Global.team[i].id.Equals(index))
                    {
                        selectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return selectedIndex;
        }

        public static int PlayersIndex(int index)
        {
            int SelectedIndex = 1;

            try
            {
                for (int i = 0; i < Global.player_amount; i++)
                {
                    if (Global.player[i].id.Equals(index))
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return SelectedIndex;
        }
    }
}
