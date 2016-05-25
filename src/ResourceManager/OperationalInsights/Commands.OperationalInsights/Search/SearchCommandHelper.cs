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
        /// Return true if the provided query is a list of computers, return false otherwise.
        /// </summary>
        public static bool IsListOfComputers(string groupQuery)
        {
            if (string.IsNullOrEmpty(groupQuery))
            {
                return false;
            }

            // First, remove white spaces from group query.
            string query = new string(
                groupQuery.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());

            if ((query.IndexOf("|measurecount()bycomputer", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                (query.IndexOf("|distinctcomputer", StringComparison.InvariantCultureIgnoreCase) >= 0))
            {
                return true;
            }

            return false;
        }

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

            bool hasGroupTag = false;
            string groupKey = null;
            IList<Tag> tagList = new List<Tag>();

            foreach (string key in tags.Keys)
            {
                if (tags[key] != null)
                {
                    tagList.Add(new Tag() { Name = key, Value = tags[key].ToString() });

                    if (key.Equals("group", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        hasGroupTag = true;
                        groupKey = key;
                    }
                }
                else
                {
                    throw new PSArgumentException("Tag value can't be null.");
                }
            }

            // If the saved search is tagged as a group of computers, do a sanity check on the query as it should be a list of computers.
            if (hasGroupTag &&
                tags[groupKey].ToString().Equals("computer", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!IsListOfComputers(query))
                {
                    throw new PSArgumentException("Query is not a list of computers. Please use aggregations such as: distinct Computer or measure count() by Computer.");
                }
            }

            return tagList;
        }
    }
}
