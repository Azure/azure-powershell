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

using Hyak.Common;
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

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual List<PSAccount> GetLinkTargets()
        {
            List<PSAccount> accounts = new List<PSAccount>();

            var response = OperationalInsightsManagementClient.Workspaces.ListLinkTargets();
            if (response != null && response.Accounts != null)
            {
                response.Accounts.ForEach(account => accounts.Add(new PSAccount(account)));
            }

            return accounts;
        }

        public virtual PSWorkspaceKeys GetWorkspaceKeys(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.Workspaces.GetSharedKeys(resourceGroupName, workspaceName);

            return new PSWorkspaceKeys(response.Keys);
        }

        public virtual List<PSManagementGroup> GetWorkspaceManagementGroups(string resourceGroupName, string workspaceName)
        {
            List<PSManagementGroup> managementGroups = new List<PSManagementGroup>();

            var response = OperationalInsightsManagementClient.Workspaces.ListManagementGroups(resourceGroupName, workspaceName);
            if (response != null && response.ManagementGroups != null)
            {
                response.ManagementGroups.ForEach(mg => managementGroups.Add(new PSManagementGroup(mg)));
            }

            return managementGroups;
        }

        public virtual List<PSUsageMetric> GetWorkspaceUsage(string resourceGroupName, string workspaceName)
        {
            List<PSUsageMetric> usageMetrics = new List<PSUsageMetric>();

            var response = OperationalInsightsManagementClient.Workspaces.ListUsages(resourceGroupName, workspaceName);
            if (response != null && response.UsageMetrics != null)
            {
                response.UsageMetrics.ForEach(um => usageMetrics.Add(new PSUsageMetric(um)));
            }

            return usageMetrics;
        }

        public virtual PSWorkspace GetWorkspace(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.Workspaces.Get(resourceGroupName, workspaceName);

            return new PSWorkspace(response.Workspace, resourceGroupName);
        }

        public virtual List<PSWorkspace> ListWorkspaces(string resourceGroupName)
        {
            List<PSWorkspace> workspaces = new List<PSWorkspace>();

            // Support both resource group and subscription listing
            var response = string.IsNullOrWhiteSpace(resourceGroupName)
                ? OperationalInsightsManagementClient.Workspaces.ListInSubscription()
                : OperationalInsightsManagementClient.Workspaces.ListInResourceGroup(resourceGroupName);

            if (response != null && response.Workspaces != null)
            {
                foreach (Workspace workspace in response.Workspaces)
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

        public virtual HttpStatusCode DeleteWorkspace(string resourceGroupName, string workspaceName)
        {
            AzureOperationResponse response = OperationalInsightsManagementClient.Workspaces.Delete(resourceGroupName, workspaceName);
            return response.StatusCode;
        }

        public virtual Workspace CreateOrUpdateWorkspace(
            string resourceGroupName,
            string workspaceName,
            string location,
            string sku,
            Guid? customerId,
            IDictionary<string, string> tags)
        {
            WorkspaceProperties properties = new WorkspaceProperties();

            if (!string.IsNullOrWhiteSpace(sku))
            {
                properties.Sku = new Sku(sku);
            }

            if (customerId.HasValue)
            {
                properties.CustomerId = customerId;
            }

            var response = OperationalInsightsManagementClient.Workspaces.CreateOrUpdate(
                resourceGroupName,
                new WorkspaceCreateOrUpdateParameters()
                {
                    Workspace =
                        new Workspace()
                        {
                            Name = workspaceName,
                            Location = location,
                            Tags = tags,
                            Properties = properties
                        }
                });

            return response.Workspace;
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
                workspace.CustomerId,
                parameters.Tags == null ? workspace.Tags : ToDictionary(parameters.Tags));

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
                            parameters.CustomerId,
                            tags),
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


        public virtual List<PSIntelligencePack> GetIntelligencePackList(string resourceGroupName, string workspaceName)
        {
            List<PSIntelligencePack> intelligencePacks = new List<PSIntelligencePack>();

            var listResponse = OperationalInsightsManagementClient.Workspaces.ListIntelligencePacks(resourceGroupName, workspaceName);
            if (listResponse != null && listResponse.IntelligencePacks != null)
            {
                listResponse.IntelligencePacks.ForEach(ip => intelligencePacks.Add(new PSIntelligencePack(ip.Name, ip.Enabled)));
            }

            return intelligencePacks;
        }

        public virtual PSIntelligencePack SetIntelligencePack(string resourceGroupName, string workspaceName, string intelligencePackName, bool enabled)
        {
            if (enabled)
            {
                OperationalInsightsManagementClient.Workspaces.EnableIntelligencePack(resourceGroupName, workspaceName, intelligencePackName);
                return new PSIntelligencePack(intelligencePackName, enabled); ;
            }
            else
            {
                OperationalInsightsManagementClient.Workspaces.DisableIntelligencePack(resourceGroupName, workspaceName, intelligencePackName);
                return new PSIntelligencePack(intelligencePackName, enabled);
            }
        }
        private bool CheckWorkspaceExists(string resourceGroupName, string workspaceName)
        {
            try
            {
                PSWorkspace workspace = GetWorkspace(resourceGroupName, workspaceName);
                return true;
            }
            catch (CloudException e)
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
