namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the application gateway.</summary>
    public partial class ApplicationGatewayPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[] _authenticationCertificate;

        /// <summary>Authentication certificates of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[] AuthenticationCertificate { get => this._authenticationCertificate; set => this._authenticationCertificate = value; }

        /// <summary>Backing field for <see cref="BackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] _backendAddressPool;

        /// <summary>Backend address pool of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] BackendAddressPool { get => this._backendAddressPool; set => this._backendAddressPool = value; }

        /// <summary>Backing field for <see cref="BackendHttpSettingsCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings[] _backendHttpSettingsCollection;

        /// <summary>Backend http settings of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings[] BackendHttpSettingsCollection { get => this._backendHttpSettingsCollection; set => this._backendHttpSettingsCollection = value; }

        /// <summary>Backing field for <see cref="EnableHttp2" /> property.</summary>
        private bool? _enableHttp2;

        /// <summary>Whether HTTP2 is enabled on the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableHttp2 { get => this._enableHttp2; set => this._enableHttp2 = value; }

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[] _frontendIPConfiguration;

        /// <summary>Frontend IP addresses of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[] FrontendIPConfiguration { get => this._frontendIPConfiguration; set => this._frontendIPConfiguration = value; }

        /// <summary>Backing field for <see cref="FrontendPort" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[] _frontendPort;

        /// <summary>Frontend ports of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[] FrontendPort { get => this._frontendPort; set => this._frontendPort = value; }

        /// <summary>Backing field for <see cref="GatewayIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[] _gatewayIPConfiguration;

        /// <summary>Subnets of application the gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[] GatewayIPConfiguration { get => this._gatewayIPConfiguration; set => this._gatewayIPConfiguration = value; }

        /// <summary>Backing field for <see cref="HttpListener" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener[] _httpListener;

        /// <summary>Http listeners of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener[] HttpListener { get => this._httpListener; set => this._httpListener = value; }

        /// <summary>Internal Acessors for OperationalState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormatInternal.OperationalState { get => this._operationalState; set { {_operationalState = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormatInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SslPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormatInternal.SslPolicy { get => (this._sslPolicy = this._sslPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy()); set { {_sslPolicy = value;} } }

        /// <summary>Internal Acessors for WafConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayPropertiesFormatInternal.WafConfiguration { get => (this._wafConfiguration = this._wafConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayWebApplicationFirewallConfiguration()); set { {_wafConfiguration = value;} } }

        /// <summary>Backing field for <see cref="OperationalState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState? _operationalState;

        /// <summary>Operational state of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState? OperationalState { get => this._operationalState; }

        /// <summary>Backing field for <see cref="Probe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[] _probe;

        /// <summary>Probes of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[] Probe { get => this._probe; set => this._probe = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RedirectConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRedirectConfiguration[] _redirectConfiguration;

        /// <summary>Redirect configurations of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRedirectConfiguration[] RedirectConfiguration { get => this._redirectConfiguration; set => this._redirectConfiguration = value; }

        /// <summary>Backing field for <see cref="RequestRoutingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRequestRoutingRule[] _requestRoutingRule;

        /// <summary>Request routing rules of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRequestRoutingRule[] RequestRoutingRule { get => this._requestRoutingRule; set => this._requestRoutingRule = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>Resource GUID property of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySku _sku;

        /// <summary>SKU of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySku()); set => this._sku = value; }

        /// <summary>Capacity (instance count) of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Capacity = value; }

        /// <summary>Name of an application gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Name = value; }

        /// <summary>Tier of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal)Sku).Tier = value; }

        /// <summary>Backing field for <see cref="SslCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslCertificate[] _sslCertificate;

        /// <summary>SSL certificates of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslCertificate[] SslCertificate { get => this._sslCertificate; set => this._sslCertificate = value; }

        /// <summary>Backing field for <see cref="SslPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy _sslPolicy;

        /// <summary>SSL policy of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy SslPolicy { get => (this._sslPolicy = this._sslPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewaySslPolicy()); set => this._sslPolicy = value; }

        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] SslPolicyCipherSuite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).CipherSuite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).CipherSuite = value; }

        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] SslPolicyDisabledSslProtocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).DisabledSslProtocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).DisabledSslProtocol = value; }

        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? SslPolicyMinProtocolVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).MinProtocolVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).MinProtocolVersion = value; }

        /// <summary>Name of Ssl predefined policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? SslPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).PolicyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).PolicyName = value; }

        /// <summary>Type of Ssl Policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? SslPolicyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).PolicyType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal)SslPolicy).PolicyType = value; }

        /// <summary>Backing field for <see cref="UrlPathMap" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMap[] _urlPathMap;

        /// <summary>URL path map of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMap[] UrlPathMap { get => this._urlPathMap; set => this._urlPathMap = value; }

        /// <summary>Backing field for <see cref="WafConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfiguration _wafConfiguration;

        /// <summary>Web application firewall configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfiguration WafConfiguration { get => (this._wafConfiguration = this._wafConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayWebApplicationFirewallConfiguration()); set => this._wafConfiguration = value; }

        /// <summary>The disabled rule groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup[] WafConfigurationDisabledRuleGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).DisabledRuleGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).DisabledRuleGroup = value; }

        /// <summary>Whether the web application firewall is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool WafConfigurationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).Enabled = value; }

        /// <summary>Web application firewall mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode WafConfigurationFirewallMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).FirewallMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).FirewallMode = value; }

        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string WafConfigurationRuleSetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).RuleSetType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).RuleSetType = value; }

        /// <summary>The version of the rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string WafConfigurationRuleSetVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).RuleSetVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfigurationInternal)WafConfiguration).RuleSetVersion = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayPropertiesFormat" /> instance.</summary>
        public ApplicationGatewayPropertiesFormat()
        {

        }
    }
    /// Properties of the application gateway.
    public partial interface IApplicationGatewayPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Authentication certificates of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication certificates of the application gateway resource.",
        SerializedName = @"authenticationCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[] AuthenticationCertificate { get; set; }
        /// <summary>Backend address pool of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backend address pool of the application gateway resource.",
        SerializedName = @"backendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>Backend http settings of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backend http settings of the application gateway resource.",
        SerializedName = @"backendHttpSettingsCollection",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings[] BackendHttpSettingsCollection { get; set; }
        /// <summary>Whether HTTP2 is enabled on the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether HTTP2 is enabled on the application gateway resource.",
        SerializedName = @"enableHttp2",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableHttp2 { get; set; }
        /// <summary>Frontend IP addresses of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Frontend IP addresses of the application gateway resource.",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
        /// <summary>Frontend ports of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Frontend ports of the application gateway resource.",
        SerializedName = @"frontendPorts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[] FrontendPort { get; set; }
        /// <summary>Subnets of application the gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnets of application the gateway resource.",
        SerializedName = @"gatewayIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[] GatewayIPConfiguration { get; set; }
        /// <summary>Http listeners of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Http listeners of the application gateway resource.",
        SerializedName = @"httpListeners",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener[] HttpListener { get; set; }
        /// <summary>Operational state of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operational state of the application gateway resource.",
        SerializedName = @"operationalState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState? OperationalState { get;  }
        /// <summary>Probes of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Probes of the application gateway resource.",
        SerializedName = @"probes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[] Probe { get; set; }
        /// <summary>
        /// Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>Redirect configurations of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Redirect configurations of the application gateway resource.",
        SerializedName = @"redirectConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRedirectConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRedirectConfiguration[] RedirectConfiguration { get; set; }
        /// <summary>Request routing rules of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request routing rules of the application gateway resource.",
        SerializedName = @"requestRoutingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRequestRoutingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRequestRoutingRule[] RequestRoutingRule { get; set; }
        /// <summary>Resource GUID property of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource GUID property of the application gateway resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>Capacity (instance count) of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capacity (instance count) of an application gateway.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>Name of an application gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of an application gateway SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? SkuName { get; set; }
        /// <summary>Tier of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of an application gateway.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? SkuTier { get; set; }
        /// <summary>SSL certificates of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL certificates of the application gateway resource.",
        SerializedName = @"sslCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslCertificate) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslCertificate[] SslCertificate { get; set; }
        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl cipher suites to be enabled in the specified order to application gateway.",
        SerializedName = @"cipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] SslPolicyCipherSuite { get; set; }
        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl protocols to be disabled on application gateway.",
        SerializedName = @"disabledSslProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] SslPolicyDisabledSslProtocol { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum version of Ssl protocol to be supported on application gateway.",
        SerializedName = @"minProtocolVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? SslPolicyMinProtocolVersion { get; set; }
        /// <summary>Name of Ssl predefined policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Ssl predefined policy",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? SslPolicyName { get; set; }
        /// <summary>Type of Ssl Policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of Ssl Policy",
        SerializedName = @"policyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? SslPolicyType { get; set; }
        /// <summary>URL path map of the application gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL path map of the application gateway resource.",
        SerializedName = @"urlPathMaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMap) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMap[] UrlPathMap { get; set; }
        /// <summary>The disabled rule groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disabled rule groups.",
        SerializedName = @"disabledRuleGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup[] WafConfigurationDisabledRuleGroup { get; set; }
        /// <summary>Whether the web application firewall is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the web application firewall is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool WafConfigurationEnabled { get; set; }
        /// <summary>Web application firewall mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Web application firewall mode.",
        SerializedName = @"firewallMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode WafConfigurationFirewallMode { get; set; }
        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the web application firewall rule set. Possible values are: 'OWASP'.",
        SerializedName = @"ruleSetType",
        PossibleTypes = new [] { typeof(string) })]
        string WafConfigurationRuleSetType { get; set; }
        /// <summary>The version of the rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the rule set type.",
        SerializedName = @"ruleSetVersion",
        PossibleTypes = new [] { typeof(string) })]
        string WafConfigurationRuleSetVersion { get; set; }

    }
    /// Properties of the application gateway.
    internal partial interface IApplicationGatewayPropertiesFormatInternal

    {
        /// <summary>Authentication certificates of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[] AuthenticationCertificate { get; set; }
        /// <summary>Backend address pool of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>Backend http settings of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings[] BackendHttpSettingsCollection { get; set; }
        /// <summary>Whether HTTP2 is enabled on the application gateway resource.</summary>
        bool? EnableHttp2 { get; set; }
        /// <summary>Frontend IP addresses of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
        /// <summary>Frontend ports of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[] FrontendPort { get; set; }
        /// <summary>Subnets of application the gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[] GatewayIPConfiguration { get; set; }
        /// <summary>Http listeners of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayHttpListener[] HttpListener { get; set; }
        /// <summary>Operational state of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayOperationalState? OperationalState { get; set; }
        /// <summary>Probes of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[] Probe { get; set; }
        /// <summary>
        /// Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Redirect configurations of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRedirectConfiguration[] RedirectConfiguration { get; set; }
        /// <summary>Request routing rules of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayRequestRoutingRule[] RequestRoutingRule { get; set; }
        /// <summary>Resource GUID property of the application gateway resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>SKU of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySku Sku { get; set; }
        /// <summary>Capacity (instance count) of an application gateway.</summary>
        int? SkuCapacity { get; set; }
        /// <summary>Name of an application gateway SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? SkuName { get; set; }
        /// <summary>Tier of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? SkuTier { get; set; }
        /// <summary>SSL certificates of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslCertificate[] SslCertificate { get; set; }
        /// <summary>SSL policy of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy SslPolicy { get; set; }
        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] SslPolicyCipherSuite { get; set; }
        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] SslPolicyDisabledSslProtocol { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? SslPolicyMinProtocolVersion { get; set; }
        /// <summary>Name of Ssl predefined policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? SslPolicyName { get; set; }
        /// <summary>Type of Ssl Policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? SslPolicyType { get; set; }
        /// <summary>URL path map of the application gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayUrlPathMap[] UrlPathMap { get; set; }
        /// <summary>Web application firewall configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayWebApplicationFirewallConfiguration WafConfiguration { get; set; }
        /// <summary>The disabled rule groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup[] WafConfigurationDisabledRuleGroup { get; set; }
        /// <summary>Whether the web application firewall is enabled or not.</summary>
        bool WafConfigurationEnabled { get; set; }
        /// <summary>Web application firewall mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode WafConfigurationFirewallMode { get; set; }
        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        string WafConfigurationRuleSetType { get; set; }
        /// <summary>The version of the rule set type.</summary>
        string WafConfigurationRuleSetVersion { get; set; }

    }
}