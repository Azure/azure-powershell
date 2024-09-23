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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(PSNetworkManagerSecurityUserRuleCollection))]
    public class NewAzNetworkManagerSecurityUserRuleCollectionCommand : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
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
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager securityUser configuration name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

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
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = ByName)]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByName,
            HelpMessage = "Applies To.")]
        public virtual PSNetworkManagerSecurityUserGroupItem[] AppliesToGroup { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object representing the securityUser collection.",
            ParameterSetName = ByInputObject)]
        public PSNetworkManagerSecurityUserRuleCollection InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, description, appliesTo) = ExtractParameters();

            var present = this.IsNetworkManagerSecurityUserRuleCollectionPresent(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, securityUserRuleCollectionName),
                Properties.Resources.CreatingResourceMessage,
                securityUserRuleCollectionName,
                () =>
                {
                    var networkManagerSecurityUserRuleCollection = this.CreateNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, description, appliesTo);
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
            this.NetworkManagerSecurityUserRuleCollectionClient.CreateOrUpdate(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, ruleCollectionModel);

            var psSecurityUserRuleCollection = this.GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName);
            return psSecurityUserRuleCollection;
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string securityUserRuleCollectionName, string description, PSNetworkManagerSecurityUserGroupItem[] appliesTo) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case ByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.SecurityUserConfigurationName,
                        this.InputObject.Name,
                        this.InputObject.Description,
                        this.InputObject.AppliesToGroups.ToArray()
                    );

                case ByName:
                    return (
                        this.ResourceGroupName,
                        this.NetworkManagerName,
                        this.SecurityUserConfigurationName,
                        this.Name,
                        this.Description,
                        this.AppliesToGroup.ToArray()
                    );

                default:
                    throw new PSArgumentException("Invalid parameter set");
            }
        }
    }
}
