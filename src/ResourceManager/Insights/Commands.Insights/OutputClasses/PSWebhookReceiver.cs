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

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the WebhookReceiver class.
    /// </summary>
    public class PSWebhookReceiver : PSActionGroupReceiverBase
    {
        /// <summary>
        /// Gets or sets the receiver's service uri.
        /// </summary>
        public string ServiceUri { get; set; }

        /// <summary>Initializes a new instance of the PSWebhookReceiver class</summary>
        public PSWebhookReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSWebhookReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSWebhookReceiver(WebhookReceiver receiver)
        {
            this.Name = receiver.Name;
            this.ServiceUri = receiver.ServiceUri;
        }
    }
}
