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
    /// and invokes IEcsManagement.RegisterMonitoringAgent (COM interop)
    /// 3. Global State Manager calls ManagementAgentTasks.RegisterMonitoringAgent
    /// 4. ManagementAgentTasks.RegisterMonitoringAgent deserializes the structure from JSON,
    /// picks the fields needed for MonitoringConfiguration and persists it.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Variable names match the intent")]
    public sealed class ServerRegistrationInformation
    {
        /// <summary>
        /// Gets or sets the resource location.
        /// </summary>
        /// <value>The resource location.</value>
        [JsonProperty(PropertyName = "resourceLocation", Required = Required.Default)]
        public string ResourceLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the service endpoint.
        /// </summary>
        /// <value>The service endpoint.</value>
        [JsonProperty(PropertyName = "serviceEndpoint", Required = Required.Default)]
        public string ServiceEndpoint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        /// <value>The subscription identifier.</value>
        [JsonProperty(PropertyName = "subscriptionId", Required = Required.Default)]
        public Guid SubscriptionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        [JsonProperty(PropertyName = "storageSyncServiceName", Required = Required.Default)]
        public string StorageSyncServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        /// <value>The name of the resource group.</value>
        [JsonProperty(PropertyName = "resourceGroupName", Required = Required.Default)]
        public string ResourceGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cluster identifier.
        /// </summary>
        /// <value>The cluster identifier.</value>
        [JsonProperty(PropertyName = "clusterId", Required = Required.Default)]
        public Guid ClusterId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the cluster.
        /// </summary>
        /// <value>The name of the cluster.</value>
        [JsonProperty(PropertyName = "clusterName", Required = Required.Default)]
        public string ClusterName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the monitoring configuration.
        /// </summary>
        /// <value>The monitoring configuration.</value>
        [JsonProperty(PropertyName = "monitoringConfiguration", Required = Required.Default)]
        public HybridMonitoringConfigurationResource MonitoringConfiguration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the server certificate.
        /// </summary>
        /// <value>The server certificate.</value>
        [JsonProperty(PropertyName = "serverCertificate", Required = Required.Default)]
        public byte[] ServerCertificate
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "applicationId", Required = Required.Default)]
        public Guid? ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the storage sync service uid.
        /// </summary>
        /// <value>The storage sync service uid.</value>
        [JsonProperty(PropertyName = "storageSyncServiceUid", Required = Required.Default)]
        public Guid StorageSyncServiceUid
        {
            get;
            set;
        }
    }
}
