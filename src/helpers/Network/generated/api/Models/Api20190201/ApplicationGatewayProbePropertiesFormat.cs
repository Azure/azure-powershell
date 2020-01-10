namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of probe of an application gateway.</summary>
    public partial class ApplicationGatewayProbePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Host" /> property.</summary>
        private string _host;

        /// <summary>Host name to send the probe to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Host { get => this._host; set => this._host = value; }

        /// <summary>Backing field for <see cref="Interval" /> property.</summary>
        private int? _interval;

        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from
        /// 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Interval { get => this._interval; set => this._interval = value; }

        /// <summary>Backing field for <see cref="Match" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch _match;

        /// <summary>Criterion for classifying a healthy probe response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch Match { get => (this._match = this._match ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatch()); set => this._match = value; }

        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string MatchBody { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatchInternal)Match).Body; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatchInternal)Match).Body = value; }

        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] MatchStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatchInternal)Match).StatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatchInternal)Match).StatusCode = value; }

        /// <summary>Internal Acessors for Match</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormatInternal.Match { get => (this._match = this._match ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatch()); set { {_match = value;} } }

        /// <summary>Backing field for <see cref="MinServer" /> property.</summary>
        private int? _minServer;

        /// <summary>Minimum number of servers that are always marked healthy. Default value is 0.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MinServer { get => this._minServer; set => this._minServer = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="PickHostNameFromBackendHttpSetting" /> property.</summary>
        private bool? _pickHostNameFromBackendHttpSetting;

        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? PickHostNameFromBackendHttpSetting { get => this._pickHostNameFromBackendHttpSetting; set => this._pickHostNameFromBackendHttpSetting = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? _protocol;

        /// <summary>The protocol used for the probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="Timeout" /> property.</summary>
        private int? _timeout;

        /// <summary>
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Timeout { get => this._timeout; set => this._timeout = value; }

        /// <summary>Backing field for <see cref="UnhealthyThreshold" /> property.</summary>
        private int? _unhealthyThreshold;

        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold.
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? UnhealthyThreshold { get => this._unhealthyThreshold; set => this._unhealthyThreshold = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayProbePropertiesFormat" /> instance.</summary>
        public ApplicationGatewayProbePropertiesFormat()
        {

        }
    }
    /// Properties of probe of an application gateway.
    public partial interface IApplicationGatewayProbePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
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
        /// <summary>The protocol used for the probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol used for the probe.",
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
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.",
        SerializedName = @"timeout",
        PossibleTypes = new [] { typeof(int) })]
        int? Timeout { get; set; }
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
    /// Properties of probe of an application gateway.
    internal partial interface IApplicationGatewayProbePropertiesFormatInternal

    {
        /// <summary>Host name to send the probe to.</summary>
        string Host { get; set; }
        /// <summary>
        /// The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from
        /// 1 second to 86400 seconds.
        /// </summary>
        int? Interval { get; set; }
        /// <summary>Criterion for classifying a healthy probe response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch Match { get; set; }
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        string MatchBody { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        string[] MatchStatusCode { get; set; }
        /// <summary>Minimum number of servers that are always marked healthy. Default value is 0.</summary>
        int? MinServer { get; set; }
        /// <summary>
        /// Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Whether the host header should be picked from the backend http settings. Default value is false.
        /// </summary>
        bool? PickHostNameFromBackendHttpSetting { get; set; }
        /// <summary>The protocol used for the probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol? Protocol { get; set; }
        /// <summary>
        /// Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        int? Timeout { get; set; }
        /// <summary>
        /// The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold.
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        int? UnhealthyThreshold { get; set; }

    }
}