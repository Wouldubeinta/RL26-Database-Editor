namespace RL26_Database_Editor
{
    public class TeamData
    {
        public struct Team
        {
            public byte[] padding1;
            public int identifier;
            public bool isTeamEnabled;
            public bool teamEnabled;
            public bool isId;
            public int id;
            public bool isFullName;
            public byte fullNameSize;
            public string fullName;
            public bool isLocationName;
            public byte locationNameSize;
            public string locationName;
            public bool isClubName;
            public byte clubNameSize;
            public string clubName;
            public bool isAbbreviatedName;
            public byte abbreviatedNameSize;
            public string abbreviatedName;
            public bool isFrontendVisible;
            public bool frontendVisible;
            public bool isJerseyName;
            public byte jerseyNameSize;
            public string jerseyName;
            public bool isGender;
            public int gender;
            public bool islogo;
            public byte logoSize;
            public string logo;
            public bool isWcLogo;
            public byte wcLogoSize;
            public string wcLogo;
            public bool isSupporters;
            public int supporters;
            public bool isCommentaryTeamLocationHash;
            public uint commentaryTeamLocationHash;
            public bool isCommentaryTeamMascotHash;
            public uint commentaryTeamMascotHash;
            public bool isCommentary;
            public int commentary;
            public RGB primaryColour;
            public RGB secondaryColour;
            public RGB hudTextColour;
            public bool isClubType;
            public int clubType;
            public bool isAffiliations;
            public int affiliations;
            public bool isClubTypeAdditional;
            public int clubTypeAdditional;
            public bool isWorldCupTeam;
            public bool WorldCupTeam;
            public bool isStadiumAmount;
            public int stadiumAmount;
            public Stadium[] stadium;
            public Stadium finalStadium;
            public byte feederClubsAmount;
            public FeederClubs[] feederClubs;
            public byte fedFromClubsAmount;
            public FedFromClubs[] fedFromClubs;
            public bool isAlternateNumbering;
            public bool alternateNumbering;
            public bool isAlternativeNumberingSystem;
            public int alternateNumberingSystem;
            public bool isPlayerRoster;
            public byte playerAmount;
            public TeamPlayers[] players;
            public bool isStandardMatch;
            public Roles[] roles;
            public Lineups[] lineups;
            public bool isNines;
            public NineRoles[] nineRoles;
            public NineLineups[] nineLineups;
            public int dataSize;
            public byte[] data;
            public short jerseyAmount;
            public Jerseys[] jerseys;
            public byte[] padding2;
        }

        public struct RGB
        {
            public bool isRgb;
            public byte r;
            public byte g;
            public byte b;
        }

        public struct Stadium
        {
            public bool isId;
            public int id;
            public bool isWantCustomName;
            public bool wantCustomName;
            public bool isCustomName;
            public byte customNameSize;
            public string customName;
            public bool isStadiumIsOnDisk;
            public bool StadiumIsOnDisk;
        }

        public struct FeederClubs
        {
            public bool isFeederClubs;
            public int feederClubsId;
        }

        public struct FedFromClubs
        {
            public bool isFedFromClubs;
            public int fedFromClubsId;
        }

        public struct TeamPlayers
        {
            public bool isPlayerId;
            public int playerId;
        }

        public struct Roles
        {
            public bool isRoleId;
            public int roleId;
        }

        public struct Lineups
        {
            public bool isLineupId;
            public int lineupId;
            public byte posNumber;
        }

        public struct NineRoles
        {
            public bool isNinesRoleId;
            public int nineRoleId;
        }

        public struct NineLineups
        {
            public bool isNineLineupId;
            public int nineLineupId;
        }

        public struct Jerseys
        {
            public string name;
            public RGB nameColour;
            public RGB keylineColour;
            public RGB numberColour;
            public byte manufactureId;
            public short licensedId;
            public short licensedTopId;
            public short licensedShortsId;
            public short licensedSocksId;
            public byte keylineSize;
            public byte numberFont;
            public byte nameFont;
            public byte keylineOffset;
            public bool showingLeadingZero;
            public bool showName;
            public bool showNumber;
            public bool showInternalKeyline;
            public ushort padding1;
            public byte[] padding2;
            public byte[] padding3;
            public byte[] padding4;
            public byte[] padding5;
            public ushort padding6;
            public byte[] padding7;
            public byte[] padding8;
            public byte[] padding9;
            public byte[] padding10;
            public byte[] padding11;
            public byte[] padding12;
            public byte[] padding13;
            public byte[] padding14;
            public byte[] padding15;
            public byte[] padding16;
            public byte[] padding17;
            public byte[] padding18;
            public byte[] padding19;
        }
    }
}
