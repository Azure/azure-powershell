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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class SnapshotPolicyExtensions
    {
        #region SnapshotPolicy
        public static PSNetAppFilesSnapshotPolicy ConvertToPs(this Management.NetApp.Models.SnapshotPolicy snapshotPolicy)
        {
            var psSnapshotPolicy = new PSNetAppFilesSnapshotPolicy
            {
                ResourceGroupName = new ResourceIdentifier(snapshotPolicy.Id).ResourceGroupName,
                Location = snapshotPolicy.Location,
                Id = snapshotPolicy.Id,
                Name = snapshotPolicy.Name,
                Type = snapshotPolicy.Type,
                Tags = snapshotPolicy.Tags,
                Etag = snapshotPolicy.Etag,
                ProvisioningState = snapshotPolicy.ProvisioningState,
                Enabled = snapshotPolicy.Enabled,                
                HourlySchedule = snapshotPolicy.HourlySchedule.ConvertToPs(),
                DailySchedule = snapshotPolicy.DailySchedule.ConvertToPs(),
                WeeklySchedule = snapshotPolicy.WeeklySchedule.ConvertToPs(),
                MonthlySchedule = snapshotPolicy.MonthlySchedule.ConvertToPs(),
                SystemData = snapshotPolicy.SystemData.ToPsSystemData()
            };
            return psSnapshotPolicy;
        }
        
        public static HourlySchedule ConvertFromPs(this PSNetAppFilesHourlySchedule psHourlySchedule)
        {
            var hourlySchedule = new HourlySchedule
            {
                Minute = psHourlySchedule.Minute,                
                SnapshotsToKeep = psHourlySchedule.SnapshotsToKeep
            };

            return hourlySchedule;
        }

        public static PSNetAppFilesHourlySchedule ConvertToPs(this HourlySchedule hourlySchedule)
        {
            PSNetAppFilesHourlySchedule psNetAppFilesHourlySchedule = new PSNetAppFilesHourlySchedule
            {
                Minute = hourlySchedule.Minute,                
                SnapshotsToKeep = hourlySchedule.SnapshotsToKeep,
                UsedBytes = hourlySchedule.UsedBytes
            };
            return psNetAppFilesHourlySchedule;
        }

        public static DailySchedule ConvertFromPs(this PSNetAppFilesDailySchedule psDailySchedule)
        {
            var dailySchedule = new DailySchedule
            {
                Hour = psDailySchedule.Hour,
                Minute = psDailySchedule.Minute,
                SnapshotsToKeep = psDailySchedule.SnapshotsToKeep,
                UsedBytes = psDailySchedule.UsedBytes
            };

            return dailySchedule;
        }

        public static PSNetAppFilesDailySchedule ConvertToPs(this DailySchedule dailySchedule)
        {
            PSNetAppFilesDailySchedule psNetAppFilesDailySchedule = new PSNetAppFilesDailySchedule
            {
                Hour = dailySchedule.Hour,
                Minute = dailySchedule.Minute,
                SnapshotsToKeep = dailySchedule.SnapshotsToKeep,
                UsedBytes = dailySchedule.UsedBytes
            };
            return psNetAppFilesDailySchedule;
        }

        public static WeeklySchedule ConvertFromPs(this  PSNetAppFilesWeeklySchedule psWeeklySchedule)
        {
            var weeklySchedule = new WeeklySchedule
            {
                Minute = psWeeklySchedule.Minute,
                Hour = psWeeklySchedule.Hour,
                Day = psWeeklySchedule.Day,
                SnapshotsToKeep = psWeeklySchedule.SnapshotsToKeep,
                UsedBytes = psWeeklySchedule.UsedBytes
            };

            return weeklySchedule;
        }

        public static PSNetAppFilesWeeklySchedule ConvertToPs(this WeeklySchedule weeklySchedule)
        {
            PSNetAppFilesWeeklySchedule psNetAppFilesWeeklySchedule = new PSNetAppFilesWeeklySchedule
            {
                Minute = weeklySchedule.Minute,
                Hour = weeklySchedule.Hour,
                Day = weeklySchedule.Day,
                SnapshotsToKeep = weeklySchedule.SnapshotsToKeep,
                UsedBytes = weeklySchedule.UsedBytes
            };
            return psNetAppFilesWeeklySchedule;
        }

        public static MonthlySchedule ConvertFromPs(this  PSNetAppFilesMonthlySchedule psMonthlySchedule)
        {
            var monthlySchedule = new MonthlySchedule
            {
                Minute = psMonthlySchedule.Minute,
                Hour = psMonthlySchedule.Hour,
                DaysOfMonth = psMonthlySchedule.DaysOfMonth,
                SnapshotsToKeep = psMonthlySchedule.SnapshotsToKeep,
                UsedBytes = psMonthlySchedule.UsedBytes
            };

            return monthlySchedule;
        }

        public static PSNetAppFilesMonthlySchedule ConvertToPs(this MonthlySchedule monthlySchedule)
        {
            PSNetAppFilesMonthlySchedule psNetAppFilesWeeklySchedule = new PSNetAppFilesMonthlySchedule
            {
                Minute = monthlySchedule.Minute,
                Hour = monthlySchedule.Hour,
                DaysOfMonth = monthlySchedule.DaysOfMonth,
                SnapshotsToKeep = monthlySchedule.SnapshotsToKeep,
                UsedBytes = monthlySchedule.UsedBytes
            };
            return psNetAppFilesWeeklySchedule;
        }

        #endregion SnapshotPolicy
    }
}
