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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResrouceManager.Automation.Common;
using Microsoft.Azure.Commands.ResrouceManager.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ResrouceManager.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation accounts, filterd by automation account name and location.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationAccount")]
    [OutputType(typeof(AutomationAccount))]
    public class GetAzureAutomationAccount : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [Alias("AutomationAccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<AutomationAccount> ret = null;
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByAutomationAccountName)
            {
                ret = new List<AutomationAccount> 
                { 
                   this.AutomationClient.GetAutomationAccount(this.ResourceGroupName, this.Name)
                };
            }
            else
            {
                ret = this.AutomationClient.ListAutomationAccounts(this.ResourceGroupName);
            }

            this.GenerateCmdletOutput(ret);
        }
    }
}
