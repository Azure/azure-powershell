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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Azure.Commands.Kusto.Properties;
using Microsoft.Azure.Management.Kusto;

namespace Microsoft.Azure.Commands.Kusto.Models
{
    public class KustoClient
    {
        private readonly KustoManagementClient _client;
        private readonly Guid _subscriptionId;
        private readonly string _currentUser;

        public KustoClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.GetId();
            _client = AzureSession.Instance.ClientFactory.CreateArmClient<KustoManagementClient>(
                context,
                AzureEnvironment.Endpoint.ResourceManager);
            _currentUser = context.Account.Id;
        }

        public KustoClient()
        {
        }

        #region Cluster Related Operations

        public PSKustoCluster CreateOrUpdateCluster(string resourceGroupName,
            string clusterName,
            string location,
            string skuName = null,
            Hashtable customTags = null,
            PSKustoCluster existingCluster = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCluster(clusterName);
            }

            var tags = (customTags != null)
                ? TagsConversionHelper.CreateTagDictionary(customTags, true)
                : null;

            Cluster newOrUpdatedCluster;
            if (existingCluster != null)
            {
                var updateParameters = new ClusterUpdate();
                newOrUpdatedCluster = _client.Clusters.Update(resourceGroupName, clusterName, updateParameters);
            }
            else
            {
                newOrUpdatedCluster = _client.Clusters.CreateOrUpdate(
                    resourceGroupName,
                    clusterName,
                    new Cluster()
                    {
                        Location = location,
                        Tags = tags,
                        Sku = new AzureSku(skuName)
                    });
            }

            return new PSKustoCluster(newOrUpdatedCluster);
        }

        public void DeleteCluster(string resourceGroupName, string clusterName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCluster(clusterName);
            }

            _client.Clusters.Delete(resourceGroupName, clusterName);
        }

        public bool CheckIfClusterExists(string resourceGroupName, string clusterName, out PSKustoCluster cluster)
        {
            try
            {
                cluster = GetCluster(resourceGroupName, clusterName);
                return true;
            }
            catch (CloudException ex)
            {
                if ((ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound) || ex.Message.Contains(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, clusterName,
                    _subscriptionId)))
                {
                    cluster = null;
                    return false;
                }

                throw;
            }
        }

        public PSKustoCluster GetCluster(string resourceGroupName, string clusterName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCluster(clusterName);
            }

            return new PSKustoCluster(_client.Clusters.Get(resourceGroupName, clusterName));
        }

        public List<PSKustoCluster> ListClusters(string resourceGroupName)
        {
            var clusters = new List<PSKustoCluster>();
            var response = string.IsNullOrEmpty(resourceGroupName) ?
                _client.Clusters.List() :
                _client.Clusters.ListByResourceGroup(resourceGroupName);

            response.ToList().ForEach(capacity => clusters.Add(new PSKustoCluster(capacity)));

            return clusters;
        }

        private string GetResourceGroupByCluster(string clusterName)
        {
            try
            {
                var acctId =
                    ListClusters(null)
                        .Find(x => x.Name.Equals(clusterName, StringComparison.InvariantCultureIgnoreCase))
                        .Id;
                var rgStart = acctId.IndexOf("resourceGroups/", StringComparison.InvariantCultureIgnoreCase) + ("resourceGroups/".Length);
                var rgLength = (acctId.IndexOf("/providers/", StringComparison.InvariantCultureIgnoreCase)) - rgStart;
                return acctId.Substring(rgStart, rgLength);
            }
            catch
            {
                throw new CloudException(string.Format(Resources.FailedToDiscoverResourceGroup, clusterName, _subscriptionId));
            }
        }

        #endregion
    }
}