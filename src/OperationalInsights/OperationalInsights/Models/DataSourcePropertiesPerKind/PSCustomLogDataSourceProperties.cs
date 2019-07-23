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
        [JsonProperty(PropertyName = "fileSystemLocations")]
        public FileSystemLocations FileSystemLocations { get; set; }

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
        [JsonProperty(PropertyName = "linuxFileTypeLogPaths")]
        public string[] LinuxFileTypeLogPaths { get; set; }

        /// <summary>
        /// Gets or sets the windows file type log paths.
        /// </summary>
        [JsonProperty(PropertyName = "windowsFileTypeLogPaths")]
        public string[] WindowsFileTypeLogPaths { get; set; }

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
        [JsonProperty(PropertyName = "regexDelimiter")]
        public RegexDelimiter RegexDelimiter { get; set; }

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
        [JsonProperty(PropertyName = "matchIndex")]
        public int MatchIndex { get; set; }

        /// <summary>
        /// Gets or sets the numberd group.
        /// </summary>
        [JsonProperty(PropertyName = "numberdGroup")]
        public string NumberdGroup { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        [JsonProperty(PropertyName = "pattern")]
        public string Pattern { get; set; }

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
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the record delimiter.
        /// </summary>
        [JsonProperty(PropertyName = "recordDelimiter")]
        public RecordDelimiter RecordDelimiter { get; set; }

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
        [JsonProperty("joinStringRegex")]
        public string JoinStringRegex { get; set; }

        /// <summary>
        /// Gets or sets the regex string.
        /// </summary>
        [JsonIgnore]
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        [CmdletParameterBreakingChange(nameof(Regex), OldParamaterType = typeof(string), NewParameterTypeName = nameof(RegexDelimiter))]
        [JsonConverter(typeof(RegexDelimiterJsonConverter))]
        [JsonProperty("regex")]
        public RegexDelimiter[] RegexDelimiters { get; set; }

        ///<summary>
        /// Gets or sets the FormatString
        /// </summary>
        [JsonProperty("formatString")]
        public string FormatString { get; set; }

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
        [JsonProperty(PropertyName = "dateTimeExtraction")]
        public DateTimeExtraction DateTimeExtraction { get; set; }

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
        [JsonProperty(PropertyName = "extractionName")]
        public string ExtractionName { get; set; }

        /// <summary>
        /// Gets or sets the extraction properties.
        /// </summary>
        [JsonProperty(PropertyName = "extractionProperties")]
        public ExtractionProperties ExtractionProperties { get; set; }

        /// <summary>
        /// Gets or sets the extraction type.
        /// </summary>
        [JsonProperty(PropertyName = "extractionType")]
        public string ExtractionType { get; set; }

        #endregion
    }

    // This converter allows backward compatibility
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
                    // Satisfy case in which user uses the old regex property in input
                    return new[] {new RegexDelimiter {MatchIndex = 0, Pattern = (string) reader.Value}};
                case JsonToken.Null:
                    return null;
                default:
                    throw new JsonSerializationException();
            }
        }

        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
