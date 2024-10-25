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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObjectParameterSet), OutputType(typeof(PSNetworkManagerSecurityUserConfiguration))]
    public class SetAzNetworkManagerSecurityUserConfiguration : NetworkManagerSecurityUserConfigurationBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network manager security user configuration.")]
        public PSNetworkManagerSecurityUserConfiguration InputObject { get; set; }

        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The network manager security user configuration id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserConfigurationId")]
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

            var (resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserConfiguration) = GetParameters();

            if (this.ShouldProcess(securityUserConfigurationName, VerbsCommon.Set))
            {
                if (!this.IsNetworkManagerSecurityUserConfigurationPresent(resourceGroupName, networkManagerName, securityUserConfigurationName))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, securityUserConfigurationName));
                }

                // Update the description if provided
                if (!string.IsNullOrEmpty(this.Description))
                {
                    securityUserConfiguration.Description = this.Description;
                }

                // Map to the SDK object
                var securityUserConfigModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserConfiguration>(securityUserConfiguration);

                // Execute the PUT NetworkManagerSecurityUserConfiguration call
                this.NetworkManagerSecurityUserConfigurationClient.CreateOrUpdate(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserConfigModel);

                var psSecurityUserConfig = this.GetNetworkManagerSecurityUserConfiguration(resourceGroupName, networkManagerName, securityUserConfigurationName);
                WriteObject(psSecurityUserConfig);
            }
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, PSNetworkManagerSecurityUserConfiguration securityUserConfiguration) GetParameters()
        {
            switch (this.ParameterSetName)
            {
                case SetByResourceIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                    // Validate the format of the ResourceId
                    var segments = parsedResourceId.ParentResource.Split('/');
                    if (segments.Length < 2)
                    {
                        throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                    }

                    return (
                        parsedResourceId.ResourceGroupName,
                        parsedResourceId.ParentResource.Split('/')[1], // NetworkManagerName
                        parsedResourceId.ResourceName, // SecurityUserConfigurationName
                        this.GetNetworkManagerSecurityUserConfiguration(
                            parsedResourceId.ResourceGroupName,
                            parsedResourceId.ParentResource.Split('/')[1],
                            parsedResourceId.ResourceName
                        )
                    );

                case SetByInputObjectParameterSet:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.Name,
                        this.InputObject
                    );

                case SetByNameParameterSet:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.Name,
                        this.GetNetworkManagerSecurityUserConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name)
                    );

                default:
                    throw new ArgumentException("Invalid parameter set");
            }
        }
    }
}
