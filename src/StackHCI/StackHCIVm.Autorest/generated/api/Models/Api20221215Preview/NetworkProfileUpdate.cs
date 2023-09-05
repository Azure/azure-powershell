namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>NetworkProfile - describes the network update configuration the virtual machine</summary>
    public partial class NetworkProfileUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateInternal
    {

        /// <summary>Backing field for <see cref="NetworkInterface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] _networkInterface;

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkInterface { get => this._networkInterface; set => this._networkInterface = value; }

        /// <summary>Creates an new <see cref="NetworkProfileUpdate" /> instance.</summary>
        public NetworkProfileUpdate()
        {

        }
    }
    /// NetworkProfile - describes the network update configuration the virtual machine
    public partial interface INetworkProfileUpdate :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkInterface { get; set; }

    }
    /// NetworkProfile - describes the network update configuration the virtual machine
    internal partial interface INetworkProfileUpdateInternal

    {
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[] NetworkInterface { get; set; }

    }
}