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
using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// IaaSVM Item Class
    /// </summary>
    public class AzureVmItem : AzureItem
    {
        public string VirtualMachineId { get; set; }

        public string HealthStatus { get; set; }

        public bool? IsInclusionList { get; set; }

        public IList<int?> DiskLunList { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureVmItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            AzureIaaSVMProtectedItem protectedItem = (AzureIaaSVMProtectedItem)protectedItemResource.Properties;
            LastBackupStatus = protectedItem.LastBackupStatus;
            LastBackupTime = protectedItem.LastBackupTime;
            ProtectionState =
                EnumUtils.GetEnum<ItemProtectionState>(protectedItem.ProtectionState.ToString());
            ProtectionStatus = EnumUtils.GetEnum<ItemProtectionStatus>(protectedItem.ProtectionStatus);
            VirtualMachineId = protectedItem.VirtualMachineId;
            HealthStatus = protectedItem.HealthStatus;
            DateOfPurge = null;
            DeleteState = EnumUtils.GetEnum<ItemDeleteState>("NotDeleted");
            if (protectedItem.IsScheduledForDeferredDelete.HasValue)
            {
                DateOfPurge = protectedItem.DeferredDeleteTimeInUTC.Value.AddDays(14);
                DeleteState = EnumUtils.GetEnum<ItemDeleteState>("ToBeDeleted");
            }

            if (protectedItem.ExtendedProperties != null &&
                protectedItem.ExtendedProperties.DiskExclusionProperties != null)
            {
                DiskExclusionProperties diskExclusionProperties = protectedItem.ExtendedProperties.DiskExclusionProperties;
                IsInclusionList = diskExclusionProperties.IsInclusionList;
                DiskLunList = diskExclusionProperties.DiskLunList;
            }
        }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureVmItem(CrrModel.ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            CrrModel.AzureIaaSVMProtectedItem protectedItem = (CrrModel.AzureIaaSVMProtectedItem)protectedItemResource.Properties;
            LastBackupStatus = protectedItem.LastBackupStatus;
            LastBackupTime = protectedItem.LastBackupTime;
            ProtectionState =
                EnumUtils.GetEnum<ItemProtectionState>(protectedItem.ProtectionState.ToString());
            ProtectionStatus = EnumUtils.GetEnum<ItemProtectionStatus>(protectedItem.ProtectionStatus);
            VirtualMachineId = protectedItem.VirtualMachineId;
            HealthStatus = protectedItem.HealthStatus;
            DateOfPurge = null;
            DeleteState = EnumUtils.GetEnum<ItemDeleteState>("NotDeleted");
            if (protectedItem.IsScheduledForDeferredDelete.HasValue)
            {
                DateOfPurge = protectedItem.DeferredDeleteTimeInUTC.Value.AddDays(14);
                DeleteState = EnumUtils.GetEnum<ItemDeleteState>("ToBeDeleted");
            }

            if (protectedItem.ExtendedProperties != null &&
                protectedItem.ExtendedProperties.DiskExclusionProperties != null)
            {
                CrrModel.DiskExclusionProperties diskExclusionProperties = protectedItem.ExtendedProperties.DiskExclusionProperties;
                IsInclusionList = diskExclusionProperties.IsInclusionList;
                DiskLunList = diskExclusionProperties.DiskLunList;
            }
        }
    }

    /// <summary>
    /// IaaSVM Item ExtendedInfo Class
    /// </summary>
    public class AzureVmItemExtendedInfo : AzureItemExtendedInfo
    { }
}
