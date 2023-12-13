/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal class JsonSerializer
    {
        private int depth = 0;

        private SerializationOptions options = new SerializationOptions();

        #region Deserialization

        internal T Deseralize<T>(JsonObject json)
            where T : new()
        {
            var contract = JsonModelCache.Get(typeof(T));

            return (T)DeserializeObject(contract, json);
        }

        internal object DeserializeObject(JsonModel contract, JsonObject json)
        {
            var instance = Activator.CreateInstance(contract.Type);

            depth++;

            // Ensure we don't recurse forever
            if (depth > 5) throw new Exception("Depth greater than 5");

            foreach (var field in json)
            {
                var member = contract[field.Key];

                if (member != null)
                {
                    var value = DeserializeValue(member, field.Value);

                    member.SetValue(instance, value);
                }
            }

            depth--;

            return instance;
        }

        private object DeserializeValue(JsonMember member, JsonNode value)
        {
            if (value.Type == JsonType.Null) return null;

            var type = member.Type;

            if (member.IsStringLike && value.Type != JsonType.String)
            {
                // Take the long path...
                return DeserializeObject(JsonModelCache.Get(type), (JsonObject)value);
            }
            else if (member.Converter != null)
            {
                return member.Converter.FromJson(value);
            }
            else if (type.IsArray)
            {
                return DeserializeArray(type, (JsonArray)value);
            }
            else if (member.IsList)
            {
                return DeserializeList(type, (JsonArray)value);
            }
            else
            {
                var contract = JsonModelCache.Get(type);

                return DeserializeObject(contract, (JsonObject)value);
            }
        }

        private object DeserializeValue(Type type, JsonNode value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (value.Type == JsonType.Null) return null;

            var typeDetails = TypeDetails.Get(type);

            if (typeDetails.JsonConverter != null)
            {
                return typeDetails.JsonConverter.FromJson(value);
            }
            else if (typeDetails.IsEnum)
            {
                return Enum.Parse(type, value.ToString(), ignoreCase: true);
            }
            else if (type.IsArray)
            {
                return DeserializeArray(type, (JsonArray)value);
            }
            else if (typeDetails.IsList)
            {
                return DeserializeList(type, (JsonArray)value);
            }
            else
            {
                var contract = JsonModelCache.Get(type);

                return DeserializeObject(contract, (JsonObject)value);
            }
        }

        internal Array DeserializeArray(Type type, JsonArray elements)
        {
            var elementType = type.GetElementType();

            var elementTypeDetails = TypeDetails.Get(elementType);

            var array = Array.CreateInstance(elementType, elements.Count);

            int i = 0;

            if (elementTypeDetails.JsonConverter != null)
            {
                foreach (var value in elements)
                {
                    array.SetValue(elementTypeDetails.JsonConverter.FromJson(value), i);

                    i++;
                }
            }
            else
            {
                foreach (var value in elements)
                {
                    array.SetValue(DeserializeValue(elementType, value), i);

                    i++;
                }
            }

            return array;
        }

        internal IList DeserializeList(Type type, JsonArray jsonArray)
        {
            // TODO: Handle non-generic types
            if (!type.IsGenericType)
                throw new ArgumentException("Must be a generic type", nameof(type));

            var elementType = type.GetGenericArguments()[0];

            IList list;

            if (type.IsInterface)
            {
                // Create a concrete generic list
                list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
            }
            else
            {
                list = (IList)Activator.CreateInstance(type);
            }

            foreach (var value in jsonArray)
            {
                list.Add(DeserializeValue(elementType, value));
            }

            return list;
        }

        #endregion

        #region Serialization

        internal JsonNode Serialize(object instance) =>
            Serialize(instance, SerializationOptions.Default);

        internal JsonNode Serialize(object instance, string[] include) =>
            Serialize(instance, new SerializationOptions { Include = include });

        internal JsonNode Serialize(object instance, SerializationOptions options)
        {
            this.options = options;

            if (instance == null)
            {
                return XNull.Instance;
            }

            return ReadValue(instance.GetType(), instance);
        }

        #region Readers

        internal JsonArray ReadArray(IEnumerable collection)
        {
            var array = new XNodeArray();

            foreach (var item in collection)
            {
                array.Add(ReadValue(item.GetType(), item));
            }

            return array;
        }

        internal IEnumerable<KeyValuePair<string, JsonNode>> ReadProperties(object instance)
        {
            var contract = JsonModelCache.Get(instance.GetType());

            foreach (var member in contract.Members)
            {
                string name = member.Name;

                if (options.PropertyNameTransformer != null)
                {
                    name = options.PropertyNameTransformer.Invoke(name);
                }

                // Skip the field if it's not included
                if ((depth == 1 && !options.IsIncluded(name)))
                {
                    continue;
                }

                var value = member.GetValue(instance);

                if (!member.EmitDefaultValue && (value == null || (member.IsList && ((IList)value).Count == 0) || value.Equals(member.DefaultValue)))
                {
                    continue;
                }
                else if (options.IgnoreNullValues && value == null) // Ignore null values
                {
                    continue;
                }

                // Transform the value if there is one
                if (options.Transformations != null)
                {
                    var transform = options.GetTransformation(name);

                    if (transform != null)
                    {
                        value = transform.Transformer(value);
                    }
                }

                yield return new KeyValuePair<string, JsonNode>(name, ReadValue(member.TypeDetails, value));
            }
        }

        private JsonObject ReadObject(object instance)
        {
            depth++;

            // TODO: Guard against a self referencing graph
            if (depth > options.MaxDepth)
            {
                depth--;

                return new JsonObject();
            }

            var node = new JsonObject(ReadProperties(instance));

            depth--;

            return node;
        }

        private JsonNode ReadValue(Type type, object value)
        {
            if (value == null)
            {
                return XNull.Instance;
            }

            var member = TypeDetails.Get(type);

            return ReadValue(member, value);
        }

        private JsonNode ReadValue(TypeDetails type, object value)
        {
            if (value == null)
            {
                return XNull.Instance;
            }

            if (type.JsonConverter != null)
            {
                return type.JsonConverter.ToJson(value);
            }
            else if (type.IsArray)
            {
                switch (Type.GetTypeCode(type.ElementType))
                {
                    case TypeCode.String: return CreateArray((string[])value);
                    case TypeCode.UInt16: return CreateArray((ushort[])value);
                    case TypeCode.UInt32: return CreateArray((uint[])value);
                    case TypeCode.UInt64: return CreateArray((ulong[])value);
                    case TypeCode.Int16: return CreateArray((short[])value);
                    case TypeCode.Int32: return CreateArray((int[])value);
                    case TypeCode.Int64: return CreateArray((long[])value);
                    case TypeCode.Single: return CreateArray((float[])value);
                    case TypeCode.Double: return CreateArray((double[])value);
                    default: return ReadArray((IEnumerable)value);
                }
            }
            else if (value is IEnumerable)
            {
                if (type.IsList && type.ElementType != null)
                {
                    switch (Type.GetTypeCode(type.ElementType))
                    {
                        case TypeCode.String: return CreateList<string>(value);
                        case TypeCode.UInt16: return CreateList<ushort>(value);
                        case TypeCode.UInt32: return CreateList<uint>(value);
                        case TypeCode.UInt64: return CreateList<ulong>(value);
                        case TypeCode.Int16: return CreateList<short>(value);
                        case TypeCode.Int32: return CreateList<int>(value);
                        case TypeCode.Int64: return CreateList<long>(value);
                        case TypeCode.Single: return CreateList<float>(value);
                        case TypeCode.Double: return CreateList<double>(value);
                    }
                }

                return ReadArray((IEnumerable)value);
            }
            else
            {
                // Complex object
                return ReadObject(value);
            }
        }

        private XList<T> CreateList<T>(object value) => new XList<T>((IList<T>)value);

        private XImmutableArray<T> CreateArray<T>(T[] array) =>  new XImmutableArray<T>(array);

        #endregion

        #endregion
    }
}