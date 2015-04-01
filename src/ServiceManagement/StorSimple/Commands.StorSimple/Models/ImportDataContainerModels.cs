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
        /// Gets or sets the list of migration state, where MigrationState is NotStarted
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationNotStarted { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state, where MigrationState is Failed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationFailed { get; set; }

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
    public class LegacyDataContainerMigrationStatus
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
        /// Constructor - Constructor LegacyDataContainerMigrationStatus object of given MigrationStatus, by filter from overall status list provided 
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
                    foreach (MigrationDataContainerStatus status in this.StatusList)
                    {
                        consoleop.AppendLine(string.Format("VolumeContainer : {0}", status.DataContainerName));
                        consoleop.AppendLine(string.Format("PercentageCompleted : {0}", status.PercentageCompleted));
                        consoleop.AppendLine(string.Format("MigrationStatus : {0}", status.Status.ToString()));
                        if (null != status.BackupSets && 0 < status.BackupSets.Count)
                        {
                            consoleop.AppendLine("BackupSets :");
                            foreach (MigrationBackupSet backupSet in status.BackupSets)
                            {
                                consoleop.AppendLine(string.Format("\tPolicy : {0}, Status : {1}", backupSet.BackupPolicyName, backupSet.Status.ToString()));
                                if (!string.IsNullOrEmpty(backupSet.Message.Message))
                                {
                                    consoleop.Append(string.Format(", Message : {0}", backupSet.Message.Message));
                                }

                                if (!string.IsNullOrEmpty(backupSet.Message.Recommendation))
                                {
                                    consoleop.Append(string.Format(", Recommendation : {0}", backupSet.Message.Recommendation));
                                }
                            }
                        }
                        else
                        {
                            consoleop.AppendLine(Resources.MigrationBackupSetNotFound);
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