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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    /// <summary>
    /// Cmdlet to set a Network Manager SecurityUser Rule.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRule", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObject), OutputType(typeof(PSNetworkManagerSecurityUserRule))]
    public class SetAzNetworkManagerSecurityUserRuleCommand : NetworkManagerSecurityUserRuleBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager SecurityUser Rule")]
        public PSNetworkManagerSecurityUserRule InputObject { get; set; }

        [Parameter(
            ParameterSetName = SetByResourceId,
            Mandatory = true,
            HelpMessage = "NetworkManager SecurityUserRule Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserRuleId")]
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

        [Alias("ConfigName")]
        [Parameter(
            ParameterSetName = SetByName,
            Mandatory = true,
            HelpMessage = "The security user configuration name.")]
        [ValidateNotNullOrEmpty]
        public string SecurityUserConfigurationName { get; set; }

        [Parameter(
            ParameterSetName = SetByName,
            Mandatory = true,
            HelpMessage = "The rule collection name.")]
        [ValidateNotNullOrEmpty]
        public string RuleCollectionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject?.Name ?? this.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                var (resourceGroupName, networkManagerName, securityUserConfigurationName, ruleCollectionName, ruleName) = ExtractResourceDetails();

                var securityUserRuleModel = MapToSdkObject();

                var securityUserRuleResponse = this.NetworkManagerSecurityUserRuleOperationClient.CreateOrUpdate(
                    resourceGroupName,
                    networkManagerName,
                    securityUserConfigurationName,
                    ruleCollectionName,
                    ruleName,
                    securityUserRuleModel);

                var psSecurityUserRule = this.ToPSSecurityUserRule(securityUserRuleResponse);
                WriteObject(psSecurityUserRule);
            }
        }

        /// <summary>
        /// Extracts resource details from either ResourceId, InputObject, or individual name parameters.
        /// </summary>
        /// <returns>Tuple containing resource details.</returns>
        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string ruleCollectionName, string ruleName) ExtractResourceDetails()
        {
            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                // Validate the format of the ResourceId
                var segments = parsedResourceId.ParentResource.Split('/');
                if (segments.Length < 6)
                {
                    throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                }

                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.NetworkManagerName = segments[1];
                this.SecurityUserConfigurationName = segments[3];
                this.RuleCollectionName = segments[5];

                return (this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.Name);
            }
            else if (this.InputObject != null)
            {
                return (
                    this.InputObject.ResourceGroupName,
                    this.InputObject.NetworkManagerName,
                    this.InputObject.SecurityUserConfigurationName,
                    this.InputObject.RuleCollectionName,
                    this.InputObject.Name
                );
            }
            else
            {
                return (
                    this.ResourceGroupName,
                    this.NetworkManagerName,
                    this.SecurityUserConfigurationName,
                    this.RuleCollectionName,
                    this.Name
                );
            }
        }

        /// <summary>
        /// Maps the InputObject to the SDK's SecurityUserRule object.
        /// </summary>
        /// <returns>Mapped SecurityUserRule object.</returns>
        private SecurityUserRule MapToSdkObject()
        {
            if (this.InputObject.GetType().Name == "PSNetworkManagerSecurityUserRule")
            {
                return NetworkResourceManagerProfile.Mapper.Map<SecurityUserRule>(InputObject);
            }
            else
            {
                var securityUserRule = new SecurityUserRule
                {
                    Protocol = this.InputObject.Protocol,
                    Direction = this.InputObject.Direction,
                    Sources = this.InputObject.Sources?.Select(s => new AddressPrefixItem(s.AddressPrefix, s.AddressPrefixType)).ToList(),
                    Destinations = this.InputObject.Destinations?.Select(d => new AddressPrefixItem(d.AddressPrefix, d.AddressPrefixType)).ToList(),
                    SourcePortRanges = this.InputObject.SourcePortRanges,
                    DestinationPortRanges = this.InputObject.DestinationPortRanges
                };

                if (!string.IsNullOrEmpty(this.InputObject.Description))
                {
                    securityUserRule.Description = this.InputObject.Description;
                }

                return securityUserRule;
            }
        }
    }
}