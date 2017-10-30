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

    public class SubscriptionAttributes
    {
        public SubscriptionAttributes()
        { }

        public SubscriptionAttributes(SBSubscription subscriptionResource)
        {
            if (subscriptionResource != null)
            {                
                AccessedAt = subscriptionResource.AccessedAt;
                AutoDeleteOnIdle = XmlConvert.ToString((TimeSpan)subscriptionResource.AutoDeleteOnIdle);
                DefaultMessageTimeToLive = XmlConvert.ToString((TimeSpan)subscriptionResource.DefaultMessageTimeToLive);
                LockDuration = XmlConvert.ToString((TimeSpan)subscriptionResource.LockDuration);
                CountDetails = subscriptionResource.CountDetails;
                CreatedAt = subscriptionResource.CreatedAt;
                DeadLetteringOnMessageExpiration = subscriptionResource.DeadLetteringOnMessageExpiration;
                EnableBatchedOperations = subscriptionResource.EnableBatchedOperations;
                MaxDeliveryCount = subscriptionResource.MaxDeliveryCount;
                MessageCount = subscriptionResource.MessageCount;
                RequiresSession = subscriptionResource.RequiresSession;
                Status = subscriptionResource.Status;
                UpdatedAt = subscriptionResource.UpdatedAt;
                Name = subscriptionResource.Name;
            }
        }


        /// <summary>
        /// Queue name.
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// Last time a there was a receive request to this subscription.
        /// </summary>
        public DateTime? AccessedAt { get; set; }        
        
        /// <summary>
        /// TimeSpan idle interval after which the topic is automatically
        /// deleted. The minimum duration is 5 minutes.
        /// </summary>
        public string AutoDeleteOnIdle { get; set; }

        /// <summary>
        /// </summary>
        public MessageCountDetails CountDetails { get; set; }

        /// <summary>
        /// Exact time the message was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Default message time to live value. This is the duration after
        /// which the message expires, starting from when the message is sent
        /// to Service Bus. This is the default value used when TimeToLive is
        /// not set on a message itself.
        /// </summary>
        public string DefaultMessageTimeToLive { get; set; }
                
        /// <summary>
        /// Value that indicates if a subscription has dead letter support
        /// when a message expires.
        /// </summary>
        public bool? DeadLetteringOnMessageExpiration { get; set; }

        /// <summary>
        /// Value that indicates whether server-side batched operations are
        /// enabled..
        /// </summary>
        public bool? EnableBatchedOperations { get; set; }

        /// <summary>
        /// The lock duration time span for the subscription.
        /// </summary>
        public string LockDuration { get; set; }

        /// <summary>
        /// Number of maximum deliveries.
        /// </summary>
        public int? MaxDeliveryCount { get; set; }

        /// <summary>
        /// Number of messages.
        /// </summary>
        public long? MessageCount { get; set; }

        /// <summary>
        /// Value indicating if a subscription supports the concept of session.
        /// </summary>
        public bool? RequiresSession { get; set; }

        /// <summary>
        /// Enumerates the possible values for the status of a messaging
        /// entity. Possible values include: 'Active', 'Creating',
        /// 'Deleting', 'Disabled', 'ReceiveDisabled', 'Renaming',
        /// 'Restoring', 'SendDisabled', 'Unknown'
        /// </summary>
        public EntityStatus? Status { get; set; }

        /// <summary>
        /// The exact time the message has been updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }        
    }
}
