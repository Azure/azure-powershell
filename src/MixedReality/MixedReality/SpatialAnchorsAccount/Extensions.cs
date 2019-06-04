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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.MixedReality.SpatialAnchorsAccount
{
    using Microsoft.Azure.Management.MixedReality;
    using Microsoft.Azure.Management.MixedReality.Models;
    using Microsoft.Rest.Azure;

    internal static class Extensions
    {
        internal static SpatialAnchorsAccount Find(this ISpatialAnchorsAccountsOperations operations, string resourceGroupName, string spatialAnchorsAccountName)
        {
            return operations.EnumerateByResourceGroup(resourceGroupName).FirstOrDefault(account => string.Equals(account.Name, spatialAnchorsAccountName, StringComparison.InvariantCultureIgnoreCase));
        }

        internal static IEnumerable<SpatialAnchorsAccount> EnumerateBySubscription(this ISpatialAnchorsAccountsOperations operations)
        {
            return Enumerate(() => operations.ListBySubscription(), link => operations.ListBySubscriptionNext(link)).ToList();
        }

        internal static IEnumerable<SpatialAnchorsAccount> EnumerateByResourceGroup(this ISpatialAnchorsAccountsOperations operations, string resourceGroupName)
        {
            return Enumerate(() => operations.ListByResourceGroup(resourceGroupName), link => operations.ListByResourceGroupNext(link)).ToList();
        }

        private static IEnumerable<T> Enumerate<T>(Func<IPage<T>> getFirstPage, Func<string, IPage<T>> getNextPage)
        {
            for (var page = getFirstPage(); page != null; page = !string.IsNullOrWhiteSpace(page.NextPageLink) ? getNextPage(page.NextPageLink) : null)
            {
                foreach (var item in page)
                {
                    yield return item;
                }
            }
        }
    }
}
