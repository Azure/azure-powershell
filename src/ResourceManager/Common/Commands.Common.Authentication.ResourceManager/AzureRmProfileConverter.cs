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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRmProfileConverter : JsonConverter
    {
        bool _serializeCache;
        public AzureRmProfileConverter(bool serializeCache = true) 
        {
            _serializeCache = serializeCache;
        }

        public override bool CanWrite => true;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IAzureContext) 
                || objectType == typeof(IAzureAccount) 
                || objectType == typeof(IAzureSubscription)
                || objectType == typeof(IAzureEnvironment)
                || objectType == typeof(IAzureTenant) 
                || objectType == typeof(IAzureTokenCache)
                || objectType == typeof(AzureTokenCache) 
                || objectType == typeof(ProtectedFileTokenCache)
                || objectType == typeof(AuthenticationStoreTokenCache)
                || objectType == typeof(IAzureContextContainer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(IAzureContextContainer))
            {
                return serializer.Deserialize<AzureRmProfile>(reader);
            }
            if (objectType == typeof(IAzureContext))
            {
                return serializer.Deserialize<AzureContext>(reader);
            }
            else if (objectType == typeof(IAzureAccount))
            {
                return serializer.Deserialize<AzureAccount>(reader);
            }
            else if (objectType  == typeof(IAzureSubscription))
            {
                return serializer.Deserialize<AzureSubscription>(reader);
            }
            else if (objectType == typeof(IAzureTenant))
            {
                return serializer.Deserialize<AzureTenant>(reader);
            }
            else if (objectType == typeof(IAzureEnvironment))
            {
                return serializer.Deserialize<AzureEnvironment>(reader);
            }
            else if (objectType == typeof(IAzureTokenCache))
            {
                var tempResult = serializer.Deserialize<CacheBuffer>(reader);
                var cache = AzureSession.Instance.TokenCache;
                if (_serializeCache && tempResult != null && tempResult.CacheData != null && tempResult.CacheData.Length > 0)
                {
                    cache.CacheData = tempResult.CacheData;
                }

                return cache;
            }
            else if (objectType == typeof(Dictionary<string, IAzureEnvironment>))
            {
                var tempResult = serializer.Deserialize<Dictionary<string, AzureEnvironment>>(reader);
                var result = new Dictionary<string, IAzureEnvironment>(StringComparer.OrdinalIgnoreCase);
                foreach (var key in tempResult.Keys)
                {
                    result[key] = tempResult[key];
                }

                return result;
            }
            else if (objectType == typeof(Dictionary<string, IAzureContext>))
            {
                var tempResult = serializer.Deserialize<Dictionary<string, AzureContext>>(reader);
                var result = new Dictionary<string, IAzureContext>(StringComparer.OrdinalIgnoreCase);
                foreach (var key in tempResult.Keys)
                {
                    result[key] = tempResult[key];
                }

                return result;
            }

            return serializer.Deserialize(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IAzureTokenCache cache = value as IAzureTokenCache;
            if (cache != null)
            {
                if (_serializeCache)
                {
                    value = new CacheBuffer { CacheData = cache.CacheData };
                }
                else
                {
                    value = new CacheBuffer();
                }
            }

            serializer.Serialize(writer, value);
        }
    }
}
