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

        public static TValue GetOrNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {
            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }

        public static T GetOrAddWithCast<TKey, T, TBase>(
            this ConcurrentDictionary<TKey, TBase> dictionary, TKey key, Func<T> add)
            where T : TBase
            => (T)dictionary.GetOrAdd(key, _ => add());
    }
}
