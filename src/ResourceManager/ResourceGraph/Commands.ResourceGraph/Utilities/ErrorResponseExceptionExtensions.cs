namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceGraph.Models;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;

    public static class ErrorResponseExceptionExtensions
    {
        /// <summary>
        /// The serialization settings
        /// </summary>
        private static readonly JsonSerializerSettings SerializationSettings =
            new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                Converters = new List<JsonConverter>
                {
                    new Iso8601TimeSpanConverter()
                }
            };

        /// <summary>
        /// To the displayable json.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static string ToDisplayableJson(this ErrorResponseException ex)
        {
            return SafeJsonConvert.SerializeObject(ex.Body, SerializationSettings);
        }
    }
}
