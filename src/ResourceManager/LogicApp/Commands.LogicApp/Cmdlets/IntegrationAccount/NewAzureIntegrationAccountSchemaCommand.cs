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

    /// <summary>
    /// Creates a new integration account schema.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntegrationAccountSchema", SupportsShouldProcess = true), OutputType(typeof(object))]
    public class NewAzureIntegrationAccountSchemaCommand : LogicAppBaseCmdlet
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

        #region Input Parameters

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

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account schema create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Metadata != null)
            {
                this.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            if (string.IsNullOrEmpty(this.SchemaDefinition))
            {
                this.SchemaDefinition = CmdletHelper.GetContentFromFile(this.TryResolvePath(this.SchemaFilePath));
            }

            this.WriteObject(
                IntegrationAccountClient.CreateIntegrationAccountSchema(this.ResourceGroupName, integrationAccount.Name,
                    this.SchemaName,
                    new IntegrationAccountSchema
                    {
                        ContentType = this.contentType,
                        Name = this.SchemaName,
                        SchemaType = (SchemaType) Enum.Parse(typeof (SchemaType), this.schemaType),                        
                        Content = this.SchemaDefinition,
                        Metadata = this.Metadata
                    }), true);
        }
    }
}