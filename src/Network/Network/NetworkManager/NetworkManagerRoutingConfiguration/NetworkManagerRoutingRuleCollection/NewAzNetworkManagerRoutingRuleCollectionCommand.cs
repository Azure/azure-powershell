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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSNetworkManagerRoutingRuleCollection))]
    public class NewAzNetworkManagerRoutingRuleCollectionCommand : NetworkManagerRoutingRuleCollectionBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = CreateByNameParameterSet)]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateByNameParameterSet,
            HelpMessage = "Applies To.")]
        public PSNetworkManagerRoutingGroupItem[] AppliesTo { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateByNameParameterSet,
            HelpMessage = "DisableBgpRoutePropagation.")]
        public string DisableBgpRoutePropagation { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = this.IsNetworkManagerRoutingRuleCollectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var networkManagerRoutingRuleCollection = this.CreateNetworkManagerRoutingRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.Name, this.Description, this.AppliesTo, this.DisableBgpRoutePropagation);
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
            this.NetworkManagerRoutingRuleCollectionClient.CreateOrUpdate(resourceGroupName, this.NetworkManagerName, routingConfigurationName, routingRuleCollectionName, ruleCollectionModel);

            var psRoutingRuleCollection = this.GetNetworkManagerRoutingRuleCollection(resourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, routingRuleCollectionName);
            return psRoutingRuleCollection;
        }
    }
}
