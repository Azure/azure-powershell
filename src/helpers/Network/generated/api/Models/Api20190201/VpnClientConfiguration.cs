namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VpnClientConfiguration for P2S client.</summary>
    public partial class VpnClientConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal
    {

        /// <summary>Internal Acessors for VpnClientAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal.VpnClientAddressPool { get => (this._vpnClientAddressPool = this._vpnClientAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set { {_vpnClientAddressPool = value;} } }

        /// <summary>Backing field for <see cref="RadiusServerAddress" /> property.</summary>
        private string _radiusServerAddress;

        /// <summary>
        /// The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RadiusServerAddress { get => this._radiusServerAddress; set => this._radiusServerAddress = value; }

        /// <summary>Backing field for <see cref="RadiusServerSecret" /> property.</summary>
        private string _radiusServerSecret;

        /// <summary>
        /// The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RadiusServerSecret { get => this._radiusServerSecret; set => this._radiusServerSecret = value; }

        /// <summary>Backing field for <see cref="VpnClientAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace _vpnClientAddressPool;

        /// <summary>
        /// The reference of the address space resource which represents Address space for P2S VpnClient.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace VpnClientAddressPool { get => (this._vpnClientAddressPool = this._vpnClientAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set => this._vpnClientAddressPool = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] VpnClientAddressPoolAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)VpnClientAddressPool).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)VpnClientAddressPool).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="VpnClientIpsecPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] _vpnClientIpsecPolicy;

        /// <summary>VpnClientIpsecPolicies for virtual network gateway P2S client.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get => this._vpnClientIpsecPolicy; set => this._vpnClientIpsecPolicy = value; }

        /// <summary>Backing field for <see cref="VpnClientProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[] _vpnClientProtocol;

        /// <summary>VpnClientProtocols for Virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[] VpnClientProtocol { get => this._vpnClientProtocol; set => this._vpnClientProtocol = value; }

        /// <summary>Backing field for <see cref="VpnClientRevokedCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[] _vpnClientRevokedCertificate;

        /// <summary>VpnClientRevokedCertificate for Virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[] VpnClientRevokedCertificate { get => this._vpnClientRevokedCertificate; set => this._vpnClientRevokedCertificate = value; }

        /// <summary>Backing field for <see cref="VpnClientRootCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[] _vpnClientRootCertificate;

        /// <summary>VpnClientRootCertificate for virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[] VpnClientRootCertificate { get => this._vpnClientRootCertificate; set => this._vpnClientRootCertificate = value; }

        /// <summary>Creates an new <see cref="VpnClientConfiguration" /> instance.</summary>
        public VpnClientConfiguration()
        {

        }
    }
    /// VpnClientConfiguration for P2S client.
    public partial interface IVpnClientConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius server address property of the VirtualNetworkGateway resource for vpn client connection.",
        SerializedName = @"radiusServerAddress",
        PossibleTypes = new [] { typeof(string) })]
        string RadiusServerAddress { get; set; }
        /// <summary>
        /// The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius secret property of the VirtualNetworkGateway resource for vpn client connection.",
        SerializedName = @"radiusServerSecret",
        PossibleTypes = new [] { typeof(string) })]
        string RadiusServerSecret { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnClientAddressPoolAddressPrefix { get; set; }
        /// <summary>VpnClientIpsecPolicies for virtual network gateway P2S client.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientIpsecPolicies for virtual network gateway P2S client.",
        SerializedName = @"vpnClientIpsecPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get; set; }
        /// <summary>VpnClientProtocols for Virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientProtocols for Virtual network gateway.",
        SerializedName = @"vpnClientProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[] VpnClientProtocol { get; set; }
        /// <summary>VpnClientRevokedCertificate for Virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientRevokedCertificate for Virtual network gateway.",
        SerializedName = @"vpnClientRevokedCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[] VpnClientRevokedCertificate { get; set; }
        /// <summary>VpnClientRootCertificate for virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientRootCertificate for virtual network gateway.",
        SerializedName = @"vpnClientRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[] VpnClientRootCertificate { get; set; }

    }
    /// VpnClientConfiguration for P2S client.
    internal partial interface IVpnClientConfigurationInternal

    {
        /// <summary>
        /// The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        string RadiusServerAddress { get; set; }
        /// <summary>
        /// The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        string RadiusServerSecret { get; set; }
        /// <summary>
        /// The reference of the address space resource which represents Address space for P2S VpnClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace VpnClientAddressPool { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] VpnClientAddressPoolAddressPrefix { get; set; }
        /// <summary>VpnClientIpsecPolicies for virtual network gateway P2S client.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get; set; }
        /// <summary>VpnClientProtocols for Virtual network gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[] VpnClientProtocol { get; set; }
        /// <summary>VpnClientRevokedCertificate for Virtual network gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[] VpnClientRevokedCertificate { get; set; }
        /// <summary>VpnClientRootCertificate for virtual network gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[] VpnClientRootCertificate { get; set; }

    }
}