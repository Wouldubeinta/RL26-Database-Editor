using PackageIO;
using System.Data;

namespace RL26_Database_Editor
{
    internal class ReadDatabase
    {
        public static void defaultdata_clubs(string file, DataGridView Teams_dataGridView)
        {
            Reader? br = null;
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

                br = new Reader(file, FileMode.Open, Endian.Little);

                //Global.TeamHeader = br.ReadBytes(3361, Endian.Little); // old db
                Global.TeamHeader = br.ReadBytes(3304, Endian.Little);
                Global.team_amount = br.ReadInt32(Endian.Little);

                for (int i = 0; i < Global.team_amount; i++)
                {
                    Global.team[i].identifier = br.ReadInt32(Endian.Little);
                    Global.team[i].isTeamEnabled = br.ReadBoolean();
                    Global.team[i].isId = br.ReadBoolean();
                    Global.team[i].id = br.ReadInt32(Endian.Little);

                    Global.team[i].isFullName = br.ReadBoolean();
                    Global.team[i].fullNameSize = br.ReadByte();
                    Global.team[i].fullName = br.ReadString(Global.team[i].fullNameSize);

                    Global.team[i].isLocationName = br.ReadBoolean();
                    Global.team[i].locationNameSize = br.ReadByte();
                    Global.team[i].locationName = br.ReadString(Global.team[i].locationNameSize);

                    Global.team[i].isClubName = br.ReadBoolean();
                    Global.team[i].clubNameSize = br.ReadByte();
                    Global.team[i].clubName = br.ReadString(Global.team[i].clubNameSize);

                    Global.team[i].isAbbreviatedName = br.ReadBoolean();
                    Global.team[i].abbreviatedNameSize = br.ReadByte();
                    Global.team[i].abbreviatedName = br.ReadString(Global.team[i].abbreviatedNameSize);

                    Global.team[i].isFrontendVisible = br.ReadBoolean();
                    Global.team[i].frontendVisible = br.ReadBoolean();

                    Global.team[i].isJerseyName = br.ReadBoolean(); // ?

                    Global.team[i].isGender = br.ReadBoolean();
                    Global.team[i].gender = br.ReadInt32(Endian.Little);

                    Global.team[i].islogo = br.ReadBoolean();
                    Global.team[i].logoSize = br.ReadByte();
                    Global.team[i].logo = br.ReadString(Global.team[i].logoSize);

                    Global.team[i].isWcLogo = br.ReadBoolean();
                    Global.team[i].wcLogoSize = 0;
                    Global.team[i].wcLogo = string.Empty;

                    if (Global.team[i].isWcLogo)
                    {
                        Global.team[i].wcLogoSize = br.ReadByte();
                        Global.team[i].wcLogo = br.ReadString(Global.team[i].logoSize);
                    }

                    Global.team[i].isSupporters = br.ReadBoolean();
                    Global.team[i].supporters = br.ReadInt32(Endian.Little);

                    Global.team[i].isCommentaryTeamLocationHash = br.ReadBoolean();
                    Global.team[i].commentaryTeamLocationHash = br.ReadUInt32(Endian.Little);

                    Global.team[i].isCommentaryTeamMascotHash = br.ReadBoolean();
                    Global.team[i].commentaryTeamMascotHash = br.ReadUInt32(Endian.Little);

                    Global.team[i].primaryColour.isRgb = br.ReadBoolean();
                    Global.team[i].primaryColour.r = br.ReadByte();
                    Global.team[i].primaryColour.g = br.ReadByte();
                    Global.team[i].primaryColour.b = br.ReadByte();

                    Global.team[i].secondaryColour.isRgb = br.ReadBoolean();
                    Global.team[i].secondaryColour.r = br.ReadByte();
                    Global.team[i].secondaryColour.g = br.ReadByte();
                    Global.team[i].secondaryColour.b = br.ReadByte();

                    Global.team[i].hudTextColour.isRgb = br.ReadBoolean();
                    Global.team[i].hudTextColour.r = br.ReadByte();
                    Global.team[i].hudTextColour.g = br.ReadByte();
                    Global.team[i].hudTextColour.b = br.ReadByte();

                    Global.team[i].isClubType = br.ReadBoolean();
                    Global.team[i].clubType = 0;

                    if (Global.team[i].isClubType)
                        Global.team[i].clubType = br.ReadInt32(Endian.Little);

                    Global.team[i].isAffiliations = br.ReadBoolean();
                    Global.team[i].affiliations = 0;

                    if (Global.team[i].isAffiliations)
                        Global.team[i].affiliations = br.ReadInt32(Endian.Little);

                    Global.team[i].isWorldCupTeam = br.ReadBoolean();
                    Global.team[i].WorldCupTeam = false;

                    if (Global.team[i].isWorldCupTeam)
                        Global.team[i].WorldCupTeam = br.ReadBoolean();

                    Global.team[i].isStadiumAmount = br.ReadBoolean();
                    Global.team[i].stadiumAmount = br.ReadInt32(Endian.Little);

                    Global.team[i].stadium = new TeamData.Stadium[3];

                    for (int j = 0; j < 3; j++)
                    {
                        Global.team[i].stadium[j].isId = br.ReadBoolean();
                        Global.team[i].stadium[j].id = 5;

                        if (Global.team[i].stadium[j].isId)
                            Global.team[i].stadium[j].id = br.ReadInt32(Endian.Little);

                        Global.team[i].stadium[j].isWantCustomName = br.ReadBoolean();
                        Global.team[i].stadium[j].wantCustomName = false;

                        if (Global.team[i].stadium[j].isWantCustomName)
                            Global.team[i].stadium[j].wantCustomName = br.ReadBoolean();

                        Global.team[i].stadium[j].isCustomName = br.ReadBoolean();
                        Global.team[i].stadium[j].customNameSize = 0;
                        Global.team[i].stadium[j].customName = string.Empty;

                        if (Global.team[i].stadium[j].isCustomName)
                        {
                            Global.team[i].stadium[j].customNameSize = br.ReadByte();
                            Global.team[i].stadium[j].customName = br.ReadString(Global.team[i].stadium[j].customNameSize);
                        }

                        Global.team[i].stadium[j].isStadiumIsOnDisk = br.ReadBoolean();
                        Global.team[i].stadium[j].StadiumIsOnDisk = false;

                        if (Global.team[i].stadium[j].isStadiumIsOnDisk)
                            Global.team[i].stadium[j].StadiumIsOnDisk = br.ReadBoolean();
                    }

                    Global.team[i].finalStadium.isId = br.ReadBoolean();
                    Global.team[i].finalStadium.id = 8;

                    if (Global.team[i].finalStadium.isId)
                        Global.team[i].finalStadium.id = br.ReadInt32(Endian.Little);

                    Global.team[i].finalStadium.isWantCustomName = br.ReadBoolean();
                    Global.team[i].finalStadium.wantCustomName = false;

                    if (Global.team[i].finalStadium.isWantCustomName)
                        Global.team[i].finalStadium.wantCustomName = br.ReadBoolean();

                    Global.team[i].finalStadium.isCustomName = br.ReadBoolean();
                    Global.team[i].finalStadium.customNameSize = 0;
                    Global.team[i].finalStadium.customName = string.Empty;

                    if (Global.team[i].finalStadium.isCustomName)
                    {
                        Global.team[i].finalStadium.customNameSize = br.ReadByte();
                        Global.team[i].finalStadium.customName = br.ReadString(Global.team[i].finalStadium.customNameSize);
                    }

                    Global.team[i].feederClubs = new TeamData.FeederClubs[7];
                    byte feederClub_Amount = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        Global.team[i].feederClubs[j].isFeederClubs = br.ReadBoolean();
                        Global.team[i].feederClubs[j].feederClubsId = 1;

                        if (Global.team[i].feederClubs[j].isFeederClubs)
                        {
                            feederClub_Amount++;
                            Global.team[i].feederClubs[j].feederClubsId = br.ReadInt32(Endian.Little);
                        }
                    }

                    Global.team[i].feederClubsAmount = feederClub_Amount;

                    Global.team[i].fedFromClubs = new TeamData.FedFromClubs[7];
                    byte fedFromClubs_Amount = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        Global.team[i].fedFromClubs[j].isFedFromClubs = br.ReadBoolean();
                        Global.team[i].fedFromClubs[j].fedFromClubsId = 1;

                        if (Global.team[i].fedFromClubs[j].isFedFromClubs)
                        {
                            fedFromClubs_Amount++;
                            Global.team[i].fedFromClubs[j].fedFromClubsId = br.ReadInt32(Endian.Little);
                        }
                    }

