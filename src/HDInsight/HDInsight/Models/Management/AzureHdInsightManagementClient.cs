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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightManagementClient
    {
        public AzureHdInsightManagementClient(IAzureContext context)
        {
            HdInsightManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<HDInsightManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightManagementClient() { }

        private IHDInsightManagementClient HdInsightManagementClient { get; set; }

        public virtual Cluster CreateNewCluster(string resourceGroupName, string clusterName, OSType osType, ClusterCreateParameters parameters, string minSupportedTlsVersion=default(string))
        {
            var createParams = CreateParametersConverter.GetExtendedClusterCreateParameters(clusterName, parameters);
            createParams.Properties.OsType = osType;
            createParams.Properties.MinSupportedTlsVersion = minSupportedTlsVersion;
            return HdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, createParams);
        }

        public virtual List<Cluster> GetCluster(string resourceGroupName, string clusterName)
        {
            var result = new List<Cluster>();
            if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters());
            }
            else if (string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters(resourceGroupName));
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
                    result.Add(getresponse);
                }
            }
            return result;
        }

        public virtual IList<Cluster> ListClusters()
        {
            var toReturn = new List<Cluster>();
            var response = HdInsightManagementClient.Clusters.List();
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = HdInsightManagementClient.Clusters.ListNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public virtual IList<Cluster> ListClusters(string resourceGroupName)
        {
            var toReturn = new List<Cluster>();
            var response = HdInsightManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = HdInsightManagementClient.Clusters.ListByResourceGroupNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public virtual Cluster Get(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.Get(resourceGroupName, clusterName);
        }

        public virtual void ResizeCluster(string resourceGroupName, string clusterName, ClusterResizeParameters resizeParams)
        {
            HdInsightManagementClient.Clusters.Resize(resourceGroupName, clusterName, resizeParams);
        }

        public virtual void ExecuteScriptActions(string resourceGroupName, string clusterName, ExecuteScriptActionParameters executeScriptActionParameters)
        {
            HdInsightManagementClient.Clusters.ExecuteScriptActions(resourceGroupName, clusterName, executeScriptActionParameters);
        }

        public virtual RuntimeScriptActionDetail GetScriptExecutionDetail(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            return HdInsightManagementClient.ScriptActions.GetExecutionDetail(resourceGroupName, clusterName, scriptExecutionId.ToString());
        }

        public virtual IList<RuntimeScriptActionDetail> ListPersistedScripts(string resourceGroupName, string clusterName)
        {
            var toReturn = new List<RuntimeScriptActionDetail>();
            var response = HdInsightManagementClient.ScriptActions.ListByCluster(resourceGroupName, clusterName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = HdInsightManagementClient.ScriptActions.ListByClusterNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public virtual List<RuntimeScriptActionDetail> ListScriptExecutionHistory(string resourceGroupName, string clusterName)
        {
            var toReturn = new List<RuntimeScriptActionDetail>();
            var response = HdInsightManagementClient.ScriptExecutionHistory.ListByCluster(resourceGroupName, clusterName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = HdInsightManagementClient.ScriptExecutionHistory.ListByClusterNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public virtual void DeletePersistedScript(string resourceGroupName, string clusterName, string scriptName)
        {
            HdInsightManagementClient.ScriptActions.Delete(resourceGroupName, clusterName, scriptName);
        }

        public virtual void PromoteScript(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            HdInsightManagementClient.ScriptExecutionHistory.Promote(resourceGroupName, clusterName, scriptExecutionId.ToString());
        }

        public virtual void DeleteCluster(string resourceGroupName, string clusterName)
        {
            HdInsightManagementClient.Clusters.Delete(resourceGroupName, clusterName);
        }

        public virtual void UpdateGatewayCredential(string resourceGroupName, string clusterName, UpdateGatewaySettingsParameters updateGatewaySettingsParameters)
        {
            HdInsightManagementClient.Clusters.UpdateGatewaySettings(resourceGroupName, clusterName, updateGatewaySettingsParameters);
        }

        public virtual GatewaySettings GetGatewaySettings(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.GetGatewaySettings(resourceGroupName, clusterName);
        }

        public virtual CapabilitiesResult GetProperties(string location)
        {
            return HdInsightManagementClient.Locations.GetCapabilities(location);
        }

        public virtual ClusterConfigurations ListConfigurations(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Configurations.List(resourceGroupName, clusterName);
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

            return HdInsightManagementClient.Configurations.Get(
                resourceGroupName,
                clusterName,
                configurationName);
        }

        public virtual void EnableMonitoring(string resourceGroupName, string clusterName, ClusterMonitoringRequest clusterMonitoringParameters)
        {
            HdInsightManagementClient.Extensions.EnableMonitoring(resourceGroupName, clusterName, clusterMonitoringParameters);
        }

        public virtual void DisableMonitoring(string resourceGroupName, string clusterName)
        {
            HdInsightManagementClient.Extensions.DisableMonitoring(resourceGroupName, clusterName);
        }

        public virtual ClusterMonitoringResponse GetMonitoring(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Extensions.GetMonitoringStatus(resourceGroupName, clusterName);
        }

        public virtual void RotateDiskEncryptionKey(string resourceGroupName, string clusterName, ClusterDiskEncryptionParameters parameters)
        {
            HdInsightManagementClient.Clusters.RotateDiskEncryptionKey(resourceGroupName, clusterName, parameters);
        }
    }
}
