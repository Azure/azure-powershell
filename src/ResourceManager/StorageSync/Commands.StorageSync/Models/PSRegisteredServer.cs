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
    public class PSRegisteredServer : PSResourceBase
    {
        public string StorageSyncServiceName { get; internal set; }
        public string ServerName { get; internal set; }

        public string ServerCertificate { get; set; }

        public string AgentVersion { get; set; }

        public string ServerOSVersion { get; set; }

        public int? ServerManagementtErrorCode { get; set; }

        public string LastHeartBeat { get; set; }

        public string ProvisioningState { get; set; }

        public string ServerRole { get; set; }

        public string ClusterId { get; set; }

        public string ClusterName { get; set; }

        public string ServerId { get; set; }

        public string StorageSyncServiceUid { get; set; }

        public string LastWorkflowId { get; set; }

        public string LastOperationName { get; set; }

        public string DiscoveryEndpointUri { get; set; }

        public string ResourceLocation { get; set; }

        public string ServiceLocation { get; set; }

        public string FriendlyName { get; set; }

        public string ManagementEndpointUri { get; set; }
    }
}