                    Global.team[i].fedFromClubsAmount = fedFromClubs_Amount;

                    Global.team[i].isAlternateNumbering = br.ReadBoolean();
                    Global.team[i].alternateNumbering = false;

                    if (Global.team[i].isAlternateNumbering)
                        Global.team[i].alternateNumbering = br.ReadBoolean();

                    Global.team[i].isAlternativeNumberingSystem = br.ReadBoolean();
                    Global.team[i].alternateNumberingSystem = 0;

                    if (Global.team[i].isAlternativeNumberingSystem)
                        Global.team[i].alternateNumberingSystem = br.ReadInt32(Endian.Little);

                    Global.team[i].isPlayerRoster = br.ReadBoolean();

                    Global.team[i].players = new TeamData.TeamPlayers[Global.MAX_PLAYERS_PER_TEAM]; // 64 players max.
                    byte team_players_amount = 0;

                    for (int j = 0; j < Global.MAX_PLAYERS_PER_TEAM; j++) // 64 players max.
                    {
                        Global.team[i].players[j].isPlayerId = br.ReadBoolean();
                        Global.team[i].players[j].playerId = 1;

                        if (Global.team[i].players[j].isPlayerId)
                        {
                            team_players_amount++;
                            Global.team[i].players[j].playerId = br.ReadInt32(Endian.Little);
                        }
                    }

                    Global.team[i].playerAmount = team_players_amount;

                    Global.team[i].isStandardMatch = br.ReadBoolean();
                    Global.team[i].roles = new TeamData.Roles[4];

                    for (int j = 0; j < 4; j++)
                    {
                        Global.team[i].roles[j].isRoleId = br.ReadBoolean();
                        Global.team[i].roles[j].roleId = 1;

                        if (Global.team[i].roles[j].isRoleId)
                            Global.team[i].roles[j].roleId = br.ReadInt32(Endian.Little);
                    }

                    Global.team[i].lineups = new TeamData.Lineups[Global.MIN_PLAYERS_PER_TEAM]; // new db 17 players, old db 20 players

                    for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                    {
                        Global.team[i].lineups[j].isLineupId = br.ReadBoolean();
                        Global.team[i].lineups[j].lineupId = 0;

                        if (Global.team[i].lineups[j].isLineupId)
                        {
                            Global.team[i].lineups[j].lineupId = br.ReadInt32(Endian.Little);
                            Global.team[i].lineups[j].posNumber = br.ReadByte(); // added to new db
                        }
                    }

                    Global.team[i].isNines = br.ReadBoolean();
                    Global.team[i].nineRoles = new TeamData.NineRoles[4];

                    for (int j = 0; j < 4; j++)
                    {
                        Global.team[i].nineRoles[j].isNinesRoleId = br.ReadBoolean();
                        Global.team[i].nineRoles[j].nineRoleId = 0;

                        if (Global.team[i].nineRoles[j].isNinesRoleId)
                            Global.team[i].nineRoles[j].nineRoleId = br.ReadInt32(Endian.Little);
                    }

