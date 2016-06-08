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
using System.Collections.Generic;
using System.Management.Automation;

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
                HelpMessage = "IP addresses of application gateway backend servers")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendIPAddresses { get; set; }

        [Parameter(
               HelpMessage = "FQDNs of application gateway backend servers")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendFqdns { get; set; }

        public PSApplicationGatewayBackendAddressPool NewObject()
        {
            var backendAddressPool = new PSApplicationGatewayBackendAddressPool();

            backendAddressPool.Name = this.Name;

            if (BackendIPAddresses != null && BackendFqdns != null)
            {
                throw new ArgumentException("At most one of BackendIPAddresses and BackendFqdns can be specified.");
            }
            else if (BackendIPAddresses != null && BackendIPAddresses.Count > 0)
            {
                backendAddressPool.BackendAddresses = new System.Collections.Generic.List<PSApplicationGatewayBackendAddress>();
                foreach (string ip in this.BackendIPAddresses)
                {
                    var backendAddress = new PSApplicationGatewayBackendAddress();
                    backendAddress.IpAddress = ip;
                    backendAddressPool.BackendAddresses.Add(backendAddress);
                }
            }
            else if (BackendFqdns != null && BackendFqdns.Count > 0)
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
