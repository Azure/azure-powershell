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

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps around MetricDefinition to provide detailed data about it
    /// </summary>
    public class PSMetricDefinition : MetricDefinition
    {
        /// <summary>
        /// Gets or sets the MetricAvailabilties of the metric
        /// </summary>
        public new PSAvailabilityCollection MetricAvailabilities { get; set; }

        /// <summary>
        /// Gets or sets the Name of the metric
        /// </summary>
        public new string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of Dimension objects
        /// </summary>
        protected internal new IList<Dimension> Dimensions
        {
            get { return base.Dimensions; }
            set { base.Dimensions = value; }
        }

        /// <summary>
        /// Gets or sets the Proterties of the metric
        /// </summary>
        public new PSDictionaryElement Properties { get; set; }

        /// <summary>
        /// Initializes an new instance of the PSMetricDefinition class
        /// </summary>
        /// <param name="metricDefinition">The MetricDefinition</param>
        public PSMetricDefinition(MetricDefinition metricDefinition)
        {
            // Keep the original value (localized string, Dictionary, List) in the base
            base.Dimensions = metricDefinition.Dimensions;
            base.MetricAvailabilities = metricDefinition.MetricAvailabilities;
            base.Name = metricDefinition.Name;
            base.Properties = metricDefinition.Properties;

            this.MetricAvailabilities = new PSAvailabilityCollection(metricDefinition.MetricAvailabilities);
            this.Name = metricDefinition.Name.ToString(localizedValue: false);
            this.PrimaryAggregationType = metricDefinition.PrimaryAggregationType;
            this.Properties = new PSDictionaryElement(metricDefinition.Properties);
            this.ResourceId = metricDefinition.ResourceId;
            this.Unit = metricDefinition.Unit;
        }
    }
}
