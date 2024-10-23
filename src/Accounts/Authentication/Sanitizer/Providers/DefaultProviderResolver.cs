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

using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    internal class DefaultProviderResolver : ISanitizerProviderResolver
    {
        private readonly SanitizerProviderCache<Type, SanitizerProviderBase> _providerCache;

        private static readonly ISanitizerProviderResolver _instance = new DefaultProviderResolver();

        public static ISanitizerProviderResolver Instance => _instance;

        public ISanitizerService Service => new DefaultSanitizerService();

        private DefaultProviderResolver()
        {
            _providerCache = new SanitizerProviderCache<Type, SanitizerProviderBase>(CreateProvider);
        }

        public SanitizerProviderBase ResolveProvider(Type type)
        {
            return _providerCache.GetSanitizerProvider(type);
        }

        private SanitizerProviderBase CreateProvider(Type type)
        {
            SanitizerProviderBase provider = null;

            if (Service != null && !type.IsByRef)
            {
                switch (type)
                {
                    case Type _ when IsOfTypeString(type):
                        provider = CreateStringProvider();
                        break;
                    case Type _ when IsOfTypeJsonObject(type):
                        provider = CreateJsonObjectProvider();
                        break;
                    case Type _ when IsOfTypeJsonArray(type):
                        provider = CreateJsonArrayProvider();
                        break;
                    case Type _ when IsOfTypeDictionary(type):
                        provider = CreateDictionaryProvider();
                        break;
                    case Type _ when IsOfTypeCollection(type):
                        provider = CreateCollectionProvider();
                        break;
                    case Type _ when IsOfTypeCustomObject(type):
                        provider = CreateCustomObjectProvider(type);
                        break;
                }
            }

            return provider;
        }

        private bool IsOfTypeString(Type type)
        {
            return type == typeof(string);
        }

        private SanitizerProviderBase CreateStringProvider()
        {
            return new SanitizerStringProvider(Service);
        }

        private bool IsOfTypeJsonObject(Type type)
        {
            return type == typeof(JObject);
        }

        private SanitizerProviderBase CreateJsonObjectProvider()
        {
            return new SanitizerJsonObjectProvider(Service);
        }

        private bool IsOfTypeJsonArray(Type type)
        {
            return type == typeof(JArray);
        }

        private SanitizerProviderBase CreateJsonArrayProvider()
        {
            return new SanitizerJsonArrayProvider(Service);
        }

        private bool IsOfTypeDictionary(Type type)
        {
            bool isDictionary = false;

            try
            {
                if (type != null && type != typeof(string))
                {
                    if (typeof(IDictionary).IsAssignableFrom(type))
                    {
                        isDictionary = true;
                    }
                    else if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<,>) && !type.GetGenericArguments()[1].IsValueType)
                    {
                        isDictionary = true;
                    }
                    else
                    {
                        foreach (var interfaceType in type.GetInterfaces())
                        {
                            if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IDictionary<,>) && !type.GetGenericArguments()[1].IsValueType)
                            {
                                isDictionary = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignore exceptions
            }

            return isDictionary;
        }

        private SanitizerProviderBase CreateDictionaryProvider()
        {
            return new SanitizerDictionaryProvider(Service);
        }

        private bool IsOfTypeCollection(Type type)
        {
            bool isCollection = false;

            try
            {
                if (type != null && type != typeof(string))
                {
                    if (typeof(IList).IsAssignableFrom(type))
                    {
                        isCollection = true;
                    }
                    else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>) && !type.GetGenericArguments()[0].IsValueType)
                    {
                        isCollection = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions
            }

            return isCollection;
        }

        private SanitizerProviderBase CreateCollectionProvider()
        {
            return new SanitizerCollectionProvider(Service);
        }

        private bool IsOfTypeCustomObject(Type type)
        {
            return type != null && type != typeof(string) && type.IsClass && !type.FullName.StartsWith("System.");
        }

        private bool IsIgnoredProperty(string typeName, string propertyName)
        {
            return Service.IgnoredProperties.TryGetValue(typeName, out var propertyNames) && propertyNames.Contains(propertyName);
        }

        private SanitizerProviderBase CreateCustomObjectProvider(Type objType)
        {
            var objProvider = new SanitizerCustomObjectProvider(Service);
            foreach (var property in objType.GetRuntimeProperties())
            {
                if (property.CanRead && !property.PropertyType.IsValueType && property.GetMethod != null && property.GetMethod.IsPublic && !property.GetMethod.IsStatic
                    && property.GetIndexParameters().Length == 0
                    && !IsIgnoredProperty(objType.FullName, property.Name))
                {
                    var sanitizerProperty = new SanitizerProperty(property);
                    objProvider.Properties.Add(sanitizerProperty);
                }
            }

            return objProvider;
        }
    }
}
