using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RiotAPIConsole
{
    internal class Player
    {
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; } = "";
        [JsonPropertyName("gameName")]
        public string GameName { get; set; } = "";
        [JsonPropertyName("tagLine")]
        public string TagLine { get; set; } = "";
    }
}
