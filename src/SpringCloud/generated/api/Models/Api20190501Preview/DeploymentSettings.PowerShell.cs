namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Deployment settings payload</summary>
    [System.ComponentModel.TypeConverter(typeof(DeploymentSettingsTypeConverter))]
    public partial class DeploymentSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DeploymentSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).Cpu = (int?) content.GetValueForProperty("Cpu",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).Cpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).EnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables) content.GetValueForProperty("EnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).EnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettingsEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).InstanceCount = (int?) content.GetValueForProperty("InstanceCount",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).InstanceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).JvmOption = (string) content.GetValueForProperty("JvmOption",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).JvmOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).MemoryInGb = (int?) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).MemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).RuntimeVersion = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion?) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).RuntimeVersion, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DeploymentSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).Cpu = (int?) content.GetValueForProperty("Cpu",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).Cpu, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).EnvironmentVariable = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables) content.GetValueForProperty("EnvironmentVariable",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).EnvironmentVariable, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettingsEnvironmentVariablesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).InstanceCount = (int?) content.GetValueForProperty("InstanceCount",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).InstanceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).JvmOption = (string) content.GetValueForProperty("JvmOption",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).JvmOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).MemoryInGb = (int?) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).MemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).RuntimeVersion = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion?) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsInternal)this).RuntimeVersion, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DeploymentSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DeploymentSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DeploymentSettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Deployment settings payload
    [System.ComponentModel.TypeConverter(typeof(DeploymentSettingsTypeConverter))]
    public partial interface IDeploymentSettings

    {

    }
}