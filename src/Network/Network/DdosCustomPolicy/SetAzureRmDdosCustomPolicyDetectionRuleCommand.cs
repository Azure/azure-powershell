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
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyDetectionRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicy))]
    public class SetAzureRmDdosCustomPolicyDetectionRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The DDoS custom policy object containing the detection rule.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the detection rule to update.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "The updated traffic type of the detection rule.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(MNM.DdosTrafficType.Tcp, MNM.DdosTrafficType.Udp, MNM.DdosTrafficType.TcpSyn, IgnoreCase = true)]
        public string TrafficType { get; set; }

        [Parameter(HelpMessage = "The updated packets per second threshold of the detection rule.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? PacketsPerSecond { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.DdosCustomPolicy.DetectionRules == null)
            {
                throw new ArgumentException($"Detection rule '{this.Name}' was not found.");
            }

            var index = this.DdosCustomPolicy.DetectionRules.FindIndex(
                item => string.Equals(item.Name, this.Name, StringComparison.OrdinalIgnoreCase));
            if (index < 0)
            {
                throw new ArgumentException($"Detection rule '{this.Name}' was not found.");
            }

            if (!ShouldProcess(this.DdosCustomPolicy.Name, $"Set detection rule '{this.Name}'"))
            {
                WriteObject(this.DdosCustomPolicy);
                return;
            }

            var existingRule = this.DdosCustomPolicy.DetectionRules[index];
            var trafficType = MyInvocation.BoundParameters.ContainsKey(nameof(TrafficType))
                ? this.TrafficType
                : existingRule.TrafficType;
            var packetsPerSecond = MyInvocation.BoundParameters.ContainsKey(nameof(PacketsPerSecond))
                ? this.PacketsPerSecond.Value
                : existingRule.PacketsPerSecond;

            for (var i = 0; i < this.DdosCustomPolicy.DetectionRules.Count; i++)
            {
                if (i != index &&
                    string.Equals(
                        this.DdosCustomPolicy.DetectionRules[i].TrafficType,
                        trafficType,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException($"A detection rule with traffic type '{trafficType}' already exists.");
                }
            }

            var replacement = new PSDdosCustomPolicyDetectionRule
            {
                Name = existingRule.Name,
                TrafficType = trafficType,
                PacketsPerSecond = packetsPerSecond,
            };
            var updatedRules = new List<PSDdosCustomPolicyDetectionRule>(this.DdosCustomPolicy.DetectionRules)
            {
                [index] = replacement
            };

            this.DdosCustomPolicy.DetectionRules = updatedRules;
            WriteObject(this.DdosCustomPolicy, true);
        }
    }
}
