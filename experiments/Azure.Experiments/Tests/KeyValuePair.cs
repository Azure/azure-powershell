using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Tests
{
    internal static class KeyValuePair
    {
        public static KeyValuePair<K, V> Create<K, V>(K k, V v)
            => new KeyValuePair<K, V>(k, v);
    }
}
