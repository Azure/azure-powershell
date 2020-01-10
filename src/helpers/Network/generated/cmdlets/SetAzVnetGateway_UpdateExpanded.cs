namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Creates or updates a virtual network gateway in the specified resource group.</summary>
    /// <remarks>
    /// [OpenAPI] VirtualNetworkGateways_CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}"
    /// [METADATA]
    /// path: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{virtualNetworkGatewayName}'
    /// apiVersions:
    /// - '2019-02-01'
    /// filename:
    /// - 'mem:///993?oai3.shaken.json'
    /// originalLocations:
    /// - >-
    /// https://github.com/Azure/azure-rest-api-specs/blob/resource-hybrid-profile-fix/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/virtualNetworkGateway.json#/paths/~1subscriptions~1{subscriptionId}~1resourceGroups~1{resourceGroupName}~1providers~1Microsoft.Network~1virtualNetworkGateways~1{virtualNetworkGatewayName}
    /// profiles:
    /// latest-2019-04-30: '2019-02-01'
    /// [DETAILS]
    /// verb: Set
    /// subjectPrefix:
    /// subject: VnetGateway
    /// variant: UpdateExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.Set, @"AzVnetGateway_UpdateExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.Alias("Set-AzVirtualNetworkGateway")]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Description(@"Creates or updates a virtual network gateway in the specified resource group.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Profile("latest-2019-04-30")]
    public partial class SetAzVnetGateway_UpdateExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = System.Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private global::System.Management.Automation.InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        /// The <see cref="global::System.Threading.CancellationTokenSource" /> for this operation.
        /// </summary>
        private global::System.Threading.CancellationTokenSource _cancellationTokenSource = new global::System.Threading.CancellationTokenSource();

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A list of address blocks reserved for this virtual network in CIDR notation.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("VpnClientAddressPool", "VpnClientAddressPrefix")]
        public string[] AddressPrefix { get => ParametersBody.AddressPrefix ?? null /* arrayOf */; set => ParametersBody.AddressPrefix = value; }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>The BGP speaker's ASN.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The BGP speaker's ASN.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        [global::System.Management.Automation.Alias("Asn")]
        public long BgpAsn { get => ParametersBody.BgpAsn ?? default(long); set => ParametersBody.BgpAsn = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The weight added to routes learned from this BGP speaker.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        [global::System.Management.Automation.Alias("PeerWeight", "BgpPeeringWeight")]
        public int BgpPeerWeight { get => ParametersBody.BgpPeerWeight ?? default(int); set => ParametersBody.BgpPeerWeight = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The BGP peering address and BGP identifier of this BGP speaker.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        public string BgpPeeringAddress { get => ParametersBody.BgpPeeringAddress ?? null; set => ParametersBody.BgpPeeringAddress = value; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Network Client => Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.ClientAPI;

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A list of address blocks reserved for this virtual network in CIDR notation.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        public string[] CustomRouteAddressPrefix { get => ParametersBody.CustomRouteAddressPrefix ?? null /* arrayOf */; set => ParametersBody.CustomRouteAddressPrefix = value; }

        /// <summary>
        /// The credentials, account, tenant, and subscription used for communication with Azure
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>ActiveActive flag</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "ActiveActive flag")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ActiveActive flag",
        SerializedName = @"activeActive",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        [global::System.Management.Automation.Alias("EnableActiveActiveFeature")]
        public global::System.Management.Automation.SwitchParameter EnableActiveActive { get => ParametersBody.EnableActiveActive ?? default(global::System.Management.Automation.SwitchParameter); set => ParametersBody.EnableActiveActive = value; }

        /// <summary>Whether BGP is enabled for this virtual network gateway or not.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether BGP is enabled for this virtual network gateway or not.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether BGP is enabled for this virtual network gateway or not.",
        SerializedName = @"enableBgp",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableBgp { get => ParametersBody.EnableBgp ?? default(global::System.Management.Automation.SwitchParameter); set => ParametersBody.EnableBgp = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets a unique read-only string that changes whenever the resource is updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        public string Etag { get => ParametersBody.Etag ?? null; set => ParametersBody.Etag = value; }

        /// <summary>Resource ID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource ID.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        public string GatewayDefaultSiteId { get => ParametersBody.GatewayDefaultSiteId ?? null; set => ParametersBody.GatewayDefaultSiteId = value; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.",
        SerializedName = @"gatewayType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType GatewayType { get => ParametersBody.GatewayType ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType)""); set => ParametersBody.GatewayType = value; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>IP configurations for virtual network gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "IP configurations for virtual network gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP configurations for virtual network gateway.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayIPConfiguration) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayIPConfiguration[] IPConfiguration { get => ParametersBody.IPConfiguration ?? null /* arrayOf */; set => ParametersBody.IPConfiguration = value; }

        /// <summary>VpnClientIpsecPolicies for virtual network gateway P2S client.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VpnClientIpsecPolicies for virtual network gateway P2S client.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientIpsecPolicies for virtual network gateway P2S client.",
        SerializedName = @"vpnClientIpsecPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy) })]
        [global::System.Management.Automation.Alias("VpnClientIPsecPolicy")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IPsecPolicy { get => ParametersBody.IPsecPolicy ?? null /* arrayOf */; set => ParametersBody.IPsecPolicy = value; }

        /// <summary>Resource ID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource ID.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        public string Id { get => ParametersBody.Id ?? null; set => ParametersBody.Id = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>Resource location.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource location.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        public string Location { get => ParametersBody.Location ?? null; set => ParametersBody.Location = value; }

        /// <summary>
        /// <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the virtual network gateway.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the virtual network gateway.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the virtual network gateway.",
        SerializedName = @"virtualNetworkGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("VirtualNetworkGatewayName")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>Backing field for <see cref="ParametersBody" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway _parametersBody= new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkGateway();

        /// <summary>A common class for general resource information</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway ParametersBody { get => this._parametersBody; set => this._parametersBody = value; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>VpnClientProtocols for Virtual network gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VpnClientProtocols for Virtual network gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientProtocols for Virtual network gateway.",
        SerializedName = @"vpnClientProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol))]
        [global::System.Management.Automation.Alias("VpnClientProtocol")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[] Protocol { get => ParametersBody.Protocol ?? null /* arrayOf */; set => ParametersBody.Protocol = value; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>
        /// The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The radius server address property of the VirtualNetworkGateway resource for vpn client connection.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius server address property of the VirtualNetworkGateway resource for vpn client connection.",
        SerializedName = @"radiusServerAddress",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("VpnClientRadiusServerAddress")]
        public string RadiusServerAddress { get => ParametersBody.RadiusServerAddress ?? null; set => ParametersBody.RadiusServerAddress = value; }

        /// <summary>
        /// The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The radius secret property of the VirtualNetworkGateway resource for vpn client connection.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The radius secret property of the VirtualNetworkGateway resource for vpn client connection.",
        SerializedName = @"radiusServerSecret",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("VpnClientRadiusServerSecret")]
        public string RadiusServerSecret { get => ParametersBody.RadiusServerSecret ?? null; set => ParametersBody.RadiusServerSecret = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the resource group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the resource group.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>The resource GUID property of the VirtualNetworkGateway resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The resource GUID property of the VirtualNetworkGateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the VirtualNetworkGateway resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        public string ResourceGuid { get => ParametersBody.ResourceGuid ?? null; set => ParametersBody.ResourceGuid = value; }

        /// <summary>VpnClientRevokedCertificate for Virtual network gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VpnClientRevokedCertificate for Virtual network gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientRevokedCertificate for Virtual network gateway.",
        SerializedName = @"vpnClientRevokedCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate) })]
        [global::System.Management.Automation.Alias("VpnClientRevokedCertificates", "VpnClientRevokedCertificate")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[] RevokedCertificate { get => ParametersBody.RevokedCertificate ?? null /* arrayOf */; set => ParametersBody.RevokedCertificate = value; }

        /// <summary>VpnClientRootCertificate for virtual network gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VpnClientRootCertificate for virtual network gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VpnClientRootCertificate for virtual network gateway.",
        SerializedName = @"vpnClientRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate) })]
        [global::System.Management.Automation.Alias("VpnClientRootCertificates", "VpnClientRootCertificate")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[] RootCertificate { get => ParametersBody.RootCertificate ?? null /* arrayOf */; set => ParametersBody.RootCertificate = value; }

        /// <summary>The capacity.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The capacity.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The capacity.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        public int SkuCapacity { get => ParametersBody.SkuCapacity ?? default(int); set => ParametersBody.SkuCapacity = value; }

        /// <summary>Gateway SKU name.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gateway SKU name.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gateway SKU name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName SkuName { get => ParametersBody.SkuName ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName)""); set => ParametersBody.SkuName = value; }

        /// <summary>Gateway SKU tier.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gateway SKU tier.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gateway SKU tier.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier SkuTier { get => ParametersBody.SkuTier ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier)""); set => ParametersBody.SkuTier = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part
        /// of the URI for every service call.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.DefaultInfo(
        Name = @"",
        Description =@"",
        Script = @"(Get-AzContext).Subscription.Id")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Resource tags.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource tags.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ParametersBody.Tag ?? null /* object */; set => ParametersBody.Tag = value; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.",
        SerializedName = @"vpnType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType VpnType { get => ParametersBody.VpnType ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType)""); set => ParametersBody.VpnType = value; }

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway"
        /// /> from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of SetAzVnetGateway_UpdateExpanded</returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.SetAzVnetGateway_UpdateExpanded Clone()
        {
            var clone = new SetAzVnetGateway_UpdateExpanded();
            clone.__correlationId = this.__correlationId;
            clone.__processRecordId = this.__processRecordId;
            clone.DefaultProfile = this.DefaultProfile;
            clone.InvocationInformation = this.InvocationInformation;
            clone.Proxy = this.Proxy;
            clone.Pipeline = this.Pipeline;
            clone.AsJob = this.AsJob;
            clone.Break = this.Break;
            clone.ProxyCredential = this.ProxyCredential;
            clone.ProxyUseDefaultCredentials = this.ProxyUseDefaultCredentials;
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            clone.ParametersBody = this.ParametersBody;
            clone.ResourceGroupName = this.ResourceGroupName;
            clone.Name = this.Name;
            clone.SubscriptionId = this.SubscriptionId;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletEndProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.DelayBeforePolling:
                    {
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            var data = messageData();
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }
                        break;
                    }
                }
                await Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.Signal(id, token, messageData, (i,t,m) => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(i,t,()=> Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventDataConverter.ConvertFrom( m() ) as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.EventData ), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'VirtualNetworkGatewaysCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async global::System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordAsyncStart); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    await this.Client.VirtualNetworkGatewaysCreateOrUpdate(ResourceGroupName, Name, SubscriptionId, ParametersBody, onOk, this, Pipeline);
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  ResourceGroupName=ResourceGroupName,Name=Name,SubscriptionId=SubscriptionId,body=ParametersBody})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>
        /// Intializes a new instance of the <see cref="SetAzVnetGateway_UpdateExpanded" /> cmdlet class.
        /// </summary>
        public SetAzVnetGateway_UpdateExpanded()
        {

        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway"
        /// /> from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // onOk - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
                WriteObject((await response));
            }
        }
    }
}