namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Outbound rule of the load balancer.</summary>
    public partial class OutboundRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>The number of outbound ports to be used for NAT.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? AllocatedOutboundPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).AllocatedOutboundPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).AllocatedOutboundPort = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).BackendAddressPoolId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).BackendAddressPoolId = value; }

        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableTcpReset { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).EnableTcpReset; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).EnableTcpReset = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>The Frontend IP addresses of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>The timeout for the TCP idle connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>Internal Acessors for BackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRuleInternal.BackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).BackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).BackendAddressPool = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.OutboundRulePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormat _property;

        /// <summary>Properties of load balancer outbound rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.OutboundRulePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The protocol for the outbound rule in load balancer. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Creates an new <see cref="OutboundRule" /> instance.</summary>
        public OutboundRule()
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
    /// Outbound rule of the load balancer.
    public partial interface IOutboundRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
    {
        /// <summary>The number of outbound ports to be used for NAT.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of outbound ports to be used for NAT.",
        SerializedName = @"allocatedOutboundPorts",
        PossibleTypes = new [] { typeof(int) })]
        int? AllocatedOutboundPort { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendAddressPoolId { get; set; }
        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.",
        SerializedName = @"enableTcpReset",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableTcpReset { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>The Frontend IP addresses of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Frontend IP addresses of the load balancer.",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] FrontendIPConfiguration { get; set; }
        /// <summary>The timeout for the TCP idle connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout for the TCP idle connection",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The protocol for the outbound rule in load balancer. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The protocol for the outbound rule in load balancer. Possible values are: 'Tcp', 'Udp', and 'All'.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Outbound rule of the load balancer.
    internal partial interface IOutboundRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>The number of outbound ports to be used for NAT.</summary>
        int? AllocatedOutboundPort { get; set; }
        /// <summary>
        /// A reference to a pool of DIPs. Outbound traffic is randomly load balanced across IPs in the backend IPs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource BackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendAddressPoolId { get; set; }
        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        bool? EnableTcpReset { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The Frontend IP addresses of the load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] FrontendIPConfiguration { get; set; }
        /// <summary>The timeout for the TCP idle connection</summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Properties of load balancer outbound rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRulePropertiesFormat Property { get; set; }
        /// <summary>
        /// The protocol for the outbound rule in load balancer. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerOutboundRuleProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}