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
using System.Collections;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Rule
{
    /// <summary>
    /// 'Get-AzServiceBusRule' Cmdlet gives the details of a / List of subscriptions Rules
    /// <para> If Rule name provided, a single Rule detials will be returned</para>
    /// <para> If Rule name not provided, list of Rule will be returned</para>
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusRule"), OutputType(typeof(PSRulesAttributes))]
    public class GetAzureRmServiceBusRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Topic Name")]
        [Alias(AliasTopicName)]
        [ValidateNotNullOrEmpty]
        public string Topic { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, Position = 3, HelpMessage = "Subscription Name")]
        [Alias(AliasSubscriptionName)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, Position = 4, HelpMessage = "Rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of Rules to return.")]
        [ValidateRange(1, 10000)]
        public int? MaxCount { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    PSRulesAttributes ruleAttributes = Client.GetRule(ResourceGroupName, Namespace, Topic, Subscription, Name);
                    WriteObject(ruleAttributes);
                }
                else
                {
                    if (MaxCount.HasValue)
                    {
                        IEnumerable<PSRulesAttributes> ruleAttributes = Client.ListRules(ResourceGroupName, Namespace, Topic, Subscription, MaxCount);
                        WriteObject(ruleAttributes, true);
                    }
                    else
                    {
                        IEnumerable<PSRulesAttributes> ruleAttributes = Client.ListRules(ResourceGroupName, Namespace, Topic, Subscription);
                        WriteObject(ruleAttributes, true);
                    }

                }
            }
            catch (Management.ServiceBus.Models.ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
