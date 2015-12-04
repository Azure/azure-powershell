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

        public virtual PSSearchGetSavedSearchResponse GetSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SearchGetSavedSearchResponse response = OperationalInsightsManagementClient.Search.GetSavedSearch(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSavedSearchResponse searchResponse = new PSSearchGetSavedSearchResponse(response);
            return searchResponse;
        }

        public virtual PSSearchSavedSearchResponse GetSavedSearches(string resourceGroupName, string workspaceName)
        {
            SearchSavedSearchResponse responses = OperationalInsightsManagementClient.Search.GetSavedSearches(resourceGroupName, workspaceName);
            PSSearchSavedSearchResponse searchResponses = new PSSearchSavedSearchResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSearchResultResponse GetSavedSearchResults(string resourceGroupName, string workspaceName, string savedSearchId)
        {
            SearchGetSearchResultResponse responses = OperationalInsightsManagementClient.Search.GetSavedSearchResults(resourceGroupName, workspaceName, savedSearchId);
            PSSearchGetSearchResultResponse searchResponses = new PSSearchGetSearchResultResponse(responses);
            return searchResponses;
        }

        public virtual PSSearchGetSchemaResponse GetSchema(string resourceGroupName, string workspaceName)
        {
            SearchGetSchemaResponse response = OperationalInsightsManagementClient.Search.GetSchema(resourceGroupName, workspaceName);
            PSSearchGetSchemaResponse schemaResponse = new PSSearchGetSchemaResponse(response);
            return schemaResponse;
        }

        public virtual PSSearchGetSearchResultResponse GetSearchResult(string resourceGroupName, string workspaceName, PSSearchGetSearchResultParameters psParameters)
        {
            SearchGetSearchResultParameters parameters = new SearchGetSearchResultParameters();
            parameters.Top = psParameters.Top;
            parameters.Skip = psParameters.Skip;
            if (psParameters.Highlight != null)
            {
                parameters.Highlight = new Highlight();
                parameters.Highlight.Pre = psParameters.Highlight.Pre;
                parameters.Highlight.Post = psParameters.Highlight.Post;
            }
            parameters.IncludeArchive = psParameters.IncludeArchive;
            parameters.Query = psParameters.Query;
            parameters.Start = psParameters.Start;
            parameters.End = psParameters.End;
            if (psParameters.Facet != null)
            {
                parameters.Facet = new Facet();
                parameters.Facet.Field = psParameters.Facet.Field;
                parameters.Facet.Limit = psParameters.Facet.Limit;
                parameters.Facet.Mincount = psParameters.Facet.Mincount;
                if (psParameters.Facet.Range != null)
                {
                    parameters.Facet.Range = new Range();
                    parameters.Facet.Range.Field = psParameters.Facet.Range.Field;
                    parameters.Facet.Range.Start = psParameters.Facet.Range.Start;
                    parameters.Facet.Range.End = psParameters.Facet.Range.End;
                    parameters.Facet.Range.Gap = psParameters.Facet.Range.Gap;
                }

            }
            SearchGetSearchResultResponse response = OperationalInsightsManagementClient.Search.GetSearchResult(resourceGroupName, workspaceName, parameters);
            PSSearchGetSearchResultResponse searchResponse = new PSSearchGetSearchResultResponse(response);
            return searchResponse;
        }

        public virtual PSSearchGetSearchResultResponse GetSearchResultUpdate(string resourceGroupName, string workspaceName, string id)
        {
            SearchGetSearchResultResponse response = OperationalInsightsManagementClient.Search.GetSearchResultUpdate(resourceGroupName, workspaceName, id);
            PSSearchGetSearchResultResponse searchResponse = new PSSearchGetSearchResultResponse(response);
            return searchResponse;
        }

        public virtual HttpStatusCode PutSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId, string category, string displayName, string query, int version)
        {
            SearchPutSavedSearchParameters parameters = new SearchPutSavedSearchParameters();
            parameters.Properties = new SavedSearchProperties();
            parameters.Properties.Category = category;
            parameters.Properties.DisplayName = displayName;
            parameters.Properties.Query = query;
            parameters.Properties.Version = version;
            AzureOperationResponse response = OperationalInsightsManagementClient.Search.PutSavedSearch(resourceGroupName, workspaceName, savedSearchId, parameters);
            return response.StatusCode;
        }
    }
}