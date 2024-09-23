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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ByInputObject), OutputType(typeof(PSNetworkManagerSecurityUserConfiguration))]
    public class SetAzNetworkManagerSecurityUserConfiguration : NetworkManagerSecurityUserConfigurationBaseCmdlet
    {
        private const string ByResourceId = "ByResourceId";
        private const string ByInputObject = "ByInputObject";

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
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager SecurityUserConfiguration")]
        public PSNetworkManagerSecurityUserConfiguration InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            HelpMessage = "NetworkManager SecurityUserConfiguration Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserConfigurationId")]
        public string ResourceId { get; set; }

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
                case ByResourceId:
                    return (
                        NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "securityUserConfigurations"),
                        this.GetNetworkManagerSecurityUserConfiguration(
                            NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                            NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                            NetworkBaseCmdlet.GetResourceName(this.ResourceId, "securityUserConfigurations")
                        )
                    );

                case ByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.Name,
                        this.InputObject
                    );

                default:
                    throw new ArgumentException("Invalid parameter set");
            }
        }
    }
}
