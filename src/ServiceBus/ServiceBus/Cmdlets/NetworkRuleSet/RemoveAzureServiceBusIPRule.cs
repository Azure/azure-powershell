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
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusIPRule", DefaultParameterSetName = IPRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSetAttributes))]
    public class RemoveAzureServiceBusIPRule : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = true, ParameterSetName = IPRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 2, HelpMessage = "IPRule Configuration Object")]
        [ValidateNotNullOrEmpty]
        public PSNWRuleSetIpRulesAttributes IpRuleObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        public override void ExecuteCmdlet()
        {
            PSNetworkRuleSetAttributes networkRuleSet = Client.GetNetworkRuleSet(ResourceGroupName, Name);

            PSNWRuleSetIpRulesAttributes Toremove = new PSNWRuleSetIpRulesAttributes();

            if (ParameterSetName.Equals(IPRuleInputObjectParameterSet))
            {
                Toremove = IpRuleObject;
            }

            if (ParameterSetName.Equals(IPRulePropertiesParameterSet))
            {
                foreach (PSNWRuleSetIpRulesAttributes iprule in networkRuleSet.IpRules)
                {
                    if (iprule.IpMask.Equals(IpMask))
                    {
                        Toremove = iprule;
                        break;
                    }
                }
            }
            

            if (Toremove != null)
            {
                if (ShouldProcess(target: Name, action: string.Format("Removing IPrule for NetworkRuleSet of {0} in Resourcegroup {1}", Name, ResourceGroupName)))
                {
                    try
                    {
                        //Add the IpRules
                        networkRuleSet.IpRules.Remove(Toremove);
                        var result = Client.CreateOrUpdateNetworkRuleSet(ResourceGroupName, Name, networkRuleSet);
                        if (PassThru.IsPresent)
                        {
                            WriteObject(result);
                        }
                    }
                    catch (Management.ServiceBus.Models.ErrorResponseException ex)
                    {
                        WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                    }
                }
            }
            else
            {
                WriteError(ServiceBusClient.WriteErrorIPRuleExists("Remove"));
            }
        }
    }
}
