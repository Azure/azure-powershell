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

using Microsoft.Azure.Commands.Insights.TransitionalClasses;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the MetricTrigger, but in the old namespace
    /// </summary>
    public class MetricTrigger : Monitor.Models.MetricTrigger
    {
        /// <summary>
        /// Gets or sets the OperatorProperty of the Metric Trigger
        /// </summary>
        public new ComparisonOperationType OperatorProperty
        {
            get
            {
                return (ComparisonOperationType)System.Enum.Parse(typeof(ComparisonOperationType), base.OperatorProperty.ToString());
            }
            set
            {
                base.OperatorProperty = (Monitor.Models.ComparisonOperationType)System.Enum.Parse(typeof(Monitor.Models.ComparisonOperationType), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the Statistic of the Metric Trigger
        /// </summary>
        public new MetricStatisticType Statistic
        {
            get
            {
                return (MetricStatisticType)System.Enum.Parse(typeof(MetricStatisticType), base.Statistic.ToString());
            }
            set
            {
                base.Statistic = (Monitor.Models.MetricStatisticType)System.Enum.Parse(typeof(Monitor.Models.MetricStatisticType), value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the TimeAggregation of the Metric Trigger
        /// </summary>
        public new TimeAggregationType TimeAggregation
        {
            get
            {
                return (TimeAggregationType)System.Enum.Parse(typeof(TimeAggregationType), base.TimeAggregation.ToString());
            }
            set
            {
                base.TimeAggregation = (Monitor.Models.TimeAggregationType)System.Enum.Parse(typeof(Monitor.Models.TimeAggregationType), value.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the MetricTrigger class.
        /// </summary>
        public MetricTrigger()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the MetricTrigger class.
        /// </summary>
        /// <param name="metricTrigger">The MetricTrigger object</param>
        public MetricTrigger(Monitor.Models.MetricTrigger metricTrigger)
            : base(
                  metricName: metricTrigger?.MetricName,
                  metricResourceUri: metricTrigger?.MetricResourceUri,
                  timeGrain: metricTrigger == null ? default(System.TimeSpan) : metricTrigger.TimeGrain,
                  operatorProperty: metricTrigger == null ? default(Monitor.Models.ComparisonOperationType) : metricTrigger.OperatorProperty,
                  statistic: metricTrigger == null ? default(Monitor.Models.MetricStatisticType) : metricTrigger.Statistic,
                  threshold: metricTrigger == null ? 0 : metricTrigger.Threshold,
                  timeAggregation: metricTrigger == null ? default(Monitor.Models.TimeAggregationType) : metricTrigger.TimeAggregation,
                  timeWindow: metricTrigger == null ? default(System.TimeSpan) : metricTrigger.TimeWindow)
        {
            if (metricTrigger != null)
            {
                this.OperatorProperty = TransitionHelpers.ConvertNamespace(metricTrigger.OperatorProperty);
                this.Statistic = TransitionHelpers.ConvertNamespace(metricTrigger.Statistic);
                this.TimeAggregation = TransitionHelpers.ConvertNamespace(metricTrigger.TimeAggregation);
            }
        }
    }
}
