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

        private int PlayerIndex = 0;
        private Random? random = null;
        private Dialogue_Wildcardhash.WildcardHash[]? commentaryNameHash = null;

        private void Player_Editor_Load(object sender, EventArgs e)
        {
            Player_Index_textBox.Text = Global.player_index.ToString();
            PlayerIndex = Global.player_index;
            Player_ID_textBox.Text = Global.player[PlayerIndex].id.ToString();

            Preferred_Hand_comboBox.SelectedIndex = Global.player[PlayerIndex].preferredHand;
            Preferred_Foot_comboBox.SelectedIndex = Global.player[PlayerIndex].preferredFoot;

            First_Name_textBox.Text = Global.player[PlayerIndex].firstName;
            Last_Name_textBox.Text = Global.player[PlayerIndex].lastName;

            licensed_checkBox.Checked = Global.player[PlayerIndex].licensed;
            Hidden_checkBox.Checked = Global.player[PlayerIndex].hidden;

            string commentaryDataPath = Global.currentPath + @"\commentary_data\";

            commentaryNameHash = CommentaryHashes.Read(commentaryDataPath + "dialogue_wildcardhash_surnames");

            string[] commNames = new string[commentaryNameHash.Length];

            for (int i = 0; i < commentaryNameHash.Length; i++)
            {
                commNames[i] = commentaryNameHash[i].name.ToTitleCase();
            }

            commentaryNameHash_comboBox.Items.AddRange(commNames);
            int commentaryIndex = CommentaryHashes.GetHashes(Global.player[PlayerIndex].commentaryNameHash, commentaryNameHash);

            if (commentaryIndex != -1)
                commentaryNameHash_comboBox.SelectedIndex = commentaryIndex;
            else
                commentaryNameHash_comboBox.SelectedIndex = 0;

            club_textBox.Text = Global.player[PlayerIndex].club.ToString();

            PlayerGender_textBox.Text = "Male";
            PlayerGenderImage_label.Image = Properties.Resources.Male;

            if (Global.player[PlayerIndex].gender == 1)
            {
                PlayerGender_textBox.Text = "Female";
                PlayerGenderImage_label.Image = Properties.Resources.Female;
            }

            Day_numericUpDown.Value = Global.player[PlayerIndex].dob.day;
            Month_numericUpDown.Value = Global.player[PlayerIndex].dob.month;
            Year_numericUpDown.Value = Global.player[PlayerIndex].dob.year;

            if (Global.player[PlayerIndex].jerseyNumber < 1 || Global.player[PlayerIndex].jerseyNumber > 99)
                Jersey_Number_numericUpDown.Value = 1;
            else
                Jersey_Number_numericUpDown.Value = Global.player[PlayerIndex].jerseyNumber;

            slJerseyNumber_checkBox.Checked = Global.player[PlayerIndex].isJerseyNumber;
            isWordCup_checkBox.Checked = Global.player[PlayerIndex].WorldCup;
            Jersey_Name_textBox.Text = Global.player[PlayerIndex].jerseyName;

            Primary_Role_comboBox.SelectedIndex = Global.player[PlayerIndex].primaryRole;
            Secondary_Role_comboBox.SelectedIndex = Global.player[PlayerIndex].secondaryRole;
            Tertiary_Role_comboBox.SelectedIndex = Global.player[PlayerIndex].tertiaryRole;

            Representative_Country_comboBox.Items.AddRange(StringArrays.RepCountry);
            Country_Of_Birth_comboBox.Items.AddRange(StringArrays.CountryOfBirth);
            Representative_Country_comboBox.SelectedIndex = Global.player[PlayerIndex].repCountry;
            Country_Of_Birth_comboBox.SelectedIndex = Global.player[PlayerIndex].countryOfBirth;

            int SOO_ID = Global.player[PlayerIndex].stateOfOrigin;

            if (SOO_ID == 0 || SOO_ID == 196)
                SOO_comboBox.SelectedIndex = 0;
            else if (SOO_ID == 197)
                SOO_comboBox.SelectedIndex = 1;
            else if (SOO_ID == 198)
                SOO_comboBox.SelectedIndex = 2;

            originRepNumber_numericUpDown.Value = Global.player[PlayerIndex].originRepNumber;
            originOtherNumber_numericUpDown.Value = Global.player[PlayerIndex].originOtherNumber;

            int CVC_ID = Global.player[PlayerIndex].cityVsCountry;

            if (CVC_ID == 0 || CVC_ID == 199)
                CVC_comboBox.SelectedIndex = 0;
            else if (CVC_ID == 200)
                CVC_comboBox.SelectedIndex = 1;
            else if (CVC_ID == 201)
                CVC_comboBox.SelectedIndex = 2;

            int Allstars_ID = Global.player[PlayerIndex].allStars;

            if (Allstars_ID == 0 || Allstars_ID == 202)
                Allstars_comboBox.SelectedIndex = 0;
            else if (Allstars_ID == 203)
                Allstars_comboBox.SelectedIndex = 1;
            else if (Allstars_ID == 204)
                Allstars_comboBox.SelectedIndex = 2;

            Height_numericUpDown.Value = Global.player[PlayerIndex].appearance.height;
            Weight_numericUpDown.Value = Global.player[PlayerIndex].appearance.weight;

            if (Global.player[PlayerIndex].isContractExpiry == false || Global.player[PlayerIndex].contractExpiry == 0)
                ContractExpiry_comboBox.SelectedIndex = 26;
            else
                ContractExpiry_comboBox.Text = Global.player[PlayerIndex].contractExpiry.ToString();

            Reputation_numericUpDown.Value = Global.player[PlayerIndex].attributes.reputation;
            Ego_numericUpDown.Value = Global.player[PlayerIndex].attributes.ego;
            Loyalty_numericUpDown.Value = Global.player[PlayerIndex].attributes.loyalty;

            Strength_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.strength;
            Agility_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.agility;
            Fitness_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.fitness;
            Acceleration_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.acceleration;
            Discipline_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.discipline;
            Durability_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.durability;
            SprintSpeed_numericUpDown.Value = Global.player[PlayerIndex].technicalAbility.sprintSpeed;

            if (Global.player[PlayerIndex].attributes.isPerk == false || Global.player[PlayerIndex].attributes.perk == 0)
                Perks_comboBox.SelectedIndex = 0;
            else
                Perks_comboBox.SelectedIndex = Global.player[PlayerIndex].attributes.perk;

            grubberKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.grubberKick;
            puntKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.puntKick;
            chipKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.chipKick;
            bombKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.bombKick;
            fieldgoalKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.fieldgoalKick;
            placeKick_numericUpDown.Value = Global.player[PlayerIndex].skills.kickingSkills.placeKick;

            basicPass_numericUpDown.Value = Global.player[PlayerIndex].skills.passingSkills.basicPass;
            longPass_numericUpDown.Value = Global.player[PlayerIndex].skills.passingSkills.longPass;
            offload_numericUpDown.Value = Global.player[PlayerIndex].skills.passingSkills.offload;

            dummyPass_numericUpDown.Value = Global.player[PlayerIndex].skills.evasionSkills.dummyPass;
            fend_numericUpDown.Value = Global.player[PlayerIndex].skills.evasionSkills.fend;
            sideStep_numericUpDown.Value = Global.player[PlayerIndex].skills.evasionSkills.sideStep;
            breakTackle_numericUpDown.Value = Global.player[PlayerIndex].skills.evasionSkills.breakTackle;

            tackle_numericUpDown.Value = Global.player[PlayerIndex].skills.tackleSkills.tackle;
            driveTackle_numericUpDown.Value = Global.player[PlayerIndex].skills.tackleSkills.driveTackle;
            diveTackle_numericUpDown.Value = Global.player[PlayerIndex].skills.tackleSkills.diveTackle;
            impactTackle_numericUpDown.Value = Global.player[PlayerIndex].skills.tackleSkills.impactTackle;

            contestedCollect_numericUpDown.Value = Global.player[PlayerIndex].skills.miscSkills.contestedCollect;
            diveCollect_numericUpDown.Value = Global.player[PlayerIndex].skills.miscSkills.diveCollect;
            ballStrip_numericUpDown.Value = Global.player[PlayerIndex].skills.miscSkills.ballStrip;

            nrlcareerappearances_numericUpDown.Value = Global.player[PlayerIndex].nrlStats.appearances;
            nrlcareertriesscored_numericUpDown.Value = Global.player[PlayerIndex].nrlStats.triesScored;
            nrlcareergoals_numericUpDown.Value = Global.player[PlayerIndex].nrlStats.goals;
            nrlcareergoalsattempted_numericUpDown.Value = Global.player[PlayerIndex].nrlStats.goalsAttempted;
            nrlcareerpoints_numericUpDown.Value = Global.player[PlayerIndex].nrlStats.points;

            SLcareerappearances_numericUpDown.Value = Global.player[PlayerIndex].slStats.appearances;
            SLcareertriesscored_numericUpDown.Value = Global.player[PlayerIndex].slStats.triesScored;
            SLcareergoals_numericUpDown.Value = Global.player[PlayerIndex].slStats.goals;
            SLcareergoalsattempted_numericUpDown.Value = Global.player[PlayerIndex].slStats.goalsAttempted;
            SLcareerpoints_numericUpDown.Value = Global.player[PlayerIndex].slStats.points;

            StadardMatchEnabled_checkBox.Checked = Global.player[PlayerIndex].isStandardStats;

            if (StadardMatchEnabled_checkBox.Checked)
            {
                Stries_numericUpDown.Value = Global.player[PlayerIndex].standardStats.tries;
                StryAssists_numericUpDown.Value = Global.player[PlayerIndex].standardStats.tryAssists;
                SfieldGoalAttempts_numericUpDown.Value = Global.player[PlayerIndex].standardStats.fieldGoalAttempts;
                StackleBreaks_numericUpDown.Value = Global.player[PlayerIndex].standardStats.tackleBreaks;
                SpenaltyGoalAttempts_numericUpDown.Value = Global.player[PlayerIndex].standardStats.penaltyGoalAttempts;
                Sruns_numericUpDown.Value = Global.player[PlayerIndex].standardStats.runs;
                SballStrips_numericUpDown.Value = Global.player[PlayerIndex].standardStats.ballStrips;
                SfieldGoals_numericUpDown.Value = Global.player[PlayerIndex].standardStats.fieldGoals;
                SmatchesPlayed_numericUpDown.Value = Global.player[PlayerIndex].standardStats.matchesPlayed;
                SmatchesWon_numericUpDown.Value = Global.player[PlayerIndex].standardStats.matchesWon;
                SmetresRun_numericUpDown.Value = Global.player[PlayerIndex].standardStats.metresRun;
                Sinterceptions_numericUpDown.Value = Global.player[PlayerIndex].standardStats.interceptions;
                SfortyTwenties_numericUpDown.Value = Global.player[PlayerIndex].standardStats.fortyTwenties;
                SinterceptedPasses_numericUpDown.Value = Global.player[PlayerIndex].standardStats.interceptedPasses;
                Sfends_numericUpDown.Value = Global.player[PlayerIndex].standardStats.fends;
                Stackles_numericUpDown.Value = Global.player[PlayerIndex].standardStats.tackles;
                ShandlingErrors_numericUpDown.Value = Global.player[PlayerIndex].standardStats.handlingErrors;
                Shitups_numericUpDown.Value = Global.player[PlayerIndex].standardStats.hitups;
                Sconversions_numericUpDown.Value = Global.player[PlayerIndex].standardStats.conversions;
                SmatchesDrawn_numericUpDown.Value = Global.player[PlayerIndex].standardStats.matchesDrawn;
                SmissedTackles_numericUpDown.Value = Global.player[PlayerIndex].standardStats.missedTackles;
                SpenaltiesConceded_numericUpDown.Value = Global.player[PlayerIndex].standardStats.penaltiesConceded;
                SlineBreakAssists_numericUpDown.Value = Global.player[PlayerIndex].standardStats.lineBreakAssists;
                SconversionAttempts_numericUpDown.Value = Global.player[PlayerIndex].standardStats.conversionAttempts;
                SoneOnOneTackles_numericUpDown.Value = Global.player[PlayerIndex].standardStats.oneOnOneTackles;
                SminutesPlayed_numericUpDown.Value = Global.player[PlayerIndex].standardStats.minutesPlayed;
                Spasses_numericUpDown.Value = Global.player[PlayerIndex].standardStats.passes;
                SkicksInPlay_numericUpDown.Value = Global.player[PlayerIndex].standardStats.kicksInPlay;
                SkickMetresGained_numericUpDown.Value = Global.player[PlayerIndex].standardStats.kickMetresGained;
                SlineBreaks_numericUpDown.Value = Global.player[PlayerIndex].standardStats.lineBreaks;
                Soffloads_numericUpDown.Value = Global.player[PlayerIndex].standardStats.offloads;
                SknockOns_numericUpDown.Value = Global.player[PlayerIndex].standardStats.knockOns;
                SpenaltyGoals_numericUpDown.Value = Global.player[PlayerIndex].standardStats.penaltyGoals;
            }

            NinesMatchEnabled_checkBox.Checked = Global.player[PlayerIndex].isNinesStats;

            if (NinesMatchEnabled_checkBox.Checked)
            {
                Ntries_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.tries;
                NtryAssists_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.tryAssists;
                NfieldGoalAttempts_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.fieldGoalAttempts;
                NtackleBreaks_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.tackleBreaks;
                NpenaltyGoalAttempts_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.penaltyGoalAttempts;
                Nruns_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.runs;
                NballStrips_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.ballStrips;
                NfieldGoals_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.fieldGoals;
                NmatchesPlayed_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.matchesPlayed;
                NmatchesWon_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.matchesWon;
                NmetresRun_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.metresRun;
                Ninterceptions_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.interceptions;
                NbonusTries_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.bonusTries;
                NfortyTwenties_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.fortyTwenties;
                NinterceptedPasses_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.interceptedPasses;
                Nfends_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.fends;
                Ntackles_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.tackles;
                NhandlingErrors_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.handlingErrors;
                Nhitups_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.hitups;
                Nconversions_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.conversions;
                NmatchesDrawn_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.matchesDrawn;
                NmissedTackles_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.missedTackles;
                NpenaltiesConceded_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.penaltiesConceded;
                NlineBreakAssists_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.lineBreakAssists;
                NconversionAttempts_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.conversionAttempts;
                NoneOnOneTackles_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.oneOnOneTackles;
                NminutesPlayed_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.minutesPlayed;
                Npasses_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.passes;
                NkicksInPlay_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.kicksInPlay;
                NkickMetresGained_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.kickMetresGained;
                NlineBreaks_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.lineBreaks;
                Noffloads_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.offloads;
                NknockOns_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.knockOns;
                NpenaltyGoals_numericUpDown.Value = Global.player[PlayerIndex].ninesStats.penaltyGoals;
            }

            int playerRating = PlayerRating();
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

            Global.player[PlayerIndex].id = Convert.ToInt32(Player_ID_textBox.Text);
            Global.player[PlayerIndex].isPreferredHand = true;
            Global.player[PlayerIndex].preferredHand = Convert.ToByte(Preferred_Hand_comboBox.SelectedIndex);
            Global.player[PlayerIndex].isPreferredFoot = true;
            Global.player[PlayerIndex].preferredFoot = Convert.ToByte(Preferred_Foot_comboBox.SelectedIndex);

            Global.player[PlayerIndex].dob.day = Convert.ToInt32(Day_numericUpDown.Value);
            Global.player[PlayerIndex].dob.month = Convert.ToInt32(Month_numericUpDown.Value);
            Global.player[PlayerIndex].dob.year = Convert.ToInt32(Year_numericUpDown.Value);

            Global.player[PlayerIndex].firstNameSize = Convert.ToByte(First_Name_textBox.Text.Length);
            Global.player[PlayerIndex].firstName = First_Name_textBox.Text;
            Global.player[PlayerIndex].lastNameSize = Convert.ToByte(Last_Name_textBox.Text.Length);
            Global.player[PlayerIndex].lastName = Last_Name_textBox.Text;

            if (Convert.ToInt32(club_textBox.Text) == 0)
            {
                Global.player[PlayerIndex].isClub = false;
                Global.player[PlayerIndex].club = 0;
            }
            else
            {
                Global.player[PlayerIndex].isClub = true;
                Global.player[PlayerIndex].club = Convert.ToInt32(club_textBox.Text);
            }

            Global.player[PlayerIndex].isLicensed = licensed_checkBox.Checked;
            Global.player[PlayerIndex].licensed = licensed_checkBox.Checked;

            Global.player[PlayerIndex].isHidden = Hidden_checkBox.Checked;
            Global.player[PlayerIndex].hidden = Hidden_checkBox.Checked;

            Global.player[PlayerIndex].isCommentaryNameHash = true;

            if (commentaryNameHash != null)
            {
                uint commNameHash = CommentaryHashes.SetHashes(commentaryNameHash_comboBox.Text.ToLower(), commentaryNameHash);
                Global.player[PlayerIndex].commentaryNameHash = commNameHash;
            }

            Global.player[PlayerIndex].isWorldCup = isWordCup_checkBox.Checked;
            Global.player[PlayerIndex].WorldCup = isWordCup_checkBox.Checked;

            Global.player[PlayerIndex].jerseyNameSize = Convert.ToByte(Jersey_Name_textBox.Text.Length);
            Global.player[PlayerIndex].jerseyName = Jersey_Name_textBox.Text;

            Global.player[PlayerIndex].isJerseyNumber = slJerseyNumber_checkBox.Checked;
            Global.player[PlayerIndex].jerseyNumber = Convert.ToInt32(Jersey_Number_numericUpDown.Value);

            Global.player[PlayerIndex].isPrimaryRole = true;
            Global.player[PlayerIndex].primaryRole = Convert.ToInt32(Primary_Role_comboBox.SelectedIndex);
            Global.player[PlayerIndex].isSecondaryRole = true;
            Global.player[PlayerIndex].secondaryRole = Convert.ToInt32(Secondary_Role_comboBox.SelectedIndex);
            Global.player[PlayerIndex].isTertiaryRole = true;
            Global.player[PlayerIndex].tertiaryRole = Convert.ToInt32(Tertiary_Role_comboBox.SelectedIndex);

            Global.player[PlayerIndex].isStateOfOrigin = true;

            if (SOO_comboBox.SelectedIndex == 0)
            {
                Global.player[PlayerIndex].isStateOfOrigin = false;
                Global.player[PlayerIndex].stateOfOrigin = 196;
            }
            else if (SOO_comboBox.SelectedIndex == 1)
                Global.player[PlayerIndex].stateOfOrigin = 197;
            else if (SOO_comboBox.SelectedIndex == 2)
                Global.player[PlayerIndex].stateOfOrigin = 198;

            Global.player[PlayerIndex].isOriginRepNumber = true;
            Global.player[PlayerIndex].originRepNumber = Convert.ToInt32(originRepNumber_numericUpDown.Value);

            Global.player[PlayerIndex].isOriginOtherNumber = true;
            Global.player[PlayerIndex].originOtherNumber = Convert.ToInt32(originOtherNumber_numericUpDown.Value);

            Global.player[PlayerIndex].isCityVsCountry = true;

            if (CVC_comboBox.SelectedIndex == 0)
            {
                Global.player[PlayerIndex].isCityVsCountry = false;
                Global.player[PlayerIndex].cityVsCountry = 199;
            }
            else if (CVC_comboBox.SelectedIndex == 1)
                Global.player[PlayerIndex].cityVsCountry = 200;
            else if (CVC_comboBox.SelectedIndex == 2)
                Global.player[PlayerIndex].cityVsCountry = 201;

            Global.player[PlayerIndex].isAllStars = true;

            if (Allstars_comboBox.SelectedIndex == 0)
            {
                Global.player[PlayerIndex].isAllStars = false;
                Global.player[PlayerIndex].allStars = 202;
            }
            else if (Allstars_comboBox.SelectedIndex == 1)
                Global.player[PlayerIndex].allStars = 203;
            else if (Allstars_comboBox.SelectedIndex == 2)
                Global.player[PlayerIndex].allStars = 204;

            Global.player[PlayerIndex].isCountryOfBirth = true;
            Global.player[PlayerIndex].countryOfBirth = Country_Of_Birth_comboBox.SelectedIndex;

            Global.player[PlayerIndex].isRepCountry = true;
            Global.player[PlayerIndex].repCountry = Representative_Country_comboBox.SelectedIndex;

            Global.player[PlayerIndex].appearance.height = Convert.ToInt32(Height_numericUpDown.Value);
            Global.player[PlayerIndex].appearance.weight = Convert.ToInt32(Weight_numericUpDown.Value);

            Global.player[PlayerIndex].attributes.isReputation = true;
            Global.player[PlayerIndex].attributes.reputation = Convert.ToInt32(Reputation_numericUpDown.Value);
            Global.player[PlayerIndex].attributes.isEgo = true;
            Global.player[PlayerIndex].attributes.ego = Convert.ToInt32(Ego_numericUpDown.Value);
            Global.player[PlayerIndex].attributes.isLoyalty = true;
            Global.player[PlayerIndex].attributes.loyalty = Convert.ToInt32(Loyalty_numericUpDown.Value);

            if (Perks_comboBox.SelectedIndex == 0)
            {
                Global.player[PlayerIndex].attributes.isPerk = false;
                Global.player[PlayerIndex].attributes.perk = 0;
            }
            else
            {
                Global.player[PlayerIndex].attributes.isPerk = true;
                Global.player[PlayerIndex].attributes.perk = Perks_comboBox.SelectedIndex;
            }

            Global.player[PlayerIndex].technicalAbility.strength = Convert.ToInt32(Strength_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.agility = Convert.ToInt32(Agility_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.fitness = Convert.ToInt32(Fitness_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.acceleration = Convert.ToInt32(Acceleration_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.discipline = Convert.ToInt32(Discipline_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.durability = Convert.ToInt32(Durability_numericUpDown.Value);
            Global.player[PlayerIndex].technicalAbility.sprintSpeed = Convert.ToInt32(SprintSpeed_numericUpDown.Value);

            Global.player[PlayerIndex].skills.kickingSkills.grubberKick = Convert.ToInt32(grubberKick_numericUpDown.Value);
            Global.player[PlayerIndex].skills.kickingSkills.puntKick = Convert.ToInt32(puntKick_numericUpDown.Value);
            Global.player[PlayerIndex].skills.kickingSkills.chipKick = Convert.ToInt32(chipKick_numericUpDown.Value);
            Global.player[PlayerIndex].skills.kickingSkills.bombKick = Convert.ToInt32(bombKick_numericUpDown.Value);
            Global.player[PlayerIndex].skills.kickingSkills.fieldgoalKick = Convert.ToInt32(fieldgoalKick_numericUpDown.Value);
            Global.player[PlayerIndex].skills.kickingSkills.placeKick = Convert.ToInt32(placeKick_numericUpDown.Value);

            Global.player[PlayerIndex].skills.passingSkills.basicPass = Convert.ToInt32(basicPass_numericUpDown.Value);
            Global.player[PlayerIndex].skills.passingSkills.longPass = Convert.ToInt32(longPass_numericUpDown.Value);
            Global.player[PlayerIndex].skills.passingSkills.offload = Convert.ToInt32(offload_numericUpDown.Value);

            Global.player[PlayerIndex].skills.evasionSkills.dummyPass = Convert.ToInt32(dummyPass_numericUpDown.Value);
            Global.player[PlayerIndex].skills.evasionSkills.fend = Convert.ToInt32(fend_numericUpDown.Value);
            Global.player[PlayerIndex].skills.evasionSkills.sideStep = Convert.ToInt32(sideStep_numericUpDown.Value);
            Global.player[PlayerIndex].skills.evasionSkills.breakTackle = Convert.ToInt32(breakTackle_numericUpDown.Value);

            Global.player[PlayerIndex].skills.tackleSkills.tackle = Convert.ToInt32(tackle_numericUpDown.Value);
            Global.player[PlayerIndex].skills.tackleSkills.driveTackle = Convert.ToInt32(driveTackle_numericUpDown.Value);
            Global.player[PlayerIndex].skills.tackleSkills.diveTackle = Convert.ToInt32(diveTackle_numericUpDown.Value);
            Global.player[PlayerIndex].skills.tackleSkills.impactTackle = Convert.ToInt32(impactTackle_numericUpDown.Value);

            Global.player[PlayerIndex].skills.miscSkills.contestedCollect = Convert.ToInt32(contestedCollect_numericUpDown.Value);
            Global.player[PlayerIndex].skills.miscSkills.diveCollect = Convert.ToInt32(diveCollect_numericUpDown.Value);
            Global.player[PlayerIndex].skills.miscSkills.ballStrip = Convert.ToInt32(ballStrip_numericUpDown.Value);

            Global.player[PlayerIndex].nrlStats.appearances = Convert.ToInt32(nrlcareerappearances_numericUpDown.Value);
            Global.player[PlayerIndex].nrlStats.triesScored = Convert.ToInt32(nrlcareertriesscored_numericUpDown.Value);
            Global.player[PlayerIndex].nrlStats.goals = Convert.ToInt32(nrlcareergoals_numericUpDown.Value);
            Global.player[PlayerIndex].nrlStats.goalsAttempted = Convert.ToInt32(nrlcareergoalsattempted_numericUpDown.Value);
            Global.player[PlayerIndex].nrlStats.points = Convert.ToInt32(nrlcareerpoints_numericUpDown.Value);

            Global.player[PlayerIndex].slStats.appearances = Convert.ToInt32(SLcareerappearances_numericUpDown.Value);
            Global.player[PlayerIndex].slStats.triesScored = Convert.ToInt32(SLcareertriesscored_numericUpDown.Value);
            Global.player[PlayerIndex].slStats.goals = Convert.ToInt32(SLcareergoals_numericUpDown.Value);
            Global.player[PlayerIndex].slStats.goalsAttempted = Convert.ToInt32(SLcareergoalsattempted_numericUpDown.Value);
            Global.player[PlayerIndex].slStats.points = Convert.ToInt32(SLcareerpoints_numericUpDown.Value);

            if (StadardMatchEnabled_checkBox.Checked)
            {
                Global.player[PlayerIndex].isStandardStats = true;

                Global.player[PlayerIndex].standardStats.isMatchesPlayed = true;
                Global.player[PlayerIndex].standardStats.matchesPlayed = Convert.ToInt32(SmatchesPlayed_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isMatchesWon = true;
                Global.player[PlayerIndex].standardStats.matchesWon = Convert.ToInt32(SmatchesWon_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isMatchesDrawn = true;
                Global.player[PlayerIndex].standardStats.matchesDrawn = Convert.ToInt32(SmatchesDrawn_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isBallStrips = true;
                Global.player[PlayerIndex].standardStats.ballStrips = Convert.ToInt32(SballStrips_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isConversions = true;
                Global.player[PlayerIndex].standardStats.conversions = Convert.ToInt32(Sconversions_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isConversionAttempts = true;
                Global.player[PlayerIndex].standardStats.conversionAttempts = Convert.ToInt32(SconversionAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isFends = true;
                Global.player[PlayerIndex].standardStats.fends = Convert.ToInt32(Sfends_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isFieldGoalAttempts = true;
                Global.player[PlayerIndex].standardStats.fieldGoalAttempts = Convert.ToInt32(SfieldGoalAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isFieldGoals = true;
                Global.player[PlayerIndex].standardStats.fieldGoals = Convert.ToInt32(SfieldGoals_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isFortyTwenties = true;
                Global.player[PlayerIndex].standardStats.fortyTwenties = Convert.ToInt32(SfortyTwenties_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isHandlingErrors = true;
                Global.player[PlayerIndex].standardStats.handlingErrors = Convert.ToInt32(ShandlingErrors_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isHitups = true;
                Global.player[PlayerIndex].standardStats.hitups = Convert.ToInt32(Shitups_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isInterceptedPasses = true;
                Global.player[PlayerIndex].standardStats.interceptedPasses = Convert.ToInt32(SinterceptedPasses_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isInterceptions = true;
                Global.player[PlayerIndex].standardStats.interceptions = Convert.ToInt32(Sinterceptions_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isKickMetresGained = true;
                Global.player[PlayerIndex].standardStats.kickMetresGained = Convert.ToInt32(SkickMetresGained_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isKicksInPlay = true;
                Global.player[PlayerIndex].standardStats.kicksInPlay = Convert.ToInt32(SkicksInPlay_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isKnockOns = true;
                Global.player[PlayerIndex].standardStats.knockOns = Convert.ToInt32(SknockOns_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.islineBreakAssists = true;
                Global.player[PlayerIndex].standardStats.lineBreakAssists = Convert.ToInt32(SlineBreakAssists_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isLineBreaks = true;
                Global.player[PlayerIndex].standardStats.lineBreaks = Convert.ToInt32(SlineBreaks_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isMetresRun = true;
                Global.player[PlayerIndex].standardStats.metresRun = Convert.ToInt32(SmetresRun_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isMinutesPlayed = true;
                Global.player[PlayerIndex].standardStats.minutesPlayed = Convert.ToInt32(SminutesPlayed_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isMissedTackles = true;
                Global.player[PlayerIndex].standardStats.missedTackles = Convert.ToInt32(SmissedTackles_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isOffloads = true;
                Global.player[PlayerIndex].standardStats.offloads = Convert.ToInt32(Soffloads_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isOneOnOneTackles = true;
                Global.player[PlayerIndex].standardStats.oneOnOneTackles = Convert.ToInt32(SoneOnOneTackles_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isPasses = true;
                Global.player[PlayerIndex].standardStats.passes = Convert.ToInt32(Spasses_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isPenaltiesConceded = true;
                Global.player[PlayerIndex].standardStats.penaltiesConceded = Convert.ToInt32(SpenaltiesConceded_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isPenaltyGoals = true;
                Global.player[PlayerIndex].standardStats.penaltyGoals = Convert.ToInt32(SpenaltyGoals_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isPenaltyGoalAttempts = true;
                Global.player[PlayerIndex].standardStats.penaltyGoalAttempts = Convert.ToInt32(SpenaltyGoalAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isRuns = true;
                Global.player[PlayerIndex].standardStats.runs = Convert.ToInt32(Sruns_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isTackleBreaks = true;
                Global.player[PlayerIndex].standardStats.tackleBreaks = Convert.ToInt32(StackleBreaks_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isTackles = true;
                Global.player[PlayerIndex].standardStats.tackles = Convert.ToInt32(Stackles_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isTries = true;
                Global.player[PlayerIndex].standardStats.tries = Convert.ToInt32(Stries_numericUpDown.Value);
                Global.player[PlayerIndex].standardStats.isTryAssists = true;
                Global.player[PlayerIndex].standardStats.tryAssists = Convert.ToInt32(StryAssists_numericUpDown.Value);
            }
            else
                Global.player[PlayerIndex].isStandardStats = false;

            if (NinesMatchEnabled_checkBox.Checked)
            {
                Global.player[PlayerIndex].isNinesStats = true;

                Global.player[PlayerIndex].ninesStats.isMatchesPlayed = true;
                Global.player[PlayerIndex].ninesStats.matchesPlayed = Convert.ToInt32(NmatchesPlayed_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isMatchesWon = true;
                Global.player[PlayerIndex].ninesStats.matchesWon = Convert.ToInt32(NmatchesWon_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isMatchesDrawn = true;
                Global.player[PlayerIndex].ninesStats.matchesDrawn = Convert.ToInt32(NmatchesDrawn_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isBallStrips = true;
                Global.player[PlayerIndex].ninesStats.ballStrips = Convert.ToInt32(NballStrips_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isConversions = true;
                Global.player[PlayerIndex].ninesStats.conversions = Convert.ToInt32(Nconversions_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isConversionAttempts = true;
                Global.player[PlayerIndex].ninesStats.conversionAttempts = Convert.ToInt32(NconversionAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isFends = true;
                Global.player[PlayerIndex].ninesStats.fends = Convert.ToInt32(Nfends_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isFieldGoalAttempts = true;
                Global.player[PlayerIndex].ninesStats.fieldGoalAttempts = Convert.ToInt32(NfieldGoalAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isFieldGoals = true;
                Global.player[PlayerIndex].ninesStats.fieldGoals = Convert.ToInt32(NfieldGoals_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isFortyTwenties = true;
                Global.player[PlayerIndex].ninesStats.fortyTwenties = Convert.ToInt32(NfortyTwenties_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isHandlingErrors = true;
                Global.player[PlayerIndex].ninesStats.handlingErrors = Convert.ToInt32(NhandlingErrors_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isHitups = true;
                Global.player[PlayerIndex].ninesStats.hitups = Convert.ToInt32(Nhitups_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isInterceptedPasses = true;
                Global.player[PlayerIndex].ninesStats.interceptedPasses = Convert.ToInt32(NinterceptedPasses_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isInterceptions = true;
                Global.player[PlayerIndex].ninesStats.interceptions = Convert.ToInt32(Ninterceptions_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isKickMetresGained = true;
                Global.player[PlayerIndex].ninesStats.kickMetresGained = Convert.ToInt32(NkickMetresGained_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isKicksInPlay = true;
                Global.player[PlayerIndex].ninesStats.kicksInPlay = Convert.ToInt32(NkicksInPlay_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isKnockOns = true;
                Global.player[PlayerIndex].ninesStats.knockOns = Convert.ToInt32(NknockOns_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.islineBreakAssists = true;
                Global.player[PlayerIndex].ninesStats.lineBreakAssists = Convert.ToInt32(NlineBreakAssists_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isLineBreaks = true;
                Global.player[PlayerIndex].ninesStats.lineBreaks = Convert.ToInt32(NlineBreaks_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isMetresRun = true;
                Global.player[PlayerIndex].ninesStats.metresRun = Convert.ToInt32(NmetresRun_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isMinutesPlayed = true;
                Global.player[PlayerIndex].ninesStats.minutesPlayed = Convert.ToInt32(NminutesPlayed_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isMissedTackles = true;
                Global.player[PlayerIndex].ninesStats.missedTackles = Convert.ToInt32(NmissedTackles_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isOffloads = true;
                Global.player[PlayerIndex].ninesStats.offloads = Convert.ToInt32(Noffloads_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isOneOnOneTackles = true;
                Global.player[PlayerIndex].ninesStats.oneOnOneTackles = Convert.ToInt32(NoneOnOneTackles_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isPasses = true;
                Global.player[PlayerIndex].ninesStats.passes = Convert.ToInt32(Npasses_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isPenaltiesConceded = true;
                Global.player[PlayerIndex].ninesStats.penaltiesConceded = Convert.ToInt32(NpenaltiesConceded_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isPenaltyGoals = true;
                Global.player[PlayerIndex].ninesStats.penaltyGoals = Convert.ToInt32(NpenaltyGoals_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isPenaltyGoalAttempts = true;
                Global.player[PlayerIndex].ninesStats.penaltyGoalAttempts = Convert.ToInt32(NpenaltyGoalAttempts_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isRuns = true;
                Global.player[PlayerIndex].ninesStats.runs = Convert.ToInt32(Nruns_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isTackleBreaks = true;
                Global.player[PlayerIndex].ninesStats.tackleBreaks = Convert.ToInt32(NtackleBreaks_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isTackles = true;
                Global.player[PlayerIndex].ninesStats.tackles = Convert.ToInt32(Ntackles_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isTries = true;
                Global.player[PlayerIndex].ninesStats.tries = Convert.ToInt32(Ntries_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isTryAssists = true;
                Global.player[PlayerIndex].ninesStats.tryAssists = Convert.ToInt32(NtryAssists_numericUpDown.Value);
                Global.player[PlayerIndex].ninesStats.isBonusTries = true;
                Global.player[PlayerIndex].ninesStats.bonusTries = Convert.ToInt32(NbonusTries_numericUpDown.Value);
            }
            else
                Global.player[PlayerIndex].isNinesStats = false;

            if (ContractExpiry_comboBox.SelectedIndex != 26)
            {
                Global.player[PlayerIndex].isContractExpiry = true;
                Global.player[PlayerIndex].contractExpiry = Convert.ToInt32(ContractExpiry_comboBox.Text);
            }
            else
            {
                Global.player[PlayerIndex].isContractExpiry = false;
                Global.player[PlayerIndex].contractExpiry = 0;
            }

            int playerRating = PlayerRating();

            player_name_label.Text = First_Name_textBox.Text + " " + Last_Name_textBox.Text + " - " + playerRating.ToString();

            RefreshList.Update_PlayerList(Players_dataGridView);

            MessageBox.Show("Changers have been saved to this player", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private int PlayerRating()
        {
            int PlayerRole = 0;
            int Role = Primary_Role_comboBox.SelectedIndex;

            if (Role == 0)
                PlayerRole = PlayerRatingFB();
            else if (Role == 1)
                PlayerRole = PlayerRatingW();
            else if (Role == 2)
                PlayerRole = PlayerRatingC();
            else if (Role == 3)
                PlayerRole = PlayerRatingFE();
            else if (Role == 4)
                PlayerRole = PlayerRatingHB();
            else if (Role == 5)
                PlayerRole = PlayerRatingPR();
            else if (Role == 6)
                PlayerRole = PlayerRatingHK();
            else if (Role == 7)
                PlayerRole = PlayerRatingSR();
            else if (Role == 8)
                PlayerRole = PlayerRatingL();
            return PlayerRole;
        }

        private int PlayerRatingFB()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 90) + Agility_numericUpDown.Value + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 85) + SprintSpeed_numericUpDown.Value + basicPass_numericUpDown.Value + longPass_numericUpDown.Value
            + sideStep_numericUpDown.Value + contestedCollect_numericUpDown.Value) / 11;
            return (int)playerRating;
        }

        private int PlayerRatingW()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 90) + Agility_numericUpDown.Value + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 85) + SprintSpeed_numericUpDown.Value + offload_numericUpDown.Value + dummyPass_numericUpDown.Value
            + fend_numericUpDown.Value + sideStep_numericUpDown.Value + breakTackle_numericUpDown.Value + tackle_numericUpDown.Value + driveTackle_numericUpDown.Value + diveTackle_numericUpDown.Value
            + contestedCollect_numericUpDown.Value + diveCollect_numericUpDown.Value) / 17;
            return (int)playerRating;
        }

        private int PlayerRatingC()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 90) + Agility_numericUpDown.Value + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 90) + SprintSpeed_numericUpDown.Value + basicPass_numericUpDown.Value + offload_numericUpDown.Value
            + dummyPass_numericUpDown.Value + sideStep_numericUpDown.Value + tackle_numericUpDown.Value + contestedCollect_numericUpDown.Value) / 13;
            return (int)playerRating;
        }

        private int PlayerRatingFE()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 95) + Agility_numericUpDown.Value + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 85) + ((SprintSpeed_numericUpDown.Value * 100) / 95) + dummyPass_numericUpDown.Value + grubberKick_numericUpDown.Value
            + puntKick_numericUpDown.Value + bombKick_numericUpDown.Value + fieldgoalKick_numericUpDown.Value + basicPass_numericUpDown.Value + longPass_numericUpDown.Value) / 14;
            return (int)playerRating;
        }

        private int PlayerRatingHB()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 95) + Agility_numericUpDown.Value + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 85) + ((SprintSpeed_numericUpDown.Value * 100) / 95) + grubberKick_numericUpDown.Value + puntKick_numericUpDown.Value
            + bombKick_numericUpDown.Value + fieldgoalKick_numericUpDown.Value + basicPass_numericUpDown.Value + longPass_numericUpDown.Value) / 13;
            return (int)playerRating;
        }

        private int PlayerRatingPR()
        {
            decimal playerRating = (Strength_numericUpDown.Value + ((Agility_numericUpDown.Value * 100) / 90) + ((Fitness_numericUpDown.Value * 100) / 85) + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 90) + ((SprintSpeed_numericUpDown.Value * 100) / 80) + fend_numericUpDown.Value + breakTackle_numericUpDown.Value
            + tackle_numericUpDown.Value + driveTackle_numericUpDown.Value + impactTackle_numericUpDown.Value + offload_numericUpDown.Value) / 13;
            return (int)playerRating;
        }

        private int PlayerRatingHK()
        {
            decimal playerRating = (((Strength_numericUpDown.Value * 100) / 90) + ((Agility_numericUpDown.Value * 100) / 95) + Fitness_numericUpDown.Value + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 95) + ((Durability_numericUpDown.Value * 100) / 95) + ((SprintSpeed_numericUpDown.Value * 100) / 90) + dummyPass_numericUpDown.Value + sideStep_numericUpDown.Value
            + tackle_numericUpDown.Value + grubberKick_numericUpDown.Value + puntKick_numericUpDown.Value + basicPass_numericUpDown.Value + longPass_numericUpDown.Value
            + offload_numericUpDown.Value) / 15;
            return (int)playerRating;
        }

        private int PlayerRatingSR()
        {
            decimal playerRating = (Strength_numericUpDown.Value + ((Agility_numericUpDown.Value * 100) / 90) + ((Fitness_numericUpDown.Value * 100) / 95) + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 90) + ((SprintSpeed_numericUpDown.Value * 100) / 85) + basicPass_numericUpDown.Value + offload_numericUpDown.Value
            + fend_numericUpDown.Value + sideStep_numericUpDown.Value + breakTackle_numericUpDown.Value + tackle_numericUpDown.Value + driveTackle_numericUpDown.Value
            + diveTackle_numericUpDown.Value) / 15;
            return (int)playerRating;
        }

        private int PlayerRatingL()
        {
            decimal playerRating = (Strength_numericUpDown.Value + ((Agility_numericUpDown.Value * 100) / 90) + ((Fitness_numericUpDown.Value * 100) / 95) + Acceleration_numericUpDown.Value
            + ((Discipline_numericUpDown.Value * 100) / 90) + ((Durability_numericUpDown.Value * 100) / 90) + ((SprintSpeed_numericUpDown.Value * 100) / 85) + basicPass_numericUpDown.Value + offload_numericUpDown.Value
            + fend_numericUpDown.Value + breakTackle_numericUpDown.Value + tackle_numericUpDown.Value + driveTackle_numericUpDown.Value) / 13;
            return (int)playerRating;
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
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);
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
                    Fitness_numericUpDown.Value = RandomizeStats(70, 80);
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
                    Fitness_numericUpDown.Value = RandomizeStats(60, 70);
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
                    Fitness_numericUpDown.Value = RandomizeStats(80, 95);
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
                    Fitness_numericUpDown.Value = RandomizeStats(70, 85);
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
                    Fitness_numericUpDown.Value = RandomizeStats(60, 75);
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
                    Fitness_numericUpDown.Value = RandomizeStats(70, 90);
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
                    Fitness_numericUpDown.Value = RandomizeStats(60, 80);
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
                    Fitness_numericUpDown.Value = RandomizeStats(50, 70);
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
                    Fitness_numericUpDown.Value = RandomizeStats(75, 90);
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
                    Fitness_numericUpDown.Value = RandomizeStats(70, 85);
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
                    Fitness_numericUpDown.Value = RandomizeStats(50, 70);
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