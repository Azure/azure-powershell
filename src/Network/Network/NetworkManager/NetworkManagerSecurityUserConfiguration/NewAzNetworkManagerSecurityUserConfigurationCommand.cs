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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserConfiguration", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(PSNetworkManagerSecurityUserConfiguration))]
    public class NewAzNetworkManagerSecurityUserConfigurationCommand : NetworkManagerSecurityUserConfigurationBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
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
            HelpMessage = "The input object representing the securityUser configuration.",
            ParameterSetName = ByInputObject)]
        public PSNetworkManagerSecurityUserConfiguration InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, securityUserConfigurationName) = GetParameters();

            var present = this.IsNetworkManagerSecurityUserConfigurationPresent(resourceGroupName, networkManagerName, securityUserConfigurationName);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, securityUserConfigurationName),
                Properties.Resources.CreatingResourceMessage,
                securityUserConfigurationName,
                () =>
                {
                    var networkManagerSecurityUserConfiguration = this.CreateNetworkManagerSecurityUserConfiguration(resourceGroupName, networkManagerName, securityUserConfigurationName);
                    WriteObject(networkManagerSecurityUserConfiguration);
                },
                () => present);
        }

        private PSNetworkManagerSecurityUserConfiguration CreateNetworkManagerSecurityUserConfiguration(string resourceGroupName, string networkManagerName, string securityUserConfigurationName)
        {
            var securityUserConfig = new PSNetworkManagerSecurityUserConfiguration
            {
                Name = securityUserConfigurationName
            };

            if (!string.IsNullOrEmpty(this.Description))
            {
                securityUserConfig.Description = this.Description;
            }

            // Map to the sdk object
            var securityUserConfigModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserConfiguration>(securityUserConfig);

            // Execute the Create SecurityUser Config call
            this.NetworkManagerSecurityUserConfigurationClient.CreateOrUpdate(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserConfigModel);

            var psSecurityUserConfig = this.GetNetworkManagerSecurityUserConfiguration(resourceGroupName, networkManagerName, securityUserConfigurationName);
            return psSecurityUserConfig;
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName) GetParameters()
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
