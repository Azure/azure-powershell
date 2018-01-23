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
using System.Collections.Generic;
using System.Xml;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    public class TopicAttributes 
    {
        public TopicAttributes()
        { }

        public TopicAttributes(SBTopic topicResource)
        {
            if (topicResource != null)
            {
                AccessedAt = topicResource.AccessedAt;
                AutoDeleteOnIdle = XmlConvert.ToString((TimeSpan)topicResource.AutoDeleteOnIdle);                
                CreatedAt = topicResource.CreatedAt;
                CountDetails = topicResource.CountDetails;
                DefaultMessageTimeToLive = XmlConvert.ToString((TimeSpan)topicResource.DefaultMessageTimeToLive);
                DuplicateDetectionHistoryTimeWindow = XmlConvert.ToString((TimeSpan)topicResource.DuplicateDetectionHistoryTimeWindow);
                EnableBatchedOperations = topicResource.EnableBatchedOperations;
                EnableExpress = topicResource.EnableExpress;
                EnablePartitioning = topicResource.EnablePartitioning;                
                MaxSizeInMegabytes = topicResource.MaxSizeInMegabytes;
                RequiresDuplicateDetection = topicResource.RequiresDuplicateDetection;
                SizeInBytes = topicResource.SizeInBytes;
                Status = topicResource.Status;
                SubscriptionCount = topicResource.SubscriptionCount;
                SupportOrdering = topicResource.SupportOrdering;
                UpdatedAt = topicResource.UpdatedAt;
                Name = topicResource.Name;
                Id = topicResource.Id;
                Type = topicResource.Type;
            }
        }

        /// <summary>
        /// Queue name.
        /// </summary> 
        public string Name { get; set; }

        

        /// <summary>
        /// Id of the resource.
        /// </summary> 
        public string Id { get; set; }

        /// <summary>
        /// Type of the resource.
        /// </summary> 
        public string Type { get; set; }

        /// <summary>
        /// Last time the message was sent or a request was received for this
        /// topic.
        /// </summary>
        public DateTime? AccessedAt { get; set; }

        /// <summary>
        /// TimeSpan idle interval after which the topic is automatically
        /// deleted. The minimum duration is 5 minutes.
        /// </summary>
        public string AutoDeleteOnIdle { get; set; }        

        /// <summary>
        /// Exact time the message was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// </summary>
        public MessageCountDetails CountDetails { get; set; }

        /// <summary>
        /// Default message time to live value. This is the duration after
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
        /// Value that indicates whether server-side batched operations are
        /// enabled..
        /// </summary>
        public bool? EnableBatchedOperations { get; set; }

        /// <summary>
        /// Value that indicates whether Express Entities are enabled. An
        /// express topic holds a message in memory temporarily before
        /// writing it to persistent storage.
        /// </summary>
        public bool? EnableExpress { get; set; }

        /// <summary>
        /// Value that indicates whether the topic to be partitioned across
        /// multiple message brokers is enabled.
        /// </summary>
        public bool? EnablePartitioning { get; set; }
                
        /// <summary>
        /// Maximum size of the topic in megabytes, which is the size of
        /// memory allocated for the topic.
        /// </summary>
        public int? MaxSizeInMegabytes { get; set; }

        /// <summary>
        /// Value indicating if this topic requires duplicate detection.
        /// </summary>
        public bool? RequiresDuplicateDetection { get; set; }

        /// <summary>
        /// Size of the topic in bytes.
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
        /// Number of subscriptions.
        /// </summary>
        public int? SubscriptionCount { get; set; }

        /// <summary>
        /// Value that indicates whether the topic supports ordering.
        /// </summary>
        public bool? SupportOrdering { get; set; }

        /// <summary>
        /// The exact time the message has been updated.
        /// </summary>
        
        public DateTime? UpdatedAt { get; set; }
        
    }
}
