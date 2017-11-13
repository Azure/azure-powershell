using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public static class EnumerableEx
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> value)
            => value ?? Enumerable.Empty<T>();
    }
}
