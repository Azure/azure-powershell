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
    using Common.Tags;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helper class for tags.
    /// </summary>
    internal static class TagsHelper
    {
        /// <summary>
        /// Gets a tags dictionary from an enumerable of tags.
        /// </summary>
        /// <param name="tags">The enumerable of tags</param>
        internal static InsensitiveDictionary<string> GetTagsDictionary(Hashtable tags)
        {
            if(tags == null)
            {
                return null;
            }

            var tagsDictionary = TagsConversionHelper.CreateTagDictionary(tags, true);
            return tagsDictionary.Distinct(kvp => kvp.Key).ToInsensitiveDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        /// <summary>
        /// Gets a tags hash table from a tags dictionary.
        /// </summary>
        /// <param name="tags">The tags dictionary.</param>
        internal static Hashtable GetTagsHashtable(InsensitiveDictionary<string> tags)
        {
            return tags == null
                ? null
                : TagsConversionHelper.CreateTagHashtable(tags);
        }
    }
}
