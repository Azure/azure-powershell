namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters for VirtualWAN</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualWanPropertiesTypeConverter))]
    public partial class VirtualWanProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualWanProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualWanProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualWanProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualWanProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowBranchToBranchTraffic = (bool?) content.GetValueForProperty("AllowBranchToBranchTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowBranchToBranchTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowVnetToVnetTraffic = (bool?) content.GetValueForProperty("AllowVnetToVnetTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowVnetToVnetTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).DisableVpnEncryption = (bool?) content.GetValueForProperty("DisableVpnEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).DisableVpnEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).Office365LocalBreakoutCategory = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory?) content.GetValueForProperty("Office365LocalBreakoutCategory",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).Office365LocalBreakoutCategory, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[]) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).P2SVpnServerConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).SecurityProviderName = (string) content.GetValueForProperty("SecurityProviderName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).SecurityProviderName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VirtualHub, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VpnSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("VpnSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VpnSite, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualWanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualWanProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowBranchToBranchTraffic = (bool?) content.GetValueForProperty("AllowBranchToBranchTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowBranchToBranchTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowVnetToVnetTraffic = (bool?) content.GetValueForProperty("AllowVnetToVnetTraffic",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).AllowVnetToVnetTraffic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).DisableVpnEncryption = (bool?) content.GetValueForProperty("DisableVpnEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).DisableVpnEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).Office365LocalBreakoutCategory = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory?) content.GetValueForProperty("Office365LocalBreakoutCategory",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).Office365LocalBreakoutCategory, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.OfficeTrafficCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration[]) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).P2SVpnServerConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).SecurityProviderName = (string) content.GetValueForProperty("SecurityProviderName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).SecurityProviderName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VirtualHub, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VpnSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("VpnSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanPropertiesInternal)this).VpnSite, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters for VirtualWAN
    [System.ComponentModel.TypeConverter(typeof(VirtualWanPropertiesTypeConverter))]
    public partial interface IVirtualWanProperties

    {

    }
}