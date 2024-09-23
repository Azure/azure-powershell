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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(PSNetworkManagerRoutingConfiguration))]
    public class NewAzNetworkManagerRoutingConfigurationCommand : NetworkManagerRoutingConfigurationBaseCmdlet
    {
        private const string ByName = "ByName";
        private const string ByInputObject = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = ByName)]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object representing the routing configuration.",
            ParameterSetName = ByInputObject)]
        public PSNetworkManagerRoutingConfiguration InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, routingConfigurationName) = GetParameters();

            var present = this.IsNetworkManagerRoutingConfigurationPresent(resourceGroupName, networkManagerName, routingConfigurationName);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, routingConfigurationName),
                Properties.Resources.CreatingResourceMessage,
                routingConfigurationName,
                () =>
                {
                    var networkManagerRoutingConfiguration = this.CreateNetworkManagerRoutingConfiguration(resourceGroupName, networkManagerName, routingConfigurationName);
                    WriteObject(networkManagerRoutingConfiguration);
                },
                () => present);
        }

        private PSNetworkManagerRoutingConfiguration CreateNetworkManagerRoutingConfiguration(string resourceGroupName, string networkManagerName, string routingConfigurationName)
        {
            var routingConfig = new PSNetworkManagerRoutingConfiguration
            {
                Name = routingConfigurationName
            };

            if (!string.IsNullOrEmpty(this.Description))
            {
                routingConfig.Description = this.Description;
            }

            // Map to the sdk object
            var routingConfigModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkManagerRoutingConfiguration>(routingConfig);

            // Execute the Create Routing Config call
            this.NetworkManagerRoutingConfigurationClient.CreateOrUpdate(resourceGroupName, networkManagerName, routingConfigurationName, routingConfigModel);

            var psRoutingConfig = this.GetNetworkManagerRoutingConfiguration(resourceGroupName, networkManagerName, routingConfigurationName);
            return psRoutingConfig;
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName) GetParameters()
        {
            switch (this.ParameterSetName)
            {
                case ByName:
                    return (this.ResourceGroupName, this.NetworkManagerName, this.Name);

                case ByInputObject:
                    return (this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name);

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
