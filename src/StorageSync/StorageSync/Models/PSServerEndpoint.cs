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
    /// Class PSServerEndpoint.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    public class PSServerEndpoint : PSResourceBase
    {
        /// <summary>
        /// Gets or sets the name of the sync group.
        /// </summary>
        /// <value>The name of the sync group.</value>
        public string SyncGroupName { get; set; }
        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        public string StorageSyncServiceName { get; set; }
        /// <summary>
        /// Gets or sets the server local path.
        /// </summary>
        /// <value>The server local path.</value>
        public string ServerLocalPath { get; set; }
        /// <summary>
        /// Gets or sets the server resource identifier.
        /// </summary>
        /// <value>The server resource identifier.</value>
        public string ServerResourceId { get; set; }
        /// <summary>
        /// Gets or sets the name of the server endpoint.
        /// </summary>
        /// <value>The name of the server endpoint.</value>
        public string ServerEndpointName { get; set; }
        /// <summary>
        /// Gets or sets the state of the provisioning.
        /// </summary>
        /// <value>The state of the provisioning.</value>
        public string ProvisioningState { get; set; }
        /// <summary>
        /// Gets or sets the last workflow identifier.
        /// </summary>
        /// <value>The last workflow identifier.</value>
        public string LastWorkflowId { get; set; }
        /// <summary>
        /// Gets or sets the last name of the operation.
        /// </summary>
        /// <value>The last name of the operation.</value>
        public string LastOperationName { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Gets or sets the sync status.
        /// </summary>
        /// <value>The sync status.</value>
        public PSServerEndpointHealth SyncStatus { get; set; }
        /// <summary>
        /// Gets or sets the cloud tiering.
        /// </summary>
        /// <value>The cloud tiering.</value>
        public string CloudTiering { get; set; }
        /// <summary>
        /// Gets or sets the volume free space percent.
        /// </summary>
        /// <value>The volume free space percent.</value>
        public int? VolumeFreeSpacePercent { get; set; }
        /// <summary>
        /// Gets or sets the tier files older than days.
        /// </summary>
        /// <value>The tier files older than days.</value>
        public int? TierFilesOlderThanDays { get; set; }
    }
}