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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Association
{
    [Cmdlet(VerbsCommon.Set, "AzureNetworkSecurityGroupAssociation"), OutputType(typeof(bool))]
    public class SetAzureNetworkSecurityGroupAssociation : NetworkCmdletBase
    {
        public const string AddNetworkSecurityGroupAssociationToSubnet = "AddNetworkSecurityGroupAssociationToSubnet";
        public const string AddNetworkSecurityGroupAssociationToIaaSRole = "AddNetworkSecurityGroupAssociationToIaaSRole";
        public const string AddNetworkSecurityGroupAssociationToPaaSRole = "AddNetworkSecurityGroupAssociationToPaaSRole";
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

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToIaaSRole)]
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = AddNetworkSecurityGroupAssociationToPaaSRole)]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            Func<string> getAssociation;
            Action setAssociation;
            Action<string> removeAssociation;
            string actionMessage = "";
            string processMessage = "";
            string finishMessage = "";
            string cmdletTarget = "";

            if (string.Equals(this.ParameterSetName, AddNetworkSecurityGroupAssociationToSubnet))
            {
                getAssociation = () =>
                {
                    return Client.GetNetworkSecurityGroupForSubnet(
                        this.VirtualNetworkName,
                        this.SubnetName)
                        .Name;
                };

                setAssociation = () =>
                {
                    Client.SetNetworkSecurityGroupForSubnet(this.Name, this.VirtualNetworkName, this.SubnetName);
                };

                removeAssociation = (currentNetworkSecurityGroup) =>
                {
                    Client.RemoveNetworkSecurityGroupFromSubnet(currentNetworkSecurityGroup, this.VirtualNetworkName, this.SubnetName);
                };

                cmdletTarget = string.Format(
                    Resources.SetNSGSubnetAssociationTarget,
                    this.Name,
                    this.VirtualNetworkName,
                    this.SubnetName);

                finishMessage = string.Format(
                    Resources.ReplaceNetworkSecurityGroupInSubnetWarningSucceeded,
                    this.Name,
                    this.SubnetName,
                    this.VirtualNetworkName);
            }

            else
            {
                this.obtainedDeploymentName = Client.GetDeploymentName(this.VM, this.Slot, this.ServiceName);

                if (string.Equals(this.ParameterSetName, AddNetworkSecurityGroupAssociationToIaaSRole))
                {
                    this.RoleName = this.VM.Name;
                }

                if (string.IsNullOrEmpty(this.NetworkInterfaceName))
                {
                    getAssociation = () =>
                    {
                        return Client.GetNetworkSecurityGroupForRole(
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName)
                            .Name;
                    };

                    setAssociation = () =>
                    {
                        Client.SetNetworkSecurityGroupForRole(
                            this.Name,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName);
                    };

                    removeAssociation = (currentNetworkSecurityGroup) =>
                    {
                        Client.RemoveNetworkSecurityGroupFromRole(
                            currentNetworkSecurityGroup,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName);
                    };

                    cmdletTarget = string.Format(
                        Resources.SetNSGRoleAssociationTarget,
                        this.Name,
                        this.RoleName,
                        this.obtainedDeploymentName,
                        this.ServiceName);

                    finishMessage = string.Format(
                        Resources.ReplaceNetworkSecurityGroupInRoleWarningSucceeded,
                        this.Name,
                        this.RoleName,
                        this.obtainedDeploymentName,
                        this.ServiceName);

                }
                else
                {
                    getAssociation = () =>
                    {
                        return Client.GetNetworkSecurityGroupForNetworkInterface(
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName,
                            this.NetworkInterfaceName)
                            .Name;
                    };

                    setAssociation = () =>
                    {
                        Client.SetNetworkSecurityGroupForNetworkInterface(
                            this.Name,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName,
                            this.NetworkInterfaceName);
                    };

                    removeAssociation = (currentNetworkSecurityGroup) =>
                    {
                        Client.RemoveNetworkSecurityGroupFromNetworkInterface(
                            currentNetworkSecurityGroup,
                            this.ServiceName,
                            this.obtainedDeploymentName,
                            this.RoleName,
                            this.NetworkInterfaceName);
                    };

                    cmdletTarget = string.Format(
                        Resources.SetNSGNicAssociationTarget,
                        this.NetworkInterfaceName,
                        this.Name,
                        this.RoleName,
                        this.obtainedDeploymentName,
                        this.ServiceName);

                    finishMessage = string.Format(
                        Resources.ReplaceNetworkSecurityGroupInNicWarningSucceeded,
                        this.NetworkInterfaceName,
                        this.Name,
                        this.RoleName,
                        this.obtainedDeploymentName,
                        this.ServiceName);
                }
            }

            try
            {
                setAssociation();
            }
            catch (CloudException ce)
            {
                if (ce.Error.Code.Equals("BadRequest") && ce.Error.Message.Contains("already"))
                {
                    ConfirmAction(
                        Force.IsPresent,
                        actionMessage,
                        processMessage,
                        cmdletTarget,
                        () =>
                        {
                            var currentNetworkSecurityGroup = getAssociation();
                            removeAssociation(currentNetworkSecurityGroup);
                            setAssociation();
                            WriteVerboseWithTimestamp(finishMessage);
                        });
                }
                else
                {
                    throw;
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
