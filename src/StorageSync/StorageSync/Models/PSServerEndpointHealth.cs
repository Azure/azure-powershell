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

using System;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    /// <summary>
    /// Class PSServerEndpointHealth.
    /// </summary>
    public class PSServerEndpointHealth
    {
        /// <summary>
        /// Gets or sets the download health.
        /// </summary>
        /// <value>The download health.</value>
        public string DownloadHealth { get; set; }
        /// <summary>
        /// Gets or sets the upload health.
        /// </summary>
        /// <value>The upload health.</value>
        public string UploadHealth { get; set; }
        /// <summary>
        /// Gets or sets the combined health.
        /// </summary>
        /// <value>The combined health.</value>
        public string CombinedHealth { get; set; }
        /// <summary>
        /// Gets or sets the sync activity.
        /// </summary>
        /// <value>The combined health.</value>
        public string SyncActivity { get; set; }
        /// <summary>
        /// Gets or sets the last updated timestamp.
        /// </summary>
        /// <value>The last updated timestamp.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the upload status.
        /// </summary>
        /// <value>The upload status.</value>
        public PSSyncSessionStatus UploadStatus { get; set; }
        /// <summary>
        /// Gets or sets the download status.
        /// </summary>
        /// <value>The download status.</value>
        public PSSyncSessionStatus DownloadStatus { get; set; }
        /// <summary>
        /// Gets or sets the upload activity.
        /// </summary>
        /// <value>The current progress.</value>
        public PSSyncActivityStatus UploadActivity { get; set; }
        /// <summary>
        /// Gets or sets the download activity.
        /// </summary>
        /// <value>The current progress.</value>
        public PSSyncActivityStatus DownloadActivity { get; set; }
        /// <summary>
        /// Gets or sets the offline data transfer status.
        /// </summary>
        /// <value>The offline data transfer status.</value>
        public string OfflineDataTransferStatus { get; set; }
        /// <summary>
        /// Gets or sets the total persistent files not syncing count.
        /// </summary>
        /// <value>The total persistent files not syncing count.</value>
        public long? TotalPersistentFilesNotSyncingCount { get; set; }
        /// <summary>
        /// Gets or sets the background download activity.
        /// </summary>
        /// <value>The background download activity.</value>
        public PSBackgroundDataDownloadActivity BackgroundDataDownloadActivity { get; set; }
    }

    public class PSBackgroundDataDownloadActivity
    {
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public DateTime? Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the started timestamp.
        /// </summary>
        /// <value>The started timestamp.</value>
        public DateTime? StartedTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the percent progress.
        /// </summary>
        /// <value>The percent progress.</value>
        public int? PercentProgress { get; set; }
        /// <summary>
        /// Gets or sets the downloaded bytes.
        /// </summary>
        /// <value>The downloaded bytes.</value>
        public long? DownloadedBytes { get; set; }
    }
}

