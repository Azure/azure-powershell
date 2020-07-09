namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Permissions the identity has for keys, secrets, certificates and storage.</summary>
    public partial class Permissions :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal
    {

        /// <summary>Backing field for <see cref="Certificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] _certificate;

        /// <summary>Permissions to certificates</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] Certificate { get => this._certificate; set => this._certificate = value; }

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] _key;

        /// <summary>Permissions to keys</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Secret" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] _secret;

        /// <summary>Permissions to secrets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] Secret { get => this._secret; set => this._secret = value; }

        /// <summary>Backing field for <see cref="Storage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] _storage;

        /// <summary>Permissions to storage accounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] Storage { get => this._storage; set => this._storage = value; }

        /// <summary>Creates an new <see cref="Permissions" /> instance.</summary>
        public Permissions()
        {

        }
    }
    /// Permissions the identity has for keys, secrets, certificates and storage.
    public partial interface IPermissions :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>Permissions to certificates</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to certificates",
        SerializedName = @"certificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] Certificate { get; set; }
        /// <summary>Permissions to keys</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to keys",
        SerializedName = @"keys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] Key { get; set; }
        /// <summary>Permissions to secrets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to secrets",
        SerializedName = @"secrets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] Secret { get; set; }
        /// <summary>Permissions to storage accounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to storage accounts",
        SerializedName = @"storage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] Storage { get; set; }

    }
    /// Permissions the identity has for keys, secrets, certificates and storage.
    internal partial interface IPermissionsInternal

    {
        /// <summary>Permissions to certificates</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] Certificate { get; set; }
        /// <summary>Permissions to keys</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] Key { get; set; }
        /// <summary>Permissions to secrets</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] Secret { get; set; }
        /// <summary>Permissions to storage accounts</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] Storage { get; set; }

    }
}