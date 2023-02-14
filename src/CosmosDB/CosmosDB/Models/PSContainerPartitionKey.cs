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
    public class PSContainerPartitionKey
    {
        public PSContainerPartitionKey()
        {
        }

        public PSContainerPartitionKey(ContainerPartitionKey containerPartitionKey)
        {
            if (containerPartitionKey == null)
            {
                return;
            }

            Paths = containerPartitionKey.Paths;
            Kind = containerPartitionKey.Kind;
            Version = containerPartitionKey.Version;
        }

        //
        // Summary:
        //     Gets or sets list of paths using which data within the container can be partitioned
        public IList<string> Paths { get; set; }
        //
        // Summary:
        //     Gets or sets indicates the kind of algorithm used for partitioning. Possible
        //     values include: 'Hash', 'Range'
        public string Kind { get; set; }
        //
        // Summary:
        //     Gets or sets indicates the version of the partition key definition
        public int? Version { get; set; }
    }
}