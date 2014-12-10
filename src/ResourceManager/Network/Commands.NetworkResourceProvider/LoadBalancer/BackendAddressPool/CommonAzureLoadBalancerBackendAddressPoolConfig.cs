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
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public class CommonAzureLoadBalancerBackendAddressPoolConfig : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            HelpMessage = "IPConfig IDs of NetworkInterfaces")]
        [ValidateNotNullOrEmpty]
        public List<string> BackendIpConfigurationId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "IPConfig of NetworkInterface")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkInterfaceIpConfiguration> BackendIpConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Resources.SetByResource))
            {
                this.BackendIpConfigurationId = new List<string>();

                foreach (var backendIpConfiguration in this.BackendIpConfiguration)
                {
                    this.BackendIpConfigurationId.Add(backendIpConfiguration.Id);
                }
            }
        }
    }
}
