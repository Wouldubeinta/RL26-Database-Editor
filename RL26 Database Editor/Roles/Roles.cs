namespace RL26_Database_Editor
{
    /// <summary>
    /// Player Roles Class.
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
    /// [Wouldubeinta]	   02/09/2025	Created
    /// </history>
    internal class Roles
    {
        public static string playerRoles(int role)
        {
            string RoleName = string.Empty;

            switch (role)
            {
                case 0:
                    RoleName = "FB";
                    break;
                case 1:
                    RoleName = "WG";
                    break;
                case 2:
                    RoleName = "C";
                    break;
                case 3:
                    RoleName = "FE";
                    break;
                case 4:
                    RoleName = "HB";
                    break;
                case 5:
                    RoleName = "FR";
                    break;
                case 6:
                    RoleName = "HK";
                    break;
                case 7:
                    RoleName = "SR";
                    break;
                case 8:
                    RoleName = "L";
                    break;
            }

            return RoleName;
        }
    }
}
