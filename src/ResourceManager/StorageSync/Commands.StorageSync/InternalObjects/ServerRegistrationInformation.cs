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

namespace Microsoft.Azure.Commands.StorageSync.InternalObjects
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Data structure below is used to notify managed monitoring component running within filesyncsvc
    /// about successful server registration. It is important to understand how serialization is used here:
    /// 1. PS cmdlet invokes SyncServerRegistrationClient with details of registered server
    /// 2. SyncServerRegistrationClient prepares this structure, serializes it in JSON 
    ///    and invokes IEcsManagement.RegisterMonitoringAgent (COM interop)
    /// 3. Global State Manager calls ManagementAgentTasks.RegisterMonitoringAgent
    /// 4. ManagementAgentTasks.RegisterMonitoringAgent deserializes the structure from JSON,
    ///    picks the fields needed for MonitoringConfiguration and persists it.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Variable names match the intent")]
    public sealed class ServerRegistrationInformation
    {
        public ServerRegistrationInformation(
            Guid subscriptionId,
            string resourceGroupName,
            string storageSyncServiceName,
            Guid storageSyncServiceUid,
            string clusterName,
            Guid clusterId,
            HybridMonitoringConfigurationResource monitoringConfiguration,
            byte[] serverCertificate,
            string serviceEndpoint,
            string resourceLocation)
        {
            SubscriptionId = subscriptionId;
            ResourceGroupName = resourceGroupName;
            StorageSyncServiceName = storageSyncServiceName;
            StorageSyncServiceUid = storageSyncServiceUid;
            ClusterName = clusterName;
            ClusterId = clusterId;
            MonitoringConfiguration = monitoringConfiguration;
            ServerCertificate = serverCertificate;
            ServiceEndpoint = serviceEndpoint;
            ResourceLocation = resourceLocation;
        }

        [JsonProperty(PropertyName = "resourceLocation", Required = Required.Default)]
        public string ResourceLocation
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "serviceEndpoint", Required = Required.Default)]
        public string ServiceEndpoint
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "subscriptionId", Required = Required.Default)]
        public Guid SubscriptionId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "storageSyncServiceName", Required = Required.Default)]
        public string StorageSyncServiceName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "resourceGroupName", Required = Required.Default)]
        public string ResourceGroupName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "clusterId", Required = Required.Default)]
        public Guid ClusterId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "clusterName", Required = Required.Default)]
        public string ClusterName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "monitoringConfiguration", Required = Required.Default)]
        public HybridMonitoringConfigurationResource MonitoringConfiguration
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "serverCertificate", Required = Required.Default)]
        public byte[] ServerCertificate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "storageSyncServiceUid", Required = Required.Default)]
        public Guid StorageSyncServiceUid
        {
            get;
            set;
        }
    }
}
