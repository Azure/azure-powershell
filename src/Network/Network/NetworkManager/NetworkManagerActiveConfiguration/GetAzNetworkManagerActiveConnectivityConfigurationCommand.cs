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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerActiveConnectivityConfiguration"), OutputType(typeof(PSNetworkManagerActiveConnectivityConfigurationResult))]
    public class GetAzNetworkManagerActiveConnectivityConfigurationCommand : NetworkManagerBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "List of regions.")]
        [AllowEmptyCollection]
        public string[] Region { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SkipToken.")]
        public string SkipToken { get; set; }

        public override void Execute()
        {
            base.Execute();
            var parameter = new ActiveConfigurationParameter();
            if(this.Region != null)
            {
                parameter.Regions = this.Region.ToList();
            }
            if(!string.IsNullOrEmpty(this.SkipToken))
            {
                parameter.SkipToken = this.SkipToken;
            }
                
            var networkManagerActiveConnectivityConfiguration = this.NetworkClient.NetworkManagementClient.ListActiveConnectivityConfigurations(parameter, this.ResourceGroupName, this.NetworkManagerName);
            var psActiveConnectivityConfiguration = NetworkResourceManagerProfile.Mapper.Map<PSNetworkManagerActiveConnectivityConfigurationResult>(networkManagerActiveConnectivityConfiguration);
            WriteObject(psActiveConnectivityConfiguration);
        }
    }
}
