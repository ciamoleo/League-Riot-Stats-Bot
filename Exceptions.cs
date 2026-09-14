using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RiotAPIConsole
{
    internal class RateLimitException : Exception
    {
        public RateLimitException()
            : base($"Przekroczono limit zapytań.")
        {
        }
    }
    internal class ApiConnectionFailed : Exception
    {
        public ApiConnectionFailed(string response)
            : base($"Błąd połączenia z serwerem, OUTPUT: {response}")
        {
        }
    }
    internal class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(string gameName, string tagLine)
            : base($"Nie znaleziono gracza: {gameName}#{tagLine}")
        { 
        }
    }
    internal class MatchNotFoundException : Exception
    {
        public MatchNotFoundException(string matchList)
            : base($"Nie znaleziono meczu.")
        {
        }
    }
    internal class ApiKeyNotFoundException : Exception
    {
        public ApiKeyNotFoundException()
            : base("Nie znaleziono klucza API")
        {
        }

    }
    internal class DeserializationProblemException : Exception
    {
        public DeserializationProblemException()
            : base("Nie udało się zdeserializować formatu JSON.")
        {
        }
    }
}