                    Global.team[i].nineLineups = new TeamData.NineLineups[14];

                    for (int j = 0; j < 14; j++)
                    {
                        Global.team[i].nineLineups[j].isNineLineupId = br.ReadBoolean();
                        Global.team[i].nineLineups[j].nineLineupId = 1;

                        if (Global.team[i].nineLineups[j].isNineLineupId)
                            Global.team[i].nineLineups[j].nineLineupId = br.ReadInt32(Endian.Little);
                    }

                    Global.team[i].dataSize = br.ReadInt32(Endian.Little);
                    //long pos = br.Position;
                    //br.Position = pos + Global.team[i].dataSize;
                    Global.team[i].data = br.ReadBytes(Global.team[i].dataSize, Endian.Little);

                    /*
                    if (Global.team[i].dataSize == 8603)
                        Global.team[i].data = br.ReadBytes(4448, Endian.Little); // Data
                    else if (Global.team[i].dataSize == 8643)
                        Global.team[i].data = br.ReadBytes(Global.team[i].dataSize - 4195, Endian.Little); // Data
                    else if (Global.team[i].dataSize == 9103)
                        Global.team[i].data = br.ReadBytes(4748, Endian.Little); // Data

                    Global.team[i].jerseyAmount = br.ReadInt16();
                    Global.team[i].jerseys = new TeamData.Jerseys[8];

                    for (int j = 0; j < 8; j++)
                    {
                        Global.team[i].jerseys[j].name = br.ReadNullTerminatedString();
                        br.ReadBytes(24 - Global.team[i].jerseys[j].name.Length, Endian.Little);

                        Global.team[i].jerseys[j].padding2 = br.ReadBytes(167, Endian.Little);
                        Global.team[i].jerseys[j].licensedShortsId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding3 = br.ReadBytes(115, Endian.Little);
                        Global.team[i].jerseys[j].licensedTopId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding4 = br.ReadBytes(16, Endian.Little);
                        Global.team[i].jerseys[j].licensedSocksId = br.ReadInt16();
                        Global.team[i].jerseys[j].padding5 = br.ReadBytes(189, Endian.Little);

                        Global.team[i].jerseys[j].padding1 = br.ReadUInt16(Endian.Little);
                        Global.team[i].jerseys[j].nameColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding2 = br.ReadBytes(14, Endian.Little);
                        Global.team[i].jerseys[j].nameColour.r = br.ReadByte();
                        Global.team[i].jerseys[j].padding3 = br.ReadBytes(35, Endian.Little);
                        Global.team[i].jerseys[j].nameColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding4 = br.ReadBytes(8, Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding5 = br.ReadBytes(57, Endian.Little);
                        Global.team[i].jerseys[j].showNumber = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding6 = br.ReadUInt16(Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding7 = br.ReadBytes(5, Endian.Little);
                        Global.team[i].jerseys[j].showInternalKeyline = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding8 = br.ReadBytes(61, Endian.Little);
                        Global.team[i].jerseys[j].numberColour.g = br.ReadByte();
                        Global.team[i].jerseys[j].padding9 = br.ReadBytes(53, Endian.Little);
                        Global.team[i].jerseys[j].numberColour.b = br.ReadByte();
                        Global.team[i].jerseys[j].padding10 = br.ReadBytes(42, Endian.Little);
                        Global.team[i].jerseys[j].manufactureId = br.ReadByte();
                        Global.team[i].jerseys[j].padding11 = br.ReadBytes(19, Endian.Little);
                        Global.team[i].jerseys[j].licensedId = br.ReadInt16(Endian.Little);
                        Global.team[i].jerseys[j].padding12 = br.ReadBytes(39, Endian.Little);
                        Global.team[i].jerseys[j].keylineSize = br.ReadByte();
                        Global.team[i].jerseys[j].padding13 = br.ReadBytes(48, Endian.Little);
                        Global.team[i].jerseys[j].numberFont = br.ReadByte();
                        Global.team[i].jerseys[j].padding14 = br.ReadBytes(79, Endian.Little);
                        Global.team[i].jerseys[j].nameFont = br.ReadByte();
                        Global.team[i].jerseys[j].padding15 = br.ReadBytes(15, Endian.Little);
                        Global.team[i].jerseys[j].keylineOffset = br.ReadByte();
                        Global.team[i].jerseys[j].showingLeadingZero = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding16 = br.ReadBytes(7, Endian.Little);
                        Global.team[i].jerseys[j].showName = br.ReadBoolean();
                        Global.team[i].jerseys[j].padding17 = br.ReadBytes(39, Endian.Little);
                        Global.team[i].jerseys[j].keylineColour.r = br.ReadByte();
                        Global.team[i].jerseys[j].padding18 = br.ReadBytes(9, Endian.Little);
                        Global.team[i].jerseys[j].numberColour.r = br.ReadByte();

                        if (Global.team[i].dataSize == 11103)
                            Global.team[i].jerseys[j].padding19 = br.ReadBytes(64, Endian.Little);
                        else if (Global.team[i].dataSize == 11123)
                            Global.team[i].jerseys[j].padding19 = br.ReadBytes(65, Endian.Little);
                    }

                    Global.team[i].padding2 = br.ReadBytes(9, Endian.Little);
                    int y = 0;
                    */

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
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

