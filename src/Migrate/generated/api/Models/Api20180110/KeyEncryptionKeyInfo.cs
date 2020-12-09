namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Key Encryption Key (KEK) information.</summary>
    public partial class KeyEncryptionKeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfoInternal
    {

        /// <summary>Backing field for <see cref="KeyIdentifier" /> property.</summary>
        private string _keyIdentifier;

        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyIdentifier { get => this._keyIdentifier; set => this._keyIdentifier = value; }

        /// <summary>Backing field for <see cref="KeyVaultResourceArmId" /> property.</summary>
        private string _keyVaultResourceArmId;

        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultResourceArmId { get => this._keyVaultResourceArmId; set => this._keyVaultResourceArmId = value; }

        /// <summary>Creates an new <see cref="KeyEncryptionKeyInfo" /> instance.</summary>
        public KeyEncryptionKeyInfo()
        {

        }
    }
    /// Key Encryption Key (KEK) information.
    public partial interface IKeyEncryptionKeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key url / identifier.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for key.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultResourceArmId { get; set; }

    }
    /// Key Encryption Key (KEK) information.
    internal partial interface IKeyEncryptionKeyInfoInternal

    {
        /// <summary>The key url / identifier.</summary>
        string KeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        string KeyVaultResourceArmId { get; set; }

    }
}