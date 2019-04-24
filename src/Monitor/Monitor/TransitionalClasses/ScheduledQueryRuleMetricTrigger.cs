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


namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    public class ScheduledQueryRuleLogMetricTrigger : Monitor.Models.LogMetricTrigger
    {
        public ScheduledQueryRuleLogMetricTrigger() : base()
        { }
        /// <summary>
        /// Initializes a new instance of the ScheduledQueryRuleLogMetricTrigger class.
        /// </summary>
        /// <param name="metricTrigger">The Log Metric Trigger Details</param>
        public ScheduledQueryRuleLogMetricTrigger(Monitor.Models.LogMetricTrigger metricTrigger) :
            base(
                thresholdOperator: metricTrigger?.ThresholdOperator,
                threshold: metricTrigger?.Threshold,
                metricTriggerType: metricTrigger?.MetricTriggerType,
                metricColumn: metricTrigger?.MetricColumn)
        { }
    }
}
