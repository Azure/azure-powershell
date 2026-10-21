// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.PowerShell;

    /// <summary>Azure Resource Metric recommendation configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureResourceMetricRecommendationConfigurationTypeConverter))]
    public partial class AzureResourceMetricRecommendationConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.AzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureResourceMetricRecommendationConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MetricNamespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricNamespace = (string) content.GetValueForProperty("MetricNamespace",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricNamespace, global::System.Convert.ToString);
            }
            if (content.Contains("MetricName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricName = (string) content.GetValueForProperty("MetricName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricName, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("TimeGrain"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).TimeGrain = (string) content.GetValueForProperty("TimeGrain",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).TimeGrain, global::System.Convert.ToString);
            }
            if (content.Contains("DimensionFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).DimensionFilter = (string) content.GetValueForProperty("DimensionFilter",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).DimensionFilter, global::System.Convert.ToString);
            }
            if (content.Contains("SignalKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)this).SignalKind = (string) content.GetValueForProperty("SignalKind",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)this).SignalKind, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.AzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureResourceMetricRecommendationConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MetricNamespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricNamespace = (string) content.GetValueForProperty("MetricNamespace",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricNamespace, global::System.Convert.ToString);
            }
            if (content.Contains("MetricName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricName = (string) content.GetValueForProperty("MetricName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).MetricName, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("TimeGrain"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).TimeGrain = (string) content.GetValueForProperty("TimeGrain",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).TimeGrain, global::System.Convert.ToString);
            }
            if (content.Contains("DimensionFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).DimensionFilter = (string) content.GetValueForProperty("DimensionFilter",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfigurationInternal)this).DimensionFilter, global::System.Convert.ToString);
            }
            if (content.Contains("SignalKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)this).SignalKind = (string) content.GetValueForProperty("SignalKind",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal)this).SignalKind, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.AzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureResourceMetricRecommendationConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.AzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureResourceMetricRecommendationConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureResourceMetricRecommendationConfiguration" />, deserializing the content from
        /// a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="AzureResourceMetricRecommendationConfiguration" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAzureResourceMetricRecommendationConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Azure Resource Metric recommendation configuration.
    [System.ComponentModel.TypeConverter(typeof(AzureResourceMetricRecommendationConfigurationTypeConverter))]
    public partial interface IAzureResourceMetricRecommendationConfiguration

    {

    }
}