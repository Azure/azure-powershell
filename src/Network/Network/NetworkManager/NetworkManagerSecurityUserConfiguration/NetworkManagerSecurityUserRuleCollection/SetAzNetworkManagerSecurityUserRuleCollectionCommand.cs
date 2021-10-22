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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityRuleCollection))]
    public class SetAzNetworkManagerSecurityUserRuleCollection : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
    {
        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security user configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

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
            HelpMessage = "The NetworkManagerSecurityUserRuleCollection")]
        public PSNetworkManagerSecurityRuleCollection NetworkManagerSecurityUserRuleCollection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.NetworkManagerSecurityUserRuleCollection.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsNetworkManagerSecurityUserRuleCollectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.NetworkManagerSecurityUserRuleCollection.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.NetworkManagerSecurityUserRuleCollection.Name));
                }

                // Map to the sdk object
                var securityRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RuleCollection>(this.NetworkManagerSecurityUserRuleCollection);

                // Execute the PUT NetworkManagerSecurityUserRuleCollection call
                var securityRuleCollectionResponse = this.NetworkManagerSecurityUserRuleCollectionClient.CreateOrUpdate(securityRuleCollectionModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.NetworkManagerSecurityUserRuleCollection.Name);
                var psSecurityRuleCollection = this.ToPsNetworkManagerSecurityUserRuleCollection(securityRuleCollectionResponse);
                WriteObject(psSecurityRuleCollection);
            }
        }
    }
}
