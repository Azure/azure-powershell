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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSPartnerTopic
    {
        public PSPartnerTopic(PartnerTopic topic)
        {
            this.Id = topic.Id;
            this.Identity = new PsIdentityInfo(topic.Identity);
            this.Location = topic.Location;
            this.Name = topic.Name;
            this.ProvisioningState = topic.ProvisioningState;
            this.Source = topic.Source;
            this.Tags = topic.Tags;
            this.Type = topic.Type;
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(topic.Id);
            this.ExpirationTimeIfNotActivatedUtc = topic.ExpirationTimeIfNotActivatedUtc;
            this.PartnerRegistrationImmutableId = topic.PartnerRegistrationImmutableId;
            this.PartnerTopicFriendlyDescription = topic.PartnerTopicFriendlyDescription;
            this.MessageForActivation = topic.MessageForActivation;
            this.EventTypeInfo = topic.EventTypeInfo;
            this.ActivationState = topic.ActivationState;
        }

        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public PsIdentityInfo Identity { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string ProvisioningState { get; set; }

        public string Source { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public EventTypeInfo EventTypeInfo { get; set; }

        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        public Guid? PartnerRegistrationImmutableId { get; set; }

        public string PartnerTopicFriendlyDescription { get; set; }

        public string MessageForActivation { get; set; }

        public string ActivationState { get; set; }
    }
}
