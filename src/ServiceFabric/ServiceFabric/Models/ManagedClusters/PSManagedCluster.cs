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

using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSManagedCluster : ManagedCluster
    {
        public PSManagedCluster(ManagedCluster cluster)
            : base(location: cluster.Location,
                   id: cluster.Id,
                   name: cluster.Name,
                   type: cluster.Type,
                   tags: cluster.Tags,
                   etag: cluster.Etag,
                   clusterId: cluster.ClusterId,
                   addonFeatures: cluster.AddonFeatures,
                   clusterUpgradeCadence: cluster.ClusterUpgradeCadence,
                   clusterUpgradeMode: cluster.ClusterUpgradeMode,
                   clusterCodeVersion: cluster.ClusterCodeVersion,
                   provisioningState: cluster.ProvisioningState,
                   fabricSettings: cluster.FabricSettings,
                   azureActiveDirectory: cluster.AzureActiveDirectory,
                   clients: cluster.Clients,
                   networkSecurityRules: cluster.NetworkSecurityRules,
                   loadBalancingRules: cluster.LoadBalancingRules,
                   adminPassword: cluster.AdminPassword,
                   adminUserName: cluster.AdminUserName,
                   httpGatewayConnectionPort: cluster.HttpGatewayConnectionPort,
                   clientConnectionPort: cluster.ClientConnectionPort,
                   clusterCertificateThumbprints: cluster.ClusterCertificateThumbprints,
                   clusterState: cluster.ClusterState,
                   ipv4Address: cluster.Ipv4Address,
                   fqdn: cluster.Fqdn,
                   dnsName: cluster.DnsName,
                   applicationTypeVersionsCleanupPolicy: cluster.ApplicationTypeVersionsCleanupPolicy,
                   sku: cluster.Sku,
                   zonalResiliency: cluster.ZonalResiliency,
                   allowRdpAccess: cluster.AllowRdpAccess,
                   enableAutoOSUpgrade: cluster.EnableAutoOSUpgrade)
        {
        }
    }
}
