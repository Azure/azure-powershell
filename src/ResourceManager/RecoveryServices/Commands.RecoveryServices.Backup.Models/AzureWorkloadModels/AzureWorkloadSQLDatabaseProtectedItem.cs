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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure sql database workload Item Class
    /// </summary>
    public class AzureWorkloadSQLDatabaseProtectedItem : AzureItem
    {
        /// <summary>
        /// friendly name of the DB represented by this backup item.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// host/Cluster Name for instance or AG.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// parent name of the DB such as Instance or Availability Group.
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
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureWorkloadSQLDatabaseProtectedItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            AzureVmWorkloadSQLDatabaseProtectedItem protectedItem = (AzureVmWorkloadSQLDatabaseProtectedItem)protectedItemResource.Properties;
            FriendlyName = protectedItem.FriendlyName;
            ServerName = protectedItem.ServerName;
            ParentName = protectedItem.ParentName;
            ParentType = protectedItem.ParentType;
            LastBackupErrorDetail = protectedItem.LastBackupErrorDetail;
            ProtectedItemDataSourceId = protectedItem.ProtectedItemDataSourceId;
            ProtectedItemHealthStatus = protectedItem.ProtectedItemHealthStatus;
            LastBackupStatus = protectedItem.LastBackupStatus;
            LastBackupTime = protectedItem.LastBackupTime;
            ProtectionState =
                EnumUtils.GetEnum<ItemProtectionState>(protectedItem.ProtectionState.ToString());
            ProtectionStatus = EnumUtils.GetEnum<ItemProtectionStatus>(protectedItem.ProtectionStatus);
        }
    }

    /// <summary>
    /// Azure Workload Item ExtendedInfo Class
    /// </summary>
    public class AzureWorkloadSQLDatabaseProtectedItemExtendedInfo : AzureItemExtendedInfo
    { }
}