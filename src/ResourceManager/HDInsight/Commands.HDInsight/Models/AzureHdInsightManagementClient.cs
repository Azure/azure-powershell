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

        public ClusterGetResponse CreateNewCluster(string resourceGroupName, string clusterName, ClusterCreateParameters parameters)
        {
            return this.HdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, parameters);
        }

        public List<Cluster> GetCluster(string resourceGroupName, string clusterName)
        {
            var result = new List<Cluster>();
            if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(clusterName))
            {
                var listresponse = this.HdInsightManagementClient.Clusters.List();
                result.AddRange(listresponse.Clusters);
            }
            else if (string.IsNullOrEmpty(clusterName))
            {
                var listresponse = this.HdInsightManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
                result.AddRange(listresponse.Clusters);
            }
            else if (string.IsNullOrEmpty(resourceGroupName))
            {
                result.Add(this.HdInsightManagementClient.Clusters.Get(resourceGroupName, clusterName).Cluster);
            }
            return result;
        }

        public HDInsightLongRunningOperationResponse ResizeCluster(string resourceGroupName, string clusterName, ClusterResizeParameters resizeParams)
        {
            return this.HdInsightManagementClient.Clusters.Resize(resourceGroupName, clusterName, resizeParams);
        }

        public ClusterGetResponse DeleteCluster(string resourceGroupName, string clusterName)
        {
            return this.HdInsightManagementClient.Clusters.Delete(resourceGroupName, clusterName);
        }

        public HDInsightLongRunningOperationResponse ConfigureHttp(string resourceGroupName, string clusterName, HttpSettingsParameters httpSettings)
        {
            return this.HdInsightManagementClient.Clusters.ConfigureHttpSettings(resourceGroupName, clusterName, httpSettings);
        }

        public HDInsightLongRunningOperationResponse ConfigureRdp(string resourceGroupName, string clusterName, RDPSettingsParameters rdpSettings)
        {
            return this.HdInsightManagementClient.Clusters.ConfigureRdpSettings(resourceGroupName, clusterName, rdpSettings);
        }
    }
}
