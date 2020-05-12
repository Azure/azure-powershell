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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSMongoIndex
    {
        public PSMongoIndex()
        {
        }

        public PSMongoIndex(MongoIndex mongoIndex)
        {
            if (mongoIndex == null)
                return;

            Key = new PSMongoIndexKeys(mongoIndex.Key);
            Options = new PSMongoIndexOptions(mongoIndex.Options);
        }

        static public MongoIndex ToSDKModel(PSMongoIndex psMongoIndex)
        {
            if (psMongoIndex == null)
                return null;

            MongoIndex mongoIndex = new MongoIndex();

            if(psMongoIndex.Key != null)
            {
                mongoIndex.Key = PSMongoIndexKeys.ToSDKModel(psMongoIndex.Key);
            }
            
            if(psMongoIndex.Options != null)
            {
                mongoIndex.Options = PSMongoIndexOptions.ToSDKModel(psMongoIndex.Options);
            }

            return mongoIndex;
        }

        //
        // Summary:
        //     Gets or sets cosmos DB MongoDB collection index keys
        public PSMongoIndexKeys Key { get; set; }
        //
        // Summary:
        //     Gets or sets cosmos DB MongoDB collection index key options
        public PSMongoIndexOptions Options { get; set; }
    }
}