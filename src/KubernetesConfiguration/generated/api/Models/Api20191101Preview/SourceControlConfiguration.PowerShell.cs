namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.PowerShell;

    /// <summary>The SourceControl Configuration object.</summary>
    [System.ComponentModel.TypeConverter(typeof(SourceControlConfigurationTypeConverter))]
    public partial class SourceControlConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SourceControlConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SourceControlConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SourceControlConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SourceControlConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatus = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IComplianceStatus) content.GetValueForProperty("ComplianceStatus",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatus, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ComplianceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorType = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType?) content.GetValueForProperty("OperatorType",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorType, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorScope = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope?) content.GetValueForProperty("OperatorScope",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorScope, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorNamespace = (string) content.GetValueForProperty("OperatorNamespace",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorInstanceName = (string) content.GetValueForProperty("OperatorInstanceName",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorInstanceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).EnableHelmOperator = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator?) content.GetValueForProperty("EnableHelmOperator",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).EnableHelmOperator, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorProperty = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IHelmOperatorProperties) content.GetValueForProperty("HelmOperatorProperty",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorProperty, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.HelmOperatorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryPublicKey = (string) content.GetValueForProperty("RepositoryPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorParam = (string) content.GetValueForProperty("OperatorParam",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusComplianceState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState?) content.GetValueForProperty("ComplianceStatusComplianceState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusComplianceState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessage = (string) content.GetValueForProperty("ComplianceStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessageLevel = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel?) content.GetValueForProperty("ComplianceStatusMessageLevel",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessageLevel, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartValue = (string) content.GetValueForProperty("HelmOperatorPropertyChartValue",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartVersion = (string) content.GetValueForProperty("HelmOperatorPropertyChartVersion",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusLastConfigApplied = (global::System.DateTime?) content.GetValueForProperty("ComplianceStatusLastConfigApplied",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusLastConfigApplied, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SourceControlConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.SourceControlConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatus = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IComplianceStatus) content.GetValueForProperty("ComplianceStatus",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatus, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ComplianceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorType = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType?) content.GetValueForProperty("OperatorType",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorType, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorScope = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope?) content.GetValueForProperty("OperatorScope",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorScope, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScope.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorNamespace = (string) content.GetValueForProperty("OperatorNamespace",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorInstanceName = (string) content.GetValueForProperty("OperatorInstanceName",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorInstanceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).EnableHelmOperator = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator?) content.GetValueForProperty("EnableHelmOperator",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).EnableHelmOperator, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.EnableHelmOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorProperty = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.IHelmOperatorProperties) content.GetValueForProperty("HelmOperatorProperty",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorProperty, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.HelmOperatorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryPublicKey = (string) content.GetValueForProperty("RepositoryPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).RepositoryPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorParam = (string) content.GetValueForProperty("OperatorParam",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).OperatorParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusComplianceState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState?) content.GetValueForProperty("ComplianceStatusComplianceState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusComplianceState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessage = (string) content.GetValueForProperty("ComplianceStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessageLevel = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel?) content.GetValueForProperty("ComplianceStatusMessageLevel",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusMessageLevel, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartValue = (string) content.GetValueForProperty("HelmOperatorPropertyChartValue",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartVersion = (string) content.GetValueForProperty("HelmOperatorPropertyChartVersion",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).HelmOperatorPropertyChartVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusLastConfigApplied = (global::System.DateTime?) content.GetValueForProperty("ComplianceStatusLastConfigApplied",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20191101Preview.ISourceControlConfigurationInternal)this).ComplianceStatusLastConfigApplied, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The SourceControl Configuration object.
    [System.ComponentModel.TypeConverter(typeof(SourceControlConfigurationTypeConverter))]
    public partial interface ISourceControlConfiguration

    {

    }
}