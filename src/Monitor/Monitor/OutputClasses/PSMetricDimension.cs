using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSMetricDimension
    {
        /// <summary>
        /// Initializes a new instance of the MetricDimension class.
        /// </summary>
        /// <param name="dimension">Name of the dimension.</param>
        /// <param name="includeValues">List dimension includeValues.</param>
        /// <param name="excludeValues">List of dimension excludeValues.</param>

        public PSMetricDimension(string dimensionName, string[] valuesToInclude, string[] valuesToExclude)
        {
            Dimension = dimensionName;
            IncludeValues = valuesToInclude;
            ExcludeValues = valuesToExclude;
        }

        /// <summary>
        /// Gets or sets name of the dimension.
        /// </summary>
        [JsonProperty(PropertyName = "dimension")]
        public string Dimension { get; set; }

        /// <summary>
        /// Gets or sets list of dimension includeValues.
        /// </summary>
        [JsonProperty(PropertyName = "includeValues")]
        public IList<string> IncludeValues { get; set; }

        /// <summary>
        /// Gets or sets list of dimension excludeValues.
        /// </summary>
        [JsonProperty(PropertyName = "excludeValues")]
        public IList<string> ExcludeValues { get; set; }
    }
}
