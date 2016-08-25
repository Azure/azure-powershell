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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation accounts, filterd by automation account name and location.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationAccount", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(AutomationAccount))]
    public class GetAzureAutomationAccount : ResourceManager.Common.AzureRMCmdlet
    {
        /// <summary>
        /// The automation client.
        /// </summary>
        private IAutomationClient automationClient;

        /// <summary>
        /// Gets or sets the automation client base.
        /// </summary>
        public IAutomationClient AutomationClient
        {
            get
            {
                return this.automationClient = this.automationClient ?? new AutomationClient(DefaultProfile.Context);
            }

            set
            {
                this.automationClient = value;
            }
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAutomationAccountName, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAutomationAccountName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
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
                this.WriteObject(ret, true);
            }
            else
            {
                string nextLink = string.Empty;

                do
                {
                    ret = this.AutomationClient.ListAutomationAccounts(this.ResourceGroupName, ref nextLink);
                    this.WriteObject(ret, true);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
