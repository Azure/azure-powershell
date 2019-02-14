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
    /// Class PSSyncSessionStatus.
    /// </summary>
    public class PSSyncSessionStatus
    {
        /// <summary>
        /// Gets or sets the last synchronize result.
        /// </summary>
        /// <value>The last synchronize result.</value>
        public int? LastSyncResult { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize timestamp.
        /// </summary>
        /// <value>The last synchronize timestamp.</value>
        public DateTime? LastSyncTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize success timestamp.
        /// </summary>
        /// <value>The last synchronize success timestamp.</value>
        public DateTime? LastSyncSuccessTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the last synchronize per item error count.
        /// </summary>
        /// <value>The last synchronize per item error count.</value>
        public int? LastSyncPerItemErrorCount { get; set; }
    }
}