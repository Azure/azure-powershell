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
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Collections;
    using System.Globalization;
    using System.Management.Automation;
    using Resource = Properties.Resource;

    /// <summary>
    /// Creates a new integration account assembly.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "IntegrationAccountAssembly", DefaultParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath, SupportsShouldProcess = true)]
    [OutputType(typeof(PSIntegrationAccountAssembly))]
    public class NewAzureIntegrationAccountAssemblyCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndContentLink)]
        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFileBytes)]
        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndContentLink, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFileBytes, ValueFromPipeline = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountObjectHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFilePath, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public IntegrationAccount ParentObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndContentLink, ValueFromPipelineByPropertyName = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFileBytes, ValueFromPipelineByPropertyName = true)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountResourceIdHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFilePath, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndContentLink)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFileBytes)]
        [Parameter(Mandatory = true, HelpMessage = Constants.IntegrationAccountNameHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [ResourceNameCompleter("Microsoft.Logic/integrationAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName")]
        public string ParentName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias("AssemblyName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFilePathHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFilePathHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFilePath)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFilePathHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFilePath)]
        [ValidateNotNullOrEmpty]
        public string AssemblyFilePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFileDataHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndFileBytes)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFileDataHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndFileBytes)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyFileDataHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndFileBytes)]
        [ValidateNotNullOrEmpty]
        public byte[] AssemblyData { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyContentLinkHelpMessage, ParameterSetName = ParameterSet.ByInputObjectAndContentLink)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyContentLinkHelpMessage, ParameterSetName = ParameterSet.ByResourceIdAndContentLink)]
        [Parameter(Mandatory = true, HelpMessage = Constants.AssemblyContentLinkHelpMessage, ParameterSetName = ParameterSet.ByIntegrationAccountAndContentLink)]
        [ValidateNotNullOrEmpty]
        public string ContentLink { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AssemblyMetadataHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable Metadata { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account assembly create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (this.ParameterSetName)
            {
                case ParameterSet.ByInputObjectAndContentLink:
                case ParameterSet.ByInputObjectAndFileBytes:
                case ParameterSet.ByInputObjectAndFilePath:
                {
                    var parsedResourceId = new ResourceIdentifier(this.ParentObject.Id);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentName = parsedResourceId.ResourceName;
                    break;
                }
                case ParameterSet.ByResourceIdAndContentLink:
                case ParameterSet.ByResourceIdAndFileBytes:
                case ParameterSet.ByResourceIdAndFilePath:
                {
                    var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ParentName = parsedResourceId.ParentResource.Split('/')[1];
                    break;
                }
            }

            var assemblyDefinition = new AssemblyDefinition
            {
                Properties = new AssemblyProperties
                {
                    AssemblyName = this.Name,
                    ContentType = "application/octet-stream",
                    Metadata = this.Metadata
                }
            };

            switch (this.ParameterSetName)
            {
                case ParameterSet.ByInputObjectAndContentLink:
                case ParameterSet.ByResourceIdAndContentLink:
                case ParameterSet.ByIntegrationAccountAndContentLink:
                {
                    assemblyDefinition.Properties.ContentLink = new ContentLink
                    {
                        Uri = this.ContentLink
                    };
                    assemblyDefinition.Properties.Content = null;
                    break;
                }
                case ParameterSet.ByInputObjectAndFileBytes:
                case ParameterSet.ByResourceIdAndFileBytes:
                case ParameterSet.ByIntegrationAccountAndFileBytes:
                {
                    assemblyDefinition.Properties.Content = this.AssemblyData;
                    assemblyDefinition.Properties.ContentLink = null;
                    break;
                }
                case ParameterSet.ByInputObjectAndFilePath:
                case ParameterSet.ByResourceIdAndFilePath:
                case ParameterSet.ByIntegrationAccountAndFilePath:
                {
                    assemblyDefinition.Properties.Content = CmdletHelper.GetBinaryContentFromFile(this.TryResolvePath(this.AssemblyFilePath));
                    assemblyDefinition.Properties.ContentLink = null;
                    break;
                }
            }

            if (this.ShouldProcess(this.Name, string.Format(CultureInfo.InvariantCulture, Resource.CreateIntegrationAccountArtifactMessage, Resource.Assembly, this.Name, this.ResourceGroupName)))
            {
                this.WriteObject(IntegrationAccountClient.CreateIntegrationAccountAssembly(this.ResourceGroupName, this.ParentName, this.Name, assemblyDefinition));
            }
        }
    }
}