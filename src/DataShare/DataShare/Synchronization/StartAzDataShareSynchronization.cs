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
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;

    /// <summary>
    /// Defines the Start-AzDataShareSubscriptionSynchronization cmdlet.
    /// </summary>
    [Cmdlet(
         "Start",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSubscriptionSynchronization",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSShareSubscriptionSynchronization))]
    public class StartAzDataShareSynchronization : AzureDataShareCmdletBase
    {

        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of azure data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// The requested synchronization mode.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Synchronization mode (FullSync or Incremental)",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter()]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            this.SetParametersIfNeeded();
            if (this.ShouldProcess(this.ShareSubscriptionName, "Start"))
            {
                this.ConfirmAction(
                    this.Force,
                    this.ShareSubscriptionName,
                    this.MyInvocation.InvocationName,
                    this.ShareSubscriptionName,
                    this.StartSynchronization);
            }
        }

        private void StartSynchronization()
        {
            var startFunc = this.AsJob
                ? (Func<string, string, string, Synchronize, ShareSubscriptionSynchronization>)this.DataShareManagementClient
                    .ShareSubscriptions.BeginSynchronizeMethod
                : (Func<string, string, string, Synchronize, ShareSubscriptionSynchronization>)this.DataShareManagementClient
                    .ShareSubscriptions.SynchronizeMethod;
            try
            {
                var synchronization = startFunc(
                    this.ResourceGroupName,
                    this.AccountName,
                    this.ShareSubscriptionName,
                    new Synchronize(this.SynchronizationMode));
                this.WriteObject(synchronization.ToPsObject());
            } catch (DataShareErrorException ex)
            {
                if (ex.Response.StatusCode.Equals(HttpStatusCode.Conflict)) {
                    throw new PSArgumentException($"Synchronization already in progress.");
                }
            }
        }

        private void SetParametersIfNeeded()
        {
            if (this.ParameterSetName.Equals(
                ParameterSetNames.ResourceIdParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareSubscriptionName = parsedResourceId.GetShareSubscriptionName();
            }
        }
    }
}
