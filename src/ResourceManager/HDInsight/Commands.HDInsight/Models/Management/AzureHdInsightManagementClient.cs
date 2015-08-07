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

using System.Collections.Generic;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightManagementClient
    {
        public AzureHdInsightManagementClient(AzureContext context)
        {
            HdInsightManagementClient = AzureSession.ClientFactory.CreateClient<HDInsightManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightManagementClient() { }

        private IHDInsightManagementClient HdInsightManagementClient { get; set; }

        public virtual ClusterGetResponse CreateNewCluster(string resourceGroupName, string clusterName, ClusterCreateParameters parameters)
        {
            return HdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, parameters);
        }

        public virtual List<Cluster> GetCluster(string resourceGroupName, string clusterName)
        {
            var result = new List<Cluster>();
            if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters().Clusters);
            }
            else if (string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters(resourceGroupName).Clusters);
            }
            else if (string.IsNullOrEmpty(resourceGroupName))
            {
                return result;
            }
            else
            {
                var getresponse = Get(resourceGroupName, clusterName);
                if (getresponse != null)
                {
                    result.Add(getresponse.Cluster);   
                }
            }
            return result;
        }

        public virtual ClusterListResponse ListClusters()
        {
            return HdInsightManagementClient.Clusters.List();
        }

        public virtual ClusterListResponse ListClusters(string resourceGroupName)
        {
            return HdInsightManagementClient.Clusters.ListByResourceGroup(resourceGroupName);   
        }

        public virtual ClusterGetResponse Get(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.Get(resourceGroupName, clusterName);
        }

        public virtual HDInsightLongRunningOperationResponse ResizeCluster(string resourceGroupName, string clusterName, ClusterResizeParameters resizeParams)
        {
            return HdInsightManagementClient.Clusters.Resize(resourceGroupName, clusterName, resizeParams);
        }

        public virtual ClusterGetResponse DeleteCluster(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.Delete(resourceGroupName, clusterName);
        }

        public virtual HDInsightLongRunningOperationResponse ConfigureHttp(string resourceGroupName, string clusterName, HttpSettingsParameters httpSettings)
        {
            return HdInsightManagementClient.Clusters.ConfigureHttpSettings(resourceGroupName, clusterName, httpSettings);
        }

        public virtual HttpConnectivitySettings GetConnectivitySettings(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.GetConnectivitySettings(resourceGroupName, clusterName);
        }

        public virtual HDInsightLongRunningOperationResponse ConfigureRdp(string resourceGroupName, string clusterName, RDPSettingsParameters rdpSettings)
        {
            return HdInsightManagementClient.Clusters.ConfigureRdpSettings(resourceGroupName, clusterName, rdpSettings);
        }

        public virtual CapabilitiesResponse GetCapabilities(string location)
        {
            return HdInsightManagementClient.Clusters.GetCapabilities(location);
        }
    }
}
