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
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;
using Azure.ResourceManager.Automation;
using Azure.ResourceManager.Resources;
using Azure;
using Azure.ResourceManager.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes a hybridworkergroup for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorkerGroup",
        SupportsShouldProcess = true, DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    [OutputType(typeof(void))]
    public class MoveAzureAutomationHybridRunbookWorkerGroup : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybrid worker name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker name")]
        [Alias("RunbookWorker")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [Alias("RunbookWorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target hybrid worker group name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 4, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The target hybrid runbook worker group name")]
        [Alias("TargetRunbookWorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string TargetHybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            ConfirmAction(
                       string.Format(Resources.RemoveAzureAutomationResourceDescription, "HybridWorkerGroup"),
                       Name,
                       () =>
                       {
                           var hybridWorkerUpdateParams = new HybridRunbookWorkerMoveContent()
                           {
                               HybridRunbookWorkerGroupName = this.TargetHybridRunbookWorkerGroupName
                           };

                           SubscriptionResource subResource = this.ArmClient.GetDefaultSubscription(new System.Threading.CancellationToken());
                           var subId = subResource.Data.SubscriptionId;

                           var hybridWorkerResource = HybridRunbookWorkerResource.CreateResourceIdentifier(subId, this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, this.Name);
                           this.ArmClient.GetHybridRunbookWorkerResource(hybridWorkerResource).Move(hybridWorkerUpdateParams);
                       });
        }
    }
}
