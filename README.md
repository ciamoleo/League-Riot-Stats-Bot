League Riot Stats Bot
An educational C# / .NET project that integrates with the Riot Games API to fetch League of Legends player data, match history, and performance statistics. The long-term goal of the project is a full integration with a Discord Bot for automated match analytics and banter.

Overview
The application communicates with the Riot Games API using the following data flow:

Riot ID (GameName#TagLine)
└──> PUUID
└──> Recent Match IDs
└──> Match Details
└──> Player Statistics & Sabotage Metrics

This project serves as a hands-on learning playground for practical modern C# and .NET concepts, including asynchronous programming, dependency injection, and REST API consumption.

Features
[x] Fetch Riot account data by Riot ID (GameName + TagLine)

[x] Resolve account PUUID

[x] Fetch recent Match IDs for a specific player

[x] Download and parse comprehensive Match Details

[x] Strongly-typed JSON deserialization using System.Text.Json

[x] Extract individual participant statistics:

Kills / Deaths / Assists (KDA)

Champion played

Win / Loss outcome

Damage dealt and kill participation

Tech Stack
Language: C#

Framework: .NET 10

API: Riot Games REST API

Libraries & Tools:

HttpClient (Factory pattern / Dependency Injection)

System.Text.Json

Microsoft.Extensions.Configuration.Json

Architecture & Project Structure
RiotAPIConsole/
├── Program.cs          # App bootstrapping, DI setup, and configuration
├── RiotApiClient.cs    # Riot API HTTP communication, validation, and serialization
├── ApiEndpoints.cs     # Centralized routing & URL builder for Riot API endpoints
├── Player.cs           # DTO / Model for Riot Account data
├── MatchModel.cs       # Strongly typed models for match payloads & participant stats
└── appsettings.json    # Local app configuration (git-ignored secrets)

Component Breakdown
Program.cs — Application entry point; initializes configuration, registers dependencies, and coordinates execution flow.

RiotApiClient.cs — Encapsulates raw HTTP calls to Riot endpoints, handles response status checks, and manages deserialization.

ApiEndpoints.cs — Provides constants and formatting logic for regional routing and endpoint URIs.

Player.cs & MatchModel.cs — Map raw JSON responses into C# domain objects.

Getting Started
Prerequisites
.NET 10 SDK or newer

A valid Riot Games Developer API Key

Configuration
Create an appsettings.json file inside the RiotAPIConsole/ directory:

JSON
{
  "Riot": {
    "ApiKey": "RGAPI-YOUR-API-KEY-HERE"
  }
}
Warning: Never commit your API key to a public repository. Ensure appsettings.json (or user secrets) is listed in your .gitignore.

Build & Run
Restore dependencies:
dotnet restore

Run the console project:
dotnet run --project RiotAPIConsole

Learning Objectives
This repository tracks hands-on progress in modern backend C# development:

Core OOP: Classes, encapsulation, access modifiers (private, internal, public), and immutability (readonly).

Asynchronous Patterns: Efficient I/O-bound operations using Task, async, and await.

Clean Code & Architecture: Separation of concerns, Single Responsibility Principle (SRP), and constructor-based Dependency Injection.

Resilient API Consumption: Proper HttpClient usage, handling transient HTTP errors, rate-limiting awareness, and robust JSON parsing.

Roadmap
[ ] Complete full payload mapping for MatchModel (challenges, building damage, vision scores)

[ ] Add summoner rank, tier, and LP lookup via the League-v4 endpoint

[ ] Implement custom metrics (e.g., Int Rate / Sabotage Indicator formula)

[ ] Extract API interactions into a dedicated, reusable Class Library (.dll)

[ ] Implement Discord Bot integration via Discord.Net

[ ] Build slash commands (/stats, /int-check, /last-match)

[ ] Support multi-region routing (Americas, Europe, Asia)

Security
Keep Riot development API keys private; regenerate them immediately if leaked.

Use User Secrets (dotnet user-secrets) or environment variables for production and secret storage.
