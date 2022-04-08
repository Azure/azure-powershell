// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Utilities.Common;
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
    static public class ClaimsChallengeUtilities
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
