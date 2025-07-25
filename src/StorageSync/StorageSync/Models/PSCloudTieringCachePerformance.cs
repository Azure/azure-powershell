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

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    using System;

    /// <summary>
    /// Class PSCloudTieringCachePerformance.
    /// </summary>
    public class PSCloudTieringCachePerformance
    {
        /// <summary>
        /// Gets or sets the last updated timestamp.
        /// </summary>
        /// <value>The name of the sync group.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the count of bytes served locally from the cache.
        /// </summary>
        /// <value>The count of bytes served locally from the cache.</value>
        public long? CacheHitBytes { get; set; }

        /// <summary>
        /// Gets or sets the count of bytes served from recall.
        /// </summary>
        /// <value>The count of bytes served from recall.</value>
        public long? CacheMissBytes { get; set; }

        /// <summary>
        /// Gets or sets the cache hit percentage.
        /// </summary>
        /// <value>The cache hit percentage.</value>
        public int? CacheHitBytesPercent { get; set; }
    }
}
