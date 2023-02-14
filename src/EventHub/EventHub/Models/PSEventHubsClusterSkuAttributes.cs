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
    public class PSEventHubsClusterSkuAttributes
    {
        public PSEventHubsClusterSkuAttributes()
        {
            Name = "Dedicated";
        }

        public PSEventHubsClusterSkuAttributes(ClusterSku clusterSku)
        {
            if (clusterSku != null)
            {
                Capacity = clusterSku.Capacity;
                Name = "Dedicated";
            }
        }

        /// <summary>
        /// Gets or sets the quantity of Event Hubs Cluster Capacity Units
        /// contained in this cluster.
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Name of this SKU.
        /// </summary>
        public string Name { get; set; }
    }
}
