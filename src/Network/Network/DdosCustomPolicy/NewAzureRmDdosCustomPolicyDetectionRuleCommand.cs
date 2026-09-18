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
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyDetectionRule", SupportsShouldProcess = true), OutputType(typeof(PSDdosCustomPolicyDetectionRule))]
    public partial class NewAzureRmDdosCustomPolicyDetectionRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS detection rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the traffic type for the DDoS detection rule. Allowed values are Tcp, Udp, and TcpSyn.")]
        [ValidateSet(MNM.DdosTrafficType.Tcp, MNM.DdosTrafficType.Udp, MNM.DdosTrafficType.TcpSyn, IgnoreCase = true)]
        public string TrafficType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the packets per second threshold for the DDoS detection rule.")]
        [ValidateRange(1, int.MaxValue)]
        public int PacketsPerSecond { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!ShouldProcess(this.Name, "Create DDoS custom policy detection rule object"))
            {
                return;
            }

            var detectionRule = new PSDdosCustomPolicyDetectionRule
            {
                Name = this.Name,
                TrafficType = this.TrafficType,
                PacketsPerSecond = this.PacketsPerSecond
            };

            WriteObject(detectionRule, true);
        }
    }
}
