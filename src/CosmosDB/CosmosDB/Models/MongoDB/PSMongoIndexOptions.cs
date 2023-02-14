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
    public class PSMongoIndexOptions
    {
        public PSMongoIndexOptions()
        {
        }

        public PSMongoIndexOptions(MongoIndexOptions mongoIndexOptions)
        {
            if (mongoIndexOptions == null)
                return;

            ExpireAfterSeconds = mongoIndexOptions.ExpireAfterSeconds;
            Unique = mongoIndexOptions.Unique;
        }

        static public MongoIndexOptions ToSDKModel(PSMongoIndexOptions psMongoIndexOptions)
        {
            if(psMongoIndexOptions == null)
            {
                return null;
            }

            return new MongoIndexOptions
            {
                ExpireAfterSeconds = psMongoIndexOptions.ExpireAfterSeconds,
                Unique = psMongoIndexOptions.Unique
            };
        }

        //
        // Summary:
        //     Gets or sets expire after seconds
        public int? ExpireAfterSeconds { get; set; }
        //
        // Summary:
        //     Gets or sets is unique or not
        public bool? Unique { get; set; }
    }
}