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
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlContainerGetPropertiesResource 
    {
        public PSSqlContainerGetPropertiesResource()
        {
        }        
        
        public PSSqlContainerGetPropertiesResource(SqlContainerGetPropertiesResource sqlContainerGetPropertiesResource)
        {
            if (sqlContainerGetPropertiesResource == null)
            {
                return;
            }

            Id = sqlContainerGetPropertiesResource.Id;
            IndexingPolicy = new PSIndexingPolicy(sqlContainerGetPropertiesResource.IndexingPolicy);
            PartitionKey = new PSContainerPartitionKey(sqlContainerGetPropertiesResource.PartitionKey);
            DefaultTtl = sqlContainerGetPropertiesResource.DefaultTtl;
            UniqueKeyPolicy = new PSUniqueKeyPolicy(sqlContainerGetPropertiesResource.UniqueKeyPolicy);
            ConflictResolutionPolicy = new PSConflictResolutionPolicy(sqlContainerGetPropertiesResource.ConflictResolutionPolicy);
            AnalyticalStorageTtl = (int?)sqlContainerGetPropertiesResource.AnalyticalStorageTtl;
            _rid = sqlContainerGetPropertiesResource._rid;
            _ts = sqlContainerGetPropertiesResource._ts;
            _etag = sqlContainerGetPropertiesResource._etag;
        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB SQL container
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the indexing policy. By default, the indexing
        //     is automatic for all document paths within the container
        public PSIndexingPolicy IndexingPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the partition key to be used for partitioning
        //     data into multiple partitions
        public PSContainerPartitionKey PartitionKey { get; set; }
        //
        // Summary:
        //     Gets or sets default time to live
        public int? DefaultTtl { get; set; }
        //
        // Summary:
        //     Gets or sets the unique key policy configuration for specifying uniqueness constraints
        //     on documents in the collection in the Azure Cosmos DB service.
        public PSUniqueKeyPolicy UniqueKeyPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets the conflict resolution policy for the container.
        public PSConflictResolutionPolicy ConflictResolutionPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets analytical TTL.
        // int? since our Service defines it as int?
        public int? AnalyticalStorageTtl { get; set; }
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; }
    }
}
