namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes the OS profile for the cloud service.</summary>
    public partial class CloudServiceOSProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceOSProfile,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceOSProfileInternal
    {

        /// <summary>Backing field for <see cref="Secret" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup[] _secret;

        /// <summary>Specifies set of certificates that should be installed onto the role instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup[] Secret { get => this._secret; set => this._secret = value; }

        /// <summary>Creates an new <see cref="CloudServiceOSProfile" /> instance.</summary>
        public CloudServiceOSProfile()
        {

        }
    }
    /// Describes the OS profile for the cloud service.
    public partial interface ICloudServiceOSProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Specifies set of certificates that should be installed onto the role instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies set of certificates that should be installed onto the role instances.",
        SerializedName = @"secrets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup[] Secret { get; set; }

    }
    /// Describes the OS profile for the cloud service.
    internal partial interface ICloudServiceOSProfileInternal

    {
        /// <summary>Specifies set of certificates that should be installed onto the role instances.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup[] Secret { get; set; }

    }
}