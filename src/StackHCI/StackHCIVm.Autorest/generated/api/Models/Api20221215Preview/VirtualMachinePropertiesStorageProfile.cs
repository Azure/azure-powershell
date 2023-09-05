namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// StorageProfile - contains information about the disks and storage information for the virtual machine
    /// </summary>
    public partial class VirtualMachinePropertiesStorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal
    {

        /// <summary>Backing field for <see cref="DataDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] _dataDisk;

        /// <summary>adds data disks to the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] DataDisk { get => this._dataDisk; set => this._dataDisk = value; }

        /// <summary>Backing field for <see cref="ImageReference" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference _imageReference;

        /// <summary>Which Image to use for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference ImageReference { get => (this._imageReference = this._imageReference ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileImageReference()); set => this._imageReference = value; }

        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ImageReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReferenceInternal)ImageReference).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReferenceInternal)ImageReference).Id = value ?? null; }

        /// <summary>Internal Acessors for ImageReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal.ImageReference { get => (this._imageReference = this._imageReference ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileImageReference()); set { {_imageReference = value;} } }

        /// <summary>Internal Acessors for OSDisk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal.OSDisk { get => (this._oSDisk = this._oSDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileOSDisk()); set { {_oSDisk = value;} } }

        /// <summary>Backing field for <see cref="OSDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk _oSDisk;

        /// <summary>VHD to attach as OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk OSDisk { get => (this._oSDisk = this._oSDisk ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileOSDisk()); set => this._oSDisk = value; }

        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSDiskId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDiskInternal)OSDisk).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDiskInternal)OSDisk).Id = value ?? null; }

        /// <summary>Backing field for <see cref="VMConfigStoragePathId" /> property.</summary>
        private string _vMConfigStoragePathId;

        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string VMConfigStoragePathId { get => this._vMConfigStoragePathId; set => this._vMConfigStoragePathId = value; }

        /// <summary>Creates an new <see cref="VirtualMachinePropertiesStorageProfile" /> instance.</summary>
        public VirtualMachinePropertiesStorageProfile()
        {

        }
    }
    /// StorageProfile - contains information about the disks and storage information for the virtual machine
    public partial interface IVirtualMachinePropertiesStorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>adds data disks to the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"adds data disks to the virtual machine",
        SerializedName = @"dataDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] DataDisk { get; set; }
        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the image",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ImageReferenceId { get; set; }
        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the OS disk",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string OSDiskId { get; set; }
        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Id of the storage container that hosts the VM configuration file",
        SerializedName = @"vmConfigStoragePathId",
        PossibleTypes = new [] { typeof(string) })]
        string VMConfigStoragePathId { get; set; }

    }
    /// StorageProfile - contains information about the disks and storage information for the virtual machine
    internal partial interface IVirtualMachinePropertiesStorageProfileInternal

    {
        /// <summary>adds data disks to the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] DataDisk { get; set; }
        /// <summary>Which Image to use for the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference ImageReference { get; set; }
        /// <summary>Resource ID of the image</summary>
        string ImageReferenceId { get; set; }
        /// <summary>VHD to attach as OS disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk OSDisk { get; set; }
        /// <summary>Resource ID of the OS disk</summary>
        string OSDiskId { get; set; }
        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        string VMConfigStoragePathId { get; set; }

    }
}