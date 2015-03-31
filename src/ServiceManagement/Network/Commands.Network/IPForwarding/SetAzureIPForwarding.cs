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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.Azure.Commands.Network.IPForwarding
{
    [Cmdlet(VerbsCommon.Set, "AzureIPForwarding"), OutputType(typeof(bool))]
    public class SetAzureIPForwardingTo : NetworkCmdletBase
    {
        protected const string EnableIaaSIPForwardingParamSet = "EnableIaaSIPForwardingParamSet";
        protected const string DisableIaaSIPForwardingParamSet = "DisableIaaSIPForwardingParamSet";
        protected const string EnableSlotIPForwardingParamSet = "EnableSlotIPForwardingParamSet";
        protected const string DisableSlotIPForwardingParamSet = "DisableSlotIPForwardingParamSet";
        private string obtainedDeploymentName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EnableIaaSIPForwardingParamSet)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DisableIaaSIPForwardingParamSet)]
        public IPersistentVM VM { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EnableSlotIPForwardingParamSet)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DisableSlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = EnableSlotIPForwardingParamSet, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [Parameter(Position = 1, Mandatory = false, ParameterSetName = DisableSlotIPForwardingParamSet, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EnableSlotIPForwardingParamSet)]
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DisableSlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EnableIaaSIPForwardingParamSet)]
        [Parameter(Mandatory = true, ParameterSetName = EnableSlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DisableIaaSIPForwardingParamSet)]
        [Parameter(Mandatory = true, ParameterSetName = DisableSlotIPForwardingParamSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Disable { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(this.Slot))
            {
                this.Slot = DeploymentSlotType.Production;
            }

            this.obtainedDeploymentName = Client.GetDeploymentBySlot(this.ServiceName, this.Slot);

            if (string.IsNullOrEmpty(this.NetworkInterfaceName))
            {
                Client.SetIPForwardingForRole(this.ServiceName, this.obtainedDeploymentName, this.RoleName, this.Enable.IsPresent);
            }
            else
            {
                Client.SetIPForwardingForNetworkInterface(this.ServiceName, this.obtainedDeploymentName, this.RoleName, this.NetworkInterfaceName, this.Enable.IsPresent);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(this.Enable.IsPresent);
            }
        }
    }
}
