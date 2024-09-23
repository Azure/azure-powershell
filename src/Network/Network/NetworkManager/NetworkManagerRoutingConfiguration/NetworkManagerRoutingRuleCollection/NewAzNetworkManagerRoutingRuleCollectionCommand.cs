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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(PSNetworkManagerRoutingRuleCollection))]
    public class NewAzNetworkManagerRoutingRuleCollectionCommand : NetworkManagerRoutingRuleCollectionBaseCmdlet
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
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RoutingConfigurationName { get; set; }

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
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = ByName)]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByName,
            HelpMessage = "Applies To.")]
        public virtual PSNetworkManagerRoutingGroupItem[] AppliesTo { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByName,
            HelpMessage = "DisableBgpRoutePropagation.")]
        public string DisableBgpRoutePropagation { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object representing the routing collection.",
            ParameterSetName = ByInputObject)]
        public PSNetworkManagerRoutingRuleCollection InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName, description, appliesTo, disableBgpRoutePropagation) = ExtractParameters();

            var present = this.IsNetworkManagerRoutingRuleCollectionPresent(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, routingRuleCollectionName),
                Properties.Resources.CreatingResourceMessage,
                routingRuleCollectionName,
                () =>
                {
                    var networkManagerRoutingRuleCollection = this.CreateNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName, description, appliesTo, disableBgpRoutePropagation);
                    WriteObject(networkManagerRoutingRuleCollection);
                },
                () => present);
        }

        private PSNetworkManagerRoutingRuleCollection CreateNetworkManagerRoutingRuleCollection(string resourceGroupName, string networkManagerName, string routingConfigurationName, string routingRuleCollectionName, string description, PSNetworkManagerRoutingGroupItem[] appliesTo, string disableBgpRoutePropagation)
        {
            var ruleCollection = new PSNetworkManagerRoutingRuleCollection
            {
                Name = routingRuleCollectionName,
                Description = description,
                AppliesTo = appliesTo.ToList(),
                DisableBgpRoutePropagation = disableBgpRoutePropagation
            };

            // Map to the sdk object
            var ruleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingRuleCollection>(ruleCollection);

            // Execute the Create Routing Rule Collection call
            this.NetworkManagerRoutingRuleCollectionClient.CreateOrUpdate(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName, ruleCollectionModel);

            var psRoutingRuleCollection = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName);
            return psRoutingRuleCollection;
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName, string routingRuleCollectionName, string description, PSNetworkManagerRoutingGroupItem[] appliesTo, string disableBgpRoutePropagation) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case ByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.RoutingConfigurationName,
                        this.InputObject.Name,
                        this.InputObject.Description,
                        this.InputObject.AppliesTo.ToArray(),
                        this.InputObject.DisableBgpRoutePropagation
                    );

                case ByName:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.RoutingConfigurationName,
                        this.Name,
                        this.Description,
                        this.AppliesTo,
                        this.DisableBgpRoutePropagation
                    );

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
