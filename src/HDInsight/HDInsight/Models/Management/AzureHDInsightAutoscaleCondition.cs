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

using Azure.ResourceManager.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightAutoscaleCondition
    {
        public AzureHDInsightAutoscaleCondition(HDInsightAutoScaleSchedule autoscaleSchedule)
        {
            Time = autoscaleSchedule?.TimeAndCapacity?.Time;
            WorkerNodeCount = autoscaleSchedule?.TimeAndCapacity?.MinInstanceCount;
            Days = autoscaleSchedule?.Days?.Select(day => (AzureHDInsightDaysOfWeek)Enum.Parse(typeof(AzureHDInsightDaysOfWeek), day.ToString())).ToList();
        }

        public AzureHDInsightAutoscaleCondition()
        {
            Days = new List<AzureHDInsightDaysOfWeek>();
        }

        public HDInsightAutoScaleSchedule ToAutoscaleSchedule()
        {
            HDInsightAutoScaleSchedule autoScaleSchedule = new HDInsightAutoScaleSchedule()
            {
                TimeAndCapacity = new HDInsightAutoScaleTimeAndCapacity()
                {
                    Time = Time,
                    MinInstanceCount = WorkerNodeCount,
                    MaxInstanceCount = WorkerNodeCount
                }
            };
            foreach (var day in Days)
            {
                autoScaleSchedule.Days.Add(new HDInsightDayOfWeek(day.ToString()));
            }
            return autoScaleSchedule;
        }

        /// <summary>
        /// The Days of the condition.
        /// </summary>
        public IList<AzureHDInsightDaysOfWeek> Days { get; set; }

        /// <summary>
        /// The schedule time of the condition.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// The target workernode count of the condition.
        /// </summary>
        public int? WorkerNodeCount { get; set; }
    }
}
