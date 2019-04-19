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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.ServiceBus
{
    /// <summary>
    /// 'New-AzureRmEventHubIpfilterRule' Cmdlet creates a new IPFilterRule
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusIPRule", DefaultParameterSetName = IPRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class AddAzureServiceBusIPRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = IPRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true, ParameterSetName = IPRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IPRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = IPRuleInputObjectParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Name { get; set; }        

        [Parameter(Mandatory = true, ParameterSetName = IPRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Subnet Resource ID")]
        [ValidateNotNullOrEmpty]
        public string IpMask { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = IPRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The IP Filter Action")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Allow")]
        public string Action { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IPRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 2, HelpMessage = "IPRule Configuration Object to be added")]
        [ValidateNotNullOrEmpty]
        public PSNWRuleSetIpRulesAttributes IpRuleObject { get; set; }


        public override void ExecuteCmdlet()
        {
            PSNetworkRuleSetAttributes networkRuleSet = Client.GetNetworkRuleSet(ResourceGroupName, Name);
            if (!networkRuleSet.IpRules.Contains(new PSNWRuleSetIpRulesAttributes { IpMask = IpMask }))
            {
                if (ShouldProcess(target: Name, action: string.Format("Adding IPrule for NetworkRuleSet of {0} in Resourcegroup {1}", Name, ResourceGroupName)))
                {
                    try
                    {
                        //Add the IpRules
                        if (ParameterSetName.Equals(IPRulePropertiesParameterSet))
                        {
                            networkRuleSet.IpRules.Add(new PSNWRuleSetIpRulesAttributes { IpMask = IpMask, Action = "Allow" });
                        }

                        if (ParameterSetName.Equals(IPRuleInputObjectParameterSet))
                        {
                            networkRuleSet.IpRules.Add(IpRuleObject);
                        }

                        WriteObject(Client.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, networkRuleSet));
                    }
                    catch (Management.ServiceBus.Models.ErrorResponseException ex)
                    {
                        WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                    }
                }
            }
            else
            {
                WriteError(ServiceBusClient.WriteErrorIPRuleExists());
            }
        }
    }
}
