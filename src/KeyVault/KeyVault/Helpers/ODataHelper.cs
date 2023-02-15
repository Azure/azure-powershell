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
using System.Linq.Expressions;
using System.Web;

namespace Microsoft.Azure.Commands.KeyVault.Helpers
{
    internal static class ODataHelper
    {
        /// <summary>
        /// Format an ODataQuery filter expression to string.
        /// </summary>
        /// <remarks>
        /// This method uses <see cref="Rest.Azure.OData.ODataQuery{T}" /> class for the underlying parsing and serialization of the filter string.
        /// It supports limited operations in the implementation of filter.
        /// For string comparison, use `==` instead of `String.Equals()`.
        /// </remarks>
        public static string FormatFilterString<T>(Expression<Func<T, bool>> filter)
        {
            var odataQuery = new Rest.Azure.OData.ODataQuery<T>(filter);
            return HttpUtility.UrlDecode(odataQuery.Filter);
        }
    }
}