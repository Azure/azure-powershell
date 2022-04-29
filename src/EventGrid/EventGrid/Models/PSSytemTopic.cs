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
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSSystemTopic
    {
        public PSSystemTopic(SystemTopic topic)
        {
            this.Id = topic.Id;
            this.Identity = new PsIdentityInfo(topic.Identity);
            this.Location = topic.Location;
            this.MetricResourceId = topic.MetricResourceId;
            this.TopicName = topic.Name;
            this.ProvisioningState = topic.ProvisioningState;
            this.Source = topic.Source;
            this.Tags = topic.Tags;
            this.TopicType = topic.TopicType;
            this.Type = topic.Type;
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(topic.Id);

        }

        public string ResourceGroupName { get; set; }

        public string TopicName { get; set; }

        public string Id { get; set; }
        public PsIdentityInfo Identity { get; set; }
        public string Type { get; set; }

        public string Location { get; set; }
        public string MetricResourceId { get; set; }

        public string ProvisioningState { get; set; }
        public string Source { get; set; }

        public IDictionary<string, string> Tags { get; set; }
        public string TopicType { get; private set; }

    }
}
