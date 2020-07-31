namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>Settings concerning key vault encryption for a configuration store.</summary>
    public partial class KeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="IdentityClientId" /> property.</summary>
        private string _identityClientId;

        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string IdentityClientId { get => this._identityClientId; set => this._identityClientId = value; }

        /// <summary>Backing field for <see cref="KeyIdentifier" /> property.</summary>
        private string _keyIdentifier;

        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string KeyIdentifier { get => this._keyIdentifier; set => this._keyIdentifier = value; }

        /// <summary>Creates an new <see cref="KeyVaultProperties" /> instance.</summary>
        public KeyVaultProperties()
        {

        }
    }
    /// Settings concerning key vault encryption for a configuration store.
    public partial interface IKeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client id of the identity which will be used to access key vault.",
        SerializedName = @"identityClientId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the key vault key used to encrypt data.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyIdentifier { get; set; }

    }
    /// Settings concerning key vault encryption for a configuration store.
    internal partial interface IKeyVaultPropertiesInternal

    {
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        string IdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        string KeyIdentifier { get; set; }

    }
}