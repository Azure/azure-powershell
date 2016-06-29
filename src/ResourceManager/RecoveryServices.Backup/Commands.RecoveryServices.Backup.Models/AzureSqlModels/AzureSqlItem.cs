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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// AzureSql Item Class
    /// </summary>
    public class AzureSqlItem : ItemBase
    {
        /// <summary>
        /// ProtectedItem DataId of the Item
        /// </summary>
        public string ProtectedItemDataId { get; set; }

        /// <summary>
        /// Protection State of the Item
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        /// Protection Policy Name for the Item
        /// </summary>
        public string ProtectionPolicyName { get; set; }

        /// <summary>
        /// ExtendedInfo for the Item
        /// </summary>
        public AzureSqlItemExtendedInfo ExtendedInfo { get; set; }

        /// <summary>
        /// Constructor. Takes the service client object representing the protected item 
        /// and converts it in to the PS protected item model
        /// </summary>
        /// <param name="protectedItemResource">Service client object representing the protected item resource</param>
        /// <param name="containerName">Name of the container associated with this protected item</param>
        /// <param name="containerType">Type of the container associated with this protected item</param>
        /// <param name="policyName">Name of the protection policy associated with this protected item</param>
        public AzureSqlItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType)
        {
            AzureSqlProtectedItem protectedItem = 
                (AzureSqlProtectedItem)protectedItemResource.Properties;
            ProtectedItemDataId = protectedItem.ProtectedItemDataId;
            ProtectionState = protectedItem.ProtectionState;
            ProtectionPolicyName = policyName;
        }
    }

    /// <summary>
    /// Represents AzureSql Item ExtendedInfo Class
    /// </summary>
    public class AzureSqlItemExtendedInfo : ItemExtendedInfoBase
    {
        /// <summary>
        /// Oldest Recovery Point for the Item
        /// </summary
        public DateTime? OldestRecoveryPoint { get; set; }

        /// <summary>
        /// Recovery Points Count for the Item
        /// </summary
        public int? RecoveryPointCount { get; set; }

        /// <summary>
        /// PolicyState for the Item
        /// </summary
        public string PolicyState { get; set; }
    }
}
