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

using Microsoft.Azure.Commands.StorageSync.InternalObjects;
using System;

namespace Commands.StorageSync.Interop.DataObjects
{
    /// <summary>
    /// Class ServerRegistrationData.
    /// </summary>
    public class ServerRegistrationData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the server certificate.
        /// </summary>
        /// <value>The server certificate.</value>
        public byte[] ServerCertificate { get; set; }

        /// <summary>
        /// Gets or sets the agent version.
        /// </summary>
        /// <value>The agent version.</value>
        public string AgentVersion { get; set; }

        /// <summary>
        /// Gets or sets the server os version.
        /// </summary>
        /// <value>The server os version.</value>
        public string ServerOSVersion { get; set; }

        /// <summary>
        /// Gets or sets the server role.
        /// </summary>
        /// <value>The server role.</value>
        public ServerRoleType ServerRole { get; set; }

        /// <summary>
        /// Gets or sets the cluster identifier.
        /// </summary>
        /// <value>The cluster identifier.</value>
        public Guid? ClusterId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cluster.
        /// </summary>
        /// <value>The name of the cluster.</value>
        public string ClusterName { get; set; }

        /// <summary>
        /// Gets or sets the server identifier.
        /// </summary>
        /// <value>The server identifier.</value>
        public Guid ServerId { get; set; }

        /// <summary>
        /// Server Machine Name.
        /// </summary>
        public string ServerMachineName { get; set; }

        /// <summary>
        /// Monitoring Configuration.
        /// </summary>
        public string MonitoringConfiguration { get; set; }

        /// <summary>
        /// Management Endpoint Uri
        /// </summary>
        public Uri ManagementEndpointUri { get; set; }

        /// <summary>
        /// Monitoring Endpoint Uri
        /// </summary>
        public Uri MonitoringEndpointUri { get; set; }

        /// <summary>
        /// Discovery Endpoint Uri
        /// </summary>
        public Uri DiscoveryEndpointUri { get; set; }

        /// <summary>
        /// Resource Location
        /// </summary>
        public string ResourceLocation { get; set; }

        /// <summary>
        /// Service Location
        /// </summary>
        public string ServiceLocation { get; set; }

        /// <summary>
        /// Storage Sync Service Uid
        /// </summary>
        public Guid? StorageSyncServiceUid { get; set; }

        /// <summary>
        /// Last Heart Beat
        /// </summary>
        public DateTime? LastHeartBeat { get; set; }

        /// <summary>
        /// Server Management Error Code
        /// </summary>
        public int? ServerManagementErrorCode { get; set; }

        /// <summary>
        /// Provisioning State
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Server Identity Id.
        /// </summary>
        public Guid? ApplicationId { get; set; }
    }
}
