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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObjectParameterSet), OutputType(typeof(PSNetworkManagerRoutingRuleCollection))]
    public class SetAzNetworkManagerRoutingRuleCollection : NetworkManagerRoutingRuleCollectionBaseCmdlet
    {
        private const string SetByNameParameterSet = "ByName";
        private const string SetByResourceIdParameterSet = "ByResourceId";
        private const string SetByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           ParameterSetName = SetByNameParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network manager routing collection.")]
        public PSNetworkManagerRoutingRuleCollection InputObject { get; set; }

        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The networkManager routing collection id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingCollectionId")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkManagerName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The routing configuration name.")]
        [ValidateNotNullOrEmpty]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByNameParameterSet)]
        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByResourceIdParameterSet)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName) = ExtractParameters();

            if (this.ShouldProcess(routingRuleCollectionName, VerbsLifecycle.Restart))
            {
                if (!this.IsNetworkManagerRoutingRuleCollectionPresent(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, routingRuleCollectionName));
                }

                // Fetch the InputObject if it is not set and ResourceId is provided
                if (this.InputObject == null)
                {
                    this.InputObject = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName);
                }

                // Update the description if provided
                if (!string.IsNullOrEmpty(this.Description))
                {
                    this.InputObject.Description = this.Description;
                }

                // Map to the sdk object
                var routingRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingRuleCollection>(this.InputObject);

                // Execute the PUT NetworkManagerRoutingRuleCollection call
                this.NetworkManagerRoutingRuleCollectionClient.CreateOrUpdate(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName, routingRuleCollectionModel);

                var psRoutingRuleCollection = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName);
                WriteObject(psRoutingRuleCollection);
            }
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName, string routingRuleCollectionName) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case SetByInputObjectParameterSet:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.RoutingConfigurationName,
                        this.InputObject.Name
                    );

                case SetByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 4)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    return (parsedResourceId.ResourceGroupName,
                        segments[1], // NetworkManagerName
                        segments[3], // RoutingConfigurationName
                        parsedResourceId.ResourceName // RuleCollectionName)
                    );

                case SetByNameParameterSet:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.RoutingConfigurationName,
                        this.Name
                    );

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
