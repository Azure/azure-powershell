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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzureRmEventHub' Cmdlet updates the specified EventHub
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubIPFilterRule", SupportsShouldProcess = true, DefaultParameterSetName = IpFilterRulePropertiesParameterSet), OutputType(typeof(PSIpFilterRuleAttributes))]
    public class SetAzureEventHubIpFilterRule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRulePropertiesParameterSet, Position = 2, HelpMessage = "Ip Filter Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRuleInputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Ip Filter Rule Object")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubObj)]
        public PSIpFilterRuleAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = IpFilterRuleResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Ip Filter Rule Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP Filter Action. Possible values include: 'Accept', 'Reject'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Accept", "Reject", IgnoreCase = true)]
        public string Action { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Single IPv4 address or a block of IP addresses in CIDR notation.")]
        [ValidateNotNullOrEmpty]
        public string IpMask { get; set; }
        
        public override void ExecuteCmdlet()
        {
            PSIpFilterRuleAttributes ipfilterrule = new PSIpFilterRuleAttributes();
                        
            if (ParameterSetName.Equals(IpFilterRuleInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
                Action = InputObject.Action;
                IpMask = InputObject.IpMask;
            }
            else if (ParameterSetName.Equals(IpFilterRuleResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }
            else if (ParameterSetName.Equals(IpFilterRulePropertiesParameterSet))
            {
                if (string.IsNullOrEmpty(Name))
                    ipfilterrule.Name = Name;
            }

            if (!string.IsNullOrEmpty(Action))
                ipfilterrule.Action = Action;
            else
                ipfilterrule.Action = InputObject.Action;

            if (!string.IsNullOrEmpty(IpMask))
                ipfilterrule.IpMask = IpMask;
            else
                ipfilterrule.IpMask = InputObject.IpMask;


            if (ShouldProcess(target:Name, action: string.Format(Resources.UpdateIpFilterRule,Name,Namespace)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateIPFilterRule(ResourceGroupName, Namespace, Name, ipfilterrule));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
