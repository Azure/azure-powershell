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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleLegacyVolumeContainerMigrationPlan")]
    public class GetAzureStorSimpleLegacyVolumeContainerMigrationPlan : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = false, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigId)]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var taskResult = StorSimpleClient.UpdateMigrationPlanSync(LegacyConfigId);
                {
                    if (LegacyConfigId == null)
                    {
                        MigrationPlanList migrationPlanList = StorSimpleClient.GetAllMigrationPlan();
                        if (migrationPlanList.MigrationPlans.Count == 0)
                        {
                            WriteVerbose(Resources.MigrationPlanNoConfigs);
                        }
                        else
                        {
                            WriteVerbose(Resources.MigrationPlanConfigList);
                            foreach (MigrationPlan migrationPlan in migrationPlanList.MigrationPlans)
                            {
                                WriteVerbose(migrationPlan.ConfigId);
                            }
                        }
                    }
                    else
                    {
                        MigrationPlanList migrationPlanList = StorSimpleClient.GetMigrationPlan(LegacyConfigId);
                        WriteVerbose(string.Format("Request Id : {0}, HttpResponse {1}", migrationPlanList.RequestId, migrationPlanList.StatusCode));

                        if (migrationPlanList.MigrationPlans.Count == 0)
                        {
                            WriteVerbose(Resources.MigrationPlanNotFound);
                        }

                        else
                        {
                            WriteVerbose(Resources.VolumeContainerList);

                            MigrationPlan migrationPlan = migrationPlanList.MigrationPlans[0];
                            List<MigrationPlanInfo> filteredMigrationPlanInfos = new List<MigrationPlanInfo>();

                            List<string> legacyContainerNamesList = new List<string>(LegacyContainerNames);

                            foreach (MigrationPlanInfo migrationPlanInfo in migrationPlan.MigrationPlanInfo)
                            {
                                if (legacyContainerNamesList.Contains(migrationPlanInfo.DataContainerName))
                                {
                                    filteredMigrationPlanInfos.Add(migrationPlanInfo);
                                }
                            }

                            migrationPlanList.MigrationPlans[0].MigrationPlanInfo = filteredMigrationPlanInfos;

                            WriteObject(this.GetResultMessage(migrationPlanList.MigrationPlans[0]));
                        }
                    }
                }
            }
            catch (Exception except)
            {
                this.HandleException(except);
            }
        }

        private string GetResultMessage(MigrationPlan migrationPlan)
        {
            MigrationPlanMsg migrationPlanMsg = new MigrationPlanMsg(migrationPlan);
            return migrationPlanMsg.ToString();
        }
    }

    public class MigrationPlanMsg
    {
        private string configId;
        private string deviceName;
        private List<MigrationPlanInfoMsg> migrationPlanInfoMsgList;

        public MigrationPlanMsg(MigrationPlan migrationPlan)
        {
            configId = migrationPlan.ConfigId;
            deviceName = migrationPlan.DeviceName;
            migrationPlanInfoMsgList = new List<MigrationPlanInfoMsg>();

            foreach (MigrationPlanInfo migrationPlanInfo in migrationPlan.MigrationPlanInfo)
            {
                MigrationPlanInfoMsg migrationPlanInfoMsg = new MigrationPlanInfoMsg(migrationPlanInfo);
                migrationPlanInfoMsgList.Add(migrationPlanInfoMsg);
            }
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.AppendLine(string.Format("Config id : {0}", configId));
            consoleOp.AppendLine(string.Format("Device name : {0}", deviceName));
            foreach (MigrationPlanInfoMsg migrationPlanInfoMsg in migrationPlanInfoMsgList)
            {
                consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
            }
            return consoleOp.ToString();
        }
    }

    public class MigrationPlanInfoMsg
    {
        private string dataContainerName;
        private int estimatedTimeInMinutes;

        public MigrationPlanInfoMsg(MigrationPlanInfo migrationPlanInfo)
        {
            dataContainerName = migrationPlanInfo.DataContainerName;
            estimatedTimeInMinutes = migrationPlanInfo.EstimatedTimeInMinutes;
        }

        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.AppendLine(string.Format("Data Container Name : {0}", dataContainerName));
            consoleOp.AppendLine(string.Format("Estimated time in minutes : {0}", estimatedTimeInMinutes));
            consoleOp.AppendLine();
            return consoleOp.ToString();
        }
    }

    public class MigrationPlanStatusMsg
    {
        public string migrationPlanStatusMsg;

        public MigrationPlanStatusMsg(MigrationPlanStatus migrationPlanStatus)
        {
            switch (migrationPlanStatus)
            {
                case MigrationPlanStatus.Invalid:
                    migrationPlanStatusMsg = "Invalid";
                    break;
                case MigrationPlanStatus.NotStarted:
                    migrationPlanStatusMsg = "NotStarted";
                    break;
                case MigrationPlanStatus.InProgress:
                    migrationPlanStatusMsg = "InProgress";
                    break;
                case MigrationPlanStatus.Failed:
                    migrationPlanStatusMsg = "Failed";
                    break;
                case MigrationPlanStatus.Completed:
                    migrationPlanStatusMsg = "Completed";
                    break;
                default:
                    migrationPlanStatusMsg = "";
                    break;
            }
        }

        public override string ToString()
        {
            return migrationPlanStatusMsg;
        }
    }
}