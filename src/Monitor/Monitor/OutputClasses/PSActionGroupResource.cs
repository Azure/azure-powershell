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
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    /// <summary>
    /// Wraps around an Action Group.
    /// </summary>
    public class PSActionGroupResource : Resource
    {
        /// <summary>Gets or sets resource group</summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the short name of the action group. This will be used
        ///             in SMS messages.
        /// 
        /// </summary>
        public string GroupShortName { get; set; }

        /// <summary>
        /// Gets or sets indicates whether this action group is enabled. If an
        ///             action group is not enabled, then none of its receviers will
        ///             receive communications.
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the list of email receivers that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSEmailReceiver> EmailReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of SMS receivers that are part of this action
        ///             group.
        /// 
        /// </summary>
        public IList<PSSmsReceiver> SmsReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of webhook receivers that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSWebhookReceiver> WebhookReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of Itsm receivers that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSItsmReceiver> ItsmReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of voice receivers that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSVoiceReceiver> VoiceReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of arm role receivers  that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSArmRoleReceiver> ArmRoleReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of AzureFunctionReceivers  that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSAzureFunctionReceiver> AzureFunctionReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of LogicAppReceivers  that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSLogicAppReceiver> LogicAppReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of AutomationRunbookReceivers  that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSAutomationRunbookReceiver> AutomationRunbookReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of AzureAppPushReceivers  that are part of this
        ///             action group.
        /// 
        /// </summary>
        public IList<PSAzureAppPushReceiver> AzureAppPushReceivers { get; set; }

        /// <summary>Initializes a new instance of the PSActionGroup class.</summary>
        /// <param name="actionGroupResource">the action group resource</param>
        public PSActionGroupResource(ActionGroupResource actionGroupResource)
            : base(
                location: actionGroupResource.Location,
                id: actionGroupResource.Id,
                name: actionGroupResource.Name,
                type: actionGroupResource.Type,
                tags: actionGroupResource.Tags)
        {
            this.ResourceGroupName = new ResourceIdentifier(actionGroupResource.Id).ResourceGroupName;
            GroupShortName = actionGroupResource.GroupShortName;
            Enabled = actionGroupResource.Enabled;
            EmailReceivers = actionGroupResource.EmailReceivers?.Select(o => new PSEmailReceiver(o)).ToList();
            SmsReceivers = actionGroupResource.SmsReceivers?.Select(o => new PSSmsReceiver(o)).ToList();
            WebhookReceivers = actionGroupResource.WebhookReceivers?.Select(o => new PSWebhookReceiver(o)).ToList();
            ArmRoleReceivers = actionGroupResource.ArmRoleReceivers?.Select(o => new PSArmRoleReceiver(o)).ToList();
            ItsmReceivers = actionGroupResource.ItsmReceivers?.Select(o => new PSItsmReceiver(o)).ToList();
            VoiceReceivers = actionGroupResource.VoiceReceivers?.Select(o => new PSVoiceReceiver(o)).ToList();
            AzureFunctionReceivers = actionGroupResource.AzureFunctionReceivers?.Select(o => new PSAzureFunctionReceiver(o)).ToList();
            LogicAppReceivers = actionGroupResource.LogicAppReceivers?.Select(o => new PSLogicAppReceiver(o)).ToList();
            AutomationRunbookReceivers = actionGroupResource.AutomationRunbookReceivers?.Select(o => new PSAutomationRunbookReceiver(o)).ToList();
            AzureAppPushReceivers = actionGroupResource.AzureAppPushReceivers?.Select(o => new PSAzureAppPushReceiver(o)).ToList();
        }
    }
}
