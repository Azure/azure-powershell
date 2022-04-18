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
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AlertsSuppressionRules
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertsSuppressionRuleScope", DefaultParameterSetName = SuppressionRuleScopeParams), OutputType(typeof(PSIScopeElement))]
    public class NewAlertsSuppressionRuleScope : SecurityCenterCmdletBase
    {
        public const string SuppressionRuleScopeParams = "AlertsSuppressionRuleScopeParams";

        [Parameter(Mandatory = true, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Entity field to scope by.")]
        public string Field { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Suppress only when field contains this specific value.")]
        public string Contains { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Suppress only when field equals one of those values.")]
        public string[] In { get; set; }

        public override void ExecuteCmdlet()
        {
            var containsBound = this.IsParameterBound(c => c.Contains);
            var inBound = this.IsParameterBound(c => c.In);

            if (!containsBound && !inBound)
            {
                throw new ArgumentException("Only \"Contains\" or \"In\" can be populated.");
            }
            
            if (containsBound && inBound)
            {
                throw new ArgumentException("At least one of \"Contains\" or \"In\" needs to be populated.");
            }

            if (containsBound && string.IsNullOrWhiteSpace(Contains))
            {
                throw new ArgumentNullException(nameof(Contains), "\"Contains\" value can't be null");
            }

            if (inBound && (In == null || In.Length == 0))
            {
                throw new ArgumentNullException(nameof(In), "\"In\" value can't be empty");
            }

            if (containsBound)
            {
                var psScopeElementContains = new PSScopeElementContains(Field, Contains);
                WriteObject(psScopeElementContains, enumerateCollection: false);
                return;
            }

            var psScopeElementIn = new PSScopeElementIn(Field, In);
            WriteObject(psScopeElementIn, enumerateCollection: false);
        }
    }
}