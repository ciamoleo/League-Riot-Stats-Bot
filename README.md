Proszę bardzo. Wyrzucamy emotki, ma być czysto, technicznie i konkretnie. Masz tu surowy kod do skopiowania. Wklej to na GitHuba i masz gotowe.

Markdown
# League Riot Stats Bot

The project is being developed to learn practical C#/.NET application development, API integration, JSON deserialization, object-oriented programming, and dependency injection.

---

## Project Status
This project is currently under development and is primarily used as a practical learning project for C# and .NET development.

## Current Features
* Retrieve a League of Legends account using Riot ID.
* Retrieve the player's PUUID.
* Retrieve recent match IDs.
* Retrieve detailed information about a selected match.
* Deserialize Riot API responses into C# models.
* Find a specific player in a match by PUUID.
* Read basic statistics such as kills, deaths, assists, champion, and win status.

## Technologies
* **C# / .NET 10**
* **Riot Games API**
* HttpClient
* System.Text.Json
* Microsoft.Extensions.Configuration.Json
* Asynchronous programming (`async` and `await`)
* Object-oriented programming (OOP)
* Constructor-based dependency injection

---

## Architecture & Project Structure

```text
RiotAPIConsole/
├── Program.cs
├── RiotApiClient.cs
├── ApiEndpoints.cs
├── Player.cs
├── MatchModel.cs
└── appsettings.json
```

* **`Program.cs`** - Responsible for application startup, configuration, object creation, and testing the application flow.
* **`RiotApiClient.cs`** - Responsible for communication with the Riot Games API, HTTP requests, response validation, and JSON deserialization.
* **`ApiEndpoints.cs`** - Contains reusable Riot API endpoint paths.
* **`Player.cs`** - Represents account data returned by the Riot Account API.
* **`MatchModel.cs`** - Represents match data and participant statistics.

Example Configuration
Create a local appsettings.json file in the root of your project:

JSON
{
  "Riot": {
    "ApiKey": "YOUR_RIOT_API_KEY"
  }
}
Warning: The API key must not be committed to the repository.

Running the Project
Bash
dotnet restore
dotnet run
Learning Objectives
This project focuses on learning:

C# classes, objects, fields, properties, and constructors.

Access modifiers such as private, public, and internal.

The purpose of readonly and static.

Asynchronous programming with Task, async, and await.

Dependency injection through constructors.

HTTP communication using HttpClient.

JSON deserialization using System.Text.Json.

Working with nested JSON objects and lists.

Separating application logic into dedicated classes.

Handling API errors and invalid responses.

## Progress & Roadmap

### Completed
- [x] Created a .NET console application.
- [x] Added Riot API configuration through `appsettings.json` and protected it with `.gitignore`.
- [x] Created `RiotApiClient` with constructor-based dependency injection for `HttpClient` and the API key.
- [x] Added reusable Riot API endpoint paths.
- [x] Retrieved a player's PUUID using Riot ID.
- [x] Retrieved recent match IDs using a player's PUUID.
- [x] Retrieved detailed information about a selected match.
- [x] Deserialized match JSON into `MatchModel`.
- [x] Mapped match participants and basic statistics.

### In Progress
- [ ] Find the selected player inside the match by PUUID.
- [ ] Display the player's champion, K/D/A, and match result.
- [ ] Improve error handling and validation.
- [ ] Refactor the test workflow in `Program.cs`.

### Planned
- [ ] Add rank and summoner information.
- [ ] Add support for multiple Riot routing regions.
- [ ] Move the Riot API code into a reusable class library.
- [ ] Create a Discord Bot using Discord.Net.
- [ ] Add Discord commands for player and match statistics.
- [ ] Add match analysis features such as KDA, win rate, and sabotage/int indicators.

Security
Never commit Riot API keys to GitHub.

Development API keys can expire and should be regenerated if they are exposed. Store secrets locally using an ignored configuration file (appsettings.json in .gitignore), environment variables, or a secret management system.
