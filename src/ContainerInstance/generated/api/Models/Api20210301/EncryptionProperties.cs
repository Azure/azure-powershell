namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container group encryption properties.</summary>
    public partial class EncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="KeyName" /> property.</summary>
        private string _keyName;

        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string KeyName { get => this._keyName; set => this._keyName = value; }

        /// <summary>Backing field for <see cref="KeyVersion" /> property.</summary>
        private string _keyVersion;

        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string KeyVersion { get => this._keyVersion; set => this._keyVersion = value; }

        /// <summary>Backing field for <see cref="VaultBaseUrl" /> property.</summary>
        private string _vaultBaseUrl;

        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string VaultBaseUrl { get => this._vaultBaseUrl; set => this._vaultBaseUrl = value; }

        /// <summary>Creates an new <see cref="EncryptionProperties" /> instance.</summary>
        public EncryptionProperties()
        {

        }
    }
    /// The container group encryption properties.
    public partial interface IEncryptionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The encryption key name.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The encryption key version.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The keyvault base url.",
        SerializedName = @"vaultBaseUrl",
        PossibleTypes = new [] { typeof(string) })]
        string VaultBaseUrl { get; set; }

    }
    /// The container group encryption properties.
    internal partial interface IEncryptionPropertiesInternal

    {
        /// <summary>The encryption key name.</summary>
        string KeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        string KeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        string VaultBaseUrl { get; set; }

    }
}