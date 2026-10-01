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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule")]
    [OutputType(typeof(PSDdosCustomPolicyMitigationRule))]
    public class GetAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 0)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(Mandatory = false, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            var rules = DdosCustomPolicy.MitigationRules;
            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(rules ?? Enumerable.Empty<PSDdosCustomPolicyMitigationRule>(), true);
                return;
            }

            var rule = rules?.FirstOrDefault(item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase));
            if (rule == null)
            {
                throw new ArgumentException($"Mitigation rule '{Name}' was not found.");
            }

            WriteObject(rule);
        }
    }
}
