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
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSWorkspaceKeys GetWorkspaceKeys(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.SharedKeys.GetSharedKeys(resourceGroupName, workspaceName);

            return new PSWorkspaceKeys(response);
        }

        public virtual PSWorkspaceKeys UpdateWorkspaceKeys(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.SharedKeys.Regenerate(resourceGroupName, workspaceName);

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
            Rest.Azure.AzureOperationResponse result = OperationalInsightsManagementClient.Workspaces.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, ForceDelete).GetAwaiter().GetResult();
            return result.Response.StatusCode;
        }

        public virtual Workspace CreateOrUpdateWorkspace(
            string resourceGroupName,
            string workspaceName,
            string location,
            PSWorkspaceSku sku,
            IDictionary<string, string> tags,
            string publicNetworkAccessForIngestion,
            string publicNetworkAccessForQuery,
            int? retentionInDays,
            bool? forceCmkForQuery = null,
            int? dailyQuotaGb = null,
            Guid? customerId = null,
            PSWorkspaceFeatures features = null,
            string defaultDataCollectionRuleResourceId = null)
        {
            Workspace properties = new Workspace(
                name: workspaceName,
                location: location,
                tags: tags,
                customerId: customerId.HasValue ? customerId.Value.ToString() : null,
                publicNetworkAccessForIngestion: publicNetworkAccessForIngestion,
                publicNetworkAccessForQuery: publicNetworkAccessForQuery,
                forceCmkForQuery: forceCmkForQuery,
                sku: sku?.getWorkspaceSku(),
                defaultDataCollectionRuleResourceId: defaultDataCollectionRuleResourceId,
                features: features?.GetWorkspaceFeatures());


            if (retentionInDays.HasValue)
            {
                properties.RetentionInDays = retentionInDays.Value;
            }

            properties.WorkspaceCapping = dailyQuotaGb != null ? new WorkspaceCapping(dailyQuotaGb) : null;

            var response = OperationalInsightsManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, properties);
            return response;
        }

        public virtual PSWorkspace UpdatePSWorkspace(UpdatePSWorkspaceParameters parameters)
        {
            // Get the existing workspace
            PSWorkspace workspace;
            try
            {
                workspace = GetWorkspace(parameters.ResourceGroupName, parameters.WorkspaceName);
            }
            catch (RestException)
            {
                //worksace not found - use New-AzOperationalInsightsWorkspace command instead
                throw new PSArgumentException($"Workspace {parameters?.WorkspaceName} under resourceGroup {parameters?.ResourceGroupName} was not found, please use New-AzOperationalInsightsWorkspace.");
            }

            // Execute the update
            Workspace updatedWorkspace = CreateOrUpdateWorkspace(
                parameters.ResourceGroupName,
                parameters.WorkspaceName,
                workspace.Location,
                parameters.Sku = parameters.Sku == null ? new PSWorkspaceSku(workspace.Sku, workspace.CapacityReservationLevel) : parameters.Sku,
                parameters.Tags == null ? workspace.Tags : ToDictionary(parameters.Tags),
                string.IsNullOrWhiteSpace(parameters.PublicNetworkAccessForIngestion) ? workspace.PublicNetworkAccessForIngestion : parameters.PublicNetworkAccessForIngestion,
                string.IsNullOrWhiteSpace(parameters.PublicNetworkAccessForQuery) ? workspace.PublicNetworkAccessForQuery : parameters.PublicNetworkAccessForQuery,
                retentionInDays: parameters.RetentionInDays,
                forceCmkForQuery: parameters.ForceCmkForQuery,
                dailyQuotaGb: parameters.DailyQuotaGb,
                customerId: workspace.CustomerId,
                defaultDataCollectionRuleResourceId: parameters.DefaultDataCollectionRuleResourceId,
                features: parameters.WsFeatures);

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
                            parameters.Sku ?? new PSWorkspaceSku(),
                            tags,
                            parameters.PublicNetworkAccessForIngestion,
                            parameters.PublicNetworkAccessForQuery,
                            retentionInDays: parameters.RetentionInDays,
                            forceCmkForQuery: parameters.ForceCmkForQuery,
                            defaultDataCollectionRuleResourceId: parameters.DefaultDataCollectionRuleResourceId,
                            features: parameters.WsFeatures),
                        parameters.ResourceGroupName);
                if (!string.Equals(workspace.ProvisioningState, Azure.OperationStatus.Succeeded.ToString(), StringComparison.OrdinalIgnoreCase))
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
            return String.IsNullOrEmpty(resourceGroupName)
                ? OperationalInsightsManagementClient.DeletedWorkspaces.List().Select(x => new PSWorkspace(x, new ResourceIdentifier(x.Id).ResourceGroupName)).ToList()
                : OperationalInsightsManagementClient.DeletedWorkspaces.ListByResourceGroup(resourceGroupName).Select(x => new PSWorkspace(x, resourceGroupName)).ToList();
        }

        public virtual bool DeletedWorkspace(string resourceGroupName, string name)
        {
            List<PSWorkspace> workspaces = GetDeletedWorkspace(resourceGroupName);

            foreach (PSWorkspace workspace in workspaces)
            {
                if (workspace.Name.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual List<PSWorkspace> FilterPSWorkspaces(string resourceGroupName, string workspaceName)
        {
            List<PSWorkspace> workspaces = new List<PSWorkspace>();

            if (!string.IsNullOrWhiteSpace(workspaceName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    throw new PSArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
                }

                workspaces.Add(GetWorkspace(resourceGroupName, workspaceName));
            }
            else
            {
                workspaces.AddRange(ListWorkspaces(resourceGroupName));
            }

            return workspaces;
        }

        public virtual List<PSIntelligencePack> GetIntelligencePackList(string resourceGroupName, string workspaceName)
        {
            List<PSIntelligencePack> intelligencePacks = new List<PSIntelligencePack>();

            var listResponse = OperationalInsightsManagementClient.IntelligencePacks.List(resourceGroupName, workspaceName);
            if (listResponse != null)
            {
                listResponse.ForEach(ip => intelligencePacks.Add(new PSIntelligencePack(ip)));
            }

            return intelligencePacks;
        }

        public virtual PSIntelligencePack SetIntelligencePack(string resourceGroupName, string workspaceName, string intelligencePackName, bool enabled)
        {
            var existingIp = GetIntelligencePackList(resourceGroupName, workspaceName).FirstOrDefault(ip => ip.Name.Equals(intelligencePackName));
            if (existingIp == null || existingIp == default(PSIntelligencePack))
            {
                throw new PSArgumentException($"Intelligence Pack {intelligencePackName} under resourceGroup {resourceGroupName} worspace:{workspaceName} does not exist");
            }

            existingIp.Enabled = enabled;

            if (enabled)
            {
                OperationalInsightsManagementClient.IntelligencePacks.Enable(resourceGroupName, workspaceName, intelligencePackName);
                return existingIp;
            }
            else
            {
                OperationalInsightsManagementClient.IntelligencePacks.Disable(resourceGroupName, workspaceName, intelligencePackName);
                return existingIp;
            }
        }

        public virtual PSOperationStatus GetOperationStatus(string operationId, string location)
        {
            if (!Guid.TryParse(operationId, out Guid tempGuid))
            {
                throw new PSArgumentException($"OperationStatus {operationId} is not a valid GUID");
            }

            var response = OperationalInsightsManagementClient.OperationStatuses.Get(location, operationId);
            return new PSOperationStatus(response);
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
            catch (ErrorResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
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
