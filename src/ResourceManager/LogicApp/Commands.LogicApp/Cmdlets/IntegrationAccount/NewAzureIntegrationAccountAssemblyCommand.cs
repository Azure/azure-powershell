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
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Creates a new integration account assembly.
    /// </summary>
    [Cmdlet(VerbsCommon.New,
    AzureRMConstants.AzureRMPrefix + "IntegrationAccountAssembly",
    DefaultParameterSetName = ParameterSet.ByIntegrationAccount)]
    public class NewAzureIntegrationAccountAssemblyCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = false, HelpMessage = "The integration account resource group name.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly name.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts/assemblies", nameof(ResourceGroupName), nameof(ParentName))]
        [ValidateNotNullOrEmpty]
        [Alias("AssemblyName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account assembly file path.", ParameterSetName = ParameterSet.ByFilePath)]
        [ValidateNotNullOrEmpty]
        public string AssemblyFilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account assembly byte data.", ParameterSetName = ParameterSet.ByBytes)]
        [ValidateNotNullOrEmpty]
        public byte[] AssemblyData { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "A publicly accessible link to the integration account assembly data.", ParameterSetName = ParameterSet.ByContentLink)]
        [ValidateNotNullOrEmpty]
        public string ContentLink { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly metadata.", ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public JObject Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "An integration account assembly.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AssemblyDefinition InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly resource id.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account assembly create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var assemblyDefinition = new AssemblyDefinition
            {
                Properties = new AssemblyProperties
                {
                    ContentType = "application/octet-stream",
                    Metadata = this.Metadata
                }
            };

            // If we have been given an object to work with, use that to prepopulate data so that we can override it later
            if (this.InputObject != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];

                assemblyDefinition.Properties.AssemblyName = parsedResourceId.ResourceName;
                assemblyDefinition.Properties.ContentLink = this.InputObject.Properties.ContentLink;
            }
            else if (this.ResourceId != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];

                assemblyDefinition.Properties.AssemblyName = parsedResourceId.ResourceName;
                assemblyDefinition.Properties.ContentLink = this.IntegrationAccountClient.GetIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, parsedResourceId.ResourceName).Properties.ContentLink;
            }

            if (ParameterSetName != ParameterSet.ByIntegrationAccount)
            {
                if (ParameterSetName == ParameterSet.ByContentLink)
                {
                    assemblyDefinition.Properties.ContentLink = new ContentLink
                    {
                        Uri = this.ContentLink
                    };
                    assemblyDefinition.Properties.Content = null;
                }
                else
                {
                    if (ParameterSetName == ParameterSet.ByFilePath)
                    {
                        this.AssemblyData = CmdletHelper.GetBinaryContentFromFile(this.TryResolvePath(this.AssemblyFilePath));
                    }

                    assemblyDefinition.Properties.Content = this.AssemblyData;
                    assemblyDefinition.Properties.ContentLink = null;
                }
            }

            if(!string.IsNullOrWhiteSpace(this.Name))
            {
                assemblyDefinition.Properties.AssemblyName = this.Name;
            }

            this.WriteObject(this.IntegrationAccountClient.CreateIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, this.Name, assemblyDefinition));
        }
    }
}