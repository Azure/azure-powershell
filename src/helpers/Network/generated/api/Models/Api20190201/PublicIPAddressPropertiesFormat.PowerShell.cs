namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Public IP address properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(PublicIPAddressPropertiesFormatTypeConverter))]
    public partial class PublicIPAddressPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PublicIPAddressPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PublicIPAddressPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PublicIPAddressPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PublicIPAddressPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettings) content.GetValueForProperty("DdosSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DdosSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefix, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PublicIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingProtectionCoverage = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage?) content.GetValueForProperty("DdosSettingProtectionCoverage",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingProtectionCoverage, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingDdosCustomPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DdosSettingDdosCustomPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingDdosCustomPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingDomainNameLabel = (string) content.GetValueForProperty("DnsSettingDomainNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingDomainNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingFqdn = (string) content.GetValueForProperty("DnsSettingFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingReverseFqdn = (string) content.GetValueForProperty("DnsSettingReverseFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingReverseFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefixId = (string) content.GetValueForProperty("PublicIPPrefixId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefixId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosCustomPolicyId = (string) content.GetValueForProperty("DdosCustomPolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosCustomPolicyId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PublicIPAddressPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettings) content.GetValueForProperty("DdosSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DdosSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefix, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]) content.GetValueForProperty("IPTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).IPTag, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPTagTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PublicIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingProtectionCoverage = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage?) content.GetValueForProperty("DdosSettingProtectionCoverage",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingProtectionCoverage, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingDdosCustomPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("DdosSettingDdosCustomPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosSettingDdosCustomPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingDomainNameLabel = (string) content.GetValueForProperty("DnsSettingDomainNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingDomainNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingFqdn = (string) content.GetValueForProperty("DnsSettingFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingReverseFqdn = (string) content.GetValueForProperty("DnsSettingReverseFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DnsSettingReverseFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefixId = (string) content.GetValueForProperty("PublicIPPrefixId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).PublicIPPrefixId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosCustomPolicyId = (string) content.GetValueForProperty("DdosCustomPolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)this).DdosCustomPolicyId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Public IP address properties.
    [System.ComponentModel.TypeConverter(typeof(PublicIPAddressPropertiesFormatTypeConverter))]
    public partial interface IPublicIPAddressPropertiesFormat

    {

    }
}