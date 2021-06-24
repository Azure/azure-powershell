/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime
{
    public interface IJsonSerializable
    {
        JsonNode ToJson(JsonObject container = null, SerializationMode serializationMode = SerializationMode.None);
    }
    internal static class JsonSerializable
    {
        /// <summary>
        /// Serializes an enumerable and returns a JsonNode.
        /// </summary>
        /// <param name="enumerable">an IEnumerable collection of items</param>
        /// <returns>A JsonNode that contains the collection of items serialized.</returns>
        private static JsonNode ToJsonValue(System.Collections.IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                // is it a byte array of some kind?
                if (enumerable is System.Collections.Generic.IEnumerable<byte> byteEnumerable)
                {
                    return new XBinary(System.Linq.Enumerable.ToArray(byteEnumerable));
                }

                var hasValues = false;
                // just create an array of value nodes.
                var result = new XNodeArray();
                foreach (var each in enumerable)
                {
                    // we had at least one value.
                    hasValues = true;

                    // try to serialize it.
                    var node = ToJsonValue(each);
                    if (null != node)
                    {
                        result.Add(node);
                    }
                }

                // if we were able to add values, (or it was just empty), return it.
                if (result.Count > 0 || !hasValues)
                {
                    return result;
                }
            }

            // we couldn't serialize the values. Sorry.
            return null;
        }

        /// <summary>
        /// Serializes a valuetype to a JsonNode.
        /// </summary>
        /// <param name="vValue">a <c>ValueType</c> (ie, a primitive, enum or struct) to be serialized </param>
        /// <returns>a JsonNode with the serialized value</returns>
        private static JsonNode ToJsonValue(ValueType vValue)
        {
            // numeric type
            if (vValue is SByte || vValue is Int16 || vValue is Int32 || vValue is Int64 || vValue is Byte || vValue is UInt16 || vValue is UInt32 || vValue is UInt64 || vValue is decimal || vValue is float || vValue is double)
            {
                return new JsonNumber(vValue.ToString());
            }

            // boolean type
            if (vValue is bool bValue)
            {
                return new JsonBoolean(bValue);
            }

            // dates 
            if (vValue is DateTime dtValue)
            {
                return new JsonDate(dtValue);
            }

            // sorry, no idea.
            return null;
        }
        /// <summary>
        /// Attempts to serialize an object by using ToJson() or ToJsonString() if they exist.
        /// </summary>
        /// <param name="oValue">the object to be serialized.</param>
        /// <returns>the serialized JsonNode (if successful), otherwise, <c>null</c></returns>
        private static JsonNode TryToJsonValue(dynamic oValue)
        {
            object jsonValue = null;
            dynamic v = oValue;
            try
            {
                jsonValue = v.ToJson().ToString();
            }
            catch
            {
                // no harm...
                try
                {
                    jsonValue = v.ToJsonString().ToString();
                }
                catch
                {
                    // no worries here either.
                }
            }

            // if we got something out, let's use it.
            if (null != jsonValue)
            {
                // JsonNumber is really a literal json value. Just don't try to cast that back to an actual number, ok? 
                return new JsonNumber(jsonValue.ToString());
            }

            return null;
        }

        /// <summary>
        /// Serialize an object by using a variety of methods.
        /// </summary>
        /// <param name="oValue">the object to be serialized.</param>
        /// <returns>the serialized JsonNode (if successful), otherwise, <c>null</c></returns>
        internal static JsonNode ToJsonValue(object value)
        {
            // things that implement our interface are preferred. 
            if (value is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable jsonSerializable)
            {
                return jsonSerializable.ToJson();
            }

            // strings are easy.
            if (value is string || value is char)
            {
                return new JsonString(value.ToString());
            }

            // value types are fairly straightforward (fallback to ToJson()/ToJsonString() or literal JsonString ) 
            if (value is System.ValueType vValue)
            {
                return ToJsonValue(vValue) ?? TryToJsonValue(vValue) ?? new JsonString(vValue.ToString());
            }

            // dictionaries are objects that should be able to serialize
            if (value is System.Collections.Generic.IDictionary<string, object> dictionary)
            {
                return Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.JsonSerializable.ToJson(dictionary, null);
            }

            // enumerable collections are handled like arrays (again, fallback to ToJson()/ToJsonString() or literal JsonString) 
            if (value is System.Collections.IEnumerable enumerableValue)
            {
                // some kind of enumerable value
                return ToJsonValue(enumerableValue) ?? TryToJsonValue(value) ?? new JsonString(value.ToString());
            }

            // at this point, we're going to fallback to a string literal here, since we really have no idea what it is.
            return new JsonString(value.ToString());
        }

        internal static JsonObject ToJson<T>(System.Collections.Generic.Dictionary<string, T> dictionary, JsonObject container) => ToJson((System.Collections.Generic.IDictionary<string, T>)dictionary, container);

        /// <summary>
        /// Serializes a dictionary into a JsonObject container.
        /// </summary>
        /// <param name="dictionary">The dictionary to serailize</param>
        /// <param name="container">the container to serialize the dictionary into</param>
        /// <returns>the container</returns>
        internal static JsonObject ToJson<T>(System.Collections.Generic.IDictionary<string, T> dictionary, JsonObject container)
        {
            container = container ?? new JsonObject();
            if (dictionary != null && dictionary.Count > 0)
            {
                foreach (var key in dictionary)
                {
                    // currently, we don't serialize null values. 
                    if (null != key.Value)
                    {
                        container.Add(key.Key, ToJsonValue(key.Value));
                        continue;
                    }
                }
            }
            return container;
        }

        internal static Func<JsonObject, System.Collections.Generic.IDictionary<string, V>> DeserializeDictionary<V>(Func<System.Collections.Generic.IDictionary<string, V>> dictionaryFactory)
        {
            return (node) => FromJson<V>(node, dictionaryFactory(), (object)(DeserializeDictionary(dictionaryFactory)) as Func<JsonObject, V>);
        }

        internal static System.Collections.Generic.IDictionary<string, V> FromJson<V>(JsonObject json, System.Collections.Generic.Dictionary<string, V> container, System.Func<JsonObject, V> objectFactory, System.Collections.Generic.HashSet<string> excludes = null) => FromJson(json, (System.Collections.Generic.IDictionary<string, V>)container, objectFactory, excludes);


        internal static System.Collections.Generic.IDictionary<string, V> FromJson<V>(JsonObject json, System.Collections.Generic.IDictionary<string, V> container, System.Func<JsonObject, V> objectFactory, System.Collections.Generic.HashSet<string> excludes = null)
        {
            if (null == json)
            {
                return container;
            }

            foreach (var key in json.Keys)
            {
                if (true == excludes?.Contains(key))
                {
                    continue;
                }

                var value = json[key];
                try
                {
                    switch (value.Type)
                    {
                        case JsonType.Null:
                            // skip null values.
                            continue;

                        case JsonType.Array:
                        case JsonType.Boolean:
                        case JsonType.Date:
                        case JsonType.Binary:
                        case JsonType.Number:
                        case JsonType.String:
                            container.Add(key, (V)value.ToValue());
                            break;
                        case JsonType.Object:
                            if (objectFactory != null)
                            {
                                var v = objectFactory(value as JsonObject);
                                if (null != v)
                                {
                                    container.Add(key, v);
                                }
                            }
                            break;
                    }
                }
                catch
                {
                }
            }
            return container;
        }
    }
}