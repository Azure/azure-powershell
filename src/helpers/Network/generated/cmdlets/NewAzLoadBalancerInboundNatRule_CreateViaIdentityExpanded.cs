namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Creates or updates a load balancer inbound nat rule.</summary>
    /// <remarks>
    /// [OpenAPI] InboundNatRules_CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/inboundNatRules/{inboundNatRuleName}"
    /// [METADATA]
    /// path: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/inboundNatRules/{inboundNatRuleName}'
    /// apiVersions:
    /// - '2019-02-01'
    /// filename:
    /// - 'mem:///978?oai3.shaken.json'
    /// originalLocations:
    /// - >-
    /// https://github.com/Azure/azure-rest-api-specs/blob/resource-hybrid-profile-fix/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/loadBalancer.json#/paths/~1subscriptions~1{subscriptionId}~1resourceGroups~1{resourceGroupName}~1providers~1Microsoft.Network~1loadBalancers~1{loadBalancerName}~1inboundNatRules~1{inboundNatRuleName}
    /// profiles:
    /// latest-2019-04-30: '2019-02-01'
    /// [DETAILS]
    /// verb: New
    /// subjectPrefix:
    /// subject: LoadBalancerInboundNatRule
    /// variant: CreateViaIdentityExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.New, @"AzLoadBalancerInboundNatRule_CreateViaIdentityExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Description(@"Creates or updates a load balancer inbound nat rule.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Profile("latest-2019-04-30")]
    public partial class NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded : global::System.Management.Automation.PSCmdlet,
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

        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The reference of ApplicationGatewayBackendAddressPool resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of ApplicationGatewayBackendAddressPool resource.",
        SerializedName = @"applicationGatewayBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get => InboundNatRuleParametersBody.ApplicationGatewayBackendAddressPool ?? null /* arrayOf */; set => InboundNatRuleParametersBody.ApplicationGatewayBackendAddressPool = value; }

        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Application security groups in which the IP configuration is included.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application security groups in which the IP configuration is included.",
        SerializedName = @"applicationSecurityGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get => InboundNatRuleParametersBody.ApplicationSecurityGroup ?? null /* arrayOf */; set => InboundNatRuleParametersBody.ApplicationSecurityGroup = value; }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A unique read-only string that changes whenever the resource is updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        public string BackendIPConfigurationEtag { get => InboundNatRuleParametersBody.BackendIPConfigurationEtag ?? null; set => InboundNatRuleParametersBody.BackendIPConfigurationEtag = value; }

        /// <summary>Resource ID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource ID.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        public string BackendIPConfigurationId { get => InboundNatRuleParametersBody.BackendIPConfigurationId ?? null; set => InboundNatRuleParametersBody.BackendIPConfigurationId = value; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The name of the resource that is unique within a resource group. This name can be used to access the resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string BackendIPConfigurationName { get => InboundNatRuleParametersBody.BackendIPConfigurationName ?? null; set => InboundNatRuleParametersBody.BackendIPConfigurationName = value; }

        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        public string BackendIPConfigurationProvisioningState { get => InboundNatRuleParametersBody.BackendIPConfigurationPropertiesProvisioningState ?? null; set => InboundNatRuleParametersBody.BackendIPConfigurationPropertiesProvisioningState = value; }

        /// <summary>
        /// The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The port used for the internal endpoint. Acceptable values range from 1 to 65535.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port used for the internal endpoint. Acceptable values range from 1 to 65535.",
        SerializedName = @"backendPort",
        PossibleTypes = new [] { typeof(int) })]
        public int BackendPort { get => InboundNatRuleParametersBody.BackendPort ?? default(int); set => InboundNatRuleParametersBody.BackendPort = value; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Network Client => Microsoft.Azure.PowerShell.Cmdlets.Network.Module.Instance.ClientAPI;

        /// <summary>
        /// The credentials, account, tenant, and subscription used for communication with Azure
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.",
        SerializedName = @"enableFloatingIP",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableFloatingIP { get => InboundNatRuleParametersBody.EnableFloatingIP ?? default(global::System.Management.Automation.SwitchParameter); set => InboundNatRuleParametersBody.EnableFloatingIP = value; }

        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.",
        SerializedName = @"enableTcpReset",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter EnableTcpReset { get => InboundNatRuleParametersBody.EnableTcpReset ?? default(global::System.Management.Automation.SwitchParameter); set => InboundNatRuleParametersBody.EnableTcpReset = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A unique read-only string that changes whenever the resource is updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        public string Etag { get => InboundNatRuleParametersBody.Etag ?? null; set => InboundNatRuleParametersBody.Etag = value; }

        /// <summary>Resource ID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource ID.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        public string FrontendIPConfigurationId { get => InboundNatRuleParametersBody.FrontendIPConfigurationId ?? null; set => InboundNatRuleParametersBody.FrontendIPConfigurationId = value; }

        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// range from 1 to 65534.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.",
        SerializedName = @"frontendPort",
        PossibleTypes = new [] { typeof(int) })]
        public int FrontendPort { get => InboundNatRuleParametersBody.FrontendPort ?? default(int); set => InboundNatRuleParametersBody.FrontendPort = value; }

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
        public string Id { get => InboundNatRuleParametersBody.Id ?? null; set => InboundNatRuleParametersBody.Id = value; }

        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        public int IdleTimeoutInMinutes { get => InboundNatRuleParametersBody.IdleTimeoutInMinutes ?? default(int); set => InboundNatRuleParametersBody.IdleTimeoutInMinutes = value; }

        /// <summary>Backing field for <see cref="InboundNatRuleParametersBody" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule _inboundNatRuleParametersBody= new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatRule();

        /// <summary>Inbound NAT rule of the load balancer.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule InboundNatRuleParametersBody { get => this._inboundNatRuleParametersBody; set => this._inboundNatRuleParametersBody = value; }

        /// <summary>Backing field for <see cref="InputObject" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity _inputObject;

        /// <summary>Identity Parameter</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Identity Parameter", ValueFromPipeline = true)]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Path)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity InputObject { get => this._inputObject; set => this._inputObject = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The reference of LoadBalancerBackendAddressPool resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of LoadBalancerBackendAddressPool resource.",
        SerializedName = @"loadBalancerBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get => InboundNatRuleParametersBody.LoadBalancerBackendAddressPool ?? null /* arrayOf */; set => InboundNatRuleParametersBody.LoadBalancerBackendAddressPool = value; }

        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A list of references of LoadBalancerInboundNatRules.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of references of LoadBalancerInboundNatRules.",
        SerializedName = @"loadBalancerInboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get => InboundNatRuleParametersBody.LoadBalancerInboundNatRule ?? null /* arrayOf */; set => InboundNatRuleParametersBody.LoadBalancerInboundNatRule = value; }

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

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets whether this is a primary customer address on the network interface.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether this is a primary customer address on the network interface.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter Primary { get => InboundNatRuleParametersBody.Primary ?? default(global::System.Management.Automation.SwitchParameter); set => InboundNatRuleParametersBody.Primary = value; }

        /// <summary>Private IP address of the IP configuration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Private IP address of the IP configuration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        public string PrivateIPAddress { get => InboundNatRuleParametersBody.PrivateIPAddress ?? null; set => InboundNatRuleParametersBody.PrivateIPAddress = value; }

        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.",
        SerializedName = @"privateIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion PrivateIPAddressVersion { get => InboundNatRuleParametersBody.PrivateIPAddressVersion ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion)""); set => InboundNatRuleParametersBody.PrivateIPAddressVersion = value; }

        /// <summary>The private IP address allocation method.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The private IP address allocation method.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address allocation method.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod PrivateIPAllocationMethod { get => InboundNatRuleParametersBody.PrivateIPAllocationMethod ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod)""); set => InboundNatRuleParametersBody.PrivateIPAllocationMethod = value; }

        /// <summary>The reference to the transport protocol used by the load balancing rule.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The reference to the transport protocol used by the load balancing rule.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to the transport protocol used by the load balancing rule.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) })]
        [global::System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol))]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get => InboundNatRuleParametersBody.Protocol ?? ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol)""); set => InboundNatRuleParametersBody.Protocol = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        public string ProvisioningState { get => InboundNatRuleParametersBody.ProvisioningState ?? null; set => InboundNatRuleParametersBody.ProvisioningState = value; }

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

        /// <summary>Public IP address bound to the IP configuration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Public IP address bound to the IP configuration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public IP address bound to the IP configuration.",
        SerializedName = @"publicIPAddress",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get => InboundNatRuleParametersBody.PublicIPAddress ?? null /* object */; set => InboundNatRuleParametersBody.PublicIPAddress = value; }

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Gets name of the resource that is unique within a resource group. This name can be used to access the resource.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string ResourceName { get => InboundNatRuleParametersBody.Name ?? null; set => InboundNatRuleParametersBody.Name = value; }

        /// <summary>Subnet bound to the IP configuration.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Subnet bound to the IP configuration.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet bound to the IP configuration.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => InboundNatRuleParametersBody.Subnet ?? null /* object */; set => InboundNatRuleParametersBody.Subnet = value; }

        /// <summary>The reference to Virtual Network Taps.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The reference to Virtual Network Taps.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Network.Category(global::Microsoft.Azure.PowerShell.Cmdlets.Network.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to Virtual Network Taps.",
        SerializedName = @"virtualNetworkTaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap) })]
        [global::System.Management.Automation.Alias("VirtualNetworkTap")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get => InboundNatRuleParametersBody.VnetTap ?? null /* arrayOf */; set => InboundNatRuleParametersBody.VnetTap = value; }

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule"
        /// /> from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

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
        /// <returns>
        /// a duplicate instance of NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded Clone()
        {
            var clone = new NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded();
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
            clone.InboundNatRuleParametersBody = this.InboundNatRuleParametersBody;
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
        /// Intializes a new instance of the <see cref="NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded" /> cmdlet class.
        /// </summary>
        public NewAzLoadBalancerInboundNatRule_CreateViaIdentityExpanded()
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
                if (ShouldProcess($"Call remote 'InboundNatRulesCreateOrUpdate' operation"))
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
                        await this.Client.InboundNatRulesCreateOrUpdateViaIdentity(InputObject.Id, InboundNatRuleParametersBody, onOk, this, Pipeline);
                    }
                    else
                    {
                        // try to call with PATH parameters from Input Object
                        if (null == InputObject.ResourceGroupName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.ResourceGroupName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.LoadBalancerName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.LoadBalancerName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.InboundNatRuleName)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.InboundNatRuleName"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        if (null == InputObject.SubscriptionId)
                        {
                            ThrowTerminatingError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception("InputObject has null value for InputObject.SubscriptionId"),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, InputObject) );
                        }
                        await this.Client.InboundNatRulesCreateOrUpdate(InputObject.ResourceGroupName ?? null, InputObject.LoadBalancerName ?? null, InputObject.InboundNatRuleName ?? null, InputObject.SubscriptionId ?? null, InboundNatRuleParametersBody, onOk, this, Pipeline);
                    }
                    await ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  body=InboundNatRuleParametersBody})
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
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule"
        /// /> from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule> response)
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
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule
                WriteObject((await response));
            }
        }
    }
}