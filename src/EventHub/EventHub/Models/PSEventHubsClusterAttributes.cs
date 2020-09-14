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

namespace Microsoft.Azure.Commands.EventHub.Models
{
    public class PSEventHubClusterAttributes
    {
        public PSEventHubClusterAttributes()
        {
            Sku = new PSEventHubsClusterSkuAttributes();
        }

        public PSEventHubClusterAttributes(Cluster cluster)
        {
            if (cluster != null)
            {
                Id = cluster.Id;
                Name = cluster.Name;
                Location = cluster.Location;
                CreatedAt = cluster.CreatedAt;
                UpdatedAt = cluster.UpdatedAt;
                Status = cluster.Status;
                Sku = new PSEventHubsClusterSkuAttributes(cluster.Sku);
                if (cluster.Tags.Count > 0)
                {
                    Tags = new Dictionary<string, string>(cluster.Tags);
                }
            }
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Exact time the cluster was created.
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// Exact time the cluster was UpdatedAt.
        /// </summary>
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Gets the metric ID of the cluster resource. Provided by the service
        /// and not modifiable by the user.
        /// </summary>
        public string MetricId { get; set; }

        /// <summary>
        /// Gets status of the Cluster resource
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets properties of the cluster SKU.
        /// </summary>
        public PSEventHubsClusterSkuAttributes Sku { get; set; }

        public Dictionary<string, string> Tags = new Dictionary<string, string>();
    }
}
