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

using System.Collections.Generic;
using System.Linq;

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{


    /// <summary>
    /// Wraps around the action group.
    /// </summary>
    public class PSActionGroupProperty : PSManagementPropertyDescriptor
    {
        /// <summary>
        /// Gets or sets the action group status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the action group short name.
        /// </summary>
        public string GroupShortName { get; set; }

        /// <summary>
        /// Gets or sets the list of email receivers.
        /// </summary>
        public IList<PSEmailReceiver> EmailReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of SMS receivers.
        /// </summary>
        public IList<PSSmsReceiver> SmsReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of webhook receviers.
        /// </summary>
        public IList<PSWebhookReceiver> WebhookReceivers { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSActionGroupProperty class.
        /// </summary>
        /// <param name="actionGroup">The action group to wrap.</param>
        public PSActionGroupProperty(ActionGroupResource actionGroup)
        {
            this.Status = actionGroup.Enabled ? "Enabled" : "Disabled";
            this.GroupShortName = actionGroup.GroupShortName;
            this.EmailReceivers = actionGroup.EmailReceivers.Select(e => new PSEmailReceiver(e)).ToList();
            this.SmsReceivers = actionGroup.SmsReceivers.Select(s => new PSSmsReceiver(s)).ToList();
            this.WebhookReceivers = actionGroup.WebhookReceivers.Select(w => new PSWebhookReceiver(w)).ToList();
        }
    }
}
