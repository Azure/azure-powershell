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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation variables for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationVariable")]
    [OutputType(typeof(Variable))]
    public class NewAzureAutomationVariable : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the variable name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "The variable name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the variable encrypted Property.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The encrypted property of the variable.")]
        [ValidateNotNull]
        public bool Encrypted { get; set; }

        /// <summary>
        /// Gets or sets the variable description.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description of the variable.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the variable value.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The value of the variable.")]
        public object Value { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            Variable variable = new Variable()
            {
                Name = this.Name,
                Encrypted = this.Encrypted,
                Description = this.Description,
                Value = this.Value,
                AutomationAccountName = this.AutomationAccountName,
                ResourceGroupName = this.ResourceGroupName
            };

            var ret = this.AutomationClient.CreateVariable(variable);

            this.GenerateCmdletOutput(ret);
        }
    }
}
