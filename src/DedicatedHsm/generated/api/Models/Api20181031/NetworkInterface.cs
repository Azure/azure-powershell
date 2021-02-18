namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>The network interface definition.</summary>
    public partial class NetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterfaceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterfaceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>Private Ip address of the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Creates an new <see cref="NetworkInterface" /> instance.</summary>
        public NetworkInterface()
        {

        }
    }
    /// The network interface definition.
    public partial interface INetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Private Ip address of the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private Ip address of the interface",
        SerializedName = @"privateIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }

    }
    /// The network interface definition.
    internal partial interface INetworkInterfaceInternal

    {
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string Id { get; set; }
        /// <summary>Private Ip address of the interface</summary>
        string PrivateIPAddress { get; set; }

    }
}