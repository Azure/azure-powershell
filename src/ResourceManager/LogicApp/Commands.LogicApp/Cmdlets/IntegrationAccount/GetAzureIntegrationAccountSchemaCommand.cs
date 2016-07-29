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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;

    /// <summary>
    /// Gets the integration account schema by name 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntegrationAccountSchema"), OutputType(typeof (object))]
    public class GetAzureIntegrationAccountSchemaCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        [Parameter(Mandatory = false, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account name.")]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account schema name.")]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get integration account schema command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (string.IsNullOrEmpty(this.SchemaName))
            {
                this.WriteObject(IntegrationAccountClient.ListIntegrationAccountSchemas(this.ResourceGroupName,this.Name), true);
            }
            else
            {
                this.WriteObject(IntegrationAccountClient.GetIntegrationAccountSchema(this.ResourceGroupName, this.Name, this.SchemaName), true);
            }
        }
    }
}