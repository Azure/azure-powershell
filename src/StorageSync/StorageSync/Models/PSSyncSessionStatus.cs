﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    /// <summary>
    /// Class PSSyncSessionStatus.
    /// </summary>
    public class PSSyncSessionStatus
    {
        /// <summary>
        /// Gets or sets the last sync result.
        /// </summary>
        /// <value>The last sync result.</value>
        public int? LastSyncResult { get; set; }
        /// <summary>
        /// Gets or sets the last sync timestamp.
        /// </summary>
        /// <value>The last sync timestamp.</value>
        public DateTime? LastSyncTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the last sync success timestamp.
        /// </summary>
        /// <value>The last sync success timestamp.</value>
        public DateTime? LastSyncSuccessTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the last sync per item error count.
        /// </summary>
        /// <value>The last sync per item error count.</value>
        public long? LastSyncPerItemErrorCount { get; set; }
        /// <summary>
        /// Gets or sets the persistent files not syncing count.
        /// </summary>
        /// <value>The persistent files not syncing count</value>
        public long? PersistentFilesNotSyncingCount { get; set; }
        /// <summary>
        /// Gets or sets the transient files not syncing count.
        /// </summary>
        /// <value>The transient files not syncing count</value>
        public long? TransientFilesNotSyncingCount { get; set; }
        /// <summary>
        /// Gets or sets the files not syncing errors
        /// </summary>
        /// <value>The list of files not syncing errors</value>
        public IList<PSServerEndpointFilesNotSyncingError> FilesNotSyncingErrors { get; set; }
        /// <summary>
        /// Gets or sets the last sync mode.
        /// </summary>
        /// <value>The last sync mode.</value>
        public string LastSyncMode { get; set; }
    }

    public class PSServerEndpointFilesNotSyncingError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int? ErrorCode { get; set; }
        /// <summary>
        /// Gets or sets the persistent files count.
        /// </summary>
        /// <value>The persistent files count.</value>
        public long? PersistentCount { get; set; }
        /// <summary>
        /// Gets or sets the transient files count.
        /// </summary>
        /// <value>The transient files count.</value>
        public long? TransientCount { get; set; }

    }
}