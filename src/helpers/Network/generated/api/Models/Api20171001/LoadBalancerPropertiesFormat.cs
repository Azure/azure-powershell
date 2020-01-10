namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the load balancer.</summary>
    public partial class LoadBalancerPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] _backendAddressPool;

        /// <summary>Collection of backend address pools used by a load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] BackendAddressPool { get => this._backendAddressPool; set => this._backendAddressPool = value; }

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration[] _frontendIPConfiguration;

        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration[] FrontendIPConfiguration { get => this._frontendIPConfiguration; set => this._frontendIPConfiguration = value; }

        /// <summary>Backing field for <see cref="InboundNatPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool[] _inboundNatPool;

        /// <summary>
        /// Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound
        /// NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
        /// Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT
        /// pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot
        /// reference an inbound NAT pool. They have to reference individual inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool[] InboundNatPool { get => this._inboundNatPool; set => this._inboundNatPool = value; }

        /// <summary>Backing field for <see cref="InboundNatRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] _inboundNatRule;

        /// <summary>
        /// Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually
        /// exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that
        /// are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual
        /// inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] InboundNatRule { get => this._inboundNatRule; set => this._inboundNatRule = value; }

        /// <summary>Backing field for <see cref="LoadBalancingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule[] _loadBalancingRule;

        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule[] LoadBalancingRule { get => this._loadBalancingRule; set => this._loadBalancingRule = value; }

        /// <summary>Backing field for <see cref="OutboundNatRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule[] _outboundNatRule;

        /// <summary>The outbound NAT rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule[] OutboundNatRule { get => this._outboundNatRule; set => this._outboundNatRule = value; }

        /// <summary>Backing field for <see cref="Probe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] _probe;

        /// <summary>Collection of probe objects used in the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Probe { get => this._probe; set => this._probe = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the load balancer resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Creates an new <see cref="LoadBalancerPropertiesFormat" /> instance.</summary>
        public LoadBalancerPropertiesFormat()
        {

        }
    }
    /// Properties of the load balancer.
    public partial interface ILoadBalancerPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Collection of backend address pools used by a load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of backend address pools used by a load balancer",
        SerializedName = @"backendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object representing the frontend IPs to be used for the load balancer",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
        /// <summary>
        /// Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound
        /// NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
        /// Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT
        /// pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot
        /// reference an inbound NAT pool. They have to reference individual inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range. Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an inbound NAT pool. They have to reference individual inbound NAT rules.",
        SerializedName = @"inboundNatPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool[] InboundNatPool { get; set; }
        /// <summary>
        /// Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually
        /// exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that
        /// are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual
        /// inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual inbound NAT rules.",
        SerializedName = @"inboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] InboundNatRule { get; set; }
        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object collection representing the load balancing rules Gets the provisioning ",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule[] LoadBalancingRule { get; set; }
        /// <summary>The outbound NAT rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The outbound NAT rules.",
        SerializedName = @"outboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule[] OutboundNatRule { get; set; }
        /// <summary>Collection of probe objects used in the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of probe objects used in the load balancer",
        SerializedName = @"probes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Probe { get; set; }
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
        /// <summary>The resource GUID property of the load balancer resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the load balancer resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }

    }
    /// Properties of the load balancer.
    internal partial interface ILoadBalancerPropertiesFormatInternal

    {
        /// <summary>Collection of backend address pools used by a load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
        /// <summary>
        /// Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound
        /// NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
        /// Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT
        /// pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot
        /// reference an inbound NAT pool. They have to reference individual inbound NAT rules.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool[] InboundNatPool { get; set; }
        /// <summary>
        /// Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually
        /// exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that
        /// are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual
        /// inbound NAT rules.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] InboundNatRule { get; set; }
        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule[] LoadBalancingRule { get; set; }
        /// <summary>The outbound NAT rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule[] OutboundNatRule { get; set; }
        /// <summary>Collection of probe objects used in the load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Probe { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the load balancer resource.</summary>
        string ResourceGuid { get; set; }

    }
}