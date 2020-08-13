namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the virtual machine used to build, customize and capture images</summary>
    public partial class ImageTemplateVMProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal
    {

        /// <summary>Internal Acessors for VnetConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal.VnetConfig { get => (this._vnetConfig = this._vnetConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.VirtualNetworkConfig()); set { {_vnetConfig = value;} } }

        /// <summary>Backing field for <see cref="OSDiskSizeGb" /> property.</summary>
        private int? _oSDiskSizeGb;

        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public int? OSDiskSizeGb { get => this._oSDiskSizeGb; set => this._oSDiskSizeGb = value; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private string _vMSize;

        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Backing field for <see cref="VnetConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig _vnetConfig;

        /// <summary>
        /// Optional configuration of the virtual network to use to deploy the build virtual machine in. Omit if no specific virtual
        /// network needs to be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig VnetConfig { get => (this._vnetConfig = this._vnetConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.VirtualNetworkConfig()); set => this._vnetConfig = value; }

        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string VnetConfigSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfigInternal)VnetConfig).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfigInternal)VnetConfig).SubnetId = value; }

        /// <summary>Creates an new <see cref="ImageTemplateVMProfile" /> instance.</summary>
        public ImageTemplateVMProfile()
        {

        }
    }
    /// Describes the virtual machine used to build, customize and capture images
    public partial interface IImageTemplateVMProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.",
        SerializedName = @"osDiskSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        int? OSDiskSizeGb { get; set; }
        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default (Standard_D1_v2).",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(string) })]
        string VMSize { get; set; }
        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of a pre-existing subnet.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetConfigSubnetId { get; set; }

    }
    /// Describes the virtual machine used to build, customize and capture images
    public partial interface IImageTemplateVMProfileInternal

    {
        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        int? OSDiskSizeGb { get; set; }
        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        string VMSize { get; set; }
        /// <summary>
        /// Optional configuration of the virtual network to use to deploy the build virtual machine in. Omit if no specific virtual
        /// network needs to be used.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig VnetConfig { get; set; }
        /// <summary>Resource id of a pre-existing subnet.</summary>
        string VnetConfigSubnetId { get; set; }

    }
}