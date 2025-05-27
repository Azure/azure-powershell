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
    public class PSPhysicalPartitionStorageInfo
    {
        public PSPhysicalPartitionStorageInfo()
        {
        }

        public PSPhysicalPartitionStorageInfo(string id, double? storageInKB)
        {
            this.Id = id;
            this.StorageInKB = storageInKB;
        }

        public string Id { get; set; }


        public double? StorageInKB { get; set; }

        
    }
}