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

using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    static public class ClaimsChallengeUtilities
    {
        private const string AuthenticationChallengePattern = @"(\w+) ((?:\w+="".*?""(?:, )?)+)(?:, )?";
        private const string ChallengeParameterPattern = @"(?:(\w+)=""([^""]*)"")+";

        private static readonly Regex AuthenticationChallengeRegex = new Regex(AuthenticationChallengePattern);
        private static readonly Regex ChallengeParameterRegex = new Regex(ChallengeParameterPattern);

        private static string GetClaimsChallenge(HttpResponseMessage response)
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

        public static bool MatchClaimsChallengePattern(this HttpResponseMessage response, out string claimsChallenge)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate?.Count > 0)
            {
                claimsChallenge = GetClaimsChallenge(response);
                return true;
            }

            claimsChallenge = null;
            return false;
        }

        private static IEnumerable<(string, string)> ParseWwwAuthenticate(HttpResponseMessage response)
        {
            return Enumerable.Repeat(response, 1)
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

        /// <summary>
        /// Format the error message from the response content of the original failed request.
        /// If the error is caused by CAE (continuous Access Evaluation), this will include why the request failed, and which policy was violated.
        /// </summary>
        /// <param name="claimsChallenge"></param>
        /// <param name="responseContent"></param>
        /// <returns></returns>
        public static string FormatClaimsChallengeErrorMessage(string claimsChallenge, string responseContent)
        {
            var errorMessage = TryGetErrorMessageFromOriginalResponse(responseContent);
            // Convert claimsChallenge to base64
            var claimsChallengeBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(claimsChallenge ?? string.Empty));
            return string.Format(Resources.ErrorMessageOfClaimsChallengeRequired, errorMessage, claimsChallengeBase64);
        }

        private static string TryGetErrorMessageFromOriginalResponse(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return content;
            }

            try
            {
                var parsedJson = Newtonsoft.Json.Linq.JToken.Parse(content);
                return parsedJson["error"].Value<string>("message");
            }
            catch
            {
                // If parsing fails, return the original content
                return content;
            }
        }

        /// <summary>
        /// Attempts to decode a base64 encoded claims challenge string.
        /// </summary>
        /// <param name="base64Input">The base64 encoded claims challenge string.</param>
        /// <param name="claimsChallenge">When this method returns, contains the decoded JSON claims challenge string if decoding succeeded; otherwise, <c>null</c>.</param>
        /// <returns>
        /// <c>true</c> if the base64 string was successfully decoded into a valid claims challenge; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParseClaimsChallenge(string base64Input, out string claimsChallenge)
        {
            claimsChallenge = null;

            if (string.IsNullOrWhiteSpace(base64Input))
                return false;

            try
            {
                byte[] data = Convert.FromBase64String(base64Input);
                claimsChallenge = Encoding.UTF8.GetString(data);

                return true;
            }
            catch
            {
                claimsChallenge = null;
                return false;
            }
        }
    }
}
