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

using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Automations;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Automations
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomationScopeObject", DefaultParameterSetName = ParameterSetNames.SecurityAutomationScope), OutputType(typeof(PSSecurityAutomationScope))]
    public class NewAutomationScopeObject : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationScope, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationScopeDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationScope, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationScopePath)]
        [ValidateNotNullOrEmpty]
        public string ScopePath { get; set; }

        public override void ExecuteCmdlet()
        {
            var automationScope = new PSSecurityAutomationScope()
            {
                Description = Description,
                ScopePath = ScopePath
            };
            WriteObject(automationScope);
        }

    }
}
