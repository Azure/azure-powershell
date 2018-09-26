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

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'New-AzureRmEventHubIpfilterRule' Cmdlet creates a new IPFilterRule
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubVNetRule", DefaultParameterSetName = VnetRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetWorkRuleAttributes))]
    public class NewAzureEventHubVNetRule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }        

        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "Virtual Network Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = VnetRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "ARM ID of Virtual Network Subnet")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkSubnetId { get; set; }
        
        public override void ExecuteCmdlet()
        {
            PSVirtualNetWorkRuleAttributes vnetRule = new PSVirtualNetWorkRuleAttributes();            

            if (!string.IsNullOrEmpty(Name))
                vnetRule.Name = Name;

            if (!string.IsNullOrEmpty(VirtualNetworkSubnetId))
                vnetRule.VirtualNetworkSubnetId = VirtualNetworkSubnetId;

            if (ShouldProcess(target:vnetRule.Name, action:string.Format(Resources.CreateVNetRule,vnetRule.Name,Namespace)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateVNetRule(ResourceGroupName, Namespace, vnetRule.Name, vnetRule));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
                        
        }
    }
}
