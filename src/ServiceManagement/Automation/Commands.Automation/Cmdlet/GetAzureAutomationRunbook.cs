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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation runbooks for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationRunbook", DefaultParameterSetName = ByAll)]
    [OutputType(typeof(Runbook))]
    public class GetAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The get runbook by runbook id parameter set.
        /// </summary>
        private const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The get runbook by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// The get runbook by schedule name parameter set.
        /// </summary>
        private const string ByScheduleName = "ByScheduleName";

        /// <summary>
        /// The get all parameter set.
        /// </summary>
        private const string ByAll = "ByAll";

        /// <summary>
        /// Gets or sets the runbook Id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByScheduleName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule name.")]
        public string ScheduleName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            IEnumerable<Runbook> runbooks;
            if (this.Id.HasValue)
            {
                // ByRunbookId
                runbooks = new List<Runbook>
                               {
                                   this.AutomationClient.GetRunbook(
                                       this.AutomationAccountName, this.Id.Value)
                               };
            }
            else if (this.Name != null)
            {
                // ByRunbookName
                runbooks = new List<Runbook> { this.AutomationClient.GetRunbook(this.AutomationAccountName, this.Name) };
            }
            else if (this.ScheduleName != null)
            {
                // ByScheduleName
                runbooks = this.AutomationClient.ListRunbookByScheduleName(
                    this.AutomationAccountName, this.ScheduleName);
            }
            else
            {
                // ByAll
                runbooks = this.AutomationClient.ListRunbooks(this.AutomationAccountName);
            }

            this.WriteObject(runbooks, true);
        }
    }
}
