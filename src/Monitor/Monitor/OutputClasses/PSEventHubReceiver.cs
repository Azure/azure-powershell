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
// ---

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the EventHubReceiver class.
    /// </summary>
    /// 
    public class PSEventHubReceiver : PSActionGroupReceiverBase
    {
        /// <summary>
        /// Gets or sets the SubscriptionId.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string EventHubNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the event hub name.
        /// </summary>
        public string EventHubName { get; set; }

        /// <summary>Gets or sets a value indicating whether or not use common alert schema.</summary>
        public bool UseCommonAlertSchema { get; set; }

        /// <summary>Initializes a new instance of the PSEventHubReceiver class</summary>
        public PSEventHubReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSEventHubReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSEventHubReceiver(EventHubReceiver receiver)
        {
            this.Name = receiver.Name;
            this.SubscriptionId = receiver.SubscriptionId;
            this.EventHubNameSpace = receiver.EventHubNameSpace;
            this.EventHubName = receiver.EventHubName;
            this.UseCommonAlertSchema = receiver.UseCommonAlertSchema.HasValue ? receiver.UseCommonAlertSchema.Value : false;
        }
    }
}
