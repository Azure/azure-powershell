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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSMetricDimension
    {
        /// <summary>
        /// Initializes a new instance of the MetricDimension class.
        /// </summary>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="valuesToInclude">List dimension includeValues.</param>
        /// <param name="valuesToExclude">List of dimension excludeValues.</param>

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
