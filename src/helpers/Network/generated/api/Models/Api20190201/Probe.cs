namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A load balancer probe.</summary>
    public partial class Probe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbeInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>
        /// The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly
        /// less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IntervalInSeconds { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).IntervalInSeconds; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).IntervalInSeconds = value; }

        /// <summary>The load balancer rules that use this probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).LoadBalancingRule; }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbeInternal.LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).LoadBalancingRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).LoadBalancingRule = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbeInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProbePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint.
        /// This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? NumberOfProbe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).NumberOfProbe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).NumberOfProbe = value; }

        /// <summary>
        /// The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int Port { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).Port = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat _property;

        /// <summary>Properties of load balancer probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProbePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The protocol of the end point. Possible values are: 'Http', 'Tcp', or 'Https'. If 'Tcp' is specified, a received ACK is
        /// required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is
        /// required for the probe to be successful.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProbeProtocol Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>
        /// The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is
        /// not allowed. There is no default value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RequestPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).RequestPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormatInternal)Property).RequestPath = value; }

        /// <summary>Creates an new <see cref="Probe" /> instance.</summary>
        public Probe()
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
    /// A load balancer probe.
    public partial interface IProbe :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get;  }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// The protocol of the end point. Possible values are: 'Http', 'Tcp', or 'Https'. If 'Tcp' is specified, a received ACK is
        /// required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is
        /// required for the probe to be successful.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The protocol of the end point. Possible values are: 'Http', 'Tcp', or 'Https'. If 'Tcp' is specified, a received ACK is required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is required for the probe to be successful.",
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
    /// A load balancer probe.
    internal partial interface IProbeInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly
        /// less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of
        /// rotation. The default value is 15, the minimum value is 5.
        /// </summary>
        int? IntervalInSeconds { get; set; }
        /// <summary>The load balancer rules that use this probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint.
        /// This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
        /// </summary>
        int? NumberOfProbe { get; set; }
        /// <summary>
        /// The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
        /// </summary>
        int Port { get; set; }
        /// <summary>Properties of load balancer probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat Property { get; set; }
        /// <summary>
        /// The protocol of the end point. Possible values are: 'Http', 'Tcp', or 'Https'. If 'Tcp' is specified, a received ACK is
        /// required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is
        /// required for the probe to be successful.
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