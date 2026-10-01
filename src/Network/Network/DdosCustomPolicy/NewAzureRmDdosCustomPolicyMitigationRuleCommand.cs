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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyMitigationRule", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDdosCustomPolicyMitigationRule))]
    public class NewAzureRmDdosCustomPolicyMitigationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter(MNM.DdosMitigationTrafficScope.Tcp, MNM.DdosMitigationTrafficScope.Udp)]
        public string TrafficScope { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int? TcpPacketsPerSecond { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int? TcpConnectionsPerSecond { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int? UdpPacketsPerSecond { get; set; }

        [Parameter(Mandatory = false)]
        public PSDdosCustomPolicySourcePolicyOverride[] SourcePolicyOverride { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ShouldProcess(Name, "Create DDoS custom policy mitigation rule object"))
            {
                WriteObject(DdosCustomPolicyMitigationRuleUtils.CreateRule(
                    Name,
                    TrafficScope,
                    TcpPacketsPerSecond,
                    TcpConnectionsPerSecond,
                    UdpPacketsPerSecond,
                    SourcePolicyOverride));
            }
        }
    }
}
