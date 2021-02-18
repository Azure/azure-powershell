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

namespace Microsoft.Azure.Commands.DataShare.Synchronization
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the Start-AzDataShareSubscriptionSynchronization cmdlet.
    /// </summary>
    [Cmdlet(
         "Start",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSubscriptionSynchronization",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSDataShareSubscriptionSynchronization))]
    public class StartAzDataShareSynchronization : AzureDataShareCmdletBase
    {

        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
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
        /// Name of azure data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.ShareSubscription, "ResourceGroupName", "AccountName")]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// The requested synchronization mode.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Synchronization mode (FullSync or Incremental)",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Synchronization mode (FullSync or Incremental)",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("FullSync", "Incremental")]
        public string SynchronizationMode { get; set; }

        /// <summary>
        /// The resource id of the azure share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure share subscription",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.ShareSubscription)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Data share subscription object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Azure data share subscription object")]
        [ValidateNotNullOrEmpty]
        public PSDataShareSubscription InputObject { get; set; }

        [Parameter]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            this.SetParametersIfNeeded();

            this.ConfirmAction(
                Resources.StartSynchronizationConfirmation,
                this.ShareSubscriptionName,
                this.StartSynchronization);
        }

        private void StartSynchronization()
        {
            var startFunc = (Func<string, string, string, Synchronize, ShareSubscriptionSynchronization>)this
                .DataShareManagementClient
                .ShareSubscriptions.SynchronizeMethod;

            var synchronization = startFunc(
                this.ResourceGroupName,
                this.AccountName,
                this.ShareSubscriptionName,
                new Synchronize(this.SynchronizationMode));
            this.WriteObject(synchronization.ToPsObject());
        }

        private void SetParametersIfNeeded()
        {
            string resourceId = null;

            if (this.ParameterSetName.Equals(
                ParameterSetNames.ResourceIdParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.ResourceId;
            }

            if (this.ParameterSetName.Equals(
                ParameterSetNames.ObjectParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                resourceId = this.InputObject.Id;
            }

            if (!string.IsNullOrEmpty(resourceId))
            {
                var parsedResourceId = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareSubscriptionName = parsedResourceId.GetShareSubscriptionName();
            }
        }
    }
}
