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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights.ApplicationInsights
{
    [GenericBreakingChange("Output type will be updated to match API 2020-03-01-Preview", "2.0.0")]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationInsightsLinkedStorageAccount", DefaultParameterSetName = ByResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSComponentLinkedStorageAccounts))]
    public class UpdateApplicationInsightsLinkedStorageAccount : ApplicationInsightsBaseCmdlet
    {
        internal const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        internal const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        internal const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Component Name")]
        [ValidateNotNullOrEmpty]
        public string ComponentName { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "PSApplicationInsightsComponent")]
        [CmdletParameterBreakingChange("InputObject", ChangeDescription = "Parameter InputObject will be removed in upcoming Az.ApplicationInsights 2.0.0")]
        [ValidateNotNullOrEmpty]
        public PSApplicationInsightsComponent InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Component ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account ResourceId")]
        [ValidateNotNullOrEmpty]
        public string LinkedStorageAccountResourceId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string StorageAccount = new ResourceIdentifier(this.LinkedStorageAccountResourceId).ResourceName;

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceId = this.InputObject.Id;
            }

            if (this.IsParameterBound(c => c.ResourceId) || !string.IsNullOrEmpty(this.ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = identifier.ResourceGroupName;
                this.ComponentName = identifier.ResourceName;
            }

            ComponentLinkedStorageAccounts existingLinkedStorageAccount = null;

            try
            {
                existingLinkedStorageAccount = this.AppInsightsManagementClient
                                                   .ComponentLinkedStorageAccounts
                                                   .GetWithHttpMessagesAsync(this.ResourceGroupName, this.ComponentName)
                                                   .GetAwaiter()
                                                   .GetResult()
                                                   .Body;
            }
            catch (CloudException)
            {
                throw new System.ArgumentException($"Component: {this.ComponentName} Does Not Have a Linked Stoprage Account");
            }

            if (this.ShouldProcess(this.ResourceGroupName, $"Update Linked Storage Account: {StorageAccount} to Application Insights Component {this.ComponentName}"))
            {
                ComponentLinkedStorageAccounts response = this.AppInsightsManagementClient
                                                              .ComponentLinkedStorageAccounts
                                                              .UpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ComponentName, this.LinkedStorageAccountResourceId)
                                                              .GetAwaiter()
                                                              .GetResult()
                                                              .Body;
                WriteComponentLinkedStorageAccount(response);
            }
        }
    }
}
