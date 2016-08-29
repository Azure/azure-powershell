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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Collections;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// A helper class that handles common tasks that deal with the <see cref="ResourcePropertyObject"/> class.
    /// </summary>
    public static class PsObjectExtensions
    {
        /// <summary>
        /// The properties to remove.
        /// </summary>
        private static readonly InsensitiveDictionary<bool> PropertiesToRemove = new InsensitiveDictionary<bool>
        {
            { "ResourceId", false },
            { "ResourceName", false },
            { "ResourceType", false},
            { "ExtensionResourceName", false },
            { "ExtensionResourceType", false },
            { "ResourceGroupName", false },
            { "SubscriptionId", false },
            { "Tags", false },
            { "PropertiesText", false },
        };

        /// <summary>
        /// Converts a <see cref="ResourcePropertyObject"/> to <see cref="JToken"/>
        /// </summary>
        /// <param name="propertyObject">The <see cref="ResourcePropertyObject"/></param>
        internal static JToken ToResourcePropertiesBody(this PSObject propertyObject)
        {
            return PsObjectExtensions.ToJToken(propertyObject);
        }

        /// <summary>
        /// Helper method for converting <see cref="Object"/> to <see cref="JToken"/>
        /// </summary>
        /// <param name="value">The object.</param>
        private static JToken ToJToken(object value)
        {
            if (value == null)
            {
                return null;
            }

            var valueAsPsObject = value as PSObject;
            if (valueAsPsObject != null)
            {
                JObject obj = new JObject();
                if (valueAsPsObject.BaseObject != null && valueAsPsObject.BaseObject is IDictionary)
                {
                    var valueAsIDictionary = valueAsPsObject.BaseObject as IDictionary;
                    var dictionaryEntries = valueAsIDictionary is IDictionary<string, object>
                        ? valueAsIDictionary.OfType<KeyValuePair<string, object>>().Select(kvp => Tuple.Create(kvp.Key, kvp.Value))
                        : valueAsIDictionary.OfType<DictionaryEntry>().Select(dictionaryEntry => Tuple.Create(dictionaryEntry.Key.ToString(), dictionaryEntry.Value));

                    dictionaryEntries = dictionaryEntries.Any(dictionaryEntry => dictionaryEntry.Item1.EqualsInsensitively(Constants.MicrosoftAzureResource))
                        ? dictionaryEntries.Where(dictionaryEntry => !PsObjectExtensions.PropertiesToRemove.ContainsKey(dictionaryEntry.Item1))
                        : dictionaryEntries;

                    foreach (var dictionaryEntry in dictionaryEntries)
                    {
                        obj.Add(dictionaryEntry.Item1, PsObjectExtensions.ToJToken(dictionaryEntry.Item2));
                    }
                }
                else
                {
                    var properties = (valueAsPsObject.TypeNames.Any(typeName => typeName.EqualsInsensitively(Constants.MicrosoftAzureResource)))
                        ? valueAsPsObject.Properties.Where(property => !PsObjectExtensions.PropertiesToRemove.ContainsKey(property.Name))
                        : valueAsPsObject.Properties.AsEnumerable();

                    foreach (var member in properties)
                    {
                        obj.Add(member.Name, PsObjectExtensions.ToJToken(member.Value));
                    }
                }

                return obj;
            }

            var valueAsDictionary = value as IDictionary;
            if (valueAsDictionary != null)
            {
                JObject obj = new JObject();
                var dictionaryEntries = valueAsDictionary is IDictionary<string, object>
                    ? valueAsDictionary.OfType<KeyValuePair<string, object>>().Select(kvp => Tuple.Create(kvp.Key, kvp.Value))
                    : valueAsDictionary.OfType<DictionaryEntry>().Select(dictionaryEntry => Tuple.Create(dictionaryEntry.Key.ToString(), dictionaryEntry.Value));

                dictionaryEntries = dictionaryEntries.Any(dictionaryEntry => dictionaryEntry.Item1.EqualsInsensitively(Constants.MicrosoftAzureResource))
                    ? dictionaryEntries.Where(dictionaryEntry => !PsObjectExtensions.PropertiesToRemove.ContainsKey(dictionaryEntry.Item1))
                    : dictionaryEntries;

                foreach (var dictionaryEntry in dictionaryEntries)
                {
                    obj.Add(dictionaryEntry.Item1, PsObjectExtensions.ToJToken(dictionaryEntry.Item2));
                }

                return obj;
            }

            var valueAsIList = value as IList;
            if (valueAsIList != null)
            {
                var tmpList = new List<JToken>();
                foreach (var v in valueAsIList)
                {
                    tmpList.Add(PsObjectExtensions.ToJToken(v));
                }

                return JArray.FromObject(tmpList.ToArray());
            }

            return new JValue(value.ToString());
        }
    }
}
