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

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSThroughput
    {
        public PSThroughput()
        {
        }        

        public PSThroughput(ThroughputInner throughputInner)
        {
            ThroughputProperty = throughputInner.ThroughputProperty;
        }

        //
        // Summary:
        //     Gets or sets value of the Cosmos DB resource throughput
        public int ThroughputProperty { get; set; }
    }
}