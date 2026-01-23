// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.Json;

    /// <summary>
    /// Partial class to properly handle IAny (free-form object) serialization.
    /// The generated code creates an empty object - this fixes it to store and serialize content.
    /// </summary>
    public partial class Any
    {
        private IDictionary _content;

        /// <summary>
        /// Called after deserializing from a dictionary. Stores the content for later serialization.
        /// </summary>
        partial void AfterDeserializeDictionary(IDictionary content)
        {
            _content = content;
        }

        /// <summary>
        /// Called after deserializing from a PSObject. Converts to dictionary and stores.
        /// </summary>
        partial void AfterDeserializePSObject(System.Management.Automation.PSObject content)
        {
            _content = new Dictionary<string, object>();
            foreach (var prop in content.Properties)
            {
                if (prop.MemberType == System.Management.Automation.PSMemberTypes.NoteProperty)
                {
                    _content[prop.Name] = prop.Value;
                }
            }
        }

        /// <summary>
        /// Called before serializing to JSON. Outputs the stored content.
        /// </summary>
        partial void BeforeToJson(ref JsonObject container, ref bool returnNow)
        {
            if (_content != null)
            {
                SerializeDictionary(_content, container);
                returnNow = true;
            }
        }

        /// <summary>
        /// Recursively serializes a dictionary to a JSON container.
        /// </summary>
        private void SerializeDictionary(IDictionary dict, JsonObject container)
        {
            foreach (DictionaryEntry entry in dict)
            {
                string key = entry.Key?.ToString();
                if (string.IsNullOrEmpty(key)) continue;

                container.Add(key, SerializeValue(entry.Value));
            }
        }

        /// <summary>
        /// Serializes a value to a JsonNode.
        /// </summary>
        private JsonNode SerializeValue(object value)
        {
            if (value == null)
            {
                return JsonNode.Parse("null");
            }

            // Handle PSObject wrapper
            if (value is System.Management.Automation.PSObject psObj)
            {
                value = psObj.BaseObject;
            }

            // Handle primitives
            if (value is string s)
            {
                return new JsonString(s);
            }
            if (value is bool b)
            {
                return new JsonBoolean(b);
            }
            if (value is int i)
            {
                return new JsonNumber(i);
            }
            if (value is long l)
            {
                return new JsonNumber(l);
            }
            if (value is double d)
            {
                return new JsonNumber(d);
            }
            if (value is float f)
            {
                return new JsonNumber(f);
            }
            if (value is decimal dec)
            {
                return new JsonNumber((double)dec);
            }

            // Handle arrays/collections
            if (value is IList list)
            {
                var array = new XNodeArray();
                foreach (var item in list)
                {
                    array.SafeAdd(SerializeValue(item));
                }
                return array;
            }

            // Handle object arrays
            if (value is object[] objArray)
            {
                var array = new XNodeArray();
                foreach (var item in objArray)
                {
                    array.SafeAdd(SerializeValue(item));
                }
                return array;
            }

            // Handle dictionaries/hashtables
            if (value is IDictionary dict)
            {
                var obj = new JsonObject();
                SerializeDictionary(dict, obj);
                return obj;
            }

            // Handle PSObject with properties (like hashtable converted to PSObject)
            if (value is System.Management.Automation.PSObject pso)
            {
                var obj = new JsonObject();
                foreach (var prop in pso.Properties)
                {
                    if (prop.MemberType == System.Management.Automation.PSMemberTypes.NoteProperty)
                    {
                        obj.Add(prop.Name, SerializeValue(prop.Value));
                    }
                }
                return obj;
            }

            // Fallback: try to convert to string
            return new JsonString(value.ToString());
        }
    }
}
