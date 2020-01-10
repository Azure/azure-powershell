namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VpnClientConnectionHealth properties</summary>
    public partial class VpnClientConnectionHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal
    {

        /// <summary>Backing field for <see cref="AllocatedIPAddress" /> property.</summary>
        private string[] _allocatedIPAddress;

        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AllocatedIPAddress { get => this._allocatedIPAddress; set => this._allocatedIPAddress = value; }

        /// <summary>Internal Acessors for TotalEgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal.TotalEgressBytesTransferred { get => this._totalEgressBytesTransferred; set { {_totalEgressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for TotalIngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal.TotalIngressBytesTransferred { get => this._totalIngressBytesTransferred; set { {_totalIngressBytesTransferred = value;} } }

        /// <summary>Backing field for <see cref="TotalEgressBytesTransferred" /> property.</summary>
        private long? _totalEgressBytesTransferred;

        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? TotalEgressBytesTransferred { get => this._totalEgressBytesTransferred; }

        /// <summary>Backing field for <see cref="TotalIngressBytesTransferred" /> property.</summary>
        private long? _totalIngressBytesTransferred;

        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? TotalIngressBytesTransferred { get => this._totalIngressBytesTransferred; }

        /// <summary>Backing field for <see cref="VpnClientConnectionsCount" /> property.</summary>
        private int? _vpnClientConnectionsCount;

        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? VpnClientConnectionsCount { get => this._vpnClientConnectionsCount; set => this._vpnClientConnectionsCount = value; }

        /// <summary>Creates an new <see cref="VpnClientConnectionHealth" /> instance.</summary>
        public VpnClientConnectionHealth()
        {

        }
    }
    /// VpnClientConnectionHealth properties
    public partial interface IVpnClientConnectionHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of allocated ip addresses to the connected p2s vpn clients.",
        SerializedName = @"allocatedIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllocatedIPAddress { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Egress Bytes Transferred in this connection",
        SerializedName = @"totalEgressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalEgressBytesTransferred { get;  }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Ingress Bytes Transferred in this P2S Vpn connection",
        SerializedName = @"totalIngressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalIngressBytesTransferred { get;  }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total of p2s vpn clients connected at this time to this P2SVpnGateway.",
        SerializedName = @"vpnClientConnectionsCount",
        PossibleTypes = new [] { typeof(int) })]
        int? VpnClientConnectionsCount { get; set; }

    }
    /// VpnClientConnectionHealth properties
    internal partial interface IVpnClientConnectionHealthInternal

    {
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        string[] AllocatedIPAddress { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        long? TotalEgressBytesTransferred { get; set; }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        long? TotalIngressBytesTransferred { get; set; }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        int? VpnClientConnectionsCount { get; set; }

    }
}