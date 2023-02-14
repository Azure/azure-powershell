﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using System;
using System.Management.Automation;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.BySubscriptionAndName), OutputType(typeof(PSBlueprintAssignment))]
    public class RemoveAzureRmBlueprintAssignment : BlueprintAssignmentCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Position = 0, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Position = 0, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AssignmentManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentObject)]
        public PSBlueprintAssignment InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        #endregion Parameters

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ParameterSetNames.ByManagementGroupAndName:
                        if (ShouldProcess(ManagementGroupId, string.Format(Resources.DeleteAssignmentShouldProcessString, Name)))
                        {
                            var deletedAssignment = BlueprintClient.DeleteBlueprintAssignment(Utils.GetScopeForManagementGroup(ManagementGroupId), Name);

                            if (deletedAssignment != null && PassThru.IsPresent)
                            {
                                WriteObject(deletedAssignment);
                            }
                        }
                        break;
                    case ParameterSetNames.BySubscriptionAndName:

                        var subscription = SubscriptionId ?? DefaultContext.Subscription.Id;

                        if (ShouldProcess(subscription, string.Format(Resources.DeleteAssignmentShouldProcessString, Name)))
                        {
                            var deletedAssignment = BlueprintClient.DeleteBlueprintAssignment(Utils.GetScopeForSubscription(subscription), Name);

                            if (deletedAssignment != null && PassThru.IsPresent)
                            {
                                WriteObject(deletedAssignment);
                            }
                        }
                        break;
                    case ParameterSetNames.DeleteBlueprintAssignmentByObject:
                        if (ShouldProcess(InputObject.Scope, string.Format(Resources.DeleteAssignmentShouldProcessString, InputObject.Name)))
                        {
                            var deletedAssignment = BlueprintClient.DeleteBlueprintAssignment(InputObject.Scope, InputObject.Name);

                            if (deletedAssignment != null && PassThru.IsPresent)
                            {
                                WriteObject(deletedAssignment);
                            }
                        }
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
