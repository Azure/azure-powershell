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
using System;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual HttpStatusCode DeleteSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            Rest.Azure.AzureOperationResponse response = OperationalInsightsManagementClient.SavedSearches.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, savedSearchId).GetAwaiter().GetResult();
            return response.Response.StatusCode;
        }

        public virtual PSSearchGetSavedSearchResponse GetSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SavedSearch response = OperationalInsightsManagementClient.SavedSearches.Get(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSavedSearchResponse searchResponse = new PSSearchGetSavedSearchResponse(response);
            return searchResponse;
        }

        public virtual PSSearchListSavedSearchResponse GetSavedSearches(string resourceGroupName, string workspaceName)
        {
            SavedSearchesListResult responses = OperationalInsightsManagementClient.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);
            PSSearchListSavedSearchResponse searchResponses = new PSSearchListSavedSearchResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSearchResultsResponse GetSavedSearchResults(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SearchResultsResponse responses = OperationalInsightsManagementClient.SavedSearches.GetResults(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSearchResultsResponse searchResponses = new PSSearchGetSearchResultsResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSchemaResponse GetSchema(string resourceGroupName, string workspaceName)
        {
            SearchGetSchemaResponse response = OperationalInsightsManagementClient.Workspaces.GetSchema(resourceGroupName, workspaceName);
            PSSearchGetSchemaResponse schemaResponse = new PSSearchGetSchemaResponse(response);
            return schemaResponse;
        }

        public virtual PSSearchGetSearchResultsResponse GetSearchResults(string resourceGroupName, string workspaceName, PSSearchGetSearchResultsParameters psParameters)
        {
            SearchParameters parameters = new SearchParameters();
            
            if (psParameters.Highlight != null)
            {
                parameters.Highlight = new SearchHighlight();
                parameters.Highlight.Pre = psParameters.Highlight.Pre;
                parameters.Highlight.Post = psParameters.Highlight.Post;
            }
            
            parameters.Top = psParameters.Top == 0 ? 10 : psParameters.Top;
            parameters.Query = psParameters.Query;
            parameters.Start = psParameters.Start;
            parameters.End = psParameters.End.GetValueOrDefault(DateTime.UtcNow);

            SearchResultsResponse response = OperationalInsightsManagementClient.Workspaces.GetSearchResults(resourceGroupName, workspaceName, parameters);
            PSSearchGetSearchResultsResponse searchResponse = new PSSearchGetSearchResultsResponse(response);
            return searchResponse;
        }

        public virtual PSSearchGetSearchResultsResponse GetSearchResultsUpdate(string resourceGroupName, string workspaceName, string id)
        {
            SearchResultsResponse response = OperationalInsightsManagementClient.Workspaces.UpdateSearchResults(resourceGroupName, workspaceName, id);
            PSSearchGetSearchResultsResponse searchResponse = new PSSearchGetSearchResultsResponse(response);
            return searchResponse;
        }

        public virtual HttpStatusCode CreateOrUpdateSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId, SavedSearch properties, bool force, Action<bool, string, string, string, Action, Func<bool>> ConfirmAction, string ETag = null)
        {
            HttpStatusCode status = HttpStatusCode.Ambiguous;
            Action createSavedSearch = () =>
                {
                    if (ETag != null && ETag != "")
                    {
                        properties.Etag = ETag;
                    }
                    Rest.Azure.AzureOperationResponse<SavedSearch> result = OperationalInsightsManagementClient.SavedSearches.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, workspaceName, savedSearchId, properties).GetAwaiter().GetResult();
                    status = result.Response.StatusCode;
                };

            ConfirmAction(
                force,    // prompt only if the saved search exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SavedSearchExists,
                    savedSearchId,
                    workspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SavedSearchCreating,
                    savedSearchId,
                    workspaceName),
                savedSearchId,
                createSavedSearch,
                () => CheckSavedSearchExists(resourceGroupName, workspaceName, savedSearchId));
            return status;
        }

        private bool CheckSavedSearchExists(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            try
            {
                PSSearchGetSavedSearchResponse savedSearch = GetSavedSearch(resourceGroupName, workspaceName, savedSearchId);
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