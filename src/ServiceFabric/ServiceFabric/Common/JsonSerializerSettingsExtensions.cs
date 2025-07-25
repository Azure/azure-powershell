// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ServiceFabric.Common
{
    using Newtonsoft.Json;

    public static class JsonSerializerSettingsExtensions
    {
        public static JsonSerializerSettings DeepCopy(this JsonSerializerSettings serializerSettings)
        {
            var copiedSerializerSettings = new JsonSerializerSettings()
            {
                StringEscapeHandling = serializerSettings.StringEscapeHandling,
                FloatParseHandling = serializerSettings.FloatParseHandling,
                FloatFormatHandling = serializerSettings.FloatFormatHandling,
                DateParseHandling = serializerSettings.DateParseHandling,
                DateTimeZoneHandling = serializerSettings.DateTimeZoneHandling,
                DateFormatHandling = serializerSettings.DateFormatHandling,
                Formatting = serializerSettings.Formatting,
                MaxDepth = serializerSettings.MaxDepth,
                DateFormatString = serializerSettings.DateFormatString,
                Context = serializerSettings.Context,
                Error = serializerSettings.Error,
                SerializationBinder = serializerSettings.SerializationBinder,
                TraceWriter = serializerSettings.TraceWriter,
                Culture = serializerSettings.Culture,
                ReferenceResolverProvider = serializerSettings.ReferenceResolverProvider,
                EqualityComparer = serializerSettings.EqualityComparer,
                ContractResolver = serializerSettings.ContractResolver,
                ConstructorHandling = serializerSettings.ConstructorHandling,
                TypeNameAssemblyFormatHandling = serializerSettings.TypeNameAssemblyFormatHandling,
                MetadataPropertyHandling = serializerSettings.MetadataPropertyHandling,
                TypeNameHandling = serializerSettings.TypeNameHandling,
                PreserveReferencesHandling = serializerSettings.PreserveReferencesHandling,
                DefaultValueHandling = serializerSettings.DefaultValueHandling,
                NullValueHandling = serializerSettings.NullValueHandling,
                ObjectCreationHandling = serializerSettings.ObjectCreationHandling,
                MissingMemberHandling = serializerSettings.MissingMemberHandling,
                ReferenceLoopHandling = serializerSettings.ReferenceLoopHandling,
                CheckAdditionalContent = serializerSettings.CheckAdditionalContent
            };

            foreach (var converter in serializerSettings.Converters)
            {
                copiedSerializerSettings.Converters.Add(converter);
            }

            return copiedSerializerSettings;
        }
    }
}
