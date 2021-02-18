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
<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
=======
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;
using System.Linq;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightManagementClient
    {
        public AzureHdInsightManagementClient(IAzureContext context)
        {
<<<<<<< HEAD
            HdInsightManagementClient = AzureSession.Instance.ClientFactory.CreateClient<HDInsightManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
=======
            HdInsightManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<HDInsightManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightManagementClient() { }

        private IHDInsightManagementClient HdInsightManagementClient { get; set; }

<<<<<<< HEAD
        public virtual ClusterGetResponse CreateNewCluster(string resourceGroupName, string clusterName, ClusterCreateParameters parameters)
        {
            return HdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, parameters);
=======
        public virtual Cluster CreateCluster(string resourceGroupName, string clusterName, ClusterCreateParametersExtended createParams)
        {
            return HdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, createParams);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public virtual List<Cluster> GetCluster(string resourceGroupName, string clusterName)
        {
            var result = new List<Cluster>();
            if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(clusterName))
            {
<<<<<<< HEAD
                result.AddRange(ListClusters().Clusters);
            }
            else if (string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters(resourceGroupName).Clusters);
=======
                result.AddRange(ListClusters());
            }
            else if (string.IsNullOrEmpty(clusterName))
            {
                result.AddRange(ListClusters(resourceGroupName));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                    result.Add(getresponse.Cluster);
=======
                    result.Add(getresponse);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                }
            }
            return result;
        }

<<<<<<< HEAD
        public virtual ClusterListResponse ListClusters()
        {
            return HdInsightManagementClient.Clusters.List();
        }

        public virtual ClusterListResponse ListClusters(string resourceGroupName)
        {
            return HdInsightManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
        }

        public virtual ClusterGetResponse Get(string resourceGroupName, string clusterName)
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            return HdInsightManagementClient.Clusters.Get(resourceGroupName, clusterName);
        }

<<<<<<< HEAD
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

        public virtual OperationResource UpdateGatewayCredential(string resourceGroupName, string clusterName, HttpSettingsParameters httpSettings)
        {
            return HdInsightManagementClient.Clusters.UpdateGatewaySettings(resourceGroupName, clusterName, httpSettings);
        }

        public virtual HttpConnectivitySettings GetGatewaySettings(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.GetGatewaySettings(resourceGroupName, clusterName);
        }

        public virtual ClusterListConfigurationsResponse ListConfigurations(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.ListConfigurations(resourceGroupName, clusterName);
        }

        public virtual OperationResource ConfigureRdp(string resourceGroupName, string clusterName, RDPSettingsParameters rdpSettings)
        {
            return HdInsightManagementClient.Clusters.ConfigureRdpSettings(resourceGroupName, clusterName, rdpSettings);
        }

        public virtual CapabilitiesResponse GetCapabilities(string location)
        {
            return HdInsightManagementClient.Clusters.GetCapabilities(location);
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
            return HdInsightManagementClient.Clusters.GetClusterConfigurations(
                resourceGroupName,
                clusterName,
                configurationName).Configuration;
        }

        public virtual OperationResource EnableOMS(string resourceGroupName, string clusterName, ClusterMonitoringRequest clusterMonitoringParameters)
        {
            return HdInsightManagementClient.Clusters.EnableMonitoring(resourceGroupName, clusterName, clusterMonitoringParameters);
        }

        public virtual OperationResource DisableOMS(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.DisableMonitoring(resourceGroupName, clusterName);
        }

        public virtual ClusterMonitoringResponse GetOMS(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Clusters.GetMonitoringStatus(resourceGroupName, clusterName);
=======
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

        public virtual IList<HostInfo> GetHosts(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.VirtualMachines.ListHosts(resourceGroupName, clusterName);
        }

        public virtual void RestartHosts(string resourceGroupName, string clusterName, IList<string> hosts)
        {
            HdInsightManagementClient.VirtualMachines.RestartHosts(resourceGroupName, clusterName, hosts);
        }

        public virtual void UpdateAutoScaleConfiguration(string resourceGroupName, string clusterName, AutoscaleConfigurationUpdateParameter autoscaleConfigurationUpdateParameter)
        {
            HdInsightManagementClient.Clusters.UpdateAutoScaleConfiguration(resourceGroupName, clusterName, autoscaleConfigurationUpdateParameter);
        }

        private void ResetClusterIdentity(ClusterCreateParametersExtended createParams, string aadAuthority, string dataLakeAudience)
        {
            var configuation = (Dictionary<string, Dictionary<string, string>>)createParams.Properties.ClusterDefinition.Configurations;
            Dictionary<string, string> clusterIdentity;
            if(!configuation.TryGetValue("clusterIdentity", out clusterIdentity))
            {
                return;
            }
            clusterIdentity["clusterIdentity.resourceUri"]=dataLakeAudience;

            string aadTenantIdWithUrl;
            clusterIdentity.TryGetValue("clusterIdentity.aadTenantId", out aadTenantIdWithUrl);

            const string defaultPubliCloudAadAuthority= "https://login.windows.net/";
            string newAadTenantIdWithUrl = aadTenantIdWithUrl?.Replace(defaultPubliCloudAadAuthority, aadAuthority);
            clusterIdentity["clusterIdentity.aadTenantId"]=newAadTenantIdWithUrl;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
