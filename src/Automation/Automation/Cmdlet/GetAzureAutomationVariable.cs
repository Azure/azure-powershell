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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation variables for a given account.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationVariable", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Variable))]
    public class GetAzureAutomationVariable : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the variable name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The variable name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<Variable> ret = null;
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                ret = new List<Variable>
                {
                   this.AutomationClient.GetVariable(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };
                this.GenerateCmdletOutput(ret);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                var nextLink = string.Empty;

                do
                {
                    ret = this.AutomationClient.ListVariables(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    this.GenerateCmdletOutput(ret);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
