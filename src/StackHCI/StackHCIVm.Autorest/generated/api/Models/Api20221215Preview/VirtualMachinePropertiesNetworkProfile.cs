namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>NetworkProfile - describes the network configuration the virtual machine</summary>
    public partial class VirtualMachinePropertiesNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileInternal
    {

        /// <summary>Backing field for <see cref="NetworkInterface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] _networkInterface;

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkInterface { get => this._networkInterface; set => this._networkInterface = value; }

        /// <summary>Creates an new <see cref="VirtualMachinePropertiesNetworkProfile" /> instance.</summary>
        public VirtualMachinePropertiesNetworkProfile()
        {

        }
    }
    /// NetworkProfile - describes the network configuration the virtual machine
    public partial interface IVirtualMachinePropertiesNetworkProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NetworkInterfaces - list of network interfaces to be attached to the virtual machine",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkInterface { get; set; }

    }
    /// NetworkProfile - describes the network configuration the virtual machine
    internal partial interface IVirtualMachinePropertiesNetworkProfileInternal

    {
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkInterface { get; set; }

    }
}