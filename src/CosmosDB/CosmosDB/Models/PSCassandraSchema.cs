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
    public class PSCassandraSchema
    {
        public PSCassandraSchema()
        {
        }

        public PSCassandraSchema(CassandraSchema cassandraSchema)
        {
            Columns = new List<PSColumn>();
            foreach (Column column in cassandraSchema.Columns)
            {
                Columns.Add(new PSColumn(column));
            }

            PartitionKeys = new List<PSCassandraPartitionKey>();
            foreach (CassandraPartitionKey cassandraPartitionKey in cassandraSchema.PartitionKeys)
            {
                PartitionKeys.Add(new PSCassandraPartitionKey(cassandraPartitionKey));
            }

            ClusterKeys = new List<PSClusterKey>();
            foreach (ClusterKey clusterKey in cassandraSchema.ClusterKeys)
            {
                ClusterKeys.Add(new PSClusterKey(clusterKey));
            }
        }

        //
        // Summary:
        //     Gets or sets list of Cassandra table columns.
        public IList<PSColumn> Columns { get; set; }
        //
        // Summary:
        //     Gets or sets list of partition key.
        public IList<PSCassandraPartitionKey> PartitionKeys { get; set; }
        //
        // Summary:
        //     Gets or sets list of cluster key.
        public IList<PSClusterKey> ClusterKeys { get; set; }

        static public CassandraSchema ConvertPSCassandraSchemaToCassandraSchema(PSCassandraSchema pSCassandraSchema)
        {
            List<Column> column = new List<Column>();
            foreach (PSColumn pSColumn in pSCassandraSchema.Columns)
            {
                column.Add(PSColumn.ConvertPSColumnToColumn(pSColumn));
            }

            List<CassandraPartitionKey> partitionKeys = new List<CassandraPartitionKey>();
            foreach (PSCassandraPartitionKey pSCassandraPartitionKey in pSCassandraSchema.PartitionKeys)
            {
                partitionKeys.Add(PSCassandraPartitionKey.ConvertPSCassandraPartitionKeyToCassandraPartitionKey(pSCassandraPartitionKey));
            }

            List<ClusterKey> clusterKeys = new List<ClusterKey>();
            foreach (PSClusterKey pSClusterKey in pSCassandraSchema.ClusterKeys)
            {
                clusterKeys.Add(PSClusterKey.ConvertPSCassandraSchemaToCassandraSchema(pSClusterKey));
            }

            return new CassandraSchema
            {
                Columns = column,
                PartitionKeys = partitionKeys,
                ClusterKeys = clusterKeys
            };
        }
    }
}