namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Details of on demand test probe request</summary>
    public partial class ApplicationGatewayOnDemandProbe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal
    {

        /// <summary>Backing field for <see cref="BackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _backendAddressPool;

        /// <summary>
        /// Reference of backend pool of application gateway to which probe request will be sent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource BackendAddressPool { get => (this._backendAddressPool = this._backendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._backendAddressPool = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)BackendAddressPool).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)BackendAddressPool).Id = value; }

        /// <summary>Backing field for <see cref="BackendHttpSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _backendHttpSetting;

        /// <summary>
        /// Reference of backend http setting of application gateway to be used for test probe.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource BackendHttpSetting { get => (this._backendHttpSetting = this._backendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._backendHttpSetting = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendHttpSettingId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)BackendHttpSetting).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)BackendHttpSetting).Id = value; }

        /// <summary>Backing field for <see cref="Host" /> property.</summary>
        private string _host;

        /// <summary>Host name to send the probe to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Host { get => this._host; set => this._host = value; }

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

        /// <summary>Internal Acessors for BackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal.BackendAddressPool { get => (this._backendAddressPool = this._backendAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_backendAddressPool = value;} } }

        /// <summary>Internal Acessors for BackendHttpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal.BackendHttpSetting { get => (this._backendHttpSetting = this._backendHttpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_backendHttpSetting = value;} } }

        /// <summary>Internal Acessors for Match</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbeInternal.Match { get => (this._match = this._match ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatch()); set { {_match = value;} } }

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

        /// <summary>Backing field for <see cref="Timeout" /> property.</summary>
        private int? _timeout;

        /// <summary>
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Timeout { get => this._timeout; set => this._timeout = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayOnDemandProbe" /> instance.</summary>
        public ApplicationGatewayOnDemandProbe()
        {

        }
    }
    /// Details of on demand test probe request
    public partial interface IApplicationGatewayOnDemandProbe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendAddressPoolId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendHttpSettingId { get; set; }
        /// <summary>Host name to send the probe to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host name to send the probe to.",
        SerializedName = @"host",
        PossibleTypes = new [] { typeof(string) })]
        string Host { get; set; }
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

    }
    /// Details of on demand test probe request
    internal partial interface IApplicationGatewayOnDemandProbeInternal

    {
        /// <summary>
        /// Reference of backend pool of application gateway to which probe request will be sent.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource BackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendAddressPoolId { get; set; }
        /// <summary>
        /// Reference of backend http setting of application gateway to be used for test probe.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource BackendHttpSetting { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendHttpSettingId { get; set; }
        /// <summary>Host name to send the probe to.</summary>
        string Host { get; set; }
        /// <summary>Criterion for classifying a healthy probe response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbeHealthResponseMatch Match { get; set; }
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        string MatchBody { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        string[] MatchStatusCode { get; set; }
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
        /// The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable
        /// values are from 1 second to 86400 seconds.
        /// </summary>
        int? Timeout { get; set; }

    }
}