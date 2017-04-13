using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PsCluster : Cluster
    {
        public PsCluster(Cluster cluster)
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
