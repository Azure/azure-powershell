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

namespace Microsoft.Azure.Commands.GuestConfiguration.Cmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.GuestConfiguration.Common;
    using Microsoft.Azure.Commands.GuestConfiguration.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets Vm Guest Policy reports (GuestConfiguration policy reports)
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "VMGuestPolicyStatusHistory", DefaultParameterSetName = ParameterSetNames.InitiativeIdScope)]
    [OutputType(typeof(PolicyStatus))]
    public class GetAzVMGuestPolicyStatusHistory : GuestConfigurationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.InitiativeIdScope, Mandatory = true, Position = 0, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.InitiativeNameScope, Mandatory = true, Position = 0, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InitiativeIdScope, Mandatory = true, Position = 1, HelpMessage = ParameterHelpMessages.VMName)]
        [Parameter(ParameterSetName = ParameterSetNames.InitiativeNameScope, Mandatory = true, Position = 1, HelpMessage = ParameterHelpMessages.VMName)]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InitiativeNameScope, Mandatory = true, Position = 2, HelpMessage = ParameterHelpMessages.InitiativeName)]
        [ValidateNotNullOrEmpty]
        public string InitiativeName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InitiativeIdScope, Mandatory = false, Position = 2, HelpMessage = ParameterHelpMessages.InitiativeId)]
        [ValidateNotNullOrEmpty]
        public string InitiativeId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InitiativeIdScope, Mandatory = false, HelpMessage = ParameterHelpMessages.ShowOnlyChange)]
        [Parameter(ParameterSetName = ParameterSetNames.InitiativeNameScope, Mandatory = false, HelpMessage = ParameterHelpMessages.ShowOnlyChange)]
        public SwitchParameter ShowOnlyChange { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IEnumerable<PolicyStatus> policyStatuses = null;

            // get all gcrp assignments first
            var gcrpAssignments = GetAllGCRPAssignments(ResourceGroupName, VMName);

            switch (ParameterSetName)
            {
                // Process results for cmdlet
                case ParameterSetNames.InitiativeNameScope:                 
                    policyStatuses = GetPolicyStatusHistory(ResourceGroupName, VMName, gcrpAssignments, InitiativeName, ShowOnlyChange.IsPresent);
                    if (policyStatuses == null || policyStatuses.Count() > 0)
                    {
                        WriteObject(policyStatuses, true);
                    }
                    break;

                case ParameterSetNames.InitiativeIdScope:
                    if (!string.IsNullOrEmpty(InitiativeId))
                    {
                        policyStatuses = GetPolicyStatusHistoryByInitiativeId(ResourceGroupName, VMName, InitiativeId, gcrpAssignments, ShowOnlyChange.IsPresent);
                    }
                    else
                    {
                        policyStatuses = GetPolicyStatusHistory(ResourceGroupName, VMName, gcrpAssignments, null, ShowOnlyChange.IsPresent);
                    }

                    if (policyStatuses == null || policyStatuses.Count() > 0)
                    {
                        WriteObject(policyStatuses, true);
                    }
                    break;
            }
        }
    }
}