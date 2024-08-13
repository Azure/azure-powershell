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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRule", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerRoutingRule))]
    public class SetAzNetworkManagerRoutingRuleCommand : NetworkManagerRoutingRuleBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager Routing Rule")]
        public PSNetworkManagerRoutingRule InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                // Map to the sdk object
                RoutingRule routingRuleModel;
                if (this.InputObject.GetType().Name == "PSNetworkManagerRoutingRule")
                {
                    routingRuleModel = NetworkResourceManagerProfile.Mapper.Map<RoutingRule>(InputObject);
                }
                else
                {
                    throw new ErrorException("Unknown Routing Rule Type");
                }

                // Execute the PUT NetworkManagerRoutingRule call
                var routingRuleResponse = this.NetworkManagerRoutingRuleOperationClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.RoutingConfigurationName, this.InputObject.RuleCollectionName, this.InputObject.Name, routingRuleModel);
                var psRoutingRule = this.ToPSRoutingRule(routingRuleResponse);
                WriteObject(psRoutingRule);
            }
        }
    }
}
