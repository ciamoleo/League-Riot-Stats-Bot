using System;
using System.Collections.Generic;
using System.Text;

namespace RiotAPIConsole
{
    internal class ApiEndPoints
    {
        /// <summary>
        /// AccountByRiotID uses gamename + tagline ex: Name#EUNE: {name} | EUNE.
        /// </summary>
        internal readonly string AccountByRiotId = 
            "/riot/account/v1/accounts/by-riot-id/";
        /// <summary>
        /// SummonerById Uses PUUID, ex: {PUUID} (from Account Riot ID).
        /// </summary>
        internal readonly string SummonerByPuuid =
            "/lol/summoner/v4/summoners/by-puuid/";
        /// <summary>
        /// Endpoint used to get latest 5 matches by puuid (remember about puuid before last /
        /// </summary>
        internal readonly string MatchListByPuuid =
            "/lol/match/v5/matches/by-puuid/";
        /// <summary>
        /// Endpoint Used to take info about match, uses MatchId
        /// </summary>
        internal readonly string MatchInfo =
            "/lol/match/v5/matches/";
        /// <summary>
        /// Endpoint used to get summoner statistic about ranked games etc.
        /// </summary>
        internal readonly string SummonerStats =
            "/lol/league/v4/entries/by-summoner/";
    }
}
