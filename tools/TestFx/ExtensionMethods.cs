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

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Commands.TestFx
{
    public static class ExtensionMethods
    {
        public static string GetValueUsingCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {
            //string valueForKey;
            if (dictionary.TryGetValue(keyName, out string valueForKey))
                return valueForKey;

            if (dictionary.TryGetValue(keyName.ToLower(), out valueForKey))
                return valueForKey;

            return valueForKey;
        }

        /// <summary>
        /// Searches dictionary with key as provided as well as key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static bool ContainsCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {
            if (dictionary.ContainsKey(keyName))
                return true;

            if (dictionary.ContainsKey(keyName.ToLower()))
                return true;

            return false;
        }

        /// <summary>
        /// Updates the dictionary first by searching for key as provided then does a second pass for key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static void UpdateDictionary(this Dictionary<string, string> dictionary, string keyName, string value)
        {
            if (dictionary.ContainsKey(keyName))
            {
                dictionary[keyName] = value;
            }
            else if (dictionary.ContainsKey(keyName.ToLower()))
            {
                dictionary[keyName.ToLower()] = value;
            }
        }

        /// <summary>
        /// Allows you to clear only values or key/value both
        /// </summary>
        /// <param name="dictionary">Dictionary<string,string> that to be cleared</param>
        /// <param name="clearValuesOnly">True: Clears only values, False: Clear keys and values</param>
        public static void Clear(this Dictionary<string, string> dictionary, bool clearValuesOnly)
        {
            //TODO: can be implemented for generic dictionary, but currently there is no requirement, else the overload
            //will be reflected for the entire solution for any kind of Dictionary, so currently only scoping to Dictionary<string,string>
            if (clearValuesOnly)
            {
                foreach (string key in dictionary.Keys.ToList())
                {
                    dictionary[key] = string.Empty;
                }
            }
            else
            {
                dictionary.Clear();
            }
        }

        /// <summary>
        /// Creates comma seperated string of all TestEnvironmentNames enum values
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static string ListValues(this TestEnvironmentName env)
        {
            List<string> enumValues = (from ev in typeof(TestEnvironmentName).GetMembers(BindingFlags.Public | BindingFlags.Static) select ev.Name).ToList();
            return string.Join(",", enumValues.Select((item) => item));
        }

        /// <summary>
        /// Checks if IEnumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsAny<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Any();
        }
    }
}
