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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmSecureGatewayIpConfiguration", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayIpConfiguration))]
    public class NewAzureSecureGatewayIpConfigurationCommand : NetworkBaseCmdlet
    {
        private const string SecureGatewaySubnetName = "SecureGatewaySubnet";
        private const int SecureGatewaySubnetMinSize = 24;

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the IP Configuration")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Virtual Network where the Secure Gateway will be deployed")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSSubnet secGwSubnet = null;
            try
            {
                secGwSubnet = this.VirtualNetwork.Subnets.Single(subnet => SecureGatewaySubnetName.Equals(subnet.Name));
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("The Virtual Network argument should contain a Subnet named SecureGatewaySubnet");
            }

            var subnetSize = int.Parse(secGwSubnet.AddressPrefix.Split(new[] { '/' })[1]);
            if (subnetSize > SecureGatewaySubnetMinSize)
            {
                throw new ArgumentException("The AddressPrefix (" + secGwSubnet.AddressPrefix + ") of the SecureGatewaySubnet os the referenced Virtual Network must be at least /24");
            }

            var ipConfig = new PSSecureGatewayIpConfiguration
            {
                Name = this.Name,
                Subnet = new PSResourceId { Id = secGwSubnet.Id }
            };

            WriteObject(ipConfig);
        }
    }
}
