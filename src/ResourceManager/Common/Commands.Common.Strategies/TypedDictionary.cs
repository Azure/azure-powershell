using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class TypedDictionary<Key, Value>
    {
        public T GetOrAdd<T>(Key key, Func<T> create)
            where T : Value
            => (T)Dictionary.GetOrAdd(key, _ => create());

        ConcurrentDictionary<Key, Value> Dictionary { get; } 
            = new ConcurrentDictionary<Key, Value>();
    }
}
