namespace RL26_Database_Editor
{
    public partial class Player_Editor : Form
    {
        private readonly DataGridView Players_dataGridView;

        public Player_Editor(DataGridView Players_dataGridView)
        {
            InitializeComponent();
            this.Players_dataGridView = Players_dataGridView;
        }

        private int Player_Index = 0;
        private Random? random = null;
        private Dialogue_Wildcardhash.WildcardHash[]? commentaryNameHash = null;

        private void Player_Editor_Load(object sender, EventArgs e)
        {
            Player_Index_textBox.Text = Global.player_index.ToString();
            Player_Index = Global.player_index;
            Player_ID_textBox.Text = Global.player[Player_Index].id.ToString();

            Preferred_Hand_comboBox.SelectedIndex = Global.player[Player_Index].preferredHand;
            Preferred_Foot_comboBox.SelectedIndex = Global.player[Player_Index].preferredFoot;

            First_Name_textBox.Text = Global.player[Player_Index].firstName;
            Last_Name_textBox.Text = Global.player[Player_Index].lastName;

            licensed_checkBox.Checked = Global.player[Player_Index].licensed;
            Hidden_checkBox.Checked = Global.player[Player_Index].hidden;

            string commentaryDataPath = Global.currentPath + @"\commentary_data\";

            commentaryNameHash = CommentaryHashes.Read(commentaryDataPath + "dialogue_wildcardhash_surnames");

            string[] commNames = new string[commentaryNameHash.Length];

            for (int i = 0; i < commentaryNameHash.Length; i++)
            {
                commNames[i] = commentaryNameHash[i].name.ToTitleCase();
            }

            commentaryNameHash_comboBox.Items.AddRange(commNames);
            int commentaryIndex = CommentaryHashes.GetHashes(Global.player[Player_Index].commentaryNameHash, commentaryNameHash);

            if (commentaryIndex != -1)
                commentaryNameHash_comboBox.SelectedIndex = commentaryIndex;
            else
                commentaryNameHash_comboBox.SelectedIndex = 0;

            club_textBox.Text = Global.player[Player_Index].club.ToString();

            PlayerGender_textBox.Text = "Male";
            PlayerGenderImage_label.Image = Properties.Resources.Male;

            if (Global.player[Player_Index].gender == 1)
            {
                PlayerGender_textBox.Text = "Female";
                PlayerGenderImage_label.Image = Properties.Resources.Female;
            }

            Day_numericUpDown.Value = Global.player[Player_Index].dob.day;
            Month_numericUpDown.Value = Global.player[Player_Index].dob.month;
            Year_numericUpDown.Value = Global.player[Player_Index].dob.year;

            if (Global.player[Player_Index].jerseyNumber < 1 || Global.player[Player_Index].jerseyNumber > 99)
                Jersey_Number_numericUpDown.Value = 1;
            else
                Jersey_Number_numericUpDown.Value = Global.player[Player_Index].jerseyNumber;

            slJerseyNumber_checkBox.Checked = Global.player[Player_Index].isJerseyNumber;
            isWordCup_checkBox.Checked = Global.player[Player_Index].WorldCup;
            Jersey_Name_textBox.Text = Global.player[Player_Index].jerseyName;

            Primary_Role_comboBox.SelectedIndex = Global.player[Player_Index].primaryRole;
            Secondary_Role_comboBox.SelectedIndex = Global.player[Player_Index].secondaryRole;
            Tertiary_Role_comboBox.SelectedIndex = Global.player[Player_Index].tertiaryRole;

            Representative_Country_comboBox.Items.AddRange(StringArrays.RepCountry);
            Country_Of_Birth_comboBox.Items.AddRange(StringArrays.CountryOfBirth);
            Representative_Country_comboBox.SelectedIndex = Global.player[Player_Index].repCountry;
            Country_Of_Birth_comboBox.SelectedIndex = Global.player[Player_Index].countryOfBirth;

            int SOO_ID = Global.player[Player_Index].stateOfOrigin;

            if (SOO_ID == 0 || SOO_ID == 196)
                SOO_comboBox.SelectedIndex = 0;
            else if (SOO_ID == 197)
                SOO_comboBox.SelectedIndex = 1;
            else if (SOO_ID == 198)
                SOO_comboBox.SelectedIndex = 2;

            originRepNumber_numericUpDown.Value = Global.player[Player_Index].originRepNumber;
            originOtherNumber_numericUpDown.Value = Global.player[Player_Index].originOtherNumber;

            int CVC_ID = Global.player[Player_Index].cityVsCountry;

            if (CVC_ID == 0 || CVC_ID == 199)
                CVC_comboBox.SelectedIndex = 0;
            else if (CVC_ID == 200)
                CVC_comboBox.SelectedIndex = 1;
            else if (CVC_ID == 201)
                CVC_comboBox.SelectedIndex = 2;

            int Allstars_ID = Global.player[Player_Index].allStars;

            if (Allstars_ID == 0 || Allstars_ID == 202)
                Allstars_comboBox.SelectedIndex = 0;
            else if (Allstars_ID == 203)
                Allstars_comboBox.SelectedIndex = 1;
            else if (Allstars_ID == 204)
                Allstars_comboBox.SelectedIndex = 2;

            Height_numericUpDown.Value = Global.player[Player_Index].appearance.height;
            Weight_numericUpDown.Value = Global.player[Player_Index].appearance.weight;

            if (Global.player[Player_Index].isContractExpiry == false || Global.player[Player_Index].contractExpiry == 0)
                ContractExpiry_comboBox.SelectedIndex = 26;
            else
                ContractExpiry_comboBox.Text = Global.player[Player_Index].contractExpiry.ToString();

            Reputation_numericUpDown.Value = Global.player[Player_Index].attributes.reputation;
            Ego_numericUpDown.Value = Global.player[Player_Index].attributes.ego;
            Loyalty_numericUpDown.Value = Global.player[Player_Index].attributes.loyalty;

            Strength_numericUpDown.Value = Global.player[Player_Index].technicalAbility.strength;
            Agility_numericUpDown.Value = Global.player[Player_Index].technicalAbility.agility;
            Stamina_numericUpDown.Value = Global.player[Player_Index].technicalAbility.stamina;
            Acceleration_numericUpDown.Value = Global.player[Player_Index].technicalAbility.acceleration;
            Discipline_numericUpDown.Value = Global.player[Player_Index].technicalAbility.discipline;
            Durability_numericUpDown.Value = Global.player[Player_Index].technicalAbility.durability;
            SprintSpeed_numericUpDown.Value = Global.player[Player_Index].technicalAbility.sprintSpeed;

            if (Global.player[Player_Index].attributes.isPerk == false || Global.player[Player_Index].attributes.perk == 0)
                Perks_comboBox.SelectedIndex = 0;
            else
                Perks_comboBox.SelectedIndex = Global.player[Player_Index].attributes.perk;

            grubberKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.grubberKick;
            puntKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.puntKick;
            chipKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.chipKick;
            bombKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.bombKick;
            fieldgoalKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.fieldgoalKick;
            placeKick_numericUpDown.Value = Global.player[Player_Index].skills.kickingSkills.placeKick;

            basicPass_numericUpDown.Value = Global.player[Player_Index].skills.passingSkills.basicPass;
            longPass_numericUpDown.Value = Global.player[Player_Index].skills.passingSkills.longPass;
            offload_numericUpDown.Value = Global.player[Player_Index].skills.passingSkills.offload;

            dummyPass_numericUpDown.Value = Global.player[Player_Index].skills.evasionSkills.dummyPass;
            fend_numericUpDown.Value = Global.player[Player_Index].skills.evasionSkills.fend;
            sideStep_numericUpDown.Value = Global.player[Player_Index].skills.evasionSkills.sideStep;
            breakTackle_numericUpDown.Value = Global.player[Player_Index].skills.evasionSkills.breakTackle;

            tackle_numericUpDown.Value = Global.player[Player_Index].skills.tackleSkills.tackle;
            driveTackle_numericUpDown.Value = Global.player[Player_Index].skills.tackleSkills.driveTackle;
            diveTackle_numericUpDown.Value = Global.player[Player_Index].skills.tackleSkills.diveTackle;
            impactTackle_numericUpDown.Value = Global.player[Player_Index].skills.tackleSkills.impactTackle;

            contestedCollect_numericUpDown.Value = Global.player[Player_Index].skills.miscSkills.contestedCollect;
            diveCollect_numericUpDown.Value = Global.player[Player_Index].skills.miscSkills.diveCollect;
            ballStrip_numericUpDown.Value = Global.player[Player_Index].skills.miscSkills.ballStrip;

            nrlcareerappearances_numericUpDown.Value = Global.player[Player_Index].nrlStats.appearances;
            nrlcareertriesscored_numericUpDown.Value = Global.player[Player_Index].nrlStats.triesScored;
            nrlcareergoals_numericUpDown.Value = Global.player[Player_Index].nrlStats.goals;
            nrlcareergoalsattempted_numericUpDown.Value = Global.player[Player_Index].nrlStats.goalsAttempted;
            nrlcareerpoints_numericUpDown.Value = Global.player[Player_Index].nrlStats.points;

            SLcareerappearances_numericUpDown.Value = Global.player[Player_Index].slStats.appearances;
            SLcareertriesscored_numericUpDown.Value = Global.player[Player_Index].slStats.triesScored;
            SLcareergoals_numericUpDown.Value = Global.player[Player_Index].slStats.goals;
            SLcareergoalsattempted_numericUpDown.Value = Global.player[Player_Index].slStats.goalsAttempted;
            SLcareerpoints_numericUpDown.Value = Global.player[Player_Index].slStats.points;

            StadardMatchEnabled_checkBox.Checked = Global.player[Player_Index].isStandardStats;

            if (StadardMatchEnabled_checkBox.Checked)
            {
                Stries_numericUpDown.Value = Global.player[Player_Index].standardStats.tries;
                StryAssists_numericUpDown.Value = Global.player[Player_Index].standardStats.tryAssists;
                SfieldGoalAttempts_numericUpDown.Value = Global.player[Player_Index].standardStats.fieldGoalAttempts;
                StackleBreaks_numericUpDown.Value = Global.player[Player_Index].standardStats.tackleBreaks;
                SpenaltyGoalAttempts_numericUpDown.Value = Global.player[Player_Index].standardStats.penaltyGoalAttempts;
                Sruns_numericUpDown.Value = Global.player[Player_Index].standardStats.runs;
                SballStrips_numericUpDown.Value = Global.player[Player_Index].standardStats.ballStrips;
                SfieldGoals_numericUpDown.Value = Global.player[Player_Index].standardStats.fieldGoals;
                SmatchesPlayed_numericUpDown.Value = Global.player[Player_Index].standardStats.matchesPlayed;
                SmatchesWon_numericUpDown.Value = Global.player[Player_Index].standardStats.matchesWon;
                SmetresRun_numericUpDown.Value = Global.player[Player_Index].standardStats.metresRun;
                Sinterceptions_numericUpDown.Value = Global.player[Player_Index].standardStats.interceptions;
                SfortyTwenties_numericUpDown.Value = Global.player[Player_Index].standardStats.fortyTwenties;
                SinterceptedPasses_numericUpDown.Value = Global.player[Player_Index].standardStats.interceptedPasses;
                Sfends_numericUpDown.Value = Global.player[Player_Index].standardStats.fends;
                Stackles_numericUpDown.Value = Global.player[Player_Index].standardStats.tackles;
                ShandlingErrors_numericUpDown.Value = Global.player[Player_Index].standardStats.handlingErrors;
                Shitups_numericUpDown.Value = Global.player[Player_Index].standardStats.hitups;
                Sconversions_numericUpDown.Value = Global.player[Player_Index].standardStats.conversions;
                SmatchesDrawn_numericUpDown.Value = Global.player[Player_Index].standardStats.matchesDrawn;
                SmissedTackles_numericUpDown.Value = Global.player[Player_Index].standardStats.missedTackles;
                SpenaltiesConceded_numericUpDown.Value = Global.player[Player_Index].standardStats.penaltiesConceded;
                SlineBreakAssists_numericUpDown.Value = Global.player[Player_Index].standardStats.lineBreakAssists;
                SconversionAttempts_numericUpDown.Value = Global.player[Player_Index].standardStats.conversionAttempts;
                SoneOnOneTackles_numericUpDown.Value = Global.player[Player_Index].standardStats.oneOnOneTackles;
                SminutesPlayed_numericUpDown.Value = Global.player[Player_Index].standardStats.minutesPlayed;
                Spasses_numericUpDown.Value = Global.player[Player_Index].standardStats.passes;
                SkicksInPlay_numericUpDown.Value = Global.player[Player_Index].standardStats.kicksInPlay;
                SkickMetresGained_numericUpDown.Value = Global.player[Player_Index].standardStats.kickMetresGained;
                SlineBreaks_numericUpDown.Value = Global.player[Player_Index].standardStats.lineBreaks;
                Soffloads_numericUpDown.Value = Global.player[Player_Index].standardStats.offloads;
                SknockOns_numericUpDown.Value = Global.player[Player_Index].standardStats.knockOns;
                SpenaltyGoals_numericUpDown.Value = Global.player[Player_Index].standardStats.penaltyGoals;
            }

            NinesMatchEnabled_checkBox.Checked = Global.player[Player_Index].isNinesStats;

            if (NinesMatchEnabled_checkBox.Checked)
            {
                Ntries_numericUpDown.Value = Global.player[Player_Index].ninesStats.tries;
                NtryAssists_numericUpDown.Value = Global.player[Player_Index].ninesStats.tryAssists;
                NfieldGoalAttempts_numericUpDown.Value = Global.player[Player_Index].ninesStats.fieldGoalAttempts;
                NtackleBreaks_numericUpDown.Value = Global.player[Player_Index].ninesStats.tackleBreaks;
                NpenaltyGoalAttempts_numericUpDown.Value = Global.player[Player_Index].ninesStats.penaltyGoalAttempts;
                Nruns_numericUpDown.Value = Global.player[Player_Index].ninesStats.runs;
                NballStrips_numericUpDown.Value = Global.player[Player_Index].ninesStats.ballStrips;
                NfieldGoals_numericUpDown.Value = Global.player[Player_Index].ninesStats.fieldGoals;
                NmatchesPlayed_numericUpDown.Value = Global.player[Player_Index].ninesStats.matchesPlayed;
                NmatchesWon_numericUpDown.Value = Global.player[Player_Index].ninesStats.matchesWon;
                NmetresRun_numericUpDown.Value = Global.player[Player_Index].ninesStats.metresRun;
                Ninterceptions_numericUpDown.Value = Global.player[Player_Index].ninesStats.interceptions;
                NbonusTries_numericUpDown.Value = Global.player[Player_Index].ninesStats.bonusTries;
                NfortyTwenties_numericUpDown.Value = Global.player[Player_Index].ninesStats.fortyTwenties;
                NinterceptedPasses_numericUpDown.Value = Global.player[Player_Index].ninesStats.interceptedPasses;
                Nfends_numericUpDown.Value = Global.player[Player_Index].ninesStats.fends;
                Ntackles_numericUpDown.Value = Global.player[Player_Index].ninesStats.tackles;
                NhandlingErrors_numericUpDown.Value = Global.player[Player_Index].ninesStats.handlingErrors;
                Nhitups_numericUpDown.Value = Global.player[Player_Index].ninesStats.hitups;
                Nconversions_numericUpDown.Value = Global.player[Player_Index].ninesStats.conversions;
                NmatchesDrawn_numericUpDown.Value = Global.player[Player_Index].ninesStats.matchesDrawn;
                NmissedTackles_numericUpDown.Value = Global.player[Player_Index].ninesStats.missedTackles;
                NpenaltiesConceded_numericUpDown.Value = Global.player[Player_Index].ninesStats.penaltiesConceded;
                NlineBreakAssists_numericUpDown.Value = Global.player[Player_Index].ninesStats.lineBreakAssists;
                NconversionAttempts_numericUpDown.Value = Global.player[Player_Index].ninesStats.conversionAttempts;
                NoneOnOneTackles_numericUpDown.Value = Global.player[Player_Index].ninesStats.oneOnOneTackles;
                NminutesPlayed_numericUpDown.Value = Global.player[Player_Index].ninesStats.minutesPlayed;
                Npasses_numericUpDown.Value = Global.player[Player_Index].ninesStats.passes;
                NkicksInPlay_numericUpDown.Value = Global.player[Player_Index].ninesStats.kicksInPlay;
                NkickMetresGained_numericUpDown.Value = Global.player[Player_Index].ninesStats.kickMetresGained;
                NlineBreaks_numericUpDown.Value = Global.player[Player_Index].ninesStats.lineBreaks;
                Noffloads_numericUpDown.Value = Global.player[Player_Index].ninesStats.offloads;
                NknockOns_numericUpDown.Value = Global.player[Player_Index].ninesStats.knockOns;
                NpenaltyGoals_numericUpDown.Value = Global.player[Player_Index].ninesStats.penaltyGoals;
            }

            int playerRating = Rating.PlayerRating(Player_Index);
            player_name_label.Text = First_Name_textBox.Text + " " + Last_Name_textBox.Text + " - " + playerRating.ToString();

            if (playerRating >= 83)
                RandomizeStats_comboBox.SelectedIndex = 0;
            else if (playerRating <= 82 && playerRating >= 70)
                RandomizeStats_comboBox.SelectedIndex = 1;
            else if (playerRating <= 69)
                RandomizeStats_comboBox.SelectedIndex = 2;
        }

