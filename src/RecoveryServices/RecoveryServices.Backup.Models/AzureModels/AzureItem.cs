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

using System;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Base class for Azure items(AzureVM, AzureFiles)
    /// </summary>
    public class AzureItem : ItemBase
    {
        /// <summary>
        /// Protection Status of the item
        /// </summary>
        public ItemProtectionStatus ProtectionStatus { get; set; }

        /// <summary>
        /// Policy ID Associated with item
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// Protection State of the item
        /// </summary>
        public ItemProtectionState ProtectionState { get; set; }

        /// <summary>
        /// Last Backup Status for the item
        /// </summary>
        public string LastBackupStatus { get; set; }

        /// <summary>
        /// Last Backup Time for the item
        /// </summary>
        public DateTime? LastBackupTime { get; set; }

        /// <summary>
        /// Protection Policy Name for the Item
        /// </summary>
        public string ProtectionPolicyName { get; set; }

        /// <summary>
        /// ExtendedInfo for the Item
        /// </summary>
        public AzureItemExtendedInfo ExtendedInfo { get; set; }

        /// <summary>
        /// Date of purge for the item
        /// </summary>
        public DateTime? DateOfPurge { get; set; }

        /// <summary>
        /// Indicates if the delete state of the item
        /// </summary>
        public ItemDeleteState DeleteState { get; set; }

        /// <summary>
        /// Gets or sets flag to identify whether datasource is protected in archive
        /// </summary>
        public bool? IsArchiveEnabled { get; set; }

        /// <summary>
        /// Gets or sets soft delete retention period in days
        /// </summary>
        public int? SoftDeleteRetentionPeriodInDays { get; set; }

        /// <summary>
        /// Gets or sets flag to identify whether the DS is scheduled for deferred
        /// delete
        /// </summary>
        public bool? IsScheduledForDeferredDelete { get; set; }

        /// <summary>
        /// Gets or sets time for deferred deletion in UTC
        /// </summary>
        public System.DateTime? DeferredDeleteTimeInUtc { get; set; }

        /// <summary>
        /// Gets or sets time for deferred deletion time remaining in [d.]hh:mm:ss.fffffff
        /// </summary>
        public string DeferredDeleteTimeRemaining { get; set; }

        public AzureItem(ProtectedItemResource protectedItemResource,
           string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType)
        {
            ProtectionPolicyName = policyName;
            PolicyId = protectedItemResource.Properties.PolicyId;
            DeleteState = ItemDeleteState.NotDeleted;
        }

        public AzureItem(CrrModel.ProtectedItemResource protectedItemResource,
           string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType)
        {
            ProtectionPolicyName = policyName;
            PolicyId = protectedItemResource.Properties.PolicyId;
            DeleteState = ItemDeleteState.NotDeleted;
        }
    }

    public class AzureItemExtendedInfo : ItemExtendedInfoBase
    {
        /// <summary>
        /// Oldest Recovery Point for the Item
        /// </summary>
        public DateTime? OldestRecoveryPoint { get; set; }

        /// <summary>
        /// Recovery Points Count for the Item
        /// </summary>
        public int RecoveryPointCount { get; set; }

        /// <summary>
        /// PolicyState for the Item
        /// </summary>
        public string PolicyState { get; set; }
    }
}
