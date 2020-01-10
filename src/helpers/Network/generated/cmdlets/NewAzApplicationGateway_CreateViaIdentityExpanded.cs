namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Creates or updates the specified application gateway.</summary>
    /// <remarks>
    /// [OpenAPI] ApplicationGateways_CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/applicationGateways/{applicationGatewayName}"
    /// [METADATA]
    /// path: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/applicationGateways/{applicationGatewayName}'
    /// apiVersions:
    /// - '2019-02-01'
    /// filename:
    /// - 'mem:///964?oai3.shaken.json'
    /// originalLocations:
    /// - >-
    /// https://github.com/Azure/azure-rest-api-specs/blob/resource-hybrid-profile-fix/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/applicationGateway.json#/paths/~1subscriptions~1{subscriptionId}~1resourceGroups~1{resourceGroupName}~1providers~1Microsoft.Network~1applicationGateways~1{applicationGatewayName}
    /// profiles:
    /// latest-2019-04-30: '2019-02-01'
    /// [DETAILS]
    /// verb: New
    /// subjectPrefix:
    /// subject: ApplicationGateway
    /// variant: CreateViaIdentityExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.New, @"AzApplicationGateway_CreateViaIdentityExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Description(@"Creates or updates the specified application gateway.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Profile("latest-2019-04-30")]
    public partial class NewAzApplicationGateway_CreateViaIdentityExpanded : global::System.Management.Automation.PSCmdlet,
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

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"authenticationCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificate) })]
        [global::System.Management.Automation.Alias("AuthenticationCertificates")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificate[] AuthenticationCertificate { get => ParametersBody.AuthenticationCertificate ?? null /* arrayOf */; set => ParametersBody.AuthenticationCertificate = value; }

        /// <summary>Upper bound on number of Application Gateway capacity</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Upper bound on number of Application Gateway capacity")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Upper bound on number of Application Gateway capacity",
        SerializedName = @"maxCapacity",
        PossibleTypes = new [] { typeof(int) })]
        public int AutoscaleMaximumCapacity { get => ParametersBody.AutoscaleMaximumCapacity ?? default(int); set => ParametersBody.AutoscaleMaximumCapacity = value; }

        /// <summary>Lower bound on number of Application Gateway capacity</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Lower bound on number of Application Gateway capacity")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Lower bound on number of Application Gateway capacity",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        public int AutoscaleMinimumCapacity { get => ParametersBody.AutoscaleMinimumCapacity; set => ParametersBody.AutoscaleMinimumCapacity = value; }

        /// <summary>
        /// Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"backendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool) })]
        [global::System.Management.Automation.Alias("BackendAddressPools")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] BackendAddressPool { get => ParametersBody.BackendAddressPool ?? null /* arrayOf */; set => ParametersBody.BackendAddressPool = value; }

        /// <summary>
        /// Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"backendHttpSettingsCollection",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings) })]
        [global::System.Management.Automation.Alias("BackendHttpSettingsCollection")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings[] BackendHttpSetting { get => ParametersBody.BackendHttpSetting ?? null /* arrayOf */; set => ParametersBody.BackendHttpSetting = value; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Whether allow WAF to check request Body.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether allow WAF to check request Body.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether allow WAF to check request Body.",
        SerializedName = @"requestBodyCheck",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter CheckWafRequestBody { get => ParametersBody.CheckWafRequestBody ?? default(global::System.Management.Automation.SwitchParameter); set => ParametersBody.CheckWafRequestBody = value; }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Network Client => Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.ClientAPI;

        /// <summary>Custom error configurations of the application gateway resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Custom error configurations of the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom error configurations of the application gateway resource.",
        SerializedName = @"customErrorConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError) })]
        [global::System.Management.Automation.Alias("CustomErrorConfiguration")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError[] CustomError { get => ParametersBody.CustomError ?? null /* arrayOf */; set => ParametersBody.CustomError = value; }

        /// <summary>
        /// The credentials, account, tenant, and subscription used for communication with Azure
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Whether FIPS is enabled on the application gateway resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether FIPS is enabled on the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether FIPS is enabled on the application gateway resource.",
        SerializedName = @"enableFips",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableFips { get => ParametersBody.EnableFips ?? default(global::System.Management.Automation.SwitchParameter); set => ParametersBody.EnableFips = value; }

        /// <summary>Whether HTTP2 is enabled on the application gateway resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether HTTP2 is enabled on the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether HTTP2 is enabled on the application gateway resource.",
        SerializedName = @"enableHttp2",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableHttp2 { get => ParametersBody.EnableHttp2 ?? default(global::System.Management.Automation.SwitchParameter); set => ParametersBody.EnableHttp2 = value; }

        /// <summary>Whether the web application firewall is enabled or not.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether the web application firewall is enabled or not.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the web application firewall is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableWaf { get => ParametersBody.EnableWaf; set => ParametersBody.EnableWaf = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A unique read-only string that changes whenever the resource is updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
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
        public string FirewallPolicyId { get => ParametersBody.FirewallPolicyId ?? null; set => ParametersBody.FirewallPolicyId = value; }

        /// <summary>
        /// Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendIPConfiguration) })]
        [global::System.Management.Automation.Alias("FrontendIPConfigurations")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendIPConfiguration[] FrontendIPConfiguration { get => ParametersBody.FrontendIPConfiguration ?? null /* arrayOf */; set => ParametersBody.FrontendIPConfiguration = value; }

        /// <summary>
        /// Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"frontendPorts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendPort) })]
        [global::System.Management.Automation.Alias("FrontendPorts")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendPort[] FrontendPort { get => ParametersBody.FrontendPort ?? null /* arrayOf */; set => ParametersBody.FrontendPort = value; }

        /// <summary>
        /// Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"gatewayIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayIPConfiguration) })]
        [global::System.Management.Automation.Alias("GatewayIPConfigurations")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayIPConfiguration[] GatewayIPConfiguration { get => ParametersBody.GatewayIPConfiguration ?? null /* arrayOf */; set => ParametersBody.GatewayIPConfiguration = value; }

        /// <summary>
        /// Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"httpListeners",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener) })]
        [global::System.Management.Automation.Alias("HttpListeners")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener[] HttpListener { get => ParametersBody.HttpListener ?? null /* arrayOf */; set => ParametersBody.HttpListener = value; }

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

        /// <summary>
        /// The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created
        /// identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType IdentityType { get => ParametersBody.IdentityType ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType)""); set => ParametersBody.IdentityType = value; }

        /// <summary>Backing field for <see cref="InputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity _inputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity InputObject { get => this._inputObject; set => this._inputObject = value; }

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

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>Backing field for <see cref="ParametersBody" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway _parametersBody= new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGateway();

        /// <summary>Application gateway resource</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway ParametersBody { get => this._parametersBody; set => this._parametersBody = value; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>Probes of the application gateway resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Probes of the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Probes of the application gateway resource.",
        SerializedName = @"probes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbe) })]
        [global::System.Management.Automation.Alias("Probes")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbe[] Probe { get => ParametersBody.Probe ?? null /* arrayOf */; set => ParametersBody.Probe = value; }

        /// <summary>
        /// Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        public string ProvisioningState { get => ParametersBody.ProvisioningState ?? null; set => ParametersBody.ProvisioningState = value; }

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
        /// Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"redirectConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration) })]
        [global::System.Management.Automation.Alias("RedirectConfigurations")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration[] RedirectConfiguration { get => ParametersBody.RedirectConfiguration ?? null /* arrayOf */; set => ParametersBody.RedirectConfiguration = value; }

        /// <summary>Request routing rules of the application gateway resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Request routing rules of the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request routing rules of the application gateway resource.",
        SerializedName = @"requestRoutingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule) })]
        [global::System.Management.Automation.Alias("RequestRoutingRules")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule[] RequestRoutingRule { get => ParametersBody.RequestRoutingRule ?? null /* arrayOf */; set => ParametersBody.RequestRoutingRule = value; }

        /// <summary>Resource GUID property of the application gateway resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource GUID property of the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource GUID property of the application gateway resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        public string ResourceGuid { get => ParametersBody.ResourceGuid ?? null; set => ParametersBody.ResourceGuid = value; }

        /// <summary>Rewrite rules for the application gateway resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Rewrite rules for the application gateway resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rewrite rules for the application gateway resource.",
        SerializedName = @"rewriteRuleSets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet[] RewriteRuleSet { get => ParametersBody.RewriteRuleSet ?? null /* arrayOf */; set => ParametersBody.RewriteRuleSet = value; }

        /// <summary>Capacity (instance count) of an application gateway.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Capacity (instance count) of an application gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capacity (instance count) of an application gateway.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        public int SkuCapacity { get => ParametersBody.SkuCapacity ?? default(int); set => ParametersBody.SkuCapacity = value; }

        /// <summary>Name of an application gateway SKU.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Name of an application gateway SKU.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of an application gateway SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName SkuName { get => ParametersBody.SkuName ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName)""); set => ParametersBody.SkuName = value; }

        /// <summary>Tier of an application gateway.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Tier of an application gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of an application gateway.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier SkuTier { get => ParametersBody.SkuTier ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier)""); set => ParametersBody.SkuTier = value; }

        /// <summary>
        /// SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"sslCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate) })]
        [global::System.Management.Automation.Alias("SslCertificates")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate[] SslCertificate { get => ParametersBody.SslCertificate ?? null /* arrayOf */; set => ParametersBody.SslCertificate = value; }

        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Ssl cipher suites to be enabled in the specified order to application gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl cipher suites to be enabled in the specified order to application gateway.",
        SerializedName = @"cipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] SslCipherSuite { get => ParametersBody.SslCipherSuite ?? null /* arrayOf */; set => ParametersBody.SslCipherSuite = value; }

        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Ssl protocols to be disabled on application gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl protocols to be disabled on application gateway.",
        SerializedName = @"disabledSslProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] SslDisabledProtocol { get => ParametersBody.SslDisabledProtocol ?? null /* arrayOf */; set => ParametersBody.SslDisabledProtocol = value; }

        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Minimum version of Ssl protocol to be supported on application gateway.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum version of Ssl protocol to be supported on application gateway.",
        SerializedName = @"minProtocolVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol SslMinimumProtocolVersion { get => ParametersBody.SslMinimumProtocolVersion ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol)""); set => ParametersBody.SslMinimumProtocolVersion = value; }

        /// <summary>Name of Ssl predefined policy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Name of Ssl predefined policy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Ssl predefined policy",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName SslPolicyName { get => ParametersBody.SslPolicyName ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName)""); set => ParametersBody.SslPolicyName = value; }

        /// <summary>Type of Ssl Policy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Type of Ssl Policy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of Ssl Policy",
        SerializedName = @"policyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType SslPolicyType { get => ParametersBody.SslPolicyType ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType)""); set => ParametersBody.SslPolicyType = value; }

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
        /// Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"trustedRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate[] TrustedRootCertificate { get => ParametersBody.TrustedRootCertificate ?? null /* arrayOf */; set => ParametersBody.TrustedRootCertificate = value; }

        /// <summary>
        /// URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).",
        SerializedName = @"urlPathMaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap) })]
        [global::System.Management.Automation.Alias("UrlPathMaps")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap[] UrlPathMap { get => ParametersBody.UrlPathMap ?? null /* arrayOf */; set => ParametersBody.UrlPathMap = value; }

        /// <summary>
        /// The list of user identities associated with resource. The user identity dictionary key references will be ARM resource
        /// ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The list of user identities associated with resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user identities associated with resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IManagedServiceIdentityUserAssignedIdentities) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IManagedServiceIdentityUserAssignedIdentities UserAssignedIdentity { get => ParametersBody.UserAssignedIdentity ?? null /* object */; set => ParametersBody.UserAssignedIdentity = value; }

        /// <summary>The disabled rule groups.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The disabled rule groups.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disabled rule groups.",
        SerializedName = @"disabledRuleGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup[] WafDisabledRuleGroup { get => ParametersBody.WafDisabledRuleGroup ?? null /* arrayOf */; set => ParametersBody.WafDisabledRuleGroup = value; }

        /// <summary>The exclusion list.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The exclusion list.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exclusion list.",
        SerializedName = @"exclusions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[] WafExclusion { get => ParametersBody.WafExclusion ?? null /* arrayOf */; set => ParametersBody.WafExclusion = value; }

        /// <summary>Maximum file upload size in Mb for WAF.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Maximum file upload size in Mb for WAF.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum file upload size in Mb for WAF.",
        SerializedName = @"fileUploadLimitInMb",
        PossibleTypes = new [] { typeof(int) })]
        public int WafFileUploadLimitInMb { get => ParametersBody.WafFileUploadLimitInMb ?? default(int); set => ParametersBody.WafFileUploadLimitInMb = value; }

        /// <summary>Web application firewall mode.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Web application firewall mode.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Web application firewall mode.",
        SerializedName = @"firewallMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode WafFirewallMode { get => ParametersBody.WafFirewallMode; set => ParametersBody.WafFirewallMode = value; }

        /// <summary>Maximum request body size for WAF.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Maximum request body size for WAF.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum request body size for WAF.",
        SerializedName = @"maxRequestBodySize",
        PossibleTypes = new [] { typeof(int) })]
        public int WafMaximumRequestBodySize { get => ParametersBody.WafMaximumRequestBodySize ?? default(int); set => ParametersBody.WafMaximumRequestBodySize = value; }

        /// <summary>Maximum request body size in Kb for WAF.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Maximum request body size in Kb for WAF.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum request body size in Kb for WAF.",
        SerializedName = @"maxRequestBodySizeInKb",
        PossibleTypes = new [] { typeof(int) })]
        public int WafMaximumRequestBodySizeInKb { get => ParametersBody.WafMaximumRequestBodySizeInKb ?? default(int); set => ParametersBody.WafMaximumRequestBodySizeInKb = value; }

        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The type of the web application firewall rule set. Possible values are: 'OWASP'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the web application firewall rule set. Possible values are: 'OWASP'.",
        SerializedName = @"ruleSetType",
        PossibleTypes = new [] { typeof(string) })]
        public string WafRuleSetType { get => ParametersBody.WafRuleSetType ?? null; set => ParametersBody.WafRuleSetType = value; }

        /// <summary>The version of the rule set type.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The version of the rule set type.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the rule set type.",
        SerializedName = @"ruleSetVersion",
        PossibleTypes = new [] { typeof(string) })]
        public string WafRuleSetVersion { get => ParametersBody.WafRuleSetVersion ?? null; set => ParametersBody.WafRuleSetVersion = value; }

        /// <summary>A list of availability zones denoting where the resource needs to come from.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A list of availability zones denoting where the resource needs to come from.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of availability zones denoting where the resource needs to come from.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        public string[] Zone { get => ParametersBody.Zone ?? null /* arrayOf */; set => ParametersBody.Zone = value; }

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway"
        /// /> from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

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
        /// <returns>a duplicate instance of NewAzApplicationGateway_CreateViaIdentityExpanded</returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.NewAzApplicationGateway_CreateViaIdentityExpanded Clone()
        {
            var clone = new NewAzApplicationGateway_CreateViaIdentityExpanded();
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

        /// <summary>
        /// Intializes a new instance of the <see cref="NewAzApplicationGateway_CreateViaIdentityExpanded" /> cmdlet class.
        /// </summary>
        public NewAzApplicationGateway_CreateViaIdentityExpanded()
        {

        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'ApplicationGatewaysCreateOrUpdate' operation"))
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
                    if (InputObject?.Id != null)
                    {
                        await this.Client.ApplicationGatewaysCreateOrUpdateViaIdentity(InputObject.Id, ParametersBody, onOk, this, Pipeline);
                    }
                    else
                    {
                        // try to call with PATH parameters from Input Object
                        if (null == InputObject.ResourceGroupName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.ResourceGroupName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.ApplicationGatewayName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.ApplicationGatewayName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.SubscriptionId)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.SubscriptionId"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        await this.Client.ApplicationGatewaysCreateOrUpdate(InputObject.ResourceGroupName ?? null, InputObject.ApplicationGatewayName ?? null, InputObject.SubscriptionId ?? null, ParametersBody, onOk, this, Pipeline);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  body=ParametersBody})
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

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway"
        /// /> from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway
                WriteObject((await response));
            }
        }
    }
}