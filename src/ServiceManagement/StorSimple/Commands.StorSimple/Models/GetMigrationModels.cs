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

using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    public class MigrationPlanMsg
    {
        private string configId;
        private string deviceName;
        private List<MigrationPlanInfoMsg> migrationPlanInfoInvalidMsgList;
        private List<MigrationPlanInfoMsg> migrationPlanInfoInProgressMsgList;
        private List<MigrationPlanInfoMsg> migrationPlanInfoNotStartedMsgList;
        private List<MigrationPlanInfoMsg> migrationPlanInfoCompletedMsgList;
        private List<MigrationPlanInfoMsg> migrationPlanInfoFailedMsgList;

        public MigrationPlanMsg(MigrationPlan migrationPlan)
        {
            configId = migrationPlan.ConfigId;
            deviceName = migrationPlan.DeviceName;
            migrationPlanInfoInvalidMsgList = new List<MigrationPlanInfoMsg>();
            migrationPlanInfoInProgressMsgList = new List<MigrationPlanInfoMsg>();
            migrationPlanInfoNotStartedMsgList = new List<MigrationPlanInfoMsg>();
            migrationPlanInfoCompletedMsgList = new List<MigrationPlanInfoMsg>();
            migrationPlanInfoFailedMsgList = new List<MigrationPlanInfoMsg>();

            foreach (MigrationPlanInfo migrationPlanInfo in migrationPlan.MigrationPlanInfo)
            {
                MigrationPlanInfoMsg migrationPlanInfoMsg = new MigrationPlanInfoMsg(migrationPlanInfo);
                if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Invalid)
                {
                    migrationPlanInfoInvalidMsgList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.InProgress)
                {
                    migrationPlanInfoInProgressMsgList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.NotStarted)
                {
                    migrationPlanInfoNotStartedMsgList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Completed)
                {
                    migrationPlanInfoCompletedMsgList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Failed)
                {
                    migrationPlanInfoFailedMsgList.Add(migrationPlanInfoMsg);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.AppendLine(string.Format("Config id : {0}", configId));
            consoleOp.AppendLine(string.Format("Device name : {0}", deviceName));

            if (migrationPlanInfoInvalidMsgList.Count == 0 && migrationPlanInfoInProgressMsgList.Count == 0 && migrationPlanInfoNotStartedMsgList.Count == 0 && migrationPlanInfoCompletedMsgList.Count == 0 && migrationPlanInfoFailedMsgList.Count == 0)
            {
                consoleOp.AppendLine("No data containers found with migration plan with this config Id.");
            }

            if (migrationPlanInfoInvalidMsgList.Count != 0)
            {
                consoleOp.AppendLine("Data containers with migration plan invalid : ");
                consoleOp.AppendLine();
                foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoInvalidMsgList)
                {
                    consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    consoleOp.AppendLine();
                }
            }

            if (migrationPlanInfoInProgressMsgList.Count != 0)
            {
                consoleOp.AppendLine("Data containers with migration plan in progress : ");
                consoleOp.AppendLine();
                foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoInProgressMsgList)
                {
                    consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    consoleOp.AppendLine();
                }
            }

            if (migrationPlanInfoNotStartedMsgList.Count != 0)
            {
                consoleOp.AppendLine("Data containers with migration plan not started : ");
                consoleOp.AppendLine();
                foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoNotStartedMsgList)
                {
                    consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    consoleOp.AppendLine();
                }
            }

            if (migrationPlanInfoCompletedMsgList.Count != 0)
            {
                consoleOp.AppendLine("Data containers with migration plan completed : ");
                consoleOp.AppendLine();
                foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoCompletedMsgList)
                {
                    consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    consoleOp.AppendLine();
                }
            }

            if (migrationPlanInfoFailedMsgList.Count != 0)
            {
                consoleOp.AppendLine("Data containers with migration plan failed : ");
                consoleOp.AppendLine();
                foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoFailedMsgList)
                {
                    consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    consoleOp.AppendLine();
                }
            }

            return consoleOp.ToString();
        }
    }

    public class MigrationPlanInfoMsg
    {
        private int assumedBandwidthInMbps;
        private string dataContainerName;
        private int estimatedTimeInMinutes;
        private int estimatedTimeInMinutesForLatestBackup;
        private string planMessageInfoListMsg;

        public MigrationPlanInfoMsg(MigrationPlanInfo migrationPlanInfo)
        {
            assumedBandwidthInMbps = migrationPlanInfo.AssumedBandwidthInMbps;
            dataContainerName = migrationPlanInfo.DataContainerName;
            estimatedTimeInMinutes = migrationPlanInfo.EstimatedTimeInMinutes;
            estimatedTimeInMinutesForLatestBackup = migrationPlanInfo.EstimatedTimeInMinutesForLatestBackup;
            planMessageInfoListMsg = GetPlanMessageInfo(new List<HcsMessageInfo>(migrationPlanInfo.PlanMessageInfoList));
        }

        public string GetPlanMessageInfo(List<HcsMessageInfo> planMessageInfoList)
        {
            StringBuilder consoleOp = new StringBuilder();
            foreach (HcsMessageInfo hcsMessageInfo in planMessageInfoList)
            {
                consoleOp.AppendLine("ErrorCode : " + hcsMessageInfo.ErrorCode + " Message : " + hcsMessageInfo.Message + " Recommendation : " + hcsMessageInfo.Recommendation + " Severity : " + hcsMessageInfo.Severity);
            }
            return consoleOp.ToString();
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.AppendLine("AssumedBandwidthInMbps : " + assumedBandwidthInMbps);
            consoleOp.AppendLine("DataContainerName : " + dataContainerName);
            consoleOp.AppendLine("estimatedTimeInMinutes : " + estimatedTimeInMinutes);
            consoleOp.AppendLine("estimatedTimeInMinutesForLatestBackup : " + estimatedTimeInMinutesForLatestBackup);
            consoleOp.AppendLine("PlanMessageInfo : " + planMessageInfoListMsg);
            return consoleOp.ToString();
        }
    }
}