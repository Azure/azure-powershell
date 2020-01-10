namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters for VpnSite</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnSitePropertiesTypeConverter))]
    public partial class VpnSiteProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnSiteProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnSiteProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnSiteProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnSiteProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("AddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings) content.GetValueForProperty("BgpProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DeviceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties) content.GetValueForProperty("DeviceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DeviceProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DevicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IsSecuritySite = (bool?) content.GetValueForProperty("IsSecuritySite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IsSecuritySite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).SiteKey = (string) content.GetValueForProperty("SiteKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).SiteKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("AddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceModel = (string) content.GetValueForProperty("DevicePropertyDeviceModel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceModel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceVendor = (string) content.GetValueForProperty("DevicePropertyDeviceVendor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceVendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyAsn = (long?) content.GetValueForProperty("BgpPropertyAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyBgpPeeringAddress = (string) content.GetValueForProperty("BgpPropertyBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyPeerWeight = (int?) content.GetValueForProperty("BgpPropertyPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyLinkSpeedInMbps = (int?) content.GetValueForProperty("DevicePropertyLinkSpeedInMbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyLinkSpeedInMbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWanId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnSiteProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("AddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings) content.GetValueForProperty("BgpProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DeviceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties) content.GetValueForProperty("DeviceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DeviceProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DevicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IsSecuritySite = (bool?) content.GetValueForProperty("IsSecuritySite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).IsSecuritySite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).SiteKey = (string) content.GetValueForProperty("SiteKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).SiteKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpaceAddressPrefix = (string[]) content.GetValueForProperty("AddressSpaceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).AddressSpaceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceModel = (string) content.GetValueForProperty("DevicePropertyDeviceModel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceModel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceVendor = (string) content.GetValueForProperty("DevicePropertyDeviceVendor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyDeviceVendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyAsn = (long?) content.GetValueForProperty("BgpPropertyAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyBgpPeeringAddress = (string) content.GetValueForProperty("BgpPropertyBgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyBgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyPeerWeight = (int?) content.GetValueForProperty("BgpPropertyPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).BgpPropertyPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyLinkSpeedInMbps = (int?) content.GetValueForProperty("DevicePropertyLinkSpeedInMbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).DevicePropertyLinkSpeedInMbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)this).VirtualWanId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters for VpnSite
    [System.ComponentModel.TypeConverter(typeof(VpnSitePropertiesTypeConverter))]
    public partial interface IVpnSiteProperties

    {

    }
}