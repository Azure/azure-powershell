namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes a set of certificates which are all in the same Key Vault.</summary>
    public partial class CloudServiceVaultSecretGroup :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultSecretGroup,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultSecretGroupInternal
    {

        /// <summary>Internal Acessors for SourceVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultSecretGroupInternal.SourceVault { get => (this._sourceVault = this._sourceVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResource()); set { {_sourceVault = value;} } }

        /// <summary>Backing field for <see cref="SourceVault" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource _sourceVault;

        /// <summary>
        /// The relative URL of the Key Vault containing all of the certificates in VaultCertificates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource SourceVault { get => (this._sourceVault = this._sourceVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResource()); set => this._sourceVault = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SourceVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResourceInternal)SourceVault).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResourceInternal)SourceVault).Id = value ?? null; }

        /// <summary>Backing field for <see cref="VaultCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate[] _vaultCertificate;

        /// <summary>The list of key vault references in SourceVault which contain certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate[] VaultCertificate { get => this._vaultCertificate; set => this._vaultCertificate = value; }

        /// <summary>Creates an new <see cref="CloudServiceVaultSecretGroup" /> instance.</summary>
        public CloudServiceVaultSecretGroup()
        {

        }
    }
    /// Describes a set of certificates which are all in the same Key Vault.
    public partial interface ICloudServiceVaultSecretGroup :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SourceVaultId { get; set; }
        /// <summary>The list of key vault references in SourceVault which contain certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of key vault references in SourceVault which contain certificates.",
        SerializedName = @"vaultCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate[] VaultCertificate { get; set; }

    }
    /// Describes a set of certificates which are all in the same Key Vault.
    internal partial interface ICloudServiceVaultSecretGroupInternal

    {
        /// <summary>
        /// The relative URL of the Key Vault containing all of the certificates in VaultCertificates.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource SourceVault { get; set; }
        /// <summary>Resource Id</summary>
        string SourceVaultId { get; set; }
        /// <summary>The list of key vault references in SourceVault which contain certificates.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultCertificate[] VaultCertificate { get; set; }

    }
}