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
                throw new System.ArgumentException($"Linked Storage Accounts type {dataSourceType} for workspace {workspaceName} is not existed in Resource Group {resourceGroupName}");
            }

            LinkedStorageAccountsResource resource = CreateOrUpdateLinkedStorageAccount(resourceGroupName, workspaceName, dataSourceType, storageAccountIds);
            return new PSLinkedStorageAccountsResource(resource);
        }
    }
}
