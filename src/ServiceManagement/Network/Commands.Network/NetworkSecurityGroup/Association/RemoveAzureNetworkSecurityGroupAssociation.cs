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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Subnet
{
    [Cmdlet(VerbsCommon.Remove, "AzureNetworkSecurityGroupAssociation"), OutputType(typeof(bool))]
    public class RemoveAzureNetworkSecurityGroupAssociation : NetworkCmdletBase
    {
        public const string RemoveNetworkSecurityGroupAssociationFromSubnet = "RemoveNetworkSecurityGroupAssociationFromSubnet";
        public const string RemoveNetworkSecurityGroupAssociationFromIaaSRole = "RemoveNetworkSecurityGroupAssociationFromIaaSRole";
        public const string RemoveNetworkSecurityGroupAssociationFromPaaSRole = "RemoveNetworkSecurityGroupAssociationFromPaaSRole";
        private string obtainedDeploymentName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #region Subnet

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromSubnet)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromSubnet)]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        #endregion

        #region IaaS

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromIaaSRole)]
        public PersistentVMRoleContext VM { get; set; }

        #endregion

        #region PaaS

        [Parameter(Position = 2, Mandatory = false, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromPaaSRole, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        #endregion

        #region Common

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromIaaSRole)]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromIaaSRole)]
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveNetworkSecurityGroupAssociationFromPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            string actionMessage = null;
            string processMessage = null;
            string successMessage = null;
            Action removeAsssociation = null;

            if (string.Equals(this.ParameterSetName, RemoveNetworkSecurityGroupAssociationFromSubnet))
            {
                actionMessage = string.Format(
                    Resources.RemoveNetworkSecurityGroupFromSubnetWarning,
                    this.Name,
                    this.SubnetName,
                    this.VirtualNetworkName);

                processMessage = Resources.RemoveNetworkSecurityGroupFromSubnetWarning;
                successMessage = string.Format(
                    Resources.RemoveNetworkSecurityGroupFromSubnetSucceeded,
                    this.Name,
                    this.VirtualNetworkName,
                    this.SubnetName);

                removeAsssociation = () =>
                {
                    Client.RemoveNetworkSecurityGroupFromSubnet(this.Name, this.VirtualNetworkName, this.SubnetName);
                };
            }
            else
            {
                this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);
                if (string.Equals(this.ParameterSetName, RemoveNetworkSecurityGroupAssociationFromIaaSRole))
                {
                    this.RoleName = this.VM.Name;
                }

                if (string.IsNullOrEmpty(this.NetworkInterfaceName))
                {
                    actionMessage = string.Format(
                        Resources.RemoveNetworkSecurityGroupFromRoleWarning,
                        this.Name,
                        this.RoleName,
                        this.ServiceName);

                    processMessage = Resources.RemoveNetworkSecurityGroupFromRoleWarning;

                    successMessage = string.Format(
                        Resources.RemoveNetworkSecurityGroupFromRoleSucceeded,
                        this.Name,
                        this.RoleName,
                        this.ServiceName);

                    removeAsssociation = () =>
                    {
                        Client.RemoveNetworkSecurityGroupFromRole(
                            this.Name,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName);
                    };
                }
                else
                {
                    actionMessage = string.Format(
                        Resources.RemoveNetworkSecurityGroupFromNicWarning,
                        this.Name,
                        this.NetworkInterfaceName,
                        this.RoleName,
                        this.ServiceName);

                    processMessage = Resources.RemoveNetworkSecurityGroupFromRoleWarning;

                    successMessage = string.Format(
                        Resources.RemoveNetworkSecurityGroupFromNicSucceeded,
                        this.Name,
                        this.NetworkInterfaceName,
                        this.RoleName,
                        this.ServiceName);

                    removeAsssociation = () =>
                    {
                        Client.RemoveNetworkSecurityGroupFromNetworkInterface(
                            this.Name,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName,
                            this.NetworkInterfaceName);
                    };
                }
            }

            ConfirmAction(
                Force.IsPresent,
                actionMessage,
                processMessage,
                Name,
                () =>
                {
                    removeAsssociation();

                    WriteVerboseWithTimestamp(successMessage);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
