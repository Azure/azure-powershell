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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSCustomLogDataSourceProperties: PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.CustomLog; } }

        /// <summary>
        /// Gets or sets the custom log name.
        /// </summary>
        [JsonProperty(PropertyName= "customLogName")]
        public string CustomLogName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the extractions.
        /// </summary>
        [JsonProperty(PropertyName = "extractions")]
        public List<CustomLogExtraction> Extractions { get; set; }

        /// <summary>
        /// Gets or sets the inputs.
        /// </summary>
        [JsonProperty(PropertyName = "inputs")]
        public List<CustomLogInput> Inputs { get; set; }
    }

    /// <summary>
    /// The location.
    /// </summary>
    public class Location
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the file system locations.
        /// </summary>
        public FileSystemLocations fileSystemLocations { get; set; }

        #endregion
    }

    /// <summary>
    /// The file system locations.
    /// </summary>
    public class FileSystemLocations
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the linux file type log paths.
        /// </summary>
        public string[] linuxFileTypeLogPaths { get; set; }

        /// <summary>
        /// Gets or sets the windows file type log paths.
        /// </summary>
        public string[] windowsFileTypeLogPaths { get; set; }

        #endregion
    }

    /// <summary>
    /// The record delimiter.
    /// </summary>
    public class RecordDelimiter
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the regex delimiter.
        /// </summary>
        public RegexDelimiter regexDelimiter { get; set; }

        #endregion
    }

    /// <summary>
    /// The regex delimiter.
    /// </summary>
    public class RegexDelimiter
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the match index.
        /// </summary>
        public int matchIndex { get; set; }

        /// <summary>
        /// Gets or sets the numberd group.
        /// </summary>
        public string numberdGroup { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string pattern { get; set; }

        #endregion
    }

    /// <summary>
    /// The custom log input.
    /// </summary>
    public class CustomLogInput
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public Location location { get; set; }

        /// <summary>
        /// Gets or sets the record delimiter.
        /// </summary>
        public RecordDelimiter recordDelimiter { get; set; }

        #endregion
    }

    /// <summary>
    /// The date time extraction.
    /// </summary>
    public class DateTimeExtraction
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the join string regex.
        /// </summary>
        public string joinStringRegex { get; set; }

        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        [CmdletParameterBreakingChange(nameof(regex), OldParamaterType = typeof(string), NewParameterTypeName = nameof(RegexDelimiter))]
        [JsonConverter(typeof(RegexDelimiterJsonConverter))]
        public RegexDelimiter[] regex { get; set; }

        ///<summary>
        /// Gets or sets the FormatString
        /// </summary>
        public string formatString { get; set; }

        #endregion
    }

    /// <summary>
    /// The extraction properties.
    /// </summary>
    public class ExtractionProperties
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date time extraction.
        /// </summary>
        public DateTimeExtraction dateTimeExtraction { get; set; }

        #endregion
    }

    /// <summary>
    /// The custom log extraction.
    /// </summary>
    public class CustomLogExtraction
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the extraction name.
        /// </summary>
        public string extractionName { get; set; }

        /// <summary>
        /// Gets or sets the extraction properties.
        /// </summary>
        public ExtractionProperties extractionProperties { get; set; }

        /// <summary>
        /// Gets or sets the extraction type.
        /// </summary>
        public string extractionType { get; set; }

        #endregion
    }

    public class RegexDelimiterJsonConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    JToken token = JToken.Load(reader);
                    return token.ToObject<RegexDelimiter[]>();
                case JsonToken.String:
                    // Allow input of just regex string for backward compatibility
                    return new[] {new RegexDelimiter {matchIndex = 0, pattern = (string) reader.Value}};
            }

            throw new JsonSerializationException();
        }

        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
