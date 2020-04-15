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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Common.Authentication;
using Newtonsoft.Json;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.UpdateBlueprintAssignment), OutputType(typeof(PSBlueprintAssignment))]
    public class SetAzureRMBlueprintAssignment : BlueprintAssignmentCmdletBase
    {
        #region Parameters

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignmentByFile, Mandatory = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.SystemAssignedIdentity)]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.UserAssignedIdentity)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.LockFlag)]
        public PSLockMode? Lock { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.SecureString)]
        [ValidateNotNullOrEmpty]
        public Hashtable SecureStringParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupParameters)]
        [ValidateNotNullOrEmpty]
        public Hashtable ResourceGroupParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Parameters)]
        [ValidateNotNull]
        public Hashtable Parameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.AssignmentFile)]
        [ValidateNotNullOrEmpty]
        public string AssignmentFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.ManagementGroupIdToAssign)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ManagementGroupIdToAssign)]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.SubscriptionIdToAssign)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionIdToAssign)]
        [ValidateNotNullOrEmpty]
        public string[] SubscriptionId { get; set; }

        #endregion
        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            Utils.ValidateName(this.Name);

            try
            {
                var subscriptionIds = SubscriptionId ?? new[] { DefaultContext.Subscription.Id };

                switch (ParameterSetName)
                {
                    case ParameterSetNames.UpdateBlueprintAssignment:

                        if (ShouldProcess(string.Join(",", subscriptionIds),
                            string.Format(Resources.UpdateAssignmentShouldProcessString, Name)))
                        {
                            var assignment = CreateAssignmentObject(
                                this.IsParameterBound(c => c.UserAssignedIdentity)
                                    ? ManagedServiceIdentityType.UserAssigned
                                    : ManagedServiceIdentityType.SystemAssigned,
                                this.IsParameterBound(c => c.UserAssignedIdentity)
                                    ? UserAssignedIdentity
                                    : null,
                                Location,
                                Blueprint.Id,
                                Lock,
                                Parameter,
                                ResourceGroupParameter,
                                SecureStringParameter);

                            foreach (var subscriptionId in subscriptionIds)
                            {
                                string targetScope = Utils.GetScopeForSubscription(subscriptionId);
                                string resourceScope = !string.IsNullOrEmpty(this.ManagementGroupId)
                                    ? Utils.GetScopeForManagementGroup(this.ManagementGroupId)
                                    : targetScope;

                                ThrowIfAssignmentNotExist(resourceScope, Name);
                                // Register Blueprint RP
                                RegisterBlueprintRp(subscriptionId);

                                if (!this.IsParameterBound(c => c.UserAssignedIdentity))
                                {
                                    var spnObjectId = GetBlueprintSpn(resourceScope, Name);
                                    AssignOwnerPermission(resourceScope, spnObjectId);
                                }

                                assignment.Scope = targetScope;
                                WriteObject(BlueprintClient.CreateOrUpdateBlueprintAssignment(resourceScope, Name, assignment));
                            }
                        }

                        break;
                    case ParameterSetNames.UpdateBlueprintAssignmentByFile:
                        if (ShouldProcess(string.Join(",", subscriptionIds),
                            string.Format(Resources.UpdateAssignmentShouldProcessString, Name)))
                        {
                            var parametersFilePath = GetValidatedFilePath(AssignmentFile);

                            foreach (var subscriptionId in subscriptionIds)
                            {
                                Assignment assignmentObject;
                                try
                                {
                                    assignmentObject = JsonConvert.DeserializeObject<Assignment>(
                                        AzureSession.Instance.DataStore.ReadFileAsText(parametersFilePath),
                                        DefaultJsonSettings.DeserializerSettings);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Can't deserialize the JSON file: " + parametersFilePath + ". " + ex.Message);
                                }

                                string targetScope = Utils.GetScopeForSubscription(subscriptionId);
                                string resourceScope = !string.IsNullOrEmpty(this.ManagementGroupId)
                                    ? Utils.GetScopeForManagementGroup(this.ManagementGroupId)
                                    : targetScope;

                                ThrowIfAssignmentNotExist(resourceScope, Name);
                                // Register Blueprint RP
                                RegisterBlueprintRp(subscriptionId);

                                if (!IsUserAssignedIdentity(assignmentObject.Identity))
                                {
                                    // If user assigned identity is defined as the identity in the assignment
                                    // we consider the user assigned MSI, otherwise system assigned MSI.
                                    //
                                    // Assign owner permission to Blueprint SPN only if assignment is being done using
                                    // System assigned identity.
                                    // This is a no-op for user assigned identity.

                                    var spnObjectId = GetBlueprintSpn(resourceScope, Name);
                                    AssignOwnerPermission(resourceScope, spnObjectId);
                                }

                                assignmentObject.Scope = targetScope;
                                WriteObject(BlueprintClient.CreateOrUpdateBlueprintAssignment(resourceScope, Name, assignmentObject));
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
