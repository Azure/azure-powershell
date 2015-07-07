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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewayBackendAddressPool"), OutputType(typeof(PSApplicationGatewayBackendAddressPool))]
    public class NewAzureApplicationGatewayBackendAddressPoolCommand : AzureApplicationGatewayBackendAddressPoolBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var backendAddressPool = new PSApplicationGatewayBackendAddressPool();

            backendAddressPool.Name = this.Name;

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResourceId))
            {
                foreach (string id in this.BackendIPConfigurationIds)
                {
                    var backendIpConfig = new PSResourceId();
                    backendIpConfig.Id = id;
                    backendAddressPool.BackendIpConfigurations.Add(backendIpConfig);
                }
            }
            else if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByIP))
            {
                foreach (string ip in this.BackendIPAddresses)
                {
                    var backendAddress = new PSApplicationGatewayBackendAddress();
                    backendAddress.IpAddress = ip;
                    backendAddressPool.BackendAddresses.Add(backendAddress);
                }
            }
            else 
            {
                foreach (string fqdn in this.BackendFqdns)
                {
                    var backendAddress = new PSApplicationGatewayBackendAddress();
                    backendAddress.Fqdn = fqdn;
                    backendAddressPool.BackendAddresses.Add(backendAddress);
                }
            }

            backendAddressPool.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayBackendAddressPoolName,
                                this.Name);

            WriteObject(backendAddressPool);
        }
    }
}
