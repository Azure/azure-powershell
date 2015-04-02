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
using Microsoft.Azure.Commands.Network.NetworkSecurityGroup.Model;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.NetworkSecurityGroup.Association
{
    [Cmdlet(VerbsCommon.Get, "AzureNetworkSecurityGroupAssociation"), OutputType(typeof(INetworkSecurityGroup))]
    public class GetAzureNetworkSecurityGroupAssociation : NetworkCmdletBase
    {
        protected const string GetNetworkSecurityGroupAssociationForSubnet = "GetNetworkSecurityGroupAssociationForSubnet";
        protected const string GetNetworkSecurityGroupAssociationForIaaSRole = "GetNetworkSecurityGroupAssociationForIaaSRole";
        protected const string GetNetworkSecurityGroupAssociationForPaaSRole = "GetNetworkSecurityGroupAssociationForPaaSRole";
        private string obtainedDeploymentName { get; set; }

        #region Subnet

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = GetNetworkSecurityGroupAssociationForSubnet)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = GetNetworkSecurityGroupAssociationForSubnet)]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        #endregion

        #region IaaS

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForIaaSRole)]
        public PersistentVMRoleContext VM { get; set; }

        #endregion

        #region PaaS

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = GetNetworkSecurityGroupAssociationForPaaSRole, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        #endregion

        #region Common

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForIaaSRole)]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForIaaSRole)]
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetNetworkSecurityGroupAssociationForPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Detailed { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            NetworkSecurityGroupGetAssociationResponse assocResponse = null;
            if (string.Equals(this.ParameterSetName, GetNetworkSecurityGroupAssociationForSubnet))
            {
                assocResponse = Client.GetNetworkSecurityGroupForSubnet(VirtualNetworkName, SubnetName);

                if (assocResponse.State != "Created")
                {
                    WriteWarningWithTimestamp(
                        string.Format(Resources.NetworkSecurityGroupNotActiveInSubnet, assocResponse.Name, VirtualNetworkName, SubnetName));

                }
            }
            else
            {
                this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);
                if (string.Equals(this.ParameterSetName, GetNetworkSecurityGroupAssociationForIaaSRole))
                {
                    this.RoleName = this.VM.Name;
                }

                if (string.IsNullOrEmpty(this.NetworkInterfaceName))
                {
                    assocResponse = Client.GetNetworkSecurityGroupForRole(
                        this.ServiceName,
                        this.obtainedDeploymentName,
                        this.RoleName);
                }
                else
                {
                    assocResponse = Client.GetNetworkSecurityGroupForNetworkInterface(
                        this.ServiceName,
                        this.obtainedDeploymentName,
                        this.RoleName,
                        this.NetworkInterfaceName);
                }
            }

            INetworkSecurityGroup securityGroup = Client.GetNetworkSecurityGroup(assocResponse.Name, Detailed);
            WriteObject(securityGroup);
        }
    }
}
