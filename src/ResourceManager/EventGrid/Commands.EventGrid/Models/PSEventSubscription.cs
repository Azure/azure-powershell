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

using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSEventSubscription
    {
        readonly DeadLetterDestination deadletterDestination;
        public PSEventSubscription(EventSubscription eventSubscription)
        {
            this.Id = eventSubscription.Id;
            this.EventSubscriptionName = eventSubscription.Name;
            this.Type = eventSubscription.Type;
            this.ProvisioningState = eventSubscription.ProvisioningState;
            this.Destination = eventSubscription.Destination;
            this.Filter = eventSubscription.Filter;
            this.Labels = eventSubscription.Labels;
            this.Topic = eventSubscription.Topic;
            this.EventTtl = eventSubscription.RetryPolicy?.EventTimeToLiveInMinutes;
            this.MaxDeliveryAttempts = eventSubscription.RetryPolicy?.MaxDeliveryAttempts;
            this.EventDeliverySchema = eventSubscription.EventDeliverySchema;
            this.deadletterDestination = eventSubscription.DeadLetterDestination;
        }

        public PSEventSubscription(EventSubscription eventSubscription, string fullEndpointUrl)
            : this(eventSubscription)
        {
            var webhookDestination = eventSubscription.Destination as WebHookEventSubscriptionDestination;
            if (webhookDestination != null)
            {
                webhookDestination.EndpointUrl = fullEndpointUrl;
            }
        }

        public string EventSubscriptionName { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Topic { get; set; }

        public EventSubscriptionFilter Filter { get; set; }

        public EventSubscriptionDestination Destination { get; set; }

        public string ProvisioningState { get; set; }

        public IList<string> Labels { get; set; }

        public int? EventTtl { get; set; }

        public int? MaxDeliveryAttempts { get; set; }

        public string EventDeliverySchema { get; set; }

        public string DeadLetterEndpoint
        {
            get
            {
                var blobStorageDeadletterEndPoint = this.deadletterDestination as StorageBlobDeadLetterDestination;
                if (blobStorageDeadletterEndPoint != null)
                {
                    return $"{blobStorageDeadletterEndPoint.ResourceId}/blobServices/default/containers/{blobStorageDeadletterEndPoint.BlobContainerName}";
                }

                return null;
            }
        }

        public string Endpoint
        {
            get
            {
                var webhookDestination = this.Destination as WebHookEventSubscriptionDestination;
                if (webhookDestination != null)
                {
                    if (webhookDestination.EndpointUrl != null)
                    {
                        return webhookDestination.EndpointUrl;
                    }

                    return webhookDestination.EndpointBaseUrl;
                }

                var eventHubDestination = this.Destination as EventHubEventSubscriptionDestination;
                if (eventHubDestination != null)
                {
                    return eventHubDestination.ResourceId;
                }

                var storageQueueDestination = this.Destination as StorageQueueEventSubscriptionDestination;
                if (storageQueueDestination != null)
                {
                    return $"{storageQueueDestination.ResourceId}/queueServices/default/queues/{storageQueueDestination.QueueName}";
                }

                var hybridConnDestination = this.Destination as HybridConnectionEventSubscriptionDestination;
                if (hybridConnDestination != null)
                {
                    return hybridConnDestination.ResourceId;
                }

                return null;
            }
        }

        /// <summary>
        /// Return a string representation of this event subscription
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
