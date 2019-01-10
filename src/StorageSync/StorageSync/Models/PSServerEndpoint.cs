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
    public class PSServerEndpoint : PSResourceBase
    {
        public string SyncGroupName { get; set; }

        public string StorageSyncServiceName { get; set; }

        public string ServerLocalPath { get; set; }
        public string ServerResourceId { get; set; }
        public string ServerEndpointName { get; set; }
        public string ProvisioningState { get; set; }
        public string LastWorkflowId { get; set; }
        public string LastOperationName { get; set; }
        public string FriendlyName { get; set; }
        public object SyncStatus { get; set; }
        public string CloudTiering { get; set; }
        public int? VolumeFreeSpacePercent { get; set; }

        public int? TierFilesOlderThanDays { get; set; }
    }
}