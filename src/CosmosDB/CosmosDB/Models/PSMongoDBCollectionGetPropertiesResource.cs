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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSMongoDBCollectionGetPropertiesResource
    {
        public PSMongoDBCollectionGetPropertiesResource(MongoDBCollectionGetPropertiesResource mongoDBCollectionGetPropertiesResource)
        {
            Id = mongoDBCollectionGetPropertiesResource.Id;
            if (mongoDBCollectionGetPropertiesResource.ShardKey != null)
            {
                ShardKey = new Dictionary<string, string>(mongoDBCollectionGetPropertiesResource.ShardKey);
            }
            List<PSMongoIndex> psMongoIndex = new List<PSMongoIndex>();
            if (mongoDBCollectionGetPropertiesResource.Indexes != null)
            {
                foreach (MongoIndex mongoIndex in mongoDBCollectionGetPropertiesResource.Indexes)
                {
                    psMongoIndex.Add(new PSMongoIndex(mongoIndex));
                }
            }

            Indexes = psMongoIndex;
            _rid = mongoDBCollectionGetPropertiesResource._rid;
            _ts = mongoDBCollectionGetPropertiesResource._ts;
            _etag = mongoDBCollectionGetPropertiesResource._etag;
        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB MongoDB collection
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets a key-value pair of shard keys to be applied for the request.
        public IDictionary<string, string> ShardKey { get; set; }
        //
        // Summary:
        //     Gets or sets list of index keys
        public IList<PSMongoIndex> Indexes { get; set; }
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