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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Used to get SoftDelete and Encryption vault properties.
    /// </summary>
    public class VaultProperty
    {
        /// <summary>
        /// Gets or sets storage type. Possible values include: 'GeoRedundant', 'LocallyRedundant'
        /// </summary>
        public string StorageModelType { get; set; }

        /// <summary>
        /// Gets or sets storage type. Possible values include: 'GeoRedundant', 'LocallyRedundant'
        /// </summary>     
        public string StorageType { get; set; }

        /// <summary>
        ///  Gets or sets locked or Unlocked. Once a machine is registered against a resource,
        ///  the storageTypeState is always Locked. Possible values include: 'Invalid', 'Locked', 'Unlocked'
        /// </summary>  
        public string StorageTypeState { get; set; }

        /// <summary>
        /// Gets or sets enabled or Disabled. Possible values include: 'Invalid', 'Enabled', 'Disabled'
        /// </summary>
        public string EnhancedSecurityState { get; set; }

        /// <summary>
        /// Gets or sets soft Delete feature state. Possible values include: 'Invalid', 'Enabled', 'Disabled'
        /// </summary>
        public string SoftDeleteFeatureState { get; set; }

        public EncryptionConfig encryptionProperties { get; set; }

        public VaultProperty(BackupResourceVaultConfig vaultConfig, BackupResourceEncryptionConfigExtendedResource vaultEncryptionSetting)
        {
            StorageModelType = vaultConfig.StorageModelType;
            StorageType = vaultConfig.StorageType;
            StorageModelType = vaultConfig.StorageModelType;
            EnhancedSecurityState = vaultConfig.EnhancedSecurityState;
            SoftDeleteFeatureState = vaultConfig.SoftDeleteFeatureState;

            // Initialize encryption properties
            encryptionProperties = new EncryptionConfig();            
            encryptionProperties.KeyUri = vaultEncryptionSetting.Properties?.KeyUri;
            encryptionProperties.InfrastructureEncryptionState = vaultEncryptionSetting.Properties?.InfrastructureEncryptionState;
            encryptionProperties.UseSystemAssignedIdentity = vaultEncryptionSetting.Properties?.UseSystemAssignedIdentity;
            encryptionProperties.UserAssignedIdentity = vaultEncryptionSetting.Properties?.UserAssignedIdentity;
        }
    }

    public class EncryptionConfig : BackupResourceEncryptionConfigExtended
    {
        public string Id { get; set; }        
        public string Name { get; set; }
        public string Type { get; set; }        
        public string Location { get; set; }
    }
}
