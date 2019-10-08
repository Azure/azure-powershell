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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the LogicAppReceiver class.
    /// </summary>
    public class PSLogicAppReceiver : PSActionGroupReceiverBase
    {
        /// <summary>
        /// Gets or sets the resourceId.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the callbackUrl.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>Gets or sets a value indicating whether or not use common alert schema.</summary>
        public bool UseCommonAlertSchema { get; set; }

        /// <summary>Initializes a new instance of the PSLogicAppReceiver class</summary>
        public PSLogicAppReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSLogicAppReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSLogicAppReceiver(LogicAppReceiver receiver)
        {
            this.Name = receiver.Name;
            this.ResourceId = receiver.ResourceId;
            this.CallbackUrl = receiver.CallbackUrl;
            this.UseCommonAlertSchema = receiver.UseCommonAlertSchema;
        }
    }
}
