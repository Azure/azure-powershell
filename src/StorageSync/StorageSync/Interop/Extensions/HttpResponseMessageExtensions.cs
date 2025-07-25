using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Extensions
{
    static public class HttpResponseMessageExtensions
    {
        private const string AuthenticationChallengePattern = @"(\w+) ((?:\w+="".*?""(?:, )?)+)(?:, )?";
        private const string ChallengeParameterPattern = @"(?:(\w+)=""([^""]*)"")+";

        private static readonly Regex AuthenticationChallengeRegex = new Regex(AuthenticationChallengePattern);
        private static readonly Regex ChallengeParameterRegex = new Regex(ChallengeParameterPattern);

        public static string GetClaimsChallenge(HttpResponseMessage response)
        {
            return ParseWwwAuthenticate(response)?
                .Where((p) => string.Equals(p.Item1, "claims", StringComparison.OrdinalIgnoreCase))
                .Select(p => Base64UrlHelper.DecodeToString(p.Item2))
                .FirstOrDefault();
        }

        public static string GetWwwAuthenticateMessage(this HttpResponseMessage response)
        {
            return string.Join(string.Empty, ParseWwwAuthenticate(response)?.Select(p => $"{p.Item1}: {p.Item2}{Environment.NewLine}"));
        }

        public static bool MatchClaimsChallengePattern(this HttpResponseMessage response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate?.Count > 0;
        }

        private static IEnumerable<(string, string)> ParseWwwAuthenticate(HttpResponseMessage response)
        {
            return Enumerable.Repeat(response, 1)
                .Where(r => r.MatchClaimsChallengePattern())
                .Select(r => r.Headers.WwwAuthenticate.FirstOrDefault().ToString())
                .SelectMany(h => ParseChallenges(h))
                .Where(c => string.Equals(c.Item1, "Bearer", StringComparison.OrdinalIgnoreCase))
                .SelectMany(b => ParseChallengeParameters(b.Item2));
        }

        private static IEnumerable<(string, string)> ParseChallenges(string headerValue)
        {
            var challengeMatches = AuthenticationChallengeRegex.Matches(headerValue);

            for (int i = 0; i < challengeMatches.Count; i++)
            {
                yield return (challengeMatches[i].Groups[1].Value, challengeMatches[i].Groups[2].Value);
            }
        }

        private static IEnumerable<(string, string)> ParseChallengeParameters(string challengeValue)
        {
            var paramMatches = ChallengeParameterRegex.Matches(challengeValue);

            for (int i = 0; i < paramMatches.Count; i++)
            {
                yield return (paramMatches[i].Groups[1].Value, paramMatches[i].Groups[2].Value);
            }
        }
    }
}
