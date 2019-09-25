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

namespace Microsoft.Azure.Commands.ResourceGraph.Cmdlets
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceGraph.Utilities;
    using Microsoft.Azure.Internal.Subscriptions.Version2018_06_01;
    using Microsoft.Azure.Management.ResourceGraph.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Search-AzGraph cmdlet
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.ResourceGraph.Utilities.ResourceGraphBaseCmdlet" />
    [Cmdlet(VerbsCommon.Search, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Graph"), OutputType(typeof(PSObject))]
    public class SearchAzureRmGraph : ResourceGraphBaseCmdlet
    {
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Query extension with subscription names
        /// </summary>
        private static string queryExtensionToIncludeNames = null;

        /// <summary>
        /// The rows per page
        /// </summary>
        private const int RowsPerPage = 1000;

        /// <summary>
        /// Maximum number of subscriptions for request
        /// </summary>
        private const int SubscriptionLimit = 1000;

        /// <summary>
        /// Gets or sets the query.
        /// </summary>s
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Resource Graph query")]
        [AllowEmptyString]
        public string Query
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Subscription(s) to run query against")]
        public string[] Subscription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "The maximum number of objects to return. Default value is 100.")]
        [ValidateRange(1, 5000), PSDefaultValue(Value = 100)]
        public int First
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the skip.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Ignores the first N objects and then gets the remaining objects")]
        [ValidateRange(1, int.MaxValue), PSDefaultValue(Value = 0)]
        public int Skip
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if result should be extended with subcription and tenant names.
        /// </summary>s
        [Parameter(Mandatory = false, HelpMessage = "Indicates if result should be extended with subcription and tenants names")]
        [PSDefaultValue(Value = IncludeOptionsEnum.None)]
        public IncludeOptionsEnum Include
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var subscriptions = this.GetSubscriptions().ToList();
            if (subscriptions == null || subscriptions.Count == 0)
            {
                var exception = new ArgumentException("No subscriptions were found to run query. " +
                    "Please try to add them implicitly as param to your request (e.g. Search-AzGraph -Query '' -Subscription '11111111-1111-1111-1111-111111111111')");

                var errorRecord = new ErrorRecord(
                            exception, "400",
                            ErrorCategory.InvalidArgument, null);
                this.WriteError(errorRecord);
                return;
            }

            if (subscriptions.Count > SubscriptionLimit)
            {
                subscriptions = subscriptions.Take(SubscriptionLimit).ToList();
                this.WriteWarning("The query included more subscriptions than allowed. " +
                    $"Only the first {SubscriptionLimit} subscriptions were included for the results. " +
                    $"To use more than {SubscriptionLimit} subscriptions, see the docs for examples: https://aka.ms/arg-error-toomanysubs");
            }

            var first = this.MyInvocation.BoundParameters.ContainsKey("First") ? this.First : 100;
            var skip = this.MyInvocation.BoundParameters.ContainsKey("Skip") ? this.Skip : 0;

            var results = new List<PSObject>();
            QueryResponse response = null;

            var resultTruncated = false;
            try
            {
                do
                {
                    var requestTop = Math.Min(first - results.Count, RowsPerPage);
                    var requestSkip = skip + results.Count;
                    var requestSkipToken = response?.SkipToken;
                    this.WriteVerbose($"Sent top={requestTop} skip={requestSkip} skipToken={requestSkipToken}");

                    var requestOptions = new QueryRequestOptions(
                        top: requestTop,
                        skip: requestSkip,
                        skipToken: requestSkipToken,
                        resultFormat: ResultFormat.ObjectArray);

                    var queryExtenstion = (this.Include == IncludeOptionsEnum.DisplayNames && this.QueryExtensionInitizalized()) ?
                        (queryExtensionToIncludeNames + (this.Query.Length != 0 ? "| " : string.Empty)) :
                        string.Empty;

                    var request = new QueryRequest(subscriptions, queryExtenstion + this.Query, options: requestOptions);
                    response = this.ResourceGraphClient.ResourcesWithHttpMessagesAsync(request)
                        .Result
                        .Body;

                    if (response.ResultTruncated == ResultTruncated.True)
                    {
                        resultTruncated = true;
                    }

                    var requestResults = response.Data.ToPsObjects();
                    results.AddRange(requestResults);
                    this.WriteVerbose($"Received results: {requestResults.Count}");
                }
                while (results.Count < first && response.SkipToken != null);

                if (resultTruncated && results.Count < first)
                {
                    this.WriteWarning("Unable to paginate the results of the query. " +
                        "Some resources may be missing from the results. " +
                        "To rewrite the query and enable paging, " +
                        "see the docs for an example: https://aka.ms/arg-results-truncated");
                }
            }
            catch (Exception ex)
            {
                var aggregateEx = ex as AggregateException;
                if (aggregateEx?.InnerException != null && aggregateEx.InnerExceptions.Count == 1)
                {
                    var errorResponseEx = aggregateEx.InnerException as ErrorResponseException;
                    if (errorResponseEx != null)
                    {
                        var errorRecord = new ErrorRecord(
                            errorResponseEx, errorResponseEx.Body.Error.Code,
                            ErrorCategory.CloseError, null)
                        {
                            ErrorDetails = new System.Management.Automation.ErrorDetails(
                                errorResponseEx.ToDisplayableJson())
                        };

                        this.WriteError(errorRecord);
                        return;
                    }
                }

                this.WriteExceptionError(ex);
                return;
            }

            this.WriteObject(results, true);
        }

        /// <summary>
        /// Gets the subscriptions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetSubscriptions()
        {
            if (this.Subscription != null)
            {
                return this.Subscription;
            }

            var accountSubscriptions = this.DefaultContext.Account.GetSubscriptions();
            if (accountSubscriptions.Length > 0)
            {
                return accountSubscriptions;
            }

            return SubscriptionCache.GetSubscriptions(this.DefaultContext);
        }

        /// <summary>
        /// Ensure that this.queryExtensionToIncludeNames is initialized
        /// </summary>
        /// <returns></returns>
        private bool QueryExtensionInitizalized()
        {
            if (queryExtensionToIncludeNames == null)
            {
                lock (SyncRoot)
                {
                    if (queryExtensionToIncludeNames == null)
                    {
                        this.InitializeQueryExtension();
                    }
                }
            }

            return queryExtensionToIncludeNames != null && queryExtensionToIncludeNames.Length > 0;
        }

        /// <summary>
        /// Initialize this.queryExtensionToIncludeNames 
        /// </summary>
        private void InitializeQueryExtension()
        {
            queryExtensionToIncludeNames = string.Empty;

            // Query extension with subscription names 
            var subscriptionList = this.DefaultContext.Account.GetSubscriptions(this.DefaultProfile);
            if (subscriptionList != null && subscriptionList.Count != 0)
            {
                queryExtensionToIncludeNames =
                    $"extend subscriptionDisplayName=case({string.Join(",", subscriptionList.Select(sub => $"subscriptionId=='{sub.Id}', '{sub.Name}'"))},'')";
            }

            // Query extension with tenant names
            using (var subscriptionsClient =
                AzureSession.Instance.ClientFactory.CreateArmClient<SubscriptionClient>(
                    this.DefaultContext, AzureEnvironment.Endpoint.ResourceManager))
            {
                var tenantList = subscriptionsClient.Tenants.List().ToList();
                if (tenantList != null && tenantList.Count != 0)
                {
                    if (queryExtensionToIncludeNames.Length > 0)
                    {
                        queryExtensionToIncludeNames += "| ";
                    }

                    queryExtensionToIncludeNames +=
                        $"extend tenantDisplayName=case({string.Join(",", tenantList.Select(tenant => $"tenantId=='{tenant.TenantId}', '{tenant.DisplayName}'"))},'')";
                }
            }
        }
    }
}
