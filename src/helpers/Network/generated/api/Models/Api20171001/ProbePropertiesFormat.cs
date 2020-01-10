namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Load balancer probe resource.</summary>
    public partial class ProbePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="IntervalInSeconds" /> property.</summary>
        private int? _intervalInSeconds;

        /// <summary>
        /// The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly
        /// less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? IntervalInSeconds { get => this._intervalInSeconds; set => this._intervalInSeconds = value; }

        /// <summary>Backing field for <see cref="LoadBalancingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] _loadBalancingRule;

        /// <summary>The load balancer rules that use this probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get => this._loadBalancingRule; }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbePropertiesFormatInternal.LoadBalancingRule { get => this._loadBalancingRule; set { {_loadBalancingRule = value;} } }

        /// <summary>Backing field for <see cref="NumberOfProbe" /> property.</summary>
        private int? _numberOfProbe;

        /// <summary>
        /// The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint.
        /// This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? NumberOfProbe { get => this._numberOfProbe; set => this._numberOfProbe = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int _port;

        /// <summary>
        /// The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol _protocol;

        /// <summary>
        /// The protocol of the end point. Possible values are: 'Http' or 'Tcp'. If 'Tcp' is specified, a received ACK is required
        /// for the probe to be successful. If 'Http' is specified, a 200 OK response from the specifies URI is required for the probe
        /// to be successful.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RequestPath" /> property.</summary>
        private string _requestPath;

        /// <summary>
        /// The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is
        /// not allowed. There is no default value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RequestPath { get => this._requestPath; set => this._requestPath = value; }

        /// <summary>Creates an new <see cref="ProbePropertiesFormat" /> instance.</summary>
        public ProbePropertiesFormat()
        {

        }
    }
    /// Load balancer probe resource.
    public partial interface IProbePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly
        /// less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of rotation. The default value is 15, the minimum value is 5.",
        SerializedName = @"intervalInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? IntervalInSeconds { get; set; }
        /// <summary>The load balancer rules that use this probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The load balancer rules that use this probe.",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get;  }
        /// <summary>
        /// The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint.
        /// This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint. This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.",
        SerializedName = @"numberOfProbes",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfProbe { get; set; }
        /// <summary>
        /// The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port for communicating the probe. Possible values range from 1 to 65535, inclusive.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int Port { get; set; }
        /// <summary>
        /// The protocol of the end point. Possible values are: 'Http' or 'Tcp'. If 'Tcp' is specified, a received ACK is required
        /// for the probe to be successful. If 'Http' is specified, a 200 OK response from the specifies URI is required for the probe
        /// to be successful.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The protocol of the end point. Possible values are: 'Http' or 'Tcp'. If 'Tcp' is specified, a received ACK is required for the probe to be successful. If 'Http' is specified, a 200 OK response from the specifies URI is required for the probe to be successful.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>
        /// The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is
        /// not allowed. There is no default value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is not allowed. There is no default value.",
        SerializedName = @"requestPath",
        PossibleTypes = new [] { typeof(string) })]
        string RequestPath { get; set; }

    }
    /// Load balancer probe resource.
    internal partial interface IProbePropertiesFormatInternal

    {
        /// <summary>
        /// The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly
        /// less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5.
        /// </summary>
        int? IntervalInSeconds { get; set; }
        /// <summary>The load balancer rules that use this probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>
        /// The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint.
        /// This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
        /// </summary>
        int? NumberOfProbe { get; set; }
        /// <summary>
        /// The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
        /// </summary>
        int Port { get; set; }
        /// <summary>
        /// The protocol of the end point. Possible values are: 'Http' or 'Tcp'. If 'Tcp' is specified, a received ACK is required
        /// for the probe to be successful. If 'Http' is specified, a 200 OK response from the specifies URI is required for the probe
        /// to be successful.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is
        /// not allowed. There is no default value.
        /// </summary>
        string RequestPath { get; set; }

    }
}