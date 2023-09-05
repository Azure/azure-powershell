namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Which Image to use for the virtual machine</summary>
    public partial class VirtualMachinePropertiesStorageProfileImageReference :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReferenceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesStorageProfileImageReference" /> instance.
        /// </summary>
        public VirtualMachinePropertiesStorageProfileImageReference()
        {

        }
    }
    /// Which Image to use for the virtual machine
    public partial interface IVirtualMachinePropertiesStorageProfileImageReference :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the image",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Which Image to use for the virtual machine
    internal partial interface IVirtualMachinePropertiesStorageProfileImageReferenceInternal

    {
        /// <summary>Resource ID of the image</summary>
        string Id { get; set; }

    }
}