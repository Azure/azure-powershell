﻿// ----------------------------------------------------------------------------------
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
    using System.Globalization;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using System.Management.Automation;

    /// <summary>
    /// Removes the integration account schema. 
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntegrationAccountSchema", SupportsShouldProcess = true)]
    public class RemoveAzureIntegrationAccountSchemaCommand : LogicAppBaseCmdlet
    {

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account schema name.")]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the command to remove integration account schema
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.RemoveResourceWarning, "Microsoft.Logic/integrationAccounts/schemas", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.RemoveResourceMessage, "Microsoft.Logic/integrationAccounts/schemas", this.Name),
                Name,
                () => {
                    IntegrationAccountClient.RemoveIntegrationAccountSchema(this.ResourceGroupName, this.Name, this.SchemaName);
                });
        }
    }
}