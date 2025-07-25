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

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model
{
    public class ScheduleItem
    {
        public ScheduleItem() { }


        public ScheduleItem(Management.Sql.Models.ScheduleItem sdkScheduleItem)
        { 
            StartDay = sdkScheduleItem.StartDay;
            StartTime = sdkScheduleItem.StartTime;
            StopDay = sdkScheduleItem.StopDay;
            StopTime = sdkScheduleItem.StopTime;
        }

        /// <summary>
        /// Gets or sets start day. Possible values include: 'Sunday',
        /// 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'
        /// </summary>
        public string StartDay { get; set; }

        /// <summary>
        /// Gets or sets start time.
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets stop day. Possible values include: 'Sunday', 'Monday',
        /// 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'
        /// </summary>
        public string StopDay { get; set; }

        /// <summary>
        /// Gets or sets stop time.
        /// </summary>
        public string StopTime { get; set; }
    }
}
