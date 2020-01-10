namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A load balancing rule for a load balancer.</summary>
    public partial class LoadBalancingRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendAddressPoolId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendAddressPoolId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendAddressPoolId = value; }

        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables
        /// "Any Port"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BackendPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendPort = value; }

        /// <summary>
        /// Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing
        /// rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? DisableOutboundSnat { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).DisableOutboundSnat; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).DisableOutboundSnat = value; }

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableFloatingIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).EnableFloatingIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).EnableFloatingIP = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendIPConfigurationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendIPConfigurationId = value; }

        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// are between 0 and 65534. Note that value 0 enables "Any Port"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int FrontendPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendPort = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>
        /// The load distribution policy for this rule. Possible values are 'Default', 'SourceIP', and 'SourceIPProtocol'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution? LoadDistribution { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).LoadDistribution; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).LoadDistribution = value; }

        /// <summary>Internal Acessors for BackendAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRuleInternal.BackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).BackendAddressPool = value; }

        /// <summary>Internal Acessors for FrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRuleInternal.FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Internal Acessors for Probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRuleInternal.Probe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).Probe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).Probe = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LoadBalancingRulePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProbeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).ProbeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).ProbeId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat _property;

        /// <summary>Properties of load balancer load balancing rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LoadBalancingRulePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Creates an new <see cref="LoadBalancingRule" /> instance.</summary>
        public LoadBalancingRule()
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
    /// A load balancing rule for a load balancer.
    public partial interface ILoadBalancingRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendAddressPoolId { get; set; }
        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables
        /// "Any Port"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables ""Any Port""",
        SerializedName = @"backendPort",
        PossibleTypes = new [] { typeof(int) })]
        int? BackendPort { get; set; }
        /// <summary>
        /// Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing
        /// rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule.",
        SerializedName = @"disableOutboundSnat",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableOutboundSnat { get; set; }
        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.",
        SerializedName = @"enableFloatingIP",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableFloatingIP { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string FrontendIPConfigurationId { get; set; }
        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// are between 0 and 65534. Note that value 0 enables "Any Port"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables ""Any Port""",
        SerializedName = @"frontendPort",
        PossibleTypes = new [] { typeof(int) })]
        int FrontendPort { get; set; }
        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The load distribution policy for this rule. Possible values are 'Default', 'SourceIP', and 'SourceIPProtocol'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The load distribution policy for this rule. Possible values are 'Default', 'SourceIP', and 'SourceIPProtocol'.",
        SerializedName = @"loadDistribution",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution? LoadDistribution { get; set; }
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
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ProbeId { get; set; }
        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get; set; }
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
    /// A load balancing rule for a load balancer.
    internal partial interface ILoadBalancingRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>
        /// A reference to a pool of DIPs. Inbound traffic is randomly load balanced across IPs in the backend IPs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource BackendAddressPool { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendAddressPoolId { get; set; }
        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables
        /// "Any Port"
        /// </summary>
        int? BackendPort { get; set; }
        /// <summary>
        /// Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing
        /// rule.
        /// </summary>
        bool? DisableOutboundSnat { get; set; }
        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        bool? EnableFloatingIP { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>A reference to frontend IP addresses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource FrontendIPConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string FrontendIPConfigurationId { get; set; }
        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// are between 0 and 65534. Note that value 0 enables "Any Port"
        /// </summary>
        int FrontendPort { get; set; }
        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The load distribution policy for this rule. Possible values are 'Default', 'SourceIP', and 'SourceIPProtocol'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution? LoadDistribution { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>The reference of the load balancer probe used by the load balancing rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Probe { get; set; }
        /// <summary>Resource ID.</summary>
        string ProbeId { get; set; }
        /// <summary>Properties of load balancer load balancing rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat Property { get; set; }
        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}