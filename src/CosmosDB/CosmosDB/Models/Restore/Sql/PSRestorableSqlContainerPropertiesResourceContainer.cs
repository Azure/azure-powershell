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

using Microsoft.Azure.Commands.CosmosDB.Models;

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableSqlContainerPropertiesResourceContainer
    {
        public PSRestorableSqlContainerPropertiesResourceContainer()
        {
        }

        public PSRestorableSqlContainerPropertiesResourceContainer(RestorableSqlContainerPropertiesResourceContainer restorableSqlContainerPropertiesResourceContainer)
        {
            if (restorableSqlContainerPropertiesResourceContainer == null)
            {
                return;
            }

            Id = restorableSqlContainerPropertiesResourceContainer.Id;
            IndexingPolicy = new PSIndexingPolicy(restorableSqlContainerPropertiesResourceContainer.IndexingPolicy);
            PartitionKey = new PSContainerPartitionKey(restorableSqlContainerPropertiesResourceContainer.PartitionKey);
            DefaultTtl = restorableSqlContainerPropertiesResourceContainer.DefaultTtl;
            UniqueKeyPolicy = new PSUniqueKeyPolicy(restorableSqlContainerPropertiesResourceContainer.UniqueKeyPolicy);
            ConflictResolutionPolicy = new PSConflictResolutionPolicy(restorableSqlContainerPropertiesResourceContainer.ConflictResolutionPolicy);
            this._rid = restorableSqlContainerPropertiesResourceContainer.Rid;
            this._ts = restorableSqlContainerPropertiesResourceContainer.Ts;
            this._etag = restorableSqlContainerPropertiesResourceContainer.Etag;
            this._self = restorableSqlContainerPropertiesResourceContainer.Self;
        }

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL container
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the indexing policy. By default,
        /// the indexing is automatic for all document paths within the
        /// container
        /// </summary>
        public PSIndexingPolicy IndexingPolicy { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the partition key to be used for
        /// partitioning data into multiple partitions
        /// </summary>
        public PSContainerPartitionKey PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets default time to live
        /// </summary>
        public int? DefaultTtl { get; set; }

        /// <summary>
        /// Gets or sets the unique key policy configuration for specifying
        /// uniqueness constraints on documents in the collection in the Azure
        /// Cosmos DB service.
        /// </summary>
        public PSUniqueKeyPolicy UniqueKeyPolicy { get; set; }

        /// <summary>
        /// Gets or sets the conflict resolution policy for the container.
        /// </summary>
        public PSConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        public string _rid { get; private set; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        public object _ts { get; private set; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        public string _etag { get; private set; }

        /// <summary>
        /// Gets a system generated property that specifies the addressable
        /// path of the container resource.
        /// </summary>
        public string _self { get; private set; }
    }
}
