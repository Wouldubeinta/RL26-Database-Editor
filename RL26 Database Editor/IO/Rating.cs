namespace RL26_Database_Editor
{
    internal class Rating
    {
        public static int PlayerRating(int index)
        {
            int PlayerRole = 0;
            int Role = Global.player[index].primaryRole;

            if (Role == 0)
                PlayerRole = PlayerRatingFB(index);
            else if (Role == 1)
                PlayerRole = PlayerRatingW(index);
            else if (Role == 2)
                PlayerRole = PlayerRatingC(index);
            else if (Role == 3)
                PlayerRole = PlayerRatingFE(index);
            else if (Role == 4)
                PlayerRole = PlayerRatingHB(index);
            else if (Role == 5)
                PlayerRole = PlayerRatingPR(index);
            else if (Role == 6)
                PlayerRole = PlayerRatingHK(index);
            else if (Role == 7)
                PlayerRole = PlayerRatingSR(index);
            else if (Role == 8)
                PlayerRole = PlayerRatingL(index);
            return PlayerRole;
        }

        private static int PlayerRatingFB(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 90) + Global.player[index].technicalAbility.agility + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 85) + Global.player[index].technicalAbility.sprintSpeed + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.longPass
            + Global.player[index].skills.evasionSkills.sideStep + Global.player[index].skills.miscSkills.contestedCollect) / 11;
            return (int)playerRating;
        }

        private static int PlayerRatingW(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 90) + Global.player[index].technicalAbility.agility + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 85) + Global.player[index].technicalAbility.sprintSpeed + Global.player[index].skills.passingSkills.offload + Global.player[index].skills.evasionSkills.dummyPass
            + Global.player[index].skills.evasionSkills.fend + Global.player[index].skills.evasionSkills.sideStep + Global.player[index].skills.evasionSkills.breakTackle + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.tackleSkills.driveTackle + Global.player[index].skills.tackleSkills.diveTackle
            + Global.player[index].skills.miscSkills.contestedCollect + Global.player[index].skills.miscSkills.diveCollect) / 17;
            return (int)playerRating;
        }

        private static int PlayerRatingC(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 90) + Global.player[index].technicalAbility.agility + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 85) + Global.player[index].technicalAbility.sprintSpeed + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.offload
            + Global.player[index].skills.evasionSkills.dummyPass + Global.player[index].skills.evasionSkills.sideStep + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.miscSkills.contestedCollect) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingFE(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 95) + Global.player[index].technicalAbility.agility + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 85) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 95) + Global.player[index].skills.evasionSkills.dummyPass + Global.player[index].skills.kickingSkills.grubberKick
            + Global.player[index].skills.kickingSkills.puntKick + Global.player[index].skills.kickingSkills.bombKick + Global.player[index].skills.kickingSkills.fieldgoalKick + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.longPass) / 14;
            return (int)playerRating;
        }

        private static int PlayerRatingHB(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 95) + Global.player[index].technicalAbility.agility + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 85) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 95) + Global.player[index].skills.kickingSkills.grubberKick + Global.player[index].skills.kickingSkills.puntKick
            + Global.player[index].skills.kickingSkills.bombKick + Global.player[index].skills.kickingSkills.fieldgoalKick + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.longPass) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingPR(int index)
        {
            decimal playerRating = (Global.player[index].technicalAbility.strength + ((Global.player[index].technicalAbility.agility * 100) / 90) + ((Global.player[index].technicalAbility.fitness * 100) / 85) + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 90) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 80) + Global.player[index].skills.evasionSkills.fend + Global.player[index].skills.evasionSkills.breakTackle
            + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.tackleSkills.driveTackle + Global.player[index].skills.tackleSkills.impactTackle + Global.player[index].skills.passingSkills.offload) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingHK(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 90) + ((Global.player[index].technicalAbility.agility * 100) / 95) + Global.player[index].technicalAbility.fitness + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 95) + ((Global.player[index].technicalAbility.durability * 100) / 95) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 90) + Global.player[index].skills.evasionSkills.dummyPass + Global.player[index].skills.evasionSkills.sideStep
            + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.kickingSkills.grubberKick + Global.player[index].skills.kickingSkills.puntKick + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.longPass
            + Global.player[index].skills.passingSkills.offload) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingSR(int index)
        {
            decimal playerRating = (Global.player[index].technicalAbility.strength + ((Global.player[index].technicalAbility.agility * 100) / 90) + ((Global.player[index].technicalAbility.fitness * 100) / 95) + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 90) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 85) + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.offload
            + Global.player[index].skills.evasionSkills.fend + Global.player[index].skills.evasionSkills.sideStep + Global.player[index].skills.evasionSkills.breakTackle + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.tackleSkills.driveTackle
            + Global.player[index].skills.tackleSkills.diveTackle) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingL(int index)
        {
            decimal playerRating = (Global.player[index].technicalAbility.strength + ((Global.player[index].technicalAbility.agility * 100) / 90) + ((Global.player[index].technicalAbility.fitness * 100) / 95) + Global.player[index].technicalAbility.acceleration
            + ((Global.player[index].technicalAbility.discipline * 100) / 90) + ((Global.player[index].technicalAbility.durability * 100) / 90) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 85) + Global.player[index].skills.passingSkills.basicPass + Global.player[index].skills.passingSkills.offload
            + Global.player[index].skills.evasionSkills.fend + Global.player[index].skills.evasionSkills.breakTackle + Global.player[index].skills.tackleSkills.tackle + Global.player[index].skills.tackleSkills.driveTackle) / 13;
            return (int)playerRating;
        }
    }
}
