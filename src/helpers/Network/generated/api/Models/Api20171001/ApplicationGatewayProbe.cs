namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Probe of the application gateway.</summary>
    public partial class ApplicationGatewayProbe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Host name to send the probe to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Host = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from
        /// 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Interval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Interval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Interval = value; }

        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string MatchBody { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MatchBody; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MatchBody = value; }

        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] MatchStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MatchStatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MatchStatusCode = value; }

        /// <summary>Internal Acessors for Match</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeHealthResponseMatch Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeInternal.Match { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Match; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Match = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayProbePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Minimum number of servers that are always marked healthy. Default value is 0.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? MinServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MinServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).MinServer = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Path { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Path = value; }

        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? PickHostNameFromBackendHttpSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).PickHostNameFromBackendHttpSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).PickHostNameFromBackendHttpSetting = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormat _property;

        /// <summary>Properties of probe of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayProbePropertiesFormat()); set => this._property = value; }

        /// <summary>Protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>
        /// the probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? Timeout { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Timeout; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).Timeout = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold.
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? UnhealthyThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).UnhealthyThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormatInternal)Property).UnhealthyThreshold = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayProbe" /> instance.</summary>
        public ApplicationGatewayProbe()
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
    /// Probe of the application gateway.
    public partial interface IApplicationGatewayProbe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Host name to send the probe to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host name to send the probe to.",
        SerializedName = @"host",
        PossibleTypes = new [] { typeof(string) })]
        string Host { get; set; }
        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from
        /// 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from 1 second to 86400 seconds.",
        SerializedName = @"interval",
        PossibleTypes = new [] { typeof(int) })]
        int? Interval { get; set; }
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Body that must be contained in the health response. Default value is empty.",
        SerializedName = @"body",
        PossibleTypes = new [] { typeof(string) })]
        string MatchBody { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.",
        SerializedName = @"statusCodes",
        PossibleTypes = new [] { typeof(string) })]
        string[] MatchStatusCode { get; set; }
        /// <summary>Minimum number of servers that are always marked healthy. Default value is 0.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of servers that are always marked healthy. Default value is 0.",
        SerializedName = @"minServers",
        PossibleTypes = new [] { typeof(int) })]
        int? MinServer { get; set; }
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
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the host header should be picked from the backend http settings. Default value is false.",
        SerializedName = @"pickHostNameFromBackendHttpSettings",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PickHostNameFromBackendHttpSetting { get; set; }
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
        /// the probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.",
        SerializedName = @"timeout",
        PossibleTypes = new [] { typeof(int) })]
        int? Timeout { get; set; }
        /// <summary>Type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold.
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold. Acceptable values are from 1 second to 20.",
        SerializedName = @"unhealthyThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? UnhealthyThreshold { get; set; }

    }
    /// Probe of the application gateway.
    internal partial interface IApplicationGatewayProbeInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Host name to send the probe to.</summary>
        string Host { get; set; }
        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from
        /// 1 second to 86400 seconds.
        /// </summary>
        int? Interval { get; set; }
        /// <summary>Criterion for classifying a healthy probe response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeHealthResponseMatch Match { get; set; }
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        string MatchBody { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        string[] MatchStatusCode { get; set; }
        /// <summary>Minimum number of servers that are always marked healthy. Default value is 0.</summary>
        int? MinServer { get; set; }
        /// <summary>
        /// Name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        bool? PickHostNameFromBackendHttpSetting { get; set; }
        /// <summary>Properties of probe of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbePropertiesFormat Property { get; set; }
        /// <summary>Protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// the probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        int? Timeout { get; set; }
        /// <summary>Type of the resource.</summary>
        string Type { get; set; }
        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold.
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        int? UnhealthyThreshold { get; set; }

    }
}