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
    using System.Globalization;
    using System.Management.Automation;

    /// <summary>
    /// Updates the integration account map.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IntegrationAccountMap", SupportsShouldProcess = true)]
    [OutputType(typeof(IntegrationAccountMap))]
    public class UpdateAzureIntegrationAccountMapCommand : LogicAppBaseCmdlet
    {
        #region Input Paramters

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

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account map update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            var integrationAccountMap = IntegrationAccountClient.GetIntegrationAccountMap(this.ResourceGroupName,
                this.Name,
                this.MapName);

            var integrationAccountMapCopy = new IntegrationAccountMap(mapType: integrationAccountMap.MapType,
                id: integrationAccountMap.Id,
                name: integrationAccountMap.Name,
                type: integrationAccountMap.Type,
                location: integrationAccountMap.Location,
                tags: integrationAccountMap.Tags,
                parametersSchema: integrationAccountMap.ParametersSchema,
                createdTime: integrationAccountMap.CreatedTime,
                changedTime: integrationAccountMap.ChangedTime,
                content: integrationAccountMap.Content,
                contentLink: null,
                metadata: integrationAccountMap.Metadata);

            if (!string.IsNullOrEmpty(this.MapFilePath))
            {
                integrationAccountMapCopy.Content = CmdletHelper.GetStringContentFromFile(this.TryResolvePath(this.MapFilePath));
            }

            if (!string.IsNullOrEmpty(this.MapDefinition))
            {
                integrationAccountMapCopy.Content = this.MapDefinition;
                CmdletHelper.GetStringContentFromFile(this.TryResolvePath(this.MapFilePath));
            }

            if (!string.IsNullOrEmpty(this.MapType))
            {
                integrationAccountMapCopy.MapType = this.MapType;
            }

            integrationAccountMapCopy.ContentType = this.MapType.Equals("liquid", StringComparison.CurrentCultureIgnoreCase) ? "text/plain" : "application/xml";

            if (this.Metadata != null)
            {
                integrationAccountMapCopy.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning,
                    "Microsoft.Logic/integrationAccounts/maps", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage,
                    "Microsoft.Logic/integrationAccounts/maps", this.Name),
                Name,
                () =>
                {
                    this.WriteObject(
                        IntegrationAccountClient.UpdateIntegrationAccountMap(this.ResourceGroupName, this.Name,
                            this.MapName,
                            integrationAccountMapCopy), true);
                },
                null);
        }
    }
}
