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
using System.Runtime.Versioning;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure files Item Class
    /// </summary>
    public class AzureFileShareItem : AzureItem
    {
        /// <summary>
        /// Container id of item
        /// </summary>
        public string ParentContainerFabricId { get; set; }

        /// <summary>
        /// FriendlyName of the file share item
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Resource State of the FileShare
        /// </summary>
        public string ResourceState { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureFileShareItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            AzureFileshareProtectedItem protectedItem = (AzureFileshareProtectedItem)protectedItemResource.Properties;
            LastBackupStatus = protectedItem.LastBackupStatus;
            LastBackupTime = protectedItem.LastBackupTime;
            ProtectionState =
                EnumUtils.GetEnum<ItemProtectionState>(protectedItem.ProtectionState.ToString());
            ProtectionStatus = EnumUtils.GetEnum<ItemProtectionStatus>(protectedItem.ProtectionStatus);
            FriendlyName = protectedItem.FriendlyName;
            ResourceState = "";
            if(protectedItem.ExtendedInfo != null && protectedItem.ExtendedInfo.ResourceState != null)
            {
                ResourceState = protectedItem.ExtendedInfo.ResourceState;
            }
        }
    }

    /// <summary>
    /// Azure File Share Item ExtendedInfo Class
    /// </summary>
    public class AzureFileShareItemExtendedInfo : AzureItemExtendedInfo
    { }
}
