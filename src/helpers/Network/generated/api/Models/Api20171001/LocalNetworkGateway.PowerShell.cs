namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>A common class for general resource information</summary>
    [System.ComponentModel.TypeConverter(typeof(LocalNetworkGatewayTypeConverter))]
    public partial class LocalNetworkGateway
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LocalNetworkGateway(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LocalNetworkGateway(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LocalNetworkGateway" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LocalNetworkGateway(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).LocalNetworkAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("LocalNetworkAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).LocalNetworkAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).GatewayIPAddress = (string) content.GetValueForProperty("GatewayIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).GatewayIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpAsn = (long?) content.GetValueForProperty("BgpAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeeringAddress = (string) content.GetValueForProperty("BgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeerWeight = (int?) content.GetValueForProperty("BgpPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).AddressPrefix = (string[]) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).AddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LocalNetworkGateway(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LocalNetworkGatewayPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).LocalNetworkAddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("LocalNetworkAddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).LocalNetworkAddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).GatewayIPAddress = (string) content.GetValueForProperty("GatewayIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).GatewayIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpAsn = (long?) content.GetValueForProperty("BgpAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeeringAddress = (string) content.GetValueForProperty("BgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeerWeight = (int?) content.GetValueForProperty("BgpPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).BgpPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).AddressPrefix = (string[]) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGatewayInternal)this).AddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A common class for general resource information
    [System.ComponentModel.TypeConverter(typeof(LocalNetworkGatewayTypeConverter))]
    public partial interface ILocalNetworkGateway

    {

    }
}