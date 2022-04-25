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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomationActionObject", DefaultParameterSetName = ParameterSetNames.SecurityAutomationActionLogicApp), OutputType(typeof(PSSecurityAutomationAction))]
    public class NewAutomationActionObject : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionLogicApp, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActionLogicAppResourceId)]
        [ValidateNotNullOrEmpty]
        public string LogicAppResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionLogicApp, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActionLogicAppUri)]
        [ValidateNotNullOrEmpty]
        public string Uri { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionEventHub, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActionEventHubResourceId)]
        [ValidateNotNullOrEmpty]
        public string EventHubResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionEventHub, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActionEventHubConnectionString)]
        [ValidateNotNullOrEmpty]
        public string ConnectionString { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionEventHub, Mandatory = false, HelpMessage = ParameterHelpMessages.AutomationActionEventHubSasPolicyName)]
        public string SasPolicyName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationActionWorkspace, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationActionWorkspaceResourceId)]
        public string WorkspaceResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SecurityAutomationActionLogicApp:
                    var automationActionLogicApp = new PSSecurityAutomationActionLogicApp()
                    {
                        LogicAppResourceId = LogicAppResourceId,
                        Uri = Uri
                    };
                    WriteObject(automationActionLogicApp);
                    break;
                case ParameterSetNames.SecurityAutomationActionEventHub:
                    var automationActionEventHub = new PSSecurityAutomationActionEventHub()
                    {
                        EventHubResourceId = EventHubResourceId,
                        ConnectionString = ConnectionString,
                        SasPolicyName =SasPolicyName
                    };
                    WriteObject(automationActionEventHub);
                    break;
                case ParameterSetNames.SecurityAutomationActionWorkspace:
                    var automationActionWorkspace = new PSSecurityAutomationActionWorkspace()
                    {
                        WorkspaceResourceId = WorkspaceResourceId
                    };
                    WriteObject(automationActionWorkspace);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }

    }
}
