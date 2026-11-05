// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.PowerShell;

    /// <summary>A signal configuration for an Azure resource type</summary>
    [System.ComponentModel.TypeConverter(typeof(SignalConfigurationTypeConverter))]
    public partial class SignalConfiguration
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SignalConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SignalConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SignalConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="SignalConfiguration" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SignalConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Configuration = (Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Configuration, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SignalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).SignalId = (string) content.GetValueForProperty("SignalId",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).SignalId, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("ApplicableResourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ApplicableResourceType = (System.Collections.Generic.List<string>) content.GetValueForProperty("ApplicableResourceType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ApplicableResourceType, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("RefreshInterval"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).RefreshInterval = (string) content.GetValueForProperty("RefreshInterval",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).RefreshInterval, global::System.Convert.ToString);
            }
            if (content.Contains("DataUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DataUnit = (string) content.GetValueForProperty("DataUnit",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DataUnit, global::System.Convert.ToString);
            }
            if (content.Contains("EvaluationRule"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).EvaluationRule = (Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule) content.GetValueForProperty("EvaluationRule",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).EvaluationRule, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.EvaluationRuleTypeConverter.ConvertFrom);
            }
            if (content.Contains("ConfigurationSignalKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ConfigurationSignalKind = (string) content.GetValueForProperty("ConfigurationSignalKind",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ConfigurationSignalKind, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SignalConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Configuration = (Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Configuration, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalRecommendationConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SignalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).SignalId = (string) content.GetValueForProperty("SignalId",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).SignalId, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("ApplicableResourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ApplicableResourceType = (System.Collections.Generic.List<string>) content.GetValueForProperty("ApplicableResourceType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ApplicableResourceType, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("RefreshInterval"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).RefreshInterval = (string) content.GetValueForProperty("RefreshInterval",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).RefreshInterval, global::System.Convert.ToString);
            }
            if (content.Contains("DataUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DataUnit = (string) content.GetValueForProperty("DataUnit",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).DataUnit, global::System.Convert.ToString);
            }
            if (content.Contains("EvaluationRule"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).EvaluationRule = (Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule) content.GetValueForProperty("EvaluationRule",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).EvaluationRule, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.EvaluationRuleTypeConverter.ConvertFrom);
            }
            if (content.Contains("ConfigurationSignalKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ConfigurationSignalKind = (string) content.GetValueForProperty("ConfigurationSignalKind",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalConfigurationInternal)this).ConfigurationSignalKind, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// A signal configuration for an Azure resource type
    [System.ComponentModel.TypeConverter(typeof(SignalConfigurationTypeConverter))]
    public partial interface ISignalConfiguration

    {

    }
}