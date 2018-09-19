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

namespace Microsoft.Azure.Commands.OperationalInsights
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Management.OperationalInsights.Models;

    internal class SearchCommandHelper
    {
        /// <summary>
        /// Populate and validate SavedSearch.Properties.Tags from a Hashtable of tags specified in the cmdlet.
        /// </summary>
        /// <returns></returns>
        public static IList<Tag> PopulateAndValidateTagsForProperties(Hashtable tags, string query)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            string groupKey = null;
            IList<Tag> tagList = new List<Tag>();

            foreach (string key in tags.Keys)
            {
                if (tags[key] != null)
                {
                    tagList.Add(new Tag() { Name = key, Value = tags[key].ToString() });

                    if (key.Equals("group", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        groupKey = key;
                    }
                }
                else
                {
                    throw new PSArgumentException("Tag value can't be null.");
                }
            }

            return tagList;
        }
    }
}
