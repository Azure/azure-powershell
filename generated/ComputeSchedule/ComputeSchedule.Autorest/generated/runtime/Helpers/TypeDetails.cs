/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    
    

    internal class TypeDetails
    {
        private readonly Type info;

        internal TypeDetails(Type info)
        {
            this.info = info ?? throw new ArgumentNullException(nameof(info));
        }

        internal Type NonNullType { get; set; }

        internal object DefaultValue { get; set; }

        internal bool IsNullable { get; set; }

        internal bool IsList { get; set; }

        internal bool IsStringLike { get; set; }

        internal bool IsEnum => info.IsEnum;

        internal bool IsArray => info.IsArray;

        internal bool IsValueType => info.IsValueType;

        internal Type ElementType { get; set; }

        internal IJsonConverter JsonConverter { get; set; }

        #region Creation

        private static readonly ConcurrentDictionary<Type, TypeDetails> cache = new ConcurrentDictionary<Type, TypeDetails>();

        internal static TypeDetails Get<T>() => Get(typeof(T));

        internal static TypeDetails Get(Type type) => cache.GetOrAdd(type, Create);

        private static TypeDetails Create(Type type)
        {
            var isGenericList = !type.IsPrimitive && type.ImplementsOpenGenericInterface(typeof(IList<>));
            var isList        = !type.IsPrimitive && (isGenericList || typeof(IList).IsAssignableFrom(type));

            var isNullable = type.IsNullable();

            Type elementType;

            if (type.IsArray)
            {
                elementType = type.GetElementType();
            }
            else if (isGenericList)
            {
                var iList = type.GetOpenGenericInterface(typeof(IList<>));

                elementType = iList.GetGenericArguments()[0];
            }
            else
            {
                elementType = null;
            }

            var nonNullType = isNullable ? type.GetGenericArguments()[0] : type;

            var isStringLike = false;

            IJsonConverter converter;

            var jsonConverterAttribute = type.GetCustomAttribute<JsonConverterAttribute>();

            if (jsonConverterAttribute != null)
            {
                converter = jsonConverterAttribute.Converter;
            }
            else if (nonNullType.IsEnum)
            {
                converter = new EnumConverter(nonNullType);
            }
            else if (JsonConverterFactory.Instances.TryGetValue(nonNullType, out converter))
            {
            }
            else if (StringLikeHelper.IsStringLike(nonNullType))
            {
                isStringLike = true;

                converter = new StringLikeConverter(nonNullType);
            }

            return new TypeDetails(nonNullType) {
                NonNullType   = nonNullType,
                DefaultValue  = type.IsValueType ? Activator.CreateInstance(type) : null,
                IsNullable    = isNullable,
                IsList        = isList,
                IsStringLike  = isStringLike,
                ElementType   = elementType,
                JsonConverter = converter
            };
        }      

        #endregion
    }
}