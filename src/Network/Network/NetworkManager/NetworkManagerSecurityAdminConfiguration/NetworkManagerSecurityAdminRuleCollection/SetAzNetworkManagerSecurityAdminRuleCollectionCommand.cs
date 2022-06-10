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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityAdminRuleCollection))]
    public class SetAzNetworkManagerSecurityAdminRuleCollection : NetworkManagerSecurityAdminRuleCollectionBaseCmdlet
    {
        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityAdminConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkManagerSecurityAdminRuleCollection")]
        public PSNetworkManagerSecurityAdminRuleCollection NetworkManagerSecurityAdminRuleCollection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.NetworkManagerSecurityAdminRuleCollection.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsNetworkManagerSecurityAdminRuleCollectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.NetworkManagerSecurityAdminRuleCollection.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.NetworkManagerSecurityAdminRuleCollection.Name));
                }

                // Map to the sdk object
                var securityRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AdminRuleCollection>(this.NetworkManagerSecurityAdminRuleCollection);

                // Execute the PUT NetworkManagerSecurityAdminRuleCollection call
                var securityRuleCollectionResponse = this.NetworkManagerSecurityAdminRuleCollectionClient.CreateOrUpdate(securityRuleCollectionModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.NetworkManagerSecurityAdminRuleCollection.Name);
                var psSecurityRuleCollection = this.ToPsNetworkManagerSecurityAdminRuleCollection(securityRuleCollectionResponse);
                WriteObject(psSecurityRuleCollection);
            }
        }
    }
}
