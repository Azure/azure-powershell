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

using System;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    /// <summary>
    /// Class PSRegisteredServer.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    public class PSRegisteredServer : PSResourceBase
    {
        /// <summary>
        /// Gets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        public string StorageSyncServiceName { get; internal set; }

        /// <summary>
        /// Gets or sets the server identifier.
        /// </summary>
        /// <value>The server identifier.</value>
        public string ServerId { get; set; }

        /// <summary>
        /// Gets or sets the server certificate.
        /// </summary>
        /// <value>The server certificate.</value>
        public string ServerCertificate { get; set; }

        /// <summary>
        /// Gets or sets the agent version.
        /// </summary>
        /// <value>The agent version.</value>
        public string AgentVersion { get; set; }

        /// <summary>
        /// Gets or sets the agent version status.
        /// </summary>
        /// <value>The agent version status.</value>
        public string AgentVersionStatus { get; set; }

        /// <summary>
        /// Gets or sets the agent version expiration date.
        /// </summary>
        /// <value>The agent version expiration date.</value>
        public DateTime? AgentVersionExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the server os version.
        /// </summary>
        /// <value>The server os version.</value>
        public string ServerOSVersion { get; set; }

        /// <summary>
        /// Gets or sets the server management error code.
        /// </summary>
        /// <value>The server management error code.</value>
        public int? ServerManagementErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the last heart beat.
        /// </summary>
        /// <value>The last heart beat.</value>
        public string LastHeartBeat { get; set; }

        /// <summary>
        /// Gets or sets the state of the provisioning.
        /// </summary>
        /// <value>The state of the provisioning.</value>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the server role.
        /// </summary>
        /// <value>The server role.</value>
        public string ServerRole { get; set; }

        /// <summary>
        /// Gets or sets the cluster identifier.
        /// </summary>
        /// <value>The cluster identifier.</value>
        public string ClusterId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cluster.
        /// </summary>
        /// <value>The name of the cluster.</value>
        public string ClusterName { get; set; }

        /// <summary>
        /// Gets or sets the storage sync service uid.
        /// </summary>
        /// <value>The storage sync service uid.</value>
        public string StorageSyncServiceUid { get; set; }

        /// <summary>
        /// Gets or sets the last workflow identifier.
        /// </summary>
        /// <value>The last workflow identifier.</value>
        public string LastWorkflowId { get; set; }

        /// <summary>
        /// Gets or sets the last name of the operation.
        /// </summary>
        /// <value>The last name of the operation.</value>
        public string LastOperationName { get; set; }

        /// <summary>
        /// Gets or sets the discovery endpoint URI.
        /// </summary>
        /// <value>The discovery endpoint URI.</value>
        public string DiscoveryEndpointUri { get; set; }

        /// <summary>
        /// Gets or sets the resource location.
        /// </summary>
        /// <value>The resource location.</value>
        public string ResourceLocation { get; set; }

        /// <summary>
        /// Gets or sets the service location.
        /// </summary>
        /// <value>The service location.</value>
        public string ServiceLocation { get; set; }

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the management endpoint URI.
        /// </summary>
        /// <value>The management endpoint URI.</value>
        public string ManagementEndpointUri { get; set; }

        /// <summary>
        /// Gets or sets the monitoring endpoint URI.
        /// </summary>
        /// <value>The monitoring endpoint URI.</value>
        public string MonitoringEndpointUri { get; set; }

        /// <summary>
        /// Gets or sets the monitoring configuration.
        /// </summary>
        /// <value>The monitoring configuration.</value>
        public string MonitoringConfiguration { get; set; }

        /// <summary>
        /// Gets the current FQDN of the server as observed by AFS.
        /// </summary>
        /// <value>The FQDN of the server.</value>
        public string ServerName { get; internal set; }

        /// <summary>
        /// Gets the Application Id.
        /// </summary>
        public string ApplicationId{ get; internal set; }

        /// <summary>
        /// Identity of the server
        /// </summary>
        public bool? Identity { get; internal set; }

        /// <summary>
        /// Latst Application Id
        /// </summary>
        public string LatestApplicationId { get; internal set; }

        /// <summary>
        /// Active Auth type.
        /// </summary>
        public string ActiveAuthType { get; internal set; }
    }
}