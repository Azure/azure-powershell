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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets 
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSBlueprint),typeof(PSPublishedBlueprint))]
    public class GetAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndVersion, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndLatestPublished, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndLatestPublished, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndVersion, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionVersion)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndLatestPublished, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndVersion, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndVersion, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndLatestPublished, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndVersion, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionVersion)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndVersion, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionVersion)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndLatestPublished, Mandatory = true, HelpMessage = ParameterHelpMessages.LatestPublishedFlag)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndLatestPublished, Mandatory = true, HelpMessage = ParameterHelpMessages.LatestPublishedFlag)]
        public SwitchParameter LatestPublished { get; set; }

        #endregion Parameters

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            var scope = GetCurrentScope();

            try
            {
                switch (ParameterSetName)
                {
                    case ParameterSetNames.ManagementGroupScope:
                        foreach (var bp in BlueprintClientWithVersion.ListBlueprints(scope))
                            WriteObject(bp, true);

                        break;
                    case ParameterSetNames.SubscriptionScope:
                        var queryScopes =
                            GetManagementGroupAncestorsForSubscription(
                                SubscriptionId ?? DefaultContext.Subscription.Id)
                                .Select(mg => FormatManagementGroupAncestorScope(mg))
                                .ToList();

                        //add current subscription scope to the list of MG scopes that we'll query
                        queryScopes.Add(scope);

                        foreach (var bp in BlueprintClientWithVersion.ListBlueprints(queryScopes))
                            WriteObject(bp, true);

                        break;
                    case ParameterSetNames.BySubscriptionAndName: case ParameterSetNames.ByManagementGroupAndName:
                        WriteObject(BlueprintClientWithVersion.GetBlueprint(scope, Name));
                        break;
                    case ParameterSetNames.BySubscriptionNameAndVersion: case ParameterSetNames.ByManagementGroupNameAndVersion:
                        WriteObject(BlueprintClient.GetPublishedBlueprint(scope, Name, Version));
                        break;
                    case ParameterSetNames.BySubscriptionNameAndLatestPublished: case ParameterSetNames.ByManagementGroupNameAndLatestPublished:
                        WriteObject(BlueprintClient.GetLatestPublishedBlueprint(scope, Name));
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
            finally
            {
                UnregisterDelegatingHandlerIfRegistered();
            }
        }
        #endregion Cmdlet Overrides

        #region Private Methods
        private string GetCurrentScope()
        {
            string scope = null;

            if (this.IsParameterBound(c => c.ManagementGroupId))
            {
                scope = string.Format(BlueprintConstants.ManagementGroupScope, ManagementGroupId);
            }
            else 
            {
                scope = this.IsParameterBound(c => c.SubscriptionId)
                    ? string.Format(BlueprintConstants.SubscriptionScope, SubscriptionId)
                    : string.Format(BlueprintConstants.SubscriptionScope, DefaultContext.Subscription.Id);
            }
            return scope;
        }
        
        #endregion Private Methods
    }
}
