// ---------r-------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    /// <summary>
    /// Helper class for tags.
    /// </summary>
    internal static class TagsHelper
    {
        /// <summary>
        /// Gets a tags dictionary from an enumerable of tags.
        /// </summary>
        /// <param name="tags">The enumerable of tags</param>
        internal static InsensitiveDictionary<string> GetTagsDictionary(IEnumerable<Hashtable> tags)
        {
            return tags == null
                ? null
                : tags
                    .CoalesceEnumerable()
                    .Select(hashTable => hashTable.OfType<DictionaryEntry>()
                        .ToInsensitiveDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value))
                    .Where(tagDictionary => tagDictionary.ContainsKey("Name"))
                    .Select(tagDictionary => Tuple
                        .Create(
                            tagDictionary["Name"].ToString(),
                            tagDictionary.ContainsKey("Value") ? tagDictionary["Value"].ToString() : string.Empty))
                    .Distinct(kvp => kvp.Item1)
                    .ToInsensitiveDictionary(kvp => kvp.Item1, kvp => kvp.Item2);
        }

        /// <summary>
        /// Gets a tags hash table from a tags dictionary.
        /// </summary>
        /// <param name="tags">The tags dictionary.</param>
        internal static List<Hashtable> GetTagsHashtables(InsensitiveDictionary<string> tags)
        {
            return tags == null
                ? null
                : tags.Select(kvp => new Hashtable { { "Name", kvp.Key }, { "Value", kvp.Value } }).ToList();
        }
    }
}
