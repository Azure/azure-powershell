using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Azure.Commands.Profile.Utilities;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ClaimsChallengeUtilities
    {
        private const string AuthenticationChallengePattern = @"(\w+) ((?:\w+="".*?""(?:, )?)+)(?:, )?";
        private const string ChallengeParameterPattern = @"(?:(\w+)=""([^""]*)"")+";

        private static readonly Regex AuthenticationChallengeRegex = new Regex(AuthenticationChallengePattern);
        private static readonly Regex ChallengeParameterRegex = new Regex(ChallengeParameterPattern);

        public static string GetClaimsChallenge(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate != null)
            {
                var headerValue = response.Headers.WwwAuthenticate.FirstOrDefault()?.ToString();//??
                foreach (var challenge in ParseChallenges(headerValue))
                {
                    if (string.Equals(challenge.Item1, "Bearer", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (var parameter in ParseChallengeParameters(challenge.Item2))
                        {
                            if (string.Equals(parameter.Item1, "claims", StringComparison.OrdinalIgnoreCase))
                            {
                                // currently we are only handling ARM claims challenges which are always b64url encoded, and must be decoded.
                                // some handling will have to be added if we intend to handle claims challenges from Graph as well since they
                                // are not encoded.
                                return Base64UrlHelper.DecodeToString(parameter.Item2);
                            }
                        }
                    }
                }
            }

            return null;
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
