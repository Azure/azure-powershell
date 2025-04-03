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
using System.Linq;

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

        public virtual Cluster CreateCluster(string resourceGroupName, string clusterName, ClusterCreateParametersExtended createParams)
        {
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

        public virtual void UpdateCluster(string resourceGroupName, string clusterName, Dictionary<string,string> tags, ClusterIdentity identity)
        {
            HdInsightManagementClient.Clusters.Update(resourceGroupName, clusterName, tags, identity);
        }

        public virtual void ResizeCluster(string resourceGroupName, string clusterName, ClusterResizeParameters resizeParams)
        {
            HdInsightManagementClient.Clusters.Resize(resourceGroupName, clusterName, resizeParams?.TargetInstanceCount);
        }

        public virtual void ExecuteScriptActions(string resourceGroupName, string clusterName, ExecuteScriptActionParameters executeScriptActionParameters)
        {
            HdInsightManagementClient.Clusters.ExecuteScriptActions(resourceGroupName, clusterName, executeScriptActionParameters.PersistOnSuccess, executeScriptActionParameters?.ScriptActions);
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
            HdInsightManagementClient.Extensions.EnableMonitoring(resourceGroupName, clusterName, clusterMonitoringParameters?.WorkspaceId, clusterMonitoringParameters?.PrimaryKey);
        }

        public virtual void DisableMonitoring(string resourceGroupName, string clusterName)
        {
            HdInsightManagementClient.Extensions.DisableMonitoring(resourceGroupName, clusterName);
        }

        public virtual ClusterMonitoringResponse GetMonitoring(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Extensions.GetMonitoringStatus(resourceGroupName, clusterName);
        }

        public virtual void EnableAzureMonitor(string resourceGroupName, string clusterName, AzureMonitorRequest azureMonitorRequestParameters)
        {
            HdInsightManagementClient.Extensions.EnableAzureMonitor(resourceGroupName, clusterName, azureMonitorRequestParameters);
        }

        public virtual void EnableAzureMonitorAgent(string resourceGroupName, string clusterName, AzureMonitorRequest azureMonitorRequestParameters)
        {
            HdInsightManagementClient.Extensions.EnableAzureMonitorAgent(resourceGroupName, clusterName, azureMonitorRequestParameters);
        }

        public virtual void DisableAzureMonitor(string resourceGroupName, string clusterName)
        {
            HdInsightManagementClient.Extensions.DisableAzureMonitor(resourceGroupName, clusterName);
        }

        public virtual void DisableAzureMonitorAgent(string resourceGroupName, string clusterName)
        {
            HdInsightManagementClient.Extensions.DisableAzureMonitorAgent(resourceGroupName, clusterName);
        }

        public virtual AzureMonitorResponse GetAzureMonitor(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Extensions.GetAzureMonitorStatus(resourceGroupName, clusterName);
        }

        public virtual AzureMonitorResponse GetAzureMonitorAgent(string resourceGroupName, string clusterName)
        {
            return HdInsightManagementClient.Extensions.GetAzureMonitorAgentStatus(resourceGroupName, clusterName);
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
            HdInsightManagementClient.Clusters.UpdateAutoScaleConfiguration(resourceGroupName, clusterName, autoscaleConfigurationUpdateParameter?.Autoscale);
        }

        public virtual BillingResponseListResult ListBillingSpecs(string location)
        {
            return HdInsightManagementClient.Locations.ListBillingSpecs(location);
        }

        public virtual IList<PrivateLinkResource> GetPrivateLinkResources(string resourceGroupName, string clusterName, string privateLinkResourceName)
        {
            var result = HdInsightManagementClient.PrivateLinkResources.ListByCluster(resourceGroupName, clusterName)?.Value;
            if (privateLinkResourceName != null)
            {
                result=result?.Where(item => item.Name.Equals(privateLinkResourceName))?.ToList();
            }
            return result;
        }

        public virtual IList<PrivateEndpointConnection> GetPrivateEndpointConnections(string resourceGroupName, string clusterName, string privateEndpointConnectionName)
        {
            var result = HdInsightManagementClient.PrivateEndpointConnections.ListByCluster(resourceGroupName, clusterName).ToList();
            if (privateEndpointConnectionName != null)
            {
                result = result?.Where(item => item.Name.Equals(privateEndpointConnectionName)).ToList();
            }
            return result;
        }

        public virtual void DeletePrivateEndpointConnection(string resourceGroupName, string clusterName, string privateEndpointConnectionName)
        {
            HdInsightManagementClient.PrivateEndpointConnections.Delete(resourceGroupName, clusterName, privateEndpointConnectionName);
        }

        public virtual PrivateEndpointConnection UpdatePrivateEndpointConnection(string resourceGroupName, string clusterName, string privateEndpointConnectionName, PrivateEndpointConnection privateEndpointConnectionParameter)
        {
            return HdInsightManagementClient.PrivateEndpointConnections.CreateOrUpdate(resourceGroupName, clusterName, privateEndpointConnectionName, privateEndpointConnectionParameter?.PrivateLinkServiceConnectionState);
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
        }
    }
}
