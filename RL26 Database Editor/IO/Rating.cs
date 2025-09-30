namespace RL26_Database_Editor
{
    /// <summary>
    /// Player Ratings Class.
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
    /// [Wouldubeinta]	   23/09/2025	Created
    /// </history>
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
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 94) + ((Global.player[index].technicalAbility.agility * 100) / 96) + ((Global.player[index].technicalAbility.stamina * 100) / 97) + ((Global.player[index].technicalAbility.acceleration * 100) / 94)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 92) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.longPass * 100) / 94)
            + ((Global.player[index].skills.evasionSkills.sideStep * 100) / 94) + ((Global.player[index].skills.miscSkills.contestedCollect * 100) / 94)) / 11;
            return (int)playerRating;
        }

        private static int PlayerRatingW(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 94) + ((Global.player[index].technicalAbility.agility * 100) / 96) + ((Global.player[index].technicalAbility.stamina * 100) / 95) + ((Global.player[index].technicalAbility.acceleration * 100) / 98)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 97) + ((Global.player[index].skills.passingSkills.offload * 100) / 94) + ((Global.player[index].skills.evasionSkills.dummyPass * 100) / 94)
            + ((Global.player[index].skills.evasionSkills.fend * 100) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 100) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.driveTackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.diveTackle * 100) / 94)
            + ((Global.player[index].skills.miscSkills.contestedCollect * 100) / 94) + ((Global.player[index].skills.miscSkills.diveCollect * 100) / 94)) / 17;
            return (int)playerRating;
        }

        private static int PlayerRatingC(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 99) + ((Global.player[index].technicalAbility.agility * 100) / 94) + ((Global.player[index].technicalAbility.stamina * 100) / 95) + ((Global.player[index].technicalAbility.acceleration * 100) / 96)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.offload * 100) / 94)
            + ((Global.player[index].skills.evasionSkills.dummyPass * 100) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 100) / 94) + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.miscSkills.contestedCollect * 100) / 94)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingFE(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 92) + ((Global.player[index].technicalAbility.agility * 100) / 90) + ((Global.player[index].technicalAbility.stamina * 100) / 94) + ((Global.player[index].technicalAbility.acceleration * 100) / 92)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 93) + ((Global.player[index].skills.evasionSkills.dummyPass * 100) / 94) + ((Global.player[index].skills.kickingSkills.grubberKick * 100) / 94)
            + ((Global.player[index].skills.kickingSkills.puntKick * 100) / 94) + ((Global.player[index].skills.kickingSkills.bombKick * 100) / 94) + ((Global.player[index].skills.kickingSkills.fieldgoalKick * 100) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.longPass * 100) / 94)) / 14;
            return (int)playerRating;
        }

        private static int PlayerRatingHB(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 90) + ((Global.player[index].technicalAbility.agility * 100) / 89) + ((Global.player[index].technicalAbility.stamina * 100) / 91) + ((Global.player[index].technicalAbility.acceleration * 100) / 94)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 93) + ((Global.player[index].skills.kickingSkills.grubberKick * 100) / 94) + ((Global.player[index].skills.kickingSkills.puntKick * 100) / 94)
            + ((Global.player[index].skills.kickingSkills.bombKick * 100) / 94) + ((Global.player[index].skills.kickingSkills.fieldgoalKick * 100) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.longPass * 100) / 94)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingPR(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 94) + ((Global.player[index].technicalAbility.agility * 100) / 94) + ((Global.player[index].technicalAbility.stamina * 100) / 94) + ((Global.player[index].technicalAbility.acceleration * 100) / 94)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 93) + ((Global.player[index].skills.evasionSkills.fend * 100) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 100) / 94)
            + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.driveTackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.impactTackle * 100) / 94) + ((Global.player[index].skills.passingSkills.offload * 100) / 94)) / 13;
            return (int)(playerRating);
        }

        private static int PlayerRatingHK(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 92) + ((Global.player[index].technicalAbility.agility * 100) / 95) + ((Global.player[index].technicalAbility.stamina * 100) / 97) + ((Global.player[index].technicalAbility.acceleration * 100) / 90)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 94) + ((Global.player[index].skills.evasionSkills.dummyPass * 100) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 100) / 94)
            + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.kickingSkills.grubberKick * 100) / 94) + ((Global.player[index].skills.kickingSkills.puntKick * 100) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.longPass * 100) / 94)
            + ((Global.player[index].skills.passingSkills.offload * 100) / 94)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingSR(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 96) + ((Global.player[index].technicalAbility.agility * 100) / 93) + ((Global.player[index].technicalAbility.stamina * 100) / 94) + ((Global.player[index].technicalAbility.acceleration * 100) / 94)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.offload * 100) / 94)
            + ((Global.player[index].skills.evasionSkills.fend * 100) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 100) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.driveTackle * 100) / 94)
            + ((Global.player[index].skills.tackleSkills.diveTackle * 100) / 94)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingL(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 100) / 95) + ((Global.player[index].technicalAbility.agility * 100) / 93) + ((Global.player[index].technicalAbility.stamina * 100) / 94) + ((Global.player[index].technicalAbility.acceleration * 100) / 94)
            + ((Global.player[index].technicalAbility.discipline * 100) / 94) + ((Global.player[index].technicalAbility.durability * 100) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 100) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 100) / 94) + ((Global.player[index].skills.passingSkills.offload * 100) / 94)
            + ((Global.player[index].skills.evasionSkills.fend * 100) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.tackle * 100) / 94) + ((Global.player[index].skills.tackleSkills.driveTackle * 100) / 94)) / 13;
            return (int)playerRating;
        }
    }
}
