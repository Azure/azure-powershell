namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>VHD to attach as OS disk</summary>
    public partial class VirtualMachinePropertiesStorageProfileOSDisk :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDiskInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesStorageProfileOSDisk" /> instance.
        /// </summary>
        public VirtualMachinePropertiesStorageProfileOSDisk()
        {

        }
    }
    /// VHD to attach as OS disk
    public partial interface IVirtualMachinePropertiesStorageProfileOSDisk :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the OS disk",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// VHD to attach as OS disk
    internal partial interface IVirtualMachinePropertiesStorageProfileOSDiskInternal

    {
        /// <summary>Resource ID of the OS disk</summary>
        string Id { get; set; }

    }
}