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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.serviceBus
{
    /// <summary>
    /// 'New-AzureRmServiceBusfilterRule' Cmdlet creates a new IPFilterRule
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusIPFilterRule", DefaultParameterSetName = IpFilterRulePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSIpFilterRuleAttributes))]
    public class NewAzureServiceBusIpFilterRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }        

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "IP Filter Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Single IPv4 address or a block of IP addresses in CIDR notation.")]
        [ValidateNotNullOrEmpty]
        public string IpMask { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Action for the IP provided in IPMask, Possible values include: 'Accept', 'Reject' ")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Accept", "Reject", IgnoreCase = true)]
        public string Action { get; set; }


        public override void ExecuteCmdlet()
        {
            PSIpFilterRuleAttributes ipfilterRule = new PSIpFilterRuleAttributes();            

            if (!string.IsNullOrEmpty(Name))
                ipfilterRule.Name = Name;

            if (!string.IsNullOrEmpty(IpMask))
                ipfilterRule.IpMask = IpMask;

            if (!string.IsNullOrEmpty(Action))
                ipfilterRule.Action = Action;

            if (ShouldProcess(target:ipfilterRule.Name, action:string.Format(Resources.CreateIpFilterRule,ipfilterRule.Name,Namespace)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateIPFilterRule(ResourceGroupName, Namespace, ipfilterRule.Name, ipfilterRule));
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBus.ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }
                        
        }
    }
}
