namespace RL26_Database_Editor
{
    public partial class All_Player_Stats_Querys : Form
    {
        public All_Player_Stats_Querys()
        {
            InitializeComponent();
        }

        private void All_Player_Stats_Querys_Load(object sender, EventArgs e)
        {
            PlayerRole_comboBox.SelectedIndex = 0;
        }

        private void ChangeStats_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Global.player_amount; i++)
            {
                int Role = Global.player[i].primaryRole;

                if (Role == PlayerRole_comboBox.SelectedIndex)
                    SkillChange(i);
                else
                    SkillChange(i);
            }

            MessageBox.Show("All player stats have been changed", "All Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SkillChange(int i)
        {
            // Technical Ability
            Global.player[i].technicalAbility.strength = Results(Global.player[i].technicalAbility.strength, Strength_numericUpDown.Value);
            Global.player[i].technicalAbility.agility = Results(Global.player[i].technicalAbility.agility, Agility_numericUpDown.Value);
            Global.player[i].technicalAbility.fitness = Results(Global.player[i].technicalAbility.fitness, Fitness_numericUpDown.Value);
            Global.player[i].technicalAbility.acceleration = Results(Global.player[i].technicalAbility.acceleration, Acceleration_numericUpDown.Value);
            Global.player[i].technicalAbility.discipline = Results(Global.player[i].technicalAbility.discipline, Discipline_numericUpDown.Value);
            Global.player[i].technicalAbility.durability = Results(Global.player[i].technicalAbility.durability, Durability_numericUpDown.Value);
            Global.player[i].technicalAbility.sprintSpeed = Results(Global.player[i].technicalAbility.sprintSpeed, SprintSpeed_numericUpDown.Value);

            // Kicking Skills
            Global.player[i].skills.kickingSkills.grubberKick = Results(Global.player[i].skills.kickingSkills.grubberKick, grubberKick_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.puntKick = Results(Global.player[i].skills.kickingSkills.puntKick, puntKick_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.chipKick = Results(Global.player[i].skills.kickingSkills.chipKick, chipKick_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.bombKick = Results(Global.player[i].skills.kickingSkills.bombKick, bombKick_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.fieldgoalKick = Results(Global.player[i].skills.kickingSkills.fieldgoalKick, fieldgoalKick_numericUpDown.Value);
            Global.player[i].skills.kickingSkills.placeKick = Results(Global.player[i].skills.kickingSkills.placeKick, placeKick_numericUpDown.Value);

            // Passing Skills
            Global.player[i].skills.passingSkills.basicPass = Results(Global.player[i].skills.passingSkills.basicPass, basicPass_numericUpDown.Value);
            Global.player[i].skills.passingSkills.longPass = Results(Global.player[i].skills.passingSkills.longPass, longPass_numericUpDown.Value);
            Global.player[i].skills.passingSkills.offload = Results(Global.player[i].skills.passingSkills.offload, offload_numericUpDown.Value);

            // Evasion Skills
            Global.player[i].skills.evasionSkills.dummyPass = Results(Global.player[i].skills.evasionSkills.dummyPass, dummyPass_numericUpDown.Value);
            Global.player[i].skills.evasionSkills.fend = Results(Global.player[i].skills.evasionSkills.fend, fend_numericUpDown.Value);
            Global.player[i].skills.evasionSkills.sideStep = Results(Global.player[i].skills.evasionSkills.sideStep, sideStep_numericUpDown.Value);
            Global.player[i].skills.evasionSkills.breakTackle = Results(Global.player[i].skills.evasionSkills.breakTackle, breakTackle_numericUpDown.Value);

            // Misc Skills
            Global.player[i].skills.miscSkills.contestedCollect = Results(Global.player[i].skills.miscSkills.contestedCollect, contestedCollect_numericUpDown.Value);
            Global.player[i].skills.miscSkills.diveCollect = Results(Global.player[i].skills.miscSkills.diveCollect, diveCollect_numericUpDown.Value);
            Global.player[i].skills.miscSkills.ballStrip = Results(Global.player[i].skills.miscSkills.ballStrip, ballStrip_numericUpDown.Value);

            // Tackle Skills
            Global.player[i].skills.tackleSkills.tackle = Results(Global.player[i].skills.tackleSkills.tackle, tackle_numericUpDown.Value);
            Global.player[i].skills.tackleSkills.driveTackle = Results(Global.player[i].skills.tackleSkills.driveTackle, driveTackle_numericUpDown.Value);
            Global.player[i].skills.tackleSkills.diveTackle = Results(Global.player[i].skills.tackleSkills.diveTackle, diveTackle_numericUpDown.Value);
            Global.player[i].skills.tackleSkills.impactTackle = Results(Global.player[i].skills.tackleSkills.impactTackle, impactTackle_numericUpDown.Value);
        }

        private int Results(int Skill, decimal control)
        {
            int temp = 0;
            int Results = Skill + Convert.ToInt32(control);

            if (Results < 0)
                temp = 0;
            else if (Results > 99)
                temp = 99;
            else if (Results > -1 && Results < 100)
                temp = Results;
            return temp;
        }

        private void IncrementsValue_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Technical Ability
            Strength_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Strength_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Agility_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Agility_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Fitness_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Fitness_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Acceleration_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Acceleration_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Discipline_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Discipline_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            Durability_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            Durability_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            SprintSpeed_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            SprintSpeed_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Kicking Skills
            grubberKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            grubberKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            puntKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            puntKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            chipKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            chipKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            bombKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            bombKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            fieldgoalKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            fieldgoalKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            placeKick_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            placeKick_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Passing Skills
            basicPass_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            basicPass_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            longPass_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            longPass_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            offload_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            offload_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Evasion Skills
            dummyPass_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            dummyPass_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            fend_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            fend_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            sideStep_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            sideStep_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            breakTackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            breakTackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Misc Skills
            contestedCollect_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            contestedCollect_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            diveCollect_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            diveCollect_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            ballStrip_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            ballStrip_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            // Tackle Skills
            tackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            tackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            driveTackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            driveTackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            diveTackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            diveTackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;

            impactTackle_numericUpDown.Maximum = IncrementsValue_numericUpDown.Value;
            impactTackle_numericUpDown.Minimum = -IncrementsValue_numericUpDown.Value;
        }
    }
}
