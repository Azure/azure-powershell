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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// IEnumerable extension methods
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Coalesces the enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        public static IEnumerable<TSource> CoalesceEnumerable<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>
        /// Selects a collection and returns an array.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The result of the selector function.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        public static TResult[] SelectArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToArray();
        }

        /// <summary>
        /// Selects a collection and returns an array.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The result of the selector function.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        public static TResult[] SelectManyArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            return source.SelectMany(selector).ToArray();
        }

        /// <summary>
        /// Returns a distinct array.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        public static TSource[] DistinctArray<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
        {
            return source.Distinct(comparer ?? EqualityComparer<TSource>.Default).ToArray();
        }

        /// <summary>
        /// Creates an insensitive dictionary from an enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="keySelector">The key selector.</param>
        public static InsensitiveDictionary<TValue> ToInsensitiveDictionary<TValue>(this IEnumerable<TValue> source, Func<TValue, string> keySelector)
        {
            var dictionary = new InsensitiveDictionary<TValue>();
            foreach (var value in source)
            {
                dictionary[keySelector(value)] = value;
            }

            return dictionary;
        }

        /// <summary>
        /// Creates an insensitive dictionary from an enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="valueSelector">The value selector.</param>
        public static InsensitiveDictionary<TValue> ToInsensitiveDictionary<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, string> keySelector, Func<TSource, TValue> valueSelector)
        {
            var dictionary = new InsensitiveDictionary<TValue>();
            foreach (var value in source)
            {
                dictionary[keySelector(value)] = valueSelector(value);
            }

            return dictionary;
        }

        /// <summary>
        /// Returns a distinct collection based on a key.
        /// </summary>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <typeparam name="TKeyType">The key type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        public static IEnumerable<TSource> Distinct<TSource, TKeyType>(this IEnumerable<TSource> source, Func<TSource, TKeyType> keySelector, IEqualityComparer<TKeyType> comparer = null)
        {
            var set = new Dictionary<TKeyType, TSource>(comparer ?? EqualityComparer<TKeyType>.Default);
            foreach (TSource element in source)
            {
                TSource value;
                var key = keySelector(element);
                if (!set.TryGetValue(key, out value))
                {
                    yield return element;
                }
                else
                {
                    set[key] = value;
                }
            }
        }

        /// <summary>
        /// Batches an enumerable into batches of the specified size.
        /// </summary>
        /// <typeparam name="TSource">The source type/</typeparam>
        /// <param name="source">The enumerable to batch.</param>
        /// <param name="batchSize">The batch size.</param>
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int batchSize = 10)
        {
            var batch = new List<TSource>(batchSize);
            foreach (var item in source)
            {
                batch.Add(item);
                if (batch.Count >= batchSize)
                {
                    yield return batch;
                    batch = new List<TSource>(batchSize);
                }
            }

            if (batch.Count > 0)
            {
                yield return batch;
            }
        }
    }
}