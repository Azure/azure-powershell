namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of the virtual network peering.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringPropertiesFormatTypeConverter))]
    public partial class VirtualNetworkPeeringPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkPeeringPropertiesFormat" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualNetworkPeeringPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("RemoteVnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVnetAccess = (bool?) content.GetValueForProperty("AllowVnetAccess",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVnetAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnetId = (string) content.GetValueForProperty("RemoteVnetId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnetId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualNetworkPeeringPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("RemoteVnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVnetAccess = (bool?) content.GetValueForProperty("AllowVnetAccess",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVnetAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnetId = (string) content.GetValueForProperty("RemoteVnetId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVnetId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Properties of the virtual network peering.
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringPropertiesFormatTypeConverter))]
    public partial interface IVirtualNetworkPeeringPropertiesFormat

    {

    }
}