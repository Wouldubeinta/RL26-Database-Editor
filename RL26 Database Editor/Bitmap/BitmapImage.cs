namespace RL26_Database_Editor
{
    public class BitmapImage
    {
        public static Bitmap[] genderImages()
        {
            Bitmap[] Imagelist = new Bitmap[2];

            try
            {
                Imagelist[0] = Properties.Resources.Male;
                Imagelist[1] = Properties.Resources.Female;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return Imagelist;
        }
    }
}
