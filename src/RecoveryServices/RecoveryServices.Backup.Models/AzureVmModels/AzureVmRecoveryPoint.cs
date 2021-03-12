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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure VM specific recovery point class.
    /// </summary>
    public class AzureVmRecoveryPoint : AzureRecoveryPoint
    {
        /// <summary>
        /// Additional info associated with this recovery point serialized into a string.
        /// </summary>
        public string RecoveryPointAdditionalInfo { get; set; }

        /// <summary>
        /// Storage type of the VM whose backup operation has created this recovery point.
        /// </summary>
        public string SourceVMStorageType { get; set; }

        /// <summary>
        /// ARM ID of the VM represented by the recovery point
        /// </summary>
        public string SourceResourceId { get; set; }

        /// <summary>
        /// Identifies whether this recovery point represents 
        /// an encrypted VM at the time of backup.
        /// </summary>
        public bool EncryptionEnabled { get; set; }

        /// <summary>
        /// Identifies whether an ILR session is already active 
        /// that is associated with this recovery point.
        /// </summary>
        public bool IlrSessionActive { get; set; }

        /// <summary>
        /// Identifies if the virtual machine has a managed disks.
        /// </summary>
        public bool IsManagedVirtualMachine { get; set; }

        /// <summary>
        /// Required details for recovering an encrypted VM. 
        /// Applicable only when the EncryptionEnabled flag is true.
        /// </summary>
        public KeyAndSecretDetails KeyAndSecretDetails { get; set; }

        /// <summary>
        /// Identifies whether this recovery point supports restoring
        /// disks to their original storage accounts.
        /// </summary>
        public bool OriginalSAEnabled { get; set; }

        /// <summary>
        /// Zone pinned information for the Recovery point
        /// </summary>
        public IList<string> Zones { get; set; }

        /// <summary>
        /// Recovery Type information for Recovery point: "Vault", "Snapshot", "Snapshot and Vault" 
        /// </summary>
        public RecoveryPointTier RecoveryPointTier;

        /// <summary>
        /// Rehydration expiry time
        /// </summary>
        public DateTime? RehydrationExpiryTime;

        public AzureVmRecoveryPoint()
        {

        }
    }
}