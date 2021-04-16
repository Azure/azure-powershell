namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    /// <summary>Cloud service properties</summary>
    [System.ComponentModel.TypeConverter(typeof(CloudServicePropertiesTypeConverter))]
    public partial class CloudServiceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CloudServiceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).PackageUrl = (string) content.GetValueForProperty("PackageUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).PackageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).Configuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ConfigurationUrl = (string) content.GetValueForProperty("ConfigurationUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ConfigurationUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).StartCloudService = (bool?) content.GetValueForProperty("StartCloudService",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).StartCloudService, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).AllowModelOverride = (bool?) content.GetValueForProperty("AllowModelOverride",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).AllowModelOverride, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UpgradeMode = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode?) content.GetValueForProperty("UpgradeMode",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UpgradeMode, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).RoleProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile) content.GetValueForProperty("RoleProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).RoleProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UniqueId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CloudServiceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).PackageUrl = (string) content.GetValueForProperty("PackageUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).PackageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).Configuration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ConfigurationUrl = (string) content.GetValueForProperty("ConfigurationUrl",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ConfigurationUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).StartCloudService = (bool?) content.GetValueForProperty("StartCloudService",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).StartCloudService, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).AllowModelOverride = (bool?) content.GetValueForProperty("AllowModelOverride",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).AllowModelOverride, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UpgradeMode = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode?) content.GetValueForProperty("UpgradeMode",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UpgradeMode, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).RoleProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile) content.GetValueForProperty("RoleProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).RoleProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)this).UniqueId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CloudServiceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CloudServiceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CloudServiceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Cloud service properties
    [System.ComponentModel.TypeConverter(typeof(CloudServicePropertiesTypeConverter))]
    public partial interface ICloudServiceProperties

    {

    }
}