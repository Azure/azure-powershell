﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSDomainTopic
    {
        public PSDomainTopic(DomainTopic domainTopic)
        {
            this.Id = domainTopic.Id;
            this.DomainName = this.GetDomainNameFromDomainTopic(domainTopic);
            this.DomainTopicName = domainTopic.Name;
            this.Type = domainTopic.Type;
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(domainTopic.Id);
            this.ProvisioningState = domainTopic.ProvisioningState;
        }

        public string ResourceGroupName { get; set; }

        public string DomainName { get; set; }

        public string DomainTopicName { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string ProvisioningState { get; set; }

        /// <summary>
        /// Return a string representation of this domain
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }

        string GetDomainNameFromDomainTopic(DomainTopic domainTopic)
        {
            string[] tokens = domainTopic.Id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 10)
            {
                return tokens[7];
            }
            else
            {
                throw new ArgumentException("Unsupported value for domainTopic Id.");
            }
        }
    }
}
