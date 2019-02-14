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
    public class HelpMessages
    {
        public const string AsJobParameter = "Run cmdlet in the background";
        public const string StorageSyncServiceObjectParameter = "StorageSyncService Object, normally passed through the parameter.";
        public const string StorageSyncServiceInputObjectParameter = "StorageSyncService Input Object, normally passed through the pipeline.";
        public const string StorageSyncServiceResourceIdParameter = "StorageSyncService Resource Id";
        public const string StorageSyncServiceParentResourceIdParameter = "StorageSyncService Parent Resource Id";
        public const string StorageSyncServiceNameParameter = "Name of the StorageSyncService.";
        public const string StorageSyncServiceLocationParameter = "Storage Sync Service Location.";
        public const string StorageSyncServiceTagsParameter = "Storage Sync Service Tags.";
        public const string StorageSyncServiceForceParameter = "Force to Delete the Storage Sync Service";
        public const string SyncGroupObjectParameter = "SyncGroup Object, normally passed through the parameter.";
        public const string SyncGroupInputObjectParameter = "SyncGroup Input Object";
        public const string SyncGroupResourceIdParameter = "SyncGroup Resource Id";
        public const string SyncGroupParentResourceIdParameter = "SyncGroup Parent Resource Id";
        public const string SyncGroupNameParameter = "Name of the SyncGroup.";
        public const string SyncGroupForceParameter = "Force to Delete the Sync Group";
        public const string RegisteredServerObjectParameter = "RegisteredServer Object, normally passed through the parameter.";
        public const string RegisteredServerInputObjectParameter = "RegisteredServer Input Object, normally passed through the pipeline.";
        public const string RegisteredServerResourceIdParameter = "RegisteredServer Resource Id";
        public const string RegisteredServerNameParameter = "Name of the RegisteredServer.";
        public const string RegisteredServerForceParameter = "Force to Delete the RegisteredServer";
        public const string CloudEndpointObjectParameter = "CloudEndpoint Object, normally passed through the parameter.";
        public const string CloudEndpointInputObjectParameter = "CloudEndpoint Input Object, normally passed through the pipeline.";
        public const string CloudEndpointResourceIdParameter = "CloudEndpoint Resource Id";
        public const string CloudEndpointNameParameter = "Name of the CloudEndpoint.";
        public const string CloudEndpointForceParameter = "Force to Delete the CloudEndpoint";
        public const string StorageAccountShareNameParameter = "Storage Account Share Name (Azure File Share Name)";
        public const string StorageAccountTenantIdParameter = "Storage Account Tenant Id (Company Directory Id)";
        public const string StorageAccountResourceIdParameter = "Storage Account Resource Id";
        public const string ServerEndpointObjectParameter = "ServerEndpoint Object, normally passed through the parameter.";
        public const string ServerEndpointInputObjectParameter = "ServerEndpoint Input Object, normally passed through the pipeline.";
        public const string ServerEndpointResourceIdParameter = "ServerEndpoint Resource Id";
        public const string ServerEndpointNameParameter = "Name of the ServerEndpoint.";
        public const string ServerEndpointForceParameter = "Force to Delete the ServerEndpoint";
        public const string ServerLocalPathParameter = "Server Local Path Parameter";
        public const string CloudTieringParameter = "Cloud Tiering Parameter";
        public const string CloudSeededDataParameter = "Cloud Seeded Data Parameter";
        public const string CloudSeededDataFileShareUriParameter = "Cloud Seeded Data File Share Uri Parameter";
        public const string TierFilesOlderThanDaysParameter = "Tier Files Older Than Days Parameter";
        public const string VolumeFreeSpacePercentParameter = "Volume Free Space Percent Parameter";
        public const string PatternParameter = "Pattern of the file name";
        public const string RecallPathParameter = "Recall path which need to be recalled.";
        public const string ResourceGroupNameParameter = "Resource Group Name.";
    }
}
