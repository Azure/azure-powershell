namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Backend address pool settings of an application gateway.</summary>
    public partial class ApplicationGatewayBackendHttpSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>Cookie name to use for the affinity cookie.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string AffinityCookieName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).AffinityCookieName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).AffinityCookieName = value; }

        /// <summary>Array of references to application gateway authentication certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] AuthenticationCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).AuthenticationCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).AuthenticationCertificate = value; }

        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int ConnectionDrainingDrainTimeoutInSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDrainingDrainTimeoutInSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDrainingDrainTimeoutInSec = value; }

        /// <summary>Whether connection draining is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool ConnectionDrainingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDrainingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDrainingEnabled = value; }

        /// <summary>Cookie based affinity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCookieBasedAffinity? CookieBasedAffinity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).CookieBasedAffinity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).CookieBasedAffinity = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Host header to be sent to the backend servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).HostName = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for ConnectionDraining</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal.ConnectionDraining { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDraining; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ConnectionDraining = value; }

        /// <summary>Internal Acessors for Probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal.Probe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Probe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Probe = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettingsPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Path { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Path = value; }

        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? PickHostNameFromBackendAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).PickHostNameFromBackendAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).PickHostNameFromBackendAddress = value; }

        /// <summary>Port</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Port { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Port = value; }

        /// <summary>Whether the probe is enabled. Default value is false.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? ProbeEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProbeEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProbeEnabled = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProbeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProbeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProbeId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat _property;

        /// <summary>Properties of Backend address pool settings of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendHttpSettingsPropertiesFormat()); set => this._property = value; }

        /// <summary>Protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>
        /// Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout.
        /// Acceptable values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? RequestTimeout { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).RequestTimeout; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormatInternal)Property).RequestTimeout = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayBackendHttpSettings" /> instance.</summary>
        public ApplicationGatewayBackendHttpSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// Backend address pool settings of an application gateway.
    public partial interface IApplicationGatewayBackendHttpSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] AuthenticationCertificate { get; set; }
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Host header to be sent to the backend servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host header to be sent to the backend servers.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get; set; }
        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// <summary>Port</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Port",
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
        /// <summary>Protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protocol.",
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
        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Backend address pool settings of an application gateway.
    internal partial interface IApplicationGatewayBackendHttpSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>Cookie name to use for the affinity cookie.</summary>
        string AffinityCookieName { get; set; }
        /// <summary>Array of references to application gateway authentication certificates.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] AuthenticationCertificate { get; set; }
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Host header to be sent to the backend servers.</summary>
        string HostName { get; set; }
        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Whether to pick host header should be picked from the host name of the backend server. Default value is false.
        /// </summary>
        bool? PickHostNameFromBackendAddress { get; set; }
        /// <summary>Port</summary>
        int? Port { get; set; }
        /// <summary>Probe resource of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Probe { get; set; }
        /// <summary>Whether the probe is enabled. Default value is false.</summary>
        bool? ProbeEnabled { get; set; }
        /// <summary>Resource ID.</summary>
        string ProbeId { get; set; }
        /// <summary>Properties of Backend address pool settings of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendHttpSettingsPropertiesFormat Property { get; set; }
        /// <summary>Protocol.</summary>
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
        /// <summary>Type of the resource.</summary>
        string Type { get; set; }

    }
}