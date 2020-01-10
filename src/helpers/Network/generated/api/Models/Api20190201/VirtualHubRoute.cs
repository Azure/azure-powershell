namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualHub route</summary>
    public partial class VirtualHubRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string[] _addressPrefix;

        /// <summary>List of all addressPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="NextHopIPAddress" /> property.</summary>
        private string _nextHopIPAddress;

        /// <summary>NextHop ip address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHopIPAddress { get => this._nextHopIPAddress; set => this._nextHopIPAddress = value; }

        /// <summary>Creates an new <see cref="VirtualHubRoute" /> instance.</summary>
        public VirtualHubRoute()
        {

        }
    }
    /// VirtualHub route
    public partial interface IVirtualHubRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of all addressPrefixes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all addressPrefixes.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefix { get; set; }
        /// <summary>NextHop ip address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NextHop ip address.",
        SerializedName = @"nextHopIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string NextHopIPAddress { get; set; }

    }
    /// VirtualHub route
    internal partial interface IVirtualHubRouteInternal

    {
        /// <summary>List of all addressPrefixes.</summary>
        string[] AddressPrefix { get; set; }
        /// <summary>NextHop ip address.</summary>
        string NextHopIPAddress { get; set; }

    }
}