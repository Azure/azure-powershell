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
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", DefaultParameterSetName = ParameterSetNames.BlueprintAssignmentsBySubscription), OutputType(typeof(PSBlueprintAssignment))]
    public class GetAzureRmBlueprintAssignment : BlueprintCmdletBase
    {
        #region Parameters

        [Parameter(ParameterSetName = ParameterSetNames.BlueprintAssignmentByName, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BlueprintAssignmentsBySubscription, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BlueprintAssignmentByName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion Parameters

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            var subscription = SubscriptionId ?? DefaultContext.Subscription.Id;

            try
            {
                switch (ParameterSetName) {
                    case ParameterSetNames.BlueprintAssignmentsBySubscription:
                        foreach (var assignment in BlueprintClient.ListBlueprintAssignments(Utils.GetScopeForSubscription(subscription)))
                            WriteObject(assignment, true);
                        break;
                    case ParameterSetNames.BlueprintAssignmentByName:
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
