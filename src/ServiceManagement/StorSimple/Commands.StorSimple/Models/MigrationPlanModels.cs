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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    /// <summary>
    /// Migration plan to be returned
    /// </summary>
    public class MigrationPlanMsg
    {
        public string LegacyConfigId { get; set; }
        public string DeviceName { get; set; }
        public MigrationPlanInfoMsgList MigrationTimeEstimationCompleted { get; set; }
        public MigrationPlanInfoMsgList MigrationTimeEstimationInProgress { get; set; }
        public MigrationPlanInfoMsgList MigrationTimeEstimationFailed { get; set; }
        public MigrationPlanInfoMsgList MigrationTimeEstimationNotStarted { get; set; }      

        public class MigrationPlanInfoMsgList
        {
            public List<MigrationPlanInfoMsg> MigrationTimeEstimationInfoList { get; set; }
            public MigrationPlanStatus MigrationTimeEstimationStatus { get; set; }
            public MigrationPlanInfoMsgList(MigrationPlanStatus status)
            {
                this.MigrationTimeEstimationStatus = status;
                this.MigrationTimeEstimationInfoList = new List<MigrationPlanInfoMsg>();
            }

            public override string ToString()
            {
                StringBuilder consoleOp = new StringBuilder();
                if (0 < MigrationTimeEstimationInfoList.Count)
                {
                    foreach (var migrationPlanInfoMsg in MigrationTimeEstimationInfoList)
                    {
                        consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                        consoleOp.AppendLine();
                    }                    
                }
                else
                {
                    consoleOp.Append("None");
                }

                return consoleOp.ToString();
            }   
        }

        public MigrationPlanMsg(MigrationPlan migrationPlan)
        {
            LegacyConfigId = migrationPlan.ConfigId;
            DeviceName = migrationPlan.DeviceName;
            MigrationTimeEstimationInProgress = new MigrationPlanInfoMsgList(MigrationPlanStatus.InProgress);
            MigrationTimeEstimationNotStarted = new MigrationPlanInfoMsgList(MigrationPlanStatus.NotStarted);
            MigrationTimeEstimationCompleted = new MigrationPlanInfoMsgList(MigrationPlanStatus.Completed);
            MigrationTimeEstimationFailed = new MigrationPlanInfoMsgList(MigrationPlanStatus.Failed);

            foreach (var migrationPlanInfo in migrationPlan.MigrationPlanInfo)
            {
                MigrationPlanInfoMsg migrationPlanInfoMsg = new MigrationPlanInfoMsg(migrationPlanInfo);
                
                if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.InProgress)
                {
                    MigrationTimeEstimationInProgress.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.NotStarted)
                {
                    MigrationTimeEstimationNotStarted.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Completed)
                {
                    MigrationTimeEstimationCompleted.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Failed)
                {
                    MigrationTimeEstimationFailed.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
            }
        }
    }

    public class MigrationPlanConfig
    {
        public string LegacyConfigId { get; set; }
        public string DeviceName { get; set; }

        public MigrationPlanConfig(MigrationPlan migrationPlan)
        {
            LegacyConfigId = migrationPlan.ConfigId;
            DeviceName = migrationPlan.DeviceName;
        }
    }
    
    /// <summary>
    /// Migration plan info message represents the actual migration plan 
    /// </summary>
    public class MigrationPlanInfoMsg : MigrationModelCommon
    {
        public int AssumedBandwidthInMbps { get; set; }
        public string CloudConfigurationName { get; set; }
        public TimeSpan EstimatedTimeForAllBackups { get; set; }
        public TimeSpan EstimatedTimeForLargestBackup { get; set; }
        public string PlanMessageInfo { get; set; }

        public MigrationPlanStatus Status { get; set; }

        public MigrationPlanInfoMsg(MigrationPlanInfo migrationPlanInfo)
        {
            AssumedBandwidthInMbps = migrationPlanInfo.AssumedBandwidthInMbps;
            CloudConfigurationName = migrationPlanInfo.DataContainerName;
            EstimatedTimeForAllBackups = new TimeSpan(0, migrationPlanInfo.EstimatedTimeInMinutes, 0);
            EstimatedTimeForLargestBackup = new TimeSpan(0, migrationPlanInfo.EstimatedTimeInMinutesForLargestBackup, 0);
            PlanMessageInfo = GetPlanMessageInfo(new List<HcsMessageInfo>(migrationPlanInfo.PlanMessageInfoList));
            Status = migrationPlanInfo.PlanStatus;
        }

        public string GetPlanMessageInfo(List<HcsMessageInfo> planMessageInfoList)
        {
            StringBuilder consoleOp = new StringBuilder();
            foreach (var hcsMessageInfo in planMessageInfoList)
            {
                string consoleStrOp = HcsMessageInfoToString(hcsMessageInfo);
                if(!string.IsNullOrEmpty(consoleStrOp))
                {
                    consoleOp.AppendLine(consoleStrOp);
                }
            }

            return consoleOp.ToString();
        }

        /// <summary>
        /// Format the timespan
        /// </summary>
        /// <param name="span">time span to displayed</param>
        /// <returns>time span in string format</returns>
        public static string FormatTimeSpan(TimeSpan span)
        {
            string timeFormat = string.Empty;
            if (0 != span.Days)
            {
                timeFormat = string.Format("{0}Day{1} ", span.Days, ((1 == span.Days) ? "s" : string.Empty));
            }
            if (0 != span.Hours || 0 != span.Days)
            {
                timeFormat = string.Format("{0}{1}Hour{2} ", timeFormat, span.Hours, ((1 < span.Hours) ? "s" : string.Empty));
            }
            if (0 != span.Minutes || (0 == span.Days && 0 == span.Hours))
            {
                timeFormat = string.Format("{0}{1}Minute{2} ", timeFormat, span.Minutes, ((1 < span.Minutes) ? "s" : string.Empty));
            }

            return timeFormat;
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();        
            consoleOp.AppendLine(
                this.IntendAndConCat("CloudConfigurationName", CloudConfigurationName));
            consoleOp.AppendLine(
                this.IntendAndConCat("EstimatedTimeForLatestBackup", FormatTimeSpan(EstimatedTimeForLargestBackup)));
            consoleOp.AppendLine(
                this.IntendAndConCat("EstimatedTimeForAllBackups", FormatTimeSpan(EstimatedTimeForAllBackups)));

            if (!string.IsNullOrEmpty(PlanMessageInfo))
            {
                consoleOp.AppendLine(
                    this.IntendAndConCat("PlanMessageInfo", PlanMessageInfo));
            }

            if (MigrationPlanStatus.Completed == Status)
            {
                consoleOp.AppendLine(string.Format(Resources.MigrationTimeEstimationBWMsg, (AssumedBandwidthInMbps / 8)));
            }

            return consoleOp.ToString();
        }
    }
}