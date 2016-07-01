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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureLoadBalancerFrontendIpConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the FrontendIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceSubnet",
            HelpMessage = "The private ip address of the frontendIpConfiguration " +
                          "if static allocation is specified.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceIdSubnet",
            HelpMessage = "The private ip address of the frontendIpConfiguration " +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourceIdSubnet",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourceSubnet",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourceIdPublicIpAddress",
            HelpMessage = "PublicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourcePublicIpAddress",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!ParameterSetName.Contains(Microsoft.Azure.Commands.Network.Properties.Resources.SetByResourceId))
            {
                if (this.Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }

                if (this.PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }
            }
        }
    }
}
