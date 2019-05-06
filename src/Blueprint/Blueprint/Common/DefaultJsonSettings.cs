using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public static class DefaultJsonSettings
    {
        /// <summary>
        /// Serializer settings for JSON schemas owned by Blueprint RP. Use this to (de)serialize doc db entities,
        /// blueprint rp resource bodies, or any objects whose schema we control.
        /// </summary>
        public static JsonSerializerSettings DeserializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                    ContractResolver = new ReadOnlyJsonContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
                };

                settings.Converters.Add(new PolymorphicDeserializeJsonConverter<Artifact>("kind"));
                settings.Converters.Add(new TransformationJsonConverter());
                settings.Converters.Add(new CloudErrorJsonConverter());

                return settings;
            }
        }
        public static JsonSerializerSettings SerializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                    ContractResolver = new ReadOnlyJsonContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
                };

                settings.Converters.Add(new TransformationJsonConverter());
                settings.Converters.Add(new PolymorphicSerializeJsonConverter<Artifact>("kind"));

                return settings;
            }
        }
    }
}
