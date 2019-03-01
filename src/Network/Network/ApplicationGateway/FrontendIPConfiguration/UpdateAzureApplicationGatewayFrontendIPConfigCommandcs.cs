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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFrontendIPConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayFrontendIPConfigCommand : AzureApplicationGatewayFrontendIPConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The application gateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var frontendIPConfig = this.ApplicationGateway.FrontendIPConfigurations.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (frontendIPConfig == null)
            {
                throw new ArgumentException("FrontendIPConfiguration with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }

                if (this.PublicIPAddress != null)
                {
                    this.PublicIPAddressId = this.PublicIPAddress.Id;
                }
            }

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                frontendIPConfig.Subnet = new PSResourceId();
                frontendIPConfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIPAddress))
                {
                    frontendIPConfig.PrivateIPAddress = this.PrivateIPAddress;
                    frontendIPConfig.PrivateIPAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIPAddressId))
            {
                frontendIPConfig.PublicIPAddress = new PSResourceId();
                frontendIPConfig.PublicIPAddress.Id = this.PublicIPAddressId;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
