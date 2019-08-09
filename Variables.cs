/*
    This file is part of BP-NoApartmentsHiding.

    BP-NoApartmentsHiding is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    BP-NoApartmentsHiding is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with BP-NoApartmentsHiding. If not, see <https://www.gnu.org/licenses/>.
 */

namespace NoApartmentsHiding
{
    public class Variables
    {
        public int MaxWantedLevel { get; set; } = 0;
        public string MessageColor { get; set; } = "#e2a90b";
        public string CantEnterMessage { get; set; } = "You can't enter any apartments because of wanted level.";
        public string CantInviteMessage { get; set; } = "You can't invite wanted criminals.";
    }
}
