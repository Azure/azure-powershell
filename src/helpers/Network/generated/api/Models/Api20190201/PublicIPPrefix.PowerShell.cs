namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Public IP prefix resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(PublicIPPrefixTypeConverter))]
    public partial class PublicIPPrefix
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PublicIPPrefix(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PublicIPPrefix(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PublicIPPrefix" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PublicIPPrefix(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Zone = (string[]) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Zone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPPrefix = (string) content.GetValueForProperty("IPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PrefixLength = (int?) content.GetValueForProperty("PrefixLength",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PrefixLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ReferencedPublicIPAddressTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfigurationId = (string) content.GetValueForProperty("LoadBalancerFrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PublicIPPrefix(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Zone = (string[]) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).Zone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPPrefix = (string) content.GetValueForProperty("IPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PrefixLength = (int?) content.GetValueForProperty("PrefixLength",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PrefixLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ReferencedPublicIPAddressTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPPrefixSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfigurationId = (string) content.GetValueForProperty("LoadBalancerFrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixInternal)this).LoadBalancerFrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Public IP prefix resource.
    [System.ComponentModel.TypeConverter(typeof(PublicIPPrefixTypeConverter))]
    public partial interface IPublicIPPrefix

    {

    }
}