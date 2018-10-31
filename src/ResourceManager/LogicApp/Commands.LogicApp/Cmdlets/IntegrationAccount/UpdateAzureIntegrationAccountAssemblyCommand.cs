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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Globalization;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Updates the integration account assembly.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IntegrationAccountAssembly", SupportsShouldProcess = true)]
    [OutputType(typeof(AssemblyDefinition))]
    public class UpdateAzureIntegrationAccountAssemblyCommand : LogicAppBaseCmdlet
    {
        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account assembly name.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AssemblyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly file path.")]
        [ValidateNotNullOrEmpty]
        public string AssemblyFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly definition.")]
        [ValidateNotNullOrEmpty]
        public byte[] AssemblyDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account assembly metadata.", ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account assembly update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var integrationAccount = this.IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            var integrationAccountAssembly = this.IntegrationAccountClient.GetIntegrationAccountAssembly(this.ResourceGroupName, this.Name, this.AssemblyName);

            var updatedProperties = new AssemblyProperties();

            if (this.AssemblyDefinition == null || this.AssemblyDefinition.Length == 0)
            {
                this.AssemblyDefinition = CmdletHelper.GetBinaryContentFromFile(this.TryResolvePath(this.AssemblyFilePath));
            }

            if (this.Metadata != null)
            {
                updatedProperties.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            updatedProperties.Content = this.AssemblyDefinition;
            updatedProperties.AssemblyName = this.AssemblyName;
            updatedProperties.ContentType = "application/octet-stream";

            var integrationAccountAssemblyCopy = new AssemblyDefinition(
                id: integrationAccountAssembly.Id,
                name: integrationAccountAssembly.Name,
                type: integrationAccountAssembly.Type,
                location: integrationAccountAssembly.Location,
                tags: integrationAccountAssembly.Tags,
                properties: updatedProperties);



            this.ConfirmAction(this.Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning, "Microsoft.Logic/integrationAccounts/assemblies", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage, "Microsoft.Logic/integrationAccounts/assemblies", this.Name),
                this.Name,
                () =>
                {
                    this.WriteObject(this.IntegrationAccountClient.UpdateIntegrationAccountAssembly(this.ResourceGroupName, this.Name, this.AssemblyName, integrationAccountAssemblyCopy), true);
                },
                null);
        }
    }
}
