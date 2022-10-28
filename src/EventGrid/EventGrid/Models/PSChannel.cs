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

using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSChannel
    {
        public PSChannel(Channel channel)
        {
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(channel.Id);
            this.PartnerNamespaceName = EventGridUtils.ParsePartnerNamespaceNameFromId(channel.Id);
            this.Name = channel.Name;
            this.Id = channel.Id;
            this.ProvisioningState = channel.ProvisioningState;
            this.ChannelType = channel.ChannelType;
            this.PartnerTopicInfo = new PSPartnerTopicInfo(channel.PartnerTopicInfo);
            this.MessageForActivation = channel.MessageForActivation;
            this.ReadinessState = channel.ReadinessState;
            this.ExpirationTimeIfNotActivatedUtc = channel.ExpirationTimeIfNotActivatedUtc;
        }

        public string ResourceGroupName { get; set; }

        public string PartnerNamespaceName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string ChannelType { get; set; }

        public PSPartnerTopicInfo PartnerTopicInfo { get; set; }

        public string MessageForActivation { get; set; }

        public string ProvisioningState { get; set; }

        public string ReadinessState { get; set; }

        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        /// <summary>
        /// Return a string representation of this partner Namespace
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
