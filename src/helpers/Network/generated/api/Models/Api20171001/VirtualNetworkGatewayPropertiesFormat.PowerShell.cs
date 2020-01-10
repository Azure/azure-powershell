namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>VirtualNetworkGateway properties</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkGatewayPropertiesFormatTypeConverter))]
    public partial class VirtualNetworkGatewayPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkGatewayPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkGatewayPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkGatewayPropertiesFormat" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualNetworkGatewayPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("GatewayDefaultSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSite, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewaySkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientConfiguration) content.GetValueForProperty("VpnClientConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Active = (bool?) content.GetValueForProperty("Active",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Active, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).EnableBgp = (bool?) content.GetValueForProperty("EnableBgp",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).EnableBgp, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType?) content.GetValueForProperty("GatewayType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType?) content.GetValueForProperty("VpnType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("VpnClientConfigurationVpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn = (long?) content.GetValueForProperty("BgpSettingAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight = (int?) content.GetValueForProperty("BgpSettingPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSiteId = (string) content.GetValueForProperty("GatewayDefaultSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress = (string) content.GetValueForProperty("BgpSettingBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerAddress = (string) content.GetValueForProperty("VpnClientConfigurationRadiusServerAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerSecret = (string) content.GetValueForProperty("VpnClientConfigurationRadiusServerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]) content.GetValueForProperty("VpnClientConfigurationVpnClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRevokedCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate[]) content.GetValueForProperty("VpnClientConfigurationVpnClientRevokedCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRevokedCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientRevokedCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRootCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate[]) content.GetValueForProperty("VpnClientConfigurationVpnClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientRootCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualNetworkGatewayPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings) content.GetValueForProperty("BgpSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("GatewayDefaultSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSite, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewaySku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewaySkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientConfiguration) content.GetValueForProperty("VpnClientConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Active = (bool?) content.GetValueForProperty("Active",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).Active, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).EnableBgp = (bool?) content.GetValueForProperty("EnableBgp",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).EnableBgp, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType?) content.GetValueForProperty("GatewayType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType?) content.GetValueForProperty("VpnType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace) content.GetValueForProperty("VpnClientConfigurationVpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn = (long?) content.GetValueForProperty("BgpSettingAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight = (int?) content.GetValueForProperty("BgpSettingPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSiteId = (string) content.GetValueForProperty("GatewayDefaultSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).GatewayDefaultSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress = (string) content.GetValueForProperty("BgpSettingBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).BgpSettingBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerAddress = (string) content.GetValueForProperty("VpnClientConfigurationRadiusServerAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerSecret = (string) content.GetValueForProperty("VpnClientConfigurationRadiusServerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationRadiusServerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]) content.GetValueForProperty("VpnClientConfigurationVpnClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientProtocol, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRevokedCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate[]) content.GetValueForProperty("VpnClientConfigurationVpnClientRevokedCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRevokedCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientRevokedCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRootCertificate = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate[]) content.GetValueForProperty("VpnClientConfigurationVpnClientRootCertificate",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientConfigurationVpnClientRootCertificate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VpnClientRootCertificateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayPropertiesFormatInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }
    }
    /// VirtualNetworkGateway properties
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkGatewayPropertiesFormatTypeConverter))]
    public partial interface IVirtualNetworkGatewayPropertiesFormat

    {

    }
}