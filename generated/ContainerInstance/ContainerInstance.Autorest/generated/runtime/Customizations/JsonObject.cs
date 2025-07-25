/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    using System;
    using System.Collections.Generic;

    public partial class JsonObject
    {
        internal override object ToValue() => Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.JsonSerializable.FromJson(this, new System.Collections.Generic.Dictionary<string, object>(), (obj) => obj.ToValue());

        internal void SafeAdd(string name, Func<JsonNode> valueFn)
        {
            if (valueFn != null)
            {
                var value = valueFn();
                if (null != value)
                {
                    items.Add(name, value);
                }
            }
        }

        internal void SafeAdd(string name, JsonNode value)
        {
            if (null != value)
            {
                items.Add(name, value);
            }
        }
        
        internal T NullableProperty<T>(string propertyName) where T : JsonNode
        {
            if (this.TryGetValue(propertyName, out JsonNode value))
            {
                if (value.IsNull)
                {
                    return null;
                }
                if (value is T tval)
                {
                    return tval;
                }
                /* it's present, but not the correct type...  */
                //throw new Exception($"Property {propertyName} in object expected type {typeof(T).Name} but value of type {value.Type.ToString()} was found.");
            }
            return null;
        }

        internal JsonObject Property(string propertyName)
        {
            return PropertyT<JsonObject>(propertyName);
        }

        internal T PropertyT<T>(string propertyName) where T : JsonNode
        {
            if (this.TryGetValue(propertyName, out JsonNode value))
            {
                if (value.IsNull)
                {
                    return null; // we're going to assume that the consumer knows what to do if null is explicity returned?
                }

                if (value is T tval)
                {
                    return tval;
                }
                /* it's present, but not the correct type...  */
                // throw new Exception($"Property {propertyName} in object expected type {typeof(T).Name} but value of type {value.Type.ToString()} was found.");
            }
            return null;
        }

        internal int NumberProperty(string propertyName, ref int output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToInt() ?? output;
        internal float NumberProperty(string propertyName, ref float output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToFloat() ?? output;
        internal byte NumberProperty(string propertyName, ref byte output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToByte() ?? output;
        internal long NumberProperty(string propertyName, ref long output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToLong() ?? output;
        internal double NumberProperty(string propertyName, ref double output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToDouble() ?? output;
        internal decimal NumberProperty(string propertyName, ref decimal output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToDecimal() ?? output;
        internal short NumberProperty(string propertyName, ref short output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToShort() ?? output;
        internal DateTime NumberProperty(string propertyName, ref DateTime output) => output = this.PropertyT<JsonNumber>(propertyName)?.ToDateTime() ?? output;

        internal int? NumberProperty(string propertyName, ref int? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToInt() ?? null;
        internal float? NumberProperty(string propertyName, ref float? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToFloat() ?? null;
        internal byte? NumberProperty(string propertyName, ref byte? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToByte() ?? null;
        internal long? NumberProperty(string propertyName, ref long? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToLong() ?? null;
        internal double? NumberProperty(string propertyName, ref double? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToDouble() ?? null;
        internal decimal? NumberProperty(string propertyName, ref decimal? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToDecimal() ?? null;
        internal short? NumberProperty(string propertyName, ref short? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToShort() ?? null;

        internal DateTime? NumberProperty(string propertyName, ref DateTime? output) => output = this.NullableProperty<JsonNumber>(propertyName)?.ToDateTime() ?? null;


        internal string StringProperty(string propertyName) => this.PropertyT<JsonString>(propertyName)?.ToString();
        internal string StringProperty(string propertyName, ref string output) => output = this.PropertyT<JsonString>(propertyName)?.ToString() ?? output;
        internal char StringProperty(string propertyName, ref char output) => output = this.PropertyT<JsonString>(propertyName)?.ToChar() ?? output;
        internal char? StringProperty(string propertyName, ref char? output) => output = this.PropertyT<JsonString>(propertyName)?.ToChar() ?? null;

        internal DateTime StringProperty(string propertyName, ref DateTime output) => DateTime.TryParse(this.PropertyT<JsonString>(propertyName)?.ToString(), out output) ? output : output;
        internal DateTime? StringProperty(string propertyName, ref DateTime? output) => output = DateTime.TryParse(this.PropertyT<JsonString>(propertyName)?.ToString(), out var o) ? o : output;


        internal bool BooleanProperty(string propertyName, ref bool output) => output = this.PropertyT<JsonBoolean>(propertyName)?.ToBoolean() ?? output;
        internal bool? BooleanProperty(string propertyName, ref bool? output) => output = this.PropertyT<JsonBoolean>(propertyName)?.ToBoolean() ?? null;

        internal T[] ArrayProperty<T>(string propertyName, ref T[] output, Func<JsonNode, T> deserializer)
        {
            var array = this.PropertyT<JsonArray>(propertyName);
            if (array != null)
            {
                output = new T[array.Count];
                for (var i = 0; i < output.Length; i++)
                {
                    output[i] = deserializer(array[i]);
                }
            }
            return output;
        }
        internal T[] ArrayProperty<T>(string propertyName, Func<JsonNode, T> deserializer)
        {
            var array = this.PropertyT<JsonArray>(propertyName);
            if (array != null)
            {
                var output = new T[array.Count];
                for (var i = 0; i < output.Length; i++)
                {
                    output[i] = deserializer(array[i]);
                }
                return output;
            }
             return new T[0];
        }
        internal void IterateArrayProperty(string propertyName, Action<JsonNode> deserializer)
        {
            var array = this.PropertyT<JsonArray>(propertyName);
            if (array != null)
            {
                for (var i = 0; i < array.Count; i++)
                {
                    deserializer(array[i]);
                }
            }
        }

        internal Dictionary<string, T> DictionaryProperty<T>(string propertyName, ref Dictionary<string, T> output, Func<JsonNode, T> deserializer)
        {
            var dictionary = this.PropertyT<JsonObject>(propertyName);
            if (output == null)
            {
                output = new Dictionary<string, T>();
            }
            else
            {
                output.Clear();
            }
            if (dictionary != null)
            {
                foreach (var key in dictionary.Keys)
                {
                    output[key] = deserializer(dictionary[key]);
                }
            }
            return output;
        }

        internal static JsonObject Create<T>(IDictionary<string, T> source, Func<T, JsonNode> selector)
        {
            if (source == null || selector == null)
            {
                return null;
            }
            var result = new JsonObject();

            foreach (var key in source.Keys)
            {
                result.SafeAdd(key, selector(source[key]));
            }
            return result;
        }
    }
}