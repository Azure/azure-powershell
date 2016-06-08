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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.Commands.DataFactories
{
    public static class DataFactoryCommonUtilities
    {
        public static string ExtractNameFromJson(string jsonText, string resourceType)
        {
            Dictionary<string, object> jsonKeyValuePairs;

            try
            {
                jsonKeyValuePairs = JsonUtilities.DeserializeJson(jsonText, true);
            }
            catch (Exception exception)
            {
                throw new JsonSerializationException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidJson, exception.Message, resourceType));
            }

            const string NameTagInJson = "Name";

            foreach (var key in jsonKeyValuePairs.Keys)
            {
                if (string.Compare(NameTagInJson, key, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return (string)jsonKeyValuePairs[key];
                }
            }

            return string.Empty;
        }

        public static Dictionary<string, string> ExtractTagsFromJson(string jsonText)
        {
            Dictionary<string, object> jsonKeyValuePairs = JsonUtilities.DeserializeJson(jsonText);
            const string TagsKeyInJson = "tags";

            foreach (var key in jsonKeyValuePairs.Keys)
            {
                if (string.Compare(TagsKeyInJson, key, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    var tags = (jsonKeyValuePairs[key] as Dictionary<string, object>).ToDictionary(
                        p => p.Key,
                        p => (string)p.Value);

                    return tags;
                }
            }

            return null;
        }

        public static Dictionary<string, string> ToDictionary(this Hashtable hashTable)
        {
            return hashTable.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
        }

        public static bool TagsAreEqual(IDictionary<string, string> first, IDictionary<string, string> second)
        {
            bool equal = false;
            if (first.Count == second.Count)
            {
                equal = true;
                foreach (var pair in first)
                {
                    string value;
                    if (second.TryGetValue(pair.Key, out value))
                    {
                        if (!value.Equals(pair.Value))
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        // Require key be present.
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }

        public static bool IsSucceededProvisioningState(string provisioningState)
        {
            return
                string.Compare(provisioningState, OperationStatus.Succeeded.ToString(),
                    StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsNextPageLink(this string nextLink)
        {
            return !string.IsNullOrEmpty(nextLink);
        }
    }
}
