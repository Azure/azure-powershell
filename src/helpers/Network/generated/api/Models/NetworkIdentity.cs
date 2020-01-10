namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class NetworkIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal
    {

        /// <summary>Backing field for <see cref="ApplicationGatewayName" /> property.</summary>
        private string _applicationGatewayName;

        /// <summary>The name of the application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ApplicationGatewayName { get => this._applicationGatewayName; set => this._applicationGatewayName = value; }

        /// <summary>Backing field for <see cref="ApplicationSecurityGroupName" /> property.</summary>
        private string _applicationSecurityGroupName;

        /// <summary>The name of the application security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ApplicationSecurityGroupName { get => this._applicationSecurityGroupName; set => this._applicationSecurityGroupName = value; }

        /// <summary>Backing field for <see cref="AuthorizationName" /> property.</summary>
        private string _authorizationName;

        /// <summary>The name of the authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationName { get => this._authorizationName; set => this._authorizationName = value; }

        /// <summary>Backing field for <see cref="AzureFirewallName" /> property.</summary>
        private string _azureFirewallName;

        /// <summary>The name of the Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AzureFirewallName { get => this._azureFirewallName; set => this._azureFirewallName = value; }

        /// <summary>Backing field for <see cref="BackendAddressPoolName" /> property.</summary>
        private string _backendAddressPoolName;

        /// <summary>The name of the backend address pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string BackendAddressPoolName { get => this._backendAddressPoolName; set => this._backendAddressPoolName = value; }

        /// <summary>Backing field for <see cref="CircuitName" /> property.</summary>
        private string _circuitName;

        /// <summary>The name of the express route circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CircuitName { get => this._circuitName; set => this._circuitName = value; }

        /// <summary>Backing field for <see cref="ConnectionMonitorName" /> property.</summary>
        private string _connectionMonitorName;

        /// <summary>The name of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ConnectionMonitorName { get => this._connectionMonitorName; set => this._connectionMonitorName = value; }

        /// <summary>Backing field for <see cref="ConnectionName" /> property.</summary>
        private string _connectionName;

        /// <summary>The name of the vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ConnectionName { get => this._connectionName; set => this._connectionName = value; }

        /// <summary>Backing field for <see cref="CrossConnectionName" /> property.</summary>
        private string _crossConnectionName;

        /// <summary>The name of the ExpressRouteCrossConnection (service key of the circuit).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CrossConnectionName { get => this._crossConnectionName; set => this._crossConnectionName = value; }

        /// <summary>Backing field for <see cref="DdosCustomPolicyName" /> property.</summary>
        private string _ddosCustomPolicyName;

        /// <summary>The name of the DDoS custom policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DdosCustomPolicyName { get => this._ddosCustomPolicyName; set => this._ddosCustomPolicyName = value; }

        /// <summary>Backing field for <see cref="DdosProtectionPlanName" /> property.</summary>
        private string _ddosProtectionPlanName;

        /// <summary>The name of the DDoS protection plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DdosProtectionPlanName { get => this._ddosProtectionPlanName; set => this._ddosProtectionPlanName = value; }

        /// <summary>Backing field for <see cref="DefaultSecurityRuleName" /> property.</summary>
        private string _defaultSecurityRuleName;

        /// <summary>The name of the default security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DefaultSecurityRuleName { get => this._defaultSecurityRuleName; set => this._defaultSecurityRuleName = value; }

        /// <summary>Backing field for <see cref="DevicePath" /> property.</summary>
        private string _devicePath;

        /// <summary>The path of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DevicePath { get => this._devicePath; set => this._devicePath = value; }

        /// <summary>Backing field for <see cref="ExpressRouteGatewayName" /> property.</summary>
        private string _expressRouteGatewayName;

        /// <summary>The name of the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ExpressRouteGatewayName { get => this._expressRouteGatewayName; set => this._expressRouteGatewayName = value; }

        /// <summary>Backing field for <see cref="ExpressRoutePortName" /> property.</summary>
        private string _expressRoutePortName;

        /// <summary>The name of the ExpressRoutePort resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ExpressRoutePortName { get => this._expressRoutePortName; set => this._expressRoutePortName = value; }

        /// <summary>Backing field for <see cref="FrontendIPConfigurationName" /> property.</summary>
        private string _frontendIPConfigurationName;

        /// <summary>The name of the frontend IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string FrontendIPConfigurationName { get => this._frontendIPConfigurationName; set => this._frontendIPConfigurationName = value; }

        /// <summary>Backing field for <see cref="GatewayName" /> property.</summary>
        private string _gatewayName;

        /// <summary>The name of the gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string GatewayName { get => this._gatewayName; set => this._gatewayName = value; }

        /// <summary>Backing field for <see cref="IPConfigurationName" /> property.</summary>
        private string _iPConfigurationName;

        /// <summary>The name of the ip configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPConfigurationName { get => this._iPConfigurationName; set => this._iPConfigurationName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="InboundNatRuleName" /> property.</summary>
        private string _inboundNatRuleName;

        /// <summary>The name of the inbound nat rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InboundNatRuleName { get => this._inboundNatRuleName; set => this._inboundNatRuleName = value; }

        /// <summary>Backing field for <see cref="InterfaceEndpointName" /> property.</summary>
        private string _interfaceEndpointName;

        /// <summary>The name of the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InterfaceEndpointName { get => this._interfaceEndpointName; set => this._interfaceEndpointName = value; }

        /// <summary>Backing field for <see cref="LinkName" /> property.</summary>
        private string _linkName;

        /// <summary>The name of the ExpressRouteLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LinkName { get => this._linkName; set => this._linkName = value; }

        /// <summary>Backing field for <see cref="LoadBalancerName" /> property.</summary>
        private string _loadBalancerName;

        /// <summary>The name of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LoadBalancerName { get => this._loadBalancerName; set => this._loadBalancerName = value; }

        /// <summary>Backing field for <see cref="LoadBalancingRuleName" /> property.</summary>
        private string _loadBalancingRuleName;

        /// <summary>The name of the load balancing rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LoadBalancingRuleName { get => this._loadBalancingRuleName; set => this._loadBalancingRuleName = value; }

        /// <summary>Backing field for <see cref="LocalNetworkGatewayName" /> property.</summary>
        private string _localNetworkGatewayName;

        /// <summary>The name of the local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalNetworkGatewayName { get => this._localNetworkGatewayName; set => this._localNetworkGatewayName = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The location of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="LocationName" /> property.</summary>
        private string _locationName;

        /// <summary>Name of the requested ExpressRoutePort peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocationName { get => this._locationName; set => this._locationName = value; }

        /// <summary>Backing field for <see cref="NatGatewayName" /> property.</summary>
        private string _natGatewayName;

        /// <summary>The name of the nat gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NatGatewayName { get => this._natGatewayName; set => this._natGatewayName = value; }

        /// <summary>Backing field for <see cref="NetworkInterfaceName" /> property.</summary>
        private string _networkInterfaceName;

        /// <summary>The name of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NetworkInterfaceName { get => this._networkInterfaceName; set => this._networkInterfaceName = value; }

        /// <summary>Backing field for <see cref="NetworkProfileName" /> property.</summary>
        private string _networkProfileName;

        /// <summary>The name of the NetworkProfile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NetworkProfileName { get => this._networkProfileName; set => this._networkProfileName = value; }

        /// <summary>Backing field for <see cref="NetworkWatcherName" /> property.</summary>
        private string _networkWatcherName;

        /// <summary>The name of the network watcher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NetworkWatcherName { get => this._networkWatcherName; set => this._networkWatcherName = value; }

        /// <summary>Backing field for <see cref="NsgName" /> property.</summary>
        private string _nsgName;

        /// <summary>The name of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NsgName { get => this._nsgName; set => this._nsgName = value; }

        /// <summary>Backing field for <see cref="OutboundRuleName" /> property.</summary>
        private string _outboundRuleName;

        /// <summary>The name of the outbound rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string OutboundRuleName { get => this._outboundRuleName; set => this._outboundRuleName = value; }

        /// <summary>Backing field for <see cref="P2SVpnServerConfigurationName" /> property.</summary>
        private string _p2SVpnServerConfigurationName;

        /// <summary>The name of the P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string P2SVpnServerConfigurationName { get => this._p2SVpnServerConfigurationName; set => this._p2SVpnServerConfigurationName = value; }

        /// <summary>Backing field for <see cref="PacketCaptureName" /> property.</summary>
        private string _packetCaptureName;

        /// <summary>The name of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PacketCaptureName { get => this._packetCaptureName; set => this._packetCaptureName = value; }

        /// <summary>Backing field for <see cref="PeeringName" /> property.</summary>
        private string _peeringName;

        /// <summary>The name of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PeeringName { get => this._peeringName; set => this._peeringName = value; }

        /// <summary>Backing field for <see cref="PolicyName" /> property.</summary>
        private string _policyName;

        /// <summary>The name of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PolicyName { get => this._policyName; set => this._policyName = value; }

        /// <summary>Backing field for <see cref="PredefinedPolicyName" /> property.</summary>
        private string _predefinedPolicyName;

        /// <summary>Name of Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PredefinedPolicyName { get => this._predefinedPolicyName; set => this._predefinedPolicyName = value; }

        /// <summary>Backing field for <see cref="ProbeName" /> property.</summary>
        private string _probeName;

        /// <summary>The name of the probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProbeName { get => this._probeName; set => this._probeName = value; }

        /// <summary>Backing field for <see cref="PublicIPAddressName" /> property.</summary>
        private string _publicIPAddressName;

        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PublicIPAddressName { get => this._publicIPAddressName; set => this._publicIPAddressName = value; }

        /// <summary>Backing field for <see cref="PublicIPPrefixName" /> property.</summary>
        private string _publicIPPrefixName;

        /// <summary>The name of the PublicIpPrefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PublicIPPrefixName { get => this._publicIPPrefixName; set => this._publicIPPrefixName = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>Backing field for <see cref="RouteFilterName" /> property.</summary>
        private string _routeFilterName;

        /// <summary>The name of the route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouteFilterName { get => this._routeFilterName; set => this._routeFilterName = value; }

        /// <summary>Backing field for <see cref="RouteName" /> property.</summary>
        private string _routeName;

        /// <summary>The name of the route.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouteName { get => this._routeName; set => this._routeName = value; }

        /// <summary>Backing field for <see cref="RouteTableName" /> property.</summary>
        private string _routeTableName;

        /// <summary>The name of the route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouteTableName { get => this._routeTableName; set => this._routeTableName = value; }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        /// <summary>The name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Backing field for <see cref="SecurityRuleName" /> property.</summary>
        private string _securityRuleName;

        /// <summary>The name of the security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecurityRuleName { get => this._securityRuleName; set => this._securityRuleName = value; }

        /// <summary>Backing field for <see cref="ServiceEndpointPolicyDefinitionName" /> property.</summary>
        private string _serviceEndpointPolicyDefinitionName;

        /// <summary>The name of the service endpoint policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceEndpointPolicyDefinitionName { get => this._serviceEndpointPolicyDefinitionName; set => this._serviceEndpointPolicyDefinitionName = value; }

        /// <summary>Backing field for <see cref="ServiceEndpointPolicyName" /> property.</summary>
        private string _serviceEndpointPolicyName;

        /// <summary>The name of the service endpoint policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceEndpointPolicyName { get => this._serviceEndpointPolicyName; set => this._serviceEndpointPolicyName = value; }

        /// <summary>Backing field for <see cref="SubnetName" /> property.</summary>
        private string _subnetName;

        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SubnetName { get => this._subnetName; set => this._subnetName = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part
        /// of the URI for every service call.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Backing field for <see cref="TapConfigurationName" /> property.</summary>
        private string _tapConfigurationName;

        /// <summary>The name of the tap configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TapConfigurationName { get => this._tapConfigurationName; set => this._tapConfigurationName = value; }

        /// <summary>Backing field for <see cref="TapName" /> property.</summary>
        private string _tapName;

        /// <summary>The name of the virtual network tap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TapName { get => this._tapName; set => this._tapName = value; }

        /// <summary>Backing field for <see cref="VirtualHubName" /> property.</summary>
        private string _virtualHubName;

        /// <summary>The name of the VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualHubName { get => this._virtualHubName; set => this._virtualHubName = value; }

        /// <summary>Backing field for <see cref="VirtualMachineScaleSetName" /> property.</summary>
        private string _virtualMachineScaleSetName;

        /// <summary>The name of the virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualMachineScaleSetName { get => this._virtualMachineScaleSetName; set => this._virtualMachineScaleSetName = value; }

        /// <summary>Backing field for <see cref="VirtualWanName" /> property.</summary>
        private string _virtualWanName;

        /// <summary>The name of the VirtualWAN being retrieved.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualWanName { get => this._virtualWanName; set => this._virtualWanName = value; }

        /// <summary>Backing field for <see cref="VirtualWanName1" /> property.</summary>
        private string _virtualWanName1;

        /// <summary>The name of the VirtualWAN for which configuration of all vpn-sites is needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualWanName1 { get => this._virtualWanName1; set => this._virtualWanName1 = value; }

        /// <summary>Backing field for <see cref="VirtualWanName2" /> property.</summary>
        private string _virtualWanName2;

        /// <summary>The name of the VirtualWan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualWanName2 { get => this._virtualWanName2; set => this._virtualWanName2 = value; }

        /// <summary>Backing field for <see cref="VirtualmachineIndex" /> property.</summary>
        private string _virtualmachineIndex;

        /// <summary>The virtual machine index.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VirtualmachineIndex { get => this._virtualmachineIndex; set => this._virtualmachineIndex = value; }

        /// <summary>Backing field for <see cref="VnetGatewayConnectionName" /> property.</summary>
        private string _vnetGatewayConnectionName;

        /// <summary>
        /// The name of the virtual network gateway connection for which the configuration script is generated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VnetGatewayConnectionName { get => this._vnetGatewayConnectionName; set => this._vnetGatewayConnectionName = value; }

        /// <summary>Backing field for <see cref="VnetGatewayName" /> property.</summary>
        private string _vnetGatewayName;

        /// <summary>The name of the virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VnetGatewayName { get => this._vnetGatewayName; set => this._vnetGatewayName = value; }

        /// <summary>Backing field for <see cref="VnetName" /> property.</summary>
        private string _vnetName;

        /// <summary>The name of the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VnetName { get => this._vnetName; set => this._vnetName = value; }

        /// <summary>Backing field for <see cref="VnetPeeringName" /> property.</summary>
        private string _vnetPeeringName;

        /// <summary>The name of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VnetPeeringName { get => this._vnetPeeringName; set => this._vnetPeeringName = value; }

        /// <summary>Backing field for <see cref="VpnSiteName" /> property.</summary>
        private string _vpnSiteName;

        /// <summary>The name of the VpnSite being retrieved.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string VpnSiteName { get => this._vpnSiteName; set => this._vpnSiteName = value; }

        /// <summary>Creates an new <see cref="NetworkIdentity" /> instance.</summary>
        public NetworkIdentity()
        {

        }
    }
    public partial interface INetworkIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name of the application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the application gateway.",
        SerializedName = @"applicationGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationGatewayName { get; set; }
        /// <summary>The name of the application security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the application security group.",
        SerializedName = @"applicationSecurityGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationSecurityGroupName { get; set; }
        /// <summary>The name of the authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the authorization.",
        SerializedName = @"authorizationName",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationName { get; set; }
        /// <summary>The name of the Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Firewall.",
        SerializedName = @"azureFirewallName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureFirewallName { get; set; }
        /// <summary>The name of the backend address pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the backend address pool.",
        SerializedName = @"backendAddressPoolName",
        PossibleTypes = new [] { typeof(string) })]
        string BackendAddressPoolName { get; set; }
        /// <summary>The name of the express route circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the express route circuit.",
        SerializedName = @"circuitName",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitName { get; set; }
        /// <summary>The name of the connection monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the connection monitor.",
        SerializedName = @"connectionMonitorName",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionMonitorName { get; set; }
        /// <summary>The name of the vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the vpn connection.",
        SerializedName = @"connectionName",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionName { get; set; }
        /// <summary>The name of the ExpressRouteCrossConnection (service key of the circuit).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the ExpressRouteCrossConnection (service key of the circuit).",
        SerializedName = @"crossConnectionName",
        PossibleTypes = new [] { typeof(string) })]
        string CrossConnectionName { get; set; }
        /// <summary>The name of the DDoS custom policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the DDoS custom policy.",
        SerializedName = @"ddosCustomPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string DdosCustomPolicyName { get; set; }
        /// <summary>The name of the DDoS protection plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the DDoS protection plan.",
        SerializedName = @"ddosProtectionPlanName",
        PossibleTypes = new [] { typeof(string) })]
        string DdosProtectionPlanName { get; set; }
        /// <summary>The name of the default security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the default security rule.",
        SerializedName = @"defaultSecurityRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultSecurityRuleName { get; set; }
        /// <summary>The path of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path of the device.",
        SerializedName = @"devicePath",
        PossibleTypes = new [] { typeof(string) })]
        string DevicePath { get; set; }
        /// <summary>The name of the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the ExpressRoute gateway.",
        SerializedName = @"expressRouteGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteGatewayName { get; set; }
        /// <summary>The name of the ExpressRoutePort resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the ExpressRoutePort resource.",
        SerializedName = @"expressRoutePortName",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRoutePortName { get; set; }
        /// <summary>The name of the frontend IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the frontend IP configuration.",
        SerializedName = @"frontendIPConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string FrontendIPConfigurationName { get; set; }
        /// <summary>The name of the gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the gateway.",
        SerializedName = @"gatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayName { get; set; }
        /// <summary>The name of the ip configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the ip configuration name.",
        SerializedName = @"ipConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string IPConfigurationName { get; set; }
        /// <summary>Resource identity path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource identity path",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the inbound nat rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the inbound nat rule.",
        SerializedName = @"inboundNatRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string InboundNatRuleName { get; set; }
        /// <summary>The name of the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the interface endpoint.",
        SerializedName = @"interfaceEndpointName",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointName { get; set; }
        /// <summary>The name of the ExpressRouteLink resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the ExpressRouteLink resource.",
        SerializedName = @"linkName",
        PossibleTypes = new [] { typeof(string) })]
        string LinkName { get; set; }
        /// <summary>The name of the load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the load balancer.",
        SerializedName = @"loadBalancerName",
        PossibleTypes = new [] { typeof(string) })]
        string LoadBalancerName { get; set; }
        /// <summary>The name of the load balancing rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the load balancing rule.",
        SerializedName = @"loadBalancingRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string LoadBalancingRuleName { get; set; }
        /// <summary>The name of the local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the local network gateway.",
        SerializedName = @"localNetworkGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGatewayName { get; set; }
        /// <summary>The location of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The location of the subnet.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Name of the requested ExpressRoutePort peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the requested ExpressRoutePort peering location.",
        SerializedName = @"locationName",
        PossibleTypes = new [] { typeof(string) })]
        string LocationName { get; set; }
        /// <summary>The name of the nat gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the nat gateway.",
        SerializedName = @"natGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string NatGatewayName { get; set; }
        /// <summary>The name of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the network interface.",
        SerializedName = @"networkInterfaceName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkInterfaceName { get; set; }
        /// <summary>The name of the NetworkProfile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the NetworkProfile.",
        SerializedName = @"networkProfileName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileName { get; set; }
        /// <summary>The name of the network watcher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the network watcher.",
        SerializedName = @"networkWatcherName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkWatcherName { get; set; }
        /// <summary>The name of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the network security group.",
        SerializedName = @"networkSecurityGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string NsgName { get; set; }
        /// <summary>The name of the outbound rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the outbound rule.",
        SerializedName = @"outboundRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string OutboundRuleName { get; set; }
        /// <summary>The name of the P2SVpnServerConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the P2SVpnServerConfiguration.",
        SerializedName = @"p2SVpnServerConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string P2SVpnServerConfigurationName { get; set; }
        /// <summary>The name of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the packet capture session.",
        SerializedName = @"packetCaptureName",
        PossibleTypes = new [] { typeof(string) })]
        string PacketCaptureName { get; set; }
        /// <summary>The name of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the peering.",
        SerializedName = @"peeringName",
        PossibleTypes = new [] { typeof(string) })]
        string PeeringName { get; set; }
        /// <summary>The name of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the policy",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyName { get; set; }
        /// <summary>Name of Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Ssl predefined policy.",
        SerializedName = @"predefinedPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string PredefinedPolicyName { get; set; }
        /// <summary>The name of the probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the probe.",
        SerializedName = @"probeName",
        PossibleTypes = new [] { typeof(string) })]
        string ProbeName { get; set; }
        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the subnet.",
        SerializedName = @"publicIpAddressName",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressName { get; set; }
        /// <summary>The name of the PublicIpPrefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the PublicIpPrefix.",
        SerializedName = @"publicIpPrefixName",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPPrefixName { get; set; }
        /// <summary>The name of the resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource group.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroupName { get; set; }
        /// <summary>The name of the route filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the route filter.",
        SerializedName = @"routeFilterName",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterName { get; set; }
        /// <summary>The name of the route.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the route.",
        SerializedName = @"routeName",
        PossibleTypes = new [] { typeof(string) })]
        string RouteName { get; set; }
        /// <summary>The name of the route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the route table.",
        SerializedName = @"routeTableName",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableName { get; set; }
        /// <summary>The name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the rule.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }
        /// <summary>The name of the security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the security rule.",
        SerializedName = @"securityRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string SecurityRuleName { get; set; }
        /// <summary>The name of the service endpoint policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the service endpoint policy definition.",
        SerializedName = @"serviceEndpointPolicyDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceEndpointPolicyDefinitionName { get; set; }
        /// <summary>The name of the service endpoint policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the service endpoint policy.",
        SerializedName = @"serviceEndpointPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceEndpointPolicyName { get; set; }
        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the subnet.",
        SerializedName = @"subnetName",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get; set; }
        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part
        /// of the URI for every service call.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }
        /// <summary>The name of the tap configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the tap configuration.",
        SerializedName = @"tapConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string TapConfigurationName { get; set; }
        /// <summary>The name of the virtual network tap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network tap.",
        SerializedName = @"tapName",
        PossibleTypes = new [] { typeof(string) })]
        string TapName { get; set; }
        /// <summary>The name of the VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VirtualHub.",
        SerializedName = @"virtualHubName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualHubName { get; set; }
        /// <summary>The name of the virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual machine scale set.",
        SerializedName = @"virtualMachineScaleSetName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineScaleSetName { get; set; }
        /// <summary>The name of the VirtualWAN being retrieved.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VirtualWAN being retrieved.",
        SerializedName = @"VirtualWANName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualWanName { get; set; }
        /// <summary>The name of the VirtualWAN for which configuration of all vpn-sites is needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VirtualWAN for which configuration of all vpn-sites is needed.",
        SerializedName = @"virtualWANName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualWanName1 { get; set; }
        /// <summary>The name of the VirtualWan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VirtualWan.",
        SerializedName = @"virtualWanName",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualWanName2 { get; set; }
        /// <summary>The virtual machine index.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The virtual machine index.",
        SerializedName = @"virtualmachineIndex",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualmachineIndex { get; set; }
        /// <summary>
        /// The name of the virtual network gateway connection for which the configuration script is generated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network gateway connection for which the configuration script is generated.",
        SerializedName = @"virtualNetworkGatewayConnectionName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetGatewayConnectionName { get; set; }
        /// <summary>The name of the virtual network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network gateway.",
        SerializedName = @"virtualNetworkGatewayName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetGatewayName { get; set; }
        /// <summary>The name of the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network.",
        SerializedName = @"virtualNetworkName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetName { get; set; }
        /// <summary>The name of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network peering.",
        SerializedName = @"virtualNetworkPeeringName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetPeeringName { get; set; }
        /// <summary>The name of the VpnSite being retrieved.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VpnSite being retrieved.",
        SerializedName = @"vpnSiteName",
        PossibleTypes = new [] { typeof(string) })]
        string VpnSiteName { get; set; }

    }
    internal partial interface INetworkIdentityInternal

    {
        /// <summary>The name of the application gateway.</summary>
        string ApplicationGatewayName { get; set; }
        /// <summary>The name of the application security group.</summary>
        string ApplicationSecurityGroupName { get; set; }
        /// <summary>The name of the authorization.</summary>
        string AuthorizationName { get; set; }
        /// <summary>The name of the Azure Firewall.</summary>
        string AzureFirewallName { get; set; }
        /// <summary>The name of the backend address pool.</summary>
        string BackendAddressPoolName { get; set; }
        /// <summary>The name of the express route circuit.</summary>
        string CircuitName { get; set; }
        /// <summary>The name of the connection monitor.</summary>
        string ConnectionMonitorName { get; set; }
        /// <summary>The name of the vpn connection.</summary>
        string ConnectionName { get; set; }
        /// <summary>The name of the ExpressRouteCrossConnection (service key of the circuit).</summary>
        string CrossConnectionName { get; set; }
        /// <summary>The name of the DDoS custom policy.</summary>
        string DdosCustomPolicyName { get; set; }
        /// <summary>The name of the DDoS protection plan.</summary>
        string DdosProtectionPlanName { get; set; }
        /// <summary>The name of the default security rule.</summary>
        string DefaultSecurityRuleName { get; set; }
        /// <summary>The path of the device.</summary>
        string DevicePath { get; set; }
        /// <summary>The name of the ExpressRoute gateway.</summary>
        string ExpressRouteGatewayName { get; set; }
        /// <summary>The name of the ExpressRoutePort resource.</summary>
        string ExpressRoutePortName { get; set; }
        /// <summary>The name of the frontend IP configuration.</summary>
        string FrontendIPConfigurationName { get; set; }
        /// <summary>The name of the gateway.</summary>
        string GatewayName { get; set; }
        /// <summary>The name of the ip configuration name.</summary>
        string IPConfigurationName { get; set; }
        /// <summary>Resource identity path</summary>
        string Id { get; set; }
        /// <summary>The name of the inbound nat rule.</summary>
        string InboundNatRuleName { get; set; }
        /// <summary>The name of the interface endpoint.</summary>
        string InterfaceEndpointName { get; set; }
        /// <summary>The name of the ExpressRouteLink resource.</summary>
        string LinkName { get; set; }
        /// <summary>The name of the load balancer.</summary>
        string LoadBalancerName { get; set; }
        /// <summary>The name of the load balancing rule.</summary>
        string LoadBalancingRuleName { get; set; }
        /// <summary>The name of the local network gateway.</summary>
        string LocalNetworkGatewayName { get; set; }
        /// <summary>The location of the subnet.</summary>
        string Location { get; set; }
        /// <summary>Name of the requested ExpressRoutePort peering location.</summary>
        string LocationName { get; set; }
        /// <summary>The name of the nat gateway.</summary>
        string NatGatewayName { get; set; }
        /// <summary>The name of the network interface.</summary>
        string NetworkInterfaceName { get; set; }
        /// <summary>The name of the NetworkProfile.</summary>
        string NetworkProfileName { get; set; }
        /// <summary>The name of the network watcher.</summary>
        string NetworkWatcherName { get; set; }
        /// <summary>The name of the network security group.</summary>
        string NsgName { get; set; }
        /// <summary>The name of the outbound rule.</summary>
        string OutboundRuleName { get; set; }
        /// <summary>The name of the P2SVpnServerConfiguration.</summary>
        string P2SVpnServerConfigurationName { get; set; }
        /// <summary>The name of the packet capture session.</summary>
        string PacketCaptureName { get; set; }
        /// <summary>The name of the peering.</summary>
        string PeeringName { get; set; }
        /// <summary>The name of the policy</summary>
        string PolicyName { get; set; }
        /// <summary>Name of Ssl predefined policy.</summary>
        string PredefinedPolicyName { get; set; }
        /// <summary>The name of the probe.</summary>
        string ProbeName { get; set; }
        /// <summary>The name of the subnet.</summary>
        string PublicIPAddressName { get; set; }
        /// <summary>The name of the PublicIpPrefix.</summary>
        string PublicIPPrefixName { get; set; }
        /// <summary>The name of the resource group.</summary>
        string ResourceGroupName { get; set; }
        /// <summary>The name of the route filter.</summary>
        string RouteFilterName { get; set; }
        /// <summary>The name of the route.</summary>
        string RouteName { get; set; }
        /// <summary>The name of the route table.</summary>
        string RouteTableName { get; set; }
        /// <summary>The name of the rule.</summary>
        string RuleName { get; set; }
        /// <summary>The name of the security rule.</summary>
        string SecurityRuleName { get; set; }
        /// <summary>The name of the service endpoint policy definition.</summary>
        string ServiceEndpointPolicyDefinitionName { get; set; }
        /// <summary>The name of the service endpoint policy.</summary>
        string ServiceEndpointPolicyName { get; set; }
        /// <summary>The name of the subnet.</summary>
        string SubnetName { get; set; }
        /// <summary>
        /// The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part
        /// of the URI for every service call.
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>The name of the tap configuration.</summary>
        string TapConfigurationName { get; set; }
        /// <summary>The name of the virtual network tap.</summary>
        string TapName { get; set; }
        /// <summary>The name of the VirtualHub.</summary>
        string VirtualHubName { get; set; }
        /// <summary>The name of the virtual machine scale set.</summary>
        string VirtualMachineScaleSetName { get; set; }
        /// <summary>The name of the VirtualWAN being retrieved.</summary>
        string VirtualWanName { get; set; }
        /// <summary>The name of the VirtualWAN for which configuration of all vpn-sites is needed.</summary>
        string VirtualWanName1 { get; set; }
        /// <summary>The name of the VirtualWan.</summary>
        string VirtualWanName2 { get; set; }
        /// <summary>The virtual machine index.</summary>
        string VirtualmachineIndex { get; set; }
        /// <summary>
        /// The name of the virtual network gateway connection for which the configuration script is generated.
        /// </summary>
        string VnetGatewayConnectionName { get; set; }
        /// <summary>The name of the virtual network gateway.</summary>
        string VnetGatewayName { get; set; }
        /// <summary>The name of the virtual network.</summary>
        string VnetName { get; set; }
        /// <summary>The name of the virtual network peering.</summary>
        string VnetPeeringName { get; set; }
        /// <summary>The name of the VpnSite being retrieved.</summary>
        string VpnSiteName { get; set; }

    }
}