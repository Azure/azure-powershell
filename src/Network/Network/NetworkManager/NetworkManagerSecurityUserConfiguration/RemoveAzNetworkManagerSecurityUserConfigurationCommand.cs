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
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerSecurityUserConfigurationCommand : NetworkManagerSecurityUserConfigurationBaseCmdlet
    {
        private const string ByName = "ByName";
        private const string ByResourceId = "ByResourceId";
        private const string ByInputObject = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.",
           ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
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
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecurityUser Configuration resource.",
            ParameterSetName = ByInputObject)]
        [ValidateNotNull]
        public PSNetworkManagerSecurityUserConfiguration InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = ByResourceId)]
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

            var (resourceGroupName, networkManagerName, securityUserConfigurationName) = GetParameters();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, securityUserConfigurationName),
                Properties.Resources.RemoveResourceMessage,
                securityUserConfigurationName,
                () => RemoveSecurityUserConfiguration(resourceGroupName, networkManagerName, securityUserConfigurationName));
        }

        private void RemoveSecurityUserConfiguration(string resourceGroupName, string networkManagerName, string securityUserConfigurationName)
        {
            bool forceDelete = ForceDelete.IsPresent;

            this.NetworkManagerSecurityUserConfigurationClient.Delete(resourceGroupName, networkManagerName, securityUserConfigurationName, forceDelete);
            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName) GetParameters()
        {
            switch (this.ParameterSetName)
            {
                case ByResourceId:
                    var resourceId = this.ResourceId;
                    return (
                        NetworkBaseCmdlet.GetResourceGroup(resourceId),
                        NetworkBaseCmdlet.GetResourceName(resourceId, "networkManagers"),
                        NetworkBaseCmdlet.GetResourceName(resourceId, "securityUserConfigurations")
                    );

                case ByInputObject:
                    var inputObject = this.InputObject;
                    return (
                        inputObject.ResourceGroupName,
                        inputObject.NetworkManagerName,
                        inputObject.Name
                    );

                case ByName:
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