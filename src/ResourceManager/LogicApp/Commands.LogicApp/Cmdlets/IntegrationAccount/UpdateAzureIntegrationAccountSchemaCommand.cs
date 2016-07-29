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


using System.Globalization;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Updates the integration account schema.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntegrationAccountSchema", SupportsShouldProcess = true),
     OutputType(typeof (object))]
    public class UpdateAzureIntegrationAccountSchemaCommand : LogicAppBaseCmdlet
    {

        #region Defaults

        /// <summary>
        /// Default content type for schema.
        /// </summary>
        private string contentType = "application/xml";

        /// <summary>
        /// Default schema type.
        /// </summary>
        private string schemaType = "Xml";

        #endregion Defaults

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account schema name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema file path.")]
        [ValidateNotNullOrEmpty]
        public string SchemaFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema definition.")]
        [ValidateNotNullOrEmpty]
        public string SchemaDefinition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema type.")]
        [ValidateSet("Xml", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string SchemaType
        {
            get { return this.schemaType; }
            set { value = this.schemaType; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema content type.")]
        [ValidateNotNullOrEmpty]
        public string ContentType
        {
            get { return this.contentType; }
            set { value = this.contentType; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema metadata.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account schema create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            var integrationAccountSchema = IntegrationAccountClient.GetIntegrationAccountSchema(this.ResourceGroupName,
                this.Name,
                this.SchemaName);

            if (!string.IsNullOrEmpty(this.SchemaFilePath))
            {
                integrationAccountSchema.Content =
                    CmdletHelper.GetContentFromFile(this.TryResolvePath(this.SchemaFilePath));
            }

            if (!string.IsNullOrEmpty(this.SchemaDefinition))
            {
                integrationAccountSchema.Content = this.SchemaDefinition;
            }

            if (!string.IsNullOrEmpty(this.schemaType))
            {
                integrationAccountSchema.SchemaType = (SchemaType) Enum.Parse(typeof (SchemaType), this.SchemaType);
            }

            if (!string.IsNullOrEmpty(this.ContentType))
            {
                integrationAccountSchema.ContentType = this.ContentType;
            }

            if (this.Metadata != null)
            {
                integrationAccountSchema.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning,
                    "Microsoft.Logic/integrationAccounts/schemas", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage,
                    "Microsoft.Logic/integrationAccounts/schemas", this.Name),
                Name,
                () =>
                {
                    this.WriteObject(
                        IntegrationAccountClient.UpdateIntegrationAccountSchema(this.ResourceGroupName,
                            integrationAccount.Name,
                            this.SchemaName, integrationAccountSchema), true);
                },
                null);
        }
    }
}