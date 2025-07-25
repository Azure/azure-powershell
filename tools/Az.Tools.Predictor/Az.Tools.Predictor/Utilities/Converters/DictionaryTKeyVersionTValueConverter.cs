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
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities.Converters
{
    internal sealed class DictionaryTKeyVersionTValueConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(IDictionary<,>))
            {
                return false;
            }

            return typeToConvert.GetGenericArguments()[0] == typeof(Version);
        }

        public override JsonConverter CreateConverter(
            Type type,
            JsonSerializerOptions options)
        {
            Type keyType = type.GetGenericArguments()[0];
            Type valueType = type.GetGenericArguments()[1];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(DictionaryVersionConverterInner<,>).MakeGenericType(
                    new Type[] { keyType, valueType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

            return converter;
        }

        private class DictionaryVersionConverterInner<TKey, TValue> :
            JsonConverter<IDictionary<Version, TValue>>
        {
            private readonly JsonConverter<TValue> _valueConverter;
            private readonly Type _keyType;
            private readonly Type _valueType;

            public DictionaryVersionConverterInner(JsonSerializerOptions options)
            {
                // For performance, use the existing converter if available.
                _valueConverter = (JsonConverter<TValue>)options
                    .GetConverter(typeof(TValue));

                // Cache the key and value types.
                _keyType = typeof(TKey);
                _valueType = typeof(TValue);
            }

            public override IDictionary<Version, TValue> Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                } 

                var dictionary = new Dictionary<Version, TValue>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return dictionary;
                    }

                    // Get the key.
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new JsonException();
                    }

                    string propertyName = reader.GetString();

                    if (!Version.TryParse(propertyName, out Version key))
                    {
                        throw new JsonException(
                            $"Unable to convert \"{propertyName}\" to System.Version.");
                    }

                    // Get the value.
                    TValue value;
                    if (_valueConverter != null)
                    {
                        reader.Read();
                        value = _valueConverter.Read(ref reader, _valueType, options);
                    }
                    else
                    {
                        value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                    }

                    // Add to dictionary.
                    dictionary.Add(key, value);
                }

                throw new JsonException();
            }

            public override void Write(
                Utf8JsonWriter writer,
                IDictionary<Version, TValue> dictionary,
                JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach ((Version key, TValue value) in dictionary)
                {
                    var propertyName = key.ToString();
                    writer.WritePropertyName
                        (options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

                    if (_valueConverter != null)
                    {
                        _valueConverter.Write(writer, value, options);
                    }
                    else
                    {
                        JsonSerializer.Serialize(writer, value, options);
                    }
                }

                writer.WriteEndObject();
            }
        }
    }
}
