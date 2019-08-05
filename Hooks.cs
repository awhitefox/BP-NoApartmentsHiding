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
using System.IO;
using UnityEngine;
using UniversalUnityHooks;

namespace NoApartmentsHiding
{
    public static class Hooks
    {
        private const string ConfigFilePath = "Plugins/NoApartmentsHiding-Settings.json";
        private static Variables Vars = new Variables();

        [Hook("SvManager.StartServer")]
        public static void StartServer(SvManager svManager)
        {
            Debug.Log("Initializing NoApartmentsHiding...");
            if (File.Exists(ConfigFilePath))
            {
                try { Vars = JsonConvert.DeserializeObject<Variables>(File.ReadAllText(ConfigFilePath)); }
                catch (Exception) { Debug.Log($"[ERROR] Can't deserialize {ConfigFilePath}. Using default values."); }
            }
            else
            {
                Debug.Log("Config file for NoApartmentsHiding not found. Creating one...");
                File.WriteAllText(ConfigFilePath, JsonConvert.SerializeObject(Vars, Formatting.Indented));
            }
        }

        [Hook("SvPlayer.SvEnterPlace")]
        public static bool SvEnterPlace(SvPlayer svPlayer, ref int door, ref ShPlayer shPlayer)
        {
            if (shPlayer.wantedLevel > Vars.MaxWantedLevel && svPlayer.entity.manager.FindByID<ShDoor>(door) is ShApartment)
            {
                svPlayer.ShowMessageInChat($"<color={Vars.MessageColor}>{Vars.CantEnterMessage}</color>"); // TODO
                return true;
            }
            return false;
        }

        [Hook("SvPlayer.SvInvite")]
        public static bool SvInvite(SvPlayer svPlayer, ref int targetId)
        {
            var target = svPlayer.entity.manager.FindByID<ShPlayer>(targetId);
            if (target.wantedLevel > Vars.MaxWantedLevel)
            {
                svPlayer.ShowMessageInChat($"<color={Vars.MessageColor}>{Vars.CantInviteMessage}</color>");
                return true;
            }
            return false;
        }

        private static void ShowMessageInChat(this SvPlayer player, string message) => player.Send(SvSendType.Self, Channel.Unsequenced, ClPacket.GameMessage, message);
    }
}
