using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RiotAPIConsole
{
    public class MatchModel
    {
        [JsonPropertyName("info")]
        public MatchInfo Info { get; set; }
    }
    public class MatchInfo
    {
        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }
    }
    public class Participant
    {
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; } = "";
        [JsonPropertyName("championName")]
        public string ChampionName { get; set; } = "";
        [JsonPropertyName("kills")]
        public int Kills { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("assists")]
        public int Assists { get; set; }
        [JsonPropertyName("win")]
        public bool Win {  get; set; }
    }
}
