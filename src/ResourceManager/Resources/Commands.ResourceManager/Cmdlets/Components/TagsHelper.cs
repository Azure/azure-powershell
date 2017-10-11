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
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

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

        /// <summary>
        /// Resolves the tag name given the tagObj and tagName parameters. If both are specified then tagObj takes precedence.
        /// </summary>
        /// <param name="tagObjParameter">Parameter containing the tag name-value specified as a hashset.</param>
        /// <param name="tagNameParameter">Parameter containing the tag name specified individually.</param>
        /// <returns>The resolved tag name.</returns>
        internal static string GetTagNameFromParameters(Hashtable tagObjParameter, string tagNameParameter)
        {
            PSTagValuePair tagValuePair = null;
            if (tagObjParameter != null)
            {
                tagValuePair = TagsConversionHelper.Create(tagObjParameter);

                if (tagValuePair == null)
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }
            }

            if (tagValuePair != null)
            {
                return tagValuePair.Name;
            }
            return tagNameParameter;
        }

        /// <summary>
        /// Resolves the tag value given the tagObj and tagValue parameters. If both are specified then tagObj takes precedence.
        /// </summary>
        /// <param name="tagObjParameter">Parameter containing the tag name-value specified as a hashset.</param>
        /// <param name="tagValueParameter">Parameter containing the tag value specified individually.</param>
        /// <returns>The resolved tag value.</returns>
        internal static string GetTagValueFromParameters(Hashtable tagObjParameter, string tagValueParameter)
        {
            PSTagValuePair tagValuePair = null;
            if (tagObjParameter != null)
            {
                tagValuePair = TagsConversionHelper.Create(tagObjParameter);

                if (tagValuePair == null)
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }
            }

            if (tagValuePair != null)
            {
                return tagValuePair.Value;
            }
            return tagValueParameter;
        }
    }
}
