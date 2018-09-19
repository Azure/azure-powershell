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

using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    /// <summary>
    ///     Provides extension methods for Stacks.
    /// </summary>
    internal static class StackExtensions
    {
        /// <summary>
        ///     Adds an Item to the stack.  This is the same as a Push operation.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of items stored in the stack.
        /// </typeparam>
        /// <param name="stack">
        ///     The stack.
        /// </param>
        /// <param name="item">
        ///     The item to be added.
        /// </param>
        public static void Add<T>(this Stack<T> stack, T item)
        {
            stack.ArgumentNotNull("stack");
            stack.Push(item);
        }

        /// <summary>
        ///     Adds a range of items onto the stack.  This is the same as multiple push operations.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of items stored in the stack.
        /// </typeparam>
        /// <param name="stack">
        ///     The stack.
        /// </param>
        /// <param name="items">
        ///     The items to be added to the stack (they will be added in the order presented).
        /// </param>
        public static void AddRange<T>(this Stack<T> stack, IEnumerable<T> items)
        {
            stack.ArgumentNotNull("stack");
            items.ArgumentNotNull("items");
            foreach (T item in items)
            {
                stack.Add(item);
            }
        }

        /// <summary>
        ///     Removes an item from the stack.  This is the same as a Pop operation.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of items stored in the stack.
        /// </typeparam>
        /// <param name="stack">
        ///     The stack.
        /// </param>
        /// <returns>
        ///     The item on the top of the stack that was removed (poped).
        /// </returns>
        public static T Remove<T>(this Stack<T> stack)
        {
            stack.ArgumentNotNull("stack");
            return stack.Pop();
        }
    }
}
