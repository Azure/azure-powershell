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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSClusterKey
    {
        public PSClusterKey()
        {
        }

        public PSClusterKey(ClusterKey clusterKey)
        {
            if(clusterKey == null)
            {
                return;
            }

            Name = clusterKey.Name;
            OrderBy = clusterKey.OrderBy;
        }

        static public ClusterKey ToSDKModel(PSClusterKey psClusterKey)
        {
            if (psClusterKey == null)
            {
                return null;
            }

            return new ClusterKey
            {
                Name = psClusterKey.Name,
                OrderBy = psClusterKey.OrderBy
            };
        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB Cassandra table cluster key
        public string Name { get; set; }
        //
        // Summary:
        //     Gets or sets order of the Cosmos DB Cassandra table cluster key, only support
        //     "Asc" and "Desc"
        public string OrderBy { get; set; }
    }
}