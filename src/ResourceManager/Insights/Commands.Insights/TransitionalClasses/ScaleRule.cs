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
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the ScaleRule, but in the old namespace
    /// </summary>
    public class ScaleRule : Monitor.Models.ScaleRule
    {
        /// <summary>
        /// Gets or sets the MetricTrigger property
        /// </summary>
        public new MetricTrigger MetricTrigger { get; set; }

        /// <summary>
        /// Gets or sets the ScaleAction property
        /// </summary>
        public new ScaleAction ScaleAction { get; set; }

        /// <summary>
        /// Initializes a new instance of the ScaleRule class.
        /// </summary>
        public ScaleRule()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScaleRule class.
        /// </summary>
        /// <param name="metricTrigger">The metric trigger object</param>
        /// <param name="scaleAction">The scale action object</param>
        public ScaleRule(Monitor.Models.MetricTrigger metricTrigger, Monitor.Models.ScaleAction scaleAction)
            : base(
                  metricTrigger: metricTrigger,
                  scaleAction: scaleAction)
        {
            this.MetricTrigger = metricTrigger != null ? new MetricTrigger(metricTrigger) : null;
            this.ScaleAction = scaleAction != null ? new ScaleAction(scaleAction) : null;
        }

        /// <summary>
        /// Initializes a new instance of the ScaleRule class.
        /// </summary>
        /// <param name="scaleRule">The scale rule</param>
        public ScaleRule(Monitor.Models.ScaleRule scaleRule)
            : base()
        {
            if (scaleRule != null)
            {
                base.MetricTrigger = scaleRule.MetricTrigger;
                base.ScaleAction = scaleRule.ScaleAction;
                this.MetricTrigger = scaleRule.MetricTrigger != null ? new MetricTrigger(scaleRule.MetricTrigger) : null;
                this.ScaleAction = scaleRule.ScaleAction != null ? new ScaleAction(scaleRule.ScaleAction) : null;
            }
        }
    }
}
