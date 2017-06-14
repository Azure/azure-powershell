﻿// ----------------------------------------------------------------------------------
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
using System.Text;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSCluster : Cluster
    {
        public string PSClusterString { get { return this.ToString(); } }

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
                    sb.AppendLine(string.Format("{0}{1} :", space, name));
                    var list = value as IList;
                    foreach (var item in list)
                    {
                        var innerString = ToString(item, space + Tab);
                        sb.Append(innerString);
                    }
                }
                else if (value is IDictionary)
                {
                    sb.AppendLine(string.Format("{0}{1} :", space, name));
                    var dic = value as IDictionary;
                    foreach (var k in dic.Keys)
                    {
                        sb.AppendLine(string.Format("{0}{1} : {2}", space + Tab, k, dic[k]));
                    }
                }
                else if (value is CertificateDescription ||
                         value is AzureActiveDirectory ||
                         value is DiagnosticsStorageAccountConfig ||
                         value is ClusterUpgradePolicy)
                {
                    var innerString = ToString(value, space + Tab);
                    sb.Append(innerString);
                }
                else
                {
                    sb.AppendLine(string.Format("{0}{1} : {2}", space, name, value));
                }
            }

            return sb.ToString();
        }
    }
}
