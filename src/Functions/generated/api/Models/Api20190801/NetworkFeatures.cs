namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    /// </summary>
    public partial class NetworkFeatures :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeatures,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CertBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).CertBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).CertBlob = value; }

        /// <summary>The client certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).CertThumbprint; }

        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).DnsServer = value; }

        /// <summary>The Hybrid Connections summary view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] HybridConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnection; }

        /// <summary>The Hybrid Connection V2 (Service Bus) view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] HybridConnectionsV2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnectionsV2; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsSwift { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).IsSwift; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).IsSwift = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for CertThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.CertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).CertThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).CertThumbprint = value; }

        /// <summary>Internal Acessors for HybridConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntity[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.HybridConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnection = value; }

        /// <summary>Internal Acessors for HybridConnectionsV2</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnection[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.HybridConnectionsV2 { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnectionsV2; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).HybridConnectionsV2 = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeaturesProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResyncRequired</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.ResyncRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).ResyncRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).ResyncRequired = value; }

        /// <summary>Internal Acessors for Route</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).Route = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnection = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkConnectionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionId = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkConnectionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionName = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkConnectionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionProperty = value; }

        /// <summary>Internal Acessors for VirtualNetworkConnectionType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkConnectionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionType = value; }

        /// <summary>Internal Acessors for VirtualNetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesInternal.VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkName = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties _property;

        /// <summary>NetworkFeatures resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkFeaturesProperties()); set => this._property = value; }

        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ResyncRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).ResyncRequired; }

        /// <summary>The routes that this Virtual Network connection uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).Route; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionKind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionName; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkConnectionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkConnectionType; }

        /// <summary>The Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VirtualNetworkName; }

        /// <summary>The Virtual Network's resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VnetResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesPropertiesInternal)Property).VnetResourceId = value; }

        /// <summary>Creates an new <see cref="NetworkFeatures" /> instance.</summary>
        public NetworkFeatures()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    public partial interface INetworkFeatures :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Full view of network features for an app (presently VNET integration and Hybrid Connections).
    internal partial interface INetworkFeaturesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>NetworkFeatures resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkFeaturesProperties Property { get; set; }
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