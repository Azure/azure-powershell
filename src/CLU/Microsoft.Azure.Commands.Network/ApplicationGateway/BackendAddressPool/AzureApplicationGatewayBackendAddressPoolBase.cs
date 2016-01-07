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
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayBackendAddressPoolBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the Backend Address Pool")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "Resource IDs of the application gateway backend servers")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendIPConfigurationIds { get; set; }

        [Parameter(
                ParameterSetName = "SetByIP",
                HelpMessage = "IP addresses of application gateway backend servers")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendIPAddresses { get; set; }

        [Parameter(
        ParameterSetName = "SetByFqdn",
        HelpMessage = "FQDNs of application gateway backend servers")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendFqdns { get; set; }         

        public PSApplicationGatewayBackendAddressPool NewObject()
        {
            var backendAddressPool = new PSApplicationGatewayBackendAddressPool();

            backendAddressPool.Name = this.Name;

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResourceId))
            {
                backendAddressPool.BackendIpConfigurations = new System.Collections.Generic.List<PSResourceId>();
                foreach (string id in this.BackendIPConfigurationIds)
                {
                    var backendIpConfig = new PSResourceId();
                    backendIpConfig.Id = id;
                    backendAddressPool.BackendIpConfigurations.Add(backendIpConfig);
                }
            }
            else if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByIP))
            {
                backendAddressPool.BackendAddresses = new System.Collections.Generic.List<PSApplicationGatewayBackendAddress>();
                foreach (string ip in this.BackendIPAddresses)
                {
                    var backendAddress = new PSApplicationGatewayBackendAddress();
                    backendAddress.IpAddress = ip;
                    backendAddressPool.BackendAddresses.Add(backendAddress);
                }
            }
            else
            {
                backendAddressPool.BackendAddresses = new System.Collections.Generic.List<PSApplicationGatewayBackendAddress>();
                foreach (string fqdn in this.BackendFqdns)
                {
                    var backendAddress = new PSApplicationGatewayBackendAddress();
                    backendAddress.Fqdn = fqdn;
                    backendAddressPool.BackendAddresses.Add(backendAddress);
                }
            }

            backendAddressPool.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayBackendAddressPoolName,
                                this.Name);

            return backendAddressPool;
        }
    }
}
