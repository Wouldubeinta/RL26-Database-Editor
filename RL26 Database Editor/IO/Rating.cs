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
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 94) + ((Global.player[index].technicalAbility.agility * 99) / 96) + ((Global.player[index].technicalAbility.stamina * 99) / 97) + ((Global.player[index].technicalAbility.acceleration * 99) / 94)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 92) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 94) + ((Global.player[index].skills.passingSkills.longPass * 99) / 94)
            + ((Global.player[index].skills.evasionSkills.sideStep * 99) / 96) + ((Global.player[index].skills.miscSkills.contestedCollect * 99) / 98)) / 11;
            return (int)playerRating;
        }

        private static int PlayerRatingW(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 94) + ((Global.player[index].technicalAbility.agility * 99) / 96) + ((Global.player[index].technicalAbility.stamina * 99) / 95) + ((Global.player[index].technicalAbility.acceleration * 99) / 98)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 97) + ((Global.player[index].skills.passingSkills.offload * 99) / 93) + ((Global.player[index].skills.evasionSkills.dummyPass * 99) / 90)
            + ((Global.player[index].skills.evasionSkills.fend * 99) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 99) / 99) + ((Global.player[index].skills.evasionSkills.breakTackle * 99) / 95) + ((Global.player[index].skills.tackleSkills.tackle * 99) / 94) + ((Global.player[index].skills.tackleSkills.driveTackle * 99) / 94) + ((Global.player[index].skills.tackleSkills.diveTackle * 99) / 94)
            + ((Global.player[index].skills.miscSkills.contestedCollect * 99) / 94) + ((Global.player[index].skills.miscSkills.diveCollect * 99) / 96)) / 17;
            return (int)playerRating;
        }

        private static int PlayerRatingC(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 99) + ((Global.player[index].technicalAbility.agility * 99) / 94) + ((Global.player[index].technicalAbility.stamina * 99) / 95) + ((Global.player[index].technicalAbility.acceleration * 99) / 96)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 94) + ((Global.player[index].skills.passingSkills.offload * 99) / 94)
            + ((Global.player[index].skills.evasionSkills.dummyPass * 99) / 90) + ((Global.player[index].skills.evasionSkills.sideStep * 99) / 98) + ((Global.player[index].skills.tackleSkills.tackle * 99) / 94) + ((Global.player[index].skills.miscSkills.contestedCollect * 99) / 94)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingFE(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 92) + ((Global.player[index].technicalAbility.agility * 99) / 90) + ((Global.player[index].technicalAbility.stamina * 99) / 94) + ((Global.player[index].technicalAbility.acceleration * 99) / 92)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 93) + ((Global.player[index].skills.evasionSkills.dummyPass * 99) / 96) + ((Global.player[index].skills.kickingSkills.grubberKick * 99) / 94)
            + ((Global.player[index].skills.kickingSkills.puntKick * 99) / 99) + ((Global.player[index].skills.kickingSkills.bombKick * 99) / 96) + ((Global.player[index].skills.kickingSkills.fieldgoalKick * 99) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 98) + ((Global.player[index].skills.passingSkills.longPass * 99) / 97)) / 14;
            return (int)playerRating;
        }

        private static int PlayerRatingHB(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 90) + ((Global.player[index].technicalAbility.agility * 99) / 89) + ((Global.player[index].technicalAbility.stamina * 99) / 91) + ((Global.player[index].technicalAbility.acceleration * 99) / 94)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 93) + ((Global.player[index].skills.kickingSkills.grubberKick * 99) / 94) + ((Global.player[index].skills.kickingSkills.puntKick * 97) / 94)
            + ((Global.player[index].skills.kickingSkills.bombKick * 99) / 99) + ((Global.player[index].skills.kickingSkills.fieldgoalKick * 99) / 95) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 96) + ((Global.player[index].skills.passingSkills.longPass * 99) / 98)) / 13;
            return (int)playerRating;
        }

        private static int PlayerRatingPR(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 94) + ((Global.player[index].technicalAbility.agility * 99) / 94) + ((Global.player[index].technicalAbility.stamina * 99) / 94) + ((Global.player[index].technicalAbility.acceleration * 99) / 94)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 93) + ((Global.player[index].skills.evasionSkills.fend * 99) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 99) / 94)
            + ((Global.player[index].skills.tackleSkills.tackle * 99) / 98) + ((Global.player[index].skills.tackleSkills.driveTackle * 99) / 96) + ((Global.player[index].skills.tackleSkills.impactTackle * 99) / 99) + ((Global.player[index].skills.passingSkills.offload * 99) / 97)) / 13;
            return (int)(playerRating);
        }

        private static int PlayerRatingHK(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 92) + ((Global.player[index].technicalAbility.agility * 99) / 95) + ((Global.player[index].technicalAbility.stamina * 99) / 97) + ((Global.player[index].technicalAbility.acceleration * 99) / 90)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 94) + ((Global.player[index].skills.evasionSkills.dummyPass * 99) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 99) / 94)
            + ((Global.player[index].skills.tackleSkills.tackle * 99) / 95) + ((Global.player[index].skills.kickingSkills.grubberKick * 99) / 94) + ((Global.player[index].skills.kickingSkills.puntKick * 99) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 99) + ((Global.player[index].skills.passingSkills.longPass * 99) / 98)
            + ((Global.player[index].skills.passingSkills.offload * 99) / 93)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingSR(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 96) + ((Global.player[index].technicalAbility.agility * 99) / 93) + ((Global.player[index].technicalAbility.stamina * 99) / 94) + ((Global.player[index].technicalAbility.acceleration * 99) / 94)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 94) + ((Global.player[index].skills.passingSkills.offload * 99) / 99)
            + ((Global.player[index].skills.evasionSkills.fend * 99) / 94) + ((Global.player[index].skills.evasionSkills.sideStep * 99) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 99) / 95) + ((Global.player[index].skills.tackleSkills.tackle * 99) / 97) + ((Global.player[index].skills.tackleSkills.driveTackle * 99) / 96)
            + ((Global.player[index].skills.tackleSkills.diveTackle * 99) / 94)) / 15;
            return (int)playerRating;
        }

        private static int PlayerRatingL(int index)
        {
            decimal playerRating = (((Global.player[index].technicalAbility.strength * 99) / 95) + ((Global.player[index].technicalAbility.agility * 99) / 93) + ((Global.player[index].technicalAbility.stamina * 99) / 94) + ((Global.player[index].technicalAbility.acceleration * 99) / 94)
            + ((Global.player[index].technicalAbility.discipline * 99) / 94) + ((Global.player[index].technicalAbility.durability * 99) / 94) + ((Global.player[index].technicalAbility.sprintSpeed * 99) / 94) + ((Global.player[index].skills.passingSkills.basicPass * 99) / 94) + ((Global.player[index].skills.passingSkills.offload * 99) / 97)
            + ((Global.player[index].skills.evasionSkills.fend * 99) / 94) + ((Global.player[index].skills.evasionSkills.breakTackle * 99) / 94) + ((Global.player[index].skills.tackleSkills.tackle * 99) / 99) + ((Global.player[index].skills.tackleSkills.driveTackle * 99) / 96)) / 13;
            return (int)playerRating;
        }
    }
}
