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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRule", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerSecurityBaseUserRule))]
    public class SetAzNetworkManagerSecurityUserRuleCommand : NetworkManagerSecurityUserRuleBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security user rule collection name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

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
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager Security User Rule")]
        public PSNetworkManagerSecurityBaseUserRule SecurityUserRule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.SecurityUserRule.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                // Map to the sdk object
                BaseUserRule userRuleModel;
                if (this.SecurityUserRule.GetType().Name == "PSNetworkManagerSecurityUserRule")
                {
                    userRuleModel = NetworkResourceManagerProfile.Mapper.Map<UserRule>(SecurityUserRule);
                }
                else if (this.SecurityUserRule.GetType().Name == "PSNetworkManagerSecurityDefaultUserRule")
                {
                    userRuleModel = NetworkResourceManagerProfile.Mapper.Map<DefaultUserRule>(SecurityUserRule);
                }
                else
                {
                    throw new ErrorException("UnKnown User Rule Type");
                }


                // Execute the PUT NetworkManagerSecurityUserRule call
                var userRuleResponse = this.NetworkManagerSecurityUserRuleOperationClient.CreateOrUpdate(userRuleModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.SecurityUserRule.Name);
                var psUserRule = this.ToPSSecurityUserRule(userRuleResponse);
                WriteObject(psUserRule);
            }
        }
    }
}
