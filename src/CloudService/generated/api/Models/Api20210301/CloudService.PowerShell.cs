namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    /// <summary>Describes the cloud service.</summary>
    [System.ComponentModel.TypeConverter(typeof(CloudServiceTypeConverter))]
    public partial class CloudService
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CloudService(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).RoleProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile) content.GetValueForProperty("RoleProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).RoleProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).PackageUrl = (string) content.GetValueForProperty("PackageUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).PackageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ConfigurationUrl = (string) content.GetValueForProperty("ConfigurationUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ConfigurationUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).StartCloudService = (bool?) content.GetValueForProperty("StartCloudService",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).StartCloudService, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).AllowModelOverride = (bool?) content.GetValueForProperty("AllowModelOverride",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).AllowModelOverride, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UpgradeMode = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode?) content.GetValueForProperty("UpgradeMode",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UpgradeMode, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Configuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UniqueId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CloudService(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServicePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).RoleProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile) content.GetValueForProperty("RoleProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).RoleProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).PackageUrl = (string) content.GetValueForProperty("PackageUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).PackageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ConfigurationUrl = (string) content.GetValueForProperty("ConfigurationUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ConfigurationUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).StartCloudService = (bool?) content.GetValueForProperty("StartCloudService",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).StartCloudService, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).AllowModelOverride = (bool?) content.GetValueForProperty("AllowModelOverride",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).AllowModelOverride, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UpgradeMode = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode?) content.GetValueForProperty("UpgradeMode",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UpgradeMode, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).Configuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal)this).UniqueId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CloudService(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CloudService(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CloudService" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the cloud service.
    [System.ComponentModel.TypeConverter(typeof(CloudServiceTypeConverter))]
    public partial interface ICloudService

    {

    }
}