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

using Microsoft.Azure.Management.NotificationHubs.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.NotificationHubs.Models
{

    /// <summary>
    /// Represents the properties of a Namespace of type NotificationHub
    /// </summary>
    public class NamespaceAttributes
    {
        private static readonly Regex ResourceGroupRegex = new Regex(@"/resourceGroups/(?<resourceGroupName>.+)/providers/", RegexOptions.Compiled);

        public NamespaceAttributes(string resourceGroup, NamespaceResource nsResource)
            : this(nsResource)
        {
            if (nsResource != null)
            {
                ResourceGroupName = resourceGroup;

                if (!string.IsNullOrWhiteSpace(nsResource.Id))
                {
                    var match = ResourceGroupRegex.Match(Id);
                    if (match.Success)
                    {
                        var resourceGroupNameGroup = match.Groups["resourceGroupName"];
                        if (resourceGroupNameGroup != null && resourceGroupNameGroup.Success)
                        {
                            ResourceGroupName = resourceGroupNameGroup.Value;
                        }
                    }
                }
            }
        }

        public NamespaceAttributes(NamespaceResource nsResource)
        {
            if (nsResource != null)
            {
                Id = nsResource.Id;
                Name = nsResource.Name;
                Type = nsResource.Type;
                Location = nsResource.Location;
                Tags = new Dictionary<string, string>(nsResource.Tags);
                CreatedAt = nsResource.Properties.CreatedAt;
                Critical = nsResource.Properties.Critical;
                Enabled = nsResource.Properties.Enabled;
                NamespaceType = nsResource.Properties.NamespaceType;
                ProvisioningState = nsResource.Properties.ProvisioningState;
                Region = nsResource.Properties.Region;
                ScaleUnit = nsResource.Properties.ScaleUnit;
                ServiceBusEndpoint = nsResource.Properties.ServiceBusEndpoint;
                Status = nsResource.Properties.Status;
                SubscriptionId = nsResource.Properties.SubscriptionId;
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
        /// Gets or sets the Type of the Namespace
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the Namespace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location the Namespace is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Namespace.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// The time the namespace was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Whether or not the namespace is set as Critical.
        /// </summary>
        public bool Critical { get; set; }

        /// <summary>
        /// Whether or not the namespace is currently enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the namespace type.
        /// </summary>
        public NamespaceType NamespaceType { get; internal set; }

        /// <summary>
        /// Gets or sets provisioning state of the Namespace.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Specifies the targeted region in which the namespace
        /// should be created. 
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        ///  ScaleUnit where the namespace gets created
        /// </summary>
        public string ScaleUnit { get; set; }

        /// <summary>
        /// Endpoint you can use to perform NotificationHub
        /// operations. 
        /// </summary>
        public Uri ServiceBusEndpoint { get; set; }

        /// <summary>
        ///  Status of the namespace.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The Id of the Azure subscription associated with the
        /// namespace.
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}
