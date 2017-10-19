using System.Collections.Generic;

namespace Azure.Experiments.Tests
{
    internal static class KeyValuePair
    {
        public static KeyValuePair<K, V> Create<K, V>(K k, V v)
            => new KeyValuePair<K, V>(k, v);
    }
}
