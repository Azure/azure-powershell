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

using Microsoft.Azure.Insights.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps around a list of PSMetricValue objects to display them with indentation
    /// </summary>
    public class PSMetricValuesCollection
    {
        private IList<PSMetricValue> metricValues;

        /// <summary>
        /// Initializes a new instance of the PSMetricValuesCollection class
        /// </summary>
        /// <param name="metricValues">The list of metric values</param>
        public PSMetricValuesCollection(IEnumerable<MetricValue> metricValues)
        {
            this.metricValues = metricValues.Select(mv => new PSMetricValue(mv)).ToList();
        }

        /// <summary>
        /// A string representation of the list Dimension objects including indentation
        /// </summary>
        /// <returns>A string representation of the list of Dimension objects including indentation</returns>
        public override string ToString()
        {
            return this.metricValues.ToString(indentationTabs: 1);
        }
    }
}
