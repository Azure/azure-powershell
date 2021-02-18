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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightAutoscaleRecurrence
    {
        public AzureHDInsightAutoscaleRecurrence(AutoscaleRecurrence autoscaleRecurrence)
        {
            TimeZone = autoscaleRecurrence?.TimeZone;
            Condition = autoscaleRecurrence?.Schedule?.Select(item => new AzureHDInsightAutoscaleCondition(item)).ToList();
        }

        public AzureHDInsightAutoscaleRecurrence(string timeZone = null, IList<AzureHDInsightAutoscaleCondition> condition = null)
        {
            TimeZone = timeZone;
            Condition = condition;
        }

        /// <summary>
        /// The condition for Schedule-based autoscale.
        /// </summary>
        public IList<AzureHDInsightAutoscaleCondition> Condition { get; set; }

        /// <summary>
        /// The time zone.
        /// </summary>
        public string TimeZone { get; set; }
    }
}
