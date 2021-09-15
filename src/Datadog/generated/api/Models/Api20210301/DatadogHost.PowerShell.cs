namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(DatadogHostTypeConverter))]
    public partial class DatadogHost
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatadogHost(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Meta = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata) content.GetValueForProperty("Meta",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Meta, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHostMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Alias = (string[]) content.GetValueForProperty("Alias",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Alias, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).App = (string[]) content.GetValueForProperty("App",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).App, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaInstallMethod = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod) content.GetValueForProperty("MetaInstallMethod",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaInstallMethod, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogInstallMethodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaLogsAgent = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent) content.GetValueForProperty("MetaLogsAgent",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaLogsAgent, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogLogsAgentTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaAgentVersion = (string) content.GetValueForProperty("MetaAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodTool = (string) content.GetValueForProperty("InstallMethodTool",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodTool, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodToolVersion = (string) content.GetValueForProperty("InstallMethodToolVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodToolVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodInstallerVersion = (string) content.GetValueForProperty("InstallMethodInstallerVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodInstallerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).LogAgentTransport = (string) content.GetValueForProperty("LogAgentTransport",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).LogAgentTransport, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatadogHost(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Meta = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata) content.GetValueForProperty("Meta",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Meta, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHostMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Alias = (string[]) content.GetValueForProperty("Alias",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).Alias, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).App = (string[]) content.GetValueForProperty("App",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).App, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaInstallMethod = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod) content.GetValueForProperty("MetaInstallMethod",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaInstallMethod, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogInstallMethodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaLogsAgent = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent) content.GetValueForProperty("MetaLogsAgent",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaLogsAgent, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogLogsAgentTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaAgentVersion = (string) content.GetValueForProperty("MetaAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).MetaAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodTool = (string) content.GetValueForProperty("InstallMethodTool",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodTool, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodToolVersion = (string) content.GetValueForProperty("InstallMethodToolVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodToolVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodInstallerVersion = (string) content.GetValueForProperty("InstallMethodInstallerVersion",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).InstallMethodInstallerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).LogAgentTransport = (string) content.GetValueForProperty("LogAgentTransport",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal)this).LogAgentTransport, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatadogHost(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHost"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatadogHost(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatadogHost" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    [System.ComponentModel.TypeConverter(typeof(DatadogHostTypeConverter))]
    public partial interface IDatadogHost

    {

    }
}