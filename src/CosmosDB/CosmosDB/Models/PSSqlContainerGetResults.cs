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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlContainerGetResults 
    {
        public PSSqlContainerGetResults()
        {
        }        
        
        public PSSqlContainerGetResults(SqlContainerGetResults sqlContainerGetResults)
        {
            Name = sqlContainerGetResults.Name;
            Id = sqlContainerGetResults.Id;
            SqlContainerGetResultsId = sqlContainerGetResults.SqlContainerGetResultsId;
            IndexingPolicy = sqlContainerGetResults.IndexingPolicy;
            PartitionKey = sqlContainerGetResults.PartitionKey;
            DefaultTtl = sqlContainerGetResults.DefaultTtl;
            UniqueKeyPolicy = sqlContainerGetResults.UniqueKeyPolicy;
            ConflictResolutionPolicy = sqlContainerGetResults.ConflictResolutionPolicy;
            _rid = sqlContainerGetResults._rid;
            _ts = sqlContainerGetResults._ts;
            _etag = sqlContainerGetResults._etag;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB SQL container
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL container
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL container
        /// </summary>
        public string SqlContainerGetResultsId { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the indexing policy. By default,
        /// the indexing is automatic for all document paths within the
        /// container
        /// </summary>
        public IndexingPolicy IndexingPolicy { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the partition key to be used for
        /// partitioning data into multiple partitions
        /// </summary>
        public ContainerPartitionKey PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets default time to live
        /// </summary>
        public int? DefaultTtl { get; set; }

        /// <summary>
        /// Gets or sets the unique key policy configuration for specifying
        /// uniqueness constraints on documents in the collection in the Azure
        /// Cosmos DB service.
        /// </summary>
        public UniqueKeyPolicy UniqueKeyPolicy { get; set; }

        /// <summary>
        /// Gets or sets the conflict resolution policy for the container.
        /// </summary>
        public ConflictResolutionPolicy ConflictResolutionPolicy { get; set; }

        /// <summary>
        /// Gets or sets a system generated property. A unique identifier.
        /// </summary>
        public string _rid { get; set; }

        /// <summary>
        /// Gets or sets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        public object _ts { get; set; }

        /// <summary>
        /// Gets or sets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        public string _etag { get; set; }
    }
}
