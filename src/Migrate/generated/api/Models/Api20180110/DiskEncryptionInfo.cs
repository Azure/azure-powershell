namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery disk encryption info (BEK and KEK).</summary>
    public partial class DiskEncryptionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal
    {

        /// <summary>Backing field for <see cref="DiskEncryptionKeyInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo _diskEncryptionKeyInfo;

        /// <summary>The recovery KeyVault reference for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo DiskEncryptionKeyInfo { get => (this._diskEncryptionKeyInfo = this._diskEncryptionKeyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionKeyInfo()); set => this._diskEncryptionKeyInfo = value; }

        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DiskEncryptionKeyInfoKeyVaultResourceArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfoInternal)DiskEncryptionKeyInfo).KeyVaultResourceArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfoInternal)DiskEncryptionKeyInfo).KeyVaultResourceArmId = value ?? null; }

        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DiskEncryptionKeyInfoSecretIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfoInternal)DiskEncryptionKeyInfo).SecretIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfoInternal)DiskEncryptionKeyInfo).SecretIdentifier = value ?? null; }

        /// <summary>Backing field for <see cref="KeyEncryptionKeyInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo _keyEncryptionKeyInfo;

        /// <summary>The recovery KeyVault reference for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo KeyEncryptionKeyInfo { get => (this._keyEncryptionKeyInfo = this._keyEncryptionKeyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.KeyEncryptionKeyInfo()); set => this._keyEncryptionKeyInfo = value; }

        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyInfoKeyIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfoInternal)KeyEncryptionKeyInfo).KeyIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfoInternal)KeyEncryptionKeyInfo).KeyIdentifier = value ?? null; }

        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyInfoKeyVaultResourceArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfoInternal)KeyEncryptionKeyInfo).KeyVaultResourceArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfoInternal)KeyEncryptionKeyInfo).KeyVaultResourceArmId = value ?? null; }

        /// <summary>Internal Acessors for DiskEncryptionKeyInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal.DiskEncryptionKeyInfo { get => (this._diskEncryptionKeyInfo = this._diskEncryptionKeyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionKeyInfo()); set { {_diskEncryptionKeyInfo = value;} } }

        /// <summary>Internal Acessors for KeyEncryptionKeyInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal.KeyEncryptionKeyInfo { get => (this._keyEncryptionKeyInfo = this._keyEncryptionKeyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.KeyEncryptionKeyInfo()); set { {_keyEncryptionKeyInfo = value;} } }

        /// <summary>Creates an new <see cref="DiskEncryptionInfo" /> instance.</summary>
        public DiskEncryptionInfo()
        {

        }
    }
    /// Recovery disk encryption info (BEK and KEK).
    public partial interface IDiskEncryptionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for secret.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret url / identifier.",
        SerializedName = @"secretIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionKeyInfoSecretIdentifier { get; set; }
        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key url / identifier.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyInfoKeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for key.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyInfoKeyVaultResourceArmId { get; set; }

    }
    /// Recovery disk encryption info (BEK and KEK).
    internal partial interface IDiskEncryptionInfoInternal

    {
        /// <summary>The recovery KeyVault reference for secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo DiskEncryptionKeyInfo { get; set; }
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        string DiskEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        string DiskEncryptionKeyInfoSecretIdentifier { get; set; }
        /// <summary>The recovery KeyVault reference for key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo KeyEncryptionKeyInfo { get; set; }
        /// <summary>The key url / identifier.</summary>
        string KeyEncryptionKeyInfoKeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        string KeyEncryptionKeyInfoKeyVaultResourceArmId { get; set; }

    }
}