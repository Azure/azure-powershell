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
using System.IO;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Gets Azure Recovery Services Vault Backup Properties.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProperty")]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProperties")]
    [OutputType(typeof(ASRVaultBackupProperties))]
    public class GetAzureRmRecoveryServicesBackupProperty : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                BackupStorageConfig getStorageResponse = RecoveryServicesClient.GetVaultStorageType(
                                                                        this.Vault.ResourceGroupName, this.Vault.Name);
                ASRVaultBackupProperties vaultBackupProperties = new ASRVaultBackupProperties();
                vaultBackupProperties.BackupStorageRedundancy = getStorageResponse.StorageType;
                this.WriteObject(vaultBackupProperties);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
