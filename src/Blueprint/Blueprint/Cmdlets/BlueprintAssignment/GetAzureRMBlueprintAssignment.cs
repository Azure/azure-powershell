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

using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using System;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSBlueprintAssignment))]
    public class GetAzureRmBlueprintAssignment : BlueprintAssignmentCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            var subscription = SubscriptionId ?? DefaultContext.Subscription.Id;

            try
            {
                switch (ParameterSetName) {
                    case ParameterSetNames.ManagementGroupScope:
                        foreach (var assignment in BlueprintClient.ListBlueprintAssignments(Utils.GetScopeForManagementGroup(ManagementGroupId)))
                            WriteObject(assignment, true);
                        break;
                    case ParameterSetNames.SubscriptionScope:
                        foreach (var assignment in BlueprintClient.ListBlueprintAssignments(Utils.GetScopeForSubscription(subscription)))
                            WriteObject(assignment, true);
                        break;
                    case ParameterSetNames.ByManagementGroupAndName:
                        WriteObject(BlueprintClient.GetBlueprintAssignment(Utils.GetScopeForManagementGroup(ManagementGroupId), Name));
                        break;
                    case ParameterSetNames.BySubscriptionAndName:
                        WriteObject(BlueprintClient.GetBlueprintAssignment(Utils.GetScopeForSubscription(subscription), Name));
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion Cmdlet Overrides
    }
}
