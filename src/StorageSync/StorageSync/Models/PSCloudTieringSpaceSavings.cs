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
    /// Class PSCloudTieringSpaceSavings.
    /// </summary>
    public class PSCloudTieringSpaceSavings
    {
        /// <summary>
        /// Gets or sets the last updated timestamp.
        /// </summary>
        /// <value>The last updated timestamp.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the volume size.
        /// </summary>
        /// <value>The volume size.</value>
        public long? VolumeSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the estimated file share size.
        /// </summary>
        /// <value>The estimated file share size.</value>
        public long? TotalSizeCloudBytes { get; set; }

        /// <summary>
        /// Gets or sets the local cache size.
        /// </summary>
        /// <value>The local cache size.</value>
        public long? CachedSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the space savings percentage.
        /// </summary>
        /// <value>The space savings percentage.</value>
        public int? SpaceSavingsPercent { get; set; }

        /// <summary>
        /// Gets or sets the space savings in bytes.
        /// </summary>
        /// <value>The space savings in bytes.</value>
        public long? SpaceSavingsBytes { get; set; }
    }
}
