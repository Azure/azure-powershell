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

using Azure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Helpers for the cmdlets that list items through Track 2 (Azure.Compute.Batch), so that -MaxCount, -Select and
    /// -Expand work as they do with Track 1 (Microsoft.Azure.Batch) today.
    /// </summary>
    /// <remarks>
    /// Long-running calls (delete or resize a pool, reboot a node, terminate a job, ...) need no helper: the cmdlets
    /// pass WaitUntil.Started, so they return as soon as the service accepts the request, as today.
    /// </remarks>
    internal static class Track2Lists
    {
        /// <summary>
        /// The Track 2 version of PSPagedEnumerable.CreateWithMaxCount: maps the items as their pages arrive. A maxCount
        /// of 0 or less means no limit; otherwise it logs the limit and stops after that many items, without asking the
        /// service for more pages.
        /// </summary>
        internal static IEnumerable<TOut> WithMaxCount<TIn, TOut>(
            Pageable<TIn> items, Func<TIn, TOut> map, int maxCount, Action logMaxCount = null)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            IEnumerable<TOut> mapped = items.Select(map);
            if (maxCount <= 0)
            {
                return mapped;
            }

            logMaxCount?.Invoke();
            return mapped.Take(maxCount);
        }

        /// <summary>
        /// Turns the comma-separated text of -Select or -Expand into the list Track 2 takes. Track 2 joins the list with
        /// commas again, so the service gets the same text as with Track 1; null stays null (no clause).
        /// </summary>
        internal static IList<string> ToClauseList(string clause)
        {
            return clause == null ? null : clause.Split(',');
        }
    }
}
