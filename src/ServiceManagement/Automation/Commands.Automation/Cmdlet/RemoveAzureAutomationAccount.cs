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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes azure automation accounts, filterd by automation account name and location.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureAutomationAccount")]
    [OutputType(typeof(AutomationAccount))]
    public class RemoveAzureAutomationAccount : AzureSMCmdlet
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
                return this.automationClient = this.automationClient ?? new AutomationClient(Profile, 
                    Profile.Context.Subscription);
            }

            set
            {
                this.automationClient = value;
            }
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [Alias("AutomationAccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the automaiton account.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.RemovingAzureAutomationResourceWarning, this.Name),
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationResourceDescription, this.Name),
                this.Name,
                () =>
                {
                    AutomationClient.DeleteAutomationAccount(this.Name);
                });
        }
    }
}
