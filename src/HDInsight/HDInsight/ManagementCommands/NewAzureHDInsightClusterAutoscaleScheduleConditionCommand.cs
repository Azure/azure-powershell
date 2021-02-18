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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Week = Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightDaysOfWeek;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterAutoscaleScheduleCondition"), OutputType(typeof(AzureHDInsightAutoscaleCondition))]
    public class NewAzureHDInsightClusterAutoscaleScheduleConditionCommand : HDInsightCmdletBase
    {
        private readonly AzureHDInsightAutoscaleCondition _condition;
        #region Input Parameter Definitions

        [Parameter(HelpMessage = "Gets or sets the time of Autoscale schedule condition.", Mandatory = true)]
        public DateTime Time { get; set; }

        [Parameter(HelpMessage = "Gets or sets the schedule workernode count of Autoscale schedule condition.", Mandatory = true)]
        public int WorkerNodeCount { get; set; }

        [Parameter(HelpMessage = "Gets or sets the days of Autoscale schedule condition.", Mandatory = true)]
        public AzureHDInsightDaysOfWeek[] Day { get; set; }

        #endregion

        public NewAzureHDInsightClusterAutoscaleScheduleConditionCommand()
        {
            _condition = new AzureHDInsightAutoscaleCondition();
        }

        public override void ExecuteCmdlet()
        {
            _condition.Time = Time.ToString("HH:mm");
            _condition.WorkerNodeCount = WorkerNodeCount;
            _condition.Days = Day.ToList();
            WriteObject(_condition);
        }
    }
}
