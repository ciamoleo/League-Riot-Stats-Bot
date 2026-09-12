# League Riot Stats Bot

An educational C# project that uses the Riot Games API to retrieve League of Legends player data, match history, and match statistics. Discord Bot integration is planned as the next stage of development.

## Project Overview

The application currently communicates with the Riot Games API and follows this data flow:

```text
Riot ID
→ PUUID
→ Match IDs
→ Match details
→ Player statistics
The project is being developed to learn practical C#/.NET application development, API integration, JSON deserialization, object-oriented programming, and dependency injection.

Current Features
Retrieve a League of Legends account using Riot ID.
Retrieve the player's PUUID.
Retrieve recent match IDs.
Retrieve detailed information about a selected match.
Deserialize Riot API responses into C# models.
Find a specific player in a match by PUUID.
Read basic statistics such as kills, deaths, assists, champion, and win status.
Technologies
C#
.NET 10
Riot Games API
HttpClient
System.Text.Json
Microsoft.Extensions.Configuration.Json
Asynchronous programming with async and await
Object-oriented programming
Constructor-based dependency injection
Project Structure
RiotAPIConsole/
├── Program.cs
├── RiotApiClient.cs
├── ApiEndpoints.cs
├── Player.cs
├── MatchModel.cs
└── appsettings.json
Architecture
Program.cs

Responsible for application startup, configuration, object creation, and testing the application flow.

RiotApiClient.cs

Responsible for communication with the Riot Games API, HTTP requests, response validation, and JSON deserialization.

ApiEndpoints.cs

Contains reusable Riot API endpoint paths.

Player.cs

Represents account data returned by the Riot Account API.

MatchModel.cs

Represents match data and participant statistics.

Example Configuration
Create a local appsettings.json file:

{
  "Riot": {
    "ApiKey": "YOUR_RIOT_API_KEY"
  }
}
The API key must not be committed to the repository.

Running the Project
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
Roadmap
Complete match model deserialization.
Extract player statistics from a selected match.
Add rank and summoner information.
Improve exception handling.
Move API communication into a reusable class library.
Create a Discord Bot using Discord.Net.
Add Discord commands for player and match statistics.
Add support for multiple Riot routing regions.
Security
Never commit Riot API keys to GitHub.

Development API keys can expire and should be regenerated if they are exposed. Store secrets locally using an ignored configuration file, environment variables, or a secret management system.

Project Status
This project is currently under development and is primarily used as a practical learning project for C# and .NET development. ```
