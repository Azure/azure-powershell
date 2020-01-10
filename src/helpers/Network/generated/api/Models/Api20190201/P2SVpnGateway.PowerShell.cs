namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>P2SVpnGateway Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(P2SVpnGatewayTypeConverter))]
    public partial class P2SVpnGateway
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new P2SVpnGateway(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new P2SVpnGateway(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="P2SVpnGateway" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal P2SVpnGateway(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("CustomRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRoute, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionHealth = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth) content.GetValueForProperty("VpnClientConnectionHealth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionHealth, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealthTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ScaleUnit = (int?) content.GetValueForProperty("ScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ScaleUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionCount = (int?) content.GetValueForProperty("VpnClientConnectionCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfigurationId = (string) content.GetValueForProperty("P2SVpnServerConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAllocatedIPAddress = (string[]) content.GetValueForProperty("VpnClientAllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientEgressBytesTransferred = (long?) content.GetValueForProperty("VpnClientEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientIngressBytesTransferred = (long?) content.GetValueForProperty("VpnClientIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRouteAddressPrefix = (string[]) content.GetValueForProperty("CustomRouteAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRouteAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGateway"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal P2SVpnGateway(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("CustomRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRoute, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionHealth = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth) content.GetValueForProperty("VpnClientConnectionHealth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionHealth, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealthTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ScaleUnit = (int?) content.GetValueForProperty("ScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).ScaleUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionCount = (int?) content.GetValueForProperty("VpnClientConnectionCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientConnectionCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfigurationId = (string) content.GetValueForProperty("P2SVpnServerConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).P2SVpnServerConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAllocatedIPAddress = (string[]) content.GetValueForProperty("VpnClientAllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientAllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientEgressBytesTransferred = (long?) content.GetValueForProperty("VpnClientEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientIngressBytesTransferred = (long?) content.GetValueForProperty("VpnClientIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).VpnClientIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRouteAddressPrefix = (string[]) content.GetValueForProperty("CustomRouteAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal)this).CustomRouteAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// P2SVpnGateway Resource.
    [System.ComponentModel.TypeConverter(typeof(P2SVpnGatewayTypeConverter))]
    public partial interface IP2SVpnGateway

    {

    }
}