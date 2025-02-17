/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
    internal static class CollectionExtensions
    {
        public static T[] NullIfEmpty<T>(this T[] collection) => (collection?.Any() ?? false) ? collection : null;
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> collection) => collection ?? Enumerable.Empty<T>();

        // https://stackoverflow.com/a/4158364/294804
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> selector) =>
            collection.GroupBy(selector).Select(group => group.First());
    }
}
