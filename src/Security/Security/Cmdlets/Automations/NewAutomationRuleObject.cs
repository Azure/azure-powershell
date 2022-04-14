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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomationRuleObject", DefaultParameterSetName = ParameterSetNames.SecurityAutomationRule), OutputType(typeof(PSSecurityAutomationTriggeringRule))]
    public class NewAutomationRuleObject : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationRulePropertyJPath)]
        [ValidateNotNullOrEmpty]
        public string PropertyJPath { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationRuleOperator)]
        [ValidateNotNullOrEmpty]
        public string Operator { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationRuleExpectedValue)]
        [ValidateNotNullOrEmpty]
        public string ExpectedValue { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SecurityAutomationRule, Mandatory = true, HelpMessage = ParameterHelpMessages.AutomationRulePropertyType)]
        [ValidateNotNullOrEmpty]
        public string PropertyType { get; set; }

        public override void ExecuteCmdlet()
        {
            var automationRule = new PSSecurityAutomationTriggeringRule()
            {
                ExpectedValue = ExpectedValue,
                OperatorProperty = Operator,
                PropertyJPath = PropertyJPath,
                PropertyType = PropertyType
            };
            WriteObject(automationRule);
        }

    }
}
