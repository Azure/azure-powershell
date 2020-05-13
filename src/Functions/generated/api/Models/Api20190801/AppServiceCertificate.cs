namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Key Vault container for a certificate that is purchased through Azure.</summary>
    public partial class AppServiceCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal
    {

        /// <summary>Backing field for <see cref="KeyVaultId" /> property.</summary>
        private string _keyVaultId;

        /// <summary>Key Vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyVaultId { get => this._keyVaultId; set => this._keyVaultId = value; }

        /// <summary>Backing field for <see cref="KeyVaultSecretName" /> property.</summary>
        private string _keyVaultSecretName;

        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyVaultSecretName { get => this._keyVaultSecretName; set => this._keyVaultSecretName = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? _provisioningState;

        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="AppServiceCertificate" /> instance.</summary>
        public AppServiceCertificate()
        {

        }
    }
    /// Key Vault container for a certificate that is purchased through Azure.
    public partial interface IAppServiceCertificate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Key Vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault resource Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultId { get; set; }
        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault secret name.",
        SerializedName = @"keyVaultSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultSecretName { get; set; }
        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the Key Vault secret.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get;  }

    }
    /// Key Vault container for a certificate that is purchased through Azure.
    internal partial interface IAppServiceCertificateInternal

    {
        /// <summary>Key Vault resource Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>Key Vault secret name.</summary>
        string KeyVaultSecretName { get; set; }
        /// <summary>Status of the Key Vault secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get; set; }

    }
}