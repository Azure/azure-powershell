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

using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSCluster : Cluster
    {
        public PSCluster(Cluster cluster)
            : base(
                  location: cluster.Location,
                  id: cluster.Id,
                  name: cluster.Name,
                  type: cluster.Type,
                  tags: cluster.Tags,
                  availableClusterVersions: cluster.AvailableClusterVersions,
                  clusterId: cluster.ClusterId,
                  clusterState: cluster.ClusterState,
                  clusterEndpoint: cluster.ClusterEndpoint,
                  clusterCodeVersion: cluster.ClusterCodeVersion,
                  certificate: cluster.Certificate,
                  reliabilityLevel: cluster.ReliabilityLevel,
                  upgradeMode: cluster.UpgradeMode,
                  clientCertificateThumbprints: cluster.ClientCertificateThumbprints,
                  clientCertificateCommonNames: cluster.ClientCertificateCommonNames,
                  fabricSettings: cluster.FabricSettings,
                  reverseProxyCertificate: cluster.ReverseProxyCertificate,
                  managementEndpoint: cluster.ManagementEndpoint,
                  nodeTypes: cluster.NodeTypes,
                  provisioningState: cluster.ProvisioningState,
                  vmImage: cluster.VmImage,
                  diagnosticsStorageAccountConfig: cluster.DiagnosticsStorageAccountConfig,
                  upgradeDescription: cluster.UpgradeDescription
                )
        {
        }
    }
}
