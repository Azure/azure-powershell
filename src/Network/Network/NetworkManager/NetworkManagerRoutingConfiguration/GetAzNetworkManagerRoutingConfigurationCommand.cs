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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingConfiguration", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSNetworkManagerRoutingConfiguration))]
    public class GetAzNetworkManagerRoutingConfigurationCommand : NetworkManagerRoutingConfigurationBaseCmdlet
    {
        private const string ListParameterSet = "ByList";
        private const string GetByNameParameterSet = "ByName";
        private const string GetByResourceIdParameterSet = "ByResourceId";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "The network manager routing configuration id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingConfigurationId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            switch (this.ParameterSetName)
            {
                case GetByNameParameterSet:
                    var nmRoutingConfigurationByName = this.GetNetworkManagerRoutingConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                    WriteObject(nmRoutingConfigurationByName);
                    break;

                case GetByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                    // Validate the format of the ResourceId
                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 2)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.NetworkManagerName = segments[1];

                    var nmRoutingConfigurationByResourceId = this.GetNetworkManagerRoutingConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                    WriteObject(nmRoutingConfigurationByResourceId);
                    break;

                case ListParameterSet:
                    var routingConfigurationPage = this.NetworkManagerRoutingConfigurationClient.List(this.ResourceGroupName, this.NetworkManagerName);

                    // Get all resources by polling on next page link
                    var routingConfigurationList = ListNextLink<NetworkManagerRoutingConfiguration>.GetAllResourcesByPollingNextLink(routingConfigurationPage, this.NetworkManagerRoutingConfigurationClient.ListNext);
                    var psNmRoutingConfigList = new List<PSNetworkManagerRoutingConfiguration>();

                    foreach (var routingConfiguration in routingConfigurationList)
                    {
                        var psNmRoutingConfig = this.ToPsNetworkManagerRoutingConfiguration(routingConfiguration);
                        psNmRoutingConfig.ResourceGroupName = this.ResourceGroupName;
                        psNmRoutingConfig.NetworkManagerName = this.NetworkManagerName;
                        psNmRoutingConfigList.Add(psNmRoutingConfig);
                    }

                    WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psNmRoutingConfigList), true);
                    break;
                default:
                    break;
            }
        }
    }
}
