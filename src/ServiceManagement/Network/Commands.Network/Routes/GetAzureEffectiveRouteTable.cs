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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Get, "AzureEffectiveRouteTable"), OutputType(typeof(IEnumerable<EffectiveRouteTable>))]
    public class GetAzureEffectiveRouteTable : NetworkCmdletBase
    {
        public const string IaaSGetEffectiveRouteTableParamSet = "IaaSGetEffectiveRouteTableParamSet";
        public const string SlotGetEffectiveRouteTableParamSet = "SlotGetEffectiveRouteTableParamSet";

        private string obtainedDeploymentName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSGetEffectiveRouteTableParamSet)]
        public PersistentVMRoleContext VM { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSGetEffectiveRouteTableParamSet)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotGetEffectiveRouteTableParamSet)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = SlotGetEffectiveRouteTableParamSet, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotGetEffectiveRouteTableParamSet)]
        [ValidateNotNullOrEmpty]
        public string RoleInstanceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = IaaSGetEffectiveRouteTableParamSet)]
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SlotGetEffectiveRouteTableParamSet)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);

            if (string.Equals(this.ParameterSetName, IaaSGetEffectiveRouteTableParamSet))
            {
                this.RoleInstanceName = this.VM.InstanceName;
            }

            GetEffectiveRouteTableResponse result;
            if (string.IsNullOrEmpty(this.NetworkInterfaceName))
            {
                result = Client.GetEffectiveRouteTableForRoleInstance(
                    this.ServiceName,
                    this.obtainedDeploymentName,
                    this.RoleInstanceName);
            }
            else
            {
                result = Client.GetEffectiveRouteTableForNetworkInterface(
                    this.ServiceName,
                    this.obtainedDeploymentName,
                    this.RoleInstanceName,
                    this.NetworkInterfaceName);
            }

            WriteObject(result.EffectiveRouteTable);
        }
    }
}
