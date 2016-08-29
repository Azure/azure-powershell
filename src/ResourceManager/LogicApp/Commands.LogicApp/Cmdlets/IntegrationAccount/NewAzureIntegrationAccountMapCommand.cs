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
    /// Creates a new integration account map.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntegrationAccountMap", SupportsShouldProcess = true), OutputType(typeof(object))]
    public class NewAzureIntegrationAccountMapCommand : LogicAppBaseCmdlet
    {

        #region Defaults

        /// <summary>
        /// Default content type for map.
        /// </summary>
        private string contentType = "application/xml";

        /// <summary>
        /// Default map type.
        /// </summary>
        private string mapType = "Xslt";

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
        [ValidateSet("Xslt", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string MapType
        {
            get { return this.mapType; }
            set { value = this.mapType; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The integration account map content type.")]
        [ValidateNotNullOrEmpty]
        public string ContentType
        {
            get { return this.contentType; }
            set { value = this.contentType; }
        }

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
                this.MapDefinition = CmdletHelper.GetContentFromFile(this.TryResolvePath(this.MapFilePath));
            }

            this.WriteObject(IntegrationAccountClient.CreateIntegrationAccountMap(this.ResourceGroupName, integrationAccount.Name, this.MapName,
                new IntegrationAccountMap
                {
                    ContentType = this.ContentType,
                    Name = this.MapName,
                    Content = this.MapDefinition,
                    MapType = (MapType) Enum.Parse(typeof (MapType), this.MapType),
                    Metadata = this.Metadata
                }), true);
        }
    }
}