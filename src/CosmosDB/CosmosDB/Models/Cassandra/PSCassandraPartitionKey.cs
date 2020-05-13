﻿// ----------------------------------------------------------------------------------
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
    public class PSCassandraPartitionKey
    {
        public PSCassandraPartitionKey()
        {
        }

        public PSCassandraPartitionKey(CassandraPartitionKey cassandraPartitionKey)
        {
            if(cassandraPartitionKey == null)
            {
                return;
            }

            Name = cassandraPartitionKey.Name;
        }

        static public CassandraPartitionKey ToSDKModel(PSCassandraPartitionKey psCassandraPartitionKey)
        {
            if (psCassandraPartitionKey == null)
            {
                return null;
            }

            return new CassandraPartitionKey
            {
                Name = psCassandraPartitionKey.Name
            };
        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB Cassandra table partition key
        public string Name { get; set; }
    }
}