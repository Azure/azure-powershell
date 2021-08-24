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
    /// Class PSCloudEndpoint.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    public class PSCloudEndpoint : PSResourceBase
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
        /// Gets or sets the name of the cloud endpoint.
        /// </summary>
        /// <value>The name of the cloud endpoint.</value>
        public string CloudEndpointName { get; set; }
        /// <summary>
        /// Gets or sets the storage account resource identifier.
        /// </summary>
        /// <value>The storage account resource identifier.</value>
        public string StorageAccountResourceId { get; set; }
        /// <summary>
        /// Gets or sets the name of the storage account share.
        /// </summary>
        /// <value>The name of the storage account share.</value>
        public string AzureFileShareName { get; set; }
        /// <summary>
        /// Gets or sets the storage account tenant identifier.
        /// </summary>
        /// <value>The storage account tenant identifier.</value>
        public string StorageAccountTenantId { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [backup enabled].
        /// </summary>
        /// <value><c>null</c> if [backup enabled] contains no value, <c>true</c> if [backup enabled]; otherwise, <c>false</c>.</value>
        public bool? BackupEnabled { get; set; }
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
        /// Gets or sets the partnership identifier.
        /// </summary>
        /// <value>The partnership identifier.</value>
        public string PartnershipId { get;  set; }
        /// <summary>
        /// Gets or sets the state of the provisioning.
        /// </summary>
        /// <value>The state of the provisioning.</value>
        public string ProvisioningState { get;  set; }
        /// <summary>
        /// Gets or sets the change enumeration status.
        /// </summary>
        /// <value>The change enumeration status.</value>
        public PSCloudEndpointChangeEnumerationStatus ChangeEnumerationStatus { get; set; }
    }
}
