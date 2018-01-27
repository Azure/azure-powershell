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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Subscription
{
    /// <summary>
    /// 'Set-AzureRmServiceBusSubscription' Cmdlet updates the specified ServiceBus Subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusSubscriptionVerb, SupportsShouldProcess = true), OutputType(typeof(SubscriptionAttributes))]
    public class SetAzureRmServiceBusSubscription : AzureServiceBusCmdletBase
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
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ServiceBus Subscription definition.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasSubscriptionObj)]
        public SubscriptionAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            SubscriptionAttributes subscriptionAttributes =  new SubscriptionAttributes();
            if (InputObject != null)
            {
                subscriptionAttributes = InputObject;
            }
            else
            {
               // subscriptionAttributes = SubscriptionObj;
            }
            
            if (ShouldProcess(target: subscriptionAttributes.Name, action: string.Format(Resources.UpdateSubscription, subscriptionAttributes.Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateSubscription(ResourceGroupName, Namespace, Topic, subscriptionAttributes.Name, subscriptionAttributes));
            }
        }
    }
}
