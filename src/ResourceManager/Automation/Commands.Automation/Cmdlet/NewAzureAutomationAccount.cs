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
using Microsoft.Azure.Management.Automation.Models;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;
using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Creates azure automation accounts based on automation account name and location.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationAccount")]
    [OutputType(typeof(AutomationAccount))]
    public class NewAzureAutomationAccount : ResourceManager.Common.AzureRMCmdlet
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
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [Alias("AutomationAccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The geo region of the automation account")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The plan of the automation account")]
        [ValidateSet(SkuNameEnum.Free, SkuNameEnum.Basic, IgnoreCase = true)]
        public string Plan { get; set; }

        /// <summary>
        /// Gets or sets the module tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account tags.")]
        [Alias("Tag")]
        public IDictionary Tags { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var account = this.AutomationClient.CreateAutomationAccount(this.ResourceGroupName, this.Name, this.Location, this.Plan, this.Tags);
            this.WriteObject(account);
        }
    }
}
