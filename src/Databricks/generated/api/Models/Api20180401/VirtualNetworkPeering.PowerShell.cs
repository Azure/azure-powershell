namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.PowerShell;

    /// <summary>Peerings in a VirtualNetwork resource</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringTypeConverter))]
    public partial class VirtualNetworkPeering
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeering"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkPeering(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeering"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkPeering(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkPeering" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeering"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualNetworkPeering(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeering"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualNetworkPeering(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Peerings in a VirtualNetwork resource
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringTypeConverter))]
    public partial interface IVirtualNetworkPeering

    {

    }
}