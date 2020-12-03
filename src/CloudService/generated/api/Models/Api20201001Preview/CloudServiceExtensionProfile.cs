namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes a cloud service extension profile.</summary>
    public partial class CloudServiceExtensionProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceExtensionProfile,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceExtensionProfileInternal
    {

        /// <summary>Backing field for <see cref="Extension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension[] _extension;

        /// <summary>List of extensions for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension[] Extension { get => this._extension; set => this._extension = value; }

        /// <summary>Creates an new <see cref="CloudServiceExtensionProfile" /> instance.</summary>
        public CloudServiceExtensionProfile()
        {

        }
    }
    /// Describes a cloud service extension profile.
    public partial interface ICloudServiceExtensionProfile :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>List of extensions for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of extensions for the cloud service.",
        SerializedName = @"extensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension[] Extension { get; set; }

    }
    /// Describes a cloud service extension profile.
    internal partial interface ICloudServiceExtensionProfileInternal

    {
        /// <summary>List of extensions for the cloud service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension[] Extension { get; set; }

    }
}