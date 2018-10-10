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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmVirtualNetworkGatewayIpConfig", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGateway))]
    public class RemoveAzureVirtualNetworkGatewayIpConfigCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway object to base modifications off of. This can be retrieved using Get-AzureRmVirtualNetworkGateway")]
        [ValidateNotNull]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the VirtualNetworkGatewayIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {

            base.Execute();

            if (ShouldProcess(Name, Properties.Resources.RemoveResourceMessage + Properties.Resources.VirtualNetworkGatewayIpConfigName))
            {
                if (this.VirtualNetworkGateway.IpConfigurations != null)
                {
                    PSVirtualNetworkGatewayIpConfiguration configToRemove = this.VirtualNetworkGateway.IpConfigurations.Find(config => config.Name.Equals(Name));
                    if (configToRemove == null)
                    {
                        throw new ArgumentException("Virtual Network Gateway object does not have any Gateway IpConfiguration with Name=" + Name + " specified.");
                    }
                    else
                    {
                        this.VirtualNetworkGateway.IpConfigurations.Remove(configToRemove);
                    }
                }
                else
                {
                    throw new ArgumentException("Virtual Network Gateway object does not have any Gateway IpConfigurations specified.");
                }

                WriteObject(this.VirtualNetworkGateway);
            }
        }
    }
}
