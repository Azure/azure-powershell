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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure SQL instance workload Item Class
    /// </summary>
    public class AzureWorkloadSQLInstanceProtectedItem : AzureItem
    {
        /// <summary>
        /// friendly name of the instance represented by this backup item.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// host/Cluster Name for instance or AG.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// parent name of the instance such as Instance or Availability Group.
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// protected item, example: for a DB, standalone server
        ///     or distributed.
        /// </summary>
        public string ParentType { get; set; }

        /// <summary>
        /// error details in last backup
        /// </summary>
        public ErrorDetail LastBackupErrorDetail { get; set; }

        /// <summary>
        ///ID of the protected item.
        /// </summary>
        public string ProtectedItemDataSourceId { get; set; }

        /// <summary>
        ///  health status of the backup item
        /// </summary>
        public string ProtectedItemHealthStatus { get; set; }

        /// <summary>
        /// Name of the child databases protected under this instance.
        /// </summary>
        public List<string> ChildDatabaseNameList { get; set; }

        /// <summary>
        /// The state of instance protection.
        /// Possible values: Unknown, Ready, ScheduleDisabled, PartialProtection, ProtectionError.
        /// </summary>
        public string InstanceProtectionReadiness { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureWorkloadSQLInstanceProtectedItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            AzureVmWorkloadSQLInstanceProtectedItem protectedItem = (AzureVmWorkloadSQLInstanceProtectedItem)protectedItemResource.Properties;
            FriendlyName = protectedItem.FriendlyName;
            ServerName = protectedItem.ServerName;
            ParentName = protectedItem.ParentName;
            ParentType = protectedItem.ParentType;
            LastBackupErrorDetail = protectedItem.LastBackupErrorDetail;
            ProtectedItemDataSourceId = protectedItem.ProtectedItemDataSourceId;
            ProtectedItemHealthStatus = protectedItem.ProtectedItemHealthStatus;
            ChildDatabaseNameList = protectedItem.ChildDatabaseNameList != null ? new List<string>(protectedItem.ChildDatabaseNameList) : null;
            InstanceProtectionReadiness = protectedItem.InstanceProtectionReadiness;
            LastBackupStatus = protectedItem.LastBackupStatus;
            LastBackupTime = protectedItem.LastBackupTime;
            ProtectionState =
                EnumUtils.GetEnum<ItemProtectionState>(protectedItem.ProtectionState.ToString());
            ProtectionStatus = EnumUtils.GetEnum<ItemProtectionStatus>(protectedItem.ProtectionStatus);

            IsArchiveEnabled = protectedItem.IsArchiveEnabled;
            SoftDeleteRetentionPeriodInDays = protectedItem.SoftDeleteRetentionPeriodInDays;
            IsScheduledForDeferredDelete = protectedItem.IsScheduledForDeferredDelete;
            DeferredDeleteTimeInUtc = protectedItem.DeferredDeleteTimeInUtc;
            DeferredDeleteTimeRemaining = protectedItem.DeferredDeleteTimeRemaining;

            DateOfPurge = null;
            DeleteState = EnumUtils.GetEnum<ItemDeleteState>("NotDeleted");
            if (protectedItem.IsScheduledForDeferredDelete.HasValue && protectedItem.IsScheduledForDeferredDelete.Value)
            {
                if (!string.IsNullOrEmpty(protectedItem.DeferredDeleteTimeRemaining))
                {
                    TimeSpan timeRemaining;
                    if (TimeSpan.TryParse(protectedItem.DeferredDeleteTimeRemaining, out timeRemaining))
                    {
                        DateOfPurge = DateTime.UtcNow.Add(timeRemaining);
                    }
                }
                DeleteState = EnumUtils.GetEnum<ItemDeleteState>("ToBeDeleted");
            }
        }
    }

    /// <summary>
    /// Azure Workload Item ExtendedInfo Class
    /// </summary>
    public class AzureWorkloadSQLInstanceProtectedItemExtendedInfo : AzureItemExtendedInfo
    { }
}
