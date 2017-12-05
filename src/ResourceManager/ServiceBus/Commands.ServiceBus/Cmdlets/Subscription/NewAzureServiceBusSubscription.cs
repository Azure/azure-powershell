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
using System.Xml;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Subscription
{
    /// <summary>
    /// 'New-AzureRmServiceBusSubscription' Cmdlet creates a new Subscription
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusSubscriptionVerb, SupportsShouldProcess = true), OutputType(typeof(SubscriptionAttributes))]
    public class NewAzureRmServiceBusSubscription : AzureServiceBusCmdletBase
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
            Position = 1,
            HelpMessage = "Topic Name.")]
        [Alias(AliasTopicName)]
        [ValidateNotNullOrEmpty]
        public string Topic { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Subscription Name")]
        [Alias(AliasSubscriptionName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
                
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Auto Delete On Idle - the TimeSpan idle interval after which the queue is automatically deleted. The minimum duration is 5 minutes.")]
        [ValidateNotNullOrEmpty]
        public string AutoDeleteOnIdle { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Timespan to live value. This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself. For Standard = Timespan.Max and Basic = 14 dyas")]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageTimeToLive { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dead Lettering On Message Expiration")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? DeadLetteringOnMessageExpiration { get; set; }        

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Batched Operations - value that indicates whether server-side batched operations are enabled")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableBatchedOperations { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Lock Duration")]
        public string LockDuration { get; set; }
        
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "MaxDeliveryCount - the maximum delivery count. A message is automatically deadlettered after this number of deliveries.")]
        [ValidateNotNullOrEmpty]
        public int? MaxDeliveryCount { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RequiresSession - the value indicating if this queue requires duplicate detection.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresSession { get; set; }

        public override void ExecuteCmdlet()
        {
            
            SubscriptionAttributes subAttributes = new SubscriptionAttributes();

            NamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroupName, Namespace);
            
            subAttributes.Name = Name;
            
            if (AutoDeleteOnIdle != null)
                subAttributes.AutoDeleteOnIdle = AutoDeleteOnIdle;

            if (DefaultMessageTimeToLive != null)
                subAttributes.DefaultMessageTimeToLive = DefaultMessageTimeToLive;

            if (LockDuration != null)
                subAttributes.LockDuration = LockDuration;

            if (DeadLetteringOnMessageExpiration != null)
                subAttributes.DeadLetteringOnMessageExpiration = DeadLetteringOnMessageExpiration;

            if (EnableBatchedOperations != null)
                subAttributes.EnableBatchedOperations = EnableBatchedOperations;

            if (DeadLetteringOnMessageExpiration != null)
                subAttributes.DeadLetteringOnMessageExpiration = DeadLetteringOnMessageExpiration;

            if (MaxDeliveryCount != null)
                subAttributes.MaxDeliveryCount = MaxDeliveryCount;

            if (RequiresSession != null)
                subAttributes.RequiresSession = RequiresSession;
            
            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateSubscription, Name, Topic,Namespace)))
            {
                WriteObject(Client.CreateUpdateSubscription(ResourceGroupName, Namespace, Topic, Name, subAttributes));
            }
        }
    }
}
