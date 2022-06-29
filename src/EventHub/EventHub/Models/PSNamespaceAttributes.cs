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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    /// <summary>
    /// Represents the properties of a Namespace of type EventHub
    /// </summary>
    public class PSNamespaceAttributes
    {
        public PSNamespaceAttributes(EHNamespace evResource)
        {
            if (evResource != null)
            {
                Sku = new Sku
                {
                    Capacity = evResource.Sku.Capacity,
                    Name = evResource.Sku.Name,
                    Tier = evResource.Sku.Tier
                };

                if (evResource.ProvisioningState != null)
                    ProvisioningState = evResource.ProvisioningState;

                if (evResource.CreatedAt.HasValue)
                    CreatedAt = evResource.CreatedAt;

                if(evResource.UpdatedAt.HasValue)
                    UpdatedAt = evResource.UpdatedAt;

                if(evResource.ServiceBusEndpoint != null)
                    ServiceBusEndpoint = evResource.ServiceBusEndpoint;
                if (evResource.Location != null)
                    Location = evResource.Location;

                if(evResource.Id != null)
                    Id = evResource.Id;

                if (evResource.Name != null)
                    Name = evResource.Name;

                if (evResource.IsAutoInflateEnabled.HasValue)
                    IsAutoInflateEnabled = evResource.IsAutoInflateEnabled;

                if (evResource.MaximumThroughputUnits.HasValue)
                    MaximumThroughputUnits = evResource.MaximumThroughputUnits;

                if (evResource.KafkaEnabled.HasValue)
                   KafkaEnabled = evResource.KafkaEnabled;

                if(evResource.Tags.Count > 0)
                    Tags = new Dictionary<string, string>(evResource.Tags);

                if (evResource.Identity != null)
                {
                    Identity = new PSIdentityAttributes(evResource.Identity);

                    IdentityType = evResource.Identity.Type.ToString();

                    if (evResource.Identity.UserAssignedIdentities != null)
                        IdentityId = evResource.Identity.UserAssignedIdentities.Keys.ToArray();
                }


                if (evResource.Encryption != null)
                {

                    if (evResource.Encryption.KeyVaultProperties != null)
                    {
                        EncryptionConfig = evResource.Encryption.KeyVaultProperties.Where(x => x != null).Select(x => {

                            PSEncryptionConfigAttributes kvproperty = new PSEncryptionConfigAttributes(x);

                            return kvproperty;
                        }).ToArray();
                    }
                }

                if (evResource.PrivateEndpointConnections != null)
                {
                    PrivateEndpointConnections = evResource.PrivateEndpointConnections.Where(x => x != null).Select(x => new PSEventHubPrivateEndpointConnectionAttributes(x)).ToArray();
                }

                ResourceGroup = Regex.Split(evResource.Id, @"/")[4];
                ResourceGroupName = Regex.Split(evResource.Id, @"/")[4];
                ZoneRedundant = evResource.ZoneRedundant;
                DisableLocalAuth = evResource.DisableLocalAuth;
                ClusterArmId = evResource.ClusterArmId;
                Encryption = new PSEncryptionAttributes(evResource.Encryption);
            }
        }
        
        /// <summary>
        /// Gets the resourcegroup name
        /// </summary>
        public string ResourceGroup { get; }

        /// <summary>
        /// Gets the resourcegroup name
        /// </summary>
        public string ResourceGroupName { get; }


        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Namespace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Provisioning state of the Namespace.
        /// </summary>
        public string ProvisioningState { get; set; }
                
        /// <summary>
        /// The time the namespace was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The time the namespace was updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Endpoint you can use to perform ServiceBus operations.
        /// </summary>
        public string ServiceBusEndpoint { get; set; }
        
        /// <summary>
        /// Gets or sets value that indicates whether AutoInflate is enabled
        /// for eventhub namespace.
        /// </summary>
        public bool? IsAutoInflateEnabled { get; set; }

        /// <summary>
        /// Gets or sets upper limit of throughput units when AutoInflate is
        /// enabled, vaule should be within 0 to 20 throughput units. ( '0' if
        /// AutoInflateEnabled = true)
        /// </summary>
        public int? MaximumThroughputUnits { get; set; }

        /// <summary>
        /// Gets or sets value that indicates whether Kafka is enabled for
        /// eventhub namespace.
        /// </summary>
        public bool? KafkaEnabled { get; set; }

        public bool? ZoneRedundant { get; set; }

        public string ClusterArmId { get; set; }
        
        public PSIdentityAttributes Identity { get; set; }

        public PSEncryptionAttributes Encryption { get; set; }

        public Dictionary<string, string> Tags = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets this property disables SAS authentication for the
        /// Service Bus namespace.
        /// </summary>
        public bool? DisableLocalAuth { get; set; }

        public string IdentityType { get; set; }

        public string[] IdentityId { get; set; }

        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }

        public PSEventHubPrivateEndpointConnectionAttributes[] PrivateEndpointConnections { get; set; }
    }
}
