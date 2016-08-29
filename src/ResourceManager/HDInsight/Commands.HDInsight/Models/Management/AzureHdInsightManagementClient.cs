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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;

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

        public virtual OperationResource ResizeCluster(string resourceGroupName, string clusterName, ClusterResizeParameters resizeParams)
        {
            return HdInsightManagementClient.Clusters.Resize(resourceGroupName, clusterName, resizeParams);
        }

        public virtual OperationResource ExecuteScriptActions(string resourceGroupName, string clusterName, ExecuteScriptActionParameters executeScriptActionParameters)
        {
            return HdInsightManagementClient.Clusters.ExecuteScriptActions(resourceGroupName, clusterName, executeScriptActionParameters);
        }

        public virtual ClusterRuntimeScriptActionDetailResponse GetScriptExecutionDetail(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            return HdInsightManagementClient.Clusters.GetScriptExecutionDetail(resourceGroupName, clusterName, scriptExecutionId);
        }

        public virtual ClusterListPersistedScriptActionsResponse ListPersistedScripts(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.ListPersistedScripts(resourceGroupName, clusterName);
        }

        public virtual ClusterListRuntimeScriptActionDetailResponse ListScriptExecutionHistory(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.ListScriptExecutionHistory(resourceGroupName, clusterName);
        }

        public virtual AzureOperationResponse DeletePersistedScript(string resourceGroupName, string clusterName, string scriptName)
        {
            return HdInsightManagementClient.Clusters.DeletePersistedScript(resourceGroupName, clusterName, scriptName);
        }

        public virtual AzureOperationResponse PromoteScript(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            return HdInsightManagementClient.Clusters.PromoteScript(resourceGroupName, clusterName, scriptExecutionId);
        }

        public virtual OperationResource DeleteCluster(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.Delete(resourceGroupName, clusterName);
        }

        public virtual OperationResource ConfigureHttp(string resourceGroupName, string clusterName, HttpSettingsParameters httpSettings)
        {
            return HdInsightManagementClient.Clusters.ConfigureHttpSettings(resourceGroupName, clusterName, httpSettings);
        }

        public virtual HttpConnectivitySettings GetConnectivitySettings(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.GetConnectivitySettings(resourceGroupName, clusterName);
        }

        public virtual OperationResource ConfigureRdp(string resourceGroupName, string clusterName, RDPSettingsParameters rdpSettings)
        {
            return HdInsightManagementClient.Clusters.ConfigureRdpSettings(resourceGroupName, clusterName, rdpSettings);
        }

        public virtual CapabilitiesResponse GetCapabilities(string location)
        {
            return HdInsightManagementClient.Clusters.GetCapabilities(location);
        }

        public virtual IDictionary<string, string> GetClusterConfigurations(string resourceGroupName, string clusterName, string configurationName)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(resourceGroupName) ||
                string.IsNullOrWhiteSpace(clusterName) ||
                string.IsNullOrWhiteSpace(configurationName))
            {
                return properties;
            }

            return HdInsightManagementClient.Clusters.GetClusterConfigurations(
                resourceGroupName,
                clusterName,
                configurationName).Configuration;
        }
    }
}
