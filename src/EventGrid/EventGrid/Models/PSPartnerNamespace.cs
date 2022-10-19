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
    public class PSPartnerNamespace
    {
        public PSPartnerNamespace(PartnerNamespace partnerNamespace)
        {
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(partnerNamespace.Id);
            this.PartnerNamespaceName = partnerNamespace.Name;
            this.Id = partnerNamespace.Id;
            this.ProvisioningState = partnerNamespace.ProvisioningState;
            this.PartnerRegistrationFullyQualifiedId = partnerNamespace.PartnerRegistrationFullyQualifiedId;
            this.Endpoint = partnerNamespace.Endpoint;
            this.PublicNetworkAccess = partnerNamespace.PublicNetworkAccess;
            this.DisableLocalAuth = partnerNamespace.DisableLocalAuth;
            this.PartnerTopicRoutingMode = partnerNamespace.PartnerTopicRoutingMode;

            if (partnerNamespace.PrivateEndpointConnections != null)
            {
                foreach (PrivateEndpointConnection privateEndpointConnection in partnerNamespace.PrivateEndpointConnections)
                {
                    this.PrivateEndpointConnections.Add(new PSPrivateEndpointConnection(privateEndpointConnection));
                }
            }

            if (partnerNamespace.InboundIpRules != null)
            {
                foreach (InboundIpRule inboundIpRule in partnerNamespace.InboundIpRules)
                {
                    this.InboundIpRules.Add(new PSInboundIpRule(inboundIpRule));
                }
            }
        }

        public string ResourceGroupName { get; set; }

        public string PartnerNamespaceName { get; set; }

        public string Id { get; set; }

        public IList<PSPrivateEndpointConnection> PrivateEndpointConnections { get; private set; }

        public string ProvisioningState { get; private set; }

        public string PartnerRegistrationFullyQualifiedId { get; set; }

        public string Endpoint { get; private set; }

        public string PublicNetworkAccess { get; set; }

        public IList<PSInboundIpRule> InboundIpRules { get; set; }

        public bool? DisableLocalAuth { get; set; }

        public string PartnerTopicRoutingMode { get; set; }

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
