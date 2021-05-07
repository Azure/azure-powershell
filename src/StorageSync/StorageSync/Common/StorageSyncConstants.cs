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
    /// Class StorageSyncConstants.
    /// </summary>
    public class StorageSyncConstants
    {
        /// <summary>
        /// The product name
        /// </summary>
        public const string ProductName = "StorageSync";
        /// <summary>
        /// The product prefix
        /// </summary>
        public const string ProductPrefix = AzureRMConstants.AzureRMPrefix + ProductName;
        /// <summary>
        /// The resource provider
        /// </summary>
        public const string ResourceProvider = "Microsoft.StorageSync";
        /// <summary>
        /// The storage account resource provider
        /// </summary>
        public const string StorageAccountResourceProvider = "Microsoft.Storage";
        /// <summary>
        /// The providers type name
        /// </summary>
        public const string ProvidersTypeName = "providers";
        /// <summary>
        /// The resource group type name
        /// </summary>
        public const string ResourceGroupTypeName = "resourceGroups";
        /// <summary>
        /// The subscription type name
        /// </summary>
        public const string SubscriptionTypeName = "subscriptions";
        /// <summary>
        /// The storage sync service type name
        /// </summary>
        public const string StorageSyncServiceTypeName = "storageSyncServices";
        /// <summary>
        /// The sync group type name
        /// </summary>
        public const string SyncGroupTypeName =  "syncGroups";
        /// <summary>
        /// The registered server type name
        /// </summary>
        public const string RegisteredServerTypeName = "registeredServers";
        /// <summary>
        /// The server endpoint type name
        /// </summary>
        public const string ServerEndpointTypeName = "serverEndpoints";
        /// <summary>
        /// The cloud endpoint type name
        /// </summary>
        public const string CloudEndpointTypeName = "cloudEndpoints";
        /// <summary>
        /// The storage sync service type
        /// </summary>
        public const string StorageSyncServiceType = ResourceProvider + "/" + StorageSyncServiceTypeName;
        /// <summary>
        /// The sync group type
        /// </summary>
        public const string SyncGroupType = StorageSyncServiceType + "/" + SyncGroupTypeName;
        /// <summary>
        /// The registered server type
        /// </summary>
        public const string RegisteredServerType = StorageSyncServiceType + "/" + RegisteredServerTypeName;
        /// <summary>
        /// The server endpoint type
        /// </summary>
        public const string ServerEndpointType = SyncGroupType + "/" + ServerEndpointTypeName;
        /// <summary>
        /// The cloud endpoint type
        /// </summary>
        public const string CloudEndpointType = SyncGroupType + "/" + CloudEndpointTypeName;
        /// <summary>
        /// The storage account type
        /// </summary>
        public const string StorageAccountType = "Microsoft.Storage/storageAccounts";
        /// <summary>
        /// The cloud tiering on
        /// </summary>
        public const string CloudTieringOn = "on";
        /// <summary>
        /// The cloud tiering off
        /// </summary>
        public const string CloudTieringOff = "off";

        /// <summary>
        /// The afs agent registry key
        /// </summary>
        public const string AfsAgentRegistryKey = @"SOFTWARE\Microsoft\Azure\StorageSync\Agent";
        /// <summary>
        /// The afs agent installer path registry key value name
        /// </summary>
        public const string AfsAgentInstallerPathRegistryKeyValueName = "InstallDir";
        /// <summary>
        /// The afs agent version registry key value name
        /// </summary>
        public const string AfsAgentVersionRegistryKeyValueName = "Version";
        /// <summary>
        /// The monitoring agent directory name
        /// </summary>
        public const string MonitoringAgentDirectoryName = @"MAAgent\Monitoring";
        /// <summary>
        /// The file sync SVC name
        /// </summary>
        public const string FileSyncSvcName = "FileSyncSvc";

        /// <summary>
        /// The storage sync resource manager
        /// </summary>
        public const string StorageSyncResourceManager = "StorageSyncResourceManager";

        /// <summary>
        /// The sync server identifier
        /// </summary>
        public const string SyncServerId = "SyncServerId";

        /// <summary>
        /// The tenant identifier
        /// </summary>
        public const string TenantId = "TenantId";
    }
}
