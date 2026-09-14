using Microsoft.Extensions.Configuration;
using RiotAPIConsole;
using System.Diagnostics;
using System.Net;
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
            _apiKey = apiKey;
        }

        public async Task<string> GetPlayerPuuidAsync(string gameName, string tagLine)
        {
            string endpoint
                = $"{BaseUrl}{_endpoints.AccountByRiotId}{gameName}/{tagLine}?api_key={_apiKey}";

            HttpResponseMessage response
                = await _httpClient.GetAsync(endpoint);

            EnsureResponseIsValid(response);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new PlayerNotFoundException(
                    gameName,
                    tagLine);
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiConnectionFailed(response.StatusCode.ToString());
            }
            string accountJson
                = await response.Content.ReadAsStringAsync();
            Player? player = JsonSerializer.Deserialize<Player>(accountJson);
            if (player == null)
            {
                throw new DeserializationProblemException();
            }
            return player.Puuid;
        }
        public async Task<List<string>> GetPlayerMatchListAsync(string puuid)
        {
            string endpoint
                = $"{BaseUrl}{_endpoints.MatchListByPuuid}{puuid}/ids?count=5&api_key={_apiKey}";
            HttpResponseMessage response
                = await _httpClient.GetAsync(endpoint);

            EnsureResponseIsValid(response);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new MatchNotFoundException(puuid);
            }

            string matchListJson
                = await response.Content.ReadAsStringAsync();
            List<string>? matchList = JsonSerializer.Deserialize<List<string>>(matchListJson);
            if (matchList == null)
            {
                throw new DeserializationProblemException();
            }
            if (matchList.Count == 0)
            {
                throw new MatchNotFoundException("Nie udało się znaleźć meczów.");
            }
            return matchList;
        }
        public async Task<MatchModel> GetMatchInfoAsync(string matchId)
        {
            string endpoint =
                $"{BaseUrl}{_endpoints.MatchInfo}{matchId}?api_key={_apiKey}";

            HttpResponseMessage response =
                await _httpClient.GetAsync(endpoint);

            EnsureResponseIsValid(response);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new MatchNotFoundException($"");
            }

            string rawMatchJson
                = await response.Content.ReadAsStringAsync();

            MatchModel? matchModel = JsonSerializer.Deserialize<MatchModel>(rawMatchJson);

            if (matchModel == null)
            {
                throw new DeserializationProblemException();
            }
            return matchModel;
        }
        private void EnsureResponseIsValid(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Forbidden: // 403
                    throw new ApiKeyNotFoundException();

                case HttpStatusCode.Unauthorized: // 401
                    throw new ApiKeyNotFoundException();
                case HttpStatusCode.TooManyRequests: //429
                    throw new RateLimitException();
            }
        }
    }
}