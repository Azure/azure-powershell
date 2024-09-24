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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserConfiguration", DefaultParameterSetName = ByListParameterSet), OutputType(typeof(PSNetworkManagerSecurityUserConfiguration))]
    public class GetAzNetworkManagerSecurityUserConfigurationCommand : NetworkManagerSecurityUserConfigurationBaseCmdlet
    {
        private const string ByListParameterSet = "ByList";
        private const string ByNameParameterSet = "ByName";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByResourceIdParameterSet,
            HelpMessage = "NetworkManager SecurityUserConfiguration Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserConfigurationId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object containing the necessary properties.",
            ParameterSetName = ByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSNetworkManagerSecurityUserConfiguration InputObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            switch (this.ParameterSetName)
            {
                case ByNameParameterSet:
                    var nmSecurityUserConfigurationByName = this.GetNetworkManagerSecurityUserConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                    WriteObject(nmSecurityUserConfigurationByName);
                    break;

                case ByResourceIdParameterSet:
                    var resourceId = this.ResourceId;
                    var resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(resourceId);
                    var networkManagerName = NetworkBaseCmdlet.GetResourceName(resourceId, "networkManagers");
                    var securityUserConfigurationName = NetworkBaseCmdlet.GetResourceName(resourceId, "securityUserConfigurations");
                    var nmSecurityUserConfigurationByResourceId = this.GetNetworkManagerSecurityUserConfiguration(resourceGroupName, networkManagerName, securityUserConfigurationName);
                    WriteObject(nmSecurityUserConfigurationByResourceId);
                    break;

                case ByInputObjectParameterSet:
                    var inputObject = this.InputObject;
                    var nmSecurityUserConfigurationByInputObject = this.GetNetworkManagerSecurityUserConfiguration(inputObject.ResourceGroupName, inputObject.NetworkManagerName, inputObject.Name);
                    WriteObject(nmSecurityUserConfigurationByInputObject);
                    break;

                case ByListParameterSet:
                    var securityUserConfigurationPage = this.NetworkManagerSecurityUserConfigurationClient.List(this.ResourceGroupName, this.NetworkManagerName);

                    // Get all resources by polling on next page link
                    var securityUserConfigurationList = ListNextLink<SecurityUserConfiguration>.GetAllResourcesByPollingNextLink(securityUserConfigurationPage, this.NetworkManagerSecurityUserConfigurationClient.ListNext);
                    var psNmSecurityUserConfigList = new List<PSNetworkManagerSecurityUserConfiguration>();

                    foreach (var securityUserConfiguration in securityUserConfigurationList)
                    {
                        var psNmSecurityUserConfig = this.ToPsNetworkManagerSecurityUserConfiguration(securityUserConfiguration);
                        psNmSecurityUserConfig.ResourceGroupName = this.ResourceGroupName;
                        psNmSecurityUserConfig.NetworkManagerName = this.NetworkManagerName;
                        psNmSecurityUserConfigList.Add(psNmSecurityUserConfig);
                    }

                    WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psNmSecurityUserConfigList), true);
                    break;

                default:
                    break;
            }
        }
    }
}
