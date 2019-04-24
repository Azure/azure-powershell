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

using Microsoft.Azure.Commands.Blueprint.Models;
using System;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Azure.Commands.Blueprint.Common;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using BlueprintConstants = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;


namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByName), OutputType(typeof(PSBlueprintAssignment))]
    public class RemoveAzureRmBlueprintAssignment : BlueprintCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByObject, Position = 0, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByName, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssignmentSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNull]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DeleteBlueprintAssignmentByObject, Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentObject)]
        public PSBlueprintAssignment InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        #endregion Parameters


        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            var subscription = SubscriptionId ?? DefaultContext.Subscription.Id;

            try
            {
                switch (ParameterSetName)
                {
                    case ParameterSetNames.DeleteBlueprintAssignmentByName:
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
                        if (ShouldProcess(subscription, string.Format(Resources.DeleteAssignmentShouldProcessString, InputObject.Name)))
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
