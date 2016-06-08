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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.IPForwarding.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.IPForwarding
{
    [Cmdlet(VerbsCommon.Get, "AzureIPForwarding"), OutputType(typeof(string))]
    public class GetAzureIPForwarding : NetworkCmdletBase
    {
        public const string IaaSIPForwardingParamSet = "IaaSIPForwardingParamSet";
        public const string SlotIPForwardingParamSet = "SlotIPForwardingParamSet";

        private string obtainedDeploymentName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSIPForwardingParamSet)]
        public PersistentVMRoleContext VM { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSIPForwardingParamSet)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = SlotIPForwardingParamSet, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSIPForwardingParamSet)]
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);

            if (string.Equals(this.ParameterSetName, IaaSIPForwardingParamSet))
            {
                this.RoleName = this.VM.Name;
            }

            string ipForwardingState;
            if (string.IsNullOrEmpty(this.NetworkInterfaceName))
            {
                ipForwardingState = Client.GetIPForwardingForRole(this.ServiceName, this.obtainedDeploymentName, this.RoleName);
            }
            else
            {
                ipForwardingState = Client.GetIPForwardingForNetworkInterface(this.ServiceName, this.obtainedDeploymentName, this.RoleName, this.NetworkInterfaceName);
            }

            WriteObject(ipForwardingState);
        }
    }
}
