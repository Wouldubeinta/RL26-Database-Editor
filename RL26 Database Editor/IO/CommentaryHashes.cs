using PackageIO;

namespace RL26_Database_Editor
{
    public class CommentaryHashes
    {
        public static Dialogue_Wildcardhash.WildcardHash[] Read(string file)
        {
            Reader? br = null;
            Dialogue_Wildcardhash.WildcardHash[]? wildcardHashes = null;

            try
            {
                br = new Reader(file);

                uint count = br.ReadUInt32();
                wildcardHashes = new Dialogue_Wildcardhash.WildcardHash[count];

                for (int i = 0; i < count; i++)
                {
                    wildcardHashes[i] = new Dialogue_Wildcardhash.WildcardHash();
                    wildcardHashes[i].hash = br.ReadUInt32();
                    int nameSize = br.ReadInt32();
                    wildcardHashes[i].name = br.ReadString(nameSize);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null) { br.Close(); br = null; }
            }
            return wildcardHashes;
        }

        public static int GetHashes(uint hash, Dialogue_Wildcardhash.WildcardHash[] wildcardHashes)
        {
            int index = -1;

            for (int i = 0; i < wildcardHashes.Length; i++)
            {
                if (wildcardHashes[i].hash == hash)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static uint SetHashes(string name, Dialogue_Wildcardhash.WildcardHash[] wildcardHashes)
        {
            uint hash = 2913447899; // none hash

            for (int i = 0; i < wildcardHashes.Length; i++)
            {
                if (wildcardHashes[i].name == name)
                {
                    hash = wildcardHashes[i].hash;
                    break;
                }
            }
            return hash;
        }
    }
}
