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
// ------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Automations;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Automations
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomation", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityAutomation))]
    public class SetAutomation : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Security/automations", nameof(ResourceGroupName))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Security/automations")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Etag)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Etag)]
        public string Etag { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.Tags)]
        public IDictionary<string, string> Tags { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AutomationDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.AutomationDescription)]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.IsEnabled)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, HelpMessage = ParameterHelpMessages.IsEnabled)]
        public bool IsEnabled { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationScopes)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationScopes)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAutomationScope[] Scopes { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationSources)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationSources)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAutomationSource[] Sources { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActions)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActions)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAutomationAction[] Actions { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAutomation InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            var resourceGroupName = "";
            var name = "";
            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    resourceGroupName = ResourceGroupName;
                    name = Name;
                    break;
                case ParameterSetNames.ResourceId:
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
            var automation = new Automation()
            {
                Location = Location,
                Etag = Etag,
                Tags = Tags,
                Description = Description,
                IsEnabled = IsEnabled,
                Scopes = null,
                Sources = null,
                Actions = null
            };
            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var result = SecurityCenterClient.Automations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, automation).GetAwaiter().GetResult().Body;
                WriteObject(result.ConvertToPSType()); 
            }
        }

    }
}
