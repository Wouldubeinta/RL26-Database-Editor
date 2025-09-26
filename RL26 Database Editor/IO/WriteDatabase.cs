using PackageIO;

namespace RL26_Database_Editor
{
    internal class WriteDatabase
    {
        public static void WriteTeamData(string file)
        {
            Writer? bw = null;

            try
            {
                bw = new Writer(file, FileMode.Create, Endian.Little);

                bw.Write(Global.TeamHeader, Endian.Little);
                bw.WriteInt32(Global.team_amount, Endian.Little);

                for (int i = 0; i < Global.team_amount; i++)
                {
                    bw.WriteInt32(Global.team[i].identifier, Endian.Little);
                    bw.WriteBool(Global.team[i].isTeamEnabled);
                    bw.WriteBool(Global.team[i].isId);
                    bw.WriteInt32(Global.team[i].id, Endian.Little);

                    // FullName
                    bw.WriteBool(Global.team[i].isFullName);
                    bw.WriteUInt8(Global.team[i].fullNameSize);
                    bw.WriteString(Global.team[i].fullName, Global.team[i].fullNameSize, Endian.Little);

                    // LocationName
                    bw.WriteBool(Global.team[i].isLocationName);
                    bw.WriteUInt8(Global.team[i].locationNameSize);
                    bw.WriteString(Global.team[i].locationName, Global.team[i].locationNameSize, Endian.Little);

                    // ClubName
                    bw.WriteBool(Global.team[i].isClubName);
                    bw.WriteUInt8(Global.team[i].clubNameSize);
                    bw.WriteString(Global.team[i].clubName, Global.team[i].clubNameSize);

                    // AbbreviatedName
                    bw.WriteBool(Global.team[i].isAbbreviatedName);
                    bw.WriteUInt8(Global.team[i].abbreviatedNameSize);
                    bw.WriteString(Global.team[i].abbreviatedName, Global.team[i].abbreviatedNameSize, Endian.Little);

                    bw.WriteBool(Global.team[i].isFrontendVisible);

                    if (Global.team[i].isFrontendVisible)
                        bw.WriteBool(Global.team[i].frontendVisible);

                    bw.WriteBool(Global.team[i].isJerseyName); // ?

                    // Gender
                    bw.WriteBool(Global.team[i].isGender);
                    bw.WriteInt32(Global.team[i].gender, Endian.Little);

                    // Logo
                    bw.WriteBool(Global.team[i].islogo);
                    bw.WriteUInt8(Global.team[i].logoSize);
                    bw.WriteString(Global.team[i].logo, Global.team[i].logoSize, Endian.Little);

                    // WC Logo
                    bw.WriteBool(Global.team[i].isWcLogo);

                    if (Global.team[i].isWcLogo)
                    {
                        bw.WriteUInt8(Global.team[i].wcLogoSize);
                        bw.WriteString(Global.team[i].wcLogo, Global.team[i].logoSize, Endian.Little);
                    }

                    // Supporters
                    bw.WriteBool(Global.team[i].isSupporters);
                    bw.WriteInt32(Global.team[i].supporters, Endian.Little);

                    // Commentary
                    bw.WriteBool(Global.team[i].isCommentaryTeamLocationHash);
                    bw.WriteUInt32(Global.team[i].commentaryTeamLocationHash, Endian.Little);

                    bw.WriteBool(Global.team[i].isCommentaryTeamMascotHash);
                    bw.WriteUInt32(Global.team[i].commentaryTeamMascotHash, Endian.Little);

                    // PrimaryColour
                    bw.WriteBool(Global.team[i].primaryColour.isRgb);
                    bw.WriteUInt8(Global.team[i].primaryColour.r);
                    bw.WriteUInt8(Global.team[i].primaryColour.g);
                    bw.WriteUInt8(Global.team[i].primaryColour.b);

                    // SecondaryColour
                    bw.WriteBool(Global.team[i].secondaryColour.isRgb);
                    bw.WriteUInt8(Global.team[i].secondaryColour.r);
                    bw.WriteUInt8(Global.team[i].secondaryColour.g);
                    bw.WriteUInt8(Global.team[i].secondaryColour.b);

                    // HudTextColour
                    bw.WriteBool(Global.team[i].hudTextColour.isRgb);
                    bw.WriteUInt8(Global.team[i].hudTextColour.r);
                    bw.WriteUInt8(Global.team[i].hudTextColour.g);
                    bw.WriteUInt8(Global.team[i].hudTextColour.b);

                    bw.WriteBool(Global.team[i].isClubType);

                    if (Global.team[i].isClubType)
                        bw.WriteInt32(Global.team[i].clubType, Endian.Little);

                    bw.WriteBool(Global.team[i].isAffiliations);

                    if (Global.team[i].isAffiliations)
                        bw.WriteInt32(Global.team[i].affiliations, Endian.Little);

                    bw.WriteBool(Global.team[i].isWorldCupTeam);

                    if (Global.team[i].isWorldCupTeam)
                        bw.WriteBool(Global.team[i].WorldCupTeam);

                    bw.WriteBool(Global.team[i].isStadiumAmount);
                    bw.WriteInt32(Global.team[i].stadiumAmount, Endian.Little);

                    for (int j = 0; j < 3; j++)
                    {
                        bw.WriteBool(Global.team[i].stadium[j].isId);

                        if (Global.team[i].stadium[j].isId)
                            bw.WriteInt32(Global.team[i].stadium[j].id, Endian.Little);

                        bw.WriteBool(Global.team[i].stadium[j].isWantCustomName);

                        if (Global.team[i].stadium[j].isWantCustomName)
                            bw.WriteBool(Global.team[i].stadium[j].wantCustomName);

                        bw.WriteBool(Global.team[i].stadium[j].isCustomName);

                        if (Global.team[i].stadium[j].isCustomName)
                        {
                            bw.WriteUInt8(Global.team[i].stadium[j].customNameSize);
                            bw.WriteString(Global.team[i].stadium[j].customName, Global.team[i].stadium[j].customNameSize, Endian.Little);
                        }

                        bw.WriteBool(Global.team[i].stadium[j].isStadiumIsOnDisk);

                        if (Global.team[i].stadium[j].isStadiumIsOnDisk)
                            bw.WriteBool(Global.team[i].stadium[j].StadiumIsOnDisk);
                    }

                    bw.WriteBool(Global.team[i].finalStadium.isId);

                    if (Global.team[i].finalStadium.isId)
                        bw.WriteInt32(Global.team[i].finalStadium.id, Endian.Little);

                    bw.WriteBool(Global.team[i].finalStadium.isWantCustomName);

                    if (Global.team[i].finalStadium.isWantCustomName)
                        bw.WriteBool(Global.team[i].finalStadium.wantCustomName);

                    bw.WriteBool(Global.team[i].finalStadium.isCustomName);

                    if (Global.team[i].finalStadium.isCustomName)
                    {
                        bw.WriteUInt8(Global.team[i].finalStadium.customNameSize);
                        bw.WriteString(Global.team[i].finalStadium.customName, Global.team[i].finalStadium.customNameSize, Endian.Little);
                    }

                    for (int j = 0; j < 7; j++)
                    {
                        bw.WriteBool(Global.team[i].feederClubs[j].isFeederClubs);

                        if (Global.team[i].feederClubs[j].isFeederClubs)
                            bw.WriteInt32(Global.team[i].feederClubs[j].feederClubsId, Endian.Little);
                    }

                    for (int j = 0; j < 7; j++)
                    {
                        bw.WriteBool(Global.team[i].fedFromClubs[j].isFedFromClubs);

                        if (Global.team[i].fedFromClubs[j].isFedFromClubs)
                            bw.WriteInt32(Global.team[i].fedFromClubs[j].fedFromClubsId, Endian.Little);
                    }

                    bw.WriteBool(Global.team[i].isAlternateNumbering);

                    if (Global.team[i].isAlternateNumbering)
                        bw.WriteBool(Global.team[i].alternateNumbering);

                    bw.WriteBool(Global.team[i].isAlternativeNumberingSystem);

                    if (Global.team[i].isAlternativeNumberingSystem)
                        bw.WriteInt32(Global.team[i].alternateNumberingSystem, Endian.Little);

                    bw.WriteBool(Global.team[i].isPlayerRoster);

                    for (int j = 0; j < Global.MAX_PLAYERS_PER_TEAM; j++)
                    {
                        bw.WriteBool(Global.team[i].players[j].isPlayerId);

                        if (Global.team[i].players[j].isPlayerId)
                            bw.WriteInt32(Global.team[i].players[j].playerId, Endian.Little);
                    }

                    bw.WriteBool(Global.team[i].isStandardMatch);

                    for (int j = 0; j < 4; j++)
                    {
                        bw.WriteBool(Global.team[i].roles[j].isRoleId);

                        if (Global.team[i].roles[j].isRoleId)
                            bw.WriteInt32(Global.team[i].roles[j].roleId, Endian.Little);
                    }

                    for (int j = 0; j < Global.MIN_PLAYERS_PER_TEAM; j++)
                    {
                        bw.WriteBool(Global.team[i].lineups[j].isLineupId);

                        if (Global.team[i].lineups[j].isLineupId)
                        {
                            bw.WriteInt32(Global.team[i].lineups[j].lineupId, Endian.Little);
                            bw.WriteUInt8(Global.team[i].lineups[j].posNumber);
                        }

                    }

                    bw.WriteBool(Global.team[i].isNines);

                    for (int j = 0; j < 4; j++)
                    {
                        bw.WriteBool(Global.team[i].nineRoles[j].isNinesRoleId);

                        if (Global.team[i].nineRoles[j].isNinesRoleId)
                            bw.WriteInt32(Global.team[i].nineRoles[j].nineRoleId, Endian.Little);
                    }

                    for (int j = 0; j < 14; j++)
                    {
                        bw.WriteBool(Global.team[i].nineLineups[j].isNineLineupId);

                        if (Global.team[i].nineLineups[j].isNineLineupId)
                        {
                            bw.WriteInt32(Global.team[i].nineLineups[j].nineLineupId, Endian.Little);
                        }
                    }

                    bw.WriteInt32(Global.team[i].dataSize, Endian.Little);
                    bw.Write(Global.team[i].data, Endian.Little);

                    /*
                    bw.WriteInt16(Global.team[i].jerseyAmount);

                    for (int j = 0; j < 8; j++)
                    {
                        bw.Write((Global.team[i].jerseys[j].name + new string(default(char), 24)).Take(24).Select(ch => (byte)ch).ToArray(), Endian.Little);
                        bw.WriteUInt8(0);

                        bw.WriteUInt16(Global.team[i].jerseys[j].padding1, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding2, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding3, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding4, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding5, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showNumber);
                        bw.WriteUInt16(Global.team[i].jerseys[j].padding6, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding7, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showInternalKeyline);
                        bw.Write(Global.team[i].jerseys[j].padding8, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.g);
                        bw.Write(Global.team[i].jerseys[j].padding9, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.b);
                        bw.Write(Global.team[i].jerseys[j].padding10, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].manufactureId);
                        bw.Write(Global.team[i].jerseys[j].padding11, Endian.Little);
                        bw.WriteInt16(Global.team[i].jerseys[j].licensedId, Endian.Little);
                        bw.Write(Global.team[i].jerseys[j].padding12, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineSize);
                        bw.Write(Global.team[i].jerseys[j].padding13, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberFont);
                        bw.Write(Global.team[i].jerseys[j].padding14, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].nameFont);
                        bw.Write(Global.team[i].jerseys[j].padding15, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineOffset);
                        bw.WriteBool(Global.team[i].jerseys[j].showingLeadingZero);
                        bw.Write(Global.team[i].jerseys[j].padding16, Endian.Little);
                        bw.WriteBool(Global.team[i].jerseys[j].showName);
                        bw.Write(Global.team[i].jerseys[j].padding17, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].keylineColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding18, Endian.Little);
                        bw.WriteUInt8(Global.team[i].jerseys[j].numberColour.r);
                        bw.Write(Global.team[i].jerseys[j].padding19, Endian.Little);
                    }

                    bw.Write(Global.team[i].padding2, Endian.Little);
                    */
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }

        public static void WritePlayerData(string file)
        {
            Writer? bw = null;

            try
            {
                bw = new Writer(file, FileMode.Create, Endian.Little);

                bw.Write(Global.PlayerHeader, Endian.Little);
                bw.WriteInt32(Global.player_amount); // player_amount

                for (int i = 0; i < Global.player_amount; i++)
                {
                    bw.WriteInt32(Global.player[i].identifier, Endian.Little);
                    bw.WriteInt32(Global.player[i].dataSize, Endian.Little);

                    bw.Write(Global.player[i].data, Endian.Little);

                    bw.WriteBool(Global.player[i].isPlayerEnabled);
                    bw.WriteBool(Global.player[i].isId);
                    bw.WriteInt32(Global.player[i].id, Endian.Little);

                    bw.WriteBool(Global.player[i].isFirstName);
                    bw.WriteUInt8(Global.player[i].firstNameSize);
                    bw.WriteString(Global.player[i].firstName, Global.player[i].firstNameSize, Endian.Little);

                    bw.WriteBool(Global.player[i].isLastName);
                    bw.WriteUInt8(Global.player[i].lastNameSize);
                    bw.WriteString(Global.player[i].lastName, Global.player[i].lastNameSize, Endian.Little);

                    bw.WriteBool(Global.player[i].isLicensed);

                    if (Global.player[i].isLicensed)
                        bw.WriteBool(Global.player[i].licensed);

                    bw.WriteBool(Global.player[i].isHidden);

                    if (Global.player[i].isHidden)
                        bw.WriteBool(Global.player[i].hidden);

                    bw.WriteBool(Global.player[i].isClub);

                    if (Global.player[i].isClub)
                        bw.WriteInt32(Global.player[i].club, Endian.Little);

                    bw.WriteBool(Global.player[i].isGender);

                    if (Global.player[i].isGender)
                        bw.WriteInt32(Global.player[i].gender, Endian.Little);

                    bw.WriteBool(Global.player[i].isJerseyName);
                    bw.WriteUInt8(Global.player[i].jerseyNameSize);
                    bw.WriteString(Global.player[i].jerseyName, Global.player[i].jerseyNameSize, Endian.Little);

                    bw.WriteBool(Global.player[i].isJerseyNumber);

                    if (Global.player[i].isJerseyNumber)
                        bw.WriteInt32(Global.player[i].jerseyNumber, Endian.Little);

                    bw.WriteBool(Global.player[i].dob.isDay);
                    bw.WriteInt32(Global.player[i].dob.day, Endian.Little);
                    bw.WriteBool(Global.player[i].dob.isMonth);
                    bw.WriteInt32(Global.player[i].dob.month, Endian.Little);
                    bw.WriteBool(Global.player[i].dob.isYear);
                    bw.WriteInt32(Global.player[i].dob.year, Endian.Little);

                    bw.WriteBool(Global.player[i].isAge);

                    if (Global.player[i].isAge)
                        bw.WriteInt32(Global.player[i].age, Endian.Little);

                    bw.WriteBool(Global.player[i].isCountryOfBirth);

                    if (Global.player[i].isCountryOfBirth)
                        bw.WriteInt32(Global.player[i].countryOfBirth, Endian.Little);

                    bw.WriteBool(Global.player[i].isRepCountry);

                    if (Global.player[i].isRepCountry)
                        bw.WriteInt32(Global.player[i].repCountry, Endian.Little);

                    bw.WriteBool(Global.player[i].isStateOfOrigin);

                    if (Global.player[i].isStateOfOrigin)
                        bw.WriteInt32(Global.player[i].stateOfOrigin, Endian.Little);

                    bw.WriteBool(Global.player[i].isOriginRepNumber);

                    if (Global.player[i].isOriginRepNumber)
                        bw.WriteInt32(Global.player[i].originRepNumber, Endian.Little);

                    bw.WriteBool(Global.player[i].isOriginOtherNumber);

                    if (Global.player[i].isOriginOtherNumber)
                        bw.WriteInt32(Global.player[i].originOtherNumber, Endian.Little);

                    bw.WriteBool(Global.player[i].isCityVsCountry);

                    if (Global.player[i].isCityVsCountry)
                        bw.WriteInt32(Global.player[i].cityVsCountry, Endian.Little);

                    bw.WriteBool(Global.player[i].isAllStars);

                    if (Global.player[i].isAllStars)
                        bw.WriteInt32(Global.player[i].allStars, Endian.Little);

                    bw.WriteBool(Global.player[i].isWorldCup);

                    if (Global.player[i].isWorldCup)
                        bw.WriteBool(Global.player[i].WorldCup);

                    bw.WriteBool(Global.player[i].isContractExpiry);

                    if (Global.player[i].isContractExpiry)
                        bw.WriteInt32(Global.player[i].contractExpiry, Endian.Little);

                    bw.WriteBool(Global.player[i].isPrimaryRole);

                    if (Global.player[i].isPrimaryRole)
                        bw.WriteInt32(Global.player[i].primaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isSecondaryRole);

                    if (Global.player[i].isSecondaryRole)
                        bw.WriteInt32(Global.player[i].secondaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isTertiaryRole);

                    if (Global.player[i].isTertiaryRole)
                        bw.WriteInt32(Global.player[i].tertiaryRole, Endian.Little);

                    bw.WriteBool(Global.player[i].isCommentaryNameHash);

                    if (Global.player[i].isCommentaryNameHash)
                        bw.WriteUInt32(Global.player[i].commentaryNameHash, Endian.Little);

                    bw.WriteBool(Global.player[i].isPreferredHand);

                    if (Global.player[i].isPreferredHand)
                        bw.WriteUInt8(Global.player[i].preferredHand);

                    bw.WriteBool(Global.player[i].isPreferredFoot);

                    if (Global.player[i].isPreferredFoot)
                        bw.WriteUInt8(Global.player[i].preferredFoot);

                    bw.WriteBool(Global.player[i].appearance.isHeight);
                    bw.WriteInt32(Global.player[i].appearance.height, Endian.Little);
                    bw.WriteBool(Global.player[i].appearance.isWeight);
                    bw.WriteInt32(Global.player[i].appearance.weight, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isReputation);

                    if (Global.player[i].attributes.isReputation)
                        bw.WriteInt32(Global.player[i].attributes.reputation, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isEgo);

                    if (Global.player[i].attributes.isEgo)
                        bw.WriteInt32(Global.player[i].attributes.ego, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isLoyalty);

                    if (Global.player[i].attributes.isLoyalty)
                        bw.WriteInt32(Global.player[i].attributes.loyalty, Endian.Little);

                    bw.WriteBool(Global.player[i].attributes.isPerk);

                    if (Global.player[i].attributes.isPerk)
                        bw.WriteInt32(Global.player[i].attributes.perk, Endian.Little);

                    bw.WriteBool(Global.player[i].appearance.isHeadVisual);

                    if (Global.player[i].appearance.isHeadVisual)
                        bw.WriteInt32(Global.player[i].appearance.headVisual, Endian.Little);

                    bw.WriteBool(Global.player[i].appearance.isHairTopVisual);

                    if (Global.player[i].appearance.isHairTopVisual)
                        bw.WriteInt32(Global.player[i].appearance.hairTopVisual, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isStrength);
                    bw.WriteInt32(Global.player[i].technicalAbility.strength, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isDurability);
                    bw.WriteInt32(Global.player[i].technicalAbility.durability, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isDiscipline);
                    bw.WriteInt32(Global.player[i].technicalAbility.discipline, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.tackleSkills.isTackle);
                    bw.WriteInt32(Global.player[i].skills.tackleSkills.tackle, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.tackleSkills.isDriveTackle);
                    bw.WriteInt32(Global.player[i].skills.tackleSkills.driveTackle, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.tackleSkills.isDiveTackle);
                    bw.WriteInt32(Global.player[i].skills.tackleSkills.diveTackle, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.tackleSkills.isImpactTackle);
                    bw.WriteInt32(Global.player[i].skills.tackleSkills.impactTackle, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isAgility);
                    bw.WriteInt32(Global.player[i].technicalAbility.agility, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isFitness);
                    bw.WriteInt32(Global.player[i].technicalAbility.fitness, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isAcceleration);
                    bw.WriteInt32(Global.player[i].technicalAbility.acceleration, Endian.Little);

                    bw.WriteBool(Global.player[i].technicalAbility.isSprintSpeed);
                    bw.WriteInt32(Global.player[i].technicalAbility.sprintSpeed, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isGrubberKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.grubberKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isPuntKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.puntKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isChipKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.chipKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isBombKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.bombKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isFieldgoalKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.fieldgoalKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.kickingSkills.isPlaceKick);
                    bw.WriteInt32(Global.player[i].skills.kickingSkills.placeKick, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.passingSkills.isBasicPass);
                    bw.WriteInt32(Global.player[i].skills.passingSkills.basicPass, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.passingSkills.islongPass);
                    bw.WriteInt32(Global.player[i].skills.passingSkills.longPass, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.passingSkills.isOffload);
                    bw.WriteInt32(Global.player[i].skills.passingSkills.offload, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.miscSkills.isContestedCollect);
                    bw.WriteInt32(Global.player[i].skills.miscSkills.contestedCollect, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.miscSkills.isDiveCollect);
                    bw.WriteInt32(Global.player[i].skills.miscSkills.diveCollect, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.miscSkills.isBallStrip);
                    bw.WriteInt32(Global.player[i].skills.miscSkills.ballStrip, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.evasionSkills.isDummyPass);
                    bw.WriteInt32(Global.player[i].skills.evasionSkills.dummyPass, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.evasionSkills.isFend);
                    bw.WriteInt32(Global.player[i].skills.evasionSkills.fend, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.evasionSkills.isSideStep);
                    bw.WriteInt32(Global.player[i].skills.evasionSkills.sideStep, Endian.Little);

                    bw.WriteBool(Global.player[i].skills.evasionSkills.isBreakTackle);
                    bw.WriteInt32(Global.player[i].skills.evasionSkills.breakTackle, Endian.Little);

                    bw.WriteBool(Global.player[i].nrlStats.isAppearances);
                    bw.WriteInt32(Global.player[i].nrlStats.appearances, Endian.Little);

                    bw.WriteBool(Global.player[i].nrlStats.isTriesScored);
                    bw.WriteInt32(Global.player[i].nrlStats.triesScored, Endian.Little);

                    bw.WriteBool(Global.player[i].nrlStats.isGoals);
                    bw.WriteInt32(Global.player[i].nrlStats.goals, Endian.Little);

                    bw.WriteBool(Global.player[i].nrlStats.isGoalsAttempted);
                    bw.WriteInt32(Global.player[i].nrlStats.goalsAttempted, Endian.Little);

                    bw.WriteBool(Global.player[i].nrlStats.isPoints);
                    bw.WriteInt32(Global.player[i].nrlStats.points, Endian.Little);

                    bw.WriteBool(Global.player[i].slStats.isAppearances);
                    bw.WriteInt32(Global.player[i].slStats.appearances, Endian.Little);

                    bw.WriteBool(Global.player[i].slStats.isTriesScored);
                    bw.WriteInt32(Global.player[i].slStats.triesScored, Endian.Little);

                    bw.WriteBool(Global.player[i].slStats.isGoals);
                    bw.WriteInt32(Global.player[i].slStats.goals, Endian.Little);

                    bw.WriteBool(Global.player[i].slStats.isGoalsAttempted);
                    bw.WriteInt32(Global.player[i].slStats.goalsAttempted, Endian.Little);

                    bw.WriteBool(Global.player[i].slStats.isPoints);
                    bw.WriteInt32(Global.player[i].slStats.points, Endian.Little);

                    bw.WriteBool(Global.player[i].appearance.isPhotogrammetryStatus);

                    if (Global.player[i].appearance.isPhotogrammetryStatus)
                        bw.WriteInt32(Global.player[i].appearance.photogrammetryStatus, Endian.Little);

                    bw.WriteBool(Global.player[i].isStandardStats);

                    if (Global.player[i].isStandardStats)
                    {
                        bw.WriteBool(Global.player[i].standardStats.isMatchesPlayed);

                        if (Global.player[i].standardStats.isMatchesPlayed)
                            bw.WriteInt32(Global.player[i].standardStats.matchesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isMatchesWon);

                        if (Global.player[i].standardStats.isMatchesWon)
                            bw.WriteInt32(Global.player[i].standardStats.matchesWon, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isMatchesDrawn);

                        if (Global.player[i].standardStats.isMatchesDrawn)
                            bw.WriteInt32(Global.player[i].standardStats.matchesDrawn, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isBallStrips);

                        if (Global.player[i].standardStats.isBallStrips)
                            bw.WriteInt32(Global.player[i].standardStats.ballStrips, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isConversions);

                        if (Global.player[i].standardStats.isConversions)
                            bw.WriteInt32(Global.player[i].standardStats.conversions, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isConversionAttempts);

                        if (Global.player[i].standardStats.isConversionAttempts)
                            bw.WriteInt32(Global.player[i].standardStats.conversionAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isFends);

                        if (Global.player[i].standardStats.isFends)
                            bw.WriteInt32(Global.player[i].standardStats.fends, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isFieldGoalAttempts);

                        if (Global.player[i].standardStats.isFieldGoalAttempts)
                            bw.WriteInt32(Global.player[i].standardStats.fieldGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isFieldGoals);

                        if (Global.player[i].standardStats.isFieldGoals)
                            bw.WriteInt32(Global.player[i].standardStats.fieldGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isFortyTwenties);

                        if (Global.player[i].standardStats.isFortyTwenties)
                            bw.WriteInt32(Global.player[i].standardStats.fortyTwenties, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isHandlingErrors);

                        if (Global.player[i].standardStats.isHandlingErrors)
                            bw.WriteInt32(Global.player[i].standardStats.handlingErrors, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isHitups);

                        if (Global.player[i].standardStats.isHitups)
                            bw.WriteInt32(Global.player[i].standardStats.hitups, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isInterceptedPasses);

                        if (Global.player[i].standardStats.isInterceptedPasses)
                            bw.WriteInt32(Global.player[i].standardStats.interceptedPasses, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isInterceptions);

                        if (Global.player[i].standardStats.isInterceptions)
                            bw.WriteInt32(Global.player[i].standardStats.interceptions, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isKickMetresGained);

                        if (Global.player[i].standardStats.isKickMetresGained)
                            bw.WriteInt32(Global.player[i].standardStats.kickMetresGained, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isKicksInPlay);

                        if (Global.player[i].standardStats.isKicksInPlay)
                            bw.WriteInt32(Global.player[i].standardStats.kicksInPlay, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isKnockOns);

                        if (Global.player[i].standardStats.isKnockOns)
                            bw.WriteInt32(Global.player[i].standardStats.knockOns, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.islineBreakAssists);

                        if (Global.player[i].standardStats.islineBreakAssists)
                            bw.WriteInt32(Global.player[i].standardStats.lineBreakAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isLineBreaks);

                        if (Global.player[i].standardStats.isLineBreaks)
                            bw.WriteInt32(Global.player[i].standardStats.lineBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isMetresRun);

                        if (Global.player[i].standardStats.isMetresRun)
                            bw.WriteInt32(Global.player[i].standardStats.metresRun, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isMinutesPlayed);

                        if (Global.player[i].standardStats.isMinutesPlayed)
                            bw.WriteInt32(Global.player[i].standardStats.minutesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isMissedTackles);

                        if (Global.player[i].standardStats.isMissedTackles)
                            bw.WriteInt32(Global.player[i].standardStats.missedTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isOffloads);

                        if (Global.player[i].standardStats.isOffloads)
                            bw.WriteInt32(Global.player[i].standardStats.offloads, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isOneOnOneTackles);

                        if (Global.player[i].standardStats.isOneOnOneTackles)
                            bw.WriteInt32(Global.player[i].standardStats.oneOnOneTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isPasses);

                        if (Global.player[i].standardStats.isPasses)
                            bw.WriteInt32(Global.player[i].standardStats.passes, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isPenaltiesConceded);

                        if (Global.player[i].standardStats.isPenaltiesConceded)
                            bw.WriteInt32(Global.player[i].standardStats.penaltiesConceded, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isPenaltyGoals);

                        if (Global.player[i].standardStats.isPenaltyGoals)
                            bw.WriteInt32(Global.player[i].standardStats.penaltyGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isPenaltyGoalAttempts);

                        if (Global.player[i].standardStats.isPenaltyGoalAttempts)
                            bw.WriteInt32(Global.player[i].standardStats.penaltyGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isRuns);

                        if (Global.player[i].standardStats.isRuns)
                            bw.WriteInt32(Global.player[i].standardStats.runs, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isTackleBreaks);

                        if (Global.player[i].standardStats.isTackleBreaks)
                            bw.WriteInt32(Global.player[i].standardStats.tackleBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isTackles);

                        if (Global.player[i].standardStats.isTackles)
                            bw.WriteInt32(Global.player[i].standardStats.tackles, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isTries);

                        if (Global.player[i].standardStats.isTries)
                            bw.WriteInt32(Global.player[i].standardStats.tries, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isTryAssists);

                        if (Global.player[i].standardStats.isTryAssists)
                            bw.WriteInt32(Global.player[i].standardStats.tryAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].standardStats.isBonusTries);

                        if (Global.player[i].standardStats.isBonusTries)
                            bw.WriteInt32(Global.player[i].standardStats.bonusTries, Endian.Little);
                    }

                    bw.WriteBool(Global.player[i].isNinesStats);

                    if (Global.player[i].isNinesStats)
                    {
                        bw.WriteBool(Global.player[i].ninesStats.isMatchesPlayed);

                        if (Global.player[i].ninesStats.isMatchesPlayed)
                            bw.WriteInt32(Global.player[i].ninesStats.matchesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isMatchesWon);

                        if (Global.player[i].ninesStats.isMatchesWon)
                            bw.WriteInt32(Global.player[i].ninesStats.matchesWon, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isMatchesDrawn);

                        if (Global.player[i].ninesStats.isMatchesDrawn)
                            bw.WriteInt32(Global.player[i].ninesStats.matchesDrawn, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isBallStrips);

                        if (Global.player[i].ninesStats.isBallStrips)
                            bw.WriteInt32(Global.player[i].ninesStats.ballStrips, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isConversions);

                        if (Global.player[i].ninesStats.isConversions)
                            bw.WriteInt32(Global.player[i].ninesStats.conversions, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isConversionAttempts);

                        if (Global.player[i].ninesStats.isConversionAttempts)
                            bw.WriteInt32(Global.player[i].ninesStats.conversionAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isFends);

                        if (Global.player[i].ninesStats.isFends)
                            bw.WriteInt32(Global.player[i].ninesStats.fends, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isFieldGoalAttempts);

                        if (Global.player[i].ninesStats.isFieldGoalAttempts)
                            bw.WriteInt32(Global.player[i].ninesStats.fieldGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isFieldGoals);

                        if (Global.player[i].ninesStats.isFieldGoals)
                            bw.WriteInt32(Global.player[i].ninesStats.fieldGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isFortyTwenties);

                        if (Global.player[i].ninesStats.isFortyTwenties)
                            bw.WriteInt32(Global.player[i].ninesStats.fortyTwenties, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isHandlingErrors);

                        if (Global.player[i].ninesStats.isHandlingErrors)
                            bw.WriteInt32(Global.player[i].ninesStats.handlingErrors, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isHitups);

                        if (Global.player[i].ninesStats.isHitups)
                            bw.WriteInt32(Global.player[i].ninesStats.hitups, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isInterceptedPasses);

                        if (Global.player[i].ninesStats.isInterceptedPasses)
                            bw.WriteInt32(Global.player[i].ninesStats.interceptedPasses, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isInterceptions);

                        if (Global.player[i].ninesStats.isInterceptions)
                            bw.WriteInt32(Global.player[i].ninesStats.interceptions, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isKickMetresGained);

                        if (Global.player[i].ninesStats.isKickMetresGained)
                            bw.WriteInt32(Global.player[i].ninesStats.kickMetresGained, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isKicksInPlay);

                        if (Global.player[i].ninesStats.isKicksInPlay)
                            bw.WriteInt32(Global.player[i].ninesStats.kicksInPlay, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isKnockOns);

                        if (Global.player[i].ninesStats.isKnockOns)
                            bw.WriteInt32(Global.player[i].ninesStats.knockOns, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.islineBreakAssists);

                        if (Global.player[i].ninesStats.islineBreakAssists)
                            bw.WriteInt32(Global.player[i].ninesStats.lineBreakAssists, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isLineBreaks);

                        if (Global.player[i].ninesStats.isLineBreaks)
                            bw.WriteInt32(Global.player[i].ninesStats.lineBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isMetresRun);

                        if (Global.player[i].ninesStats.isMetresRun)
                            bw.WriteInt32(Global.player[i].ninesStats.metresRun, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isMinutesPlayed);

                        if (Global.player[i].ninesStats.isMinutesPlayed)
                            bw.WriteInt32(Global.player[i].ninesStats.minutesPlayed, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isMissedTackles);

                        if (Global.player[i].ninesStats.isMissedTackles)
                            bw.WriteInt32(Global.player[i].ninesStats.missedTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isOffloads);

                        if (Global.player[i].ninesStats.isOffloads)
                            bw.WriteInt32(Global.player[i].ninesStats.offloads, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isOneOnOneTackles);

                        if (Global.player[i].ninesStats.isOneOnOneTackles)
                            bw.WriteInt32(Global.player[i].ninesStats.oneOnOneTackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isPasses);

                        if (Global.player[i].ninesStats.isPasses)
                            bw.WriteInt32(Global.player[i].ninesStats.passes, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isPenaltiesConceded);

                        if (Global.player[i].ninesStats.isPenaltiesConceded)
                            bw.WriteInt32(Global.player[i].ninesStats.penaltiesConceded, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isPenaltyGoals);

                        if (Global.player[i].ninesStats.isPenaltyGoals)
                            bw.WriteInt32(Global.player[i].ninesStats.penaltyGoals, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isPenaltyGoalAttempts);

                        if (Global.player[i].ninesStats.isPenaltyGoalAttempts)
                            bw.WriteInt32(Global.player[i].ninesStats.penaltyGoalAttempts, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isRuns);

                        if (Global.player[i].ninesStats.isRuns)
                            bw.WriteInt32(Global.player[i].ninesStats.runs, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isTackleBreaks);

                        if (Global.player[i].ninesStats.isTackleBreaks)
                            bw.WriteInt32(Global.player[i].ninesStats.tackleBreaks, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isTackles);

                        if (Global.player[i].ninesStats.isTackles)
                            bw.WriteInt32(Global.player[i].ninesStats.tackles, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isTries);

                        if (Global.player[i].ninesStats.isTries)
                            bw.WriteInt32(Global.player[i].ninesStats.tries, Endian.Little);

                        bw.WriteBool(Global.player[i].ninesStats.isTryAssists);

                        if (Global.player[i].ninesStats.isTryAssists)
                            bw.WriteInt32(Global.player[i].ninesStats.tryAssists, Endian.Little);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
    }
}
