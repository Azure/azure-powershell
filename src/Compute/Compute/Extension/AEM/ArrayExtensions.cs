using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Extension.AEM
{
    public static class ArrayExtensions
    {
        // taken from http://csharphelper.com/blog/2017/10/make-subarray-extension-methods-in-c/
        // Copy the indicated entries from an array into a new array.
        public static T[] SubArray<T>(this T[] values,
            int start_index, int end_index)
        {
            int num_items = end_index - start_index + 1;
            T[] result = new T[num_items];
            Array.Copy(values, start_index, result, 0, num_items);
            return result;
        }
    }
}
