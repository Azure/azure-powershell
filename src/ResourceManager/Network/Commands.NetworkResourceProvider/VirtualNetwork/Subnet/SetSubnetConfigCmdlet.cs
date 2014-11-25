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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureVirtualNetworkSubnetConfig")]
    public class SetAzureVirtualNetworkSubnetConfigCmdlet : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The address prefix of the subnet")]
        [ValidateNotNullOrEmpty]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of Dns Servers")]
        public List<string> DnsServer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Verify if the subnet exists in the VirtualNetwork
            var subnet = this.VirtualNetwork.Properties.Subnets.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (subnet == null)
            {
                throw new ArgumentException("Subnet with the specified name does not exist");
            }

            subnet.Properties = new PSSubnetProperties();
            subnet.Properties.AddressPrefix = this.AddressPrefix;
            subnet.Properties.DhcpOptions = new PSDhcpOptions();
            subnet.Properties.DhcpOptions.DnsServers = this.DnsServer;

            WriteObject(this.VirtualNetwork);
        }
    }
}
