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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Helper methods related to retrieving paginated resources.
    /// </summary>
    public class PaginationHelper
    {
        /// <summary>
        /// Perform an action for each page of a paginated response, requesting the next page after the action completes.
        /// </summary>
        /// <typeparam name="T">The type of object expected in the response</typeparam>
        /// <param name="getFirstPage">A function that will request the first page</param>
        /// <param name="getNextPage">A function that will consume a nextLink and request further pages</param>
        /// <param name="action">The action to perform on each page.</param>
        /// <param name="top">The maximum number of resource to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static void ForEach<T>(
            Func<IPage<T>> getFirstPage, 
            Func<string, IPage<T>> getNextPage,
            Action<IEnumerable<T>> action, 
            int top,
            CancellationToken cancellationToken)
        {
            IPage<T> currentPage = null;
            int count = 0;
            while (!cancellationToken.IsCancellationRequested && 
                   (currentPage == null || !string.IsNullOrWhiteSpace(currentPage.NextPageLink)) &&
                   count < top)
            {
                cancellationToken.ThrowIfCancellationRequested();
                currentPage = currentPage == null ? getFirstPage() : getNextPage(currentPage.NextPageLink);
                if (currentPage == null)
                {
                    break;
                }

                var results = currentPage.ToArray();
                action(results.Take(top - count));
                count += results.Length;
            }
        }
    }
}
