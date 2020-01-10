namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>LoadBalancer resource</summary>
    public partial class LoadBalancer :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>Collection of backend address pools used by a load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] BackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).BackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).BackendAddressPool = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[] FrontendIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).FrontendIPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).FrontendIPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>
        /// Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound
        /// NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
        /// Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT
        /// pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot
        /// reference an inbound NAT pool. They have to reference individual inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[] InboundNatPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).InboundNatPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).InboundNatPool = value; }

        /// <summary>
        /// Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually
        /// exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that
        /// are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual
        /// inbound NAT rules.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] InboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).InboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).InboundNatRule = value; }

        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[] LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).LoadBalancingRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).LoadBalancingRule = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>The outbound rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[] OutboundRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).OutboundRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).OutboundRule = value; }

        /// <summary>Collection of probe objects used in the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[] Probe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).Probe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).Probe = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat _property;

        /// <summary>Properties of load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The resource GUID property of the load balancer resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0, Label = @"GUID")]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSku _sku;

        /// <summary>The load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerSku()); set => this._sku = value; }

        /// <summary>Name of a load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"SKU Name")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerSkuInternal)Sku).Name = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="LoadBalancer" /> instance.</summary>
        public LoadBalancer()
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
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// LoadBalancer resource
    public partial interface ILoadBalancer :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>Collection of backend address pools used by a load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of backend address pools used by a load balancer",
        SerializedName = @"backendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object representing the frontend IPs to be used for the load balancer",
        SerializedName = @"frontendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[] InboundNatPool { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] InboundNatRule { get; set; }
        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object collection representing the load balancing rules Gets the provisioning ",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[] LoadBalancingRule { get; set; }
        /// <summary>The outbound rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The outbound rules.",
        SerializedName = @"outboundRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[] OutboundRule { get; set; }
        /// <summary>Collection of probe objects used in the load balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of probe objects used in the load balancer",
        SerializedName = @"probes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[] Probe { get; set; }
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
        /// <summary>Name of a load balancer SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a load balancer SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? SkuName { get; set; }

    }
    /// LoadBalancer resource
    internal partial interface ILoadBalancerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>Collection of backend address pools used by a load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] BackendAddressPool { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Object representing the frontend IPs to be used for the load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[] FrontendIPConfiguration { get; set; }
        /// <summary>
        /// Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound
        /// NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
        /// Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT
        /// pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot
        /// reference an inbound NAT pool. They have to reference individual inbound NAT rules.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[] InboundNatPool { get; set; }
        /// <summary>
        /// Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually
        /// exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that
        /// are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual
        /// inbound NAT rules.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] InboundNatRule { get; set; }
        /// <summary>Object collection representing the load balancing rules Gets the provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[] LoadBalancingRule { get; set; }
        /// <summary>The outbound rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[] OutboundRule { get; set; }
        /// <summary>Collection of probe objects used in the load balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[] Probe { get; set; }
        /// <summary>Properties of load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat Property { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the load balancer resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>The load balancer SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerSku Sku { get; set; }
        /// <summary>Name of a load balancer SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName? SkuName { get; set; }

    }
}