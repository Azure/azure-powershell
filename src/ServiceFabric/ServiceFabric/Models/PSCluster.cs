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
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSCluster : Cluster
    {
        public string PSClusterString { get { return this.ToString(); } }

        public PSCluster(Cluster cluster)
            : base(
                  addOnFeatures: cluster.AddOnFeatures,
                  applicationTypeVersionsCleanupPolicy: cluster.ApplicationTypeVersionsCleanupPolicy,
                  availableClusterVersions: cluster.AvailableClusterVersions,
                  azureActiveDirectory: cluster.AzureActiveDirectory,
                  certificate: cluster.Certificate,
                  certificateCommonNames: cluster.CertificateCommonNames,
                  clientCertificateCommonNames: cluster.ClientCertificateCommonNames,
                  clientCertificateThumbprints: cluster.ClientCertificateThumbprints,
                  clusterCodeVersion: cluster.ClusterCodeVersion,
                  clusterEndpoint: cluster.ClusterEndpoint,
                  clusterId: cluster.ClusterId,
                  clusterState: cluster.ClusterState,
                  diagnosticsStorageAccountConfig: cluster.DiagnosticsStorageAccountConfig,
                  enableHttpGatewayExclusiveAuthMode: cluster.EnableHttpGatewayExclusiveAuthMode,
                  etag: cluster.Etag,
                  eventStoreServiceEnabled: cluster.EventStoreServiceEnabled,
                  fabricSettings: cluster.FabricSettings,
                  id: cluster.Id,
                  infrastructureServiceManager: cluster.InfrastructureServiceManager,
                  location: cluster.Location,
                  managementEndpoint: cluster.ManagementEndpoint,
                  name: cluster.Name,
                  nodeTypes: cluster.NodeTypes,
                  notifications: cluster.Notifications,
                  provisioningState: cluster.ProvisioningState,
                  reliabilityLevel: cluster.ReliabilityLevel,
                  reverseProxyCertificate: cluster.ReverseProxyCertificate,
                  reverseProxyCertificateCommonNames: cluster.ReverseProxyCertificateCommonNames,
                  sfZonalUpgradeMode: cluster.SfZonalUpgradeMode,
                  tags: cluster.Tags,
                  type: cluster.Type,
                  upgradeDescription: cluster.UpgradeDescription,
                  upgradeMode: cluster.UpgradeMode,
                  upgradePauseEndTimestampUtc: cluster.UpgradePauseEndTimestampUtc,
                  upgradePauseStartTimestampUtc: cluster.UpgradePauseStartTimestampUtc,
                  upgradeWave: cluster.UpgradeWave,
                  vmImage: cluster.VMImage,
                  vmssZonalUpgradeMode: cluster.VmssZonalUpgradeMode,
                  waveUpgradePaused: cluster.WaveUpgradePaused)
        {
        }

        public override string ToString()
        {
            return this.ToString(this, "");
        }

        private string ToString(object objects, string space)
        {
            const string Tab = "    ";
            var sb = new StringBuilder();

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(objects))
            {
                var name = descriptor.Name;
                if (name.Equals("PSClusterString", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var value = descriptor.GetValue(objects);
                if (value is IList)
                {
                    sb.AppendLine($"{space}{name} :");
                    var list = value as IList;
                    foreach (var item in list)
                    {
                        var spacing = space + Tab;
                        if (item is NodeTypeDescription)
                        {
                            sb.AppendLine($"{spacing}{item.GetType().Name} :");
                            spacing += Tab;
                        }

                        var innerString = ToString(item, spacing);
                        sb.Append(innerString);
                    }
                }
                else if (value is IDictionary)
                {
                    sb.AppendLine($"{space}{name} :");
                    var dictionary = value as IDictionary;
                    foreach (var k in dictionary.Keys)
                    {
                        sb.AppendLine($"{space + Tab}{k} : {dictionary[k]}");
                    }
                }
                else if (value is CertificateDescription ||
                         value is AzureActiveDirectory ||
                         value is DiagnosticsStorageAccountConfig ||
                         value is ClusterUpgradePolicy ||
                         value is EndpointRangeDescription ||
                         value is ClusterHealthPolicy ||
                         value is ClusterUpgradeDeltaHealthPolicy ||
                         value is NodeTypeDescription)
                {
                    sb.AppendLine($"{space}{name} :");
                    var innerString = ToString(value, space + Tab);
                    sb.Append(innerString);
                }
                else
                {
                    sb.AppendLine($"{space}{name} : {value}");
                }
            }

            return sb.ToString();
        }
    }
}
