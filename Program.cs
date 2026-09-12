using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using RiotAPIConsole;

namespace RiotAPIConsole;

internal class Program
{

    // Data fields of program's class
    private readonly RiotApiClient _riotApiClient;

    private readonly string _gameName;
    private readonly string _tagLine;
    private readonly string _apiKey;
    private string _puuid;

    public Program(
        RiotApiClient riotApiClient,
        string gameName,
        string tagLine,
        string apiKey) // Constructor
    {
        _riotApiClient = riotApiClient;
        _gameName = gameName;
        _tagLine = tagLine;
        _apiKey = apiKey;
    }

    public static async Task Main()
    {
        string gameName = "RafalPrincePolo";
        string tagLine = "Rafal";
        // Creating object of configuration (uploading ApiKey from appsettings.json)

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Setting apiKey as 

        string apiKey
            = config["Riot:ApiKey"]
            ?? throw new Exception("Brak Api Key");

        using HttpClient httpClient = new(); // inicjalizacja HttpClient w Main.

        RiotApiClient riotApiClient
            = new RiotApiClient(httpClient, apiKey);

        Program program =
            new Program(riotApiClient,
            gameName,
            tagLine,
            apiKey);

        await program.RunPlayerFlowAsync(
            gameName,
            tagLine);
    }
    private async Task RunPlayerFlowAsync(
    string gameName,
    string tagLine)
    {
        // 1. Pobieramy PUUID gracza
        string puuid =
            await _riotApiClient.GetPlayerPuuidAsync(
                gameName,
                tagLine);

        Console.WriteLine($"PUUID gracza {gameName}: {puuid}");

        // 2. Pobieramy listę identyfikatorów meczów
        List<string> matchList =
            await _riotApiClient.GetPlayerMatchListAsync(
                puuid);

        if (matchList.Count == 0)
        {
            throw new Exception("Gracz nie ma żadnych meczów.");
        }

        Console.WriteLine("\nLista meczów:");

        foreach (string matchId in matchList)
        {
            Console.WriteLine(matchId);
        }

        // 3. Wybieramy pierwszy mecz z listy
        string latestMatchId = matchList[0];

        // 4. Pobieramy szczegóły najnowszego meczu
        MatchModel matchModel =
            await _riotApiClient.GetMatchInfoJsonAsync(
                latestMatchId);

        Console.WriteLine(
            $"\nPobrano mecz: {latestMatchId}");

        // Tymczasowy test, jeśli MatchModel ma Info.Participants
        Console.WriteLine($"Graczy: {matchModel.Info?.Participants?.Count}\n");
        Participant? searchedPlayer = null;

        foreach (Participant participant in matchModel.Info.Participants)
        {
            if (participant.Puuid == puuid)
            {
                searchedPlayer = participant;
                break;
            }
        }
        if (searchedPlayer is null)
        {
            Console.WriteLine("Nie znaleziono gracza w tym meczu.");
        }
        else
        {
            Console.WriteLine(
                $"{searchedPlayer.ChampionName}: " +
                $"{searchedPlayer.Kills}/" +
                $"{searchedPlayer.Deaths}/" +
                $"{searchedPlayer.Assists}");
            Console.WriteLine(
                searchedPlayer.Win
                ? "Wygrana"
                : "Porażka");
        }
    }
}

