namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(RoleInstanceTypeConverter))]
    public partial class RoleInstance
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstance"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RoleInstance(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstance"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RoleInstance(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RoleInstance" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstance"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RoleInstance(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstancePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformUpdateDomain = (int?) content.GetValueForProperty("InstanceViewPlatformUpdateDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformUpdateDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformFaultDomain = (int?) content.GetValueForProperty("InstanceViewPlatformFaultDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformFaultDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPrivateId = (string) content.GetValueForProperty("InstanceViewPrivateId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPrivateId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewStatuses = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[]) content.GetValueForProperty("InstanceViewStatuses",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewStatuses, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceInstanceViewStatusTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstance"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RoleInstance(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstancePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformUpdateDomain = (int?) content.GetValueForProperty("InstanceViewPlatformUpdateDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformUpdateDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformFaultDomain = (int?) content.GetValueForProperty("InstanceViewPlatformFaultDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPlatformFaultDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPrivateId = (string) content.GetValueForProperty("InstanceViewPrivateId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewPrivateId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewStatuses = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[]) content.GetValueForProperty("InstanceViewStatuses",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal)this).InstanceViewStatuses, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceInstanceViewStatusTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(RoleInstanceTypeConverter))]
    public partial interface IRoleInstance

    {

    }
}