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
    /// Local server information discovered through the Azure File Sync agent.
    /// This is not an Azure resource; it is read locally through the COM management interface.
    /// </summary>
    public class PSLocalStorageSyncServer
    {
        /// <summary>
        /// Gets or sets the local server identifier.
        /// </summary>
        public Guid ServerId { get; set; }

        /// <summary>
        /// Gets or sets the current machine name.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the server role, either Standalone or ClusterNode.
        /// </summary>
        public string ServerRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the server is part of a failover cluster.
        /// </summary>
        public bool IsInCluster { get; set; }

        /// <summary>
        /// Gets or sets the cluster identifier when the server is a cluster node.
        /// </summary>
        public Guid? ClusterId { get; set; }

        /// <summary>
        /// Gets or sets the cluster name when the server is a cluster node.
        /// </summary>
        public string ClusterName { get; set; }

        /// <summary>
        /// Gets or sets the application identifier of the server system-assigned managed identity.
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the agent version reported by the local Azure File Sync agent.
        /// </summary>
        public string AgentVersion { get; set; }

        /// <summary>
        /// Gets or sets the local server operating system version.
        /// </summary>
        public string ServerOSVersion { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier of the server system-assigned managed identity.
        /// </summary>
        public Guid? TenantId { get; set; }
    }
}
