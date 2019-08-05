/*
    This file is part of NoApartmentsHiding.

    NoApartmentsHiding is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NoApartmentsHiding is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NoApartmentsHiding. If not, see <https://www.gnu.org/licenses/>.
 */

using Newtonsoft.Json;
using System;

namespace NoApartmentsHiding
{
    [Serializable]
    public class Variables
    {
        [JsonProperty]
        public int MaxWantedLevel = 0;
        [JsonProperty]
        public string MessageColor = "#e2a90b";
        [JsonProperty]
        public string CantEnterMessage = "You can't enter any apartments because of wanted level.";
        [JsonProperty]
        public string CantInviteMessage = "You can't invite wanted criminals.";
    }
}
