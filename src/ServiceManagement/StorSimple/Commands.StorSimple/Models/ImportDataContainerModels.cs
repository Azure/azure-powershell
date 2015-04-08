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
    /// Overall Status of data container migration
    /// </summary>
    public class DataContainerMigrationStatus 
    {
        /// <summary>
        /// Gets or sets Config ID of migration instance under consideration
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is Completed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationCompleted { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is InProgress
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationInprogress { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is Failed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationFailed { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is NotStarted
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationNotStarted { get; set; }

        /// <summary>
        /// Data container migration status
        /// </summary>
        /// <param name="configId">ConfigId corresponding to current instance of migration</param>
        /// <param name="overallStatusList">Overall list of status obtained from service</param>
        public DataContainerMigrationStatus(string configId, List<MigrationDataContainerStatus> overallStatusList)
        {
            this.LegacyConfigId = configId;
            this.MigrationNotStarted = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.NotStarted);
            this.MigrationInprogress = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.InProgress);
            this.MigrationFailed = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.Failed);
            this.MigrationCompleted = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.Completed);
        }

    }

    /// <summary>
    /// Status migration in one particular Migration state
    /// </summary>
    public class LegacyDataContainerMigrationStatus: MigrationModelCommon
    {
        /// <summary>
        /// Migration status in Migration state the state specified
        /// </summary>
        public List<MigrationDataContainerStatus> StatusList { get; set; }

        /// <summary>
        /// Migration State
        /// </summary>
        private MigrationStatus migrationState;

        /// <summary>
        /// Constructor - Constructs LegacyDataContainerMigrationStatus object of given MigrationStatus type, 
        /// by filtering from overall status list provided 
        /// </summary>
        /// <param name="overallStatusList">overall migration status</param>
        /// <param name="type">MigrationStatus of the list of stored</param>
        public LegacyDataContainerMigrationStatus(List<MigrationDataContainerStatus> overallStatusList, MigrationStatus type)
        {
            this.StatusList = new List<MigrationDataContainerStatus>();
            this.migrationState = type;
            if (null != overallStatusList)
            {
                this.StatusList.AddRange(overallStatusList.FindAll(status => type == status.Status));
            }
        }

        /// <summary>
        /// Displays the content in the desired format
        /// </summary>
        /// <returns>format content to be displayed</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder consoleop = new StringBuilder();
                if (null != this.StatusList && 0 < this.StatusList.Count)
                {
                    foreach (var status in this.StatusList)
                    {
                        int maxLength = status.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                        consoleop.AppendLine(IntendAndConCat("CloudConfigurationName", status.CloudConfigurationName, maxLength));
                        consoleop.AppendLine(IntendAndConCat("PercentageCompleted", status.PercentageCompleted, maxLength));
                        consoleop.AppendLine(IntendAndConCat("MigrationStatus", status.Status.ToString(), maxLength));
                        if (null != status.BackupSets && 0 < status.BackupSets.Count)
                        {
                            consoleop.AppendLine(IntendAndConCat("BackupSets", string.Empty, maxLength));
                            foreach (MigrationBackupSet backupSet in status.BackupSets)
                            {
                                consoleop.AppendLine(string.Format("\tPolicy : {0}, Created On : {1}, Status : {2}",
                                    backupSet.BackupPolicyName, backupSet.CreationTime.ToString("MM/dd/yyyy HH:mm:ss"), backupSet.Status.ToString()));
                                string consoleStrOp = this.HcsMessageInfoToString(backupSet.Message);
                                if (!string.IsNullOrEmpty(consoleStrOp))
                                {
                                    consoleop.AppendLine("\t");
                                    consoleop.AppendLine(consoleStrOp);
                                }
                            }
                        }
                        else
                        {
                            consoleop.AppendLine(Resources.MigrationBackupSetNotFound);
                        }

                        string statusStrOp = this.HcsMessageInfoToString(status.MessageInfo);
                        if (!string.IsNullOrEmpty(statusStrOp))
                        {
                            consoleop.AppendLine(IntendAndConCat("Messages", statusStrOp, maxLength));
                        }

                        consoleop.AppendLine();
                    }                    
                }
                else
                {
                    return string.Format(Resources.MigrationNoDataContainerInGivenStateOfMigration, this.migrationState.ToString());
                }

                return consoleop.ToString();
            }
            catch (Exception)
            {
                // powershell will consume the exception, and no details will be displayed if the exception is thrown, hence handling and returning error string.
                return Resources.MigrationErrorInParsingDisplayContent;
            }
        }
    }
}