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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
<<<<<<< HEAD
    public class PSMetricCriteria : MetricCriteria
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricCriteria class.
        /// </summary>
        /// <param name="metricCriteria">The input MetricCriteria object</param>
        public PSMetricCriteria(MetricCriteria metricCriteria)
            :base(name: metricCriteria.Name, metricName: metricCriteria.MetricName, operatorProperty: metricCriteria.OperatorProperty, timeAggregation: metricCriteria.TimeAggregation, threshold: metricCriteria.Threshold, metricNamespace: metricCriteria.MetricNamespace, dimensions: metricCriteria.Dimensions)
=======
    /// <summary>
    /// PS object for static metric criteria
    /// </summary>
    public class PSMetricCriteria : MetricCriteria, IPSMultiMetricCriteria
    {
        /// <summary>
        /// Gets the type of the metric criteria
        /// </summary>
        public CriterionType CriterionType => CriterionType.StaticThresholdCriterion;

        /// <summary>
        /// Initiliazes a PS object for static metric criteria
        /// </summary>
        /// <param name="metricCriteria">The original static metric criteria object</param>
        public PSMetricCriteria(MetricCriteria metricCriteria)
            : base(name: metricCriteria.Name,
                  metricName: metricCriteria.MetricName,
                  operatorProperty: metricCriteria.OperatorProperty,
                  timeAggregation: metricCriteria.TimeAggregation,
                  threshold: metricCriteria.Threshold,
                  metricNamespace: metricCriteria.MetricNamespace,
                  dimensions: metricCriteria.Dimensions,
                  skipMetricValidation: metricCriteria.SkipMetricValidation)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
        }
    }
}
