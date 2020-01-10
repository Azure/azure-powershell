namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Inbound NAT rule of the load balancer.</summary>
    public partial class InboundNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ApplicationGatewayBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ApplicationGatewayBackendAddressPool = value; }

        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ApplicationSecurityGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ApplicationSecurityGroup = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendIPConfigurationEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationId = value; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendIPConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationName = value; }

        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BackendIPConfigurationPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationPropertiesProvisioningState = value; }

        /// <summary>
        /// The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BackendPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendPort = value; }

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableFloatingIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).EnableFloatingIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).EnableFloatingIP = value; }

        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableTcpReset { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).EnableTcpReset; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).EnableTcpReset = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendIPConfigurationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendIPConfigurationId = value; }

        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// range from 1 to 65534.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? FrontendPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendPort = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).LoadBalancerBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).LoadBalancerBackendAddressPool = value; }

        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).LoadBalancerInboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).LoadBalancerInboundNatRule = value; }

        /// <summary>Internal Acessors for BackendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRuleInternal.BackendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfiguration = value; }

        /// <summary>Internal Acessors for BackendIPConfigurationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRuleInternal.BackendIPConfigurationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).BackendIPConfigurationProperty = value; }

        /// <summary>Internal Acessors for FrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRuleInternal.FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatRulePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? Primary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Primary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Primary = value; }

        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAddress = value; }

        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAddressVersion = value; }

        /// <summary>The private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PrivateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormat _property;

        /// <summary>Properties of load balancer inbound nat rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatRulePropertiesFormat()); set => this._property = value; }

        /// <summary>The reference to the transport protocol used by the load balancing rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol? Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Protocol = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Public IP address bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).PublicIPAddress = value; }

        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>The reference to Virtual Network Taps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).VnetTap; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormatInternal)Property).VnetTap = value; }

        /// <summary>Creates an new <see cref="InboundNatRule" /> instance.</summary>
        public InboundNatRule()
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
    /// Inbound NAT rule of the load balancer.
    public partial interface IInboundNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
    {
        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of ApplicationGatewayBackendAddressPool resource.",
        SerializedName = @"applicationGatewayBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get; set; }
        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application security groups in which the IP configuration is included.",
        SerializedName = @"applicationSecurityGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string BackendIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string BackendIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string BackendIPConfigurationName { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string BackendIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>
        /// The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port used for the internal endpoint. Acceptable values range from 1 to 65535.",
        SerializedName = @"backendPort",
        PossibleTypes = new [] { typeof(int) })]
        int? BackendPort { get; set; }
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
        /// range from 1 to 65534.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.",
        SerializedName = @"frontendPort",
        PossibleTypes = new [] { typeof(int) })]
        int? FrontendPort { get; set; }
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
        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of LoadBalancerBackendAddressPool resource.",
        SerializedName = @"loadBalancerBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of references of LoadBalancerInboundNatRules.",
        SerializedName = @"loadBalancerInboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get; set; }
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
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether this is a primary customer address on the network interface.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.",
        SerializedName = @"privateIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>The private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address allocation method.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>The reference to the transport protocol used by the load balancing rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to the transport protocol used by the load balancing rule.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol? Protocol { get; set; }
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
        /// <summary>Public IP address bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public IP address bound to the IP configuration.",
        SerializedName = @"publicIPAddress",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet bound to the IP configuration.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }
        /// <summary>The reference to Virtual Network Taps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to Virtual Network Taps.",
        SerializedName = @"virtualNetworkTaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get; set; }

    }
    /// Inbound NAT rule of the load balancer.
    internal partial interface IInboundNatRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get; set; }
        /// <summary>Application security groups in which the IP configuration is included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get; set; }
        /// <summary>
        /// A reference to a private IP address defined on a network interface of a VM. Traffic sent to the frontend port of each
        /// of the frontend IP configurations is forwarded to the backend IP.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration BackendIPConfiguration { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string BackendIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string BackendIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string BackendIPConfigurationName { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string BackendIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>Network interface IP configuration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationPropertiesFormat BackendIPConfigurationProperty { get; set; }
        /// <summary>
        /// The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        /// </summary>
        int? BackendPort { get; set; }
        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        bool? EnableFloatingIP { get; set; }
        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        bool? EnableTcpReset { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>A reference to frontend IP addresses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource FrontendIPConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string FrontendIPConfigurationId { get; set; }
        /// <summary>
        /// The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values
        /// range from 1 to 65534.
        /// </summary>
        int? FrontendPort { get; set; }
        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        bool? Primary { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>The private IP address allocation method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>Properties of load balancer inbound nat rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRulePropertiesFormat Property { get; set; }
        /// <summary>The reference to the transport protocol used by the load balancing rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol? Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Public IP address bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }
        /// <summary>The reference to Virtual Network Taps.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get; set; }

    }
}