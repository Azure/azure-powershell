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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    /// <summary>
    /// Cmdlet to set a Network Manager SecurityUser Rule.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRule", SupportsShouldProcess = true, DefaultParameterSetName = ByInputObject), OutputType(typeof(PSNetworkManagerSecurityUserRule))]
    public class SetAzNetworkManagerSecurityUserRuleCommand : NetworkManagerSecurityUserRuleBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager SecurityUser Rule")]
        public PSNetworkManagerSecurityUserRule InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            HelpMessage = "NetworkManager SecurityUserRule Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserRuleId")]
        public string ResourceId { get; set; }

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
        /// Extracts resource details from either ResourceId or InputObject.
        /// </summary>
        /// <returns>Tuple containing resource details.</returns>
        private (string resourceGroupName, string networkManagerName, string securityUserConfigurationName, string ruleCollectionName, string ruleName) ExtractResourceDetails()
        {
            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                return (
                    NetworkBaseCmdlet.GetResourceGroup(this.ResourceId),
                    NetworkBaseCmdlet.GetResourceName(this.ResourceId, "networkManagers"),
                    NetworkBaseCmdlet.GetResourceName(this.ResourceId, "securityUserConfigurations"),
                    NetworkBaseCmdlet.GetResourceName(this.ResourceId, "ruleCollections"),
                    this.Name ?? NetworkBaseCmdlet.GetResourceName(this.ResourceId, "rules")
                );
            }
            else
            {
                return (
                    this.InputObject.ResourceGroupName,
                    this.InputObject.NetworkManagerName,
                    this.InputObject.SecurityUserConfigurationName,
                    this.InputObject.RuleCollectionName,
                    this.InputObject.Name
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
                throw new ErrorException("Unknown SecurityUser Rule Type");
            }
        }
    }
}