namespace RL26_Database_Editor
{
    /// <summary>
    /// Team Data Struct.
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
    /// [Wouldubeinta]	   17/09/2025	Created
    /// </history>
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
            public RGB primaryColour;
            public RGB secondaryColour;
            public RGB hudTextColour;
            public bool isClubType;
            public int clubType;
            public bool isAffiliations;
            public int affiliations;
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
            public byte shirtNumber;
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
