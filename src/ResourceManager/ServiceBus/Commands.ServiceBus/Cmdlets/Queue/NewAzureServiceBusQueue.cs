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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'New-AzureRmServiceBusQueue' Cmdlet creates a new Queue
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusQueueVerb, SupportsShouldProcess = true), OutputType(typeof(PSQueueAttributes))]
    public class NewAzureRmServiceBusQueue : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Queue Name")]
        [Alias(AliasQueueName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "EnablePartitioning")]
        [ValidateSet("TRUE", "FALSE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnablePartitioning { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Lock Duration")]
        
        public string LockDuration { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Auto Delete On Idle - the TimeSpan idle interval after which the queue is automatically deleted. The minimum duration is 5 minutes.")]
        [ValidateNotNullOrEmpty]
        public string AutoDeleteOnIdle { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Timespan to live value. This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself. For Standard = Timespan.Max and Basic = 14 dyas")]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageTimeToLive { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Duplicate Detection History Time Window - TimeSpan, that defines the duration of the duplicate detection history. The default value is 10 minutes.")]
        [ValidateNotNullOrEmpty]
        public string DuplicateDetectionHistoryTimeWindow { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Dead Lettering On Message Expiration")]
        [ValidateSet("TRUE", "FALSE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? DeadLetteringOnMessageExpiration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable Batched Operations - value that indicates whether server-side batched operations are enabled")]
        public SwitchParameter EnableBatchedOperations { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "EnableExpress - a value that indicates whether Express Entities are enabled. An express queue holds a message in memory temporarily before writing it to persistent storage.")]
        [ValidateSet("TRUE", "FALSE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableExpress { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "MaxDeliveryCount - the maximum delivery count. A message is automatically deadlettered after this number of deliveries.")]
        [ValidateNotNullOrEmpty]
        public int? MaxDeliveryCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "MaxSizeInMegabytes - the maximum size of the queue in megabytes, which is the size of memory allocated for the queue.")]
        [ValidateNotNullOrEmpty]
        public long? MaxSizeInMegabytes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "MessageCount - the number of messages in the queue")]
        [ValidateNotNullOrEmpty]
        public long? MessageCount { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "RequiresDuplicateDetection - a value that indicates whether the queue supports the concept of session")]
        [ValidateSet("TRUE", "FALSE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresDuplicateDetection { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "RequiresSession - the value indicating if this queue requires duplicate detection")]
        [ValidateSet("TRUE", "FALSE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresSession { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "SizeInBytes - the size of the queue in bytes")]
        [ValidateNotNullOrEmpty]
        public long? SizeInBytes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Queue/Topic name to forward the messages")]
        [ValidateNotNullOrEmpty]        
        public string ForwardTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Queue/Topic name to forward the Dead Letter message")]
        [ValidateNotNullOrEmpty]
        public string ForwardDeadLetteredMessagesTo { get; set; }

        public override void ExecuteCmdlet()
        {
            PSQueueAttributes queueAttributes = new PSQueueAttributes();

            PSNamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroupName, Namespace);
            
            queueAttributes.Name = Name;

            queueAttributes.EnablePartitioning = EnablePartitioning;

            if (LockDuration != null)
            { queueAttributes.LockDuration = LockDuration; }

            if (AutoDeleteOnIdle != null)
            { queueAttributes.AutoDeleteOnIdle = AutoDeleteOnIdle; }

            if (DefaultMessageTimeToLive != null)
            { queueAttributes.DefaultMessageTimeToLive = DefaultMessageTimeToLive; }

            if (DuplicateDetectionHistoryTimeWindow != null)
            { queueAttributes.DuplicateDetectionHistoryTimeWindow = DuplicateDetectionHistoryTimeWindow; }

            if (DeadLetteringOnMessageExpiration != null)
            { queueAttributes.DeadLetteringOnMessageExpiration = DeadLetteringOnMessageExpiration; }

            queueAttributes.EnableBatchedOperations = EnableBatchedOperations.IsPresent;

            if (EnableExpress != null)
            { queueAttributes.EnableExpress = EnableExpress; }

            if (MaxDeliveryCount != null)
            { queueAttributes.MaxDeliveryCount = MaxDeliveryCount; }

            if (MaxSizeInMegabytes != null)
            { queueAttributes.MaxSizeInMegabytes = (int?)MaxSizeInMegabytes; }

            if (MessageCount != null)
            { queueAttributes.MessageCount = MessageCount; }

            if (RequiresDuplicateDetection != null)
            { queueAttributes.RequiresDuplicateDetection = RequiresDuplicateDetection; }

            if (RequiresSession != null)
            { queueAttributes.RequiresSession = RequiresSession; }

            if (SizeInBytes != null)
            { queueAttributes.SizeInBytes = SizeInBytes; }

            if (ForwardTo != null)
            { queueAttributes.ForwardTo = ForwardTo; }

            if (ForwardDeadLetteredMessagesTo != null)
            { queueAttributes.ForwardDeadLetteredMessagesTo = ForwardDeadLetteredMessagesTo; }


            if (ShouldProcess(target: Name, action: string.Format(Resources.CreateQueue, Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateQueue(ResourceGroupName, Namespace, Name, queueAttributes));
            }
        }
    }
}
