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

using System.Management.Automation;
using System.Security.Permissions;
using Job = Microsoft.Azure.Commands.Automation.Model.Job;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Starts an Azure automation runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureAutomationRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Job))]
    public class StartAzureAutomationRunbook : StartAzureAutomationRunbookBase
    {
        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Job job;

            if (this.Id.HasValue)
            {
                // ByRunbookId
                job = this.AutomationClient.StartRunbook(
                    this.AutomationAccountName, this.Id.Value, this.Parameters);
            }
            else
            {
                // ByRunbookName
                job = this.AutomationClient.StartRunbook(
                    this.AutomationAccountName, this.Name, this.Parameters);
            }

            this.WriteObject(job);
        }
    }
}
