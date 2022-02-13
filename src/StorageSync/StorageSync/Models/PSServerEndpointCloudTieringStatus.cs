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
    /// Class PSServerEndpointCloudTieringStatus.
    /// </summary>
    public class PSServerEndpointCloudTieringStatus
    {
        /// <summary>
        /// Gets or sets the last updated timestamp.
        /// </summary>
        /// <value>The last updated timestamp.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the health state.
        /// </summary>
        /// <value>The health state.</value>
        public string Health { get; set; }

        /// <summary>
        /// Gets or sets the health last updated timestamp.
        /// </summary>
        /// <value>The health last updated timestamp.</value>
        public DateTime? HealthLastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the last cloud tiering result.
        /// </summary>
        /// <value>The last cloud tiering result.</value>
        public int? LastCloudTieringResult { get; set; }

        /// <summary>
        /// Gets or sets the last cloud tiering success timestamp.
        /// </summary>
        /// <value>The last cloud tiering success timestamp.</value>
        public DateTime? LastSuccessTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the space savings details.
        /// </summary>
        /// <value>The space savings details.</value>
        public PSCloudTieringSpaceSavings SpaceSavings { get; set; }

        /// <summary>
        /// Gets or sets the cache performance details.
        /// </summary>
        /// <value>The cache performance details.</value>
        public PSCloudTieringCachePerformance CachePerformance { get; set; }

        /// <summary>
        /// Gets or sets the files not tiering errors.
        /// </summary>
        /// <value>The files not tiering errors.</value>
        public PSCloudTieringFilesNotTiering FilesNotTiering { get; set; }

        /// <summary>
        /// Gets or sets the volume free space policy status.
        /// </summary>
        /// <value>The volume free space policy status.</value>
        public PSCloudTieringVolumeFreeSpacePolicyStatus VolumeFreeSpacePolicyStatus { get; set; }
    }
}