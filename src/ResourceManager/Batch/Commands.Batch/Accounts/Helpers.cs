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

namespace Microsoft.Azure.Commands.Batch
{  
    internal class Helpers
    {
        // copied from Resources\Commands.Resources

        private const string ExcludedTagPrefix = "hidden-related:/";

        public static PSTagValuePair Create(Hashtable hashtable)
        {
            if (hashtable == null ||
                !hashtable.ContainsKey("Name"))
            {
                return null;
            }

            PSTagValuePair tagValue = new PSTagValuePair();
            tagValue.Name = hashtable["Name"].ToString();

            if (hashtable.ContainsKey("Value"))
            {
                tagValue.Value = hashtable["Value"].ToString();
            }

            return tagValue;
        }

        public static Dictionary<string, string> CreateTagDictionary(Hashtable[] hashtableArray, bool validate)
        {
            Dictionary<string, string> tagDictionary = null;
            if (hashtableArray != null && hashtableArray.Length > 0)
            {
                tagDictionary = new Dictionary<string, string>();
                foreach (var tag in hashtableArray)
                {
                    var tagValuePair = Create(tag);
                    if (tagValuePair != null)
                    {
                        if (tagValuePair.Value != null)
                        {
                            tagDictionary[tagValuePair.Name] = tagValuePair.Value;
                        }
                        else
                        {
                            tagDictionary[tagValuePair.Name] = "";
                        }
                    }
                }
            }

            if (validate)
            {
                if (hashtableArray != null && hashtableArray.Length > 0 && hashtableArray[0].Count > 0 &&
                    (tagDictionary == null || tagDictionary.Count == 0))
                {
                    throw new ArgumentException(Resources.InvalidTagFormat);
                }
                if (hashtableArray != null && hashtableArray.Length > 0 && hashtableArray[0].Count > 0 &&
                    (tagDictionary == null || hashtableArray.Length != tagDictionary.Count))
                {
                    throw new ArgumentException(Resources.InvalidTagFormatNotUniqueName);
                }
            }

            return tagDictionary;
        }

        public static Hashtable[] CreateTagHashtable(IDictionary<string, string> dictionary)
        {
            List<Hashtable> tagHashtable = new List<Hashtable>();
            foreach (string key in dictionary.Keys)
            {
                tagHashtable.Add(new Hashtable
                {
                    {"Name", key},
                    {"Value", dictionary[key]}
                });
            }
            return tagHashtable.ToArray();
        }

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
                resourcesTable.AppendFormat(rowFormat,
                    GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                    GeneralUtilities.GenerateSeparator(maxValueLength, "="));

                foreach (Hashtable tag in tags)
                {
                    PSTagValuePair tagValuePair = Helpers.Create(tag);
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
        /// Filters the subscription's accounts.
        /// </summary>
        /// <param name="name">The account name.</param>
        /// <param name="tag">The tag to filter on.</param>
        /// <returns>The filtered accounts</returns>
        public static List<AccountResource> FilterAccounts(IList<AccountResource>accounts, Hashtable tag)
        {
            List<AccountResource> result = new List<AccountResource>();

            if (tag != null && tag.Count >= 1)
            {
                PSTagValuePair tagValuePair = Helpers.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException(Resources.InvalidTagFormat);
                }
                if (string.IsNullOrEmpty(tagValuePair.Value))
                {
                    accounts =
                        accounts.Where(acct => acct.Tags != null
                                               && acct.Tags.Keys.Contains(tagValuePair.Name, StringComparer.OrdinalIgnoreCase))
                                .Select(acct => acct).ToList();
                }
                else
                {
                    accounts =
                        accounts.Where(acct => acct.Tags != null && acct.Tags.Keys.Contains(tagValuePair.Name, StringComparer.OrdinalIgnoreCase))
                                .Where(rg => rg.Tags.Values.Contains(tagValuePair.Value, StringComparer.OrdinalIgnoreCase))
                                .Select(acct => acct).ToList();
                }
            }

            result.AddRange(accounts);
            return result;
        }

    }
}