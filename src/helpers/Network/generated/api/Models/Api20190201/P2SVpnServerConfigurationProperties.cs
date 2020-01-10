namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for P2SVpnServerConfiguration</summary>
    public partial class P2SVpnServerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Internal Acessors for P2SVpnGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationPropertiesInternal.P2SVpnGateway { get => this._p2SVpnGateway; set { {_p2SVpnGateway = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group. This name can be used
        /// to access the resource along with Paren VirtualWan resource name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="P2SVpnGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _p2SVpnGateway;

        /// <summary>List of references to P2SVpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] P2SVpnGateway { get => this._p2SVpnGateway; }

        /// <summary>
        /// Backing field for <see cref="P2SVpnServerConfigRadiusClientRootCertificate" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[] _p2SVpnServerConfigRadiusClientRootCertificate;

        /// <summary>Radius client root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[] P2SVpnServerConfigRadiusClientRootCertificate { get => this._p2SVpnServerConfigRadiusClientRootCertificate; set => this._p2SVpnServerConfigRadiusClientRootCertificate = value; }

        /// <summary>
        /// Backing field for <see cref="P2SVpnServerConfigRadiusServerRootCertificate" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[] _p2SVpnServerConfigRadiusServerRootCertificate;

        /// <summary>Radius Server root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[] P2SVpnServerConfigRadiusServerRootCertificate { get => this._p2SVpnServerConfigRadiusServerRootCertificate; set => this._p2SVpnServerConfigRadiusServerRootCertificate = value; }

        /// <summary>
        /// Backing field for <see cref="P2SVpnServerConfigVpnClientRevokedCertificate" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[] _p2SVpnServerConfigVpnClientRevokedCertificate;

        /// <summary>VPN client revoked certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[] P2SVpnServerConfigVpnClientRevokedCertificate { get => this._p2SVpnServerConfigVpnClientRevokedCertificate; set => this._p2SVpnServerConfigVpnClientRevokedCertificate = value; }

        /// <summary>
        /// Backing field for <see cref="P2SVpnServerConfigVpnClientRootCertificate" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[] _p2SVpnServerConfigVpnClientRootCertificate;

        /// <summary>VPN client root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[] P2SVpnServerConfigVpnClientRootCertificate { get => this._p2SVpnServerConfigVpnClientRootCertificate; set => this._p2SVpnServerConfigVpnClientRootCertificate = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RadiusServerAddress" /> property.</summary>
        private string _radiusServerAddress;

        /// <summary>
        /// The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RadiusServerAddress { get => this._radiusServerAddress; set => this._radiusServerAddress = value; }

        /// <summary>Backing field for <see cref="RadiusServerSecret" /> property.</summary>
        private string _radiusServerSecret;

        /// <summary>
        /// The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RadiusServerSecret { get => this._radiusServerSecret; set => this._radiusServerSecret = value; }

        /// <summary>Backing field for <see cref="VpnClientIpsecPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] _vpnClientIpsecPolicy;

        /// <summary>VpnClientIpsecPolicies for P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get => this._vpnClientIpsecPolicy; set => this._vpnClientIpsecPolicy = value; }

        /// <summary>Backing field for <see cref="VpnProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[] _vpnProtocol;

        /// <summary>VPN protocols for the P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[] VpnProtocol { get => this._vpnProtocol; set => this._vpnProtocol = value; }

        /// <summary>Creates an new <see cref="P2SVpnServerConfigurationProperties" /> instance.</summary>
        public P2SVpnServerConfigurationProperties()
        {

        }
    }
    /// Parameters for P2SVpnServerConfiguration
    public partial interface IP2SVpnServerConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>
        /// The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group. This name can be used
        /// to access the resource along with Paren VirtualWan resource name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group. This name can be used to access the resource along with Paren VirtualWan resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>List of references to P2SVpnGateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of references to P2SVpnGateways.",
        SerializedName = @"p2SVpnGateways",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] P2SVpnGateway { get;  }
        /// <summary>Radius client root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Radius client root certificate of P2SVpnServerConfiguration.",
        SerializedName = @"p2SVpnServerConfigRadiusClientRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[] P2SVpnServerConfigRadiusClientRootCertificate { get; set; }
        /// <summary>Radius Server root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Radius Server root certificate of P2SVpnServerConfiguration.",
        SerializedName = @"p2SVpnServerConfigRadiusServerRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[] P2SVpnServerConfigRadiusServerRootCertificate { get; set; }
        /// <summary>VPN client revoked certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN client revoked certificate of P2SVpnServerConfiguration.",
        SerializedName = @"p2SVpnServerConfigVpnClientRevokedCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[] P2SVpnServerConfigVpnClientRevokedCertificate { get; set; }
        /// <summary>VPN client root certificate of P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN client root certificate of P2SVpnServerConfiguration.",
        SerializedName = @"p2SVpnServerConfigVpnClientRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[] P2SVpnServerConfigVpnClientRootCertificate { get; set; }
        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the P2SVpnServerConfiguration resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.",
        SerializedName = @"radiusServerAddress",
        PossibleTypes = new [] { typeof(string) })]
        string RadiusServerAddress { get; set; }
        /// <summary>
        /// The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.",
        SerializedName = @"radiusServerSecret",
        PossibleTypes = new [] { typeof(string) })]
        string RadiusServerSecret { get; set; }
        /// <summary>VpnClientIpsecPolicies for P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientIpsecPolicies for P2SVpnServerConfiguration.",
        SerializedName = @"vpnClientIpsecPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get; set; }
        /// <summary>VPN protocols for the P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN protocols for the P2SVpnServerConfiguration.",
        SerializedName = @"vpnProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[] VpnProtocol { get; set; }

    }
    /// Parameters for P2SVpnServerConfiguration
    internal partial interface IP2SVpnServerConfigurationPropertiesInternal

    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group. This name can be used
        /// to access the resource along with Paren VirtualWan resource name.
        /// </summary>
        string Name { get; set; }
        /// <summary>List of references to P2SVpnGateways.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] P2SVpnGateway { get; set; }
        /// <summary>Radius client root certificate of P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[] P2SVpnServerConfigRadiusClientRootCertificate { get; set; }
        /// <summary>Radius Server root certificate of P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[] P2SVpnServerConfigRadiusServerRootCertificate { get; set; }
        /// <summary>VPN client revoked certificate of P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[] P2SVpnServerConfigVpnClientRevokedCertificate { get; set; }
        /// <summary>VPN client root certificate of P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[] P2SVpnServerConfigVpnClientRootCertificate { get; set; }
        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        string RadiusServerAddress { get; set; }
        /// <summary>
        /// The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.
        /// </summary>
        string RadiusServerSecret { get; set; }
        /// <summary>VpnClientIpsecPolicies for P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] VpnClientIpsecPolicy { get; set; }
        /// <summary>VPN protocols for the P2SVpnServerConfiguration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[] VpnProtocol { get; set; }

    }
}