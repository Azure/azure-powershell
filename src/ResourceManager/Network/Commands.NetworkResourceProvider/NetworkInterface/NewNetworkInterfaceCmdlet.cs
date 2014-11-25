

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
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, NetworkInterfaceCmdletName)]
    public class NewNetworkInterfaceCmdlet : NetworkInterfaceBaseClient
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(MNM.IpAllocationMethod.Dynamic, IgnoreCase = true)]
        public string AllocationMethod { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "id",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "object",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "id",
            HelpMessage = "PublicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "object",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsNetworkInterfacePresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(ResourceAlreadyPresent);
            }

            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, "object"))
            {
                this.SubnetId = this.Subnet.Id;

                if (PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }
            }

            var networkInterface = new PSNetworkInterface();
            networkInterface.Name = this.Name;
            networkInterface.Location = this.Location;
            networkInterface.Properties = new PSNetworkInterfaceProperties();
            networkInterface.Properties.IpConfigurations = new List<PSNetworkInterfaceIpConfiguration>();

            var nicIpConfiguration = new PSNetworkInterfaceIpConfiguration();
            nicIpConfiguration.Name = "ipconfig";
            nicIpConfiguration.Properties = new PSNetworkInterfaceIpConfigurationProperties();
            nicIpConfiguration.Properties.PrivateIpAllocationMethod = this.AllocationMethod;
            nicIpConfiguration.Properties.Subnet = new PSResourceId();
            nicIpConfiguration.Properties.Subnet.Id = this.SubnetId;

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                nicIpConfiguration.Properties.PublicIpAddress = new PSResourceId();
                nicIpConfiguration.Properties.PublicIpAddress.Id = this.PublicIpAddressId;
            }
            networkInterface.Properties.IpConfigurations.Add(nicIpConfiguration);

            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterfaceCreateOrUpdateParameters>(networkInterface);

            this.NetworkInterfaceClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkInterfaceModel);
            
            var getNetworkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);
            
            WriteObject(getNetworkInterface);
        }
    }
}

 