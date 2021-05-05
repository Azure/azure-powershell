namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(RoleInstancePropertiesTypeConverter))]
    public partial class RoleInstanceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RoleInstanceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RoleInstanceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RoleInstanceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RoleInstanceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformUpdateDomain = (int?) content.GetValueForProperty("InstanceViewPlatformUpdateDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformUpdateDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformFaultDomain = (int?) content.GetValueForProperty("InstanceViewPlatformFaultDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformFaultDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPrivateId = (string) content.GetValueForProperty("InstanceViewPrivateId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPrivateId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewStatuses = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[]) content.GetValueForProperty("InstanceViewStatuses",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewStatuses, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceInstanceViewStatusTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RoleInstanceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformUpdateDomain = (int?) content.GetValueForProperty("InstanceViewPlatformUpdateDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformUpdateDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformFaultDomain = (int?) content.GetValueForProperty("InstanceViewPlatformFaultDomain",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPlatformFaultDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPrivateId = (string) content.GetValueForProperty("InstanceViewPrivateId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewPrivateId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewStatuses = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[]) content.GetValueForProperty("InstanceViewStatuses",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)this).InstanceViewStatuses, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceInstanceViewStatusTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(RoleInstancePropertiesTypeConverter))]
    public partial interface IRoleInstanceProperties

    {

    }
}