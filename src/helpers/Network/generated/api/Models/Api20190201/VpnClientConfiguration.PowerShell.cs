namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>VpnClientConfiguration for P2S client.</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnClientConfigurationTypeConverter))]
    public partial class VpnClientConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnClientConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnClientConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnClientConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnClientConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerAddress = (string) content.GetValueForProperty("RadiusServerAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerSecret = (string) content.GetValueForProperty("RadiusServerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientIpsecPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]) content.GetValueForProperty("VpnClientIpsecPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientIpsecPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]) content.GetValueForProperty("VpnClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRevokedCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[]) content.GetValueForProperty("VpnClientRevokedCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRevokedCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientRevokedCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRootCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[]) content.GetValueForProperty("VpnClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientRootCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnClientConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerAddress = (string) content.GetValueForProperty("RadiusServerAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerSecret = (string) content.GetValueForProperty("RadiusServerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).RadiusServerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientIpsecPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]) content.GetValueForProperty("VpnClientIpsecPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientIpsecPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]) content.GetValueForProperty("VpnClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRevokedCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate[]) content.GetValueForProperty("VpnClientRevokedCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRevokedCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRevokedCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientRevokedCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRootCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate[]) content.GetValueForProperty("VpnClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientRootCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientRootCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConfigurationInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }
    }
    /// VpnClientConfiguration for P2S client.
    [System.ComponentModel.TypeConverter(typeof(VpnClientConfigurationTypeConverter))]
    public partial interface IVpnClientConfiguration

    {

    }
}