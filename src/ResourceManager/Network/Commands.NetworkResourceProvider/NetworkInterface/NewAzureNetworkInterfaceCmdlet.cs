

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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzureNetworkInterface"), OutputType(typeof(PSNetworkInterface))]
    public class NewAzureNetworkInterfaceCmdlet : NetworkInterfaceBaseClient
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The private ip address of the Network Interface " +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "PublicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "NetworkSecurityGroupId")]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsNetworkInterfacePresent(this.ResourceGroupName, this.Name))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.OverwritingResource, Name),
                    Resources.OverwritingResourceMessage,
                    Name,
                    () => CreateNetworkInterface());
            }

            var networkInterface = CreateNetworkInterface();
            
            WriteObject(networkInterface);
        }

        private PSNetworkInterface CreateNetworkInterface()
        {
            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, Resources.SetByResource))
            {
                this.SubnetId = this.Subnet.Id;

                if (this.PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }

                if (this.NetworkSecurityGroup != null)
                {
                    this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
                }
            }

            var networkInterface = new PSNetworkInterface();
            networkInterface.Name = this.Name;
            networkInterface.Location = this.Location;
            networkInterface.IpConfigurations = new List<PSNetworkInterfaceIpConfiguration>();

            var nicIpConfiguration = new PSNetworkInterfaceIpConfiguration();
            nicIpConfiguration.Name = string.IsNullOrEmpty(this.IpConfigurationName) ? "ipconfig1" : this.IpConfigurationName;
            nicIpConfiguration.PrivateIpAllocationMethod = MNM.IpAllocationMethod.Dynamic;

            if (!string.IsNullOrEmpty(this.PrivateIpAddress))
            {
                nicIpConfiguration.PrivateIpAddress = this.PrivateIpAddress;
                nicIpConfiguration.PrivateIpAllocationMethod = MNM.IpAllocationMethod.Static;
            }

            nicIpConfiguration.Subnet = new PSResourceId();
            nicIpConfiguration.Subnet.Id = this.SubnetId;

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                nicIpConfiguration.PublicIpAddress = new PSResourceId();
                nicIpConfiguration.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                networkInterface.NetworkSecurityGroup = new PSResourceId();
                networkInterface.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }

            networkInterface.IpConfigurations.Add(nicIpConfiguration);

            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterface>(networkInterface);

            networkInterfaceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.NetworkInterfaceClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkInterfaceModel);

            var getNetworkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);

            return getNetworkInterface;
        }
    }
}

 