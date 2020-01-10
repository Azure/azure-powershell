namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Outbound NAT pool of the load balancer.</summary>
    public partial class OutboundNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>The number of outbound ports to be used for NAT.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? AllocatedOutboundPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).AllocatedOutboundPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).AllocatedOutboundPort = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).BackendAddressPoolId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).BackendAddressPoolId = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>The Frontend IP addresses of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for BackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRuleInternal.BackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).BackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).BackendAddressPool = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.OutboundNatRulePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormat _property;

        /// <summary>Properties of load balancer outbound nat rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.OutboundNatRulePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Creates an new <see cref="OutboundNatRule" /> instance.</summary>
        public OutboundNatRule()
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
    /// Outbound NAT pool of the load balancer.
    public partial interface IOutboundNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
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
        Required = false,
        ReadOnly = false,
        Description = @"The Frontend IP addresses of the load balancer.",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] FrontendIPConfiguration { get; set; }
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
    /// Outbound NAT pool of the load balancer.
    internal partial interface IOutboundNatRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>The number of outbound ports to be used for NAT.</summary>
        int? AllocatedOutboundPort { get; set; }
        /// <summary>
        /// A reference to a pool of DIPs. Outbound traffic is randomly load balanced across IPs in the backend IPs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendAddressPoolId { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The Frontend IP addresses of the load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] FrontendIPConfiguration { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Properties of load balancer outbound nat rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRulePropertiesFormat Property { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}