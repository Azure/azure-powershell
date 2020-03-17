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

using System;

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
