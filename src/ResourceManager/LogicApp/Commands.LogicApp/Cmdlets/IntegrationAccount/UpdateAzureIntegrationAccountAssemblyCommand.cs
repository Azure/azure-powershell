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
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Updates the integration account assembly.
    /// </summary>
    [Cmdlet(VerbsCommon.Set,
        AzureRMConstants.AzureRMPrefix + "IntegrationAccountAssembly",
        DefaultParameterSetName = ParameterSet.ByIntegrationAccount)]
    [OutputType(typeof(AssemblyDefinition))]
    public class UpdateAzureIntegrationAccountAssemblyCommand : LogicAppBaseCmdlet
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
        /// Executes the integration account assembly update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            AssemblyDefinition originalAssembly;

            // If we have been given an object to work with, use that to prepopulate data so that we can override it later
            if (this.InputObject != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];
                this.Name = this.InputObject.Name;

                originalAssembly = this.InputObject;
            }
            else if (this.ResourceId != null)
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentName = parsedResourceId.ParentResource.Split('/')[1];
                this.Name = parsedResourceId.ResourceName;

                originalAssembly = this.IntegrationAccountClient.GetIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, parsedResourceId.ResourceName);
            } else
            {
                originalAssembly = this.IntegrationAccountClient.GetIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, this.Name);
            }

            var newAssembly = new AssemblyDefinition(
                id: originalAssembly.Id,
                name: originalAssembly.Name,
                type: originalAssembly.Type,
                location: originalAssembly.Location,
                tags: originalAssembly.Tags,
                properties: originalAssembly.Properties);
            newAssembly.Properties.ContentType = "application/octet-stream";

            // If we have been given content use that
            if (ParameterSetName != ParameterSet.ByIntegrationAccount)
            {
                if (ParameterSetName == ParameterSet.ByContentLink)
                {
                    newAssembly.Properties.ContentLink = new ContentLink
                    {
                        Uri = this.ContentLink
                    };
                    newAssembly.Properties.Content = null;
                }
                else
                {
                    if (ParameterSetName == ParameterSet.ByFilePath)
                    {
                        this.AssemblyData = CmdletHelper.GetBinaryContentFromFile(this.TryResolvePath(this.AssemblyFilePath));
                    }

                    newAssembly.Properties.Content = this.AssemblyData;
                    newAssembly.Properties.ContentLink = null;
                }
            }

            this.ConfirmAction(
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage, "Microsoft.Logic/integrationAccounts/assemblies", this.Name),
                this.Name,
                () =>
                {
                    this.WriteObject(this.IntegrationAccountClient.UpdateIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, this.Name, newAssembly));
                });
        }
    }
}