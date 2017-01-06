﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Subscription
{
    /// <summary>
    /// 'Get-AzureRmServiceBusSubscription' Cmdlet gives the details of a / List of Topic subscriptions(s)
    /// <para> If Subscription name provided, a single Subscription detials will be returned</para>
    /// <para> If Subscription name not provided, list of Subscription will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ServicebusSubscriptionVerb), OutputType(typeof(SubscriptionAttributes))]
    public class GetAzureRmServiceBusSubscription : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           Position = 2,
           HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(Mandatory = false,
         ValueFromPipelineByPropertyName = false,
         Position = 3,
         HelpMessage = "Subscription Name.")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(SubscriptionName))
            {
                SubscriptionAttributes subscriptionAttributes = Client.GetSubscription(ResourceGroup, NamespaceName, TopicName, SubscriptionName);
                WriteObject(subscriptionAttributes);
            }
            else
            {
                IEnumerable<SubscriptionAttributes> subscriptionAttributes = Client.ListSubscriptions(ResourceGroup, NamespaceName, TopicName);
                WriteObject(subscriptionAttributes);
            }
            
        }
    }
}
