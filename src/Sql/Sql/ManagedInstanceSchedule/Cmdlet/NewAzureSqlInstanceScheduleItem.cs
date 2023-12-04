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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Cmdlet
{
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "SqlInstanceScheduleItem"), OutputType(typeof(ScheduleItem))]
    public class NewAzureSqlInstanceScheduleItem : AzureRMCmdlet
    {
        [Parameter(Mandatory = true)]
        public DayOfWeek StartDay { get; set; }

        [Parameter(Mandatory = true)]
        public string StartTime { get; set; }

        [Parameter(Mandatory = true)]
        public DayOfWeek StopDay { get; set; }

        [Parameter(Mandatory = true)]
        public string StopTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        public ScheduleItem[] ScheduleList { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var newItem = new ScheduleItem()
            {
                StartDay = StartDay.ToString(),
                StartTime = StartTime.ToString(),
                StopDay = StopDay.ToString(),
                StopTime = StopTime.ToString()
            };

            if (ScheduleList != null && ScheduleList.Length > 0)
            {
                var list = ScheduleList.ToList();
                list.Add(newItem);

                WriteObject(list);
            }
            else
            {
                WriteObject(newItem);
            }
        }
    }
}
