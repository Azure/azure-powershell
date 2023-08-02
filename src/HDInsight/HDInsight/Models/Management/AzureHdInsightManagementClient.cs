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
using Azure.ResourceManager.HDInsight;
using Azure.ResourceManager.HDInsight.Models;
using System.Collections.Generic;
using Azure.ResourceManager;
using System;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightManagementClient
    {
        public AzureHdInsightManagementClient(IAzureContext context)
        {
            HdInsightManagementClient = new ArmClient(new AzurePowerShellCredential(), context.Subscription.Id.ToString());
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightManagementClient() { }

        private ArmClient HdInsightManagementClient { get; set; }

        //private ResourceIdentifier SubscriptionId { get; set; }

        public virtual HDInsightClusterData CreateCluster(string resourceGroupName, string clusterName, HDInsightClusterCreateOrUpdateContent createParams)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            ArmOperation<HDInsightClusterResource> armOperation = resourceGroup.GetHDInsightClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, createParams).GetAwaiter().GetResult();
            return armOperation.Value.Data;
        }

        public virtual List<HDInsightClusterData> GetCluster(string resourceGroupName, string clusterName)
        {
            var result = new List<HDInsightClusterData>();
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

        public virtual IList<HDInsightClusterData> ListClusters()
        {
            var toReturn = new List<HDInsightClusterData>();
            IEnumerator<HDInsightClusterResource> enumerator = HdInsightManagementClient.GetDefaultSubscription().GetHDInsightClusters().GetEnumerator();

            try
            {
                while (enumerator.MoveNext())
                {
                    toReturn.Add(enumerator.Current.Data);
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
            }

            return toReturn;
        }

        public virtual IList<HDInsightClusterData> ListClusters(string resourceGroupName)
        {
            var toReturn = new List<HDInsightClusterData>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            Pageable<HDInsightClusterResource> clusters = resourceGroup.GetHDInsightClusters().GetAll();

            foreach(HDInsightClusterResource cluster in clusters)
            {
                toReturn.Add(cluster.Data);
            }

            return toReturn;
        }

        public virtual HDInsightClusterData Get(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            return resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value.Data;
        }

        public virtual void ResizeCluster(string resourceGroupName, string clusterName, HDInsightClusterResizeContent resizeParams)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.ResizeAsync(WaitUntil.Completed, HDInsightRoleName.Workernode, resizeParams).GetAwaiter().GetResult();
        }

        public virtual void ExecuteScriptActions(string resourceGroupName, string clusterName, ExecuteScriptActionContent executeScriptActionParameters)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.ExecuteScriptActionsAsync(WaitUntil.Completed, executeScriptActionParameters).GetAwaiter().GetResult();
        }

        public virtual RuntimeScriptActionDetail GetScriptExecutionDetail(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetScriptActionExecutionDetailAsync(scriptExecutionId.ToString()).GetAwaiter().GetResult().Value;
        }

        public virtual IList<RuntimeScriptActionDetail> ListPersistedScripts(string resourceGroupName, string clusterName)
        {
            var toReturn = new List<RuntimeScriptActionDetail>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            Pageable<RuntimeScriptActionDetail> runtimeScriptActionDetails = cluster.GetScriptActions();

            foreach (var item in runtimeScriptActionDetails)
            {
                toReturn.Add(item);
            }
            return toReturn;
        }

        public virtual List<RuntimeScriptActionDetail> ListScriptExecutionHistory(string resourceGroupName, string clusterName)
        {
            var toReturn = new List<RuntimeScriptActionDetail>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            Pageable<RuntimeScriptActionDetail> runtimeScriptActionDetails = cluster.GetScriptExecutionHistories();
            foreach (var item in runtimeScriptActionDetails)
            {
                toReturn.Add(item);
            }

            return toReturn;
        }

        public virtual void DeletePersistedScript(string resourceGroupName, string clusterName, string scriptName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.DeleteScriptActionAsync(scriptName).GetAwaiter().GetResult();
        }

        public virtual void PromoteScript(string resourceGroupName, string clusterName, long scriptExecutionId)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.PromoteScriptExecutionHistoryAsync(scriptExecutionId.ToString()).GetAwaiter().GetResult();
        }

        public virtual void DeleteClusterAsync(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.DeleteAsync(WaitUntil.Completed).GetAwaiter().GetResult();
        }

        public virtual void UpdateGatewayCredential(string resourceGroupName, string clusterName, HDInsightClusterUpdateGatewaySettingsContent updateGatewaySettingsParameters)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.UpdateGatewaySettingsAsync(WaitUntil.Completed, updateGatewaySettingsParameters).GetAwaiter().GetResult();
        }

        public virtual HDInsightClusterGatewaySettings GetGatewaySettings(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetGatewaySettingsAsync().GetAwaiter().GetResult().Value;
        }

        public virtual HDInsightCapabilitiesResult GetProperties(string location)
        {
            return HdInsightManagementClient.GetDefaultSubscriptionAsync().GetAwaiter().GetResult().GetHDInsightCapabilitiesAsync(location).GetAwaiter().GetResult();
        }

        public virtual HDInsightClusterConfigurations ListConfigurations(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetConfigurationAsync().GetAwaiter().GetResult().Value;
        }

        public virtual IReadOnlyDictionary<string, string> GetClusterConfigurations(string resourceGroupName, string clusterName, string configurationName)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(resourceGroupName) ||
                string.IsNullOrWhiteSpace(clusterName) ||
                string.IsNullOrWhiteSpace(configurationName))
            {
                return properties;
            }

            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetConfigurationAsync(configurationName).GetAwaiter().GetResult().Value;
        }

        public virtual void EnableMonitoring(string resourceGroupName, string clusterName, HDInsightClusterEnableClusterMonitoringContent clusterMonitoringParameters)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.EnableClusterMonitoringExtensionAsync(WaitUntil.Completed, clusterMonitoringParameters).GetAwaiter().GetResult();
        }

        public virtual void DisableMonitoring(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.DisableClusterMonitoringExtensionAsync(WaitUntil.Completed).GetAwaiter().GetResult();
        }

        public virtual HDInsightClusterExtensionStatus GetMonitoring(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetClusterMonitoringExtensionStatusAsync().GetAwaiter().GetResult().Value;
        }

        public virtual void EnableAzureMonitor(string resourceGroupName, string clusterName, HDInsightAzureMonitorExtensionEnableContent azureMonitorRequestParameters)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.EnableAzureMonitorExtensionAsync(WaitUntil.Completed, azureMonitorRequestParameters).GetAwaiter().GetResult();
        }

        public virtual void DisableAzureMonitor(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.DisableAzureMonitorExtensionAsync(WaitUntil.Completed).GetAwaiter().GetResult();
        }

        public virtual HDInsightAzureMonitorExtensionStatus GetAzureMonitor(string resourceGroupName, string clusterName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetAzureMonitorExtensionStatusAsync().GetAwaiter().GetResult().Value;
        }

        public virtual void RotateDiskEncryptionKey(string resourceGroupName, string clusterName, HDInsightClusterDiskEncryptionContent parameters)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.RotateDiskEncryptionKeyAsync(WaitUntil.Completed, parameters).GetAwaiter().GetResult();
        }

        public virtual IList<HDInsightClusterHostInfo> GetHosts(string resourceGroupName, string clusterName)
        {
            var toReturn = new List<HDInsightClusterHostInfo>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            Pageable<HDInsightClusterHostInfo> clusterHostInfos = cluster.GetVirtualMachineHosts();
            foreach (var item in clusterHostInfos)
            {
                toReturn.Add(item);
            }

            return toReturn;
        }

        public virtual void RestartHosts(string resourceGroupName, string clusterName, IList<string> hosts)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.RestartVirtualMachineHostsAsync(WaitUntil.Completed, hosts).GetAwaiter().GetResult();
        }

        public virtual void UpdateAutoScaleConfiguration(string resourceGroupName, string clusterName, HDInsightAutoScaleConfigurationUpdateContent autoscaleConfigurationUpdateParameter)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.UpdateAutoScaleConfigurationAsync(WaitUntil.Completed, HDInsightRoleName.Workernode, autoscaleConfigurationUpdateParameter).GetAwaiter().GetResult();
        }

        public virtual HDInsightBillingSpecsListResult ListBillingSpecs(string location)
        {
            return HdInsightManagementClient.GetDefaultSubscription().GetHDInsightBillingSpecsAsync(location).GetAwaiter().GetResult();
        }

        public virtual IList<HDInsightPrivateLinkResourceData> GetPrivateLinkResources(string resourceGroupName, string clusterName, string privateLinkResourceName)
        {
            var toReturn = new List<HDInsightPrivateLinkResourceData>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            Pageable<HDInsightPrivateLinkResource> privateLinkResources = cluster.GetHDInsightPrivateLinkResources().GetAll();

            foreach (var item in privateLinkResources)
            {
                toReturn.Add(item.Data);
            }

            return toReturn;
        }

        public virtual IList<HDInsightPrivateEndpointConnectionData> GetPrivateEndpointConnections(string resourceGroupName, string clusterName, string privateEndpointConnectionName)
        {
            var toReturn = new List<HDInsightPrivateEndpointConnectionData>();
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            Pageable<HDInsightPrivateEndpointConnectionResource> privateEndpointConnectionResources = cluster.GetHDInsightPrivateEndpointConnections().GetAll();
            foreach (var item in privateEndpointConnectionResources)
            {
                toReturn.Add(item.Data);
            }

            return toReturn;
        }

        public virtual void DeletePrivateEndpointConnection(string resourceGroupName, string clusterName, string privateEndpointConnectionName)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            cluster.GetHDInsightPrivateEndpointConnections().GetAsync(privateEndpointConnectionName).GetAwaiter().GetResult().Value.DeleteAsync(WaitUntil.Completed).GetAwaiter().GetResult();
        }

        public virtual HDInsightPrivateEndpointConnectionData UpdatePrivateEndpointConnection(string resourceGroupName, string clusterName, string privateEndpointConnectionName, HDInsightPrivateEndpointConnectionData privateEndpointConnectionParameter)
        {
            ResourceGroupResource resourceGroup = HdInsightManagementClient.GetDefaultSubscription().GetResourceGroups().GetAsync(resourceGroupName).GetAwaiter().GetResult();
            HDInsightClusterResource cluster = resourceGroup.GetHDInsightClusters().GetAsync(clusterName).GetAwaiter().GetResult().Value;
            return cluster.GetHDInsightPrivateEndpointConnections().CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnectionName, privateEndpointConnectionParameter).GetAwaiter().GetResult().Value.Data;

        }
    }
}
