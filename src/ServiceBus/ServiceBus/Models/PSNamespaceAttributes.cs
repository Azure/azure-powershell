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

using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    /// <summary>
    /// Represents the properties of a Namespace of type ServiceBus
    /// </summary>
    public class PSNamespaceAttributes 
    {
        public PSNamespaceAttributes()
        { }

        public PSNamespaceAttributes(SBNamespace evResource)
        {
            if (evResource != null)
            {
                Sku = new SBSku { Capacity = evResource.Sku.Capacity,
                                Name = evResource.Sku.Name,
                                Tier = evResource.Sku.Tier};
                
                if(evResource.ProvisioningState != null)
                    ProvisioningState = evResource.ProvisioningState;                
                
                if(evResource.CreatedAt.HasValue)
                    CreatedAt = evResource.CreatedAt;
                
                if(evResource.UpdatedAt.HasValue)
                    UpdatedAt = evResource.UpdatedAt;
                
                if(evResource.ServiceBusEndpoint != null)
                    ServiceBusEndpoint = evResource.ServiceBusEndpoint;
                
                if(evResource.Location != null)
                    Location = evResource.Location;
                
                if(evResource.Name != null)
                    Name = evResource.Name;
                
                if(evResource.Id != null)
                    Id = evResource.Id;

                if(evResource.Identity != null)
                {
                    Identity = new PSIdentityAttributes(evResource.Identity);

                    IdentityType = evResource.Identity.Type.ToString();
                    
                    if(evResource.Identity.UserAssignedIdentities != null)
                        IdentityId = evResource.Identity.UserAssignedIdentities.Keys.ToArray();
                }
                    
                
                if(evResource.Encryption != null)
                {

                    if(evResource.Encryption.KeyVaultProperties != null)
                    {
                        EncryptionConfig = evResource.Encryption.KeyVaultProperties.Where(x => x != null).Select(x => {

                            PSEncryptionConfigAttributes kvproperty = new PSEncryptionConfigAttributes(x);

                            return kvproperty;
                        }).ToArray();
                    }
                }

                if (evResource.PrivateEndpointConnections != null)
                {
                    PrivateEndpointConnections = evResource.PrivateEndpointConnections.Where(x => x != null).Select(x => new PSServiceBusPrivateEndpointConnectionAttributes(x)).ToArray();
                }


                if (evResource.Tags != null)
                {
                    var tagDictionary = new Dictionary<string, string>(evResource.Tags);
                    Tag = new Hashtable(tagDictionary);
                }
                
                ResourceGroup = Regex.Split(evResource.Id, @"/")[4];
                ResourceGroupName = Regex.Split(evResource.Id, @"/")[4];
                Tags = new Dictionary<string, string>(evResource.Tags);
                if(evResource.ZoneRedundant!=null)
                ZoneRedundant = evResource.ZoneRedundant;
                DisableLocalAuth = evResource.DisableLocalAuth;
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
        /// Gets or sets the name of the resource group the Namespace is in
        /// </summary>
        public string Name { get; set; }       

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// </summary>
        public SBSku Sku { get; set; }

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

        public Dictionary<string, string> Tags = new Dictionary<string, string>();

        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets enabling this property creates a Premium Service Bus
        /// Namespace in regions supported availability zones.
        /// </summary>
        public bool? ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets this property disables SAS authentication for the
        /// Service Bus namespace.
        /// </summary>
        public bool? DisableLocalAuth { get; set; }

        public PSIdentityAttributes Identity { get; set; }

        public string IdentityType { get; set; }

        public string[] IdentityId { get; set; }

        public PSEncryptionConfigAttributes[] EncryptionConfig { get; set; }

        public PSServiceBusPrivateEndpointConnectionAttributes[] PrivateEndpointConnections { get; set; }
    }
}
