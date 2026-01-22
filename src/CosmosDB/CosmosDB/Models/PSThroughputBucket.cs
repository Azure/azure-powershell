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
    public class PSThroughputBucket
    {
        public int Id { get; set; }
        public int MaxThroughputPercentage { get; set; }
        public bool? IsDefaultBucket { get; set; }

        public PSThroughputBucket(int id, int maxThroughputPercentage, bool? isDefaultBucket = null)
        {
            Id = id;
            MaxThroughputPercentage = maxThroughputPercentage;
            IsDefaultBucket = isDefaultBucket;
        }

        public PSThroughputBucket(ThroughputBucketResource throughputBucketResource)
        {
            if (throughputBucketResource == null)
                return;
            Id = throughputBucketResource.Id;
            MaxThroughputPercentage = throughputBucketResource.MaxThroughputPercentage;
            IsDefaultBucket = throughputBucketResource.IsDefaultBucket;
        }
    }
}
