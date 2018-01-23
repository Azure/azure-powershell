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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Common
{
    public static class PSObjectExtensions
    {
        /// <summary>
        /// Determine if a given PSObject has a property with the given name
        /// </summary>
        /// <param name="source">The PSObject to check</param>
        /// <param name="name">The name of the property to look for</param>
        /// <returns>true if the PSObject has a property with the given name, otherwise false</returns>
        public static bool HasProperty(this PSObject source, string name)
        {
            bool result = false;
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                result = props != null && props.Any();
            }

            return result;
        }

        /// <summary>
        /// Determine if a given PSObject has a property with the given name and type
        /// </summary>
        /// <typeparam name="T">The type of the property to look for</typeparam>
        /// <param name="source">The PSObject to check</param>
        /// <param name="name">The name of the proeprty to look for</param>
        /// <returns>true if the PSObject has a property with the given name, otherwise false</returns>
        public static bool HasProperty<T>(this PSObject source, string name)
        {
            bool result = false;
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                result = props != null && props.Any((p) => p.IsOfType<T>());
            }

            return result;
        }


        /// <summary>
        /// Try to return the value of the given property from the given PSObject
        /// </summary>
        /// <param name="source">The PSObject to retrieve the property from</param>
        /// <param name="name">The name of the property to retrieve</param>
        /// <param name="propertyValue">The value of the property, if found in the given PSObject</param>
        /// <returns>True if the property was found, otherwise false</returns>
        public static bool TryGetProperty(this PSObject source, string name, out object propertyValue)
        {
            bool result = false;
            propertyValue = null;
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                if (props != null)
                {
                    var prop = props.FirstOrDefault();
                    propertyValue = prop?.Value;
                    result = prop != null;
                }
            }

            return result;
        }

        /// <summary>
        /// Try to return the value of the given property from the given PSObject
        /// </summary>
        /// <typeparam name="T">The expected type of the property</typeparam>
        /// <param name="source">The PSObject to retrieve the property from</param>
        /// <param name="name">The name of the property to retrieve</param>
        /// <param name="propertyValue">The value of the property, if found in the given PSObject</param>
        /// <returns>True if the property was found, otherwise false</returns>
        public static bool TryGetProperty<T>(this PSObject source, string name, out T propertyValue)
        {
            bool result = false;
            propertyValue = default(T);
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                if (props != null)
                {
                    var prop = props.FirstOrDefault((p) => p.IsOfType<T>());
                    if (prop != null)
                    {
                        propertyValue = prop.GetValue<T>();
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Return the value of the given property from the given PSObject
        /// </summary>
        /// <typeparam name="T">The expected type of the property</typeparam>
        /// <param name="source">The PSObject to retrieve the property from</param>
        /// <param name="name">The name of the property to retrieve</param>
        /// <returns>he property if found, otherwise the deefault value for T</returns>
        public static T GetProperty<T>(this PSObject source, string name)
        {
            T propertyValue = default(T);
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                if (props != null)
                {
                    var prop = props.FirstOrDefault((p) => p.IsOfType<T>());
                    if (prop != null)
                    {
                        propertyValue = prop.GetValue<T>();
                    }
                }
            }

            return propertyValue;
        }

        /// <summary>
        /// Return the value of the given property from the given PSObject
        /// </summary>
        /// <param name="source">The PSObject to retrieve the property from</param>
        /// <param name="name">The name of the property to retrieve</param>
        /// <returns>he property if found, otherwise null</returns>
        public static object GetProperty(this PSObject source, string name)
        {
            object propertyValue = default(object);
            if (source != null && source.Properties != null)
            {
                var props = source.Properties.Match(name);
                if (props != null)
                {
                    var prop = props.FirstOrDefault();
                    if (prop != null)
                    {
                        propertyValue = prop.Value;
                    }
                }
            }

            return propertyValue;
        }

        /// <summary>
        /// Populate the model extensions from a PSObject
        /// </summary>
        /// <param name="model">The model to populate</param>
        /// <param name="other">The PSObject to populate it from</param>
        public static void PopulateExtensions(this IExtensibleModel model, PSObject other)
        {
            model.ExtendedProperties.Populate(nameof(model.ExtendedProperties), other);
        }

        /// <summary>
        /// Populate a generic string dictionary from a PSObject
        /// </summary>
        /// <param name="dictionary">The dictionary to populate</param>
        /// <param name="name">The name of the property containing the dictionary</param>
        /// <param name="other">The PSObject to populate from</param>
        public static void Populate(this IDictionary<string, string> dictionary, string name, PSObject other)
        {
            Hashtable table;
            if (other.TryGetProperty(name, out table))
            {
                if (table != null)
                {
                    foreach (var entry in table.Keys)
                    {
                        var key = entry as string;
                        if (key != null)
                        {
                            string value = table[entry] as string;
                            if (value != null)
                            {
                                dictionary[key] = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Populate a list from a proprty of the given PSObject
        /// </summary>
        /// <param name="list">The list to populate</param>
        /// <param name="name">The name of the proeprty contiaing the list</param>
        /// <param name="other">The PSObject to populate the list from</param>
        public static void Populate(this IList<string> list, string name, PSObject other)
        {
            ArrayList array;
            if (other.TryGetProperty(name, out array))
            {
                foreach (var obj in array)
                {
                    var item = obj as string;
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Populate a token cache from a PSObject
        /// </summary>
        /// <param name="cache">The cache to populate</param>
        /// <param name="other">The object to populate from</param>
        public static void Populate(this IAzureTokenCache cache, PSObject other)
        {
            byte[] data;
            if (other.TryGetProperty(nameof(cache.CacheData), out data))
            {
                cache.CacheData = data;
            }
        }

        static bool IsOfType<T>(this PSPropertyInfo info)
        {
            bool result = false;
            if (info != null && string.Equals(info.TypeNameOfValue, typeof(T).FullName, StringComparison.OrdinalIgnoreCase))
            {
                result = true;
            }
            else if (info!= null && info.Value != null)
            {
                var psValue = info.Value as PSObject;
                if (psValue != null)
                {
                    if (typeof(T) == typeof(PSObject))
                    {
                        result = true;
                    }
                    else if (psValue.BaseObject != null && psValue.BaseObject.GetType() == typeof(T))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        static T GetValue<T>(this PSPropertyInfo info)
        {
            T result = default(T);
            if (info != null && string.Equals(info.TypeNameOfValue, typeof(T).FullName, StringComparison.OrdinalIgnoreCase))
            {
                result = (T)(info.Value);
            }
            else if (info != null && info.Value != null)
            {
                var psValue = info.Value as PSObject;
                if (psValue != null)
                {
                    if (typeof(T) == typeof(PSObject))
                    {
                        result = (T)(info.Value);
                    }
                    else if (psValue.BaseObject != null && psValue.BaseObject.GetType() == typeof(T))
                    {
                        result = (T)(psValue.BaseObject);
                    }
                }
            }

            return result;
        }
    }
}
