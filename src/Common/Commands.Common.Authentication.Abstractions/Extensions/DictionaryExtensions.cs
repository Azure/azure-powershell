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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Extension methods for retrieving properties from an extensions dictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Safely get the value of the given property, or return the default if no value is present in the dictionary
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <returns>The value stored in the dictionary, or the default if no value is specified</returns>
        public static TValue GetProperty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey property)
        {
            if (dictionary.ContainsKey(property))
            {
                return dictionary[property];
            }

            return default(TValue);
        }

        /// <summary>
        /// Safely get the value of the given property as an array of strings, or return an empty array if no value is present in the dictionary.
        /// This assumes the property is stored as a comma-separated list
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <returns>The value stored in the dictionary as a string array, or the default if no value is specified</returns>
        public static string[] GetPropertyAsArray<TKey>(this IDictionary<TKey, string> dictionary, TKey property)
        {
            if (dictionary.ContainsKey(property))
            {
                return dictionary[property].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return new string[0];
        }

        /// <summary>
        /// Replace the value of the given property with a comma separated list of strings
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <param name="values">The strings to store in the property</param>
        public static void SetProperty<TKey>(this IDictionary<TKey, string> dictionary, TKey property, params string[] values)
        {
            if (values == null || values.Length == 0)
            {
                if (dictionary.ContainsKey(property))
                {
                    dictionary.Remove(property);
                }
            }
            else
            {
                dictionary[property] = string.Join(",", values);
            }
        }

        /// <summary>
        /// Merge the given array of values with the existing value of the given property - if the proeprty is not set, 
        /// set the value to the given array of strings.  Values are stored as a comma-separated list
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <param name="values">The strings to store in the property</param>
        public static void SetOrAppendProperty<TKey>(this IDictionary<TKey, string> dictionary, TKey property, params string[] values)
        {
            string oldValueString = "";
            if (dictionary.ContainsKey(property))
            {
                oldValueString = dictionary[property];
            }
            var oldValues = oldValueString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var newValues = oldValues.Union(values, StringComparer.CurrentCultureIgnoreCase).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (newValues.Any())
            {
                dictionary[property] = string.Join(",", newValues);
            }
        }

        /// <summary>
        /// Determine if the given property has a value
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <returns>True if the proeprty has a value, otherwise false</returns>
        public static bool IsPropertySet<TKey>(this IDictionary<TKey, string> dictionary, TKey property)
        {
            return dictionary.ContainsKey(property) && !string.IsNullOrEmpty(dictionary[property]);
        }
    }
}
