namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>NetworkFeatures resource specific properties</summary>
    public partial class NetworkFeaturesProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal
    {

        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CertBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).CertBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).CertBlob = value; }

        /// <summary>The client certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).CertThumbprint; }

        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).DnsServer = value; }

        /// <summary>Backing field for <see cref="HybridConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] _hybridConnection;

        /// <summary>The Hybrid Connections summary view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] HybridConnection { get => this._hybridConnection; }

        /// <summary>Backing field for <see cref="HybridConnectionsV2" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] _hybridConnectionsV2;

        /// <summary>The Hybrid Connection V2 (Service Bus) view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] HybridConnectionsV2 { get => this._hybridConnectionsV2; }

        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsSwift { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).IsSwift; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).IsSwift = value; }

        /// <summary>Internal Acessors for CertThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.CertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).CertThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).CertThumbprint = value; }

        /// <summary>Internal Acessors for HybridConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.HybridConnection { get => this._hybridConnection; set { {_hybridConnection = value;} } }

        /// <summary>Internal Acessors for HybridConnectionsV2</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.HybridConnectionsV2 { get => this._hybridConnectionsV2; set { {_hybridConnectionsV2 = value;} } }

        /// <summary>Internal Acessors for ResyncRequired</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.ResyncRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).ResyncRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).ResyncRequired = value; }

        /// <summary>Internal Acessors for Route</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).Route = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkConnection { get => (this._virtualNetworkConnection = this._virtualNetworkConnection ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo()); set { {_virtualNetworkConnection = value;} } }

        /// <summary>Internal Acessors for VirtualNetworkConnectionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkConnectionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Id = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkConnectionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Name = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkConnectionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).Property = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkConnectionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Type = value; }

        /// <summary>Internal Acessors for VirtualNetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal.VirtualNetworkName { get => this._virtualNetworkName; set { {_virtualNetworkName = value;} } }

        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ResyncRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).ResyncRequired; }

        /// <summary>The routes that this Virtual Network connection uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).Route; }

        /// <summary>Backing field for <see cref="VirtualNetworkConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo _virtualNetworkConnection;

        /// <summary>The Virtual Network summary view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo VirtualNetworkConnection { get => (this._virtualNetworkConnection = this._virtualNetworkConnection ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo()); }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Kind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Name; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)VirtualNetworkConnection).Type; }

        /// <summary>Backing field for <see cref="VirtualNetworkName" /> property.</summary>
        private string _virtualNetworkName;

        /// <summary>The Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualNetworkName { get => this._virtualNetworkName; }

        /// <summary>The Virtual Network's resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).VnetResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)VirtualNetworkConnection).VnetResourceId = value; }

        /// <summary>Creates an new <see cref="NetworkFeaturesProperties" /> instance.</summary>
        public NetworkFeaturesProperties()
        {

        }
    }
    /// NetworkFeatures resource specific properties
    public partial interface INetworkFeaturesProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        Point-To-Site VPN connection.",
        SerializedName = @"certBlob",
        PossibleTypes = new [] { typeof(string) })]
        string CertBlob { get; set; }
        /// <summary>The client certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The client certificate thumbprint.",
        SerializedName = @"certThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string CertThumbprint { get;  }
        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string DnsServer { get; set; }
        /// <summary>The Hybrid Connections summary view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Hybrid Connections summary view.",
        SerializedName = @"hybridConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] HybridConnection { get;  }
        /// <summary>The Hybrid Connection V2 (Service Bus) view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Hybrid Connection V2 (Service Bus) view.",
        SerializedName = @"hybridConnectionsV2",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] HybridConnectionsV2 { get;  }
        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag that is used to denote if this is VNET injection",
        SerializedName = @"isSwift",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSwift { get; set; }
        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if a resync is required; otherwise, <code>false</code>.",
        SerializedName = @"resyncRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResyncRequired { get;  }
        /// <summary>The routes that this Virtual Network connection uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The routes that this Virtual Network connection uses.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get;  }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConnectionId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConnectionKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConnectionName { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConnectionType { get;  }
        /// <summary>The Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Virtual Network name.",
        SerializedName = @"virtualNetworkName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkName { get;  }
        /// <summary>The Virtual Network's resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Network's resource ID.",
        SerializedName = @"vnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetResourceId { get; set; }

    }
    /// NetworkFeatures resource specific properties
    internal partial interface INetworkFeaturesPropertiesInternal

    {
        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        string CertBlob { get; set; }
        /// <summary>The client certificate thumbprint.</summary>
        string CertThumbprint { get; set; }
        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        string DnsServer { get; set; }
        /// <summary>The Hybrid Connections summary view.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] HybridConnection { get; set; }
        /// <summary>The Hybrid Connection V2 (Service Bus) view.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] HybridConnectionsV2 { get; set; }
        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        bool? IsSwift { get; set; }
        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        bool? ResyncRequired { get; set; }
        /// <summary>The routes that this Virtual Network connection uses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get; set; }
        /// <summary>The Virtual Network summary view.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo VirtualNetworkConnection { get; set; }
        /// <summary>Resource Id.</summary>
        string VirtualNetworkConnectionId { get; set; }
        /// <summary>Kind of resource.</summary>
        string VirtualNetworkConnectionKind { get; set; }
        /// <summary>Resource Name.</summary>
        string VirtualNetworkConnectionName { get; set; }
        /// <summary>VnetInfo resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties VirtualNetworkConnectionProperty { get; set; }
        /// <summary>Resource type.</summary>
        string VirtualNetworkConnectionType { get; set; }
        /// <summary>The Virtual Network name.</summary>
        string VirtualNetworkName { get; set; }
        /// <summary>The Virtual Network's resource ID.</summary>
        string VnetResourceId { get; set; }

    }
}