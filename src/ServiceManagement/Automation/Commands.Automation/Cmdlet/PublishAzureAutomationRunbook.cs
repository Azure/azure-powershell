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

using System;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Publishes an azure automation runbook.
    /// </summary>
    [Cmdlet(VerbsData.Publish, "AzureAutomationRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Runbook))]
    public class PublishAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The publish runbook by runbook id parameter set.
        /// </summary>
        private const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The publish runbook by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Runbook runbook;

            if (this.Id.HasValue)
            {
                runbook = this.AutomationClient.PublishRunbook(this.AutomationAccountName, this.Id.Value);
            }
            else
            {
                runbook = this.AutomationClient.PublishRunbook(this.AutomationAccountName, this.Name);
            }

            this.WriteObject(runbook);
        }
    }
}
