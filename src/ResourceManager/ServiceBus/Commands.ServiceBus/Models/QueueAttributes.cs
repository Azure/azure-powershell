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

using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Xml;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    public class QueueAttributes
    {
        public QueueAttributes()
        { }

        public QueueAttributes(SBQueue quResource)
        {
            if (quResource != null)
            {
                Name = quResource.Name;               
                LockDuration = XmlConvert.ToString((TimeSpan)quResource.LockDuration);
                AccessedAt = quResource.AccessedAt;
                AutoDeleteOnIdle = XmlConvert.ToString((TimeSpan)quResource.AutoDeleteOnIdle); 
                CreatedAt = quResource.CreatedAt;
                DefaultMessageTimeToLive = XmlConvert.ToString((TimeSpan)quResource.DefaultMessageTimeToLive);
                DuplicateDetectionHistoryTimeWindow = XmlConvert.ToString((TimeSpan)quResource.DuplicateDetectionHistoryTimeWindow);                
                DeadLetteringOnMessageExpiration = quResource.DeadLetteringOnMessageExpiration;
                EnableExpress = quResource.EnableExpress;
                EnablePartitioning = quResource.EnablePartitioning;                
                MaxDeliveryCount = quResource.MaxDeliveryCount;
                MaxSizeInMegabytes = quResource.MaxSizeInMegabytes;
                MessageCount = quResource.MessageCount;
                CountDetails = quResource.CountDetails;
                RequiresDuplicateDetection = quResource.RequiresDuplicateDetection;
                RequiresSession = quResource.RequiresSession;
                SizeInBytes = quResource.SizeInBytes;
                Status = quResource.Status;                
                UpdatedAt = quResource.UpdatedAt;

            }
        }

        /// <summary>
        /// Queue name.
        /// </summary> 
        public string Name { get; set; }

        
        /// <summary>
        /// the duration of a peek lock; that is, the amount of time that the
        /// message is locked for other receivers. The maximum value for
        /// LockDuration is 5 minutes; the default value is 1 minute.
        /// </summary> 
        public string LockDuration { get; set; }

        /// <summary>
        /// Last time a message was sent, or the last time there was a receive
        /// request to this queue.
        /// </summary> 
        public DateTime? AccessedAt { get; set; }

        /// <summary>
        /// the TimeSpan idle interval after which the queue is automatically
        /// deleted. The minimum duration is 5 minutes.
        /// </summary> 
        public string AutoDeleteOnIdle { get; set; }
        

        /// <summary>
        /// the exact time the message was created.
        /// </summary> 
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// the default message time to live value. This is the duration after
        /// which the message expires, starting from when the message is sent
        /// to Service Bus. This is the default value used when TimeToLive is
        /// not set on a message itself.
        /// </summary> 
        public string DefaultMessageTimeToLive { get; set; }

        /// <summary>
        /// TimeSpan structure that defines the duration of the duplicate
        /// detection history. The default value is 10 minutes..
        /// </summary> 
        public string DuplicateDetectionHistoryTimeWindow { get; set; }

        /// <summary>
        /// a value that indicates whether this queue has dead letter support
        /// when a message expires.
        /// </summary> 
        public bool? DeadLetteringOnMessageExpiration { get; set; }

        /// <summary>
        /// a value that indicates whether Express Entities are enabled. An
        /// express queue holds a message in memory temporarily before
        /// writing it to persistent storage.
        /// </summary> 
        public bool? EnableExpress { get; set; }

        /// <summary>
        /// value that indicates whether the queue to be partitioned across
        /// multiple message brokers is enabled.
        /// </summary> 
        public bool? EnablePartitioning { get; set; }        

        /// <summary>
        /// the maximum delivery count. A message is automatically
        /// deadlettered after this number of deliveries.
        /// </summary> 
        public int? MaxDeliveryCount { get; set; }

        /// <summary>
        /// the maximum size of the queue in megabytes, which is the size of
        /// memory allocated for the queue.
        /// </summary> 
        public int? MaxSizeInMegabytes { get; set; }

        /// <summary>
        /// the number of messages in the queue.
        /// </summary> 
        public long? MessageCount { get; set; }

        /// <summary>
        /// </summary> 
        public MessageCountDetails CountDetails { get; set; }

        /// <summary>
        /// the value indicating if this queue requires duplicate detection.
        /// </summary>
        public bool? RequiresDuplicateDetection { get; set; }

        /// <summary>
        /// a value that indicates whether the queue supports the concept of
        /// session.
        /// </summary>
        public bool? RequiresSession { get; set; }

        /// <summary>
        /// the size of the queue in bytes.
        /// </summary>
        public long? SizeInBytes { get; set; }

        /// <summary>
        /// Enumerates the possible values for the status of a messaging
        /// entity. Possible values include: 'Active', 'Creating',
        /// 'Deleting', 'Disabled', 'ReceiveDisabled', 'Renaming',
        /// 'Restoring', 'SendDisabled', 'Unknown'
        /// </summary>
        public EntityStatus? Status { get; set; }        

        /// <summary>
        /// the exact time the message has been updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }        
    }
}
