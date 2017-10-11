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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.IotHub.Models;
    using Newtonsoft.Json;

    public class PSRoutingEndpoints
    {
        /// <summary>
        /// The list of service bus queue endpoints to which IoT hub routes
        /// the messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusQueues")]
        public IList<PSRoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get; set; }

        /// <summary>
        /// The list of service bus topic endpoints to which IoT hub routes
        /// the messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusTopics")]
        public IList<PSRoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get; set; }

        /// <summary>
        /// The list of eventhub endpoints to which IoT hub routes the
        /// messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "eventHubs")]
        public IList<PSRoutingEventHubProperties> EventHubs { get; set; }
    }
}
