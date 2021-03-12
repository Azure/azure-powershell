namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.PowerShell;

    /// <summary>Properties to create a Source Control Configuration resource</summary>
    [System.ComponentModel.TypeConverter(typeof(SourceControlConfigurationPropertiesTypeConverter))]
    public partial class SourceControlConfigurationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SourceControlConfigurationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SourceControlConfigurationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SourceControlConfigurationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SourceControlConfigurationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatus = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus) content.GetValueForProperty("ComplianceStatus",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatus, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ComplianceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorProperty = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties) content.GetValueForProperty("HelmOperatorProperty",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorProperty, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.HelmOperatorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ConfigurationProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings) content.GetValueForProperty("ConfigurationProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ConfigurationProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ConfigurationProtectedSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).EnableHelmOperator = (bool?) content.GetValueForProperty("EnableHelmOperator",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).EnableHelmOperator, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorInstanceName = (string) content.GetValueForProperty("OperatorInstanceName",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorInstanceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorNamespace = (string) content.GetValueForProperty("OperatorNamespace",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorParam = (string) content.GetValueForProperty("OperatorParam",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorScope = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType?) content.GetValueForProperty("OperatorScope",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorScope, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorType = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType?) content.GetValueForProperty("OperatorType",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorType, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryPublicKey = (string) content.GetValueForProperty("RepositoryPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).SshKnownHostsContent = (string) content.GetValueForProperty("SshKnownHostsContent",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).SshKnownHostsContent, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessage = (string) content.GetValueForProperty("ComplianceStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartValue = (string) content.GetValueForProperty("HelmOperatorPropertyChartValue",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartVersion = (string) content.GetValueForProperty("HelmOperatorPropertyChartVersion",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusComplianceState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType?) content.GetValueForProperty("ComplianceStatusComplianceState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusComplianceState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusLastConfigApplied = (global::System.DateTime?) content.GetValueForProperty("ComplianceStatusLastConfigApplied",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusLastConfigApplied, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessageLevel = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType?) content.GetValueForProperty("ComplianceStatusMessageLevel",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessageLevel, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.SourceControlConfigurationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SourceControlConfigurationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatus = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus) content.GetValueForProperty("ComplianceStatus",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatus, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ComplianceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorProperty = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IHelmOperatorProperties) content.GetValueForProperty("HelmOperatorProperty",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorProperty, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.HelmOperatorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ConfigurationProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IConfigurationProtectedSettings) content.GetValueForProperty("ConfigurationProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ConfigurationProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ConfigurationProtectedSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).EnableHelmOperator = (bool?) content.GetValueForProperty("EnableHelmOperator",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).EnableHelmOperator, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorInstanceName = (string) content.GetValueForProperty("OperatorInstanceName",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorInstanceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorNamespace = (string) content.GetValueForProperty("OperatorNamespace",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorParam = (string) content.GetValueForProperty("OperatorParam",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorScope = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType?) content.GetValueForProperty("OperatorScope",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorScope, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorType = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType?) content.GetValueForProperty("OperatorType",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).OperatorType, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ProvisioningStateType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryPublicKey = (string) content.GetValueForProperty("RepositoryPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).SshKnownHostsContent = (string) content.GetValueForProperty("SshKnownHostsContent",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).SshKnownHostsContent, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessage = (string) content.GetValueForProperty("ComplianceStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartValue = (string) content.GetValueForProperty("HelmOperatorPropertyChartValue",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartVersion = (string) content.GetValueForProperty("HelmOperatorPropertyChartVersion",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).HelmOperatorPropertyChartVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusComplianceState = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType?) content.GetValueForProperty("ComplianceStatusComplianceState",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusComplianceState, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusLastConfigApplied = (global::System.DateTime?) content.GetValueForProperty("ComplianceStatusLastConfigApplied",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusLastConfigApplied, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessageLevel = (Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType?) content.GetValueForProperty("ComplianceStatusMessageLevel",((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ISourceControlConfigurationPropertiesInternal)this).ComplianceStatusMessageLevel, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties to create a Source Control Configuration resource
    [System.ComponentModel.TypeConverter(typeof(SourceControlConfigurationPropertiesTypeConverter))]
    public partial interface ISourceControlConfigurationProperties

    {

    }
}