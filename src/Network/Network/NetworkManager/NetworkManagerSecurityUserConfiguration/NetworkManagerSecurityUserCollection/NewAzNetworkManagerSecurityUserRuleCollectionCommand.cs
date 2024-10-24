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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSNetworkManagerSecurityUserRuleCollection))]
    public class NewAzNetworkManagerSecurityUserRuleCollectionCommand : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager security user configuration name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string SecurityUserConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = CreateByNameParameterSet)]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateByNameParameterSet,
            HelpMessage = "Applies To.")]
        public PSNetworkManagerSecurityUserGroupItem[] AppliesToGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = this.IsNetworkManagerSecurityUserRuleCollectionPresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var networkManagerSecurityUserRuleCollection = this.CreateNetworkManagerSecurityUserRuleCollection(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.Name, this.Description, this.AppliesToGroup);
                    WriteObject(networkManagerSecurityUserRuleCollection);
                },
                () => present);
        }

        private PSNetworkManagerSecurityUserRuleCollection CreateNetworkManagerSecurityUserRuleCollection(string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string securityUserRuleCollectionName, string description, PSNetworkManagerSecurityUserGroupItem[] appliesTo)
        {
            var ruleCollection = new PSNetworkManagerSecurityUserRuleCollection
            {
                Name = securityUserRuleCollectionName,
                Description = description,
                AppliesToGroups = appliesTo.ToList(),
            };

            // Map to the sdk object
            var ruleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserRuleCollection>(ruleCollection);

            // Execute the Create SecurityUser Rule Collection call
            this.NetworkManagerSecurityUserRuleCollectionClient.CreateOrUpdate(resourceGroupName, this.NetworkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, ruleCollectionModel);

            var psSecurityUserRuleCollection = this.GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, securityUserRuleCollectionName);
            return psSecurityUserRuleCollection;
        }
    }
}
