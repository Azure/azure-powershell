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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Rule
{
    /// <summary>
    /// 'Set-AzureRmServiceBusRule' Cmdlet updates the specified ServiceBus Rule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusRuleVerb, SupportsShouldProcess = true), OutputType(typeof(RulesAttributes))]
    public class SetAzureRmServiceBusRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Topic Name.")]
        [Alias(AliasTopicName)]
        [ValidateNotNullOrEmpty]
        public string Topic { get; set; }

        [Parameter(Mandatory = true,
         ValueFromPipelineByPropertyName = false,
         Position = 3,
         HelpMessage = "Subscription Name.")]
        [Alias(AliasSubscriptionName)]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory = true,
         ValueFromPipelineByPropertyName = false,
         Position = 4,
         HelpMessage = "Rule Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = "ServiceBus Rules definition.")]
        [ValidateNotNullOrEmpty]
        public RulesAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            RulesAttributes rulesAttributes =  new RulesAttributes();
            if (InputObject != null)
            {
                rulesAttributes = InputObject;
            }            

            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateRule, Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateRules(ResourceGroupName, Namespace, Topic, Subscription, Name, rulesAttributes));
            }
        }
    }
}
