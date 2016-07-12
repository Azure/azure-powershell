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
using System;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual HttpStatusCode DeleteSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            AzureOperationResponse response = OperationalInsightsManagementClient.Search.DeleteSavedSearch(resourceGroupName, workspaceName, savedSearchId);
            return response.StatusCode;
        }

        public virtual PSSearchGetSavedSearchResponse GetSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SearchGetSavedSearchResponse response = OperationalInsightsManagementClient.Search.GetSavedSearch(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSavedSearchResponse searchResponse = new PSSearchGetSavedSearchResponse(response);
            return searchResponse;
        }

        public virtual PSSearchListSavedSearchResponse GetSavedSearches(string resourceGroupName, string workspaceName)
        {
            SearchListSavedSearchResponse responses = OperationalInsightsManagementClient.Search.ListSavedSearches(resourceGroupName, workspaceName);
            PSSearchListSavedSearchResponse searchResponses = new PSSearchListSavedSearchResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSearchResultsResponse GetSavedSearchResults(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SearchGetSearchResultsResponse responses = OperationalInsightsManagementClient.Search.GetSavedSearchResults(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSearchResultsResponse searchResponses = new PSSearchGetSearchResultsResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSchemaResponse GetSchema(string resourceGroupName, string workspaceName)
        {
            SearchGetSchemaResponse response = OperationalInsightsManagementClient.Search.GetSchema(resourceGroupName, workspaceName);
            PSSearchGetSchemaResponse schemaResponse = new PSSearchGetSchemaResponse(response);
            return schemaResponse;
        }

        public virtual PSSearchGetSearchResultsResponse GetSearchResults(string resourceGroupName, string workspaceName, PSSearchGetSearchResultsParameters psParameters)
        {
            SearchGetSearchResultsParameters parameters = new SearchGetSearchResultsParameters();
            parameters.Top = psParameters.Top;
            if (psParameters.Highlight != null)
            {
                parameters.Highlight = new Highlight();
                parameters.Highlight.Pre = psParameters.Highlight.Pre;
                parameters.Highlight.Post = psParameters.Highlight.Post;
            }
            parameters.Query = psParameters.Query;
            parameters.Start = psParameters.Start;
            parameters.End = psParameters.End;

            SearchGetSearchResultsResponse response = OperationalInsightsManagementClient.Search.GetSearchResults(resourceGroupName, workspaceName, parameters);
            PSSearchGetSearchResultsResponse searchResponse = new PSSearchGetSearchResultsResponse(response);
            return searchResponse;
        }

        public virtual PSSearchGetSearchResultsResponse GetSearchResultsUpdate(string resourceGroupName, string workspaceName, string id)
        {
            SearchGetSearchResultsResponse response = OperationalInsightsManagementClient.Search.UpdateSearchResults(resourceGroupName, workspaceName, id);
            PSSearchGetSearchResultsResponse searchResponse = new PSSearchGetSearchResultsResponse(response);
            return searchResponse;
        }

        public virtual HttpStatusCode CreateOrUpdateSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId, SavedSearchProperties properties, bool force, Action<bool, string, string, string, Action, Func<bool>> ConfirmAction, string ETag = null)
        {
            HttpStatusCode status = HttpStatusCode.Ambiguous;
            Action createSavedSearch = () =>
                {
                    SearchCreateOrUpdateSavedSearchParameters searchParameters = new SearchCreateOrUpdateSavedSearchParameters();
                    if (ETag != null && ETag != "")
                    {
                        searchParameters.ETag = ETag;
                    }
                    searchParameters.Properties = properties;
                    AzureOperationResponse response = OperationalInsightsManagementClient.Search.CreateOrUpdateSavedSearch(resourceGroupName, workspaceName, savedSearchId, searchParameters);
                    status = response.StatusCode;
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
            catch (CloudException e)
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