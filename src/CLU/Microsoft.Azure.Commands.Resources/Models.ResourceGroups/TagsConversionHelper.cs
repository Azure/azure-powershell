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
using System.Collections;
using System.Collections.Generic;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public class TagsConversionHelper
    {
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
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }
                if (hashtableArray != null && hashtableArray.Length > 0 && hashtableArray[0].Count > 0 &&
                    (tagDictionary == null || hashtableArray.Length != tagDictionary.Count))
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormatNotUniqueName);
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
    }
}
