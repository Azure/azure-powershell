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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyDetectionRule")]
    [OutputType(typeof(PSDdosCustomPolicyDetectionRule))]
    public class GetAzureRmDdosCustomPolicyDetectionRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The DDoS custom policy object containing detection rules.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of a detection rule. If omitted, all detection rules are returned.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.IsNullOrEmpty(this.Name))
            {
                if (this.DdosCustomPolicy.DetectionRules != null)
                {
                    WriteObject(this.DdosCustomPolicy.DetectionRules, true);
                }

                return;
            }

            var rule = this.DdosCustomPolicy.DetectionRules?.Find(
                item => string.Equals(item.Name, this.Name, StringComparison.OrdinalIgnoreCase));
            if (rule == null)
            {
                throw new ArgumentException($"Detection rule '{this.Name}' was not found.");
            }

            WriteObject(rule);
        }
    }
}
