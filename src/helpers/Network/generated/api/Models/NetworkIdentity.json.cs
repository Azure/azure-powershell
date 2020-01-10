namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class NetworkIdentity
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new NetworkIdentity(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="NetworkIdentity" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NetworkIdentity(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_virtualWanName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("VirtualWANName"), out var __jsonVirtualWanName) ? (string)__jsonVirtualWanName : (string)VirtualWanName;}
            {_applicationGatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("applicationGatewayName"), out var __jsonApplicationGatewayName) ? (string)__jsonApplicationGatewayName : (string)ApplicationGatewayName;}
            {_applicationSecurityGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("applicationSecurityGroupName"), out var __jsonApplicationSecurityGroupName) ? (string)__jsonApplicationSecurityGroupName : (string)ApplicationSecurityGroupName;}
            {_authorizationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("authorizationName"), out var __jsonAuthorizationName) ? (string)__jsonAuthorizationName : (string)AuthorizationName;}
            {_azureFirewallName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("azureFirewallName"), out var __jsonAzureFirewallName) ? (string)__jsonAzureFirewallName : (string)AzureFirewallName;}
            {_backendAddressPoolName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("backendAddressPoolName"), out var __jsonBackendAddressPoolName) ? (string)__jsonBackendAddressPoolName : (string)BackendAddressPoolName;}
            {_circuitName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("circuitName"), out var __jsonCircuitName) ? (string)__jsonCircuitName : (string)CircuitName;}
            {_connectionMonitorName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("connectionMonitorName"), out var __jsonConnectionMonitorName) ? (string)__jsonConnectionMonitorName : (string)ConnectionMonitorName;}
            {_connectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("connectionName"), out var __jsonConnectionName) ? (string)__jsonConnectionName : (string)ConnectionName;}
            {_crossConnectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("crossConnectionName"), out var __jsonCrossConnectionName) ? (string)__jsonCrossConnectionName : (string)CrossConnectionName;}
            {_ddosCustomPolicyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("ddosCustomPolicyName"), out var __jsonDdosCustomPolicyName) ? (string)__jsonDdosCustomPolicyName : (string)DdosCustomPolicyName;}
            {_ddosProtectionPlanName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("ddosProtectionPlanName"), out var __jsonDdosProtectionPlanName) ? (string)__jsonDdosProtectionPlanName : (string)DdosProtectionPlanName;}
            {_defaultSecurityRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("defaultSecurityRuleName"), out var __jsonDefaultSecurityRuleName) ? (string)__jsonDefaultSecurityRuleName : (string)DefaultSecurityRuleName;}
            {_devicePath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("devicePath"), out var __jsonDevicePath) ? (string)__jsonDevicePath : (string)DevicePath;}
            {_expressRouteGatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("expressRouteGatewayName"), out var __jsonExpressRouteGatewayName) ? (string)__jsonExpressRouteGatewayName : (string)ExpressRouteGatewayName;}
            {_expressRoutePortName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("expressRoutePortName"), out var __jsonExpressRoutePortName) ? (string)__jsonExpressRoutePortName : (string)ExpressRoutePortName;}
            {_frontendIPConfigurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("frontendIPConfigurationName"), out var __jsonFrontendIPConfigurationName) ? (string)__jsonFrontendIPConfigurationName : (string)FrontendIPConfigurationName;}
            {_gatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("gatewayName"), out var __jsonGatewayName) ? (string)__jsonGatewayName : (string)GatewayName;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_inboundNatRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("inboundNatRuleName"), out var __jsonInboundNatRuleName) ? (string)__jsonInboundNatRuleName : (string)InboundNatRuleName;}
            {_interfaceEndpointName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("interfaceEndpointName"), out var __jsonInterfaceEndpointName) ? (string)__jsonInterfaceEndpointName : (string)InterfaceEndpointName;}
            {_iPConfigurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("ipConfigurationName"), out var __jsonIPConfigurationName) ? (string)__jsonIPConfigurationName : (string)IPConfigurationName;}
            {_linkName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("linkName"), out var __jsonLinkName) ? (string)__jsonLinkName : (string)LinkName;}
            {_loadBalancerName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("loadBalancerName"), out var __jsonLoadBalancerName) ? (string)__jsonLoadBalancerName : (string)LoadBalancerName;}
            {_loadBalancingRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("loadBalancingRuleName"), out var __jsonLoadBalancingRuleName) ? (string)__jsonLoadBalancingRuleName : (string)LoadBalancingRuleName;}
            {_localNetworkGatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("localNetworkGatewayName"), out var __jsonLocalNetworkGatewayName) ? (string)__jsonLocalNetworkGatewayName : (string)LocalNetworkGatewayName;}
            {_location = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("location"), out var __jsonLocation) ? (string)__jsonLocation : (string)Location;}
            {_locationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("locationName"), out var __jsonLocationName) ? (string)__jsonLocationName : (string)LocationName;}
            {_natGatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("natGatewayName"), out var __jsonNatGatewayName) ? (string)__jsonNatGatewayName : (string)NatGatewayName;}
            {_networkInterfaceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("networkInterfaceName"), out var __jsonNetworkInterfaceName) ? (string)__jsonNetworkInterfaceName : (string)NetworkInterfaceName;}
            {_networkProfileName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("networkProfileName"), out var __jsonNetworkProfileName) ? (string)__jsonNetworkProfileName : (string)NetworkProfileName;}
            {_nsgName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("networkSecurityGroupName"), out var __jsonNetworkSecurityGroupName) ? (string)__jsonNetworkSecurityGroupName : (string)NsgName;}
            {_networkWatcherName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("networkWatcherName"), out var __jsonNetworkWatcherName) ? (string)__jsonNetworkWatcherName : (string)NetworkWatcherName;}
            {_outboundRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("outboundRuleName"), out var __jsonOutboundRuleName) ? (string)__jsonOutboundRuleName : (string)OutboundRuleName;}
            {_p2SVpnServerConfigurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("p2SVpnServerConfigurationName"), out var __jsonP2SVpnServerConfigurationName) ? (string)__jsonP2SVpnServerConfigurationName : (string)P2SVpnServerConfigurationName;}
            {_packetCaptureName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("packetCaptureName"), out var __jsonPacketCaptureName) ? (string)__jsonPacketCaptureName : (string)PacketCaptureName;}
            {_peeringName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("peeringName"), out var __jsonPeeringName) ? (string)__jsonPeeringName : (string)PeeringName;}
            {_policyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("policyName"), out var __jsonPolicyName) ? (string)__jsonPolicyName : (string)PolicyName;}
            {_predefinedPolicyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("predefinedPolicyName"), out var __jsonPredefinedPolicyName) ? (string)__jsonPredefinedPolicyName : (string)PredefinedPolicyName;}
            {_probeName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("probeName"), out var __jsonProbeName) ? (string)__jsonProbeName : (string)ProbeName;}
            {_publicIPAddressName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("publicIpAddressName"), out var __jsonPublicIPAddressName) ? (string)__jsonPublicIPAddressName : (string)PublicIPAddressName;}
            {_publicIPPrefixName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("publicIpPrefixName"), out var __jsonPublicIPPrefixName) ? (string)__jsonPublicIPPrefixName : (string)PublicIPPrefixName;}
            {_resourceGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("resourceGroupName"), out var __jsonResourceGroupName) ? (string)__jsonResourceGroupName : (string)ResourceGroupName;}
            {_routeFilterName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("routeFilterName"), out var __jsonRouteFilterName) ? (string)__jsonRouteFilterName : (string)RouteFilterName;}
            {_routeName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("routeName"), out var __jsonRouteName) ? (string)__jsonRouteName : (string)RouteName;}
            {_routeTableName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("routeTableName"), out var __jsonRouteTableName) ? (string)__jsonRouteTableName : (string)RouteTableName;}
            {_ruleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("ruleName"), out var __jsonRuleName) ? (string)__jsonRuleName : (string)RuleName;}
            {_securityRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("securityRuleName"), out var __jsonSecurityRuleName) ? (string)__jsonSecurityRuleName : (string)SecurityRuleName;}
            {_serviceEndpointPolicyDefinitionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("serviceEndpointPolicyDefinitionName"), out var __jsonServiceEndpointPolicyDefinitionName) ? (string)__jsonServiceEndpointPolicyDefinitionName : (string)ServiceEndpointPolicyDefinitionName;}
            {_serviceEndpointPolicyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("serviceEndpointPolicyName"), out var __jsonServiceEndpointPolicyName) ? (string)__jsonServiceEndpointPolicyName : (string)ServiceEndpointPolicyName;}
            {_subnetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("subnetName"), out var __jsonSubnetName) ? (string)__jsonSubnetName : (string)SubnetName;}
            {_subscriptionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("subscriptionId"), out var __jsonSubscriptionId) ? (string)__jsonSubscriptionId : (string)SubscriptionId;}
            {_tapConfigurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("tapConfigurationName"), out var __jsonTapConfigurationName) ? (string)__jsonTapConfigurationName : (string)TapConfigurationName;}
            {_tapName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("tapName"), out var __jsonTapName) ? (string)__jsonTapName : (string)TapName;}
            {_virtualHubName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualHubName"), out var __jsonVirtualHubName) ? (string)__jsonVirtualHubName : (string)VirtualHubName;}
            {_virtualMachineScaleSetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualMachineScaleSetName"), out var __jsonVirtualMachineScaleSetName) ? (string)__jsonVirtualMachineScaleSetName : (string)VirtualMachineScaleSetName;}
            {_vnetGatewayConnectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualNetworkGatewayConnectionName"), out var __jsonVirtualNetworkGatewayConnectionName) ? (string)__jsonVirtualNetworkGatewayConnectionName : (string)VnetGatewayConnectionName;}
            {_vnetGatewayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualNetworkGatewayName"), out var __jsonVirtualNetworkGatewayName) ? (string)__jsonVirtualNetworkGatewayName : (string)VnetGatewayName;}
            {_vnetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualNetworkName"), out var __jsonVirtualNetworkName) ? (string)__jsonVirtualNetworkName : (string)VnetName;}
            {_vnetPeeringName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualNetworkPeeringName"), out var __jsonVirtualNetworkPeeringName) ? (string)__jsonVirtualNetworkPeeringName : (string)VnetPeeringName;}
            {_virtualWanName1 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualWANName"), out var __jsonVirtualWanName) ? (string)__jsonVirtualWanName : (string)VirtualWanName1;}
            {_virtualWanName2 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualWanName"), out var __jsonVirtualWanName) ? (string)__jsonVirtualWanName : (string)VirtualWanName2;}
            {_virtualmachineIndex = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("virtualmachineIndex"), out var __jsonVirtualmachineIndex) ? (string)__jsonVirtualmachineIndex : (string)VirtualmachineIndex;}
            {_vpnSiteName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("vpnSiteName"), out var __jsonVpnSiteName) ? (string)__jsonVpnSiteName : (string)VpnSiteName;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NetworkIdentity" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NetworkIdentity" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._virtualWanName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualWanName.ToString()) : null, "VirtualWANName" ,container.Add );
            AddIf( null != (((object)this._applicationGatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._applicationGatewayName.ToString()) : null, "applicationGatewayName" ,container.Add );
            AddIf( null != (((object)this._applicationSecurityGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._applicationSecurityGroupName.ToString()) : null, "applicationSecurityGroupName" ,container.Add );
            AddIf( null != (((object)this._authorizationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._authorizationName.ToString()) : null, "authorizationName" ,container.Add );
            AddIf( null != (((object)this._azureFirewallName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._azureFirewallName.ToString()) : null, "azureFirewallName" ,container.Add );
            AddIf( null != (((object)this._backendAddressPoolName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._backendAddressPoolName.ToString()) : null, "backendAddressPoolName" ,container.Add );
            AddIf( null != (((object)this._circuitName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._circuitName.ToString()) : null, "circuitName" ,container.Add );
            AddIf( null != (((object)this._connectionMonitorName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._connectionMonitorName.ToString()) : null, "connectionMonitorName" ,container.Add );
            AddIf( null != (((object)this._connectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._connectionName.ToString()) : null, "connectionName" ,container.Add );
            AddIf( null != (((object)this._crossConnectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._crossConnectionName.ToString()) : null, "crossConnectionName" ,container.Add );
            AddIf( null != (((object)this._ddosCustomPolicyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._ddosCustomPolicyName.ToString()) : null, "ddosCustomPolicyName" ,container.Add );
            AddIf( null != (((object)this._ddosProtectionPlanName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._ddosProtectionPlanName.ToString()) : null, "ddosProtectionPlanName" ,container.Add );
            AddIf( null != (((object)this._defaultSecurityRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._defaultSecurityRuleName.ToString()) : null, "defaultSecurityRuleName" ,container.Add );
            AddIf( null != (((object)this._devicePath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._devicePath.ToString()) : null, "devicePath" ,container.Add );
            AddIf( null != (((object)this._expressRouteGatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._expressRouteGatewayName.ToString()) : null, "expressRouteGatewayName" ,container.Add );
            AddIf( null != (((object)this._expressRoutePortName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._expressRoutePortName.ToString()) : null, "expressRoutePortName" ,container.Add );
            AddIf( null != (((object)this._frontendIPConfigurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._frontendIPConfigurationName.ToString()) : null, "frontendIPConfigurationName" ,container.Add );
            AddIf( null != (((object)this._gatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._gatewayName.ToString()) : null, "gatewayName" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AddIf( null != (((object)this._inboundNatRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._inboundNatRuleName.ToString()) : null, "inboundNatRuleName" ,container.Add );
            AddIf( null != (((object)this._interfaceEndpointName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._interfaceEndpointName.ToString()) : null, "interfaceEndpointName" ,container.Add );
            AddIf( null != (((object)this._iPConfigurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._iPConfigurationName.ToString()) : null, "ipConfigurationName" ,container.Add );
            AddIf( null != (((object)this._linkName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._linkName.ToString()) : null, "linkName" ,container.Add );
            AddIf( null != (((object)this._loadBalancerName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._loadBalancerName.ToString()) : null, "loadBalancerName" ,container.Add );
            AddIf( null != (((object)this._loadBalancingRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._loadBalancingRuleName.ToString()) : null, "loadBalancingRuleName" ,container.Add );
            AddIf( null != (((object)this._localNetworkGatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._localNetworkGatewayName.ToString()) : null, "localNetworkGatewayName" ,container.Add );
            AddIf( null != (((object)this._location)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._location.ToString()) : null, "location" ,container.Add );
            AddIf( null != (((object)this._locationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._locationName.ToString()) : null, "locationName" ,container.Add );
            AddIf( null != (((object)this._natGatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._natGatewayName.ToString()) : null, "natGatewayName" ,container.Add );
            AddIf( null != (((object)this._networkInterfaceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._networkInterfaceName.ToString()) : null, "networkInterfaceName" ,container.Add );
            AddIf( null != (((object)this._networkProfileName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._networkProfileName.ToString()) : null, "networkProfileName" ,container.Add );
            AddIf( null != (((object)this._nsgName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._nsgName.ToString()) : null, "networkSecurityGroupName" ,container.Add );
            AddIf( null != (((object)this._networkWatcherName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._networkWatcherName.ToString()) : null, "networkWatcherName" ,container.Add );
            AddIf( null != (((object)this._outboundRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._outboundRuleName.ToString()) : null, "outboundRuleName" ,container.Add );
            AddIf( null != (((object)this._p2SVpnServerConfigurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._p2SVpnServerConfigurationName.ToString()) : null, "p2SVpnServerConfigurationName" ,container.Add );
            AddIf( null != (((object)this._packetCaptureName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._packetCaptureName.ToString()) : null, "packetCaptureName" ,container.Add );
            AddIf( null != (((object)this._peeringName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._peeringName.ToString()) : null, "peeringName" ,container.Add );
            AddIf( null != (((object)this._policyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._policyName.ToString()) : null, "policyName" ,container.Add );
            AddIf( null != (((object)this._predefinedPolicyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._predefinedPolicyName.ToString()) : null, "predefinedPolicyName" ,container.Add );
            AddIf( null != (((object)this._probeName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._probeName.ToString()) : null, "probeName" ,container.Add );
            AddIf( null != (((object)this._publicIPAddressName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._publicIPAddressName.ToString()) : null, "publicIpAddressName" ,container.Add );
            AddIf( null != (((object)this._publicIPPrefixName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._publicIPPrefixName.ToString()) : null, "publicIpPrefixName" ,container.Add );
            AddIf( null != (((object)this._resourceGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._resourceGroupName.ToString()) : null, "resourceGroupName" ,container.Add );
            AddIf( null != (((object)this._routeFilterName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._routeFilterName.ToString()) : null, "routeFilterName" ,container.Add );
            AddIf( null != (((object)this._routeName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._routeName.ToString()) : null, "routeName" ,container.Add );
            AddIf( null != (((object)this._routeTableName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._routeTableName.ToString()) : null, "routeTableName" ,container.Add );
            AddIf( null != (((object)this._ruleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._ruleName.ToString()) : null, "ruleName" ,container.Add );
            AddIf( null != (((object)this._securityRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._securityRuleName.ToString()) : null, "securityRuleName" ,container.Add );
            AddIf( null != (((object)this._serviceEndpointPolicyDefinitionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._serviceEndpointPolicyDefinitionName.ToString()) : null, "serviceEndpointPolicyDefinitionName" ,container.Add );
            AddIf( null != (((object)this._serviceEndpointPolicyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._serviceEndpointPolicyName.ToString()) : null, "serviceEndpointPolicyName" ,container.Add );
            AddIf( null != (((object)this._subnetName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._subnetName.ToString()) : null, "subnetName" ,container.Add );
            AddIf( null != (((object)this._subscriptionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._subscriptionId.ToString()) : null, "subscriptionId" ,container.Add );
            AddIf( null != (((object)this._tapConfigurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._tapConfigurationName.ToString()) : null, "tapConfigurationName" ,container.Add );
            AddIf( null != (((object)this._tapName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._tapName.ToString()) : null, "tapName" ,container.Add );
            AddIf( null != (((object)this._virtualHubName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualHubName.ToString()) : null, "virtualHubName" ,container.Add );
            AddIf( null != (((object)this._virtualMachineScaleSetName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualMachineScaleSetName.ToString()) : null, "virtualMachineScaleSetName" ,container.Add );
            AddIf( null != (((object)this._vnetGatewayConnectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._vnetGatewayConnectionName.ToString()) : null, "virtualNetworkGatewayConnectionName" ,container.Add );
            AddIf( null != (((object)this._vnetGatewayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._vnetGatewayName.ToString()) : null, "virtualNetworkGatewayName" ,container.Add );
            AddIf( null != (((object)this._vnetName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._vnetName.ToString()) : null, "virtualNetworkName" ,container.Add );
            AddIf( null != (((object)this._vnetPeeringName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._vnetPeeringName.ToString()) : null, "virtualNetworkPeeringName" ,container.Add );
            AddIf( null != (((object)this._virtualWanName1)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualWanName1.ToString()) : null, "virtualWANName" ,container.Add );
            AddIf( null != (((object)this._virtualWanName2)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualWanName2.ToString()) : null, "virtualWanName" ,container.Add );
            AddIf( null != (((object)this._virtualmachineIndex)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._virtualmachineIndex.ToString()) : null, "virtualmachineIndex" ,container.Add );
            AddIf( null != (((object)this._vpnSiteName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._vpnSiteName.ToString()) : null, "vpnSiteName" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}