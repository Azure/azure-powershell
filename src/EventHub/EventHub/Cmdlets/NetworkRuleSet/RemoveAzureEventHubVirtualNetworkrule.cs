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

using Microsoft.Azure.Commands.EventHub.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Commands.NetworkruleSet
{
    /// <summary>
    /// 'New-AzureRmEventHubIpfilterRule' Cmdlet creates a new IPFilterRule
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubVirtualNetworkRule", DefaultParameterSetName = VirtualNetworkRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class RemoveAzureEventHubVNetRule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }        

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Subnet Resource ID")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VirtualNetworkRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 2, HelpMessage = "IPRule Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSNWRuleSetVirtualNetworkRulesAttributes VirtualNetworkRuleObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSNetworkRuleSetAttributes networkRuleSet = Client.GetNetworkRuleSet(ResourceGroupName, Name);
            PSNWRuleSetVirtualNetworkRulesAttributes Toremove = new PSNWRuleSetVirtualNetworkRulesAttributes();


            if (ParameterSetName.Equals(VirtualNetworkRuleInputObjectParameterSet))
            {
                Toremove = VirtualNetworkRuleObject;
            }

            if (ParameterSetName.Equals(VirtualNetworkRulePropertiesParameterSet))
            {
                foreach (PSNWRuleSetVirtualNetworkRulesAttributes virtualnw in networkRuleSet.VirtualNetworkRules)
                {
                    if (virtualnw.Subnet.Id == SubnetId)
                    {
                        Toremove = virtualnw;
                        break;
                    }

                }
            }            


            if (Toremove != null)
            {
                if (ShouldProcess(target: Name, action: string.Format("Removeing VirtualNetworkRule for NetworkRuleSet of {0} in Resourcegroup {1}", Name, ResourceGroupName)))
                {
                    try
                    {
                        networkRuleSet.VirtualNetworkRules.Remove(Toremove);

                        var result = Client.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, networkRuleSet);

                        if (PassThru.IsPresent)
                        {
                            WriteObject(result);
                        }
                    }
                    catch (Management.EventHub.Models.ErrorResponseException ex)
                    {
                        WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                    }
                }
            }
            else
            { 
                WriteError(Eventhub.EventHubsClient.WriteErrorVirtualNetworkExists("Remove"));
            }
        }
    }
}
