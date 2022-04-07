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
using Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AlertsSuppressionRules
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertsSuppressionRule", DefaultParameterSetName = ParameterSetNames.SubscriptionScope, SupportsShouldProcess = true), OutputType(typeof(PSAlertsSuppressionRule))]
    public class SetAlertsSuppressionRule : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        public PSAlertsSuppressionRule InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = InputObject.Name;
            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var alertsSuppressionRule = SecurityCenterClient.AlertsSuppressionRules.UpdateWithHttpMessagesAsync(name, InputObject.ConvertToNetType()).GetAwaiter().GetResult().Body;
                WriteObject(alertsSuppressionRule.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}