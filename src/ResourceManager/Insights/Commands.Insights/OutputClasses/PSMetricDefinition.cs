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

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps around MetricDefinition to provide detailed data about it
    /// </summary>
    public class PSMetricDefinition : MetricDefinition
    {
        /// <summary>
        /// Initializes an new instance of the PSMetricDefinition class
        /// </summary>
        /// <param name="metricDefinition">The MetricDefinition</param>
        public PSMetricDefinition(MetricDefinition metricDefinition)
            : base(name: new PSLocalizableString(metricDefinition.Name), metricAvailabilities: new PSMetricAvailabilityCollection(metricDefinition.MetricAvailabilities), primaryAggregationType: metricDefinition.PrimaryAggregationType, resourceId: metricDefinition.ResourceId, unit: metricDefinition.Unit, id: metricDefinition.Id)
        {
        }
    }
}
