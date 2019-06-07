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
using System.Text.RegularExpressions;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.UpdateBlueprintBySubscription), OutputType(typeof(PSBlueprint))]
    public class SetAzureRMBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintBySubscription, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ImportInputPath)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ImportInputPath)]
        [ValidateNotNullOrEmpty]
        public string BlueprintFile { get; set; }
        #endregion
        
        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                var bp = CreateBlueprint(GetValidatedFilePath(BlueprintFile));

                RegisterBlueprintRp(SubscriptionId ?? DefaultContext.Subscription.Id);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.UpdateBlueprintBySubscription:
                        var subScope = Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);

                        ThrowIfBlueprintNotExist(subScope, Name);

                        WriteObject(BlueprintClient.CreateOrUpdateBlueprint(subScope, Name, bp));
                        break;
                    case ParameterSetNames.UpdateBlueprintByManagementGroup:
                        var mgScope = Utils.GetScopeForManagementGroup(ManagementGroupId);

                        ThrowIfBlueprintNotExist(mgScope, Name);

                        WriteObject(BlueprintClient.CreateOrUpdateBlueprint(mgScope, Name, bp));
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion
    }
}
