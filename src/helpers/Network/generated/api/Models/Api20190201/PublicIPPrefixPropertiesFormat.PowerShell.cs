namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Public IP prefix properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(PublicIPPrefixPropertiesFormatTypeConverter))]
    public partial class PublicIPPrefixPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PublicIPPrefixPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PublicIPPrefixPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PublicIPPrefixPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PublicIPPrefixPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPPrefix = (string) content.GetValueForProperty("IPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PrefixLength = (int?) content.GetValueForProperty("PrefixLength",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PrefixLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ReferencedPublicIPAddressTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfigurationId = (string) content.GetValueForProperty("LoadBalancerFrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPPrefixPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PublicIPPrefixPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPPrefix = (string) content.GetValueForProperty("IPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PrefixLength = (int?) content.GetValueForProperty("PrefixLength",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PrefixLength, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[]) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).PublicIPAddress, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ReferencedPublicIPAddressTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfigurationId = (string) content.GetValueForProperty("LoadBalancerFrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal)this).LoadBalancerFrontendIPConfigurationId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Public IP prefix properties.
    [System.ComponentModel.TypeConverter(typeof(PublicIPPrefixPropertiesFormatTypeConverter))]
    public partial interface IPublicIPPrefixPropertiesFormat

    {

    }
}