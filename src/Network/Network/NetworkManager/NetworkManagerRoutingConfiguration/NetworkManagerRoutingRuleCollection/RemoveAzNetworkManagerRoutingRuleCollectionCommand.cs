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

using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByName), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerRoutingRuleCollectionCommand : NetworkManagerRoutingRuleCollectionBaseCmdlet
    {
        private const string DeleteByName = "ByName";
        private const string DeleteByResourceId = "ByResourceId";
        private const string DeleteByInputObject = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = DeleteByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager routing configuration name.",
           ParameterSetName = DeleteByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.",
           ParameterSetName = DeleteByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = DeleteByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Routing rule collection resource.",
            ParameterSetName = DeleteByInputObject)]
        [ValidateNotNull]
        public PSNetworkManagerRoutingRuleCollection InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = DeleteByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Deletes the resource even if it is part of a deployed configuration. If the configuration has been deployed, the service will do a cleanup deployment in the background, prior to the delete.")]
        public SwitchParameter ForceDelete { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName) = ExtractParameters();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, routingRuleCollectionName),
                Properties.Resources.RemoveResourceMessage,
                routingRuleCollectionName,
                () =>
                {
                    bool forceDelete = ForceDelete.IsPresent;

                    this.NetworkManagerRoutingRuleCollectionClient.Delete(resourceGroupName, networkManagerName, routingConfigurationName, routingRuleCollectionName, forceDelete);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName, string routingRuleCollectionName) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case DeleteByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.RoutingConfigurationName,
                        this.InputObject.Name
                    );

                case DeleteByResourceId:
                    return (
                        NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "routingConfigurations"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "ruleCollections")
                    );

                case DeleteByName:
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
