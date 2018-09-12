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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceGraph.Utilities;
    using Microsoft.Azure.Management.ResourceGraph.Models;

    /// <summary>
    /// Search-AzureRmGraph cmdlet
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
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Resource Graph query")]
        [AllowEmptyString]
        public string Query
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "List of subscriptions to run query against")]
        public string[] Subscriptions
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
            var subscriptions =
                (this.Subscriptions ?? this.DefaultContext.Account.GetSubscriptions()).ToList();
            var first = MyInvocation.BoundParameters.ContainsKey("First") ? this.First : 100;
            var skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.Skip : 0;

            var results = new List<PSObject>();
            QueryResponse response = null;

            try
            {
                do
                {
                    var requestOptions = new QueryRequestOptions(
                        top: Math.Min(first - results.Count, RowsPerPage),
                        skip: skip + results.Count,
                        skipToken: response?.SkipToken);

                    var request = new QueryRequest(subscriptions, this.Query, requestOptions);

                    response = this.ResourceGraphClient.ResourcesWithHttpMessagesAsync(request)
                        .Result
                        .Body;

                    results.AddRange(response.Data.ToPsObjects());
                } while (results.Count < first && response.SkipToken != null);
            }
            catch (Exception ex)
            {
                var aggregateEx = ex as AggregateException;
                if (aggregateEx?.InnerException != null && aggregateEx.InnerExceptions.Count == 1)
                {
                    var errorResponseEx = aggregateEx.InnerException as ErrorResponseException;
                    if (errorResponseEx != null)
                    {
                        this.WriteError(new ErrorRecord(errorResponseEx,
                            errorResponseEx.ToDisplayableJson(), ErrorCategory.CloseError, null));
                        return;
                    }
                }

                this.WriteExceptionError(ex);
                return;
            }

            this.WriteObject(results, true);
        }
    }
}
