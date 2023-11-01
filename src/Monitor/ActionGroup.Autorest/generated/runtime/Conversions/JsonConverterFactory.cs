/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public sealed class JsonConverterFactory
    {
        private static readonly Dictionary<Type, IJsonConverter> converters = new Dictionary<Type, IJsonConverter>();

        static JsonConverterFactory()
        {
            AddInternal<Boolean>(new BooleanConverter());
            AddInternal<DateTime>(new DateTimeConverter());
            AddInternal<DateTimeOffset>(new DateTimeOffsetConverter());
            AddInternal<Byte[]>(new BinaryConverter());
            AddInternal<Decimal>(new DecimalConverter());
            AddInternal<Double>(new DoubleConverter());
            AddInternal<Guid>(new GuidConverter());
            AddInternal<Int16>(new Int16Converter());
            AddInternal<Int32>(new Int32Converter());
            AddInternal<Int64>(new Int64Converter());
            AddInternal<Single>(new SingleConverter());
            AddInternal<String>(new StringConverter());
            AddInternal<TimeSpan>(new TimeSpanConverter());
            AddInternal<UInt16>(new UInt16Converter());
            AddInternal<UInt32>(new UInt32Converter());
            AddInternal<UInt64>(new UInt64Converter());
            AddInternal<Uri>(new UriConverter());

            // Hash sets
            AddInternal(new HashSetConverter<string>());
            AddInternal(new HashSetConverter<short>());
            AddInternal(new HashSetConverter<int>());
            AddInternal(new HashSetConverter<long>());
            AddInternal(new HashSetConverter<float>());
            AddInternal(new HashSetConverter<double>());

            // JSON

            AddInternal(new JsonObjectConverter());
            AddInternal(new JsonArrayConverter());
        }

        internal static Dictionary<Type, IJsonConverter> Instances => converters;

        internal static IJsonConverter Get(Type type)
        {
            var details = TypeDetails.Get(type);

            if (details.JsonConverter == null)
            {
                throw new ConversionException($"No converter found for '{type.Name}'.");
            }

            return details.JsonConverter;
        }

        internal static bool TryGet(Type type, out IJsonConverter converter)
        {
            var typeDetails = TypeDetails.Get(type);

            converter = typeDetails.JsonConverter;

            return converter != null;
        }

        private static void AddInternal<T>(JsonConverter<T> converter)
            => converters.Add(typeof(T), converter);

        private static void AddInternal<T>(IJsonConverter converter)
            => converters.Add(typeof(T), converter);

        internal static void Add<T>(JsonConverter<T> converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            AddInternal(converter);

            var type = TypeDetails.Get<T>();

            type.JsonConverter = converter;
        }
    }
}