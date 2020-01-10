namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>LocalNetworkGateway properties</summary>
    [System.ComponentModel.TypeConverter(typeof(LocalNetworkGatewayPropertiesFormatTypeConverter))]
    public partial class LocalNetworkGatewayPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LocalNetworkGatewayPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LocalNetworkGatewayPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LocalNetworkGatewayPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LocalNetworkGatewayPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("LocalNetworkAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).GatewayIPAddress = (string) content.GetValueForProperty("GatewayIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).GatewayIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn = (long?) content.GetValueForProperty("BgpSettingAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress = (string) content.GetValueForProperty("BgpSettingBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight = (int?) content.GetValueForProperty("BgpSettingPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("LocalNetworkAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LocalNetworkGatewayPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("LocalNetworkAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).GatewayIPAddress = (string) content.GetValueForProperty("GatewayIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).GatewayIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn = (long?) content.GetValueForProperty("BgpSettingAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress = (string) content.GetValueForProperty("BgpSettingBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight = (int?) content.GetValueForProperty("BgpSettingPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("LocalNetworkAddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormatInternal)this).LocalNetworkAddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// LocalNetworkGateway properties
    [System.ComponentModel.TypeConverter(typeof(LocalNetworkGatewayPropertiesFormatTypeConverter))]
    public partial interface ILocalNetworkGatewayPropertiesFormat

    {

    }
}