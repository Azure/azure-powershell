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
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    /// <summary>
    /// Represents the properties of a Namespace of type EventHub
    /// </summary>
    public class NamespaceAttributes
    {
        public NamespaceAttributes(NamespaceResource evResource)
        {
            if (evResource != null)
            {
                Sku = evResource.Sku;
                ProvisioningState = evResource.ProvisioningState;
                Status = (Microsoft.Azure.Commands.EventHub.Models.NamespaceState)evResource.Status;
                CreatedAt = evResource.CreatedAt;
                UpdatedAt = evResource.UpdatedAt;
                ServiceBusEndpoint = evResource.ServiceBusEndpoint;               
                Enabled = evResource.Enabled;
                Location = evResource.Location;
                
            }
        }
        
        /// <summary>
        /// Gets or sets the name of the resource group the Namespace is in
        /// </summary>
        public string ResourceGroupName { get; set; }

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
        public Sku Sku { get; set; }

        /// <summary>
        /// Provisioning state of the Namespace.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// State of the namespace. Possible values include: 'Unknown',
        /// 'Creating', 'Created', 'Activating', 'Enabling', 'Active',
        /// 'Disabling', 'Disabled', 'SoftDeleting', 'SoftDeleted',
        /// 'Removing', 'Removed', 'Failed'
        /// </summary>
        public Models.NamespaceState? Status { get; set; }

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
        /// Specifies whether this instance is enabled.
        /// </summary>
        public bool? Enabled { get; set; }
    }
}
