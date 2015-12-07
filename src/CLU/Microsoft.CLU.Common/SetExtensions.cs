using System.Collections.Generic;

namespace Microsoft.CLU
{
    /// <summary>
    /// Extension methods for set operations. We use HashSet to
    /// represents a set.
    /// </summary>
    internal static class SetExtensions
    {
        /// <summary>
        /// Convert sequence to set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static HashSet<T> ToSet<T>(this IEnumerable<T> sequence)
        {
            var result = new HashSet<T>();
            foreach (var element in sequence)
            {
                result.Add(element);
            }
            return result;
        }

        // Modifies the current System.Collections.Generic.IEnumerable object to contain only
        // elements that are present in that object and in the specified set.
        public static HashSet<T> Intersect<T>(this IEnumerable<T> sequence, HashSet<T> set)
        {
            var left = sequence.ToSet();
            left.IntersectWith(set);
            return left;
        }

        /// <summary>
        /// Indicates whether the current HashSet<T> is null set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this HashSet<T> set)
        {
            return set == null || set.Count == 0;
        }
    }
}
