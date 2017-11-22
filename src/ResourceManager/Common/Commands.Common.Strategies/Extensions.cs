using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class Extensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> value)
            => value ?? Enumerable.Empty<T>();

        public static V GetOrNull<K, V>(this IDictionary<K, V> dictionary, K key)
            where V : class
        {
            V result;
            return dictionary.TryGetValue(key, out result) ? result : null;
        }

        public static V GetOrAdd<K, V, T>(this ConcurrentDictionary<K, T> dictionary, K key, Func<V> add)
            where V : T
            => (V)dictionary.GetOrAdd(key, _ => add());
    }
}
