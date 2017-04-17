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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRmProfileConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IAzureContext) 
                || objectType == typeof(IAzureAccount) 
                || objectType == typeof(IAzureSubscription) 
                || objectType == typeof(IAzureTenant) 
                || objectType == typeof(IAzureTokenCache);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType is IAzureContext)
            {
                return serializer.Deserialize<AzureContext>(reader);
            }
            else if (objectType is IAzureAccount)
            {
                return serializer.Deserialize<AzureAccount>(reader);
            }
            else if (objectType is IAzureSubscription)
            {
                return serializer.Deserialize<AzureSubscription>(reader);
            }
            else if (objectType is IAzureTenant)
            {
                return serializer.Deserialize<AzureTenant>(reader);
            }
            else if (objectType is IAzureTokenCache)
            {
                return serializer.Deserialize<AzureTokenCache>(reader);
            }

            return serializer.Deserialize(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
