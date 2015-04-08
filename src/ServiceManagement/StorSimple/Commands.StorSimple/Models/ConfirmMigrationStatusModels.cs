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

using System.Runtime.Caching.Configuration;
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
    /// Confirm Migration status msg - output of 
    /// Get-AzureStorSimpleVolumeContainerConfirmStatus cmdlet
    /// </summary>
    public class ConfirmMigrationStatusMsg
    {
        public string LegacyConfigId { get; set;}
        public ConfirmMigrationStatus CommitComplete { get; set; }
        public ConfirmMigrationStatus CommitInProgress  {get;set;}
        public ConfirmMigrationStatus CommitFailed  {get;set;}        
        public ConfirmMigrationStatus RollbackComplete  {get;set;}
        public ConfirmMigrationStatus RollbackInProgress { get; set; }
        public ConfirmMigrationStatus RollbackFailed { get; set; }
        public ConfirmMigrationStatus CommitOrRollbackNotStarted { get; set; }
        /// <summary>
        /// Constructor of Overall ConfirmMigrationStatusMsg to be returned as an output 
        /// Get-AzureStorSimpleVolumeContainerConfirmStatus cmdlet
        /// </summary>
        /// <param name="configID">config id</param>
        /// <param name="overallStatus">overall status of migration</param>
        public ConfirmMigrationStatusMsg(string configID, ConfirmStatus overallStatus)
        {
            this.LegacyConfigId = configID;
            this.CommitOrRollbackNotStarted = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitOrRollbackNotStarted, overallStatus);

            this.CommitInProgress = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitInProgress, overallStatus);
            this.CommitFailed = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitFailed, overallStatus);
            this.CommitComplete = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitComplete, overallStatus);

            this.RollbackInProgress = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackInProgress, overallStatus);
            this.RollbackFailed = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackFailed, overallStatus);
            this.RollbackComplete = new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackComplete, overallStatus);
        }

        /////// <summary>
        /////// Converts the Migration status message to string
        /////// </summary>
        /////// <returns>Message string</returns>
        ////public override string ToString()
        ////{
        ////    StringBuilder consoleop = new StringBuilder();
        ////    if ((null != this.CommitRollbackNotStarted.ConfirmStatus && 0 < this.CommitRollbackNotStarted.ConfirmStatus.Count) ||
        ////        (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count) ||
        ////        (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count) ||
        ////        (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count) ||
        ////        (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count) ||
        ////        (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count) ||
        ////        (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count))
        ////    {
        ////        if (null != this.CommitRollbackNotStarted.ConfirmStatus && 0 < this.CommitRollbackNotStarted.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("MigrationNotStarted:");
        ////            consoleop.AppendLine(this.CommitRollbackNotStarted.ToString());
        ////        }
        ////        if (null != this.CommitInProgress.ConfirmStatus && 0 < this.CommitInProgress.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("CommitInProgress:");
        ////            consoleop.AppendLine(this.CommitInProgress.ToString());
        ////        }
        ////        if (null != this.CommitComplete.ConfirmStatus && 0 < this.CommitComplete.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("CommitComplete:");
        ////            consoleop.AppendLine(this.CommitComplete.ToString());
        ////        }
        ////        if (null != this.CommitFailed.ConfirmStatus && 0 < this.CommitFailed.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("CommitFailed:");
        ////            consoleop.AppendLine(this.CommitFailed.ToString());
        ////        }
        ////        if (null != this.RollbackInProgress.ConfirmStatus && 0 < this.RollbackInProgress.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("RollbackInProgress:");
        ////            consoleop.AppendLine(this.RollbackInProgress.ToString());
        ////        }
        ////        if (null != this.RollbackComplete.ConfirmStatus && 0 < this.RollbackComplete.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("RollbackComplete:");
        ////            consoleop.AppendLine(this.RollbackComplete.ToString());
        ////        }
        ////        if (null != this.RollbackFailed.ConfirmStatus && 0 < this.RollbackFailed.ConfirmStatus.Count)
        ////        {
        ////            consoleop.AppendLine("RollbackFailed:");
        ////            consoleop.AppendLine(this.RollbackFailed.ToString());
        ////        }

        ////        return consoleop.ToString();
        ////    }
            
        ////    return string.Format(Resources.MigrationConfirmMigrationStatusReturnedEmpty, this.LegacyConfigId.ToString());
        ////}
    }

    /// <summary>
    /// Class represents the List of ConfirmStatus of MigrationVolumeContainerConfirmStatus status
    /// </summary>
    public class ConfirmMigrationStatus : MigrationModelCommon
    {
        public List<ContainerConfirmStatus> ConfirmStatus { get; set; }

        public MigrationVolumeContainerConfirmStatus Status { get; set; }

        /// <summary>
        /// Constructor - Constructs ConfirmMigrationStatus object of given statusType specified, 
        /// by filtering from overallstatus list provided 
        /// </summary>
        /// <param name="type">MigrationStatus of the list of stored</param>
        /// <param name="overallStatusList">overall migration status</param>        
        public ConfirmMigrationStatus(MigrationVolumeContainerConfirmStatus statusType, ConfirmStatus overallStatus)
        {
            this.Status = statusType;
            if (null != overallStatus)
            {
                var statusList = new List<ContainerConfirmStatus>(overallStatus.ContainerConfirmStatus);
                this.ConfirmStatus = statusList.FindAll(status => GetMigrationVolumeContainerConfirmStatus(status.Status) == statusType);
            }
            else
            {
                this.ConfirmStatus = new List<ContainerConfirmStatus>();
            }
        }

        /// <summary>
        /// Volume container Confirm migration status enums
        /// </summary>
        public enum MigrationVolumeContainerConfirmStatus
        {
            CommitOrRollbackNotStarted,
            CommitInProgress,
            CommitComplete,
            CommitFailed,
            RollbackInProgress,
            RollbackComplete,
            RollbackFailed,
        }

        /// <summary>
        /// Maps service enum to MigrationVolumeContainerConfirmStatus
        /// </summary>
        /// <param name="status">service confirm status enum</param>
        /// <returns>MigrationVolumeContainerConfirmStatus enum value corresponding to given service status</returns>
        private MigrationVolumeContainerConfirmStatus GetMigrationVolumeContainerConfirmStatus(MigrationDataContainerConfirmStatus status)
        {
            switch(status)
            {
                case MigrationDataContainerConfirmStatus.MigrationNotStarted:
                case MigrationDataContainerConfirmStatus.MigrationInProgress:
                case MigrationDataContainerConfirmStatus.MigrationComplete:
                case MigrationDataContainerConfirmStatus.MigrationFailed:
                    {
                        return MigrationVolumeContainerConfirmStatus.CommitOrRollbackNotStarted;
                    }
                case MigrationDataContainerConfirmStatus.CommitInProgress:
                    {
                        return MigrationVolumeContainerConfirmStatus.CommitInProgress;
                    }
                case MigrationDataContainerConfirmStatus.CommitComplete:
                    {
                        return MigrationVolumeContainerConfirmStatus.CommitComplete;
                    }
                case MigrationDataContainerConfirmStatus.CommitFailed:
                    {
                        return MigrationVolumeContainerConfirmStatus.CommitFailed;
                    }
                case MigrationDataContainerConfirmStatus.RollbackInProgress:
                    {
                        return MigrationVolumeContainerConfirmStatus.RollbackInProgress;
                    }
                case MigrationDataContainerConfirmStatus.RollbackComplete:
                    {
                        return MigrationVolumeContainerConfirmStatus.RollbackComplete;
                    }
                case MigrationDataContainerConfirmStatus.RollbackFailed:
                    {
                        return MigrationVolumeContainerConfirmStatus.RollbackFailed;
                    }
                default:
                    {
                        throw new Exception("Migration Data Container Confirm Status not found.");
                    }
            }
        }

        /// <summary>
        /// Compares two ContainerConfirmStatus based on status, used for sorting & group
        /// ContainerConfirmStatus based on their status
        /// </summary>
        private int CompareConfirmStatus(ContainerConfirmStatus lhs, ContainerConfirmStatus rhs)
        {
            return lhs.Status.CompareTo(rhs.Status);
        }

        /// <summary>
        /// Overridden to displays the content in the desired format
        /// </summary>
        /// <returns>format content to be displayed</returns>
        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if(null != ConfirmStatus && 0 < ConfirmStatus.Count)
            {
                ConfirmStatus.Sort(CompareConfirmStatus);
                foreach (var status in ConfirmStatus)
                {
                    int maxLength = status.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                    consoleop.AppendLine(IntendAndConCat("CloudConfigurationName", status.CloudConfigurationName, maxLength));
                    consoleop.AppendLine(IntendAndConCat("Operation", status.Operation, maxLength));
                    consoleop.AppendLine(IntendAndConCat("PercentageCompleted", status.PercentageCompleted, maxLength));
                    if (null != status.StatusMessage && 0 < status.StatusMessage.Count)
                    {
                        consoleop.AppendLine(IntendAndConCat("Messages", string.Empty, maxLength));
                        foreach(var msgInfo in status.StatusMessage)
                        {
                            string consoleStrOp = HcsMessageInfoToString(msgInfo);
                            if (!string.IsNullOrEmpty(consoleStrOp))
                            {
                                consoleop.AppendLine("\t");
                                consoleop.Append(consoleStrOp);
                            }
                        }
                    }

                    consoleop.AppendLine();
                }
            }
            else
            {
                consoleop.Append("None");
            }
            
            return consoleop.ToString();
        }
    }
}