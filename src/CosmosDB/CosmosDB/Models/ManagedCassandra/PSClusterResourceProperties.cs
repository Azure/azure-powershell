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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSClusterResourceProperties
    {
        PSClusterResourceProperties()
        {
        }

        public PSClusterResourceProperties(ClusterResourceProperties clusterProperties)
        {
            if(clusterProperties == null)
            {
                return;
            }

            GossipCertificates = new List<PSCertificate>();
            foreach (Certificate gossipCertificate in clusterProperties.GossipCertificates)
            {
                GossipCertificates.Add(new PSCertificate(gossipCertificate?.Pem));
            }

            ExternalGossipCertificates = new List<PSCertificate>();
            foreach (Certificate externalGossipCertificate in clusterProperties.ExternalGossipCertificates)
            {
                ExternalGossipCertificates.Add(new PSCertificate(externalGossipCertificate?.Pem));
            }

            ClientCertificates = new List<PSCertificate>();
            foreach (Certificate ClientCertificate in clusterProperties.ClientCertificates)
            {
                ClientCertificates.Add(new PSCertificate(ClientCertificate?.Pem));
            }

            RepairEnabled = clusterProperties.RepairEnabled;
            PrometheusEndpoint = new PSSeedNode(clusterProperties.PrometheusEndpoint?.IpAddress);
            HoursBetweenBackups = clusterProperties.HoursBetweenBackups;
            InitialCassandraAdminPassword = clusterProperties.InitialCassandraAdminPassword;
            AuthenticationMethod = clusterProperties.AuthenticationMethod;
            ClusterNameOverride = clusterProperties.ClusterNameOverride;
            CassandraVersion = clusterProperties.CassandraVersion;
            DelegatedManagementSubnetId = clusterProperties.DelegatedManagementSubnetId;
            RestoreFromBackupId = clusterProperties.RestoreFromBackupId;
            ProvisioningState = clusterProperties.ProvisioningState;
            ExternalSeedNodes = new List<PSSeedNode>();

            foreach (SeedNode externalSeedNode in clusterProperties.ExternalSeedNodes ?? Enumerable.Empty<SeedNode>())
            {
                ExternalSeedNodes.Add(new PSSeedNode(externalSeedNode?.IpAddress));
            }

            SeedNodes = new List<PSSeedNode>();
            foreach (SeedNode seedNode in clusterProperties.SeedNodes)
            {
                SeedNodes.Add(new PSSeedNode(seedNode?.IpAddress));
            }
        }

        //
        // Summary:
        //     Gets or sets the Gossip Certificates of Cassandra Cluster
        public IList<PSCertificate> GossipCertificates { get; set; }
        //
        // Summary:
        //     Gets or sets the External Gossip Certificates of Cassandra Cluster
        public IList<PSCertificate> ExternalGossipCertificates { get; set; }
        //
        // Summary:
        //     Gets or sets the Client Certificates of Cassandra Cluster
        public IList<PSCertificate> ClientCertificates { get; set; }
        //
        // Summary:
        //     Gets or sets RepairEnabled of Cassandra Cluster
        public bool? RepairEnabled { get; set; }
        //
        // Summary:
        //     Gets a system generated property. Prometheus endpoint.
        public PSSeedNode PrometheusEndpoint { get; }
        //
        // Summary:
        //     Gets or sets HoursBetweenBackups of Cassandra Cluster.
        public int? HoursBetweenBackups { get; set; }
        //
        // Summary:
        //      Gets or sets InitialCassandraAdminPassword of Cassandra Cluster.
        public string InitialCassandraAdminPassword { get; }
        //
        // Summary:
        //      Gets or sets AuthenticationMethod of Cassandra Cluster.
        public string AuthenticationMethod { get; }
        //
        // Summary:
        //      Gets or sets ClusterNameOverride of Cassandra Cluster.
        public string ClusterNameOverride { get; }
        //
        // Summary:
        //      Gets or sets CassandraVersion of Cassandra Cluster.
        public string CassandraVersion { get; }
        //
        // Summary:
        //      Gets or sets DelegatedManagementSubnetId of Cassandra Cluster.
        public string DelegatedManagementSubnetId { get; }
        //
        // Summary:
        //      Gets or sets AuthenticationMethod of Cassandra Cluster.
        public string RestoreFromBackupId { get; }
        //
        // Summary:
        //      Gets or sets AuthenticationMethod of Cassandra Cluster.
        public string ProvisioningState { get; }
        //
        // Summary:
        //      Gets or sets ExternalSeedNodes of Cassandra Cluster..
        public IList<PSSeedNode> ExternalSeedNodes { get; }
        //
        // Summary:
        //      Gets or sets SeedNodes of Cassandra Cluster.
        public IList<PSSeedNode> SeedNodes { get; }
    }
}