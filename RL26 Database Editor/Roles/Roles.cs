namespace RL26_Database_Editor
{
    internal class Roles
    {
        public static string playerRoles(int role)
        {
            string RoleName = string.Empty;

            switch (role)
            {
                case 0:
                    RoleName = "FB";
                    break;
                case 1:
                    RoleName = "WG";
                    break;
                case 2:
                    RoleName = "C";
                    break;
                case 3:
                    RoleName = "FE";
                    break;
                case 4:
                    RoleName = "HB";
                    break;
                case 5:
                    RoleName = "FR";
                    break;
                case 6:
                    RoleName = "HK";
                    break;
                case 7:
                    RoleName = "SR";
                    break;
                case 8:
                    RoleName = "L";
                    break;
            }

            return RoleName;
        }
    }
}
