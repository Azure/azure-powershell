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
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'New-AzureRmServiceBusQueue' Cmdlet creates a new Queue
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServicebusQueueVerb, SupportsShouldProcess = true), OutputType(typeof(QueueAttributes))]
    public class NewAzureRmServiceBusQueue : AzureServiceBusCmdletBase
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
            HelpMessage = "Queue Name.")]
        [ValidateNotNullOrEmpty]
        public string QueueName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "EnablePartitioning")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnablePartitioning { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Lock Duration")]
        
        public string LockDuration { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Auto Delete On Idle - the TimeSpan idle interval after which the queue is automatically deleted. The minimum duration is 5 minutes.")]
        [ValidateNotNullOrEmpty]
        public string AutoDeleteOnIdle { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Default Message TimeTo Live")]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageTimeToLive { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Duplicate Detection History Time Window - TimeSpan, that defines the duration of the duplicate detection history. The default value is 10 minutes.")]
        [ValidateNotNullOrEmpty]
        public string DuplicateDetectionHistoryTimeWindow { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Batched Operations - value that indicates whether server-side batched operations are enabled")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableBatchedOperations { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dead Lettering On Message Expiration")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? DeadLetteringOnMessageExpiration { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "EnableExpress - a value that indicates whether Express Entities are enabled. An express queue holds a message in memory temporarily before writing it to persistent storage.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? EnableExpress { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IsAnonymousAccessible - a value that indicates whether the message is anonymous accessible.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? IsAnonymousAccessible { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "MaxDeliveryCount - the maximum delivery count. A message is automatically deadlettered after this number of deliveries.")]
        [ValidateNotNullOrEmpty]
        public int? MaxDeliveryCount { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "MaxSizeInMegabytes - the maximum size of the queue in megabytes, which is the size of memory allocated for the queue.")]
        [ValidateNotNullOrEmpty]
        public long? MaxSizeInMegabytes { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "MessageCount - the number of messages in the queue.")]
        [ValidateNotNullOrEmpty]
        public long? MessageCount { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RequiresDuplicateDetection - a value that indicates whether the queue supports the concept of session")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresDuplicateDetection { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RequiresSession - the value indicating if this queue requires duplicate detection.")]
        [ValidateSet("TRUE", "FALSE",
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public bool? RequiresSession { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SizeInBytes - the size of the queue in bytes.")]
        [ValidateNotNullOrEmpty]
        public long? SizeInBytes { get; set; }

        public override void ExecuteCmdlet()
        {
            QueueAttributes queueAttributes = new QueueAttributes();

            NamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroup, NamespaceName);

            queueAttributes.Location = getNamespaceLoc.Location;


            queueAttributes.Name = QueueName;
            queueAttributes.EnablePartitioning = EnablePartitioning;

            if (LockDuration != null)
                queueAttributes.LockDuration = LockDuration;

            if (AutoDeleteOnIdle != null)
                queueAttributes.AutoDeleteOnIdle = AutoDeleteOnIdle;

            if (DefaultMessageTimeToLive != null)
                queueAttributes.DefaultMessageTimeToLive = DefaultMessageTimeToLive;

            if (DuplicateDetectionHistoryTimeWindow != null)
                queueAttributes.DuplicateDetectionHistoryTimeWindow = DuplicateDetectionHistoryTimeWindow;


            if (EnableBatchedOperations != null)
                queueAttributes.EnableBatchedOperations = EnableBatchedOperations;

            if (DeadLetteringOnMessageExpiration != null)
                queueAttributes.DeadLetteringOnMessageExpiration = DeadLetteringOnMessageExpiration;

            if (IsAnonymousAccessible != null)
                queueAttributes.IsAnonymousAccessible = IsAnonymousAccessible;

            if (MaxSizeInMegabytes != null)
                queueAttributes.MaxSizeInMegabytes = MaxSizeInMegabytes;

            if (MaxDeliveryCount != null)
                queueAttributes.MaxDeliveryCount = MaxDeliveryCount;

            if (MessageCount != null)
                queueAttributes.MessageCount = MessageCount;

            if (RequiresDuplicateDetection != null)
                queueAttributes.RequiresDuplicateDetection = RequiresDuplicateDetection;

            if (RequiresSession != null)
                queueAttributes.RequiresSession = RequiresSession;

            if (SizeInBytes != null)
                queueAttributes.SizeInBytes = SizeInBytes;
            
            if (ShouldProcess(target: QueueName, action: string.Format("Create New Queue:{0} for Namespace:{1}", QueueName,NamespaceName)))
            {
                WriteObject(Client.CreateUpdateQueue(ResourceGroup, NamespaceName, queueAttributes.Name, queueAttributes));
            }
        }
    }
}
