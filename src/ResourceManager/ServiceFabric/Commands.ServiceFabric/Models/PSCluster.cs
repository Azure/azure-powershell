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

using System.Text;
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Cluster name : {0}", this.Name));
            sb.Append(string.Format("id : {0}", this.Id));
            sb.Append(string.Format("clusterId : {0}", this.ClusterId));
            sb.Append(string.Format("location : {0}", this.Location));
            sb.Append(string.Format("type : {0}", this.Type));
            sb.Append(string.Format("clusterId : {0}", this.ClusterId));
            sb.Append(string.Format("clusterState : {0}", this.ClusterState));
            sb.Append(string.Format("clusterEndpoint : {0}", this.ClusterEndpoint));
            sb.Append(string.Format("clusterCodeVersion : {0}", this.ClusterCodeVersion));
            sb.Append(string.Format("certificate : {0}", this.Certificate));
            sb.Append(string.Format("reliabilityLevel : {0}", this.ReliabilityLevel));
            sb.Append(string.Format("upgradeMode : {0}", this.UpgradeMode));
            sb.Append(string.Format("clientCertificateThumbprints : {0}", this.ClientCertificateThumbprints));
            sb.Append(string.Format("clientCertificateCommonNames : {0}", this.ClientCertificateCommonNames));
            sb.Append(string.Format("fabricSettings : {0}", this.FabricSettings));
            sb.Append(string.Format("reverseProxyCertificate : {0}", this.ReverseProxyCertificate));
            sb.Append(string.Format("managementEndpoint : {0}", this.ManagementEndpoint));
            sb.Append(string.Format("nodeTypes : {0}", this.NodeTypes));
            sb.Append(string.Format("provisioningState : {0}", this.ProvisioningState));
            sb.Append(string.Format("vmImage : {0}", this.VmImage));
            sb.Append(string.Format("diagnosticsStorageAccountConfig : {0}", this.DiagnosticsStorageAccountConfig));
            sb.Append(string.Format("upgradeDescription : {0}", this.UpgradeDescription));

            return sb.ToString(); 
        }
    }
}
