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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerSecurityUserRuleCollectionCommand : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager securityUser configuration name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string SecurityUserConfigurationName { get; set; }

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
            HelpMessage = "The network manager security user rule collection resource.",
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSNetworkManagerSecurityUserRuleCollection InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = DeleteByResourceIdParameterSet)]
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

            var (resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName) = ExtractParameters();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, securityUserRuleCollectionName),
                Properties.Resources.RemoveResourceMessage,
                securityUserRuleCollectionName,
                () =>
                {
                    bool forceDelete = ForceDelete.IsPresent;

                    this.NetworkManagerSecurityUserRuleCollectionClient.Delete(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, forceDelete);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string securityUserRuleCollectionName) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case DeleteByInputObjectParameterSet:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.SecurityUserConfigurationName,
                        this.InputObject.Name
                    );

                case DeleteByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 4)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    var resourceGroupName = parsedResourceId.ResourceGroupName;
                    var networkManagerName = segments[1]; // NetworkManagerName
                    var routingConfigurationName = segments[3]; // SecurityUserConfigurationName
                    var routingRuleCollectionName = parsedResourceId.ResourceName; // RuleCollectionName

                    return (
                        resourceGroupName,
                        networkManagerName,
                        routingConfigurationName,
                        routingRuleCollectionName
                    );

                case DeleteByNameParameterSet:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.SecurityUserConfigurationName,
                        this.Name
                    );

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
