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
using System.Collections.Generic;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure workload protectable item Class
    /// </summary>
    public class AzureWorkloadProtectableItem : ProtectableItemBase
    {
        /// <summary>
        /// Gets or sets friendly name of the backup item.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets state of the back up item
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        /// Type of protectable item
        /// </summary>
        public string ProtectableItemType { get; set; }

        /// <summary>
        /// name for instance or AG
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// Name of the Parent Only Applicable for data bases where the parent would be either
        /// Instance or a SQL AG.
        /// </summary>
        public string ParentUniqueName { get; set; }

        /// <summary>
        /// host/Cluster Name for instance or AG
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// indicates if protectable item is auto-protectable
        /// </summary>
        public bool? IsAutoProtectable { get; set; }

        /// <summary>
        /// indicates if protectable item is auto-protected
        /// </summary>
        public bool? IsAutoProtected { get; set; }

        /// <summary>
        /// Auto protection policy for protectable item
        /// </summary>
        public string AutoProtectionPolicy { get; set; }

        /// <summary>
        /// for instance or AG, indicates number of DB's present
        /// </summary>
        public int? Subinquireditemcount { get; set; }

        /// <summary>
        /// for instance or AG, indicates number of DB's to be protected
        /// </summary>
        public int? Subprotectableitemcount { get; set; }

        /// <summary>
        /// pre-backup validation for protectable objects
        /// </summary>
        public PreBackupValidation Prebackupvalidation { get; set; }

        /// <summary>
        /// NodesList for SQLAG protectable objects
        /// </summary>
        public IList<DistributedNodesInfo> NodesList { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="workloadProtectableItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        public AzureWorkloadProtectableItem(WorkloadProtectableItemResource workloadProtectableItemResource,
            string containerName, ContainerType containerType)
            : base(workloadProtectableItemResource, containerName, containerType)
        {
            AzureVmWorkloadProtectableItem protectedItem = (AzureVmWorkloadProtectableItem)workloadProtectableItemResource.Properties;
            FriendlyName = protectedItem.FriendlyName;
            ProtectionState = protectedItem.ProtectionState;
            ParentName = protectedItem.ParentName;
            ParentUniqueName = protectedItem.ParentUniqueName;
            ServerName = protectedItem.ServerName;
            IsAutoProtectable = protectedItem.IsAutoProtectable;
            IsAutoProtected = protectedItem.IsAutoProtected;
            Subinquireditemcount = protectedItem.Subinquireditemcount;
            Subprotectableitemcount = protectedItem.Subprotectableitemcount;
            Prebackupvalidation = protectedItem.Prebackupvalidation;
            ProtectableItemType = workloadProtectableItemResource.Properties.GetType().ToString();

            if (workloadProtectableItemResource.Properties.GetType() == typeof(AzureVmWorkloadSQLAvailabilityGroupProtectableItem))
            {
                ProtectableItemType = CmdletModel.ProtectableItemType.SQLAvailabilityGroup.ToString();
            }
            else if (workloadProtectableItemResource.Properties.GetType() == typeof(AzureVmWorkloadSQLInstanceProtectableItem))
            {
                ProtectableItemType = CmdletModel.ProtectableItemType.SQLInstance.ToString();
            }
            else if (workloadProtectableItemResource.Properties.GetType() == typeof(AzureVmWorkloadSQLDatabaseProtectableItem))
            {
                ProtectableItemType = CmdletModel.ProtectableItemType.SQLDataBase.ToString();
            }
        }
    }
}