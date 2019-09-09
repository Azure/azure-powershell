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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifact", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.ImportBlueprintParameterSet), OutputType(typeof(bool))]
    public class ImportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ImportInputPath)]
        [ValidateNotNullOrEmpty]
        public string InputPath { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = false, HelpMessage = ParameterHelpMessages.ForceHelpMessage)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            RegisterBlueprintRp(SubscriptionId ?? DefaultContext.Subscription.Id);

            string scope = this.IsParameterBound(c => c.ManagementGroupId) 
                ? Utils.GetScopeForManagementGroup(ManagementGroupId) 
                : Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);
          
            ImportBlueprint(Name, scope, InputPath, Force);
            ImportArtifacts(Name, scope, InputPath);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
        #endregion
    }
}