        private void Player_Save_Changers_button_Click(object sender, EventArgs e)
        {

            Global.player[Player_Index].id = Convert.ToInt32(Player_ID_textBox.Text);
            Global.player[Player_Index].isPreferredHand = true;
            Global.player[Player_Index].preferredHand = Convert.ToByte(Preferred_Hand_comboBox.SelectedIndex);
            Global.player[Player_Index].isPreferredFoot = true;
            Global.player[Player_Index].preferredFoot = Convert.ToByte(Preferred_Foot_comboBox.SelectedIndex);

            Global.player[Player_Index].dob.day = Convert.ToInt32(Day_numericUpDown.Value);
            Global.player[Player_Index].dob.month = Convert.ToInt32(Month_numericUpDown.Value);
            Global.player[Player_Index].dob.year = Convert.ToInt32(Year_numericUpDown.Value);

            Global.player[Player_Index].firstNameSize = Convert.ToByte(First_Name_textBox.Text.Length);
            Global.player[Player_Index].firstName = First_Name_textBox.Text;
            Global.player[Player_Index].lastNameSize = Convert.ToByte(Last_Name_textBox.Text.Length);
            Global.player[Player_Index].lastName = Last_Name_textBox.Text;

            Global.player[Player_Index].isClub = true;

            if (Convert.ToInt32(club_textBox.Text) == 0)
                Global.player[Player_Index].club = 0;
            else
                Global.player[Player_Index].club = Convert.ToInt32(club_textBox.Text);

            Global.player[Player_Index].isLicensed = true;
            Global.player[Player_Index].licensed = licensed_checkBox.Checked;

            Global.player[Player_Index].isHidden = Hidden_checkBox.Checked;
            Global.player[Player_Index].hidden = Hidden_checkBox.Checked;

            Global.player[Player_Index].isCommentaryNameHash = true;

            if (commentaryNameHash != null)
            {
                uint commNameHash = CommentaryHashes.SetHashes(commentaryNameHash_comboBox.Text.ToLower(), commentaryNameHash);
                Global.player[Player_Index].commentaryNameHash = commNameHash;
            }

            Global.player[Player_Index].isWorldCup = true;
            Global.player[Player_Index].WorldCup = isWordCup_checkBox.Checked;

            Global.player[Player_Index].jerseyNameSize = Convert.ToByte(Jersey_Name_textBox.Text.Length);
            Global.player[Player_Index].jerseyName = Jersey_Name_textBox.Text;

            Global.player[Player_Index].isJerseyNumber = slJerseyNumber_checkBox.Checked;
            Global.player[Player_Index].jerseyNumber = Convert.ToInt32(Jersey_Number_numericUpDown.Value);

            Global.player[Player_Index].isPrimaryRole = true;
            Global.player[Player_Index].primaryRole = Convert.ToInt32(Primary_Role_comboBox.SelectedIndex);
            Global.player[Player_Index].isSecondaryRole = true;
            Global.player[Player_Index].secondaryRole = Convert.ToInt32(Secondary_Role_comboBox.SelectedIndex);
            Global.player[Player_Index].isTertiaryRole = true;
            Global.player[Player_Index].tertiaryRole = Convert.ToInt32(Tertiary_Role_comboBox.SelectedIndex);

            Global.player[Player_Index].isStateOfOrigin = true;

            if (SOO_comboBox.SelectedIndex == 0)
            {
                Global.player[Player_Index].stateOfOrigin = 196;
            }
            else if (SOO_comboBox.SelectedIndex == 1)
                Global.player[Player_Index].stateOfOrigin = 197;
            else if (SOO_comboBox.SelectedIndex == 2)
                Global.player[Player_Index].stateOfOrigin = 198;

            Global.player[Player_Index].isOriginRepNumber = true;
            Global.player[Player_Index].originRepNumber = Convert.ToInt32(originRepNumber_numericUpDown.Value);

            Global.player[Player_Index].isOriginOtherNumber = true;
            Global.player[Player_Index].originOtherNumber = Convert.ToInt32(originOtherNumber_numericUpDown.Value);

            Global.player[Player_Index].isCityVsCountry = true;

            if (CVC_comboBox.SelectedIndex == 0)
            {
                Global.player[Player_Index].cityVsCountry = 199;
            }
            else if (CVC_comboBox.SelectedIndex == 1)
                Global.player[Player_Index].cityVsCountry = 200;
            else if (CVC_comboBox.SelectedIndex == 2)
                Global.player[Player_Index].cityVsCountry = 201;

            Global.player[Player_Index].isAllStars = true;

            if (Allstars_comboBox.SelectedIndex == 0)
            {
                Global.player[Player_Index].allStars = 202;
            }
            else if (Allstars_comboBox.SelectedIndex == 1)
                Global.player[Player_Index].allStars = 203;
            else if (Allstars_comboBox.SelectedIndex == 2)
                Global.player[Player_Index].allStars = 204;

            Global.player[Player_Index].isCountryOfBirth = true;
            Global.player[Player_Index].countryOfBirth = Country_Of_Birth_comboBox.SelectedIndex;

            Global.player[Player_Index].isRepCountry = true;
            Global.player[Player_Index].repCountry = Representative_Country_comboBox.SelectedIndex;

            Global.player[Player_Index].appearance.height = Convert.ToInt32(Height_numericUpDown.Value);
            Global.player[Player_Index].appearance.weight = Convert.ToInt32(Weight_numericUpDown.Value);

            Global.player[Player_Index].attributes.isReputation = true;
            Global.player[Player_Index].attributes.reputation = Convert.ToInt32(Reputation_numericUpDown.Value);
            Global.player[Player_Index].attributes.isEgo = true;
            Global.player[Player_Index].attributes.ego = Convert.ToInt32(Ego_numericUpDown.Value);
            Global.player[Player_Index].attributes.isLoyalty = true;
            Global.player[Player_Index].attributes.loyalty = Convert.ToInt32(Loyalty_numericUpDown.Value);

            Global.player[Player_Index].attributes.isPerk = true;

            if (Perks_comboBox.SelectedIndex == 0)
                Global.player[Player_Index].attributes.perk = 0;
            else
                Global.player[Player_Index].attributes.perk = Perks_comboBox.SelectedIndex;

            Global.player[Player_Index].technicalAbility.strength = Convert.ToInt32(Strength_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.agility = Convert.ToInt32(Agility_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.stamina = Convert.ToInt32(Stamina_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.acceleration = Convert.ToInt32(Acceleration_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.discipline = Convert.ToInt32(Discipline_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.durability = Convert.ToInt32(Durability_numericUpDown.Value);
            Global.player[Player_Index].technicalAbility.sprintSpeed = Convert.ToInt32(SprintSpeed_numericUpDown.Value);

            Global.player[Player_Index].skills.kickingSkills.grubberKick = Convert.ToInt32(grubberKick_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.puntKick = Convert.ToInt32(puntKick_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.chipKick = Convert.ToInt32(chipKick_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.bombKick = Convert.ToInt32(bombKick_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.fieldgoalKick = Convert.ToInt32(fieldgoalKick_numericUpDown.Value);
            Global.player[Player_Index].skills.kickingSkills.placeKick = Convert.ToInt32(placeKick_numericUpDown.Value);

            Global.player[Player_Index].skills.passingSkills.basicPass = Convert.ToInt32(basicPass_numericUpDown.Value);
            Global.player[Player_Index].skills.passingSkills.longPass = Convert.ToInt32(longPass_numericUpDown.Value);
            Global.player[Player_Index].skills.passingSkills.offload = Convert.ToInt32(offload_numericUpDown.Value);

            Global.player[Player_Index].skills.evasionSkills.dummyPass = Convert.ToInt32(dummyPass_numericUpDown.Value);
            Global.player[Player_Index].skills.evasionSkills.fend = Convert.ToInt32(fend_numericUpDown.Value);
            Global.player[Player_Index].skills.evasionSkills.sideStep = Convert.ToInt32(sideStep_numericUpDown.Value);
            Global.player[Player_Index].skills.evasionSkills.breakTackle = Convert.ToInt32(breakTackle_numericUpDown.Value);

            Global.player[Player_Index].skills.tackleSkills.tackle = Convert.ToInt32(tackle_numericUpDown.Value);
            Global.player[Player_Index].skills.tackleSkills.driveTackle = Convert.ToInt32(driveTackle_numericUpDown.Value);
            Global.player[Player_Index].skills.tackleSkills.diveTackle = Convert.ToInt32(diveTackle_numericUpDown.Value);
            Global.player[Player_Index].skills.tackleSkills.impactTackle = Convert.ToInt32(impactTackle_numericUpDown.Value);

            Global.player[Player_Index].skills.miscSkills.contestedCollect = Convert.ToInt32(contestedCollect_numericUpDown.Value);
            Global.player[Player_Index].skills.miscSkills.diveCollect = Convert.ToInt32(diveCollect_numericUpDown.Value);
            Global.player[Player_Index].skills.miscSkills.ballStrip = Convert.ToInt32(ballStrip_numericUpDown.Value);

            Global.player[Player_Index].nrlStats.appearances = Convert.ToInt32(nrlcareerappearances_numericUpDown.Value);
            Global.player[Player_Index].nrlStats.triesScored = Convert.ToInt32(nrlcareertriesscored_numericUpDown.Value);
            Global.player[Player_Index].nrlStats.goals = Convert.ToInt32(nrlcareergoals_numericUpDown.Value);
            Global.player[Player_Index].nrlStats.goalsAttempted = Convert.ToInt32(nrlcareergoalsattempted_numericUpDown.Value);
            Global.player[Player_Index].nrlStats.points = Convert.ToInt32(nrlcareerpoints_numericUpDown.Value);

            Global.player[Player_Index].slStats.appearances = Convert.ToInt32(SLcareerappearances_numericUpDown.Value);
            Global.player[Player_Index].slStats.triesScored = Convert.ToInt32(SLcareertriesscored_numericUpDown.Value);
            Global.player[Player_Index].slStats.goals = Convert.ToInt32(SLcareergoals_numericUpDown.Value);
            Global.player[Player_Index].slStats.goalsAttempted = Convert.ToInt32(SLcareergoalsattempted_numericUpDown.Value);
            Global.player[Player_Index].slStats.points = Convert.ToInt32(SLcareerpoints_numericUpDown.Value);

            if (StadardMatchEnabled_checkBox.Checked)
            {
                Global.player[Player_Index].isStandardStats = true;

                Global.player[Player_Index].standardStats.isMatchesPlayed = true;
                Global.player[Player_Index].standardStats.matchesPlayed = Convert.ToInt32(SmatchesPlayed_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isMatchesWon = true;
                Global.player[Player_Index].standardStats.matchesWon = Convert.ToInt32(SmatchesWon_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isMatchesDrawn = true;
                Global.player[Player_Index].standardStats.matchesDrawn = Convert.ToInt32(SmatchesDrawn_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isBallStrips = true;
                Global.player[Player_Index].standardStats.ballStrips = Convert.ToInt32(SballStrips_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isConversions = true;
                Global.player[Player_Index].standardStats.conversions = Convert.ToInt32(Sconversions_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isConversionAttempts = true;
                Global.player[Player_Index].standardStats.conversionAttempts = Convert.ToInt32(SconversionAttempts_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isFends = true;
                Global.player[Player_Index].standardStats.fends = Convert.ToInt32(Sfends_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isFieldGoalAttempts = true;
                Global.player[Player_Index].standardStats.fieldGoalAttempts = Convert.ToInt32(SfieldGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isFieldGoals = true;
                Global.player[Player_Index].standardStats.fieldGoals = Convert.ToInt32(SfieldGoals_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isFortyTwenties = true;
                Global.player[Player_Index].standardStats.fortyTwenties = Convert.ToInt32(SfortyTwenties_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isHandlingErrors = true;
                Global.player[Player_Index].standardStats.handlingErrors = Convert.ToInt32(ShandlingErrors_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isHitups = true;
                Global.player[Player_Index].standardStats.hitups = Convert.ToInt32(Shitups_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isInterceptedPasses = true;
                Global.player[Player_Index].standardStats.interceptedPasses = Convert.ToInt32(SinterceptedPasses_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isInterceptions = true;
                Global.player[Player_Index].standardStats.interceptions = Convert.ToInt32(Sinterceptions_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isKickMetresGained = true;
                Global.player[Player_Index].standardStats.kickMetresGained = Convert.ToInt32(SkickMetresGained_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isKicksInPlay = true;
                Global.player[Player_Index].standardStats.kicksInPlay = Convert.ToInt32(SkicksInPlay_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isKnockOns = true;
                Global.player[Player_Index].standardStats.knockOns = Convert.ToInt32(SknockOns_numericUpDown.Value);
                Global.player[Player_Index].standardStats.islineBreakAssists = true;
                Global.player[Player_Index].standardStats.lineBreakAssists = Convert.ToInt32(SlineBreakAssists_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isLineBreaks = true;
                Global.player[Player_Index].standardStats.lineBreaks = Convert.ToInt32(SlineBreaks_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isMetresRun = true;
                Global.player[Player_Index].standardStats.metresRun = Convert.ToInt32(SmetresRun_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isMinutesPlayed = true;
                Global.player[Player_Index].standardStats.minutesPlayed = Convert.ToInt32(SminutesPlayed_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isMissedTackles = true;
                Global.player[Player_Index].standardStats.missedTackles = Convert.ToInt32(SmissedTackles_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isOffloads = true;
                Global.player[Player_Index].standardStats.offloads = Convert.ToInt32(Soffloads_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isOneOnOneTackles = true;
                Global.player[Player_Index].standardStats.oneOnOneTackles = Convert.ToInt32(SoneOnOneTackles_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isPasses = true;
                Global.player[Player_Index].standardStats.passes = Convert.ToInt32(Spasses_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isPenaltiesConceded = true;
                Global.player[Player_Index].standardStats.penaltiesConceded = Convert.ToInt32(SpenaltiesConceded_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isPenaltyGoals = true;
                Global.player[Player_Index].standardStats.penaltyGoals = Convert.ToInt32(SpenaltyGoals_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isPenaltyGoalAttempts = true;
                Global.player[Player_Index].standardStats.penaltyGoalAttempts = Convert.ToInt32(SpenaltyGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isRuns = true;
                Global.player[Player_Index].standardStats.runs = Convert.ToInt32(Sruns_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isTackleBreaks = true;
                Global.player[Player_Index].standardStats.tackleBreaks = Convert.ToInt32(StackleBreaks_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isTackles = true;
                Global.player[Player_Index].standardStats.tackles = Convert.ToInt32(Stackles_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isTries = true;
                Global.player[Player_Index].standardStats.tries = Convert.ToInt32(Stries_numericUpDown.Value);
                Global.player[Player_Index].standardStats.isTryAssists = true;
                Global.player[Player_Index].standardStats.tryAssists = Convert.ToInt32(StryAssists_numericUpDown.Value);
            }
            else
                Global.player[Player_Index].isStandardStats = false;

            if (NinesMatchEnabled_checkBox.Checked)
            {
                Global.player[Player_Index].isNinesStats = true;

                Global.player[Player_Index].ninesStats.isMatchesPlayed = true;
                Global.player[Player_Index].ninesStats.matchesPlayed = Convert.ToInt32(NmatchesPlayed_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isMatchesWon = true;
                Global.player[Player_Index].ninesStats.matchesWon = Convert.ToInt32(NmatchesWon_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isMatchesDrawn = true;
                Global.player[Player_Index].ninesStats.matchesDrawn = Convert.ToInt32(NmatchesDrawn_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isBallStrips = true;
                Global.player[Player_Index].ninesStats.ballStrips = Convert.ToInt32(NballStrips_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isConversions = true;
                Global.player[Player_Index].ninesStats.conversions = Convert.ToInt32(Nconversions_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isConversionAttempts = true;
                Global.player[Player_Index].ninesStats.conversionAttempts = Convert.ToInt32(NconversionAttempts_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isFends = true;
                Global.player[Player_Index].ninesStats.fends = Convert.ToInt32(Nfends_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isFieldGoalAttempts = true;
                Global.player[Player_Index].ninesStats.fieldGoalAttempts = Convert.ToInt32(NfieldGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isFieldGoals = true;
                Global.player[Player_Index].ninesStats.fieldGoals = Convert.ToInt32(NfieldGoals_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isFortyTwenties = true;
                Global.player[Player_Index].ninesStats.fortyTwenties = Convert.ToInt32(NfortyTwenties_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isHandlingErrors = true;
                Global.player[Player_Index].ninesStats.handlingErrors = Convert.ToInt32(NhandlingErrors_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isHitups = true;
                Global.player[Player_Index].ninesStats.hitups = Convert.ToInt32(Nhitups_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isInterceptedPasses = true;
                Global.player[Player_Index].ninesStats.interceptedPasses = Convert.ToInt32(NinterceptedPasses_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isInterceptions = true;
                Global.player[Player_Index].ninesStats.interceptions = Convert.ToInt32(Ninterceptions_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isKickMetresGained = true;
                Global.player[Player_Index].ninesStats.kickMetresGained = Convert.ToInt32(NkickMetresGained_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isKicksInPlay = true;
                Global.player[Player_Index].ninesStats.kicksInPlay = Convert.ToInt32(NkicksInPlay_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isKnockOns = true;
                Global.player[Player_Index].ninesStats.knockOns = Convert.ToInt32(NknockOns_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.islineBreakAssists = true;
                Global.player[Player_Index].ninesStats.lineBreakAssists = Convert.ToInt32(NlineBreakAssists_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isLineBreaks = true;
                Global.player[Player_Index].ninesStats.lineBreaks = Convert.ToInt32(NlineBreaks_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isMetresRun = true;
                Global.player[Player_Index].ninesStats.metresRun = Convert.ToInt32(NmetresRun_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isMinutesPlayed = true;
                Global.player[Player_Index].ninesStats.minutesPlayed = Convert.ToInt32(NminutesPlayed_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isMissedTackles = true;
                Global.player[Player_Index].ninesStats.missedTackles = Convert.ToInt32(NmissedTackles_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isOffloads = true;
                Global.player[Player_Index].ninesStats.offloads = Convert.ToInt32(Noffloads_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isOneOnOneTackles = true;
                Global.player[Player_Index].ninesStats.oneOnOneTackles = Convert.ToInt32(NoneOnOneTackles_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isPasses = true;
                Global.player[Player_Index].ninesStats.passes = Convert.ToInt32(Npasses_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isPenaltiesConceded = true;
                Global.player[Player_Index].ninesStats.penaltiesConceded = Convert.ToInt32(NpenaltiesConceded_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isPenaltyGoals = true;
                Global.player[Player_Index].ninesStats.penaltyGoals = Convert.ToInt32(NpenaltyGoals_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isPenaltyGoalAttempts = true;
                Global.player[Player_Index].ninesStats.penaltyGoalAttempts = Convert.ToInt32(NpenaltyGoalAttempts_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isRuns = true;
                Global.player[Player_Index].ninesStats.runs = Convert.ToInt32(Nruns_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isTackleBreaks = true;
                Global.player[Player_Index].ninesStats.tackleBreaks = Convert.ToInt32(NtackleBreaks_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isTackles = true;
                Global.player[Player_Index].ninesStats.tackles = Convert.ToInt32(Ntackles_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isTries = true;
                Global.player[Player_Index].ninesStats.tries = Convert.ToInt32(Ntries_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isTryAssists = true;
                Global.player[Player_Index].ninesStats.tryAssists = Convert.ToInt32(NtryAssists_numericUpDown.Value);
                Global.player[Player_Index].ninesStats.isBonusTries = true;
                Global.player[Player_Index].ninesStats.bonusTries = Convert.ToInt32(NbonusTries_numericUpDown.Value);
            }
            else
                Global.player[Player_Index].isNinesStats = false;

            Global.player[Player_Index].isContractExpiry = true;

            if (ContractExpiry_comboBox.SelectedIndex != 26)
                Global.player[Player_Index].contractExpiry = Convert.ToInt32(ContractExpiry_comboBox.Text);
            else
                Global.player[Player_Index].contractExpiry = 0;

            int playerRating = Rating.PlayerRating(Player_Index);

            player_name_label.Text = First_Name_textBox.Text + " " + Last_Name_textBox.Text + " - " + playerRating.ToString();

            RefreshList.Update_PlayerList(Players_dataGridView);

            MessageBox.Show("Changers have been saved to this player", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private int RandomizeStats(int min, int max)
        {
            if (random == null)
                random = new Random();
            return random.Next(min, max);
        }

        private void RandomizeStats_button_Click(object sender, EventArgs e)
        {
            int Role = Primary_Role_comboBox.SelectedIndex;
            int Level = RandomizeStats_comboBox.SelectedIndex;

            if (Role == 0 || Role == 1 || Role == 2)
            {
                if (Level == 0)
                {
                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(85, 99);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                    Durability_numericUpDown.Value = RandomizeStats(80, 95);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 99);
                    grubberKick_numericUpDown.Value = RandomizeStats(70, 85);
                    puntKick_numericUpDown.Value = RandomizeStats(60, 75);
                    chipKick_numericUpDown.Value = RandomizeStats(60, 80);
                    bombKick_numericUpDown.Value = RandomizeStats(50, 75);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(50, 75);
                    placeKick_numericUpDown.Value = RandomizeStats(50, 75);
                    basicPass_numericUpDown.Value = RandomizeStats(75, 95);
                    longPass_numericUpDown.Value = RandomizeStats(75, 95);
                    offload_numericUpDown.Value = RandomizeStats(80, 95);
                    dummyPass_numericUpDown.Value = RandomizeStats(65, 85);
                    fend_numericUpDown.Value = RandomizeStats(85, 99);
                    sideStep_numericUpDown.Value = RandomizeStats(85, 99);
                    breakTackle_numericUpDown.Value = RandomizeStats(85, 99);
                    contestedCollect_numericUpDown.Value = RandomizeStats(85, 99);
                    diveCollect_numericUpDown.Value = RandomizeStats(85, 99);
                    tackle_numericUpDown.Value = RandomizeStats(78, 92);
                    driveTackle_numericUpDown.Value = RandomizeStats(70, 85);
                    diveTackle_numericUpDown.Value = RandomizeStats(70, 85);
                    impactTackle_numericUpDown.Value = RandomizeStats(70, 85);
                }
                if (Level == 1)
                {
                    Strength_numericUpDown.Value = RandomizeStats(65, 85);
                    Agility_numericUpDown.Value = RandomizeStats(70, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(70, 80);
                    Acceleration_numericUpDown.Value = RandomizeStats(68, 92);
                    Discipline_numericUpDown.Value = RandomizeStats(70, 80);
                    Durability_numericUpDown.Value = RandomizeStats(70, 80);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(70, 92);
                    grubberKick_numericUpDown.Value = RandomizeStats(60, 75);
                    puntKick_numericUpDown.Value = RandomizeStats(50, 65);
                    chipKick_numericUpDown.Value = RandomizeStats(50, 70);
                    bombKick_numericUpDown.Value = RandomizeStats(50, 65);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(50, 65);
                    placeKick_numericUpDown.Value = RandomizeStats(50, 65);
                    basicPass_numericUpDown.Value = RandomizeStats(65, 78);
                    longPass_numericUpDown.Value = RandomizeStats(65, 78);
                    offload_numericUpDown.Value = RandomizeStats(65, 78);
                    dummyPass_numericUpDown.Value = RandomizeStats(68, 78);
                    fend_numericUpDown.Value = RandomizeStats(70, 85);
                    sideStep_numericUpDown.Value = RandomizeStats(70, 89);
                    breakTackle_numericUpDown.Value = RandomizeStats(70, 89);
                    contestedCollect_numericUpDown.Value = RandomizeStats(70, 89);
                    diveCollect_numericUpDown.Value = RandomizeStats(60, 80);
                    tackle_numericUpDown.Value = RandomizeStats(55, 70);
                    driveTackle_numericUpDown.Value = RandomizeStats(50, 78);
                    diveTackle_numericUpDown.Value = RandomizeStats(50, 70);
                    impactTackle_numericUpDown.Value = RandomizeStats(50, 70);
                }
                if (Level == 2)
                {
                    Strength_numericUpDown.Value = RandomizeStats(55, 75);
                    Agility_numericUpDown.Value = RandomizeStats(60, 75);
                    Stamina_numericUpDown.Value = RandomizeStats(60, 70);
                    Acceleration_numericUpDown.Value = RandomizeStats(58, 82);
                    Discipline_numericUpDown.Value = RandomizeStats(60, 70);
                    Durability_numericUpDown.Value = RandomizeStats(60, 70);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(60, 82);
                    grubberKick_numericUpDown.Value = RandomizeStats(50, 65);
                    puntKick_numericUpDown.Value = RandomizeStats(40, 55);
                    chipKick_numericUpDown.Value = RandomizeStats(40, 60);
                    bombKick_numericUpDown.Value = RandomizeStats(40, 55);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(40, 55);
                    placeKick_numericUpDown.Value = RandomizeStats(40, 55);
                    basicPass_numericUpDown.Value = RandomizeStats(50, 60);
                    longPass_numericUpDown.Value = RandomizeStats(45, 60);
                    offload_numericUpDown.Value = RandomizeStats(50, 60);
                    dummyPass_numericUpDown.Value = RandomizeStats(45, 60);
                    fend_numericUpDown.Value = RandomizeStats(50, 70);
                    sideStep_numericUpDown.Value = RandomizeStats(60, 79);
                    breakTackle_numericUpDown.Value = RandomizeStats(60, 79);
                    contestedCollect_numericUpDown.Value = RandomizeStats(60, 79);
                    diveCollect_numericUpDown.Value = RandomizeStats(50, 70);
                    tackle_numericUpDown.Value = RandomizeStats(45, 60);
                    driveTackle_numericUpDown.Value = RandomizeStats(40, 60);
                    diveTackle_numericUpDown.Value = RandomizeStats(40, 60);
                    impactTackle_numericUpDown.Value = RandomizeStats(40, 60);
                }
            }
            else if (Role == 3 || Role == 4 || Role == 6)
            {
                if (Level == 0)
                {
                    Strength_numericUpDown.Value = RandomizeStats(75, 95);
                    Agility_numericUpDown.Value = RandomizeStats(80, 95);
                    Stamina_numericUpDown.Value = RandomizeStats(80, 95);
                    Acceleration_numericUpDown.Value = RandomizeStats(82, 95);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 95);
                    Durability_numericUpDown.Value = RandomizeStats(80, 95);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(80, 95);
                    grubberKick_numericUpDown.Value = RandomizeStats(85, 99);
                    puntKick_numericUpDown.Value = RandomizeStats(85, 99);
                    chipKick_numericUpDown.Value = RandomizeStats(85, 99);
                    bombKick_numericUpDown.Value = RandomizeStats(85, 99);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(85, 99);
                    placeKick_numericUpDown.Value = RandomizeStats(85, 99);
                    basicPass_numericUpDown.Value = RandomizeStats(86, 99);
                    longPass_numericUpDown.Value = RandomizeStats(86, 99);
                    offload_numericUpDown.Value = RandomizeStats(80, 96);
                    dummyPass_numericUpDown.Value = RandomizeStats(85, 99);
                    fend_numericUpDown.Value = RandomizeStats(75, 85);
                    sideStep_numericUpDown.Value = RandomizeStats(80, 95);
                    breakTackle_numericUpDown.Value = RandomizeStats(70, 88);
                    contestedCollect_numericUpDown.Value = RandomizeStats(80, 90);
                    diveCollect_numericUpDown.Value = RandomizeStats(80, 90);
                    tackle_numericUpDown.Value = RandomizeStats(78, 92);
                    driveTackle_numericUpDown.Value = RandomizeStats(75, 88);
                    diveTackle_numericUpDown.Value = RandomizeStats(70, 88);
                    impactTackle_numericUpDown.Value = RandomizeStats(70, 88);
                }
                if (Level == 1)
                {
                    Strength_numericUpDown.Value = RandomizeStats(65, 85);
                    Agility_numericUpDown.Value = RandomizeStats(70, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(70, 85);
                    Acceleration_numericUpDown.Value = RandomizeStats(72, 85);
                    Discipline_numericUpDown.Value = RandomizeStats(70, 85);
                    Durability_numericUpDown.Value = RandomizeStats(70, 85);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(70, 85);
                    grubberKick_numericUpDown.Value = RandomizeStats(75, 89);
                    puntKick_numericUpDown.Value = RandomizeStats(75, 89);
                    chipKick_numericUpDown.Value = RandomizeStats(75, 89);
                    bombKick_numericUpDown.Value = RandomizeStats(75, 89);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(75, 89);
                    placeKick_numericUpDown.Value = RandomizeStats(75, 89);
                    basicPass_numericUpDown.Value = RandomizeStats(76, 89);
                    longPass_numericUpDown.Value = RandomizeStats(76, 89);
                    offload_numericUpDown.Value = RandomizeStats(70, 86);
                    dummyPass_numericUpDown.Value = RandomizeStats(75, 89);
                    fend_numericUpDown.Value = RandomizeStats(65, 75);
                    sideStep_numericUpDown.Value = RandomizeStats(70, 85);
                    breakTackle_numericUpDown.Value = RandomizeStats(60, 78);
                    contestedCollect_numericUpDown.Value = RandomizeStats(70, 80);
                    diveCollect_numericUpDown.Value = RandomizeStats(70, 80);
                    tackle_numericUpDown.Value = RandomizeStats(68, 82);
                    driveTackle_numericUpDown.Value = RandomizeStats(65, 78);
                    diveTackle_numericUpDown.Value = RandomizeStats(60, 78);
                    impactTackle_numericUpDown.Value = RandomizeStats(60, 78);
                }
                if (Level == 2)
                {
                    Strength_numericUpDown.Value = RandomizeStats(55, 75);
                    Agility_numericUpDown.Value = RandomizeStats(60, 75);
                    Stamina_numericUpDown.Value = RandomizeStats(60, 75);
                    Acceleration_numericUpDown.Value = RandomizeStats(62, 75);
                    Discipline_numericUpDown.Value = RandomizeStats(60, 75);
                    Durability_numericUpDown.Value = RandomizeStats(60, 75);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(60, 75);
                    grubberKick_numericUpDown.Value = RandomizeStats(65, 79);
                    puntKick_numericUpDown.Value = RandomizeStats(75, 82);
                    chipKick_numericUpDown.Value = RandomizeStats(75, 82);
                    bombKick_numericUpDown.Value = RandomizeStats(75, 82);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(75, 81);
                    placeKick_numericUpDown.Value = RandomizeStats(75, 82);
                    basicPass_numericUpDown.Value = RandomizeStats(76, 85);
                    longPass_numericUpDown.Value = RandomizeStats(76, 85);
                    offload_numericUpDown.Value = RandomizeStats(60, 76);
                    dummyPass_numericUpDown.Value = RandomizeStats(75, 85);
                    fend_numericUpDown.Value = RandomizeStats(60, 70);
                    sideStep_numericUpDown.Value = RandomizeStats(70, 80);
                    breakTackle_numericUpDown.Value = RandomizeStats(60, 70);
                    contestedCollect_numericUpDown.Value = RandomizeStats(60, 70);
                    diveCollect_numericUpDown.Value = RandomizeStats(60, 70);
                    tackle_numericUpDown.Value = RandomizeStats(58, 72);
                    driveTackle_numericUpDown.Value = RandomizeStats(55, 68);
                    diveTackle_numericUpDown.Value = RandomizeStats(50, 68);
                    impactTackle_numericUpDown.Value = RandomizeStats(50, 68);
                }
            }
            else if (Role == 5)
            {
                if (Level == 0)
                {
                    Strength_numericUpDown.Value = RandomizeStats(85, 99);
                    Agility_numericUpDown.Value = RandomizeStats(85, 95);
                    Stamina_numericUpDown.Value = RandomizeStats(70, 90);
                    Acceleration_numericUpDown.Value = RandomizeStats(70, 85);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 90);
                    Durability_numericUpDown.Value = RandomizeStats(75, 85);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(75, 85);
                    grubberKick_numericUpDown.Value = RandomizeStats(45, 60);
                    puntKick_numericUpDown.Value = RandomizeStats(45, 60);
                    chipKick_numericUpDown.Value = RandomizeStats(50, 70);
                    bombKick_numericUpDown.Value = RandomizeStats(45, 60);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(45, 60);
                    placeKick_numericUpDown.Value = RandomizeStats(45, 60);
                    basicPass_numericUpDown.Value = RandomizeStats(75, 85);
                    longPass_numericUpDown.Value = RandomizeStats(75, 85);
                    offload_numericUpDown.Value = RandomizeStats(85, 99);
                    dummyPass_numericUpDown.Value = RandomizeStats(70, 80);
                    fend_numericUpDown.Value = RandomizeStats(85, 99);
                    sideStep_numericUpDown.Value = RandomizeStats(70, 80);
                    breakTackle_numericUpDown.Value = RandomizeStats(80, 99);
                    contestedCollect_numericUpDown.Value = RandomizeStats(60, 75);
                    diveCollect_numericUpDown.Value = RandomizeStats(60, 75);
                    tackle_numericUpDown.Value = RandomizeStats(85, 99);
                    driveTackle_numericUpDown.Value = RandomizeStats(85, 99);
                    diveTackle_numericUpDown.Value = RandomizeStats(80, 90);
                    impactTackle_numericUpDown.Value = RandomizeStats(85, 99);
                }
                if (Level == 1)
                {
                    Strength_numericUpDown.Value = RandomizeStats(75, 89);
                    Agility_numericUpDown.Value = RandomizeStats(75, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(60, 80);
                    Acceleration_numericUpDown.Value = RandomizeStats(60, 75);
                    Discipline_numericUpDown.Value = RandomizeStats(70, 80);
                    Durability_numericUpDown.Value = RandomizeStats(65, 75);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(65, 75);
                    grubberKick_numericUpDown.Value = RandomizeStats(35, 50);
                    puntKick_numericUpDown.Value = RandomizeStats(35, 50);
                    chipKick_numericUpDown.Value = RandomizeStats(35, 50);
                    bombKick_numericUpDown.Value = RandomizeStats(35, 50);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(35, 50);
                    placeKick_numericUpDown.Value = RandomizeStats(35, 50);
                    basicPass_numericUpDown.Value = RandomizeStats(65, 75);
                    longPass_numericUpDown.Value = RandomizeStats(65, 75);
                    offload_numericUpDown.Value = RandomizeStats(75, 89);
                    dummyPass_numericUpDown.Value = RandomizeStats(60, 70);
                    fend_numericUpDown.Value = RandomizeStats(75, 89);
                    sideStep_numericUpDown.Value = RandomizeStats(60, 70);
                    breakTackle_numericUpDown.Value = RandomizeStats(70, 89);
                    contestedCollect_numericUpDown.Value = RandomizeStats(50, 65);
                    diveCollect_numericUpDown.Value = RandomizeStats(40, 65);
                    tackle_numericUpDown.Value = RandomizeStats(75, 89);
                    driveTackle_numericUpDown.Value = RandomizeStats(75, 89);
                    diveTackle_numericUpDown.Value = RandomizeStats(70, 80);
                    impactTackle_numericUpDown.Value = RandomizeStats(75, 89);
                }
                if (Level == 2)
                {
                    Strength_numericUpDown.Value = RandomizeStats(65, 79);
                    Agility_numericUpDown.Value = RandomizeStats(65, 75);
                    Stamina_numericUpDown.Value = RandomizeStats(50, 70);
                    Acceleration_numericUpDown.Value = RandomizeStats(50, 65);
                    Discipline_numericUpDown.Value = RandomizeStats(60, 70);
                    Durability_numericUpDown.Value = RandomizeStats(55, 65);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(55, 65);
                    grubberKick_numericUpDown.Value = RandomizeStats(30, 40);
                    puntKick_numericUpDown.Value = RandomizeStats(30, 40);
                    chipKick_numericUpDown.Value = RandomizeStats(30, 40);
                    bombKick_numericUpDown.Value = RandomizeStats(30, 40);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(30, 40);
                    placeKick_numericUpDown.Value = RandomizeStats(30, 40);
                    basicPass_numericUpDown.Value = RandomizeStats(55, 65);
                    longPass_numericUpDown.Value = RandomizeStats(55, 65);
                    offload_numericUpDown.Value = RandomizeStats(65, 79);
                    dummyPass_numericUpDown.Value = RandomizeStats(50, 60);
                    fend_numericUpDown.Value = RandomizeStats(65, 79);
                    sideStep_numericUpDown.Value = RandomizeStats(50, 60);
                    breakTackle_numericUpDown.Value = RandomizeStats(60, 79);
                    contestedCollect_numericUpDown.Value = RandomizeStats(40, 55);
                    diveCollect_numericUpDown.Value = RandomizeStats(30, 55);
                    tackle_numericUpDown.Value = RandomizeStats(65, 79);
                    driveTackle_numericUpDown.Value = RandomizeStats(65, 79);
                    diveTackle_numericUpDown.Value = RandomizeStats(60, 70);
                    impactTackle_numericUpDown.Value = RandomizeStats(65, 79);
                }
            }
            else if (Role == 7 || Role == 8)
            {
                if (Level == 0)
                {
                    Strength_numericUpDown.Value = RandomizeStats(85, 99);
                    Agility_numericUpDown.Value = RandomizeStats(85, 95);
                    Stamina_numericUpDown.Value = RandomizeStats(75, 90);
                    Acceleration_numericUpDown.Value = RandomizeStats(75, 90);
                    Discipline_numericUpDown.Value = RandomizeStats(80, 90);
                    Durability_numericUpDown.Value = RandomizeStats(75, 85);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(75, 90);
                    grubberKick_numericUpDown.Value = RandomizeStats(45, 60);
                    puntKick_numericUpDown.Value = RandomizeStats(45, 60);
                    chipKick_numericUpDown.Value = RandomizeStats(50, 70);
                    bombKick_numericUpDown.Value = RandomizeStats(45, 60);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(45, 60);
                    placeKick_numericUpDown.Value = RandomizeStats(60, 70);
                    basicPass_numericUpDown.Value = RandomizeStats(80, 90);
                    longPass_numericUpDown.Value = RandomizeStats(75, 85);
                    offload_numericUpDown.Value = RandomizeStats(85, 99);
                    dummyPass_numericUpDown.Value = RandomizeStats(70, 80);
                    fend_numericUpDown.Value = RandomizeStats(85, 99);
                    sideStep_numericUpDown.Value = RandomizeStats(75, 90);
                    breakTackle_numericUpDown.Value = RandomizeStats(80, 99);
                    contestedCollect_numericUpDown.Value = RandomizeStats(60, 75);
                    diveCollect_numericUpDown.Value = RandomizeStats(60, 75);
                    tackle_numericUpDown.Value = RandomizeStats(85, 99);
                    driveTackle_numericUpDown.Value = RandomizeStats(85, 99);
                    diveTackle_numericUpDown.Value = RandomizeStats(80, 95);
                    impactTackle_numericUpDown.Value = RandomizeStats(85, 99);
                }
                if (Level == 1)
                {
                    Strength_numericUpDown.Value = RandomizeStats(75, 89);
                    Agility_numericUpDown.Value = RandomizeStats(75, 85);
                    Stamina_numericUpDown.Value = RandomizeStats(70, 85);
                    Acceleration_numericUpDown.Value = RandomizeStats(65, 80);
                    Discipline_numericUpDown.Value = RandomizeStats(70, 80);
                    Durability_numericUpDown.Value = RandomizeStats(65, 75);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(70, 80);
                    grubberKick_numericUpDown.Value = RandomizeStats(35, 50);
                    puntKick_numericUpDown.Value = RandomizeStats(35, 50);
                    chipKick_numericUpDown.Value = RandomizeStats(35, 50);
                    bombKick_numericUpDown.Value = RandomizeStats(35, 50);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(35, 50);
                    placeKick_numericUpDown.Value = RandomizeStats(35, 50);
                    basicPass_numericUpDown.Value = RandomizeStats(65, 75);
                    longPass_numericUpDown.Value = RandomizeStats(65, 75);
                    offload_numericUpDown.Value = RandomizeStats(75, 89);
                    dummyPass_numericUpDown.Value = RandomizeStats(60, 70);
                    fend_numericUpDown.Value = RandomizeStats(75, 89);
                    sideStep_numericUpDown.Value = RandomizeStats(65, 75);
                    breakTackle_numericUpDown.Value = RandomizeStats(70, 89);
                    contestedCollect_numericUpDown.Value = RandomizeStats(50, 65);
                    diveCollect_numericUpDown.Value = RandomizeStats(40, 65);
                    tackle_numericUpDown.Value = RandomizeStats(75, 89);
                    driveTackle_numericUpDown.Value = RandomizeStats(75, 89);
                    diveTackle_numericUpDown.Value = RandomizeStats(70, 80);
                    impactTackle_numericUpDown.Value = RandomizeStats(75, 89);
                }
                if (Level == 2)
                {
                    Strength_numericUpDown.Value = RandomizeStats(65, 79);
                    Agility_numericUpDown.Value = RandomizeStats(65, 75);
                    Stamina_numericUpDown.Value = RandomizeStats(50, 70);
                    Acceleration_numericUpDown.Value = RandomizeStats(55, 70);
                    Discipline_numericUpDown.Value = RandomizeStats(60, 70);
                    Durability_numericUpDown.Value = RandomizeStats(55, 65);
                    SprintSpeed_numericUpDown.Value = RandomizeStats(60, 70);
                    grubberKick_numericUpDown.Value = RandomizeStats(30, 40);
                    puntKick_numericUpDown.Value = RandomizeStats(30, 40);
                    chipKick_numericUpDown.Value = RandomizeStats(30, 40);
                    bombKick_numericUpDown.Value = RandomizeStats(30, 40);
                    fieldgoalKick_numericUpDown.Value = RandomizeStats(30, 40);
                    placeKick_numericUpDown.Value = RandomizeStats(30, 40);
                    basicPass_numericUpDown.Value = RandomizeStats(60, 70);
                    longPass_numericUpDown.Value = RandomizeStats(55, 65);
                    offload_numericUpDown.Value = RandomizeStats(65, 79);
                    dummyPass_numericUpDown.Value = RandomizeStats(50, 60);
                    fend_numericUpDown.Value = RandomizeStats(65, 79);
                    sideStep_numericUpDown.Value = RandomizeStats(55, 65);
                    breakTackle_numericUpDown.Value = RandomizeStats(60, 79);
                    contestedCollect_numericUpDown.Value = RandomizeStats(40, 55);
                    diveCollect_numericUpDown.Value = RandomizeStats(30, 55);
                    tackle_numericUpDown.Value = RandomizeStats(65, 79);
                    driveTackle_numericUpDown.Value = RandomizeStats(65, 79);
                    diveTackle_numericUpDown.Value = RandomizeStats(60, 70);
                    impactTackle_numericUpDown.Value = RandomizeStats(65, 79);
                }
            }
        }
    }
}