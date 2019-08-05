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
