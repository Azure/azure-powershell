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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ByInputObject), OutputType(typeof(PSNetworkManagerRoutingConfiguration))]
    public class SetAzNetworkManagerRoutingConfiguration : NetworkManagerRoutingConfigurationBaseCmdlet
    {
        private const string ByResourceId = "ByResourceId";
        private const string ByInputObject = "ByInputObject";
        private const string ByName = "ByNameParameters";

        [Alias("ResourceName")]
        [Parameter(
           ParameterSetName = ByInputObject,
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [Parameter(
           ParameterSetName = ByResourceId,
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [Parameter(
           ParameterSetName = ByName,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager RoutingConfiguration")]
        public PSNetworkManagerRoutingConfiguration InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceId,
            Mandatory = true,
            HelpMessage = "NetworkManager RoutingConfiguration Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingConfigurationId")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ByName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByName,
            Mandatory = true,
            HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkManagerName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, routingConfigurationName, routingConfiguration) = GetParameters();

            if (this.ShouldProcess(routingConfigurationName, VerbsCommon.Set))
            {
                if (!this.IsNetworkManagerRoutingConfigurationPresent(resourceGroupName, networkManagerName, routingConfigurationName))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, routingConfigurationName));
                }

                // Map to the SDK object
                var routingConfigModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkManagerRoutingConfiguration>(routingConfiguration);

                // Execute the PUT NetworkManagerRoutingConfiguration call
                this.NetworkManagerRoutingConfigurationClient.CreateOrUpdate(resourceGroupName, networkManagerName, routingConfigurationName, routingConfigModel);

                var psRoutingConfig = this.GetNetworkManagerRoutingConfiguration(resourceGroupName, networkManagerName, routingConfigurationName);
                WriteObject(psRoutingConfig);
            }
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName, PSNetworkManagerRoutingConfiguration routingConfiguration) GetParameters()
        {
            switch (this.ParameterSetName)
            {
                case ByResourceId:
                    return (
                        NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "routingConfigurations"),
                        this.GetNetworkManagerRoutingConfiguration(
                            NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                            NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                            NetworkBaseCmdlet.GetResourceName(this.ResourceId, "routingConfigurations")
                        )
                    );

                case ByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.Name,
                        this.InputObject
                    );

                case ByName:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.Name,
                        this.GetNetworkManagerRoutingConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name)
                    );

                default:
                    throw new ArgumentException("Invalid parameter set");
            }
        }
    }
}
