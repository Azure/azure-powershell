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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    /// <summary>
    /// Class StorageSyncNouns.
    /// </summary>
    public class StorageSyncNouns
    {
        /// <summary>
        /// The noun azure rm storage sync service
        /// </summary>
        public const string NounAzureRmStorageSyncService = StorageSyncConstants.ProductPrefix + "Service";

        /// <summary>
        /// The noun azure rm storage sync service identity
        /// </summary>
        public const string NounAzureRmStorageSyncServiceIdentity = StorageSyncNouns.NounAzureRmStorageSyncService + "Identity";

        /// <summary>
        /// The noun azure rm storage sync group
        /// </summary>
        public const string NounAzureRmStorageSyncGroup = StorageSyncConstants.ProductPrefix + "Group";
        /// <summary>
        /// The noun azure rm storage sync server
        /// </summary>
        public const string NounAzureRmStorageSyncServer = StorageSyncConstants.ProductPrefix + "Server";
        /// <summary>
        /// The noun azure rm storage sync cloud endpoint
        /// </summary>
        public const string NounAzureRmStorageSyncCloudEndpoint = StorageSyncConstants.ProductPrefix + "CloudEndpoint";

        /// <summary>
        /// The noun azure rm storage sync cloud endpoint permission
        /// </summary>
        public const string NounAzureRmStorageSyncCloudEndpointPermission = StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint + "Permission";

        /// <summary>
        /// The noun azure rm storage sync server endpoint permission
        /// </summary>
        public const string NounAzureRmStorageSyncServerEndpointPermission = StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint + "Permission";

        /// <summary>
        /// The noun azure rm storage sync server endpoint
        /// </summary>
        public const string NounAzureRmStorageSyncServerEndpoint = StorageSyncConstants.ProductPrefix + "ServerEndpoint";
        /// <summary>
        /// The noun azure rm storage sync server configuration
        /// </summary>
        public const string NounAzureRmStorageSyncServerConfiguration = StorageSyncConstants.ProductPrefix + "ServerConfiguration";
        /// <summary>
        /// The noun azure rm storage sync server certificate
        /// </summary>
        public const string NounAzureRmStorageSyncServerCertificate = NounAzureRmStorageSyncServer + "Certificate";
        /// <summary>
        /// The noun azure rm storage sync change detection
        /// </summary>
        public const string NounAzureRmStorageSyncChangeDetection = StorageSyncConstants.ProductPrefix + "ChangeDetection";
    }
}
