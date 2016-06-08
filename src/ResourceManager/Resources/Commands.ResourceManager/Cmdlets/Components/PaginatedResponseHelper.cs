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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A helper class for iterating through paginated responses.
    /// TODO: Fix this by implementing async/await
    /// </summary>
    public static class PaginatedResponseHelper
    {
        /// <summary>
        /// Applies the action on each value in the paginated response.
        /// </summary>
        /// <typeparam name="TType">The type of the response.</typeparam>
        /// <param name="getFirstPage">The function that returns the first page.</param>
        /// <param name="getNextPage">The function that returns subsequent pages.</param>
        /// <param name="action">The action to apply.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static void ForEach<TType>(
            Func<Task<ResponseWithContinuation<TType[]>>> getFirstPage,
            Func<string, Task<ResponseWithContinuation<TType[]>>> getNextPage,
            CancellationToken? cancellationToken,
            Action<TType[]> action)
        {
            ResponseWithContinuation<TType[]> batch = null;
            while ((cancellationToken.HasValue && !cancellationToken.Value.IsCancellationRequested) && (batch == null || !string.IsNullOrWhiteSpace(batch.NextLink)))
            {
                cancellationToken.Value.ThrowIfCancellationRequested();

                batch = batch == null
                    ? getFirstPage().Result
                    : getNextPage(batch.NextLink).Result;

                if (batch == null)
                {
                    return;
                }

                action(batch.Value);
            }
        }

        /// <summary>
        /// Applies the action on each value in the paginated response.
        /// </summary>
        /// <typeparam name="TType">The type of the response.</typeparam>
        /// <param name="getFirstPage">The function that returns the first page.</param>
        /// <param name="getNextPage">The function that returns subsequent pages.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static TType[] Enumerate<TType>(
            Func<Task<ResponseWithContinuation<TType[]>>> getFirstPage,
            Func<string, Task<ResponseWithContinuation<TType[]>>> getNextPage,
            CancellationToken? cancellationToken)
        {
            var result = new List<TType>();
            ResponseWithContinuation<TType[]> batch = null;
            while ((cancellationToken.HasValue && !cancellationToken.Value.IsCancellationRequested) && (batch == null || !string.IsNullOrWhiteSpace(batch.NextLink)))
            {
                cancellationToken.Value.ThrowIfCancellationRequested();

                batch = batch == null
                    ? getFirstPage().Result
                    : getNextPage(batch.NextLink).Result;

                if (batch == null)
                {
                    return result.ToArray();
                }

                result.AddRange(batch.Value.CoalesceEnumerable());
            }

            return result.ToArray();
        }
    }
}
