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
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual HttpStatusCode DeleteSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            AzureOperationResponse response = OperationalInsightsManagementClient.Search.DeleteSavedSearch(resourceGroupName, workspaceName, savedSearchId);
            return response.StatusCode;
        }

        public virtual PSSearchGetSavedSearchResponse GetSavedSearch(string savedSearchId)
        {
            SearchGetSavedSearchResponse response = OperationalInsightsManagementClient.Search.GetSavedSearch(savedSearchId);
            PSSearchGetSavedSearchResponse searchResponse = new PSSearchGetSavedSearchResponse(response);
            return searchResponse;
        }

        public virtual PSSearchListSavedSearchResponse GetSavedSearches(string resourceGroupName, string workspaceName)
        {
            SearchListSavedSearchResponse responses = OperationalInsightsManagementClient.Search.ListSavedSearches(resourceGroupName, workspaceName);
            PSSearchListSavedSearchResponse searchResponses = new PSSearchListSavedSearchResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSearchResultsResponse GetSavedSearchResults(string savedSearchId)
        {
            SearchGetSearchResultsResponse responses = OperationalInsightsManagementClient.Search.GetSavedSearchResults(savedSearchId);
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

        public virtual PSSearchGetSearchResultsResponse GetSearchResultsUpdate(string id)
        {
            SearchGetSearchResultsResponse response = OperationalInsightsManagementClient.Search.UpdateSearchResults(id);
            PSSearchGetSearchResultsResponse searchResponse = new PSSearchGetSearchResultsResponse(response);
            return searchResponse;
        }

        public virtual HttpStatusCode CreateOrUpdateSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId, string category, string displayName, string query, int version)
        {
            SearchCreateOrUpdateSavedSearchParameters parameters = new SearchCreateOrUpdateSavedSearchParameters();
            parameters.Properties = new SavedSearchProperties();
            parameters.Properties.Category = category;
            parameters.Properties.DisplayName = displayName;
            parameters.Properties.Query = query;
            parameters.Properties.Version = version;
            AzureOperationResponse response = OperationalInsightsManagementClient.Search.CreateOrUpdateSavedSearch(resourceGroupName, workspaceName, savedSearchId, parameters);
            return response.StatusCode;
        }
    }
}