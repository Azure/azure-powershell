namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Disk Encryption Key Information (BitLocker Encryption Key (BEK) on Windows).</summary>
    public partial class DiskEncryptionKeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfoInternal
    {

        /// <summary>Backing field for <see cref="KeyVaultResourceArmId" /> property.</summary>
        private string _keyVaultResourceArmId;

        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultResourceArmId { get => this._keyVaultResourceArmId; set => this._keyVaultResourceArmId = value; }

        /// <summary>Backing field for <see cref="SecretIdentifier" /> property.</summary>
        private string _secretIdentifier;

        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SecretIdentifier { get => this._secretIdentifier; set => this._secretIdentifier = value; }

        /// <summary>Creates an new <see cref="DiskEncryptionKeyInfo" /> instance.</summary>
        public DiskEncryptionKeyInfo()
        {

        }
    }
    /// Disk Encryption Key Information (BitLocker Encryption Key (BEK) on Windows).
    public partial interface IDiskEncryptionKeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for secret.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret url / identifier.",
        SerializedName = @"secretIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string SecretIdentifier { get; set; }

    }
    /// Disk Encryption Key Information (BitLocker Encryption Key (BEK) on Windows).
    internal partial interface IDiskEncryptionKeyInfoInternal

    {
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        string KeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        string SecretIdentifier { get; set; }

    }
}