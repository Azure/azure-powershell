namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The encryption settings for a configuration store.</summary>
    public partial class EncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="KeyVaultProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties _keyVaultProperty;

        /// <summary>Key vault properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.KeyVaultProperties()); set => this._keyVaultProperty = value; }

        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultPropertiesInternal)KeyVaultProperty).IdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultPropertiesInternal)KeyVaultProperty).IdentityClientId = value; }

        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultPropertiesInternal)KeyVaultProperty).KeyIdentifier = value; }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionPropertiesInternal.KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.KeyVaultProperties()); set { {_keyVaultProperty = value;} } }

        /// <summary>Creates an new <see cref="EncryptionProperties" /> instance.</summary>
        public EncryptionProperties()
        {

        }
    }
    /// The encryption settings for a configuration store.
    public partial interface IEncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client id of the identity which will be used to access key vault.",
        SerializedName = @"identityClientId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the key vault key used to encrypt data.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyIdentifier { get; set; }

    }
    /// The encryption settings for a configuration store.
    internal partial interface IEncryptionPropertiesInternal

    {
        /// <summary>Key vault properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties KeyVaultProperty { get; set; }
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        string KeyVaultPropertyKeyIdentifier { get; set; }

    }
}