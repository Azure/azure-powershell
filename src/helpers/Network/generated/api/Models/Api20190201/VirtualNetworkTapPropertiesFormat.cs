namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Virtual Network Tap properties.</summary>
    public partial class VirtualNetworkTapPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal
    {

        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ApplicationGatewayBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ApplicationGatewayBackendAddressPool = value; }

        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ApplicationSecurityGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ApplicationSecurityGroup = value; }

        /// <summary>
        /// Backing field for <see cref="DestinationLoadBalancerFrontEndIPConfiguration" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration _destinationLoadBalancerFrontEndIPConfiguration;

        /// <summary>
        /// The reference to the private IP address on the internal Load Balancer that will receive the tap
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get => (this._destinationLoadBalancerFrontEndIPConfiguration = this._destinationLoadBalancerFrontEndIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FrontendIPConfiguration()); set => this._destinationLoadBalancerFrontEndIPConfiguration = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationLoadBalancerFrontEndIPConfigurationEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationLoadBalancerFrontEndIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DestinationLoadBalancerFrontEndIPConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DestinationLoadBalancerFrontEndIPConfiguration).Id = value; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationLoadBalancerFrontEndIPConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Name = value; }

        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpaddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PrivateIPAddress = value; }

        /// <summary>The Private IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpallocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PrivateIPAllocationMethod = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).ProvisioningState = value; }

        /// <summary>The reference of the Public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIpaddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPAddress = value; }

        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Subnet = value; }

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DestinationLoadBalancerFrontEndIPConfigurationZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Zone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Zone = value; }

        /// <summary>
        /// Backing field for <see cref="DestinationNetworkInterfaceIPConfiguration" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration _destinationNetworkInterfaceIPConfiguration;

        /// <summary>
        /// The reference to the private IP Address of the collector nic that will receive the tap
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get => (this._destinationNetworkInterfaceIPConfiguration = this._destinationNetworkInterfaceIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceIPConfiguration()); set => this._destinationNetworkInterfaceIPConfiguration = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationNetworkInterfaceIPConfigurationEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationNetworkInterfaceIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DestinationNetworkInterfaceIPConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DestinationNetworkInterfaceIPConfiguration).Id = value; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationNetworkInterfaceIPConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Name = value; }

        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpaddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAddress = value; }

        /// <summary>The private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpallocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAllocationMethod = value; }

        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).ProvisioningState = value; }

        /// <summary>Public IP address bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationNetworkInterfaceIPConfigurationPropertiesPublicIpaddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PublicIPAddress = value; }

        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationNetworkInterfaceIPConfigurationPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Subnet = value; }

        /// <summary>Backing field for <see cref="DestinationPort" /> property.</summary>
        private int? _destinationPort;

        /// <summary>The VXLAN destination port that will receive the tapped traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? DestinationPort { get => this._destinationPort; set => this._destinationPort = value; }

        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatPool; }

        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatRule; }

        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).LoadBalancerBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).LoadBalancerBackendAddressPool = value; }

        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).LoadBalancerInboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).LoadBalancerInboundNatRule = value; }

        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).LoadBalancingRule; }

        /// <summary>Internal Acessors for DestinationLoadBalancerFrontEndIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.DestinationLoadBalancerFrontEndIPConfiguration { get => (this._destinationLoadBalancerFrontEndIPConfiguration = this._destinationLoadBalancerFrontEndIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FrontendIPConfiguration()); set { {_destinationLoadBalancerFrontEndIPConfiguration = value;} } }

        /// <summary>Internal Acessors for DestinationLoadBalancerFrontEndIPConfigurationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.DestinationLoadBalancerFrontEndIPConfigurationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).Property = value; }

        /// <summary>Internal Acessors for DestinationNetworkInterfaceIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.DestinationNetworkInterfaceIPConfiguration { get => (this._destinationNetworkInterfaceIPConfiguration = this._destinationNetworkInterfaceIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceIPConfiguration()); set { {_destinationNetworkInterfaceIPConfiguration = value;} } }

        /// <summary>Internal Acessors for DestinationNetworkInterfaceIPConfigurationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.DestinationNetworkInterfaceIPConfigurationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Property = value; }

        /// <summary>Internal Acessors for InboundNatPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.InboundNatPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatPool = value; }

        /// <summary>Internal Acessors for InboundNatRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.InboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).InboundNatRule = value; }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).LoadBalancingRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).LoadBalancingRule = value; }

        /// <summary>Internal Acessors for NetworkInterfaceTapConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.NetworkInterfaceTapConfiguration { get => this._networkInterfaceTapConfiguration; set { {_networkInterfaceTapConfiguration = value;} } }

        /// <summary>Internal Acessors for OutboundRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.OutboundRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).OutboundRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).OutboundRule = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublicIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.PublicIPPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPPrefix = value; }

        /// <summary>Internal Acessors for ResourceGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTapPropertiesFormatInternal.ResourceGuid { get => this._resourceGuid; set { {_resourceGuid = value;} } }

        /// <summary>Backing field for <see cref="NetworkInterfaceTapConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] _networkInterfaceTapConfiguration;

        /// <summary>
        /// Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] NetworkInterfaceTapConfiguration { get => this._networkInterfaceTapConfiguration; }

        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).OutboundRule; }

        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? Primary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Primary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).Primary = value; }

        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).PrivateIPAddressVersion = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the virtual network tap. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPPrefixId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPPrefixId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationInternal)DestinationLoadBalancerFrontEndIPConfiguration).PublicIPPrefixId = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resourceGuid property of the virtual network tap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; }

        /// <summary>The reference to Virtual Network Taps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).VnetTap; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationInternal)DestinationNetworkInterfaceIPConfiguration).VnetTap = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkTapPropertiesFormat" /> instance.</summary>
        public VirtualNetworkTapPropertiesFormat()
        {

        }
    }
    /// Virtual Network Tap properties.
    public partial interface IVirtualNetworkTapPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
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
        string DestinationLoadBalancerFrontEndIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationLoadBalancerFrontEndIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationLoadBalancerFrontEndIPConfigurationName { get; set; }
        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpaddress { get; set; }
        /// <summary>The Private IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Private IP allocation method.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpallocationMethod { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>The reference of the Public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of the Public IP resource.",
        SerializedName = @"publicIPAddress",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIpaddress { get; set; }
        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of the subnet resource.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of availability zones denoting the IP allocated for the resource needs to come from.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] DestinationLoadBalancerFrontEndIPConfigurationZone { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationNetworkInterfaceIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationNetworkInterfaceIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationNetworkInterfaceIPConfigurationName { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpaddress { get; set; }
        /// <summary>The private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address allocation method.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpallocationMethod { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>Public IP address bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public IP address bound to the IP configuration.",
        SerializedName = @"publicIPAddress",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationNetworkInterfaceIPConfigurationPropertiesPublicIpaddress { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet bound to the IP configuration.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationNetworkInterfaceIPConfigurationPropertiesSubnet { get; set; }
        /// <summary>The VXLAN destination port that will receive the tapped traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VXLAN destination port that will receive the tapped traffic.",
        SerializedName = @"destinationPort",
        PossibleTypes = new [] { typeof(int) })]
        int? DestinationPort { get; set; }
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound pools URIs that use this frontend IP.",
        SerializedName = @"inboundNatPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get;  }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound rules URIs that use this frontend IP.",
        SerializedName = @"inboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get;  }
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
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets load balancing rules URIs that use this frontend IP.",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get;  }
        /// <summary>
        /// Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped.",
        SerializedName = @"networkInterfaceTapConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] NetworkInterfaceTapConfiguration { get;  }
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Outbound rules URIs that use this frontend IP.",
        SerializedName = @"outboundRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get;  }
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether this is a primary customer address on the network interface.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }
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
        /// <summary>
        /// The provisioning state of the virtual network tap. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the virtual network tap. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPPrefixId { get; set; }
        /// <summary>The resourceGuid property of the virtual network tap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resourceGuid property of the virtual network tap.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get;  }
        /// <summary>The reference to Virtual Network Taps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to Virtual Network Taps.",
        SerializedName = @"virtualNetworkTaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get; set; }

    }
    /// Virtual Network Tap properties.
    internal partial interface IVirtualNetworkTapPropertiesFormatInternal

    {
        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get; set; }
        /// <summary>Application security groups in which the IP configuration is included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] ApplicationSecurityGroup { get; set; }
        /// <summary>
        /// The reference to the private IP address on the internal Load Balancer that will receive the tap
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string DestinationLoadBalancerFrontEndIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string DestinationLoadBalancerFrontEndIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string DestinationLoadBalancerFrontEndIPConfigurationName { get; set; }
        /// <summary>The private IP address of the IP configuration.</summary>
        string DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpaddress { get; set; }
        /// <summary>The Private IP allocation method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpallocationMethod { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>The reference of the Public IP resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIpaddress { get; set; }
        /// <summary>The reference of the subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet { get; set; }
        /// <summary>Properties of the load balancer probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormat DestinationLoadBalancerFrontEndIPConfigurationProperty { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        string[] DestinationLoadBalancerFrontEndIPConfigurationZone { get; set; }
        /// <summary>
        /// The reference to the private IP Address of the collector nic that will receive the tap
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string DestinationNetworkInterfaceIPConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string DestinationNetworkInterfaceIPConfigurationId { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string DestinationNetworkInterfaceIPConfigurationName { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        string DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpaddress { get; set; }
        /// <summary>The private IP address allocation method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpallocationMethod { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>Public IP address bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress DestinationNetworkInterfaceIPConfigurationPropertiesPublicIpaddress { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet DestinationNetworkInterfaceIPConfigurationPropertiesSubnet { get; set; }
        /// <summary>Network interface IP configuration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfigurationPropertiesFormat DestinationNetworkInterfaceIPConfigurationProperty { get; set; }
        /// <summary>The VXLAN destination port that will receive the tapped traffic.</summary>
        int? DestinationPort { get; set; }
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get; set; }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get; set; }
        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[] LoadBalancerInboundNatRule { get; set; }
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>
        /// Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] NetworkInterfaceTapConfiguration { get; set; }
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get; set; }
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        bool? Primary { get; set; }
        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>
        /// The provisioning state of the virtual network tap. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the Public IP Prefix resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PublicIPPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        string PublicIPPrefixId { get; set; }
        /// <summary>The resourceGuid property of the virtual network tap.</summary>
        string ResourceGuid { get; set; }
        /// <summary>The reference to Virtual Network Taps.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[] VnetTap { get; set; }

    }
}