using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Text.Json;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class AcrToken
    {
        private readonly string _token;
        private DateTime _exp;

        public AcrToken(string token)
        {
            _token = token;
            string decodedToken = Base64UrlHelper.DecodeToString(_token.Split('.')[1]);
            int unixTimeSeconds = JsonDocument.Parse(decodedToken)
                                      .RootElement
                                      .EnumerateObject()
                                      .Where(p => p.Name == "exp")
                                      .Select(p => p.Value.GetInt32())
                                      .First();
            _exp = DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).UtcDateTime;
        }

        public string GetToken()
        {
            return _token;
        }

        public bool IsExpired(int minutesBeforeExpiration)
        {
            return DateTime.UtcNow.AddMinutes(minutesBeforeExpiration) >= _exp;
        }
    }
}
