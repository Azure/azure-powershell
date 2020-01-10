namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters for VirtualHub</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualHubPropertiesTypeConverter))]
    public partial class VirtualHubProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualHubProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualHubProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualHubProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualHubProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("ExpressRouteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable) content.GetValueForProperty("RouteTable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTable, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VpnGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VnetConnection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[]) content.GetValueForProperty("VnetConnection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VnetConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HubVirtualNetworkConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGatewayId = (string) content.GetValueForProperty("ExpressRouteGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGatewayId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGatewayId = (string) content.GetValueForProperty("P2SVpnGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGatewayId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTableRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[]) content.GetValueForProperty("RouteTableRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTableRoute, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWanId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGatewayId = (string) content.GetValueForProperty("VpnGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGatewayId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualHubProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("ExpressRouteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable) content.GetValueForProperty("RouteTable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTable, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGateway = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VpnGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGateway, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VnetConnection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[]) content.GetValueForProperty("VnetConnection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VnetConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HubVirtualNetworkConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGatewayId = (string) content.GetValueForProperty("ExpressRouteGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).ExpressRouteGatewayId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGatewayId = (string) content.GetValueForProperty("P2SVpnGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).P2SVpnGatewayId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTableRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[]) content.GetValueForProperty("RouteTableRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).RouteTableRoute, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VirtualWanId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGatewayId = (string) content.GetValueForProperty("VpnGatewayId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal)this).VpnGatewayId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters for VirtualHub
    [System.ComponentModel.TypeConverter(typeof(VirtualHubPropertiesTypeConverter))]
    public partial interface IVirtualHubProperties

    {

    }
}