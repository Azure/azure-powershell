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
using Newtonsoft.Json;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintAssignment", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.CreateBlueprintAssignment), OutputType(typeof(PSBlueprintAssignment))]
    public class SetAzureRMBlueprintAssignment : BlueprintAssignmentCmdletBase
    {
        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                var subscriptionsList = SubscriptionId ?? new[] { DefaultContext.Subscription.Id };

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateBlueprintAssignment:

                        if (ShouldProcess(string.Join(",", subscriptionsList),
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

                            foreach (var subscription in subscriptionsList)
                            {
                                var scope = Utils.GetScopeForSubscription(subscription);
                                ThrowIfAssignmentNotExist(scope, Name);
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
                        if (ShouldProcess(string.Join(",", subscriptionsList),
                            string.Format(Resources.UpdateAssignmentShouldProcessString, Name)))
                        {
                            var parametersFilePath = GetValidatedFilePath(AssignmentFile);

                            foreach (var subscription in subscriptionsList)
                            {
                                Assignment assignmentObject;
                                try
                                {
                                    assignmentObject = JsonConvert.DeserializeObject<Assignment>(
                                        File.ReadAllText(parametersFilePath),
                                        DefaultJsonSettings.DeserializerSettings);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Can't deserialize the JSON file: " + parametersFilePath + ". " + ex.Message);
                                }

                                var scope = Utils.GetScopeForSubscription(subscription);
                                ThrowIfAssignmentNotExist(scope, Name);
                                // Register Blueprint RP
                                RegisterBlueprintRp(subscription);

                                if (!this.IsParameterBound(c => c.UserAssignedIdentity))
                                {
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
