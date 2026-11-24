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
using Azure.Core;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    /// <summary>
    /// Puts the Azure PowerShell user agent in front of the SDK's own user agent, like the clients created by the
    /// Az.Accounts client factory. Added per retry, so it runs after Azure.Core's telemetry policy has set the SDK value.
    /// </summary>
    internal sealed class AzurePowerShellUserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly Func<string> _userAgent;

        /// <param name="userAgent">Gets the Azure PowerShell user agent when a request is sent, since the cmdlet's
        /// values can change between commands.</param>
        public AzurePowerShellUserAgentPolicy(Func<string> userAgent)
        {
            _userAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            var userAgent = _userAgent();
            if (string.IsNullOrEmpty(userAgent))
                return;

            var current = message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out var value) ? value : null;
            if (current == null || !current.StartsWith(userAgent, StringComparison.Ordinal))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, string.IsNullOrEmpty(current) ? userAgent : userAgent + " " + current);
            }
        }
    }
}
