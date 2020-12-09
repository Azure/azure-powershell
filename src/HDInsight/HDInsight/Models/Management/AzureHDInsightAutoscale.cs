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
    public class AzureHDInsightAutoscale
    {
        public AzureHDInsightAutoscale(Autoscale autoscale)
        {
            Capacity = autoscale?.Capacity != null ? new AzureHDInsightAutoscaleCapacity(autoscale.Capacity) : null;
            Recurrence = autoscale?.Recurrence != null ? new AzureHDInsightAutoscaleRecurrence(autoscale.Recurrence) : null;
        }

        public AzureHDInsightAutoscale(AzureHDInsightAutoscaleCapacity capacity = null, AzureHDInsightAutoscaleRecurrence recurrence = null)
        {
            Capacity = capacity;
            Recurrence = recurrence;
        }

        /// <summary>
        /// Convert AzureHDInsightAutoscaleConfiguration to Autoscale
        /// </summary>
        /// <returns></returns>
        public Autoscale ToAutoscale()
        {
            Autoscale autoscale = new Autoscale();
            if (Capacity != null)
            {
                autoscale.Capacity = new AutoscaleCapacity(Capacity.MinInstanceCount, Capacity.MaxInstanceCount);
            }

            if (Recurrence != null)
            {
                autoscale.Recurrence = new AutoscaleRecurrence(Recurrence.TimeZone, Recurrence.Condition?.Select(condition => condition.ToAutoscaleSchedule()).ToList());
            }
            return autoscale;
        }

        /// <summary>
        /// The capacity for Load-based autoscale.
        /// </summary>
        public AzureHDInsightAutoscaleCapacity Capacity { get; set; }

        /// <summary>
        /// The Recurrence for Schedule-based autoscale.
        /// </summary>
        public AzureHDInsightAutoscaleRecurrence Recurrence { get; set; }
    }
}
