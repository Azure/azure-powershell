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

using Microsoft.Azure.Management.EventGrid.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSEventSubscriptionListPagedInstance
    {
        public List<PSEventSubscriptionListInstance> PsEventSubscriptionsList = new List<PSEventSubscriptionListInstance>();
        public string NextLink;

        public PSEventSubscriptionListPagedInstance(
            IEnumerable<EventSubscription> eventSubscriptionsList,
            EventGridClient client,
            bool includeFullEndpointUrl,
            string nextLink)
        {
            foreach (EventSubscription eventSubscription in eventSubscriptionsList)
            {
                PSEventSubscriptionListInstance psEventSubscription;

                if (includeFullEndpointUrl && eventSubscription.Destination is WebHookEventSubscriptionDestination)
                {
                    EventSubscriptionFullUrl fullUrl = client.GetEventSubscriptionFullUrl(eventSubscription.Topic, eventSubscription.Name);
                    psEventSubscription = new PSEventSubscriptionListInstance(eventSubscription, fullUrl.EndpointUrl);
                }
                else
                {
                    psEventSubscription = new PSEventSubscriptionListInstance(eventSubscription);
                }

                this.PsEventSubscriptionsList.Add(psEventSubscription);
            }

            this.NextLink = nextLink;
        }
    }
}
