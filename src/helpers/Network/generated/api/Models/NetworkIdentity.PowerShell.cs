namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>FIXME: Class NetworkIdentity is MISSING DESCRIPTION</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkIdentityTypeConverter))]
    public partial class NetworkIdentity
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.NetworkIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.NetworkIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkIdentity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkIdentity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.NetworkIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkIdentity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName = (string) content.GetValueForProperty("VirtualWanName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationGatewayName = (string) content.GetValueForProperty("ApplicationGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationSecurityGroupName = (string) content.GetValueForProperty("ApplicationSecurityGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationSecurityGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AuthorizationName = (string) content.GetValueForProperty("AuthorizationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AuthorizationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AzureFirewallName = (string) content.GetValueForProperty("AzureFirewallName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AzureFirewallName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).BackendAddressPoolName = (string) content.GetValueForProperty("BackendAddressPoolName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).BackendAddressPoolName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CircuitName = (string) content.GetValueForProperty("CircuitName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CircuitName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionMonitorName = (string) content.GetValueForProperty("ConnectionMonitorName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionMonitorName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionName = (string) content.GetValueForProperty("ConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CrossConnectionName = (string) content.GetValueForProperty("CrossConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CrossConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosCustomPolicyName = (string) content.GetValueForProperty("DdosCustomPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosCustomPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosProtectionPlanName = (string) content.GetValueForProperty("DdosProtectionPlanName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosProtectionPlanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DefaultSecurityRuleName = (string) content.GetValueForProperty("DefaultSecurityRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DefaultSecurityRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DevicePath = (string) content.GetValueForProperty("DevicePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DevicePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRouteGatewayName = (string) content.GetValueForProperty("ExpressRouteGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRouteGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRoutePortName = (string) content.GetValueForProperty("ExpressRoutePortName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRoutePortName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).FrontendIPConfigurationName = (string) content.GetValueForProperty("FrontendIPConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).FrontendIPConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).GatewayName = (string) content.GetValueForProperty("GatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).GatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InboundNatRuleName = (string) content.GetValueForProperty("InboundNatRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InboundNatRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InterfaceEndpointName = (string) content.GetValueForProperty("InterfaceEndpointName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InterfaceEndpointName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).IPConfigurationName = (string) content.GetValueForProperty("IPConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).IPConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LinkName = (string) content.GetValueForProperty("LinkName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LinkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancerName = (string) content.GetValueForProperty("LoadBalancerName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancingRuleName = (string) content.GetValueForProperty("LoadBalancingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocalNetworkGatewayName = (string) content.GetValueForProperty("LocalNetworkGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocalNetworkGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocationName = (string) content.GetValueForProperty("LocationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NatGatewayName = (string) content.GetValueForProperty("NatGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NatGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkInterfaceName = (string) content.GetValueForProperty("NetworkInterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkInterfaceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkProfileName = (string) content.GetValueForProperty("NetworkProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkWatcherName = (string) content.GetValueForProperty("NetworkWatcherName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkWatcherName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).OutboundRuleName = (string) content.GetValueForProperty("OutboundRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).OutboundRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).P2SVpnServerConfigurationName = (string) content.GetValueForProperty("P2SVpnServerConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).P2SVpnServerConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PacketCaptureName = (string) content.GetValueForProperty("PacketCaptureName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PacketCaptureName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PeeringName = (string) content.GetValueForProperty("PeeringName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PeeringName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PolicyName = (string) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PredefinedPolicyName = (string) content.GetValueForProperty("PredefinedPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PredefinedPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ProbeName = (string) content.GetValueForProperty("ProbeName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ProbeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPAddressName = (string) content.GetValueForProperty("PublicIPAddressName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPAddressName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPPrefixName = (string) content.GetValueForProperty("PublicIPPrefixName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPPrefixName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteFilterName = (string) content.GetValueForProperty("RouteFilterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteFilterName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteName = (string) content.GetValueForProperty("RouteName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteTableName = (string) content.GetValueForProperty("RouteTableName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteTableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RuleName = (string) content.GetValueForProperty("RuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SecurityRuleName = (string) content.GetValueForProperty("SecurityRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SecurityRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyDefinitionName = (string) content.GetValueForProperty("ServiceEndpointPolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyDefinitionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyName = (string) content.GetValueForProperty("ServiceEndpointPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapConfigurationName = (string) content.GetValueForProperty("TapConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapName = (string) content.GetValueForProperty("TapName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualHubName = (string) content.GetValueForProperty("VirtualHubName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualHubName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualMachineScaleSetName = (string) content.GetValueForProperty("VirtualMachineScaleSetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualMachineScaleSetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayConnectionName = (string) content.GetValueForProperty("VnetGatewayConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayName = (string) content.GetValueForProperty("VnetGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetName = (string) content.GetValueForProperty("VnetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetPeeringName = (string) content.GetValueForProperty("VnetPeeringName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetPeeringName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName1 = (string) content.GetValueForProperty("VirtualWanName1",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName2 = (string) content.GetValueForProperty("VirtualWanName2",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualmachineIndex = (string) content.GetValueForProperty("VirtualmachineIndex",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualmachineIndex, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VpnSiteName = (string) content.GetValueForProperty("VpnSiteName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VpnSiteName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.NetworkIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkIdentity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName = (string) content.GetValueForProperty("VirtualWanName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationGatewayName = (string) content.GetValueForProperty("ApplicationGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationSecurityGroupName = (string) content.GetValueForProperty("ApplicationSecurityGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ApplicationSecurityGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AuthorizationName = (string) content.GetValueForProperty("AuthorizationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AuthorizationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AzureFirewallName = (string) content.GetValueForProperty("AzureFirewallName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).AzureFirewallName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).BackendAddressPoolName = (string) content.GetValueForProperty("BackendAddressPoolName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).BackendAddressPoolName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CircuitName = (string) content.GetValueForProperty("CircuitName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CircuitName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionMonitorName = (string) content.GetValueForProperty("ConnectionMonitorName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionMonitorName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionName = (string) content.GetValueForProperty("ConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CrossConnectionName = (string) content.GetValueForProperty("CrossConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).CrossConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosCustomPolicyName = (string) content.GetValueForProperty("DdosCustomPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosCustomPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosProtectionPlanName = (string) content.GetValueForProperty("DdosProtectionPlanName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DdosProtectionPlanName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DefaultSecurityRuleName = (string) content.GetValueForProperty("DefaultSecurityRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DefaultSecurityRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DevicePath = (string) content.GetValueForProperty("DevicePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).DevicePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRouteGatewayName = (string) content.GetValueForProperty("ExpressRouteGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRouteGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRoutePortName = (string) content.GetValueForProperty("ExpressRoutePortName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ExpressRoutePortName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).FrontendIPConfigurationName = (string) content.GetValueForProperty("FrontendIPConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).FrontendIPConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).GatewayName = (string) content.GetValueForProperty("GatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).GatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InboundNatRuleName = (string) content.GetValueForProperty("InboundNatRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InboundNatRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InterfaceEndpointName = (string) content.GetValueForProperty("InterfaceEndpointName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).InterfaceEndpointName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).IPConfigurationName = (string) content.GetValueForProperty("IPConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).IPConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LinkName = (string) content.GetValueForProperty("LinkName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LinkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancerName = (string) content.GetValueForProperty("LoadBalancerName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancingRuleName = (string) content.GetValueForProperty("LoadBalancingRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LoadBalancingRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocalNetworkGatewayName = (string) content.GetValueForProperty("LocalNetworkGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocalNetworkGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocationName = (string) content.GetValueForProperty("LocationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).LocationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NatGatewayName = (string) content.GetValueForProperty("NatGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NatGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkInterfaceName = (string) content.GetValueForProperty("NetworkInterfaceName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkInterfaceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkProfileName = (string) content.GetValueForProperty("NetworkProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkWatcherName = (string) content.GetValueForProperty("NetworkWatcherName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).NetworkWatcherName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).OutboundRuleName = (string) content.GetValueForProperty("OutboundRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).OutboundRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).P2SVpnServerConfigurationName = (string) content.GetValueForProperty("P2SVpnServerConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).P2SVpnServerConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PacketCaptureName = (string) content.GetValueForProperty("PacketCaptureName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PacketCaptureName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PeeringName = (string) content.GetValueForProperty("PeeringName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PeeringName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PolicyName = (string) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PredefinedPolicyName = (string) content.GetValueForProperty("PredefinedPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PredefinedPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ProbeName = (string) content.GetValueForProperty("ProbeName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ProbeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPAddressName = (string) content.GetValueForProperty("PublicIPAddressName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPAddressName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPPrefixName = (string) content.GetValueForProperty("PublicIPPrefixName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).PublicIPPrefixName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteFilterName = (string) content.GetValueForProperty("RouteFilterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteFilterName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteName = (string) content.GetValueForProperty("RouteName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteTableName = (string) content.GetValueForProperty("RouteTableName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RouteTableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RuleName = (string) content.GetValueForProperty("RuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).RuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SecurityRuleName = (string) content.GetValueForProperty("SecurityRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SecurityRuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyDefinitionName = (string) content.GetValueForProperty("ServiceEndpointPolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyDefinitionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyName = (string) content.GetValueForProperty("ServiceEndpointPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).ServiceEndpointPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapConfigurationName = (string) content.GetValueForProperty("TapConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapName = (string) content.GetValueForProperty("TapName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).TapName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualHubName = (string) content.GetValueForProperty("VirtualHubName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualHubName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualMachineScaleSetName = (string) content.GetValueForProperty("VirtualMachineScaleSetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualMachineScaleSetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayConnectionName = (string) content.GetValueForProperty("VnetGatewayConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayName = (string) content.GetValueForProperty("VnetGatewayName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetGatewayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetName = (string) content.GetValueForProperty("VnetName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetPeeringName = (string) content.GetValueForProperty("VnetPeeringName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VnetPeeringName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName1 = (string) content.GetValueForProperty("VirtualWanName1",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName2 = (string) content.GetValueForProperty("VirtualWanName2",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualWanName2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualmachineIndex = (string) content.GetValueForProperty("VirtualmachineIndex",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VirtualmachineIndex, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VpnSiteName = (string) content.GetValueForProperty("VpnSiteName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentityInternal)this).VpnSiteName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// FIXME: Interface INetworkIdentity is MISSING DESCRIPTION
    [System.ComponentModel.TypeConverter(typeof(NetworkIdentityTypeConverter))]
    public partial interface INetworkIdentity

    {

    }
}