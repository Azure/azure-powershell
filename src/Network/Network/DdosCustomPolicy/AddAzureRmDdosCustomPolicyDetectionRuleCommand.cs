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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyDetectionRule", SupportsShouldProcess = true), OutputType(typeof(PSDdosCustomPolicy))]
    public partial class AddAzureRmDdosCustomPolicyDetectionRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The DDoS custom policy object containing detection rules.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the detection rule to add.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The traffic type of the detection rule to add.")]
        [ValidateSet(MNM.DdosTrafficType.Tcp, MNM.DdosTrafficType.Udp, MNM.DdosTrafficType.TcpSyn, IgnoreCase = true)]
        public string TrafficType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The packets per second threshold for the detection rule to add.")]
        [ValidateRange(1, int.MaxValue)]
        public int PacketsPerSecond { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ShouldProcess(this.DdosCustomPolicy.Name, "Adding DDoS custom policy detection rule"))
            {
                if (this.DdosCustomPolicy.DetectionRules == null)
                {
                    this.DdosCustomPolicy.DetectionRules = new List<PSDdosCustomPolicyDetectionRule>();
                }

                var existingRule = this.DdosCustomPolicy.DetectionRules.Find(
                    rule => string.Equals(rule.Name, this.Name, StringComparison.OrdinalIgnoreCase));

                if (existingRule != null)
                {
                    throw new ArgumentException("DetectionRule with the specified name already exists.");
                }

                this.DdosCustomPolicy.DetectionRules.Add(new PSDdosCustomPolicyDetectionRule
                {
                    Name = this.Name,
                    TrafficType = this.TrafficType,
                    PacketsPerSecond = this.PacketsPerSecond,
                });

                WriteObject(this.DdosCustomPolicy, true);
            }
        }
    }
}