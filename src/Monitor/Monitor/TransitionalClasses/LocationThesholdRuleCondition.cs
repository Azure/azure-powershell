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

using System;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the LocationThresholdRuleCondition, but in the old namespace
    /// </summary>
    public class LocationThresholdRuleCondition : RuleCondition
    {
        /// <summary>
        /// Gets or sets the WindowSize of the LocationThresholdRuleCondition
        /// </summary>
        public TimeSpan? WindowSize { get; set; }

        /// <summary>
        /// Gets or sets the FailedLocationCount of the LocationThresholdRuleCondition
        /// </summary>
        public int FailedLocationCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the LocationThresholdRuleCondition class.
        /// </summary>
        public LocationThresholdRuleCondition()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the LocationThresholdRuleCondition class.
        /// </summary>
        /// <param name="locationThresholdRuleCondition">The LocationThresholdRuleCondition object</param>
        public LocationThresholdRuleCondition(Monitor.Models.LocationThresholdRuleCondition locationThresholdRuleCondition)
            : base(dataSource: locationThresholdRuleCondition?.DataSource)
        {
            this.FailedLocationCount = locationThresholdRuleCondition == null ? 0 : locationThresholdRuleCondition.FailedLocationCount;
            this.WindowSize = locationThresholdRuleCondition?.WindowSize;
        }
    }
}
