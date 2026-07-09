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

using Newtonsoft.Json.Linq;

using System;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>Entra Agentic Sessions support. When COPILOT_AGENT_SESSION_ID is set, silent
    /// token acquisitions pass the session id to ESTS so it can tag the issued token.</summary>
    public static class AgenticSession
    {
        public const string AgentSessionIdEnvVarName = "COPILOT_AGENT_SESSION_ID";

        public const string ClientSessionParamName = "client_session";

        public const string AgenticClaimName = "xms_cli_sid";

        public const string TelemetryPropertyName = "AgenticSession";

        private const string InitialMarker = "\0__initial__";

        private static readonly object _syncRoot = new object();
        private static string _lastSessionMarker = InitialMarker;

        public static string TryGetSessionId()
        {
            var sessionId = Environment.GetEnvironmentVariable(AgentSessionIdEnvVarName);
            return string.IsNullOrEmpty(sessionId) ? null : sessionId;
        }

        public static bool IsActive() => TryGetSessionId() != null;

        /// <summary>True when the session marker (empty=manual, session id=agent) differs from
        /// the last successful acquisition — callers force-refresh MSAL's AT cache in that case.</summary>
        public static bool HasSessionModeChanged()
        {
            var current = TryGetSessionId() ?? string.Empty;
            lock (_syncRoot)
            {
                return !string.Equals(_lastSessionMarker, current, StringComparison.Ordinal);
            }
        }

        public static void MarkAcquired()
        {
            var current = TryGetSessionId();
            lock (_syncRoot)
            {
                _lastSessionMarker = current ?? string.Empty;
            }
        }

        public static string BuildClaimsChallenge(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                throw new ArgumentException("Session id must be non-empty.", nameof(sessionId));
            }

            var challenge = new JObject
            {
                ["access_token"] = new JObject
                {
                    [AgenticClaimName] = new JObject
                    {
                        ["values"] = new JArray(sessionId)
                    }
                }
            };
            return challenge.ToString(Newtonsoft.Json.Formatting.None);
        }

        internal static void ResetForTests()
        {
            lock (_syncRoot)
            {
                _lastSessionMarker = InitialMarker;
            }
        }
    }
}
