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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRuleCollection", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObject), OutputType(typeof(PSNetworkManagerSecurityUserRuleCollection))]
    public class SetAzNetworkManagerSecurityUserRuleCollection : NetworkManagerSecurityUserRuleCollectionBaseCmdlet
    {
        private const string SetByResourceId = "ByResourceId";
        private const string SetByInputObject = "ByInputObject";
        private const string SetByName = "ByNameParameters";

        [Alias("ResourceName")]
        [Parameter(
           ParameterSetName = SetByName,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager SecurityUser Collection")]
        public PSNetworkManagerSecurityUserRuleCollection InputObject { get; set; }

        [Parameter(
            ParameterSetName = SetByResourceId,
            Mandatory = true,
            HelpMessage = "NetworkManager SecurityUserCollection Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserCollectionId")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = SetByName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = SetByName,
            Mandatory = true,
            HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkManagerName { get; set; }

        [Parameter(
            ParameterSetName = SetByName,
            Mandatory = true,
            HelpMessage = "The securityUser configuration name.")]
        [ValidateNotNullOrEmpty]
        public string SecurityUserConfigurationName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByName)]
        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByResourceId)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var (resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName) = ExtractParameters();

            if (this.ShouldProcess(securityUserRuleCollectionName, VerbsLifecycle.Restart))
            {
                if (!this.IsNetworkManagerSecurityUserRuleCollectionPresent(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, securityUserRuleCollectionName));
                }

                // Fetch the InputObject if it is not set and ResourceId is provided
                if (this.InputObject == null && !string.IsNullOrEmpty(this.ResourceId))
                {
                    this.InputObject = this.GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName);
                }

                // Update the description if provided
                if (!string.IsNullOrEmpty(this.Description))
                {
                    this.InputObject.Description = this.Description;
                }

                // Map to the sdk object
                var securityUserRuleCollectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserRuleCollection>(this.InputObject);

                // Execute the PUT NetworkManagerSecurityUserRuleCollection call
                this.NetworkManagerSecurityUserRuleCollectionClient.CreateOrUpdate(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName, securityUserRuleCollectionModel);

                var psSecurityUserRuleCollection = this.GetNetworkManagerSecurityUserRuleCollection(resourceGroupName, networkManagerName, securityUserConfigurationName, securityUserRuleCollectionName);
                WriteObject(psSecurityUserRuleCollection);
            }
        }

        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string securityUserRuleCollectionName) ExtractParameters()
        {
            switch (this.ParameterSetName)
            {
                case SetByInputObject:
                    return (
                        this.InputObject.ResourceGroupName,
                        this.InputObject.NetworkManagerName,
                        this.InputObject.SecurityUserConfigurationName,
                        this.InputObject.Name
                    );

                case SetByResourceId:
                    return (
                        NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "securityUserConfigurations"),
                        NetworkBaseCmdlet.GetResourceName(this.ResourceId, "ruleCollections")
                    );

                case SetByName:
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
