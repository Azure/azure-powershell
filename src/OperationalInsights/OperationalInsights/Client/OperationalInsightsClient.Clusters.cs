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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Rest;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSCluster GetPSCluster(string resourceGroupName, string clusterName)
        {
            return new PSCluster(this.OperationalInsightsManagementClient.Clusters.Get(resourceGroupName, clusterName));
        }

        public IList<PSCluster> ListPSClusters(string resourceGroupName)
        {
            IPage<Cluster> list = string.IsNullOrWhiteSpace(resourceGroupName)
                ? this.OperationalInsightsManagementClient.Clusters.List()
                : this.OperationalInsightsManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
            
            return list.Select(item => new PSCluster(item)).ToList();
        }

        public IList<PSCluster> FilterPSClusters(string resourceGroupName, string clusterName)
        {
            List<PSCluster> list = new List<PSCluster>();
            if (string.IsNullOrEmpty(clusterName))
            {
                list.AddRange(ListPSClusters(resourceGroupName));
            }
            else
            {
                list.Add(GetPSCluster(resourceGroupName, clusterName));
            }

            return list;
        }

        public virtual PSCluster CreatePSCluster(string resourceGroupName, string clusterName, PSCluster parameters)
        {
            PSCluster existingCluster;
            try
            {
                existingCluster = GetPSCluster(resourceGroupName, clusterName);
            }
            catch(RestException)
            {
                existingCluster = null;
            }

            if (existingCluster != null)
            {
                throw new PSInvalidOperationException(string.Format("cluster: '{0}' already exists in '{1}'. Please use Update-AzOperationalInsightsCluster for updating.", clusterName, resourceGroupName));
            }

            return new PSCluster(this.OperationalInsightsManagementClient.Clusters.CreateOrUpdate(resourceGroupName, clusterName, parameters.getCluster()));
        }

        public virtual PSCluster UpdatePSCluster(string resourceGroupName, string clusterName, PSClusterPatch parameters)
        {
            PSCluster existingCluster;
            try
            {
                existingCluster = GetPSCluster(resourceGroupName, clusterName);
            }
            catch(RestException)
            {
                throw new System.ArgumentException($"Cluster {clusterName} under {resourceGroupName} is not existed");
            }

            parameters.Tags = parameters.Tags == null 
                ? existingCluster.Tags 
                : parameters.Tags;

            if (parameters.KeyVaultProperties != null)
            {
                parameters.KeyVaultProperties.KeyName = string.IsNullOrEmpty(parameters.KeyVaultProperties.KeyName)
                    ? existingCluster.KeyVaultProperties?.KeyName
                    : parameters.KeyVaultProperties.KeyName;

                parameters.KeyVaultProperties.KeyVaultUri = string.IsNullOrEmpty(parameters.KeyVaultProperties.KeyVaultUri)
                    ? existingCluster.KeyVaultProperties?.KeyVaultUri
                    : parameters.KeyVaultProperties.KeyVaultUri;

                parameters.KeyVaultProperties.KeyVersion = string.IsNullOrEmpty(parameters.KeyVaultProperties.KeyVersion)
                    ? existingCluster.KeyVaultProperties?.KeyVersion
                    : parameters.KeyVaultProperties.KeyVersion;
            }

            if (parameters.Sku != null)
            {
                parameters.Sku.Name = string.IsNullOrEmpty(parameters.Sku?.Name)
                    ? existingCluster.Sku?.Name
                    : parameters.Sku.Name;

                parameters.Sku.Capacity = parameters.Sku?.Capacity == 0
                    ? existingCluster.Sku?.Capacity
                    : parameters.Sku.Capacity;
            }

            Cluster cluster = this.OperationalInsightsManagementClient.Clusters.Update(resourceGroupName, clusterName, parameters.GetClusterPatch());
            return new PSCluster(cluster);
        }

        public virtual HttpStatusCode DeletePSCluster(string resourceGroupName, string clusterName)
        {
            return this.OperationalInsightsManagementClient.Clusters
                .DeleteWithHttpMessagesAsync(resourceGroupName, clusterName)
                .GetAwaiter()
                .GetResult()
                .Response
                .StatusCode;
        }
    }
}
