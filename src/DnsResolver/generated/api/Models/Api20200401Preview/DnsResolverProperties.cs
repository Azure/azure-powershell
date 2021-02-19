namespace Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Extensions;

    /// <summary>Represents the properties of a DNS resolver.</summary>
    public partial class DnsResolverProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DnsResolverState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState? _dnsResolverState;

        /// <summary>
        /// The current status of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState? DnsResolverState { get => this._dnsResolverState; }

        /// <summary>Backing field for <see cref="MaxNumberOfInboundEndpoint" /> property.</summary>
        private long? _maxNumberOfInboundEndpoint;

        /// <summary>
        /// The maximum number of inbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public long? MaxNumberOfInboundEndpoint { get => this._maxNumberOfInboundEndpoint; }

        /// <summary>Backing field for <see cref="MaxNumberOfOutboundEndpoint" /> property.</summary>
        private long? _maxNumberOfOutboundEndpoint;

        /// <summary>
        /// The maximum number of outbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public long? MaxNumberOfOutboundEndpoint { get => this._maxNumberOfOutboundEndpoint; }

        /// <summary>Internal Acessors for DnsResolverState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.DnsResolverState { get => this._dnsResolverState; set { {_dnsResolverState = value;} } }

        /// <summary>Internal Acessors for MaxNumberOfInboundEndpoint</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.MaxNumberOfInboundEndpoint { get => this._maxNumberOfInboundEndpoint; set { {_maxNumberOfInboundEndpoint = value;} } }

        /// <summary>Internal Acessors for MaxNumberOfOutboundEndpoint</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.MaxNumberOfOutboundEndpoint { get => this._maxNumberOfOutboundEndpoint; set { {_maxNumberOfOutboundEndpoint = value;} } }

        /// <summary>Internal Acessors for NumberOfInboundEndpoint</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.NumberOfInboundEndpoint { get => this._numberOfInboundEndpoint; set { {_numberOfInboundEndpoint = value;} } }

        /// <summary>Internal Acessors for NumberOfOutboundEndpoint</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.NumberOfOutboundEndpoint { get => this._numberOfOutboundEndpoint; set { {_numberOfOutboundEndpoint = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.ResourceGuid { get => this._resourceGuid; set { {_resourceGuid = value;} } }

        /// <summary>Internal Acessors for VirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResource Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolverPropertiesInternal.VirtualNetwork { get => (this._virtualNetwork = this._virtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.SubResource()); set { {_virtualNetwork = value;} } }

        /// <summary>Backing field for <see cref="NumberOfInboundEndpoint" /> property.</summary>
        private long? _numberOfInboundEndpoint;

        /// <summary>
        /// The current number of inbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public long? NumberOfInboundEndpoint { get => this._numberOfInboundEndpoint; }

        /// <summary>Backing field for <see cref="NumberOfOutboundEndpoint" /> property.</summary>
        private long? _numberOfOutboundEndpoint;

        /// <summary>
        /// The current number of outbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public long? NumberOfOutboundEndpoint { get => this._numberOfOutboundEndpoint; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? _provisioningState;

        /// <summary>
        /// The current provisioning state of the DNS resolver. This is a read-only property and any attempt to set this value will
        /// be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resourceGuid property of the DNS resolver resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; }

        /// <summary>Backing field for <see cref="VirtualNetwork" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResource _virtualNetwork;

        /// <summary>The reference to the virtual network. This cannot be changed after creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResource VirtualNetwork { get => (this._virtualNetwork = this._virtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.SubResource()); set => this._virtualNetwork = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Origin(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.PropertyOrigin.Inlined)]
        public string VirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResourceInternal)VirtualNetwork).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResourceInternal)VirtualNetwork).Id = value ?? null; }

        /// <summary>Creates an new <see cref="DnsResolverProperties" /> instance.</summary>
        public DnsResolverProperties()
        {

        }
    }
    /// Represents the properties of a DNS resolver.
    public partial interface IDnsResolverProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The current status of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current status of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"dnsResolverState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState? DnsResolverState { get;  }
        /// <summary>
        /// The maximum number of inbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The maximum number of inbound endpoints that can be created for the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"maxNumberOfInboundEndpoints",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxNumberOfInboundEndpoint { get;  }
        /// <summary>
        /// The maximum number of outbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The maximum number of outbound endpoints that can be created for the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"maxNumberOfOutboundEndpoints",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxNumberOfOutboundEndpoint { get;  }
        /// <summary>
        /// The current number of inbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current number of inbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"numberOfInboundEndpoints",
        PossibleTypes = new [] { typeof(long) })]
        long? NumberOfInboundEndpoint { get;  }
        /// <summary>
        /// The current number of outbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current number of outbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"numberOfOutboundEndpoints",
        PossibleTypes = new [] { typeof(long) })]
        long? NumberOfOutboundEndpoint { get;  }
        /// <summary>
        /// The current provisioning state of the DNS resolver. This is a read-only property and any attempt to set this value will
        /// be ignored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current provisioning state of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The resourceGuid property of the DNS resolver resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resourceGuid property of the DNS resolver resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkId { get; set; }

    }
    /// Represents the properties of a DNS resolver.
    internal partial interface IDnsResolverPropertiesInternal

    {
        /// <summary>
        /// The current status of the DNS resolver. This is a read-only property and any attempt to set this value will be ignored.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsResolverState? DnsResolverState { get; set; }
        /// <summary>
        /// The maximum number of inbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        long? MaxNumberOfInboundEndpoint { get; set; }
        /// <summary>
        /// The maximum number of outbound endpoints that can be created for the DNS resolver. This is a read-only property and any
        /// attempt to set this value will be ignored.
        /// </summary>
        long? MaxNumberOfOutboundEndpoint { get; set; }
        /// <summary>
        /// The current number of inbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        long? NumberOfInboundEndpoint { get; set; }
        /// <summary>
        /// The current number of outbound endpoints for the DNS resolver. This is a read-only property and any attempt to set this
        /// value will be ignored.
        /// </summary>
        long? NumberOfOutboundEndpoint { get; set; }
        /// <summary>
        /// The current provisioning state of the DNS resolver. This is a read-only property and any attempt to set this value will
        /// be ignored.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The resourceGuid property of the DNS resolver resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>The reference to the virtual network. This cannot be changed after creation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResource VirtualNetwork { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualNetworkId { get; set; }

    }
}