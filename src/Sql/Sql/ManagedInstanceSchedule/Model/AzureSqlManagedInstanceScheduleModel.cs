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

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model
{
    /// <summary>
    /// Represents the core properties of an Managed instance
    /// </summary>
    public class AzureSqlManagedInstanceScheduleModel
    {
        public AzureSqlManagedInstanceScheduleModel() { }

        public AzureSqlManagedInstanceScheduleModel(Management.Sql.Models.StartStopManagedInstanceSchedule sdkSchedule)
        {
            Description = sdkSchedule.Description;
            TimeZoneId = sdkSchedule.TimeZoneId;
            ScheduleList = sdkSchedule.ScheduleList
                .Select(scheduleItem => new ScheduleItem(scheduleItem))
                .ToList();
        }

        /// <summary>
        /// Gets or sets the description of the schedule.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time zone of the schedule.
        /// </summary>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets schedule list.
        /// </summary>
        public IList<ScheduleItem> ScheduleList { get; set; }
    }
}
