namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Deployment resource payload</summary>
    [System.ComponentModel.TypeConverter(typeof(DeploymentResourceTypeConverter))]
    public partial class DeploymentResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DeploymentResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSetting = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettings) content.GetValueForProperty("DeploymentSetting",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSetting, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingRuntimeVersion = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion?) content.GetValueForProperty("DeploymentSettingRuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingRuntimeVersion, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Active = (bool?) content.GetValueForProperty("Active",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Active, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Instance = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstance[]) content.GetValueForProperty("Instance",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Instance, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstance>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentInstanceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingJvmOption = (string) content.GetValueForProperty("DeploymentSettingJvmOption",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingJvmOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingEnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettingsEnvironmentVariables) content.GetValueForProperty("DeploymentSettingEnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingEnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentSettingsEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IUserSourceInfo) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.UserSourceInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).AppName = (string) content.GetValueForProperty("AppName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).AppName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceVersion = (string) content.GetValueForProperty("SourceVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceArtifactSelector = (string) content.GetValueForProperty("SourceArtifactSelector",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceArtifactSelector, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingCpu = (int?) content.GetValueForProperty("DeploymentSettingCpu",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingCpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingMemoryInGb = (int?) content.GetValueForProperty("DeploymentSettingMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingMemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingNetCoreMainEntryPath = (string) content.GetValueForProperty("DeploymentSettingNetCoreMainEntryPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingNetCoreMainEntryPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceRelativePath = (string) content.GetValueForProperty("SourceRelativePath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceRelativePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType?) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DeploymentResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSetting = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettings) content.GetValueForProperty("DeploymentSetting",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSetting, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingRuntimeVersion = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion?) content.GetValueForProperty("DeploymentSettingRuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingRuntimeVersion, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Active = (bool?) content.GetValueForProperty("Active",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Active, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Instance = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstance[]) content.GetValueForProperty("Instance",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Instance, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstance>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentInstanceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingJvmOption = (string) content.GetValueForProperty("DeploymentSettingJvmOption",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingJvmOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingEnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettingsEnvironmentVariables) content.GetValueForProperty("DeploymentSettingEnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingEnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentSettingsEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IUserSourceInfo) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.UserSourceInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).AppName = (string) content.GetValueForProperty("AppName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).AppName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.DeploymentResourceProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceVersion = (string) content.GetValueForProperty("SourceVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceArtifactSelector = (string) content.GetValueForProperty("SourceArtifactSelector",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceArtifactSelector, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingCpu = (int?) content.GetValueForProperty("DeploymentSettingCpu",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingCpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingMemoryInGb = (int?) content.GetValueForProperty("DeploymentSettingMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingMemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingNetCoreMainEntryPath = (string) content.GetValueForProperty("DeploymentSettingNetCoreMainEntryPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).DeploymentSettingNetCoreMainEntryPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceRelativePath = (string) content.GetValueForProperty("SourceRelativePath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceRelativePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType?) content.GetValueForProperty("SourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResourceInternal)this).SourceType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DeploymentResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.DeploymentResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DeploymentResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DeploymentResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Deployment resource payload
    [System.ComponentModel.TypeConverter(typeof(DeploymentResourceTypeConverter))]
    public partial interface IDeploymentResource

    {

    }
}