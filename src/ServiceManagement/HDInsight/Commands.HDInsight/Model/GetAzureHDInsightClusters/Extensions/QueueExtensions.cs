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
    ///     Provides extension methods for Queues.
    /// </summary>
    internal static class QueueExtensions
    {
        /// <summary>
        ///     Adds an item to the Queue.  This is the same as an Enqueue operation.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        ///     The queue.
        /// </param>
        /// <param name="item">
        ///     The item to add.
        /// </param>
        public static void Add<T>(this Queue<T> queue, T item)
        {
            queue.ArgumentNotNull("queue");
            queue.Enqueue(item);
        }

        /// <summary>
        ///     Adds a range of items to the queue.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        ///     The queue.
        /// </param>
        /// <param name="items">
        ///     The items to be added (they will be added in the order presented).
        /// </param>
        public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            queue.ArgumentNotNull("queue");
            items.ArgumentNotNull("items");
            foreach (T item in items)
            {
                queue.Add(item);
            }
        }

        /// <summary>
        ///     Removes an item from the Queuue.  This is the same as a Dequeue operation.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the item stored in the queue.
        /// </typeparam>
        /// <param name="queue">
        ///     The queue.
        /// </param>
        /// <returns>
        ///     The next item in the queue.
        /// </returns>
        public static T Remove<T>(this Queue<T> queue)
        {
            queue.ArgumentNotNull("queue");
            return queue.Dequeue();
        }
    }
}
