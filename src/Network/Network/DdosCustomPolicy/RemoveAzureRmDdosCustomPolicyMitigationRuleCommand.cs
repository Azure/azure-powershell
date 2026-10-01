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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicy))]
    public class RemoveAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position = 0)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            int ruleIndex = DdosCustomPolicy.MitigationRules?.FindIndex(
                item => string.Equals(item.Name, Name, StringComparison.OrdinalIgnoreCase)) ?? -1;
            if (ruleIndex < 0)
            {
                throw new ArgumentException($"Mitigation rule '{Name}' was not found.");
            }

            if (ShouldProcess(DdosCustomPolicy.Name, $"Remove mitigation rule '{Name}'"))
            {
                DdosCustomPolicy.MitigationRules.RemoveAt(ruleIndex);
            }

            WriteObject(DdosCustomPolicy);
        }
    }
}
