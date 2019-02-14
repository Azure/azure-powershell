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
    /// <summary>
    /// Class PSSyncGroup.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    public class PSSyncGroup : PSResourceBase
    {
        /// <summary>
        /// Gets or sets the name of the synchronize group.
        /// </summary>
        /// <value>The name of the synchronize group.</value>
        public string SyncGroupName { get; set; }
        /// <summary>
        /// Gets or sets the name of the storage synchronize service.
        /// </summary>
        /// <value>The name of the storage synchronize service.</value>
        public string StorageSyncServiceName { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the synchronize group status.
        /// </summary>
        /// <value>The synchronize group status.</value>
        public string SyncGroupStatus { get; set; }
    }
}
