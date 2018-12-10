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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Logic.Models;
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Removes the integration account batch configuration. 
    /// </summary>
    [Cmdlet(VerbsCommon.Remove,
    AzureRMConstants.AzureRMPrefix + "IntegrationAccountBatchConfiguration",
    DefaultParameterSetName = ParameterSet.ByIntegrationAccount)]
    [OutputType(typeof(void))]
    public class RemoveAzureIntegrationAccountBatchConfigurationCommand : LogicAppBaseCmdlet
    {

        #region Input Paramters

        [Parameter(Mandatory = false, HelpMessage = "The integration account resource group name.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account batch configuration name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts/batchConfigurations", nameof(ResourceGroupName), nameof(ParentName))]
        [ValidateNotNullOrEmpty]
        [Alias("BatchConfigurationName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "An integration account batch configuration.", ParameterSetName = ParameterSet.ByInputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public BatchConfiguration InputObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account batch configuration resource id.", ParameterSetName = ParameterSet.ByResourceId, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the command to remove integration account batch configuration
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParameterSet.ByInputObject)
            {
                var parsedResourceId = new ResourceIdentifier(InputObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];
                this.Name = parsedResourceId.ResourceName;
            }
            else if (ParameterSetName == ParameterSet.ByResourceId)
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];
                this.Name = parsedResourceId.ResourceName;
            }

            base.ExecuteCmdlet();
            this.ConfirmAction(
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.RemoveResourceMessage, "Microsoft.Logic/integrationAccounts/batchConfigurations", this.Name),
                this.Name,
                () => {
                    this.IntegrationAccountClient.RemoveIntegrationAccountBatchConfiguration(this.ResourceGroupName, this.ParentName, this.Name);
                });
        }
    }
}