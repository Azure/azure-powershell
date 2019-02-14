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
    public class StorageSyncCmdletNames
    {
        public const string NewAzureRmStorageSyncService = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string NewAzureRmStorageSyncGroup = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string NewAzureRmStorageSyncServer = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string NewAzureRmStorageSyncCloudEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string NewAzureRmStorageSyncServerEndpoint = VerbsCommon.New + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        public const string InvokeAzureRmStorageSyncFileRecall = VerbsLifecycle.Invoke + "-" + StorageSyncNouns.NounAzureRmStorageSyncFileRecall;
        public const string GetAzureRmStorageSyncService = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string GetAzureRmStorageSyncGroup = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string GetAzureRmStorageSyncServer = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string GetAzureRmStorageSyncCloudEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string GetAzureRmStorageSyncServerEndpoint = VerbsCommon.Get + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        public const string RemoveAzureRmStorageSyncService = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string RemoveAzureRmStorageSyncGroup = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncGroup;
        public const string RemoveAzureRmStorageSyncCloudEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncCloudEndpoint;
        public const string RemoveAzureRmStorageSyncServerEndpoint = VerbsCommon.Remove + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        public const string SetAzureRmStorageSyncService = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncService;
        public const string SetAzureRmStorageSyncServerEndpoint = VerbsCommon.Set + "-" + StorageSyncNouns.NounAzureRmStorageSyncServerEndpoint;
        public const string UnregisterAzureRmStorageSyncServer = VerbsLifecycle.Unregister + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
        public const string RegisterAzureRmStorageSyncServer = VerbsLifecycle.Register + "-" + StorageSyncNouns.NounAzureRmStorageSyncServer;
    }
}
