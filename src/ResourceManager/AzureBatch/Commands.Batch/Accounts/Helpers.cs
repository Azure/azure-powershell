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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Batch
{
    internal class Helpers
    {
        // copied from Resources\Commands.Resources
        private const string ExcludedTagPrefix = "hidden-related:/";

        public static string FormatTagsTable(Hashtable[] tags)
        {
            if (tags == null)
            {
                return null;
            }

            Hashtable emptyHashtable = new Hashtable
                {
                    {"Name", string.Empty},
                    {"Value", string.Empty}
                };
            StringBuilder resourcesTable = new StringBuilder();

            if (tags.Length > 0)
            {
                int maxNameLength = Math.Max("Name".Length, tags.Where(ht => ht.ContainsKey("Name")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Name"].ToString().Length));
                int maxValueLength = Math.Max("Value".Length, tags.Where(ht => ht.ContainsKey("Value")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Value"].ToString().Length));

                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
                resourcesTable.AppendLine();
                resourcesTable.AppendFormat(rowFormat, "Name", "Value");

                foreach (Hashtable tag in tags)
                {
                    PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);

                    if (tagValuePair != null)
                    {
                        if (tagValuePair.Name.StartsWith(ExcludedTagPrefix))
                        {
                            continue;
                        }

                        if (tagValuePair.Value == null)
                        {
                            tagValuePair.Value = string.Empty;
                        }
                        resourcesTable.AppendFormat(rowFormat, tagValuePair.Name, tagValuePair.Value);
                    }
                }
            }

            return resourcesTable.ToString();
        }

        /// <summary>
        /// Filters the subscription's account with the given tag.
        /// </summary>
        /// <param name="account">The account to filter on.</param>
        /// <param name="tag">The tag to filter on.</param>
        /// <returns>Whether or not the account's tags match with the given tag</returns>
        public static bool MatchesTag(AccountResource account, Hashtable tag)
        {
            if (tag != null && tag.Count >= 1)
            {
                PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException(Resources.InvalidTagFormat);
                }

                if (string.IsNullOrEmpty(tagValuePair.Value))
                {
                    return ContainsTagWithName(account.Tags, tagValuePair.Name);
                }
                else
                {
                    return ContainsTagWithName(account.Tags, tagValuePair.Name) &&
                           account.Tags[tagValuePair.Name] == tagValuePair.Value;
                }
            }

            return true;
        }

        public static bool ContainsTagWithName(IDictionary<string, string> tags, string value)
        {
            if (tags == null)
            {
                return false;
            }

            return tags.Keys.Contains(value, StringComparer.OrdinalIgnoreCase);
        }
    }
}