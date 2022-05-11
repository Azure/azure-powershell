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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertsSuppressionRuleScope", DefaultParameterSetName = SuppressionRuleScopeParams, SupportsShouldProcess = false), OutputType(typeof(PSIScopeElement))]
    public class NewAlertsSuppressionRuleScope : SecurityCenterCmdletBase
    {
        public const string SuppressionRuleScopeParams = "AlertsSuppressionRuleScopeParams";

        [Parameter(Mandatory = true, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Entity field to scope by.")]
        public string Field { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Suppress only when field contains this specific value.")]
        public string ContainsSubstring { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SuppressionRuleScopeParams, HelpMessage = "Suppress only when field equals one of those values.")]
        public string[] AnyOf { get; set; }

        public override void ExecuteCmdlet()
        {
            var containsBound = this.IsParameterBound(c => c.ContainsSubstring);
            var inBound = this.IsParameterBound(c => c.AnyOf);

            if (!containsBound && !inBound)
            {
                throw new ArgumentException("Only \"ContainsSubstring\" or \"AnyOf\" can be populated.");
            }
            
            if (containsBound && inBound)
            {
                throw new ArgumentException("At least one of \"ContainsSubstring\" or \"AnyOf\" needs to be populated.");
            }

            if (containsBound && string.IsNullOrWhiteSpace(ContainsSubstring))
            {
                throw new ArgumentNullException(nameof(ContainsSubstring), "\"ContainsSubstring\" value can't be null");
            }

            if (inBound && (AnyOf == null || AnyOf.Length == 0))
            {
                throw new ArgumentNullException(nameof(AnyOf), "\"AnyOf\" value can't be empty");
            }

            if (containsBound)
            {
                var psScopeElementContains = new PSScopeElementContains(Field, ContainsSubstring);
                WriteObject(psScopeElementContains, enumerateCollection: false);
                return;
            }

            var psScopeElementIn = new PSScopeElementIn(Field, AnyOf);
            WriteObject(psScopeElementIn, enumerateCollection: false);
        }
    }
}