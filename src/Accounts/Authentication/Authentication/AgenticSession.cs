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

using System;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Support for Entra Agentic Sessions.
    ///
    /// When Azure PowerShell runs inside an agent context (e.g. Copilot, Azure MCP), the orchestrator
    /// sets the <see cref="AgentSessionIdEnvVarName"/> environment variable. Silent token acquisitions
    /// then inject <see cref="ClientSessionParamName"/> into the MSAL token request body so ESTS can
    /// tag the issued token as agent-driven, enabling downstream RBAC / Defender / Purview policies
    /// to differentiate agent-driven from human-driven operations.
    /// </summary>
    public static class AgenticSession
    {
        public const string AgentSessionIdEnvVarName = "COPILOT_AGENT_SESSION_ID";

        public const string ClientSessionParamName = "client_session";

        public const string TelemetryPropertyName = "AgenticSession";

        /// <summary>
        /// Reads the agent session ID from the environment.
        /// </summary>
        /// <returns>The session ID, or <c>null</c> when the environment variable is unset or empty.</returns>
        public static string TryGetSessionId()
        {
            var sessionId = Environment.GetEnvironmentVariable(AgentSessionIdEnvVarName);
            return string.IsNullOrEmpty(sessionId) ? null : sessionId;
        }

        /// <summary>
        /// Indicates whether the current process is running inside an agentic session.
        /// </summary>
        public static bool IsActive() => TryGetSessionId() != null;
    }
}
