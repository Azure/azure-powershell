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

using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.WindowsAzure;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, VirtualNetworkCmdletName)]
    public class NewVirtualNetworkCmdlet : VirtualNetworkBaseClient
    {
        [Parameter(
         Mandatory = true,
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address prefixes of the virtual network")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of Dns Servers")]
        public List<string> DnsServer { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The list of subnets")]
        public List<PSSubnet> Subnet { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var vnet = new PSVirtualNetwork();
            vnet.Name = this.Name;
            vnet.ResourceGroupName = this.ResourceGroupName;
            vnet.Location = this.Location;
            vnet.Properties = new PSVirtualNetworkProperties();
            vnet.Properties.AddressSpace = new PSAddressSpace();
            vnet.Properties.AddressSpace.AddressPrefixes = this.AddressPrefix;
            vnet.Properties.DhcpOptions = new PSDhcpOptions();
            vnet.Properties.DhcpOptions.DnsServers = this.DnsServer;

            vnet.Properties.Subnets = new List<PSSubnet>();
            vnet.Properties.Subnets = this.Subnet;

            // Map to the sdk object
            var vnetModel = Mapper.Map<MNM.VirtualNetworkCreateOrUpdateParameters>(vnet);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetModel);

            var getVirtualNetwork = this.GetVirtualNetwork(this.ResourceGroupName, this.Name);
            WriteObject(getVirtualNetwork);
        }
    }
}
