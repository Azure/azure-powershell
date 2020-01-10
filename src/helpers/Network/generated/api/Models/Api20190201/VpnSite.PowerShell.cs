namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>VpnSite Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnSiteTypeConverter))]
    public partial class VpnSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnSite(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("AddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties) content.GetValueForProperty("DeviceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DevicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SecuritySite = (bool?) content.GetValueForProperty("SecuritySite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SecuritySite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressPrefix = (string[]) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SiteKey = (string) content.GetValueForProperty("SiteKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SiteKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings) content.GetValueForProperty("BgpProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceModel = (string) content.GetValueForProperty("DeviceModel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceModel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceVendor = (string) content.GetValueForProperty("DeviceVendor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceVendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpAsn = (long?) content.GetValueForProperty("BgpAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeeringAddress = (string) content.GetValueForProperty("BgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeerWeight = (int?) content.GetValueForProperty("BgpPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).LinkSpeedInMbps = (int?) content.GetValueForProperty("LinkSpeedInMbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).LinkSpeedInMbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWanId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressSpace = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("AddressSpace",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressSpace, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties) content.GetValueForProperty("DeviceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DevicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWan = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualWan",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWan, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SecuritySite = (bool?) content.GetValueForProperty("SecuritySite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SecuritySite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressPrefix = (string[]) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).AddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SiteKey = (string) content.GetValueForProperty("SiteKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).SiteKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings) content.GetValueForProperty("BgpProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceModel = (string) content.GetValueForProperty("DeviceModel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceModel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceVendor = (string) content.GetValueForProperty("DeviceVendor",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).DeviceVendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpAsn = (long?) content.GetValueForProperty("BgpAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpAsn, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeeringAddress = (string) content.GetValueForProperty("BgpPeeringAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeeringAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeerWeight = (int?) content.GetValueForProperty("BgpPeerWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).BgpPeerWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).LinkSpeedInMbps = (int?) content.GetValueForProperty("LinkSpeedInMbps",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).LinkSpeedInMbps, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWanId = (string) content.GetValueForProperty("VirtualWanId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal)this).VirtualWanId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// VpnSite Resource.
    [System.ComponentModel.TypeConverter(typeof(VpnSiteTypeConverter))]
    public partial interface IVpnSite

    {

    }
}