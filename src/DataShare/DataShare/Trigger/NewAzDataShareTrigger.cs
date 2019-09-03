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

namespace Microsoft.Azure.Commands.DataShare.Trigger
{
    using System;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using System.Management.Automation;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the New-DataShareTrigger cmdlet.
    /// </summary>
    [Cmdlet(
         "New",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareTrigger",
         SupportsShouldProcess = true,
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet), OutputType(typeof(PSDataShareInvitation))]
    public class NewAzDataShareTrigger : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of the azure data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.ShareSubscription, "ResourceGroupName", "AccountName")]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// Name of the azure data share trigger.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share trigger name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        /// <summary>
        /// Interval at which to synchronize the data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The recurrence interval for the trigger (Day or Hour)",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Hour", "Day")]
        public string RecurrenceInterval { get; set; }

        /// <summary>
        /// The time of the first synchronization is triggered.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The start time of the scheduled synchronization for the trigger",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTime SynchronizationTime { get; set; }

        [Parameter]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                string.Format(Resources.ResourceCreateConfirmation, this.Name),
                this.Name,
                this.CreateNewTrigger);
        }

        private void CreateNewTrigger()
        {

            var triggerModel = new ScheduledTrigger
            {
                RecurrenceInterval = this.RecurrenceInterval,
                SynchronizationTime = this.SynchronizationTime,
                SynchronizationMode = SynchronizationMode.Incremental
            };

            var createFunc =
                (Func<string, string, string, string, Trigger, Trigger>)this.DataShareManagementClient.Triggers.Create;

            var trigger = createFunc(
                this.ResourceGroupName,
                this.AccountName,
                this.ShareSubscriptionName,
                this.Name,
                triggerModel) as ScheduledTrigger;

            this.WriteObject(trigger.ToPsObject());
        }
    }
}