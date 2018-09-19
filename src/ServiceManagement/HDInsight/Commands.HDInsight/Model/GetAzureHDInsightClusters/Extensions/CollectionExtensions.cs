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
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    /// <summary>
    ///     Adds Extension methods to the ICollection(of T) objects.
    /// </summary>
    internal static class CollectionExtensions
    {
        /// <summary>
        ///     Allows a range of objects IEnumerable(of T) to be added to the collection.
        /// </summary>
        /// <typeparam name="T">
        ///     The Type of objects in the collection.
        /// </typeparam>
        /// <param name="collection">
        ///     The collection that this extension method is extending.
        /// </param>
        /// <param name="items">
        ///     The IEnumerable(of T) of objects in the collection.
        /// </param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection.IsNull())
            {
                throw new ArgumentNullException("collection");
            }
            if (items.IsNull())
            {
                throw new ArgumentNullException("items");
            }

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
    }
}
