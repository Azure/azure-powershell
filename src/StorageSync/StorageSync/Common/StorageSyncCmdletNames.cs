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
    /// Class StorageSyncCmdletNames.
    /// </summary>
    public class StorageSyncCmdletNames
    {
        /// <summary>
        /// Creates new azurermstoragesyncservice.
        /// </summary>
        public const string NewAzureRmStorageSyncService = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        /// <summary>
        /// Creates new azurermstoragesyncgroup.
        /// </summary>
        public const string NewAzureRmStorageSyncGroup = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        /// <summary>
        /// Creates new azurermstoragesyncserver.
        /// </summary>
        public const string NewAzureRmStorageSyncServer = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        /// <summary>
        /// Creates new azurermstoragesynccloudendpoint.
        /// </summary>
        public const string NewAzureRmStorageSyncCloudEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        /// <summary>
        /// Creates new azurermstoragesyncserverendpoint.
        /// </summary>
        public const string NewAzureRmStorageSyncServerEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        /// <summary>
        /// The get azure rm storage sync service
        /// </summary>
        public const string GetAzureRmStorageSyncService = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        /// <summary>
        /// The get azure rm storage sync group
        /// </summary>
        public const string GetAzureRmStorageSyncGroup = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        /// <summary>
        /// The get azure rm storage sync server
        /// </summary>
        public const string GetAzureRmStorageSyncServer = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        /// <summary>
        /// The get azure rm storage sync cloud endpoint
        /// </summary>
        public const string GetAzureRmStorageSyncCloudEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        /// <summary>
        /// The get azure rm storage sync server endpoint
        /// </summary>
        public const string GetAzureRmStorageSyncServerEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        /// <summary>
        /// The remove azure rm storage sync service
        /// </summary>
        public const string RemoveAzureRmStorageSyncService = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        /// <summary>
        /// The remove azure rm storage sync group
        /// </summary>
        public const string RemoveAzureRmStorageSyncGroup = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        /// <summary>
        /// The remove azure rm storage sync cloud endpoint
        /// </summary>
        public const string RemoveAzureRmStorageSyncCloudEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        /// <summary>
        /// The remove azure rm storage sync server endpoint
        /// </summary>
        public const string RemoveAzureRmStorageSyncServerEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        /// <summary>
        /// The set azure rm storage sync service
        /// </summary>
        public const string SetAzureRmStorageSyncService = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        /// <summary>
        /// The set azure rm storage sync server endpoint
        /// </summary>
        public const string SetAzureRmStorageSyncServerEndpoint = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        /// <summary>
        /// The unregister azure rm storage sync server
        /// </summary>
        public const string UnregisterAzureRmStorageSyncServer = VerbsLifecycle.Unregister + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        /// <summary>
        /// The register azure rm storage sync server
        /// </summary>
        public const string RegisterAzureRmStorageSyncServer = VerbsLifecycle.Register + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
    }
}
