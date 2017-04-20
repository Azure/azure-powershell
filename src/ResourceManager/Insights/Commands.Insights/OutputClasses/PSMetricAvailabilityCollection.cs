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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps around a list of MetricAvailability objects to display them with indentation
    /// </summary>
    public class PSMetricAvailabilityCollection : List<MetricAvailability>
    {
        /// <summary>
        /// Initializes a new instance of the PSAvailabilityCollection class
        /// </summary>
        /// <param name="metricAvailabilities">The list of metric availabilities</param>
        public PSMetricAvailabilityCollection(IEnumerable<MetricAvailability> metricAvailabilities)
        {
            this.AddRange(metricAvailabilities.Select(e => new PSMetricAvailability(e)));
        }

/*        /// <summary>
        /// A string representation of the list MetricAvailability objects including indentation
        /// </summary>
        /// <returns>A string representation of the list of MetricAvailability objects including indentation</returns>
        public override string ToString()
        {
            return this.ToString(); //indentationTabs: 1);
        } */
    }
}
