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
    /// Class PSCloudEndpointChangeEnumerationStatus.
    /// </summary>
    public class PSCloudEndpointChangeEnumerationStatus
    {
        /// <summary>
        /// Gets the last updated timestamp.
        /// </summary>
        /// <value>The last updated timestamp.</value>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets status of last completed change enumeration
        /// </summary>
        /// <value>The status of the last completed change enumeration</value>
        public PSCloudEndpointLastChangeEnumerationStatus LastEnumerationStatus { get; set; }

        /// <summary>
        /// Gets change enumeration activity
        /// </summary>
        /// <value>The status of currently ongoing change enumeration</value>
        public PSCloudEndpointChangeEnumerationActivity Activity { get; set; }
    }

    public class PSCloudEndpointLastChangeEnumerationStatus
    {
        /// <summary>
        /// Gets the last updated timestamp.
        /// </summary>
        public DateTime? StartedTimestamp { get; set; }

        /// <summary>
        /// Gets timestamp when change enumeration completed
        /// </summary>
        public DateTime? CompletedTimestamp { get; set; }

        /// <summary>
        /// Gets count of files in the namespace
        /// </summary>
        public long? NamespaceFilesCount { get; set; }

        /// <summary>
        /// Gets count of directories in the namespace
        /// </summary>
        public long? NamespaceDirectoriesCount { get; set; }

        /// <summary>
        /// Gets namespace size in bytes
        /// </summary>
        public long? NamespaceSizeBytes { get; set; }

        /// <summary>
        /// Gets timestamp of when change enumeration is expected to run again
        /// </summary>
        public DateTime? NextRunTimestamp { get; set; }
    }

    public class PSCloudEndpointChangeEnumerationActivity
    {
        /// <summary>
        /// Gets last updated timestamp
        /// </summary>
        public DateTime? LastUpdatedTimestamp { get; set; }

        /// <summary>
        /// Gets change enumeration operation state. Possible values include:
        /// 'InitialEnumerationInProgress', 'EnumerationInProgress'
        /// </summary>
        public string OperationState { get; set; }

        /// <summary>
        /// Gets when non-zero, indicates an issue that is delaying change
        /// enumeration
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// Gets timestamp when change enumeration started
        /// </summary>
        public DateTime? StartedTimestamp { get; set; }

        /// <summary>
        /// Gets count of files processed
        /// </summary>
        public long? ProcessedFilesCount { get; set; }

        /// <summary>
        /// Gets count of directories processed
        /// </summary>
        public long? ProcessedDirectoriesCount { get; set; }

        /// <summary>
        /// Gets total count of files enumerated
        /// </summary>
        public long? TotalFilesCount { get; set; }

        /// <summary>
        /// Gets total count of directories enumerated
        /// </summary>
        public long? TotalDirectoriesCount { get; set; }

        /// <summary>
        /// Gets total enumerated size in bytes
        /// </summary>
        public long? TotalSizeBytes { get; set; }

        /// <summary>
        /// Gets progress percentage for change enumeration run, excluding
        /// processing of deletes
        /// </summary>
        public int? ProgressPercent { get; set; }

        /// <summary>
        /// Gets estimate of time remaining for the enumeration run
        /// </summary>
        public int? MinutesRemaining { get; set; }

        /// <summary>
        /// Gets change enumeration total counts state. Possible values
        /// include: 'Calculating', 'Final'
        /// </summary>
        public string TotalCountsState { get; set; }

        /// <summary>
        /// Gets progress percentage for processing deletes. This is done
        /// separately from the rest of the enumeration run
        /// </summary>
        public int? DeletesProgressPercent { get; set; }
    }
}