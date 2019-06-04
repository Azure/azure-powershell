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
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Creates a new integration account map.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IntegrationAccountMap", SupportsShouldProcess = true)]
    [OutputType(typeof(IntegrationAccountMap))]
    public class NewAzureIntegrationAccountMapCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account map name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string MapName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account map file path.")]
        [ValidateNotNullOrEmpty]
        public string MapFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account map definition.")]
        [ValidateNotNullOrEmpty]
        public string MapDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account map type.")]
        [ValidateSet("Xslt", "Xslt20", "Xslt30", "Liquid", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string MapType { get; set; } = "Xslt";

        [Parameter(Mandatory = false, HelpMessage = "The integration account map content type.")]
        [ValidateNotNullOrEmpty]
        [CmdletParameterBreakingChange("ContentType", ChangeDescription = Constants.DeprecatedContentTypeMessage)]
        public string ContentType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account map metadata.",
        ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account map create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Metadata != null)
            {
                this.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            if (string.IsNullOrEmpty(this.MapDefinition))
            {
                this.MapDefinition = CmdletHelper.GetStringContentFromFile(this.TryResolvePath(this.MapFilePath));
            }

            this.ContentType = this.MapType.Equals("liquid", StringComparison.CurrentCultureIgnoreCase) ? "text/plain" : "application/xml";

            this.WriteObject(IntegrationAccountClient.CreateIntegrationAccountMap(this.ResourceGroupName, integrationAccount.Name, this.MapName,
                new IntegrationAccountMap
                {
                    ContentType = this.ContentType,
                    Content = this.MapDefinition,
                    MapType = this.MapType,
                    Metadata = this.Metadata
                }), true);
        }
    }
}
