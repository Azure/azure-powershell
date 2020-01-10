namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Backend address pool settings of an application gateway.</summary>
    public partial class ApplicationGatewayBackendHttpSettingsPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettingsPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AffinityCookieName" /> property.</summary>
        private string _affinityCookieName;

        /// <summary>Cookie name to use for the affinity cookie.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AffinityCookieName { get => this._affinityCookieName; set => this._affinityCookieName = value; }

        /// <summary>Backing field for <see cref="AuthenticationCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _authenticationCertificate;

        /// <summary>Array of references to application gateway authentication certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] AuthenticationCertificate { get => this._authenticationCertificate; set => this._authenticationCertificate = value; }

        /// <summary>Backing field for <see cref="ConnectionDraining" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining _connectionDraining;

        /// <summary>Connection draining of the backend http settings resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining ConnectionDraining { get => (this._connectionDraining = this._connectionDraining ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayConnectionDraining()); set => this._connectionDraining = value; }

        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int ConnectionDrainingDrainTimeoutInSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDrainingInternal)ConnectionDraining).DrainTimeoutInSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDrainingInternal)ConnectionDraining).DrainTimeoutInSec = value; }

        /// <summary>Whether connection draining is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool ConnectionDrainingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDrainingInternal)ConnectionDraining).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDrainingInternal)ConnectionDraining).Enabled = value; }

        /// <summary>Backing field for <see cref="CookieBasedAffinity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity? _cookieBasedAffinity;

        /// <summary>Cookie based affinity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity? CookieBasedAffinity { get => this._cookieBasedAffinity; set => this._cookieBasedAffinity = value; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>Host header to be sent to the backend servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; set => this._hostName = value; }

        /// <summary>Internal Acessors for ConnectionDraining</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal.ConnectionDraining { get => (this._connectionDraining = this._connectionDraining ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayConnectionDraining()); set { {_connectionDraining = value;} } }

        /// <summary>Internal Acessors for Probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal.Probe { get => (this._probe = this._probe ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_probe = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="PickHostNameFromBackendAddress" /> property.</summary>
        private bool? _pickHostNameFromBackendAddress;

        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? PickHostNameFromBackendAddress { get => this._pickHostNameFromBackendAddress; set => this._pickHostNameFromBackendAddress = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>The destination port on the backend.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Probe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _probe;

        /// <summary>Probe resource of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Probe { get => (this._probe = this._probe ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._probe = value; }

        /// <summary>Backing field for <see cref="ProbeEnabled" /> property.</summary>
        private bool? _probeEnabled;

        /// <summary>Whether the probe is enabled. Default value is false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? ProbeEnabled { get => this._probeEnabled; set => this._probeEnabled = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProbeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Probe).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Probe).Id = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? _protocol;

        /// <summary>The protocol used to communicate with the backend.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RequestTimeout" /> property.</summary>
        private int? _requestTimeout;

        /// <summary>
        /// Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout.
        /// Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? RequestTimeout { get => this._requestTimeout; set => this._requestTimeout = value; }

        /// <summary>Backing field for <see cref="TrustedRootCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _trustedRootCertificate;

        /// <summary>Array of references to application gateway trusted root certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] TrustedRootCertificate { get => this._trustedRootCertificate; set => this._trustedRootCertificate = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayBackendHttpSettingsPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayBackendHttpSettingsPropertiesFormat()
        {

        }
    }
    /// Properties of Backend address pool settings of an application gateway.
    public partial interface IApplicationGatewayBackendHttpSettingsPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Cookie name to use for the affinity cookie.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Cookie name to use for the affinity cookie.",
        SerializedName = @"affinityCookieName",
        PossibleTypes = new [] { typeof(string) })]
        string AffinityCookieName { get; set; }
        /// <summary>Array of references to application gateway authentication certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of references to application gateway authentication certificates.",
        SerializedName = @"authenticationCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] AuthenticationCertificate { get; set; }
        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.",
        SerializedName = @"drainTimeoutInSec",
        PossibleTypes = new [] { typeof(int) })]
        int ConnectionDrainingDrainTimeoutInSec { get; set; }
        /// <summary>Whether connection draining is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether connection draining is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool ConnectionDrainingEnabled { get; set; }
        /// <summary>Cookie based affinity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Cookie based affinity.",
        SerializedName = @"cookieBasedAffinity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity? CookieBasedAffinity { get; set; }
        /// <summary>Host header to be sent to the backend servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host header to be sent to the backend servers.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get; set; }
        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to pick host header should be picked from the host name of the backend server. Default value is false.",
        SerializedName = @"pickHostNameFromBackendAddress",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PickHostNameFromBackendAddress { get; set; }
        /// <summary>The destination port on the backend.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination port on the backend.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>Whether the probe is enabled. Default value is false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the probe is enabled. Default value is false.",
        SerializedName = @"probeEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ProbeEnabled { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ProbeId { get; set; }
        /// <summary>The protocol used to communicate with the backend.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol used to communicate with the backend.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout.
        /// Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout. Acceptable values are from 1 second to 86400 seconds.",
        SerializedName = @"requestTimeout",
        PossibleTypes = new [] { typeof(int) })]
        int? RequestTimeout { get; set; }
        /// <summary>Array of references to application gateway trusted root certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of references to application gateway trusted root certificates.",
        SerializedName = @"trustedRootCertificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] TrustedRootCertificate { get; set; }

    }
    /// Properties of Backend address pool settings of an application gateway.
    internal partial interface IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal

    {
        /// <summary>Cookie name to use for the affinity cookie.</summary>
        string AffinityCookieName { get; set; }
        /// <summary>Array of references to application gateway authentication certificates.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] AuthenticationCertificate { get; set; }
        /// <summary>Connection draining of the backend http settings resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining ConnectionDraining { get; set; }
        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        int ConnectionDrainingDrainTimeoutInSec { get; set; }
        /// <summary>Whether connection draining is enabled or not.</summary>
        bool ConnectionDrainingEnabled { get; set; }
        /// <summary>Cookie based affinity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity? CookieBasedAffinity { get; set; }
        /// <summary>Host header to be sent to the backend servers.</summary>
        string HostName { get; set; }
        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        bool? PickHostNameFromBackendAddress { get; set; }
        /// <summary>The destination port on the backend.</summary>
        int? Port { get; set; }
        /// <summary>Probe resource of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Probe { get; set; }
        /// <summary>Whether the probe is enabled. Default value is false.</summary>
        bool? ProbeEnabled { get; set; }
        /// <summary>Resource ID.</summary>
        string ProbeId { get; set; }
        /// <summary>The protocol used to communicate with the backend.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout.
        /// Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        int? RequestTimeout { get; set; }
        /// <summary>Array of references to application gateway trusted root certificates.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] TrustedRootCertificate { get; set; }

    }
}