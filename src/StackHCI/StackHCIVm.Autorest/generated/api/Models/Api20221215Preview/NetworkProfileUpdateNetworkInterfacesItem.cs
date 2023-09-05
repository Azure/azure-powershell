namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class NetworkProfileUpdateNetworkInterfacesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItemInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID - Resource ID of the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="NetworkProfileUpdateNetworkInterfacesItem" /> instance.
        /// </summary>
        public NetworkProfileUpdateNetworkInterfacesItem()
        {

        }
    }
    public partial interface INetworkProfileUpdateNetworkInterfacesItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>ID - Resource ID of the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID - Resource ID of the network interface",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    internal partial interface INetworkProfileUpdateNetworkInterfacesItemInternal

    {
        /// <summary>ID - Resource ID of the network interface</summary>
        string Id { get; set; }

    }
}