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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSWorkspaceKeys GetWorkspaceKeys(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.SharedKeys.GetSharedKeys(resourceGroupName, workspaceName);

            return new PSWorkspaceKeys(response);
        }

        public virtual List<PSManagementGroup> GetWorkspaceManagementGroups(string resourceGroupName, string workspaceName)
        {
            List<PSManagementGroup> managementGroups = new List<PSManagementGroup>();

            var response = OperationalInsightsManagementClient.ManagementGroups.List(resourceGroupName, workspaceName);
            if (response != null)
            {
                response.ForEach(mg => managementGroups.Add(new PSManagementGroup(mg)));
            }

            return managementGroups;
        }

        public virtual List<PSUsageMetric> GetWorkspaceUsage(string resourceGroupName, string workspaceName)
        {
            List<PSUsageMetric> usageMetrics = new List<PSUsageMetric>();

            var response = OperationalInsightsManagementClient.Usages.List(resourceGroupName, workspaceName);
            if (response != null)
            {
                response.ForEach(um => usageMetrics.Add(new PSUsageMetric(um)));
            }

            return usageMetrics;
        }

        public virtual PSWorkspace GetWorkspace(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.Workspaces.Get(resourceGroupName, workspaceName);

            return new PSWorkspace(response, resourceGroupName);
        }

        public virtual List<PSWorkspace> ListWorkspaces(string resourceGroupName)
        {
            List<PSWorkspace> workspaces = new List<PSWorkspace>();

            // Support both resource group and subscription listing
            var response = string.IsNullOrWhiteSpace(resourceGroupName)
                ? OperationalInsightsManagementClient.Workspaces.List()
                : OperationalInsightsManagementClient.Workspaces.ListByResourceGroup(resourceGroupName);

            if (response != null)
            {
                foreach (Workspace workspace in response)
                {
                    // If it is a subscription list then parse the resourceGroupName from the workspace ID
                    string resourceGroup = resourceGroupName;
                    if (string.IsNullOrWhiteSpace(resourceGroup) && !string.IsNullOrWhiteSpace(workspace.Id))
                    {
                        List<string> idSegments = workspace.Id.ToLowerInvariant().Split('/').ToList();
                        int indexOfResoureGroup = idSegments.IndexOf("resourcegroups") + 1;
                        resourceGroup = idSegments[indexOfResoureGroup];
                    }

                    workspaces.Add(new PSWorkspace(workspace, resourceGroup));
                }
            }

            return workspaces;
        }

        public virtual HttpStatusCode DeleteWorkspace(string resourceGroupName, string workspaceName, bool? ForceDelete)
        {
            Rest.Azure.AzureOperationResponse result  = OperationalInsightsManagementClient.Workspaces.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, ForceDelete).GetAwaiter().GetResult();
            return result.Response.StatusCode;
        }

        public virtual Workspace CreateOrUpdateWorkspace(
            string resourceGroupName,
            string workspaceName,
            string location,
            string sku,
            IDictionary<string, string> tags, 
            string publicNetworkAccessForIngestion,
            string publicNetworkAccessForQuery,
            int? retentionInDays,
            Guid? customerId = null)
        {
            Workspace properties = new Workspace(location:location, tags:tags, customerId:customerId.HasValue?customerId.Value.ToString():null, publicNetworkAccessForIngestion:publicNetworkAccessForIngestion, publicNetworkAccessForQuery:publicNetworkAccessForQuery);

            if (!string.IsNullOrWhiteSpace(sku))
            {
                properties.Sku = new WorkspaceSku(sku);
            }

            if (retentionInDays.HasValue)
            {
                properties.RetentionInDays = retentionInDays.Value;
            }

            var response = OperationalInsightsManagementClient.Workspaces.CreateOrUpdate(
                resourceGroupName,
                workspaceName,
                properties);

            return response;
        }

        public virtual PSWorkspace UpdatePSWorkspace(UpdatePSWorkspaceParameters parameters)
        {
            // Get the existing workspace
            PSWorkspace workspace = GetWorkspace(parameters.ResourceGroupName, parameters.WorkspaceName);

            // Execute the update
            Workspace updatedWorkspace = CreateOrUpdateWorkspace(
                parameters.ResourceGroupName,
                parameters.WorkspaceName,
                workspace.Location,
                string.IsNullOrWhiteSpace(parameters.Sku) ? workspace.Sku : parameters.Sku,
                parameters.Tags == null ? workspace.Tags : ToDictionary(parameters.Tags),
                string.IsNullOrWhiteSpace(parameters.PublicNetworkAccessForIngestion) ? workspace.PublicNetworkAccessForIngestion : parameters.PublicNetworkAccessForIngestion,
                string.IsNullOrWhiteSpace(parameters.PublicNetworkAccessForQuery) ? workspace.PublicNetworkAccessForQuery : parameters.PublicNetworkAccessForQuery,
                parameters.RetentionInDays,
                workspace.CustomerId);

            return new PSWorkspace(updatedWorkspace, parameters.ResourceGroupName);
        }

        public virtual PSWorkspace CreatePSWorkspace(CreatePSWorkspaceParameters parameters)
        {
            PSWorkspace workspace = null;
            Action createWorkspace = () =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                if (parameters.Tags != null)
                {
                    tags = ToDictionary(parameters.Tags);
                }

                workspace =
                    new PSWorkspace(
                        CreateOrUpdateWorkspace(
                            parameters.ResourceGroupName,
                            parameters.WorkspaceName,
                            parameters.Location,
                            parameters.Sku,
                            tags,
                            parameters.PublicNetworkAccessForIngestion,
                            parameters.PublicNetworkAccessForQuery,
                            parameters.RetentionInDays),
                        parameters.ResourceGroupName);
                if (!string.Equals(workspace.ProvisioningState, OperationStatus.Succeeded.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    throw new ProvisioningFailedException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.WorkspaceProvisioningFailed,
                            parameters.WorkspaceName,
                            parameters.ResourceGroupName));
                }
            };

            parameters.ConfirmAction(
                parameters.Force,    // prompt only if the workspace exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.WorkspaceExists,
                    parameters.WorkspaceName,
                    parameters.ResourceGroupName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.WorkspaceCreating,
                    parameters.WorkspaceName,
                    parameters.ResourceGroupName),
                parameters.WorkspaceName,
                createWorkspace,
                () => CheckWorkspaceExists(parameters.ResourceGroupName, parameters.WorkspaceName));

            return workspace;
        }

        public virtual List<PSWorkspace> GetDeletedWorkspace(string resourceGroupName)
        {
            List<PSWorkspace> workspaces = new List<PSWorkspace>();

            if (String.IsNullOrEmpty(resourceGroupName))
            {
                return OperationalInsightsManagementClient.DeletedWorkspaces.List().Select(x => new PSWorkspace(x, new ResourceIdentifier(x.Id).ResourceGroupName)).ToList();
            }
            else
            {
                return OperationalInsightsManagementClient.DeletedWorkspaces.ListByResourceGroup(resourceGroupName).Select(x => new PSWorkspace(x, resourceGroupName)).ToList();
            }
            
        }

        public virtual List<PSWorkspace> FilterPSWorkspaces(string resourceGroupName, string workspaceName)
        {
            List<PSWorkspace> workspaces = new List<PSWorkspace>();

            if (!string.IsNullOrWhiteSpace(workspaceName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
                }

                workspaces.Add(GetWorkspace(resourceGroupName, workspaceName));
            }
            else
            {
                workspaces.AddRange(ListWorkspaces(resourceGroupName));
            }

            return workspaces;
        }

        public virtual PSLinkedStorageAccountsResource GetLinkedStorageAccount(string resourceGroupName, string workspaceName, string dataSourceType)
        {
            LinkedStorageAccountsResource resource = this.OperationalInsightsManagementClient.LinkedStorageAccounts.Get(resourceGroupName, workspaceName,PSLinkedStorageAccountsResource.getDataSourceType(dataSourceType));

            return new PSLinkedStorageAccountsResource(resource);
        }

        public virtual IList<PSLinkedStorageAccountsResource> ListLinkedStorageAccountsByWorkspace(string resourceGroupName, string workspaceName)
        {
            IList<PSLinkedStorageAccountsResource> resources = new List<PSLinkedStorageAccountsResource>();

            IEnumerable<LinkedStorageAccountsResource> response =  this.OperationalInsightsManagementClient.LinkedStorageAccounts.ListByWorkspace(resourceGroupName, workspaceName);

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

        public virtual List<PSIntelligencePack> GetIntelligencePackList(string resourceGroupName, string workspaceName)
        {
            List<PSIntelligencePack> intelligencePacks = new List<PSIntelligencePack>();

            var listResponse = OperationalInsightsManagementClient.IntelligencePacks.List(resourceGroupName, workspaceName);
            if (listResponse != null)
            {
                listResponse.ForEach(ip => intelligencePacks.Add(new PSIntelligencePack(ip.Name, ip.Enabled.Value)));
            }

            return intelligencePacks;
        }

        public virtual PSIntelligencePack SetIntelligencePack(string resourceGroupName, string workspaceName, string intelligencePackName, bool enabled)
        {
            if (enabled)
            {
                OperationalInsightsManagementClient.IntelligencePacks.Enable(resourceGroupName, workspaceName, intelligencePackName);
                return new PSIntelligencePack(intelligencePackName, enabled); 
            }
            else
            {
                OperationalInsightsManagementClient.IntelligencePacks.Disable(resourceGroupName, workspaceName, intelligencePackName);
                return new PSIntelligencePack(intelligencePackName, enabled);
            }
        }

        public virtual PSLinkedService GetPSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            return new PSLinkedService(this.OperationalInsightsManagementClient.LinkedServices.Get(resourceGroupName, workspaceName, linkedServiceName));
        }

        public virtual IList<PSLinkedService> ListPSLinkedServices(string resourceGroupName, string workspaceName)
        {
            return this.OperationalInsightsManagementClient
                .LinkedServices
                .ListByWorkspace(resourceGroupName, workspaceName)
                .Select(item => new PSLinkedService(item))
                .ToList();
        }

        public virtual IList<PSLinkedService> FilterLinkedServices(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            List<PSLinkedService> list = new List<PSLinkedService>();
            if (string.IsNullOrEmpty(linkedServiceName))
            {
                list.AddRange(ListPSLinkedServices(resourceGroupName, workspaceName));
            }
            else
            {
                list.Add(GetPSLinkedService(resourceGroupName, workspaceName, linkedServiceName));
            }

            return list;
        }

        public virtual PSLinkedService SetPSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName, PSLinkedService parameters)
        {
            PSLinkedService existingLinkedService;
            try
            {
                existingLinkedService = GetPSLinkedService(resourceGroupName, workspaceName, linkedServiceName);
            }
            catch (RestException)
            {
                throw new System.ArgumentException($"linked service {linkedServiceName} for {workspaceName} is not existed");
            }

            parameters.Tags = parameters.Tags == null
                ? existingLinkedService.Tags
                : parameters.Tags;

            parameters.ResourceId = string.IsNullOrEmpty(parameters.ResourceId)
                ? existingLinkedService.ResourceId
                : parameters.ResourceId;

            parameters.WriteAccessResourceId = string.IsNullOrEmpty(parameters.WriteAccessResourceId)
                ? existingLinkedService.WriteAccessResourceId
                : parameters.WriteAccessResourceId;

            return new PSLinkedService(this.OperationalInsightsManagementClient.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, linkedServiceName, parameters.getLinkedService()));
        }

        public virtual HttpStatusCode DeletePSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            return this.OperationalInsightsManagementClient.LinkedServices
                .DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, linkedServiceName)
                .GetAwaiter()
                .GetResult()
                .Response
                .StatusCode;
        }

        private bool CheckWorkspaceExists(string resourceGroupName, string workspaceName)
        {
            try
            {
                PSWorkspace workspace = GetWorkspace(resourceGroupName, workspaceName);
                return true;
            }
            catch (Rest.Azure.CloudException e)
            {
                // Get throws NotFound exception if workspace does not exist
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private static Dictionary<string, string> ToDictionary(Hashtable hashTable)
        {
            return hashTable.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
        }
    }
}
