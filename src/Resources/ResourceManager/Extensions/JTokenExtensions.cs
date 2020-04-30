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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// A helper class for converting <see cref="JObject"/> and <see cref="JToken"/> objects to <see cref="PSObject"/> classes.
    /// </summary>
    internal static class JTokenExtensions
    {
        /// <summary>
        /// A lookup table that contains the native mappings which are supported.
        /// </summary>
        private static readonly Dictionary<JTokenType, Type> PrimitiveTypeMap = new Dictionary<JTokenType, Type>()
        {
            { JTokenType.String, typeof(string) },
            { JTokenType.Integer, typeof(long) },
            { JTokenType.Float, typeof(double) },
            { JTokenType.Boolean, typeof(bool) },
            { JTokenType.Null, typeof(object) },
            { JTokenType.Date, typeof(DateTime) },
            { JTokenType.Bytes, typeof(byte[]) },
            { JTokenType.Guid, typeof(Guid) },
            { JTokenType.Uri, typeof(Uri) },
            { JTokenType.TimeSpan, typeof(TimeSpan) },
        };

        /// <summary>
        /// Converts a <see cref="JObject"/> to a <see cref="PSObject"/>
        /// </summary>
        /// <param name="jtoken">The <see cref="JObject"/></param>
        /// <param name="objectType">The type of the object.</param>
        internal static PSObject ToPsObject(this JToken jtoken, string objectType = null)
        {
            if (jtoken == null)
            {
                return null;
            }

            if (jtoken.Type != JTokenType.Object)
            {
                return new PSObject(JTokenExtensions.ConvertPropertyValueForPsObject(propertyValue: jtoken));
            }

            var jobject = (JObject)jtoken;
            var psObject = new PSObject();

            if (!string.IsNullOrWhiteSpace(objectType))
            {
                psObject.TypeNames.Add(objectType);
            }

            foreach (var property in jobject.Properties())
            {
                psObject.Properties.Add(new PSNoteProperty(
                    name: property.Name,
                    value: JTokenExtensions.ConvertPropertyValueForPsObject(propertyValue: property.Value)));
            }

            return psObject;
        }

        /// <summary>
        /// Converts a property value for a <see cref="JObject"/> into an <see cref="object"/> that can be 
        /// used as the value of a <see cref="PSNoteProperty"/>.
        /// </summary>
        /// <param name="propertyValue">The <see cref="JToken"/> value.</param>
        internal static object ConvertPropertyValueForPsObject(JToken propertyValue)
        {
            if (propertyValue.Type == JTokenType.Object)
            {
                return propertyValue.ToPsObject();
            }

            if (propertyValue.Type == JTokenType.Array)
            {
                var jArray = (JArray)propertyValue;

                var array = new object[jArray.Count];

                for (int i = 0; i < array.Length; ++i)
                {
                    array[i] = JTokenExtensions.ConvertPropertyValueForPsObject(jArray[i]);
                }

                return array;
            }

            Type primitiveType;
            if (JTokenExtensions.PrimitiveTypeMap.TryGetValue(propertyValue.Type, out primitiveType))
            {
                try
                {
                    return propertyValue.ToObject(primitiveType, JsonExtensions.JsonObjectTypeSerializer);
                }
                catch (FormatException)
                {
                }
                catch (ArgumentException)
                {
                }
                catch (JsonException)
                {
                }
            }

            return propertyValue.ToString();
        }
    }
}
