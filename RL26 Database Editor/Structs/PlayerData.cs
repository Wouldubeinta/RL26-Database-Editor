namespace RL26_Database_Editor
{
    /// <summary>
    /// Player Data Struct.
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
    /// [Wouldubeinta]	   16/09/2025	Created
    /// </history>
    public class PlayerData
    {
        public struct Player
        {
            public int identifier;
            public int dataSize;
            public byte[] data;
            public bool isPlayerEnabled;
            public bool isId;
            public int id;
            public bool isFirstName;
            public byte firstNameSize;
            public string firstName;
            public bool isLastName;
            public byte lastNameSize;
            public string lastName;
            public bool isLicensed;
            public bool licensed;
            public bool isHidden;
            public bool hidden;
            public bool isClub;
            public int club;
            public bool isGender;
            public int gender;
            public bool isJerseyName;
            public byte jerseyNameSize;
            public string jerseyName;
            public bool isJerseyNumber;
            public int jerseyNumber;
            public DOB dob;
            public bool isAge;
            public int age;
            public bool isCountryOfBirth;
            public int countryOfBirth;
            public bool isRepCountry;
            public int repCountry;
            public bool isStateOfOrigin;
            public int stateOfOrigin;
            public bool isOriginRepNumber;
            public int originRepNumber;
            public bool isOriginOtherNumber;
            public int originOtherNumber;
            public bool isCityVsCountry;
            public int cityVsCountry;
            public bool isAllStars;
            public int allStars;
            public bool isWorldCup;
            public bool WorldCup;
            public bool isContractExpiry;
            public int contractExpiry;
            public bool isPrimaryRole;
            public int primaryRole;
            public bool isSecondaryRole;
            public int secondaryRole;
            public bool isTertiaryRole;
            public int tertiaryRole;
            public bool isCommentaryNameHash;
            public uint commentaryNameHash;
            public bool isPreferredHand;
            public byte preferredHand;
            public bool isPreferredFoot;
            public byte preferredFoot;
            public Appearance appearance;
            public Attributes attributes;
            public TechnicalAbility technicalAbility;
            public Skills skills;
            public CareerStats nrlStats;
            public CareerStats slStats;
            public bool isStandardStats;
            public Statistics standardStats;
            public bool isNinesStats;
            public Statistics ninesStats;
        }

        public struct DOB
        {
            public bool isDay;
            public int day;
            public bool isMonth;
            public int month;
            public bool isYear;
            public int year;
        }

        public struct Appearance
        {
            public bool isHeight;
            public int height;
            public bool isWeight;
            public int weight;
            public bool isHeadVisual;
            public int headVisual;
            public bool isHairTopVisual;
            public int hairTopVisual;
            public bool isPhotogrammetryStatus;
            public int photogrammetryStatus;
        }

        public struct TechnicalAbility
        {
            public bool isStrength;
            public int strength;
            public bool isDurability;
            public int durability;
            public bool isDiscipline;
            public int discipline;
            public bool isAgility;
            public int agility;
            public bool isStamina;
            public int stamina;
            public bool isAcceleration;
            public int acceleration;
            public bool isSprintSpeed;
            public int sprintSpeed;
        }

        public struct Attributes
        {
            public bool isReputation;
            public int reputation;
            public bool isEgo;
            public int ego;
            public bool isLoyalty;
            public int loyalty;
            public bool isPerk;
            public int perk;
        }

        public struct Skills
        {
            public KickingSkills kickingSkills;
            public PassingSkills passingSkills;
            public EvasionSkills evasionSkills;
            public MiscSkills miscSkills;
            public TackleSkills tackleSkills;
        }

        public struct KickingSkills
        {
            public bool isGrubberKick;
            public int grubberKick;
            public bool isPuntKick;
            public int puntKick;
            public bool isChipKick;
            public int chipKick;
            public bool isBombKick;
            public int bombKick;
            public bool isFieldgoalKick;
            public int fieldgoalKick;
            public bool isPlaceKick;
            public int placeKick;
        }

        public struct PassingSkills
        {
            public bool isBasicPass;
            public int basicPass;
            public bool islongPass;
            public int longPass;
            public bool isOffload;
            public int offload;
        }

        public struct EvasionSkills
        {
            public bool isDummyPass;
            public int dummyPass;
            public bool isFend;
            public int fend;
            public bool isSideStep;
            public int sideStep;
            public bool isBreakTackle;
            public int breakTackle;
        }

        public struct MiscSkills
        {
            public bool isContestedCollect;
            public int contestedCollect;
            public bool isDiveCollect;
            public int diveCollect;
            public bool isBallStrip;
            public int ballStrip;
        }

        public struct TackleSkills
        {
            public bool isTackle;
            public int tackle;
            public bool isDriveTackle;
            public int driveTackle;
            public bool isDiveTackle;
            public int diveTackle;
            public bool isImpactTackle;
            public int impactTackle;
        }

        public struct CareerStats
        {
            public bool isAppearances;
            public int appearances;
            public bool isTriesScored;
            public int triesScored;
            public bool isGoals;
            public int goals;
            public bool isGoalsAttempted;
            public int goalsAttempted;
            public bool isPoints;
            public int points;
        }

        public struct Statistics
        {
            public bool isMatchesPlayed;
            public int matchesPlayed;
            public bool isMatchesWon;
            public int matchesWon;
            public bool isMatchesDrawn;
            public int matchesDrawn;
            public bool isBallStrips;
            public int ballStrips;
            public bool isConversions;
            public int conversions;
            public bool isConversionAttempts;
            public int conversionAttempts;
            public bool isFends;
            public int fends;
            public bool isFieldGoalAttempts;
            public int fieldGoalAttempts;
            public bool isFieldGoals;
            public int fieldGoals;
            public bool isFortyTwenties;
            public int fortyTwenties;
            public bool isHandlingErrors;
            public int handlingErrors;
            public bool isHitups;
            public int hitups;
            public bool isInterceptedPasses;
            public int interceptedPasses;
            public bool isInterceptions;
            public int interceptions;
            public bool isKickMetresGained;
            public int kickMetresGained;
            public bool isKicksInPlay;
            public int kicksInPlay;
            public bool isKnockOns;
            public int knockOns;
            public bool islineBreakAssists;
            public int lineBreakAssists;
            public bool isLineBreaks;
            public int lineBreaks;
            public bool isMetresRun;
            public int metresRun;
            public bool isMinutesPlayed;
            public int minutesPlayed;
            public bool isMissedTackles;
            public int missedTackles;
            public bool isOffloads;
            public int offloads;
            public bool isOneOnOneTackles;
            public int oneOnOneTackles;
            public bool isPasses;
            public int passes;
            public bool isPenaltiesConceded;
            public int penaltiesConceded;
            public bool isPenaltyGoals;
            public int penaltyGoals;
            public bool isPenaltyGoalAttempts;
            public int penaltyGoalAttempts;
            public bool isRuns;
            public int runs;
            public bool isTackleBreaks;
            public int tackleBreaks;
            public bool isTackles;
            public int tackles;
            public bool isTries;
            public int tries;
            public bool isTryAssists;
            public int tryAssists;
            public bool isBonusTries;
            public int bonusTries;
        }
    }
}
