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

using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.NetworkruleSet
{
    /// <summary>
    /// 'New-AzureRmEventHubIpfilterRule' Cmdlet creates a new IPFilterRule
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusVirtualNetworkRule", DefaultParameterSetName = VirtualNetworkRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class NewAzureEventHubVNetRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }        

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Subnet Resource ID")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, HelpMessage = "Indicates whether to ignore missing vnet Service Endpoint")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IgnoreMissingVnetServiceEndpoint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 2, HelpMessage = "VirtualNetworkRule Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSNWRuleSetVirtualNetworkRulesAttributes VirtualNetworkRuleObject { get; set; }

        public override void ExecuteCmdlet()
        {
            PSNetworkRuleSetAttributes networkRuleSet = Client.GetNetworkRuleSet(ResourceGroupName, Name);
            if (!networkRuleSet.VirtualNetworkRules.Contains(new PSNWRuleSetVirtualNetworkRulesAttributes { Subnet = new PSSubnetAttributes { Id = SubnetId }, IgnoreMissingVnetServiceEndpoint = IgnoreMissingVnetServiceEndpoint }))
            {
                if (ShouldProcess(target: Name, action: string.Format("Adding VirtualNetworkRule for NetworkRuleSet of {0} in Resourcegroup {1}", Name, ResourceGroupName)))
                {
                    try
                    {
                        //Add the VirtualNetworkRuleSet
                        if (ParameterSetName.Equals(VirtualNetworkRulePropertiesParameterSet))
                        {
                            networkRuleSet.VirtualNetworkRules.Add(new PSNWRuleSetVirtualNetworkRulesAttributes { Subnet = new PSSubnetAttributes { Id = SubnetId }, IgnoreMissingVnetServiceEndpoint = IgnoreMissingVnetServiceEndpoint.IsPresent });
                            WriteObject(Client.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, networkRuleSet));
                        }

                        if (ParameterSetName.Equals(VirtualNetworkRuleInputObjectParameterSet))
                        {
                            networkRuleSet.VirtualNetworkRules.Add(VirtualNetworkRuleObject);
                            WriteObject(Client.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, networkRuleSet));
                        }
                    }
                    catch (Management.ServiceBus.Models.ErrorResponseException ex)
                    {
                        WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                    }
                }
            }
            else {
                WriteError(ServiceBusClient.WriteErrorVirtualNetworkExists());
            }
        }
    }
}
