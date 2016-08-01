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
    using System.Management.Automation;

    /// <summary>
    /// Gets the upgraded definition for a workflow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmLogicAppUpgradedDefinition"), OutputType(typeof(object))]
    public class GetAzureLogicAppUpgradedDefinitionCommand : LogicAppBaseCmdlet
    {

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group for the workflow.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the workflow.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The target schema version for the definition.")]
        [ValidateNotNullOrEmpty]
        public string TargetSchemaVersion { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get workflow command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.WriteObject(LogicAppClient.GetWorkflowUpgradedDefinition(this.ResourceGroupName, this.Name, this.TargetSchemaVersion), false);
        }
    }
}