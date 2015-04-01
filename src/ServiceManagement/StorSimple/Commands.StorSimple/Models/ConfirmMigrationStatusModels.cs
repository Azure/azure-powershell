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
    /// Confirm Migration status msg
    /// </summary>
    public class ConfirmMigrationStatusMsg
    {
        public string LegacyConfigId { get; set;}
        public ConfirmMigrationStatus MigrationNotStarted {get;set;}
        public ConfirmMigrationStatus MigrationInProgress {get;set;}
        public ConfirmMigrationStatus MigrationComplete  {get;set;}
        public ConfirmMigrationStatus MigrationFailed  {get;set;}
        public ConfirmMigrationStatus CommitInProgress  {get;set;}
        public ConfirmMigrationStatus CommitComplete  {get;set;}
        public ConfirmMigrationStatus CommitFailed  {get;set;}
        public ConfirmMigrationStatus RollbackInProgress  {get;set;}
        public ConfirmMigrationStatus RollbackComplete  {get;set;}
        public ConfirmMigrationStatus RollbackFailed { get; set; }

        /// <summary>
        /// Constructor - Groups the confirmation status based on status
        /// </summary>
        /// <param name="configID">config id</param>
        /// <param name="overallStatus">overall status of migration</param>
        public ConfirmMigrationStatusMsg(string configID, ConfirmStatus overallStatus)
        {
            this.LegacyConfigId = configID;
            this.MigrationNotStarted = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationNotStarted, overallStatus);
            this.MigrationInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationInProgress, overallStatus);
            this.MigrationFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationFailed, overallStatus);
            this.MigrationComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.MigrationComplete, overallStatus);

            this.CommitInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitInProgress, overallStatus);
            this.CommitFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitFailed, overallStatus);
            this.CommitComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.CommitComplete, overallStatus);

            this.RollbackInProgress = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackInProgress, overallStatus);
            this.RollbackFailed = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackFailed, overallStatus);
            this.RollbackComplete = new ConfirmMigrationStatus(MigrationDataContainerConfirmStatus.RollbackComplete, overallStatus);
        }

        /// <summary>
        /// Converts the Migration status message to string
        /// </summary>
        /// <returns>Message string</returns>
        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if ((null != this.MigrationNotStarted.ConfirmStatus && 0 < this.MigrationNotStarted.ConfirmStatus.Count) ||
                (null != this.MigrationInProgress.ConfirmStatus && 0 < this.MigrationInProgress.ConfirmStatus.Count) ||
                (null != this.MigrationComplete.ConfirmStatus && 0 < this.MigrationComplete.ConfirmStatus.Count) ||
                (null != this.MigrationFailed.ConfirmStatus && 0 < this.MigrationFailed.ConfirmStatus.Count) ||
                (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count) ||
                (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count) ||
                (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count) ||
                (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count) ||
                (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count) ||
                (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count))
            {
                if(null != this.MigrationNotStarted.ConfirmStatus && 0 < this.MigrationNotStarted.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationNotStarted:");
                    consoleop.AppendLine(this.MigrationNotStarted.ToString());
                }
                if (null != this.MigrationInProgress.ConfirmStatus && 0 < this.MigrationInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationInProgress:");
                    consoleop.AppendLine(this.MigrationInProgress.ToString());
                }
                if (null != this.MigrationComplete.ConfirmStatus && 0 < this.MigrationComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationComplete:");
                    consoleop.AppendLine(this.MigrationComplete.ToString());
                }
                if (null != this.MigrationFailed.ConfirmStatus && 0 < this.MigrationFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("MigrationFailed:");
                    consoleop.AppendLine(this.MigrationFailed.ToString());
                }
                if (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitInProgress:");
                    consoleop.AppendLine(this.CommitInProgress.ToString());
                }
                if (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitComplete:");
                    consoleop.AppendLine(this.CommitComplete.ToString());
                }
                if (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("CommitFailed:");
                    consoleop.AppendLine(this.CommitFailed.ToString());
                }
                if (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackInProgress:");
                    consoleop.AppendLine(this.RollbackInProgress.ToString());
                }
                if (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackComplete:");
                    consoleop.AppendLine(this.RollbackComplete.ToString());
                }
                if (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count)
                {
                    consoleop.AppendLine("RollbackFailed:");
                    consoleop.AppendLine(this.RollbackFailed.ToString());
                }

                return consoleop.ToString();
            }
            
            return string.Format(Resources.MigrationConfirmMigrationStatusReturnedEmpty, this.LegacyConfigId.ToString());
        }
    }

    /// <summary>
    /// Status of confirm migration
    /// </summary>
    public class ConfirmMigrationStatus
    {
        public List<ContainerConfirmStatus> ConfirmStatus { get; set; }

        public MigrationDataContainerConfirmStatus Status { get; set; }

        public ConfirmMigrationStatus(MigrationDataContainerConfirmStatus statusType, ConfirmStatus overallStatus)
        {
            this.Status = statusType;
            if (null != overallStatus)
            {
                List<ContainerConfirmStatus> statusList = new List<ContainerConfirmStatus>(overallStatus.ContainerConfirmStatus);
                this.ConfirmStatus = statusList.FindAll(status => status.Status == statusType);
            }
            else
            {
                this.ConfirmStatus = new List<ContainerConfirmStatus>();
            }
        }

        int CompareConfirmStatus(ContainerConfirmStatus rhs, ContainerConfirmStatus lhs)
        {
            return rhs.Status.CompareTo(lhs.Status);
        }

        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if(null != ConfirmStatus && 0 < ConfirmStatus.Count)
            {
                ConfirmStatus.Sort(CompareConfirmStatus);
                foreach (ContainerConfirmStatus status in ConfirmStatus)
                {
                    consoleop.AppendLine(string.Format("VolumeContainer : {0}", status.ContainerName));
                    consoleop.AppendLine(string.Format("Operation : {0}", status.Operation));
                    consoleop.AppendLine(string.Format("PercentageCompleted : {0}", status.PercentageComplete));
                    consoleop.AppendLine(string.Format("Status : {0}", status.Status));
                    if (null != status.StatusMessage && 0 < status.StatusMessage.Count)
                    {
                        consoleop.AppendLine("Messages :");
                        foreach(HcsMessageInfo msgInfo in status.StatusMessage)
                        {
                            if (!string.IsNullOrEmpty(msgInfo.Message) || !string.IsNullOrEmpty(msgInfo.Recommendation))
                            {
                                consoleop.AppendLine("\t");
                                if (!string.IsNullOrEmpty(msgInfo.Message))
                                {
                                    consoleop.Append(string.Format(" Message : {0}.", msgInfo.Message));
                                }
                                if (!string.IsNullOrEmpty(msgInfo.Recommendation))
                                {
                                    consoleop.Append(string.Format(" Recommendation : {0}.", msgInfo.Recommendation));
                                }
                            }
                        }
                    }

                    consoleop.AppendLine();
                }
            }
            
            return consoleop.ToString();
        }
    }
}