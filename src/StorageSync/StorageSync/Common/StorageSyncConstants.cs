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
        /// The Offline Data Transfer on
        /// </summary>
        public const string OfflineDataTransferOn = "on";
        /// <summary>
        /// The Offline Data Transfer off
        /// </summary>
        public const string OfflineDataTransferOff = "off";
        /// <summary>
        /// The afs agent registry key
        /// </summary>
        public const string AfsAgentRegistryKey = @"SOFTWARE\Microsoft\Azure\StorageSync\Agent";
        /// <summary>
        /// The afs registry key
        /// </summary>
        public const string AfsRegistryKey = @"SOFTWARE\Microsoft\Azure\StorageSync";
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

        /// <summary>
        /// Registry key name for Server Auth Type
        /// </summary>
        public const string ServerAuthRegistryKeyName = "ServerAuth";

        /// <summary>
        /// Registry key name for Server Type
        /// </summary>
        public const string ServerTypeRegistryKeyName = "ServerType";

        /// <summary>
        /// Compute ResourceType
        /// </summary>
        public const string ComputeResourceType = "Microsoft.Compute";

        /// <summary>
        /// Hybrid Resource Type
        /// </summary>
        public const string HybridResourceType = "Microsoft.HybridCompute";

        /// <summary>
        /// Virtual Machines
        /// </summary>
        public const string VirtualMachineString = "virtualMachines";

        /// <summary>
        /// machines
        /// </summary>
        public const string HybridMachineString = "machines";

        /// <summary>
        /// Azure Instance Metadata Uri
        /// </summary>
        public const string AzureInstanceMetadataUri = "http://169.254.169.254/metadata/instance/compute?api-version=2019-11-01";

        /// <summary>
        /// Hybrid Instance Metadata Uri
        /// </summary>
        public const string HybridInstanceMetadataUri = "http://localhost:40342/metadata/instance/compute?api-version=2019-11-01";

        /// <summary>
        /// Azure Token Uri.
        ///  Azure IMDS Documentation: https://learn.microsoft.com/en-us/azure/virtual-machines/instance-metadata-service
        /// DefaultMSILoginUri = "http://169.254.169.254/metadata/identity/oauth2/token",
        /// </summary>
        public const string AzureTokenUri = DefaultMSILoginUri + "?resource=https://management.azure.com/&api-version=2019-11-01";

        /// <summary>
        /// Hybrid Token Uri
        /// Hybrid IMDS Documentation: https://learn.microsoft.com/en-us/azure/azure-arc/servers/managed-identity-authentication
        /// </summary>
        public const string HybridTokenUri = "http://localhost:40342/metadata/identity/oauth2/token?resource=https://management.azure.com/&api-version=2020-06-01";

        /// <summary>
        /// Default MSILoginUri
        /// </summary>
        public const string DefaultMSILoginUri = "http://169.254.169.254/metadata/identity/oauth2/token";

        /// <summary>
        /// default backup MSILoginUri
        /// </summary>
        public const string DefaultBackupMSILoginUri = "http://localhost:50342/oauth2/token";

        /// <summary>
        /// GetVM API Version
        /// </summary>
        public const string GetVmApiVersion = "2022-08-01";

        /// <summary>
        /// Get Hybrid API Version
        /// </summary>
        public const string GetHybridApiVersion = "2022-08-11-preview";
    }
}
