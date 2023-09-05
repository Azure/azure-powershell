namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class VirtualMachinePropertiesNetworkProfileNetworkInterfacesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItemInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID - Resource Id of the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesNetworkProfileNetworkInterfacesItem" /> instance.
        /// </summary>
        public VirtualMachinePropertiesNetworkProfileNetworkInterfacesItem()
        {

        }
    }
    public partial interface IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>ID - Resource Id of the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID - Resource Id of the network interface",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    internal partial interface IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItemInternal

    {
        /// <summary>ID - Resource Id of the network interface</summary>
        string Id { get; set; }

    }
}