namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class CloudServiceVaultAndSecretReference :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultAndSecretReference,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultAndSecretReferenceInternal
    {

        /// <summary>Internal Acessors for SourceVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultAndSecretReferenceInternal.SourceVault { get => (this._sourceVault = this._sourceVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.SubResource()); set { {_sourceVault = value;} } }

        /// <summary>Backing field for <see cref="SecretUrl" /> property.</summary>
        private string _secretUrl;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string SecretUrl { get => this._secretUrl; set => this._secretUrl = value; }

        /// <summary>Backing field for <see cref="SourceVault" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource _sourceVault;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource SourceVault { get => (this._sourceVault = this._sourceVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.SubResource()); set => this._sourceVault = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SourceVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResourceInternal)SourceVault).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResourceInternal)SourceVault).Id = value; }

        /// <summary>Creates an new <see cref="CloudServiceVaultAndSecretReference" /> instance.</summary>
        public CloudServiceVaultAndSecretReference()
        {

        }
    }
    public partial interface ICloudServiceVaultAndSecretReference :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"secretUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SecretUrl { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SourceVaultId { get; set; }

    }
    internal partial interface ICloudServiceVaultAndSecretReferenceInternal

    {
        string SecretUrl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ISubResource SourceVault { get; set; }
        /// <summary>Resource Id</summary>
        string SourceVaultId { get; set; }

    }
}