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
    using Microsoft.Azure.Commands.LogicApp.Models;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Logic.Models;
    using System.Management.Automation;

    /// <summary>
    /// Gets the integration account assembly
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "IntegrationAccountAssembly", DefaultParameterSetName = ParameterSet.ByIntegrationAccount)]
    [OutputType(typeof(PSIntegrationAccountAssembly))]
    public class GetAzureIntegrationAccountAssemblyCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccount)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public IntegrationAccount ParentObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceId, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccount)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AssemblyNameHelpMessage, ParameterSetName = ParameterSet.ByInputObject)]
        [Parameter(Mandatory = false, HelpMessage = Constants.AssemblyNameHelpMessage, ParameterSetName = ParameterSet.ByResourceId)]
        [Parameter(Mandatory = false, HelpMessage = Constants.AssemblyNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccount)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts/assemblies", nameof(ResourceGroupName), nameof(ParentName))]
        [ValidateNotNullOrEmpty]
        [Alias("AssemblyName", "ResourceName")]
        public string Name { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get integration account assembly command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ParameterSetName == ParameterSet.ByInputObject)
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ResourceName;
            }
            else if (this.ParameterSetName == ParameterSet.ByResourceId)
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.WriteObject(IntegrationAccountClient.ListIntegrationAccountAssemblies(this.ResourceGroupName, this.ParentName), true);
            }
            else
            {
                this.WriteObject(IntegrationAccountClient.GetIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, this.Name));
            }
        }
    }
}