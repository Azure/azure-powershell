namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.PowerShell;

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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkPeeringPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkPeeringPropertiesFormat" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("DatabricksAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork) content.GetValueForProperty("DatabricksVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabricksVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace) content.GetValueForProperty("RemoteAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork) content.GetValueForProperty("RemoteVirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic = (bool?) content.GetValueForProperty("AllowForwardedTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowForwardedTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit = (bool?) content.GetValueForProperty("AllowGatewayTransit",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowGatewayTransit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess = (bool?) content.GetValueForProperty("AllowVirtualNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).AllowVirtualNetworkAccess, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState?) content.GetValueForProperty("PeeringState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).PeeringState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway = (bool?) content.GetValueForProperty("UseRemoteGateway",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).UseRemoteGateway, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("DatabrickAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId = (string) content.GetValueForProperty("DatabrickVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).DatabrickVirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("RemoteAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId = (string) content.GetValueForProperty("RemoteVirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)this).RemoteVirtualNetworkId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Properties of the virtual network peering.
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkPeeringPropertiesFormatTypeConverter))]
    public partial interface IVirtualNetworkPeeringPropertiesFormat

    {

    }
}