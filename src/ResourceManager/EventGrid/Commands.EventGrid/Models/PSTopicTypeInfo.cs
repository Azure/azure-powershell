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
    public class PSTopicTypeInfo
    {
        public PSTopicTypeInfo(TopicTypeInfo topicTypeInfo)
        {
            this.TopicTypeName = topicTypeInfo.Name;
            this.Id = topicTypeInfo.Id;
            this.ProvisioningState = topicTypeInfo.ProvisioningState;
            this.Provider = topicTypeInfo.Provider;
            this.DisplayName = topicTypeInfo.DisplayName;
            this.Description = topicTypeInfo.Description;
            this.ResourceRegionType = topicTypeInfo.ResourceRegionType;
            this.SupportedLocations = topicTypeInfo.SupportedLocations;
        }

        public PSTopicTypeInfo(TopicTypeInfo topicTypeInfo, IEnumerable<EventType> eventTypes)
            : this(topicTypeInfo)
        {
            this.EventTypes = eventTypes;
        }

        public string TopicTypeName { get; set; }

        public string Id { get; set; }

        public string Provider { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string ResourceRegionType { get; set; }

        public string ProvisioningState { get; set; }

        public IEnumerable<EventType> EventTypes { get; set; }

        public IEnumerable<string> SupportedLocations { get; set; }

        /// <summary>
        /// Return a string representation of this topic
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
