namespace RL26_Database_Editor
{
    public class Global
    {
        public const Int32 MAX_TOTAL_TEAMS = 300;

        public const Int32 MIN_PLAYERS_PER_TEAM = 17;
        public const Int32 MAX_PLAYERS_PER_TEAM = 64;
        public const Int32 MAX_TOTAL_PLAYERS = MAX_TOTAL_TEAMS * MAX_PLAYERS_PER_TEAM;

        private static TeamData.Team[] _team = new TeamData.Team[MAX_TOTAL_TEAMS];
        private static PlayerData.Player[] _player = new PlayerData.Player[MAX_TOTAL_PLAYERS];

        private static byte[] _TeamHeader = new byte[3205];
        private static byte[] _PlayerHeader = new byte[2678];

        private static string _version = string.Empty;
        private static string _currentPath = string.Empty;

        private static int _teamRowIndex = 0;

        private static int _team_amount = 0;
        private static int _team_index = 0;

        private static int _playerRowIndex = 0;

        private static int _player_amount = 0;
        private static int _player_index = 0;

        public static TeamData.Team[] team
        {
            get { return _team; }
            set { _team = value; }
        }

        public static PlayerData.Player[] player
        {
            get { return _player; }
            set { _player = value; }
        }

        public static string version
        {
            get { return _version; }
            set { _version = value; }
        }

        public static string currentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public static byte[] TeamHeader
        {
            get { return _TeamHeader; }
            set { _TeamHeader = value; }
        }

        public static byte[] PlayerHeader
        {
            get { return _PlayerHeader; }
            set { _PlayerHeader = value; }
        }

        public static int teamRowIndex
        {
            get { return _teamRowIndex; }
            set { _teamRowIndex = value; }
        }

        public static int team_index
        {
            get { return _team_index; }
            set { _team_index = value; }
        }

        public static int team_amount
        {
            get { return _team_amount; }
            set { _team_amount = value; }
        }

        public static int playerRowIndex
        {
            get { return _playerRowIndex; }
            set { _playerRowIndex = value; }
        }

        public static int player_amount
        {
            get { return _player_amount; }
            set { _player_amount = value; }
        }

        public static int player_index
        {
            get { return _player_index; }
            set { _player_index = value; }
        }
    }
}
