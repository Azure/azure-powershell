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

using Microsoft.Azure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Constant definition
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Vault type
        /// </summary>
        public const string VaultType = "HyperVRecoveryManagerVault";

        /// <summary>
        /// Backup vault type
        /// </summary>
        public const string BackupVaultType = "Vaults";

        /// <summary>
        /// Vault Credential version.
        /// </summary>
        public const string VaultCredentialVersion = "1.0";

        /// <summary>
        /// The version of Extended resource info.
        /// </summary>
        public const string VaultSecurityInfoVersion = "1.0";

        /// <summary>
        /// extended information version.
        /// </summary>
        public const string VaultExtendedInfoContractVersion = "V2014_09";
    }

    /// <summary>
    /// Azure Recovery Services Vault.
    /// </summary>
    public class ARSVault
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ARSVault" /> class.
        /// </summary>
        public ARSVault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ARSVault" /> class.
        /// </summary>
        /// <param name="vault">vault object</param>
        public ARSVault(Vault vault)
        {
            this.ID = vault.Id;
            this.Name = vault.Name;
            this.Type = vault.Type;
            this.Location = vault.Location;
            this.ResourceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
            this.SubscriptionId = PSRecoveryServicesClient.GetSubscriptionId(vault.Id);
            this.Properties = new ARSVaultProperties();
            this.Properties.ProvisioningState = vault.Properties.ProvisioningState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ARSVault" /> class.
        /// </summary>
        /// <param name="vault">vault object</param>
        public ARSVault(VaultCreateResponse vault)
        {
            this.ID = vault.Id;
            this.Name = vault.Name;
            this.Type = vault.Type;
            this.Location = vault.Location;
            this.ResourceGroupName = PSRecoveryServicesClient.GetResourceGroup(vault.Id);
            this.SubscriptionId = PSRecoveryServicesClient.GetSubscriptionId(vault.Id);
            this.Properties = new ARSVaultProperties();
            this.Properties.ProvisioningState = vault.Properties.ProvisioningState;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Vault Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Vault ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets Resouce group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Subscription.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets Properties.
        /// </summary>
        public ARSVaultProperties Properties { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Vault properties.
    /// </summary>
    public class ARSVaultProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets Provisioning State.
        /// </summary>
        public string ProvisioningState { get; set; }

        #endregion
    }

    public class ASRVaultBackupProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets BackupStorageRedundancy type.
        /// </summary>
        public string BackupStorageRedundancy { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define the output of the vault settings file generation.
    /// </summary>
    public class VaultSettingsFilePath
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultSettingsFilePath" /> class
        /// </summary>
        public VaultSettingsFilePath()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the path of generated credential file.
        /// </summary>
        public string FilePath { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define the vault BackupStorageRedundancy settings.
    /// </summary>
    public enum AzureRmRecoveryServicesBackupStorageRedundancyType
    {
        GeoRedundant = 1,
        LocallyRedundant
    }

    /// <summary>
    /// Class to define the output object for the vault operations.
    /// </summary>
    public class VaultOperationOutput
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultOperationOutput" /> class
        /// </summary>
        public VaultOperationOutput()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the operation tracking id of the operation performed.
        /// </summary>
        public string Response { get; set; }

        #endregion
    }

    /// <summary>
    /// Azure Site Recovery Site object.
    /// </summary>
    public class ASRSite
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        public ASRSite()
        {
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets site type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets site SiteIdentifier.
        /// </summary>
        public string SiteIdentifier { get; set; }

        #endregion
    }
}
