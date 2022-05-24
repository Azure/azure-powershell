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
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Management.Automation;
using System.Net;
using Microsoft.Rest;
using System;
using System.Globalization;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual HttpStatusCode DeleteSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            Rest.Azure.AzureOperationResponse response = OperationalInsightsManagementClient.SavedSearches.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, savedSearchId).GetAwaiter().GetResult();
            return response.Response.StatusCode;
        }

        public virtual PSSavedSearchValue GetSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            return new PSSavedSearchValue(OperationalInsightsManagementClient.SavedSearches.Get(resourceGroupName, workspaceName, savedSearchId));
        }

        public virtual PSSearchListSavedSearchResponse GetSavedSearches(string resourceGroupName, string workspaceName)
        {
            SavedSearchesListResult responses = OperationalInsightsManagementClient.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);
            PSSearchListSavedSearchResponse searchResponses = new PSSearchListSavedSearchResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSchemaResponse GetSchema(string resourceGroupName, string workspaceName)
        {
            SearchGetSchemaResponse response = OperationalInsightsManagementClient.Schema.Get(resourceGroupName, workspaceName);
            PSSearchGetSchemaResponse schemaResponse = new PSSearchGetSchemaResponse(response);
            return schemaResponse;
        }

        public virtual PSSavedSearchValue CreateSavedSearch(PSSavedSearchParameters parameters, Action<bool, string, string, string, Action, Func<bool>> ConfirmAction, bool force)
        {
            PSSavedSearchValue existingSavedSearch;
            try
            {
                existingSavedSearch = GetSavedSearch(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.SavedSearchId);
            }
            catch (RestException)
            {
                existingSavedSearch = null;
            }

            if (existingSavedSearch != null)
            {
                throw new PSInvalidOperationException($"Saved search with id: '{parameters.SavedSearchId}' already exists in resource group: '{parameters.ResourceGroupName}', workspace: '{parameters.WorkspaceName}'. Please use Set-OperationalInsightsSavedSearch for updating.");
            }

            PSSavedSearchValue createdSavedSearch = null;
            Action createSavedSearch = () =>
            {
                createdSavedSearch = new PSSavedSearchValue( this.OperationalInsightsManagementClient.SavedSearches.CreateOrUpdate(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.SavedSearchId, parameters.GetSavedSearchFromParameters()));
            };

            ConfirmAction(
                force,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SavedSearchExists,
                    parameters.SavedSearchId,
                    parameters.WorkspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SavedSearchCreating,
                    parameters.SavedSearchId,
                    parameters.WorkspaceName),
                parameters.SavedSearchId,
                createSavedSearch,
                () => CheckSavedSearchExists(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.SavedSearchId));

            return createdSavedSearch;
        }

        public virtual PSSavedSearchValue UpdateSavedSearch(PSSavedSearchParameters parameters)
        {
            PSSavedSearchValue existingSavedSearch;
            try
            {
                existingSavedSearch = GetSavedSearch(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.SavedSearchId);
            }
            catch (RestException)
            {
                throw new PSArgumentException($"Saved Search '{parameters.DisplayName}' under resource group: '{parameters.ResourceGroupName}', workspace: '{parameters.WorkspaceName}' does not exist. Please use New-OperationalInsightsSavedSearch for creating Saved search");
            }

            parameters.DisplayName = parameters.DisplayName == null ? existingSavedSearch.Properties.DisplayName : parameters.DisplayName;
            parameters.Category = parameters.Category == null ? existingSavedSearch.Properties.Category : parameters.Category;
            parameters.Version = parameters.Version == null ? existingSavedSearch.Properties.Version : parameters.Version;
            parameters.Query = parameters.Query == null ? existingSavedSearch.Properties.Query : parameters.Query;
            parameters.FunctionAlias = parameters.FunctionAlias == null ? existingSavedSearch.Properties.FunctionAlias : parameters.FunctionAlias;
            parameters.FunctionParameters = parameters.FunctionParameters == null ? existingSavedSearch.Properties.FunctionParameters : parameters.FunctionParameters;
            parameters.ETag = parameters.ETag == null ? existingSavedSearch.Properties.Etag : parameters.ETag;
            parameters.Tags = parameters.Tags == null ? existingSavedSearch.Properties.Tags : parameters.Tags;

            Rest.Azure.AzureOperationResponse<SavedSearch> response = this.OperationalInsightsManagementClient.SavedSearches.CreateOrUpdateWithHttpMessagesAsync(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.SavedSearchId, parameters.GetSavedSearchFromParameters()).GetAwaiter().GetResult();

            return new PSSavedSearchValue(response.Body);
        }

        private bool CheckSavedSearchExists(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            try
            {
                PSSavedSearchValue savedSearch = GetSavedSearch(resourceGroupName, workspaceName, savedSearchId);
                return true;
            }
            catch (Rest.Azure.CloudException e)
            {
                // Get throws NotFound exception if the saved search does not exist
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }
    }
}