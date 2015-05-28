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

using System;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    using Management.OperationalInsights.Models;
    using Management.Resources.Models;

    public partial class OperationalInsightsClient
    {
        public virtual PSWorkspace GetWorkspace(string resourceGroupName, string workspaceName)
        {
            var response = OperationalInsightsManagementClient.Workspaces.Get(resourceGroupName, workspaceName);

            return new PSWorkspace(response.Workspace) { ResourceGroupName = resourceGroupName };
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
                response.Workspaces.ForEach(
                    ws => workspaces.Add(new PSWorkspace(ws) { ResourceGroupName = resourceGroupName }));
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

            if (!string.IsNullOrEmpty(sku))
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

        public virtual PSWorkspace CreatePSWorkspace(CreatePSWorkspaceParameters parameters)
        {
            PSWorkspace workspace = null;
            Action createWorkspace = () =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                if (parameters.Tags != null)
                {
                    tags = parameters.Tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
                }

                workspace =
                    new PSWorkspace(
                        CreateOrUpdateWorkspace(
                            parameters.ResourceGroupName, 
                            parameters.WorkspaceName,
                            parameters.Location,
                            parameters.Sku,
                            parameters.CustomerId,
                            tags)) { ResourceGroupName = parameters.ResourceGroupName };
            };

            if (parameters.Force)
            {
                // If user decides to overwrite anyway, then there is no need to check if the data factory exists or not.
                createWorkspace();
            }
            else
            {
                bool workspaceExists = CheckWorkspaceExists(parameters.ResourceGroupName, parameters.WorkspaceName);

                parameters.ConfirmAction(
                    !workspaceExists,    // prompt only if the workspace exists
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
                    createWorkspace);
            }

            // If the workspace did not transition to a succeeded provisioning state then throw
            if (workspace.Properties == null || 
                !string.Equals(workspace.Properties.ProvisioningState, OperationStatus.Succeeded.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ProvisioningFailedException(
                    string.Format(
                        CultureInfo.InvariantCulture, 
                        Resources.WorkspaceProvisioningFailed, 
                        parameters.WorkspaceName, 
                        parameters.ResourceGroupName));
            }

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
    }
}
