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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerRoutingConfigurationCommand : NetworkManagerRoutingConfigurationBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "ByName";
        private const string DeleteByResourceIdParameterSet = "ByResourceId";
        private const string DeleteByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network manager routing configuration resource.",
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSNetworkManagerRoutingConfiguration InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Deletes the resource even if it is deployed. If the configuration has been deployed, the service will do a cleanup deployment in the background, prior to the delete.")]
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

            var (resourceGroupName, networkManagerName, routingConfigurationName) = GetParameters();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, routingConfigurationName),
                Properties.Resources.RemoveResourceMessage,
                routingConfigurationName,
                () => RemoveRoutingConfiguration(resourceGroupName, networkManagerName, routingConfigurationName));
        }

        private void RemoveRoutingConfiguration(string resourceGroupName, string networkManagerName, string routingConfigurationName)
        {
            bool forceDelete = ForceDelete.IsPresent;

            this.NetworkManagerRoutingConfigurationClient.Delete(resourceGroupName, networkManagerName, routingConfigurationName, forceDelete);
            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName) GetParameters()
        {
            switch (this.ParameterSetName)
            {
                case DeleteByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 2)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    var resourceGroupName = parsedResourceId.ResourceGroupName;
                    var networkManagerName = segments[1]; // NetworkManagerName
                    var routingConfigurationName = parsedResourceId.ResourceName; // RoutingConfigurationName

                    return (
                        resourceGroupName,
                        networkManagerName,
                        routingConfigurationName
                    );

                case DeleteByInputObjectParameterSet:
                    var inputObject = this.InputObject;
                    return (
                        inputObject.ResourceGroupName,
                        inputObject.NetworkManagerName,
                        inputObject.Name
                    );

                case DeleteByNameParameterSet:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.Name
                    );

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
