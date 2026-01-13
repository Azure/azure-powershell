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

using Microsoft.Azure.Management.ResourceGraph.Models;
using System.Collections.Generic;
using RestAzureNS = Microsoft.Rest.Azure;
using System.Threading.Tasks;
using System;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Executes a Resource Graph query and returns the results
        /// </summary>
        /// <param name="query">KQL query string</param>
        /// <param name="subscriptions">List of subscription IDs to query</param>
        /// <param name="managementGroups">List of management group IDs to query</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <param name="top">Maximum number of results to return</param>
        /// <param name="skip">Number of results to skip</param>
        /// <param name="allowPartialScopes">Allow partial scopes if some subscriptions fail</param>
        /// <returns>Query response with resources</returns>
        public RestAzureNS.AzureOperationResponse<QueryResponse> ExecuteResourceGraphQuery(
            string query,
            IList<string> subscriptions = null,
            IList<string> managementGroups = null,
            string skipToken = null,
            int? top = null,
            int? skip = null,
            bool allowPartialScopes = false)
        {
            // Create query request options
            var requestOptions = new QueryRequestOptions(
                top: top,
                skip: skip,
                skipToken: skipToken,
                resultFormat: ResultFormat.ObjectArray,
                allowPartialScopes: allowPartialScopes);

            // Create the query request
            var request = new QueryRequest(
                query: query,
                subscriptions: subscriptions,
                managementGroups: managementGroups,
                options: requestOptions);

            // Execute the query using ARG client
            return ARGAdapter.Client.ResourcesWithHttpMessagesAsync(request).Result;
        }

        /// <summary>
        /// Execute Azure Resource Graph query with automatic pagination
        /// </summary>
        /// <param name="query">KQL query to execute</param>
        /// <param name="subscriptions">List of subscription IDs to query</param>
        /// <param name="managementGroups">List of management group IDs to query (optional)</param>
        /// <param name="initialSkipToken">Initial skip token for pagination (optional)</param>
        /// <param name="pageSize">Number of items per page (max 1000)</param>
        /// <param name="maxPages">Maximum number of pages to retrieve (safety limit)</param>
        /// <param name="allowPartialScopes">Allow partial scopes in query</param>
        /// <returns>Consolidated results from all pages</returns>
        public ARGPaginatedResult ExecuteResourceGraphQuery(
            string query,
            List<string> subscriptions,
            List<string> managementGroups = null,
            string initialSkipToken = null,
            int pageSize = 1000,
            int maxPages = 50,
            bool allowPartialScopes = false)
        {
            if (pageSize > 1000) pageSize = 1000; // ARG maximum
            if (pageSize < 1) pageSize = 100; // Reasonable minimum

            List<object> allResults = new List<object>();
            string skipToken = initialSkipToken;
            int totalRetrieved = 0;
            int pageNumber = 0;
            List<string> warnings = new List<string>();
            List<Exception> errors = new List<Exception>();

            do
            {
                pageNumber++;

                // Safety check to prevent infinite loops
                if (pageNumber > maxPages)
                {
                    warnings.Add($"Reached maximum page limit ({maxPages}). Total items retrieved: {totalRetrieved}. Some results may not be included.");
                    break;
                }

                try
                {
                    // Execute query for current page (call the original single-page method)
                    var response = ExecuteResourceGraphQuery(
                        query: query,
                        subscriptions: subscriptions,
                        managementGroups: managementGroups,
                        skipToken: skipToken,
                        top: pageSize,
                        skip: 0,
                        allowPartialScopes: allowPartialScopes
                    );

                    // Process results from current page
                    if (response.Body.Data != null && response.Body.Count > 0)
                    {
                        if (response.Body.Data is System.Collections.IEnumerable enumerable && !(response.Body.Data is string))
                        {
                            foreach (var item in enumerable)
                            {
                                if (item != null)
                                {
                                    allResults.Add(item);
                                    totalRetrieved++;
                                }
                            }
                        }
                        else
                        {
                            // Handle single item response
                            allResults.Add(response.Body.Data);
                            totalRetrieved++;
                        }
                    }

                    // Determine if more pages are available
                    skipToken = response.Body.SkipToken;
                    bool hasMorePages = !string.IsNullOrEmpty(skipToken) && response.Body.ResultTruncated == ResultTruncated.True;

                    if (!hasMorePages)
                    {
                        break;
                    }
                }
                catch (Exception pageEx)
                {
                    errors.Add(new Exception($"Error on page {pageNumber}: {pageEx.Message}", pageEx));
                    break;
                }

            } while (true);

            return new ARGPaginatedResult
            {
                Data = allResults,
                TotalRetrieved = totalRetrieved,
                PagesRetrieved = pageNumber,
                Warnings = warnings,
                Errors = errors,
                IsComplete = errors.Count == 0 && warnings.Count == 0
            };
        }
    }

    /// <summary>
    /// Result from paginated ARG query execution
    /// </summary>
    public class ARGPaginatedResult
    {
        public List<object> Data { get; set; } = new List<object>();
        public int TotalRetrieved { get; set; }
        public int PagesRetrieved { get; set; }
        public List<string> Warnings { get; set; } = new List<string>();
        public List<Exception> Errors { get; set; } = new List<Exception>();
        public bool IsComplete { get; set; }
    }
}