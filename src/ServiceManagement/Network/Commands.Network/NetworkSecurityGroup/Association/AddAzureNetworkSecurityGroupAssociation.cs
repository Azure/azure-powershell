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

using Microsoft.Azure.Commands.Network.NetworkSecurityGroup.Model;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.Azure.Commands.Network.NetworkSecurityGroup.Association
{
    [Cmdlet(VerbsCommon.Get, "AzureNetworkSecurityGroupAssociation"), OutputType(typeof(INetworkSecurityGroup))]
    public class AddAzureNetworkSecurityGroupAssociation : NetworkCmdletBase
    {
        protected const string AddNetworkSecurityGroupAssociationToSubnet = "AddNetworkSecurityGroupAssociationToSubnet";
        protected const string AddNetworkSecurityGroupAssociationToIaaSRole = "AddNetworkSecurityGroupAssociationToIaaSRole";
        protected const string AddNetworkSecurityGroupAssociationToPaaSRole = "AddNetworkSecurityGroupAssociationToPaaSRole";
        private string obtainedDeploymentName { get; set; }

        #region Common

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        #region Subnet

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AddNetworkSecurityGroupAssociationToSubnet)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AddNetworkSecurityGroupAssociationToSubnet)]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        #endregion

        #region IaaS

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToIaaSRole)]
        public PersistentVMRoleContext VM { get; set; }

        #endregion

        #region PaaS

        [Parameter(Position = 2, Mandatory = false, ParameterSetName = AddNetworkSecurityGroupAssociationToPaaSRole, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        #endregion

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToIaaSRole)]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, AddNetworkSecurityGroupAssociationToSubnet))
            {
                Client.SetNetworkSecurityGroupForSubnet(this.Name, this.SubnetName, this.VirtualNetworkName);
            }

            this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);
            if (string.Equals(this.ParameterSetName, AddNetworkSecurityGroupAssociationToIaaSRole))
            {
                this.RoleName = this.VM.Name;
            }

            if (string.IsNullOrEmpty(this.NetworkInterfaceName))
            {
                Client.SetNetworkSecurityGroupForRole(
                    this.Name,
                    this.ServiceName,
                    this.obtainedDeploymentName,
                    this.RoleName);
            }
            else
            {
                Client.SetNetworkSecurityGroupForNetworkInterface(
                    this.Name,
                    this.ServiceName,
                    this.obtainedDeploymentName,
                    this.RoleName,
                    this.NetworkInterfaceName);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
