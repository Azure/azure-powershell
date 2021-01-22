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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Sets Azure Recovery Services Vault Backup Properties.
    /// </summary>
    [GenericBreakingChange("Please use singular alias Set-AzRecoveryServicesBackupProperty, as Set-AzRecoveryServicesBackupProperties alias will be removed in an upcoming breaking change release", "4.0.0")]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProperty", SupportsShouldProcess = true), OutputType(typeof(void))]
    [Alias("Set-AzRecoveryServicesBackupProperties")]
    public class SetAzureRmRecoveryServicesBackupProperties : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }
        /// <summary>
        /// Gets or sets BackupStorageRedundancy type.
        /// </summary>
        [Parameter(Mandatory = false)]
        public AzureRmRecoveryServicesBackupStorageRedundancyType? BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets CrossRegionRestore flag.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter EnableCrossRegionRestore { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Resources.VaultTarget, "set"))
            {
                try
                {
                    BackupResourceConfigResource vaultStorageRequest = new BackupResourceConfigResource();
                    BackupResourceConfig properties = new BackupResourceConfig();
                    vaultStorageRequest.Properties = properties;

                    if (this.BackupStorageRedundancy.HasValue) 
                    {                        
                        vaultStorageRequest.Properties.StorageModelType = BackupStorageRedundancy.ToString();
                        if (this.EnableCrossRegionRestore.IsPresent)
                        {
                            vaultStorageRequest.Properties.CrossRegionRestoreFlag = true;
                        }
                        RecoveryServicesClient.UpdateVaultStorageType(
                            this.Vault.ResourceGroupName, this.Vault.Name, vaultStorageRequest);
                    }
                    else if(this.EnableCrossRegionRestore.IsPresent) 
                    {   
                        vaultStorageRequest.Properties.CrossRegionRestoreFlag = true;

                        RecoveryServicesClient.PatchVaultStorageConfigProperties(
                            this.Vault.ResourceGroupName, this.Vault.Name, vaultStorageRequest);
                    }
                    else
                    {
                        throw new Exception(Properties.Resources.NoBackupPropertiesProvided);
                    }
                }
                catch (Exception exception)
                {
                    this.HandleException(exception);
                }
            }
        }
    }
}
