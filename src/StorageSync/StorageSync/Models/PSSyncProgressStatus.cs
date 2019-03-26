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
    /// Class PSSyncProgressStatus.
    /// </summary>
    public class PSSyncProgressStatus
    {
        /// <summary>
        /// Gets or sets the progress timestamp.
        /// </summary>
        /// <value>The progress timestamp.</value>
        public DateTime? ProgressTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the sync direction.
        /// </summary>
        /// <value>The sync direction.</value>
        public string SyncDirection { get; set; }
        /// <summary>
        /// Gets or sets the per item error count.
        /// </summary>
        /// <value>The per item error count.</value>
        public int? PerItemErrorCount { get; set; }
        /// <summary>
        /// Gets or sets the applied item count.
        /// </summary>
        /// <value>The applied item count.</value>
        public int? AppliedItemCount { get; set; }
        /// <summary>
        /// Gets or sets the total item count.
        /// </summary>
        /// <value>The total item count.</value>
        public int? TotalItemCount { get; set; }
        /// <summary>
        /// Gets or sets the applied bytes.
        /// </summary>
        /// <value>The applied bytes.</value>
        public int? AppliedBytes { get; set; }
        /// <summary>
        /// Gets or sets the total bytes.
        /// </summary>
        /// <value>The total bytes.</value>
        public int? TotalBytes { get; set; }
    }
}