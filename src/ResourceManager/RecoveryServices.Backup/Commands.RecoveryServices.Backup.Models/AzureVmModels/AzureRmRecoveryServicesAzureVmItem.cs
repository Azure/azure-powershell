﻿// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Represents IaaSVM Item Class
    /// </summary>
    public class AzureRmRecoveryServicesIaasVmItem : AzureRmRecoveryServicesItemBase
    {   
        public string VirtualMachineId { get; set; }

        /// <summary>
        /// Protection Status of the item
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        /// Protection State of the item
        /// </summary>
        public string ProtectionState { get; set; }

        /// <summary>
        /// Last Backup Status for the item
        /// </summary>
        public string LastBackupStatus { get; set; }

        /// <summary>
        /// Protection Policy Name for the Item
        /// </summary>
        public string ProtectionPolicyName { get; set; }

        /// <summary>
        /// ExtendedInfo for the Item
        /// </summary
        public AzureRmRecoveryServicesIaasVmItemExtendedInfo ExtendedInfo { get; set; }

        public AzureRmRecoveryServicesIaasVmItem(AzureIaaSVMProtectedItem protectedItem, 
            AzureRmRecoveryServicesContainerBase container)
            : base(protectedItem, container)
        {

        }
    }

    /// <summary>
    /// Represents IaaSVM Item ExtendedInfo Class
    /// </summary>
    public class AzureRmRecoveryServicesIaasVmItemExtendedInfo : AzureRmRecoveryServicesItemExtendedInfoBase
    {
        /// <summary>
        /// Oldest Recovery Point for the Item
        /// </summary
        public DateTime? OldestRecoveryPoint { get; set; }

        /// <summary>
        /// Recovery Points Count for the Item
        /// </summary
        public int RecoveryPointCount { get; set; }

        /// <summary>
        /// PolicyState for the Item
        /// </summary
        public string PolicyState { get; set; }
    }
}
