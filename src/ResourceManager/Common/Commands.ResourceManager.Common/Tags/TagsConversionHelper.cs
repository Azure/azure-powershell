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
using System.Linq;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Common.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Tags
{
    public class TagsConversionHelper
    {
        public static PSTagValuePair Create(Hashtable hashtable)
        {
            if (hashtable == null)
            {
                return null;
            }

            IDictionaryEnumerator ide = hashtable.GetEnumerator();
            PSTagValuePair tagValuePair = new PSTagValuePair();
            if(ide.MoveNext())
            {
                DictionaryEntry entry = (DictionaryEntry) ide.Current;
                tagValuePair.Name = entry.Key.ToString();
                if(entry.Value != null)
                {
                    tagValuePair.Value = entry.Value.ToString();
                }
            }
            return tagValuePair;
        }

        public static Dictionary<string, string> CreateTagDictionary(Hashtable tags, bool validate)
        {
            Dictionary<string, string> tagDictionary = null;
            if (tags != null)
            {
                tagDictionary = new Dictionary<string, string>();
                PSTagValuePair tvPair = new PSTagValuePair();

                foreach(DictionaryEntry entry in tags)
                {
                    tvPair.Name = entry.Key.ToString();
                    if (entry.Value != null)
                    {
                        tvPair.Value = entry.Value.ToString();
                    }
                    else
                    {
                        tvPair.Value = string.Empty;
                    }
                    tagDictionary[tvPair.Name] = tvPair.Value;
                }
                
            }
            if (validate)
            {
                if (tags != null && tags.Count > 0 &&
                    (tagDictionary == null || tagDictionary.Count == 0))
                {
                    throw new ArgumentException(ProjectResources.InvalidTagFormat);
                }
            }

            return tagDictionary;
        }

        public static Hashtable CreateTagHashtable(IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            Hashtable tagsHashtable = new Hashtable();

            foreach (string key in dictionary.Keys)
            {
                tagsHashtable[key] = dictionary[key];
            }
            return tagsHashtable;
        }
    }
}
