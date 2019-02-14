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
    public class StorageSyncConstants
    {
        public const string ProductName = "StorageSync";
        public const string ProductPrefix = AzureRMConstants.AzureRMPrefix + ProductName;
        public const string ResourceProvider = "Microsoft" + "." + ProductName;
        public const string StorageAccountResourceProvider = "Microsoft.Storage";
        public const string ProvidersTypeName = "providers";
        public const string ResourceGroupTypeName = "resourceGroups";
        public const string SubscriptionTypeName = "subscriptions";
        public const string StorageSyncServiceTypeName = "storageSyncServices";
        public const string SyncGroupTypeName =  "syncGroups";
        public const string RegisteredServerTypeName = "registeredServers";
        public const string ServerEndpointTypeName = "serverEndpoints";
        public const string CloudEndpointTypeName = "cloudEndpoints";
        public const string StorageSyncServiceType = ResourceProvider + "/" + StorageSyncServiceTypeName;
        public const string SyncGroupType = StorageSyncServiceType + "/" + SyncGroupTypeName;
        public const string RegisteredServerType = StorageSyncServiceType + "/" + RegisteredServerTypeName;
        public const string ServerEndpointType = SyncGroupType + "/" + ServerEndpointTypeName;
        public const string CloudEndpointType = SyncGroupType + "/" + CloudEndpointTypeName;
        public const string StorageAccountType = "Microsoft.Storage/storageAccounts";
        public const string CloudTieringOn = "on";
        public const string CloudTieringOff = "off";
        public const string AfsAgentRegistryKey = @"SOFTWARE\Microsoft\Azure\StorageSync\Agent";
        public const string AfsAgentInstallerPathRegistryKeyValueName = "InstallDir";
        public const string AfsAgentVersionRegistryKeyValueName = "Version";
        public const string MonitoringAgentDirectoryName = @"MAAgent\Monitoring";
        public const string FileSyncSvcName = "FileSyncSvc";
    }
}
