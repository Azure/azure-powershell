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
    using Microsoft.Azure.Commands.ResourceGraph.Models;
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
    [Cmdlet(VerbsCommon.Search, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Graph", DefaultParameterSetName = "SubscriptionScopedQuery"), OutputType(typeof(PSResourceGraphResponse<PSObject>))]
    public class SearchAzureRmGraph : ResourceGraphBaseCmdlet
    {
        /// <summary>
        /// Subscription scoped query parameter set.
        /// </summary>
        public const string SubscriptionParameterSet = "SubscriptionScopedQuery";

        /// <summary>
        /// Management group scoped query parameter set.
        /// </summary>
        public const string ManagementGroupParameterSet = "ManagementGroupScopedQuery";

        /// <summary>
        /// Tenant scoped query parameter set.
        /// </summary>
        public const string TenantParameterSet = "TenantScopedQuery";

        /// <summary>
        /// The rows per page
        /// </summary>
        private const int MaxRowsPerPage = 1000;

        /// <summary>
        /// Maximum number of subscriptions for request
        /// </summary>
        private const int SubscriptionLimit = 1000;

        /// <summary>
        /// Maximum number of management groups for request
        /// </summary>
        private const int ManagementGroupLimit = 10;

        /// <summary>
        /// Gets or sets the query.
        /// </summary>s
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Graph query")]
        [AllowEmptyString]
        public string Query
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SubscriptionParameterSet, HelpMessage = "Subscription(s) to run query against. Cannot be used together with -ManagementGroup or -UseTenantScope parameters.")]
        public string[] Subscription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the management groups.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ManagementGroupParameterSet, HelpMessage = "Management group(s) to run query against. Cannot be used together with -Subscription or -UseTenantScope parameters.")]
        public string[] ManagementGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if query should succeed with partial scopes when total number of scopes exceeds the number allowed on server side.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = TenantParameterSet,
            HelpMessage = "Run query across all available subscriptions in the current tenant. Cannot be used together with -Subscription or -ManagementGroup parameters.")]
        public SwitchParameter UseTenantScope
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if query should succeed with partial scopes when total number of scopes exceeds the number allowed on server side.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ManagementGroupParameterSet, 
            HelpMessage = "Indicates if query should succeed when only partial number of subscription underneath can be processed by server")]
        [Parameter(ParameterSetName = TenantParameterSet)]
        public SwitchParameter AllowPartialScope
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
        [ValidateRange(1, 1000), PSDefaultValue(Value = 100)]
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
        /// Gets or sets the skip token.
        /// </summary>s
        [Parameter(Mandatory = false, HelpMessage = "The skip token to use for getting the next page of results if applicable")]
        public string SkipToken
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var managementGroups = this.ManagementGroup?.ToList();
            if (managementGroups != null && managementGroups.Count > ManagementGroupLimit)
            {
                managementGroups = managementGroups.Take(ManagementGroupLimit).ToList();
                this.WriteWarning("The query included more management groups than allowed. " +
                    $"Only the first {ManagementGroupLimit} management groups were included for the results. " +
                    $"To use more than {ManagementGroupLimit} management groups, see the docs for examples: https://aka.ms/arg-error-toomanysubs");
            }

            IList<string> subscriptions = null;
            if (!this.UseTenantScope.IsPresent && managementGroups == null)
            {
                subscriptions = this.GetSubscriptions()?.ToList();
                if (subscriptions != null && subscriptions.Count > SubscriptionLimit)
                {
                    subscriptions = subscriptions.Take(SubscriptionLimit).ToList();
                    this.WriteWarning("The query included more subscriptions than allowed. " +
                        $"Only the first {SubscriptionLimit} subscriptions were included for the results. " +
                        $"To use more than {SubscriptionLimit} subscriptions, see the docs for examples: https://aka.ms/arg-error-toomanysubs");
                }
            }

            var psResourceGraphResponse = new PSResourceGraphResponse<PSObject>();
            QueryResponse response = null;

            var resultTruncated = false;
            try
            {
                var skipToken = this.SkipToken;
                var isSkipTokenPassed = this.MyInvocation.BoundParameters.ContainsKey("SkipToken");

                int? first = null;
                if (this.MyInvocation.BoundParameters.ContainsKey("First"))
                {
                    first = Math.Min(First, MaxRowsPerPage);
                }
                else if (!isSkipTokenPassed)
                {
                    first = 100;
                }

                int? skip = null;
                if (this.MyInvocation.BoundParameters.ContainsKey("Skip"))
                {
                    skip = this.Skip;
                }
                else if (!isSkipTokenPassed)
                {
                    skip = 0;
                }

                var allowPartialScopes = AllowPartialScope.IsPresent;
                this.WriteVerbose($"Sent top={first} skip={skip} skipToken={skipToken}");

                var requestOptions = new QueryRequestOptions(
                        top: first,
                        skip: skip,
                        skipToken: skipToken,
                        resultFormat: ResultFormat.ObjectArray,
                        allowPartialScopes: allowPartialScopes);

                var request = new QueryRequest(this.Query, subscriptions, managementGroups, options: requestOptions);
                response = this.ResourceGraphClient.ResourcesWithHttpMessagesAsync(request)
                    .Result
                    .Body;

                if (response.ResultTruncated == ResultTruncated.True)
                {
                    resultTruncated = true;
                }

                var requestResults = response.Data.ToPsObjects();
                psResourceGraphResponse.Data = requestResults;
                psResourceGraphResponse.SkipToken = response.SkipToken;
                this.WriteVerbose($"Received results: {requestResults.Count}");

                if (resultTruncated && psResourceGraphResponse.Data.Count < first)
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

            this.WriteObject(psResourceGraphResponse);
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
            if (accountSubscriptions?.Length > 0)
            {
                return accountSubscriptions;
            }

            return null;
        }
    }
}