        public static void defaultdata_players(string file, DataGridView Players_dataGridView)
        {
            Players_dataGridView.DataSource = null;

            Reader br = null;
            DataTable dt = null;
            Bitmap[] Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.genderImages();

                dt.Columns.Add("Gender", typeof(Image));
                dt.Columns.Add("Player Index", Type.GetType("System.Int32"));
                dt.Columns.Add("Player ID", Type.GetType("System.Int32"));
                dt.Columns.Add("First Name", Type.GetType("System.String"));
                dt.Columns.Add("Last Name", Type.GetType("System.String"));

                br = new Reader(file, FileMode.Open, Endian.Little);

                Global.PlayerHeader = br.ReadBytes(2795, Endian.Little);
                Global.player_amount = br.ReadInt32(Endian.Little);

                for (int i = 0; i < Global.player_amount; i++)
                {
                    Global.player[i].identifier = br.ReadInt32(Endian.Little);

                    Global.player[i].dataSize = br.ReadInt32(Endian.Little);
                    Global.player[i].data = br.ReadBytes(Global.player[i].dataSize, Endian.Little);

                    // Ids
                    Global.player[i].isPlayerEnabled = br.ReadBoolean();
                    Global.player[i].isId = br.ReadBoolean();
                    Global.player[i].id = br.ReadInt32(Endian.Little);

                    // FirstName
                    Global.player[i].isFirstName = br.ReadBoolean();
                    Global.player[i].firstNameSize = br.ReadByte();
                    Global.player[i].firstName = br.ReadString(Global.player[i].firstNameSize);

                    // Lastname
                    Global.player[i].isLastName = br.ReadBoolean();
                    Global.player[i].lastNameSize = br.ReadByte();
                    Global.player[i].lastName = br.ReadString(Global.player[i].lastNameSize);

                    Global.player[i].isLicensed = br.ReadBoolean();
                    Global.player[i].licensed = true;

                    if (Global.player[i].isLicensed)
                        Global.player[i].licensed = br.ReadBoolean();

                    Global.player[i].isHidden = br.ReadBoolean();
                    Global.player[i].hidden = false;

                    if (Global.player[i].isHidden)
                        Global.player[i].hidden = br.ReadBoolean();

                    Global.player[i].isClub = br.ReadBoolean();
                    Global.player[i].club = 0;

                    if (Global.player[i].isClub)
                        Global.player[i].club = br.ReadInt32(Endian.Little);

                    Global.player[i].isGender = br.ReadBoolean();
                    Global.player[i].gender = 0;

                    if (Global.player[i].isGender)
                        Global.player[i].gender = br.ReadInt32(Endian.Little);

                    Global.player[i].isJerseyName = br.ReadBoolean();
                    Global.player[i].jerseyNameSize = br.ReadByte();
                    Global.player[i].jerseyName = br.ReadString(Global.player[i].jerseyNameSize);

                    Global.player[i].isJerseyNumber = br.ReadBoolean();
                    Global.player[i].jerseyNumber = 1;

                    if (Global.player[i].isJerseyNumber)
                        Global.player[i].jerseyNumber = br.ReadInt32(Endian.Little);

                    Global.player[i].dob.isDay = br.ReadBoolean();
                    Global.player[i].dob.day = br.ReadInt32(Endian.Little);
                    Global.player[i].dob.isMonth = br.ReadBoolean();
                    Global.player[i].dob.month = br.ReadInt32(Endian.Little);
                    Global.player[i].dob.isYear = br.ReadBoolean();
                    Global.player[i].dob.year = br.ReadInt32(Endian.Little);

                    Global.player[i].isAge = br.ReadBoolean();
                    Global.player[i].age = 0;

                    if (Global.player[i].isAge)
                        Global.player[i].age = br.ReadInt32(Endian.Little);

                    Global.player[i].isCountryOfBirth = br.ReadBoolean();
                    Global.player[i].countryOfBirth = 0;

                    if (Global.player[i].isCountryOfBirth)
                        Global.player[i].countryOfBirth = br.ReadInt32(Endian.Little);

                    Global.player[i].isRepCountry = br.ReadBoolean();
                    Global.player[i].repCountry = 0;

                    if (Global.player[i].isRepCountry)
                        Global.player[i].repCountry = br.ReadInt32(Endian.Little);

                    Global.player[i].isStateOfOrigin = br.ReadBoolean();
                    Global.player[i].stateOfOrigin = 0;

                    if (Global.player[i].isStateOfOrigin)
                        Global.player[i].stateOfOrigin = br.ReadInt32(Endian.Little);

                    Global.player[i].isOriginRepNumber = br.ReadBoolean();
                    Global.player[i].originRepNumber = 0;

                    if (Global.player[i].isOriginRepNumber)
                        Global.player[i].originRepNumber = br.ReadInt32(Endian.Little);

                    Global.player[i].isOriginOtherNumber = br.ReadBoolean();
                    Global.player[i].originOtherNumber = 0;

                    if (Global.player[i].isOriginOtherNumber)
                        Global.player[i].originOtherNumber = br.ReadInt32(Endian.Little);

                    Global.player[i].isCityVsCountry = br.ReadBoolean();
                    Global.player[i].cityVsCountry = 0;

                    if (Global.player[i].isCityVsCountry)
                        Global.player[i].cityVsCountry = br.ReadInt32(Endian.Little);

                    Global.player[i].isAllStars = br.ReadBoolean();
                    Global.player[i].allStars = 0;

                    if (Global.player[i].isAllStars)
                        Global.player[i].allStars = br.ReadInt32(Endian.Little);

                    Global.player[i].isWorldCup = br.ReadBoolean();
                    Global.player[i].WorldCup = false;

                    if (Global.player[i].isWorldCup)
                        Global.player[i].WorldCup = br.ReadBoolean();

                    Global.player[i].isContractExpiry = br.ReadBoolean();
                    Global.player[i].contractExpiry = 0;

                    if (Global.player[i].isContractExpiry)
                        Global.player[i].contractExpiry = br.ReadInt32(Endian.Little);

                    Global.player[i].isPrimaryRole = br.ReadBoolean();
                    Global.player[i].primaryRole = 0;

                    if (Global.player[i].isPrimaryRole)
                        Global.player[i].primaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isSecondaryRole = br.ReadBoolean();
                    Global.player[i].secondaryRole = 0;

                    if (Global.player[i].isSecondaryRole)
                        Global.player[i].secondaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isTertiaryRole = br.ReadBoolean();
                    Global.player[i].tertiaryRole = 0;

                    if (Global.player[i].isTertiaryRole)
                        Global.player[i].tertiaryRole = br.ReadInt32(Endian.Little);

                    Global.player[i].isCommentaryNameHash = br.ReadBoolean();
                    Global.player[i].commentaryNameHash = 0;

                    if (Global.player[i].isCommentaryNameHash)
                        Global.player[i].commentaryNameHash = br.ReadUInt32(Endian.Little);

                    Global.player[i].isPreferredHand = br.ReadBoolean();
                    Global.player[i].preferredHand = 0;

                    if (Global.player[i].isPreferredHand)
                        Global.player[i].preferredHand = br.ReadByte();

                    Global.player[i].isPreferredFoot = br.ReadBoolean();
                    Global.player[i].preferredFoot = 0;

                    if (Global.player[i].isPreferredFoot)
                        Global.player[i].preferredFoot = br.ReadByte();

                    Global.player[i].appearance.isHeight = br.ReadBoolean();
                    Global.player[i].appearance.height = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isWeight = br.ReadBoolean();
                    Global.player[i].appearance.weight = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isReputation = br.ReadBoolean();
                    Global.player[i].attributes.reputation = 0;

                    if (Global.player[i].attributes.isReputation)
                        Global.player[i].attributes.reputation = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isEgo = br.ReadBoolean();
                    Global.player[i].attributes.ego = 0;

                    if (Global.player[i].attributes.isEgo)
                        Global.player[i].attributes.ego = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isLoyalty = br.ReadBoolean();
                    Global.player[i].attributes.loyalty = 0;

                    if (Global.player[i].attributes.isLoyalty)
                        Global.player[i].attributes.loyalty = br.ReadInt32(Endian.Little);

                    Global.player[i].attributes.isPerk = br.ReadBoolean();

                    if (Global.player[i].attributes.isPerk)
                        Global.player[i].attributes.perk = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isHeadVisual = br.ReadBoolean();
                    Global.player[i].appearance.headVisual = 0;

                    if (Global.player[i].appearance.isHeadVisual)
                        Global.player[i].appearance.headVisual = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isHairTopVisual = br.ReadBoolean();
                    Global.player[i].appearance.hairTopVisual = 0;

                    if (Global.player[i].appearance.isHairTopVisual)
                        Global.player[i].appearance.hairTopVisual = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isStrength = br.ReadBoolean();
                    Global.player[i].technicalAbility.strength = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isDurability = br.ReadBoolean();
                    Global.player[i].technicalAbility.durability = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isDiscipline = br.ReadBoolean();
                    Global.player[i].technicalAbility.discipline = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.tackleSkills.isTackle = br.ReadBoolean();
                    Global.player[i].skills.tackleSkills.tackle = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.tackleSkills.isDriveTackle = br.ReadBoolean();
                    Global.player[i].skills.tackleSkills.driveTackle = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.tackleSkills.isDiveTackle = br.ReadBoolean();
                    Global.player[i].skills.tackleSkills.diveTackle = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.tackleSkills.isImpactTackle = br.ReadBoolean();
                    Global.player[i].skills.tackleSkills.impactTackle = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isAgility = br.ReadBoolean();
                    Global.player[i].technicalAbility.agility = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isFitness = br.ReadBoolean();
                    Global.player[i].technicalAbility.fitness = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isAcceleration = br.ReadBoolean();
                    Global.player[i].technicalAbility.acceleration = br.ReadInt32(Endian.Little);

                    Global.player[i].technicalAbility.isSprintSpeed = br.ReadBoolean();
                    Global.player[i].technicalAbility.sprintSpeed = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isGrubberKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.grubberKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isPuntKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.puntKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isChipKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.chipKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isBombKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.bombKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isFieldgoalKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.fieldgoalKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.kickingSkills.isPlaceKick = br.ReadBoolean();
                    Global.player[i].skills.kickingSkills.placeKick = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.passingSkills.isBasicPass = br.ReadBoolean();
                    Global.player[i].skills.passingSkills.basicPass = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.passingSkills.islongPass = br.ReadBoolean();
                    Global.player[i].skills.passingSkills.longPass = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.passingSkills.isOffload = br.ReadBoolean();
                    Global.player[i].skills.passingSkills.offload = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.miscSkills.isContestedCollect = br.ReadBoolean();
                    Global.player[i].skills.miscSkills.contestedCollect = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.miscSkills.isDiveCollect = br.ReadBoolean();
                    Global.player[i].skills.miscSkills.diveCollect = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.miscSkills.isBallStrip = br.ReadBoolean();
                    Global.player[i].skills.miscSkills.ballStrip = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.evasionSkills.isDummyPass = br.ReadBoolean();
                    Global.player[i].skills.evasionSkills.dummyPass = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.evasionSkills.isFend = br.ReadBoolean();
                    Global.player[i].skills.evasionSkills.fend = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.evasionSkills.isSideStep = br.ReadBoolean();
                    Global.player[i].skills.evasionSkills.sideStep = br.ReadInt32(Endian.Little);

                    Global.player[i].skills.evasionSkills.isBreakTackle = br.ReadBoolean();
                    Global.player[i].skills.evasionSkills.breakTackle = br.ReadInt32(Endian.Little);

                    Global.player[i].nrlStats.isAppearances = br.ReadBoolean();
                    Global.player[i].nrlStats.appearances = br.ReadInt32(Endian.Little);

                    Global.player[i].nrlStats.isTriesScored = br.ReadBoolean();
                    Global.player[i].nrlStats.triesScored = br.ReadInt32(Endian.Little);

                    Global.player[i].nrlStats.isGoals = br.ReadBoolean();
                    Global.player[i].nrlStats.goals = br.ReadInt32(Endian.Little);

                    Global.player[i].nrlStats.isGoalsAttempted = br.ReadBoolean();
                    Global.player[i].nrlStats.goalsAttempted = br.ReadInt32(Endian.Little);

                    Global.player[i].nrlStats.isPoints = br.ReadBoolean();
                    Global.player[i].nrlStats.points = br.ReadInt32(Endian.Little);

                    Global.player[i].slStats.isAppearances = br.ReadBoolean();
                    Global.player[i].slStats.appearances = br.ReadInt32(Endian.Little);

                    Global.player[i].slStats.isTriesScored = br.ReadBoolean();
                    Global.player[i].slStats.triesScored = br.ReadInt32(Endian.Little);

                    Global.player[i].slStats.isGoals = br.ReadBoolean();
                    Global.player[i].slStats.goals = br.ReadInt32(Endian.Little);

                    Global.player[i].slStats.isGoalsAttempted = br.ReadBoolean();
                    Global.player[i].slStats.goalsAttempted = br.ReadInt32(Endian.Little);

                    Global.player[i].slStats.isPoints = br.ReadBoolean();
                    Global.player[i].slStats.points = br.ReadInt32(Endian.Little);

                    Global.player[i].appearance.isPhotogrammetryStatus = br.ReadBoolean();
                    Global.player[i].appearance.photogrammetryStatus = 0;

                    if (Global.player[i].appearance.isPhotogrammetryStatus)
                        Global.player[i].appearance.photogrammetryStatus = br.ReadInt32(Endian.Little);

                    // Standard Stats
                    Global.player[i].isStandardStats = br.ReadBoolean();

                    if (Global.player[i].isStandardStats)
                    {
                        Global.player[i].standardStats.isMatchesPlayed = br.ReadBoolean();
                        Global.player[i].standardStats.matchesPlayed = 0;

                        if (Global.player[i].standardStats.isMatchesPlayed)
                            Global.player[i].standardStats.matchesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isMatchesWon = br.ReadBoolean();
                        Global.player[i].standardStats.matchesWon = 0;

                        if (Global.player[i].standardStats.isMatchesWon)
                            Global.player[i].standardStats.matchesWon = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isMatchesDrawn = br.ReadBoolean();
                        Global.player[i].standardStats.matchesDrawn = 0;

                        if (Global.player[i].standardStats.isMatchesDrawn)
                            Global.player[i].standardStats.matchesDrawn = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isBallStrips = br.ReadBoolean();

                        if (Global.player[i].standardStats.isBallStrips)
                            Global.player[i].standardStats.ballStrips = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isConversions = br.ReadBoolean();
                        Global.player[i].standardStats.conversions = 0;

                        if (Global.player[i].standardStats.isConversions)
                            Global.player[i].standardStats.conversions = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isConversionAttempts = br.ReadBoolean();
                        Global.player[i].standardStats.conversionAttempts = 0;

                        if (Global.player[i].standardStats.isConversionAttempts)
                            Global.player[i].standardStats.conversionAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isFends = br.ReadBoolean();
                        Global.player[i].standardStats.fends = 0;

                        if (Global.player[i].standardStats.isFends)
                            Global.player[i].standardStats.fends = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isFieldGoalAttempts = br.ReadBoolean();
                        Global.player[i].standardStats.fieldGoalAttempts = 0;

                        if (Global.player[i].standardStats.isFieldGoalAttempts)
                            Global.player[i].standardStats.fieldGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isFieldGoals = br.ReadBoolean();
                        Global.player[i].standardStats.fieldGoals = 0;

                        if (Global.player[i].standardStats.isFieldGoals)
                            Global.player[i].standardStats.fieldGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isFortyTwenties = br.ReadBoolean();
                        Global.player[i].standardStats.fortyTwenties = 0;

                        if (Global.player[i].standardStats.isFortyTwenties)
                            Global.player[i].standardStats.fortyTwenties = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isHandlingErrors = br.ReadBoolean();
                        Global.player[i].standardStats.handlingErrors = 0;

                        if (Global.player[i].standardStats.isHandlingErrors)
                            Global.player[i].standardStats.handlingErrors = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isHitups = br.ReadBoolean();
                        Global.player[i].standardStats.hitups = 0;

                        if (Global.player[i].standardStats.isHitups)
                            Global.player[i].standardStats.hitups = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isInterceptedPasses = br.ReadBoolean();
                        Global.player[i].standardStats.interceptedPasses = 0;

                        if (Global.player[i].standardStats.isInterceptedPasses)
                            Global.player[i].standardStats.interceptedPasses = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isInterceptions = br.ReadBoolean();
                        Global.player[i].standardStats.interceptions = 0;

                        if (Global.player[i].standardStats.isInterceptions)
                            Global.player[i].standardStats.interceptions = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isKickMetresGained = br.ReadBoolean();
                        Global.player[i].standardStats.kickMetresGained = 0;

                        if (Global.player[i].standardStats.isKickMetresGained)
                            Global.player[i].standardStats.kickMetresGained = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isKicksInPlay = br.ReadBoolean();
                        Global.player[i].standardStats.kicksInPlay = 0;

                        if (Global.player[i].standardStats.isKicksInPlay)
                            Global.player[i].standardStats.kicksInPlay = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isKnockOns = br.ReadBoolean();
                        Global.player[i].standardStats.knockOns = 0;

                        if (Global.player[i].standardStats.isKnockOns)
                            Global.player[i].standardStats.knockOns = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.islineBreakAssists = br.ReadBoolean();
                        Global.player[i].standardStats.lineBreakAssists = 0;

                        if (Global.player[i].standardStats.islineBreakAssists)
                            Global.player[i].standardStats.lineBreakAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isLineBreaks = br.ReadBoolean();
                        Global.player[i].standardStats.lineBreaks = 0;

                        if (Global.player[i].standardStats.isLineBreaks)
                            Global.player[i].standardStats.lineBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isMetresRun = br.ReadBoolean();
                        Global.player[i].standardStats.metresRun = 0;

                        if (Global.player[i].standardStats.isMetresRun)
                            Global.player[i].standardStats.metresRun = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isMinutesPlayed = br.ReadBoolean();
                        Global.player[i].standardStats.minutesPlayed = 0;

                        if (Global.player[i].standardStats.isMinutesPlayed)
                            Global.player[i].standardStats.minutesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isMissedTackles = br.ReadBoolean();
                        Global.player[i].standardStats.missedTackles = 0;

                        if (Global.player[i].standardStats.isMissedTackles)
                            Global.player[i].standardStats.missedTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isOffloads = br.ReadBoolean();
                        Global.player[i].standardStats.offloads = 0;

                        if (Global.player[i].standardStats.isOffloads)
                            Global.player[i].standardStats.offloads = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isOneOnOneTackles = br.ReadBoolean();
                        Global.player[i].standardStats.oneOnOneTackles = 0;

                        if (Global.player[i].standardStats.isOneOnOneTackles)
                            Global.player[i].standardStats.oneOnOneTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isPasses = br.ReadBoolean();
                        Global.player[i].standardStats.passes = 0;

                        if (Global.player[i].standardStats.isPasses)
                            Global.player[i].standardStats.passes = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isPenaltiesConceded = br.ReadBoolean();
                        Global.player[i].standardStats.penaltiesConceded = 0;

                        if (Global.player[i].standardStats.isPenaltiesConceded)
                            Global.player[i].standardStats.penaltiesConceded = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isPenaltyGoals = br.ReadBoolean();
                        Global.player[i].standardStats.penaltyGoals = 0;

                        if (Global.player[i].standardStats.isPenaltyGoals)
                            Global.player[i].standardStats.penaltyGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isPenaltyGoalAttempts = br.ReadBoolean();
                        Global.player[i].standardStats.penaltyGoalAttempts = 0;

                        if (Global.player[i].standardStats.isPenaltyGoalAttempts)
                            Global.player[i].standardStats.penaltyGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isRuns = br.ReadBoolean();
                        Global.player[i].standardStats.runs = 0;

                        if (Global.player[i].standardStats.isRuns)
                            Global.player[i].standardStats.runs = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isTackleBreaks = br.ReadBoolean();
                        Global.player[i].standardStats.tackleBreaks = 0;

                        if (Global.player[i].standardStats.isTackleBreaks)
                            Global.player[i].standardStats.tackleBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isTackles = br.ReadBoolean();

                        if (Global.player[i].standardStats.isTackles)
                            Global.player[i].standardStats.tackles = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isTries = br.ReadBoolean();
                        Global.player[i].standardStats.tries = 0;

                        if (Global.player[i].standardStats.isTries)
                            Global.player[i].standardStats.tries = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isTryAssists = br.ReadBoolean();
                        Global.player[i].standardStats.tryAssists = 0;

                        if (Global.player[i].standardStats.isTryAssists)
                            Global.player[i].standardStats.tryAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].standardStats.isBonusTries = br.ReadBoolean();
                        Global.player[i].standardStats.bonusTries = 0;

                        if (Global.player[i].standardStats.isBonusTries)
                            Global.player[i].standardStats.bonusTries = br.ReadInt32(Endian.Little);
                    }

                    // Nines Stats
                    Global.player[i].isNinesStats = br.ReadBoolean();

                    if (Global.player[i].isNinesStats)
                    {
                        Global.player[i].ninesStats.isMatchesPlayed = br.ReadBoolean();
                        Global.player[i].ninesStats.matchesPlayed = 0;

                        if (Global.player[i].ninesStats.isMatchesPlayed)
                            Global.player[i].ninesStats.matchesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isMatchesWon = br.ReadBoolean();
                        Global.player[i].ninesStats.matchesWon = 0;

                        if (Global.player[i].ninesStats.isMatchesWon)
                            Global.player[i].ninesStats.matchesWon = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isMatchesDrawn = br.ReadBoolean();
                        Global.player[i].ninesStats.matchesDrawn = 0;

                        if (Global.player[i].ninesStats.isMatchesDrawn)
                            Global.player[i].ninesStats.matchesDrawn = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isBallStrips = br.ReadBoolean();

                        if (Global.player[i].ninesStats.isBallStrips)
                            Global.player[i].ninesStats.ballStrips = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isConversions = br.ReadBoolean();
                        Global.player[i].ninesStats.conversions = 0;

                        if (Global.player[i].ninesStats.isConversions)
                            Global.player[i].ninesStats.conversions = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isConversionAttempts = br.ReadBoolean();
                        Global.player[i].ninesStats.conversionAttempts = 0;

                        if (Global.player[i].ninesStats.isConversionAttempts)
                            Global.player[i].ninesStats.conversionAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isFends = br.ReadBoolean();
                        Global.player[i].ninesStats.fends = 0;

                        if (Global.player[i].ninesStats.isFends)
                            Global.player[i].ninesStats.fends = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isFieldGoalAttempts = br.ReadBoolean();
                        Global.player[i].ninesStats.fieldGoalAttempts = 0;

                        if (Global.player[i].ninesStats.isFieldGoalAttempts)
                            Global.player[i].ninesStats.fieldGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isFieldGoals = br.ReadBoolean();
                        Global.player[i].ninesStats.fieldGoals = 0;

                        if (Global.player[i].ninesStats.isFieldGoals)
                            Global.player[i].ninesStats.fieldGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isFortyTwenties = br.ReadBoolean();
                        Global.player[i].ninesStats.fortyTwenties = 0;

                        if (Global.player[i].ninesStats.isFortyTwenties)
                            Global.player[i].ninesStats.fortyTwenties = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isHandlingErrors = br.ReadBoolean();
                        Global.player[i].ninesStats.handlingErrors = 0;

                        if (Global.player[i].ninesStats.isHandlingErrors)
                            Global.player[i].ninesStats.handlingErrors = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isHitups = br.ReadBoolean();
                        Global.player[i].ninesStats.hitups = 0;

                        if (Global.player[i].ninesStats.isHitups)
                            Global.player[i].ninesStats.hitups = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isInterceptedPasses = br.ReadBoolean();
                        Global.player[i].ninesStats.interceptedPasses = 0;

                        if (Global.player[i].ninesStats.isInterceptedPasses)
                            Global.player[i].ninesStats.interceptedPasses = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isInterceptions = br.ReadBoolean();
                        Global.player[i].ninesStats.interceptions = 0;

                        if (Global.player[i].ninesStats.isInterceptions)
                            Global.player[i].ninesStats.interceptions = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isKickMetresGained = br.ReadBoolean();
                        Global.player[i].ninesStats.kickMetresGained = 0;

                        if (Global.player[i].ninesStats.isKickMetresGained)
                            Global.player[i].ninesStats.kickMetresGained = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isKicksInPlay = br.ReadBoolean();
                        Global.player[i].ninesStats.kicksInPlay = 0;

                        if (Global.player[i].ninesStats.isKicksInPlay)
                            Global.player[i].ninesStats.kicksInPlay = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isKnockOns = br.ReadBoolean();
                        Global.player[i].ninesStats.knockOns = 0;

                        if (Global.player[i].ninesStats.isKnockOns)
                            Global.player[i].ninesStats.knockOns = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.islineBreakAssists = br.ReadBoolean();
                        Global.player[i].ninesStats.lineBreakAssists = 0;

                        if (Global.player[i].ninesStats.islineBreakAssists)
                            Global.player[i].ninesStats.lineBreakAssists = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isLineBreaks = br.ReadBoolean();
                        Global.player[i].ninesStats.lineBreaks = 0;

                        if (Global.player[i].ninesStats.isLineBreaks)
                            Global.player[i].ninesStats.lineBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isMetresRun = br.ReadBoolean();
                        Global.player[i].ninesStats.metresRun = 0;

                        if (Global.player[i].ninesStats.isMetresRun)
                            Global.player[i].ninesStats.metresRun = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isMinutesPlayed = br.ReadBoolean();
                        Global.player[i].ninesStats.minutesPlayed = 0;

                        if (Global.player[i].ninesStats.isMinutesPlayed)
                            Global.player[i].ninesStats.minutesPlayed = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isMissedTackles = br.ReadBoolean();
                        Global.player[i].ninesStats.missedTackles = 0;

                        if (Global.player[i].ninesStats.isMissedTackles)
                            Global.player[i].ninesStats.missedTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isOffloads = br.ReadBoolean();
                        Global.player[i].ninesStats.offloads = 0;

                        if (Global.player[i].ninesStats.isOffloads)
                            Global.player[i].ninesStats.offloads = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isOneOnOneTackles = br.ReadBoolean();
                        Global.player[i].ninesStats.oneOnOneTackles = 0;

                        if (Global.player[i].ninesStats.isOneOnOneTackles)
                            Global.player[i].ninesStats.oneOnOneTackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isPasses = br.ReadBoolean();
                        Global.player[i].ninesStats.passes = 0;

                        if (Global.player[i].ninesStats.isPasses)
                            Global.player[i].ninesStats.passes = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isPenaltiesConceded = br.ReadBoolean();
                        Global.player[i].ninesStats.penaltiesConceded = 0;

                        if (Global.player[i].ninesStats.isPenaltiesConceded)
                            Global.player[i].ninesStats.penaltiesConceded = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isPenaltyGoals = br.ReadBoolean();
                        Global.player[i].ninesStats.penaltyGoals = 0;

                        if (Global.player[i].ninesStats.isPenaltyGoals)
                            Global.player[i].ninesStats.penaltyGoals = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isPenaltyGoalAttempts = br.ReadBoolean();
                        Global.player[i].ninesStats.penaltyGoalAttempts = 0;

                        if (Global.player[i].ninesStats.isPenaltyGoalAttempts)
                            Global.player[i].ninesStats.penaltyGoalAttempts = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isRuns = br.ReadBoolean();
                        Global.player[i].ninesStats.runs = 0;

                        if (Global.player[i].ninesStats.isRuns)
                            Global.player[i].ninesStats.runs = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isTackleBreaks = br.ReadBoolean();
                        Global.player[i].ninesStats.tackleBreaks = 0;

                        if (Global.player[i].ninesStats.isTackleBreaks)
                            Global.player[i].ninesStats.tackleBreaks = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isTackles = br.ReadBoolean();

                        if (Global.player[i].ninesStats.isTackles)
                            Global.player[i].ninesStats.tackles = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isTries = br.ReadBoolean();
                        Global.player[i].ninesStats.tries = 0;

                        if (Global.player[i].ninesStats.isTries)
                            Global.player[i].ninesStats.tries = br.ReadInt32(Endian.Little);

                        Global.player[i].ninesStats.isTryAssists = br.ReadBoolean();
                        Global.player[i].ninesStats.tryAssists = 0;

                        if (Global.player[i].ninesStats.isTryAssists)
                            Global.player[i].ninesStats.tryAssists = br.ReadInt32(Endian.Little);
                    }

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
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
    }
}
