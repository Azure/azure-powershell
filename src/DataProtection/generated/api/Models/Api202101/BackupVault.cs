namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Backup Vault</summary>
    public partial class BackupVault :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVault,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the BackupVault resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="StorageSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] _storageSetting;

        /// <summary>Storage Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get => this._storageSetting; set => this._storageSetting = value; }

        /// <summary>Creates an new <see cref="BackupVault" /> instance.</summary>
        public BackupVault()
        {

        }
    }
    /// Backup Vault
    public partial interface IBackupVault :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Provisioning state of the BackupVault resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the BackupVault resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Storage Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Storage Settings",
        SerializedName = @"storageSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get; set; }

    }
    /// Backup Vault
    internal partial interface IBackupVaultInternal

    {
        /// <summary>Provisioning state of the BackupVault resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Storage Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get; set; }

    }
}