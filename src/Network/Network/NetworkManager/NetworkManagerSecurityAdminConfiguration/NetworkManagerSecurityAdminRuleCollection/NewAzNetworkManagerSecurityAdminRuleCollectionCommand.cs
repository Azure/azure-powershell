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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityAdminRuleCollection))]
    public class NewAzNetworkManagerSecurityAdminRuleCollectionCommand : NetworkManagerSecurityAdminRuleCollectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityAdminConfigurationName")]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string SecurityAdminConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
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
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Applies To Groups.")]
        public virtual PSNetworkManagerSecurityGroupItem[] AppliesToGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerSecurityAdminRuleCollectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerSecurityRuleCollection = this.CreateNetworkManagerSecurityAdminRuleCollection();
                    WriteObject(networkManagerSecurityRuleCollection);
                },
                () => present);
        }

        private PSNetworkManagerSecurityAdminRuleCollection CreateNetworkManagerSecurityAdminRuleCollection()
        {
            var ruleCollection = new PSNetworkManagerSecurityAdminRuleCollection();
            ruleCollection.Name = this.Name;
            if (!string.IsNullOrEmpty(this.Description))
            {
                ruleCollection.Description = this.Description;
            }
            ruleCollection.AppliesToGroups = this.AppliesToGroup.ToList();

            // Map to the sdk object
            var ruleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AdminRuleCollection>(ruleCollection);

            this.NullifyNetworkManagerSecurityAdminRuleCollectionIfAbsent(ruleCollectionModel);
            

            // Execute the Create Security Rule Collection call
            this.NetworkManagerSecurityAdminRuleCollectionClient.CreateOrUpdate(ruleCollectionModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.Name);
            var psSecuirtyRuleCollection = this.GetNetworkManagerSecurityAdminRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.Name);
            return psSecuirtyRuleCollection;
        }
    }
}
