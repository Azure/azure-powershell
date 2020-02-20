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
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.CreateBlueprintAssignment), OutputType(typeof(PSBlueprintAssignment))]
    public class NewAzureRmBlueprintAssignment : BlueprintAssignmentCmdletBase
    {
        #region Parameters

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.BlueprintAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipeline = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.SystemAssignedIdentity)]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.UserAssignedIdentity)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.LockFlag)]
        public PSLockMode? Lock { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.SecureString)]
        [ValidateNotNullOrEmpty]
        public Hashtable SecureStringParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Hashtable ResourceGroupParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.Parameters)]
        [ValidateNotNull]
        public Hashtable Parameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.SecureString)]
        [ValidateNotNullOrEmpty]
        public string AssignmentFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = BlueprintConstants.ParameterHelpMessages.SubscriptionIdToAssign)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = BlueprintConstants.ParameterHelpMessages.SubscriptionIdToAssign)]
        [ValidateNotNullOrEmpty]
        public string[] SubscriptionId { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                Utils.ValidateName(Name);

                var subscriptionsList = SubscriptionId ?? new[] { DefaultContext.Subscription.Id };

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateBlueprintAssignment:
                        if (ShouldProcess(string.Join(",", subscriptionsList), string.Format(Resources.CreateAssignmentShouldProcessString, Name)))
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

                            foreach (var subscription in subscriptionsList)
                            {
                                var scope = Utils.GetScopeForSubscription(subscription);
                                ThrowIfAssignmentExists(scope, Name);
                                // Register Blueprint RP
                                RegisterBlueprintRp(subscription);

                                if (!this.IsParameterBound(c => c.UserAssignedIdentity))
                                {
                                    var spnObjectId = GetBlueprintSpn(scope, Name);
                                    AssignOwnerPermission(subscription, spnObjectId);
                                }

                                WriteObject(BlueprintClient.CreateOrUpdateBlueprintAssignment(scope, Name, assignment));
                            }
                        }
                        break;
                    case ParameterSetNames.CreateBlueprintAssignmentByFile:

                        if (ShouldProcess(string.Join(",", subscriptionsList), string.Format(Resources.CreateAssignmentShouldProcessString, Name)))
                        {
                            var parametersFilePath = GetValidatedFilePath(AssignmentFile);

                            foreach (var subscription in subscriptionsList)
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
                                    throw new Exception(string.Format(Resources.CantDeserializeJson, parametersFilePath,
                                        ex.Message));
                                }

                                var scope = Utils.GetScopeForSubscription(subscription);
                                ThrowIfAssignmentExists(scope, Name);
                                // Register Blueprint RP
                                RegisterBlueprintRp(subscription);

                                if (!IsUserAssignedIdentity(assignmentObject.Identity))
                                {
                                    // If user assigned identity is defined as the identity in the assignment
                                    // we consider the user assigned MSI, otherwise system assigned MSI.
                                    //
                                    // Assign owner permission to Blueprint SPN only if assignment is being done using
                                    // System assigned identity.
                                    // This is a no-op for user assigned identity.

                                    var spnObjectId = GetBlueprintSpn(scope, Name);
                                    AssignOwnerPermission(subscription, spnObjectId);
                                }

                                WriteObject(BlueprintClient.CreateOrUpdateBlueprintAssignment(scope, Name, assignmentObject));
                            }
                        }

                        break;
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
