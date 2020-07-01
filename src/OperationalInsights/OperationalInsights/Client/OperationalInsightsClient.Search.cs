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

        public virtual PSSearchGetSchemaResponse GetSchema(string resourceGroupName, string workspaceName)
        {
            SearchGetSchemaResponse response = OperationalInsightsManagementClient.Schema.Get(resourceGroupName, workspaceName);
            PSSearchGetSchemaResponse schemaResponse = new PSSearchGetSchemaResponse(response);
            return schemaResponse;
        }

        public virtual HttpStatusCode CreateOrUpdateSavedSearch(string resourceGroupName, string workspaceName, string savedSearchId, SavedSearch properties, bool patch, bool force, Action<bool, string, string, string, Action, Func<bool>> ConfirmAction, string ETag = null)
        {
            PSSearchGetSavedSearchResponse ExistingSearch;
            bool existed;

            try
            {
                ExistingSearch = GetSavedSearch(resourceGroupName, workspaceName, savedSearchId);
            }
            catch (Rest.Azure.CloudException)
            {
                ExistingSearch = null;
            }

            existed = ExistingSearch == null ? false : true;

            HttpStatusCode status = HttpStatusCode.Ambiguous;
            Action createSavedSearch = () =>
            {
                if (ETag != null && ETag != "")
                {
                    properties.ETag = ETag;
                }
                Rest.Azure.AzureOperationResponse<SavedSearch> result = OperationalInsightsManagementClient.SavedSearches.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, workspaceName, savedSearchId, properties).GetAwaiter().GetResult();
                status = result.Response.StatusCode;
            };

            Action updateSavedSearch = () =>
            {
                if (ETag != null && ETag != "")
                {
                    properties.ETag = ETag;
                }
                properties.FunctionParameters = ExistingSearch.Properties.FunctionParameters;
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
                (patch && existed) ? updateSavedSearch : createSavedSearch ,
                () => existed);
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