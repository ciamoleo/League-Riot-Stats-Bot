using Microsoft.Extensions.Configuration;
using RiotAPIConsole;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Schema;

namespace RiotAPIConsole
{
    internal class RiotApiClient
    {
        // 1. Nie deklaruję na początku appsettings.JSON - to zostaje dla MAIN w program.cs (Depedency Injection)
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://europe.api.riotgames.com";
        private readonly ApiEndPoints _endpoints = new ApiEndPoints();

        public RiotApiClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
                   _apiKey = apiKey
            ?? throw new Exception("Brak Klucza API");
        }

        public async Task<string> GetPlayerPuuidAsync(string gameName, string tagLine)
        {
            string endpoint 
                = $"{BaseUrl}{_endpoints.AccountByRiotId}{gameName}/{tagLine}?api_key={_apiKey}";

            HttpResponseMessage response 
                = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Błąd: {response.StatusCode}");
            }
            else
            {
                string accountJson
                    = await response.Content.ReadAsStringAsync();
                Player? player = JsonSerializer.Deserialize<Player>(accountJson);
                if (player == null)
                {
                    throw new Exception("Błąd, nie udało się znaleźć gracza.");
                }
                else
                {
                    return player.Puuid;
                }
            }
        }
        public async Task<List<string>> GetPlayerMatchListAsync(string puuid)
        {
            string endpoint
                = $"{BaseUrl}{_endpoints.MatchListByPuuid}{puuid}/ids?count=5&api_key={_apiKey}";
            HttpResponseMessage response
                = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Błąd przy połączeniu {response.StatusCode}");
            }
            else
            {
                string matchListJson
                    = await response.Content.ReadAsStringAsync();
                List<string>? matchList = JsonSerializer.Deserialize<List<string>>(matchListJson);
                if (matchList == null)
                {
                    throw new Exception($"Błąd, nie udało się znaleźć meczów.");
                }
                else
                {
                  return matchList;
                }
            }
        }
        public async Task<MatchModel> GetMatchInfoJsonAsync(string matchId)
        {
            string endpoint =
                $"{BaseUrl}{_endpoints.MatchInfo}{matchId}?api_key={_apiKey}";

            HttpResponseMessage response =
                await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Błąd: {response.StatusCode}");
            }

            string rawMatchJson
                = await response.Content.ReadAsStringAsync();
            
            MatchModel? matchModel = JsonSerializer.Deserialize<MatchModel>(rawMatchJson);

            if ( matchModel == null )
            {
                throw new Exception("Nie udało się zdeserializować meczu.");
            }
            return matchModel;
        }
        //public async Task<double> CalculateKDA(string matchId, string puuid)
        //{
        //    await GetMatchInfoJsonAsync();
        //}
    }
}