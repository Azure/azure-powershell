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
        public MigrationPlanInfoMsgList MigrationPlanInProgressList { get; set; }
        public MigrationPlanInfoMsgList MigrationPlanNotStartedList { get; set; }
        public MigrationPlanInfoMsgList MigrationPlanCompletedList { get; set; }
        public MigrationPlanInfoMsgList MigrationPlanFailedList { get; set; }

        public class MigrationPlanInfoMsgList
        {
            public List<MigrationPlanInfoMsg> MigrationPlanInfoList { get; set; }
            public MigrationPlanStatus MigrationPlanStatus { get; set; }
            public MigrationPlanInfoMsgList(MigrationPlanStatus status)
            {
                this.MigrationPlanStatus = status;
                this.MigrationPlanInfoList = new List<MigrationPlanInfoMsg>();
            }

            public override string ToString()
            {
                StringBuilder consoleOp = new StringBuilder();
                consoleOp.AppendFormat(Resources.MigrationDCWithGivenMigrationPlanStatus, MigrationPlanStatus.ToString());
                if (0 < MigrationPlanInfoList.Count)
                {
                    foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in MigrationPlanInfoList)
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
            MigrationPlanInProgressList = new MigrationPlanInfoMsgList(MigrationPlanStatus.InProgress);
            MigrationPlanNotStartedList = new MigrationPlanInfoMsgList(MigrationPlanStatus.NotStarted);
            MigrationPlanCompletedList = new MigrationPlanInfoMsgList(MigrationPlanStatus.Completed);
            MigrationPlanFailedList = new MigrationPlanInfoMsgList(MigrationPlanStatus.Failed);

            foreach (MigrationPlanInfo migrationPlanInfo in migrationPlan.MigrationPlanInfo)
            {
                MigrationPlanInfoMsg migrationPlanInfoMsg = new MigrationPlanInfoMsg(migrationPlanInfo);
                
                if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.InProgress)
                {
                    MigrationPlanInProgressList.MigrationPlanInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.NotStarted)
                {
                    MigrationPlanNotStartedList.MigrationPlanInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Completed)
                {
                    MigrationPlanCompletedList.MigrationPlanInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Failed)
                {
                    MigrationPlanFailedList.MigrationPlanInfoList.Add(migrationPlanInfoMsg);
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
    public class MigrationPlanInfoMsg
    {
        public int AssumedBandwidthInMbps { get; set; }
        public string VolumeContainerName { get; set; }
        public int EstimatedTimeInMinutes { get; set; }
        public int EstimatedTimeInMinutesForLargestBackup { get; set; }
        public string PlanMessageInfo { get; set; }

        public MigrationPlanInfoMsg(MigrationPlanInfo migrationPlanInfo)
        {
            AssumedBandwidthInMbps = migrationPlanInfo.AssumedBandwidthInMbps;
            VolumeContainerName = migrationPlanInfo.DataContainerName;
            EstimatedTimeInMinutes = migrationPlanInfo.EstimatedTimeInMinutes;
            EstimatedTimeInMinutesForLargestBackup = migrationPlanInfo.EstimatedTimeInMinutesForLargestBackup;
            PlanMessageInfo = GetPlanMessageInfo(new List<HcsMessageInfo>(migrationPlanInfo.PlanMessageInfoList));
        }

        public string GetPlanMessageInfo(List<HcsMessageInfo> planMessageInfoList)
        {
            StringBuilder consoleOp = new StringBuilder();
            foreach (HcsMessageInfo hcsMessageInfo in planMessageInfoList)
            {
                if (!string.IsNullOrEmpty(hcsMessageInfo.Message) ||
                    !string.IsNullOrEmpty(hcsMessageInfo.Recommendation))
                {
                    if (0 != hcsMessageInfo.ErrorCode || 0 != hcsMessageInfo.Severity)
                    {
                        consoleOp.AppendLine("ErrorCode : " + hcsMessageInfo.ErrorCode + " Severity : " +
                                             hcsMessageInfo.Severity).AppendLine();
                    }

                    if (!string.IsNullOrEmpty(hcsMessageInfo.Message))
                    {
                        consoleOp.AppendLine("Message : " + hcsMessageInfo.Message);
                    }

                    if (!string.IsNullOrEmpty(hcsMessageInfo.Recommendation))
                    {
                        consoleOp.AppendLine("Recommendation : " + hcsMessageInfo.Recommendation);
                    }

                    consoleOp.AppendLine();
                }
            }

            return consoleOp.ToString();
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.AppendLine("AssumedBandwidthInMbps : " + AssumedBandwidthInMbps);
            consoleOp.AppendLine("VolumeContainerName : " + VolumeContainerName);
            consoleOp.AppendLine("EstimatedTimeInMinutes : " + EstimatedTimeInMinutes);
            consoleOp.AppendLine("EstimatedTimeInMinutesForLatestBackup : " + EstimatedTimeInMinutesForLargestBackup);
            consoleOp.AppendLine("PlanMessageInfo : " + PlanMessageInfo);
            return consoleOp.ToString();
        }
    }
}