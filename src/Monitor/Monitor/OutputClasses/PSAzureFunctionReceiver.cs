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
    /// Wraps the AzureFunctionReceiver class.
    /// </summary>
    public class PSAzureFunctionReceiver : PSActionGroupReceiverBase
    {
        /// <summary>
        /// Gets or sets the function app resourceId.
        /// </summary>
        public string FunctionAppResourceId { get; set; }

        /// <summary>
        /// Gets or sets the function name
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or sets the httpTriggerUrl.
        /// </summary>
        public string HttpTriggerUrl { get; set; }

        /// <summary>Gets or sets a value indicating whether or not use common alert schema.</summary>
        public bool UseCommonAlertSchema { get; set; }

        /// <summary>Initializes a new instance of the PSAzureFunctionReceiver class</summary>
        public PSAzureFunctionReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSAzureFunctionReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSAzureFunctionReceiver(AzureFunctionReceiver receiver)
        {
            this.Name = receiver.Name;
            this.FunctionAppResourceId = receiver.FunctionAppResourceId;
            this.FunctionName = receiver.FunctionName;
            this.HttpTriggerUrl = receiver.HttpTriggerUrl;
            this.UseCommonAlertSchema = receiver.UseCommonAlertSchema.HasValue ? receiver.UseCommonAlertSchema.Value : false;
        }
    }
}
