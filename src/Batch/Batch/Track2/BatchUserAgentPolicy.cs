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

using Azure.Core;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Puts the Azure PowerShell user agent in front of the Track 2 SDK's own user agent, like the Track 1 client did.
    /// Added per retry, so it runs after Azure.Core's telemetry policy has set the SDK value.
    /// </summary>
    internal sealed class BatchUserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string userAgent;

        public BatchUserAgentPolicy(string userAgent)
        {
            this.userAgent = userAgent;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            string current = message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string value) ? value : null;
            if (current == null || !current.StartsWith(this.userAgent))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, string.IsNullOrEmpty(current) ? this.userAgent : this.userAgent + " " + current);
            }
        }
    }
}
