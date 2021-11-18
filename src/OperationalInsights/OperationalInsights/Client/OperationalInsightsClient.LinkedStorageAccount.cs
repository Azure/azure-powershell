// ----------------------------------------------------------------------------------
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
        public virtual PSLinkedStorageAccountsResource GetLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType)
        {
            LinkedStorageAccountsResource resource = this.OperationalInsightsManagementClient.LinkedStorageAccounts.Get(resourceGroupName, workspaceName, PSLinkedStorageAccountsResource.getDataSourceType(dataSourceType));

            return new PSLinkedStorageAccountsResource(resource);
        }

        public virtual IList<PSLinkedStorageAccountsResource> ListLinkedStorageAccountsByWorkspace(string resourceGroupName, string workspaceName)
        {
            IList<PSLinkedStorageAccountsResource> resources = new List<PSLinkedStorageAccountsResource>();

            IEnumerable<LinkedStorageAccountsResource> response = this.OperationalInsightsManagementClient.LinkedStorageAccounts.ListByWorkspace(resourceGroupName, workspaceName);

            if (response != null)
            {
                resources = response.Select(resource => new PSLinkedStorageAccountsResource(resource)).ToList();
            }

            return resources;
        }

        public virtual IList<PSLinkedStorageAccountsResource> FilterPSLinkedStorageAccounts(string resourceGroupName, string workspaceName, string dataSourceType)
        {
            List<PSLinkedStorageAccountsResource> resources = new List<PSLinkedStorageAccountsResource>();

            if (!string.IsNullOrWhiteSpace(dataSourceType))
            {
                resources.Add(GetLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType));
            }
            else
            {
                resources.AddRange(ListLinkedStorageAccountsByWorkspace(resourceGroupName, workspaceName));
            }

            return resources;
        }

        public virtual HttpStatusCode DeleteLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType)
        {
            return this.OperationalInsightsManagementClient
                .LinkedStorageAccounts
                .DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, PSLinkedStorageAccountsResource.getDataSourceType(dataSourceType))
                .GetAwaiter()
                .GetResult()
                .Response
                .StatusCode;
        }

        public virtual LinkedStorageAccountsResource CreateOrUpdateLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType, IList<string> storageAccountIds)
        {
            return this.OperationalInsightsManagementClient.LinkedStorageAccounts.CreateOrUpdate(resourceGroupName, workspaceName, PSLinkedStorageAccountsResource.getDataSourceType(dataSourceType), storageAccountIds);
        }

        public virtual PSLinkedStorageAccountsResource CreateLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType, IList<string> storageAccountIds)
        {
            PSLinkedStorageAccountsResource existingResource;
            try
            {
                existingResource = GetLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType);
            }
            catch (CloudException)
            {
                existingResource = null;
            }

            if (existingResource != null)
            {
                throw new PSInvalidOperationException(string.Format("Linked Storage Accounts for workpsace: '{0}' under resource group: '{1}' already exists. Please use Update-AzOperationalInsightsLinkedStorageAccount for updating.", workspaceName, resourceGroupName));
            }

            return new PSLinkedStorageAccountsResource(CreateOrUpdateLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType, storageAccountIds));
        }

        public virtual PSLinkedStorageAccountsResource UpdateLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType, IList<string> storageAccountIds)
        {
            PSLinkedStorageAccountsResource existingResource;
            try
            {
                existingResource = GetLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType);
            }
            catch (RestException)
            {
                throw new PSArgumentException($"Linked Storage Accounts type {dataSourceType} for workspace {workspaceName} is not existed in Resource Group {resourceGroupName}");
            }

            LinkedStorageAccountsResource resource = CreateOrUpdateLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType, storageAccountIds);
            return new PSLinkedStorageAccountsResource(resource);
        }
    }
}
