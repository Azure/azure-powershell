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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Insights.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Create an AlertRuleWebhook action
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAlertRuleEmail"), OutputType(typeof(RuleEmailAction))]
    public class NewAzureRmAlertRuleEmailCommand : AzureRMCmdlet
    {
        /// <summary>
        /// Gets or sets the CustomEmails list of the action. A comma-separated list of e-mail addresses
        /// </summary>
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of custom e-mails")]
        [ValidateNotNullOrEmpty]
        public string[] CustomEmails { get; set; }

        /// <summary>
        /// Gets or sets the SendToServiceOwners flag of the action
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The send to service owner flag")]
        public SwitchParameter SendToServiceOwners { get; set; }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!this.SendToServiceOwners && (this.CustomEmails == null || this.CustomEmails.Length < 1))
            {
                throw new ArgumentException("Either SendToServiceOwners must be set or at least one custom email must be present");
            }

            var action = new RuleEmailAction
            {
                CustomEmails = this.CustomEmails,
                SendToServiceOwners = this.SendToServiceOwners
            };

            WriteObject(action);
        }
    }
}
