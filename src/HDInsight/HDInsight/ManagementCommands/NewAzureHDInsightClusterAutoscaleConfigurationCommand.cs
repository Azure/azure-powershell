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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterAutoscaleConfiguration",
        DefaultParameterSetName = LoadAutoscaleParameterSet), OutputType(typeof(AzureHDInsightAutoscale))]
    public class NewAzureHDInsightClusterAutoscaleConfiguration : HDInsightCmdletBase
    {
        private const string LoadAutoscaleParameterSet = "LoadAutoscaleParameterSet";
        private const string ScheduleAutoscaleParameterSet = "ScheduleAutoscaleParameterSet";

        private readonly AzureHDInsightAutoscale _autoscale;

        #region Input Parameter Definitions

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the minimal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleParameterSet)]
        public int MinWorkerNodeCount { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the maximal workernode count of load-based autoscale.",
            ParameterSetName = LoadAutoscaleParameterSet)]
        public int MaxWorkerNodeCount { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the time zone of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleParameterSet)]
        public string TimeZone { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the condition of schedule-based autoscale.",
            ParameterSetName = ScheduleAutoscaleParameterSet)]
        public List<AzureHDInsightAutoscaleCondition> Condition { get; set; }

        #endregion

        public NewAzureHDInsightClusterAutoscaleConfiguration()
        {
            _autoscale = new AzureHDInsightAutoscale();
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case LoadAutoscaleParameterSet:
                    _autoscale.Capacity = new AzureHDInsightAutoscaleCapacity(MinWorkerNodeCount, MaxWorkerNodeCount);
                    break;
                case ScheduleAutoscaleParameterSet:
                    _autoscale.Recurrence = new AzureHDInsightAutoscaleRecurrence(TimeZone, Condition);
                    break;
                default:
                    break;
            }
            WriteObject(_autoscale);
        }
    }
}
