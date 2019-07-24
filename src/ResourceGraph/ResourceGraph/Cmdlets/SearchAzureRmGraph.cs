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
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceGraph.Utilities;
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
        /// The rows per page
        /// </summary>
        private const int RowsPerPage = 1000;

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

            var first = this.MyInvocation.BoundParameters.ContainsKey("First") ? this.First : 100;
            var skip = this.MyInvocation.BoundParameters.ContainsKey("Skip") ? this.Skip : 0;

            var results = new List<PSObject>();
            QueryResponse response = null;

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

                    var request = new QueryRequest(subscriptions, this.Query, options: requestOptions);
                    response = this.ResourceGraphClient.ResourcesWithHttpMessagesAsync(request)
                        .Result
                        .Body;
                    var requestResults = response.Data.ToPsObjects();
                    results.AddRange(requestResults);
                    this.WriteVerbose($"Received results: {requestResults.Count}");
                }
                while (results.Count < first && response.SkipToken != null);
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

            // Use selected subscription (for example, by command "Select-AzSubscription {subscriptionId}") 
            if (this.TryGetDefaultContext(out var context))
            {
                var subscriptionId = context.Subscription?.Id;
                if (subscriptionId != null)
                {
                    return new List<string> { subscriptionId };
                }
            }

            var accountSubscriptions = this.DefaultContext.Account.GetSubscriptions();
            if (accountSubscriptions.Length > 0)
            {
                return accountSubscriptions;
            }

            return SubscriptionCache.GetSubscriptions(this.DefaultContext);
        }
    }
}
