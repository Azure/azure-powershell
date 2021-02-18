namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Class Representing Detector Evidence used for analysis</summary>
    [System.ComponentModel.TypeConverter(typeof(AnalysisDataTypeConverter))]
    public partial class AnalysisData
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AnalysisData(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition) content.GetValueForProperty("DetectorDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinition, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData) content.GetValueForProperty("DetectorMetaData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Source, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Metric = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[]) content.GetValueForProperty("Metric",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Metric, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticMetricSetTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Data = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties) content.GetValueForProperty("DetectorDefinitionProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinitionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaDataSource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource) content.GetValueForProperty("DetectorMetaDataSource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaDataSource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionType = (string) content.GetValueForProperty("DetectorDefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionId = (string) content.GetValueForProperty("DetectorDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionName = (string) content.GetValueForProperty("DetectorDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceInstruction = (string[]) content.GetValueForProperty("DataSourceInstruction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceInstruction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionKind = (string) content.GetValueForProperty("DetectorDefinitionKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Rank = (double?) content.GetValueForProperty("Rank",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Rank, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceUri = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) content.GetValueForProperty("DataSourceUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceUri, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AnalysisData(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition) content.GetValueForProperty("DetectorDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinition, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData) content.GetValueForProperty("DetectorMetaData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Source, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Metric = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[]) content.GetValueForProperty("Metric",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Metric, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticMetricSetTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Data = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(__y, __w => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__w, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties) content.GetValueForProperty("DetectorDefinitionProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinitionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaDataSource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource) content.GetValueForProperty("DetectorMetaDataSource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorMetaDataSource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionType = (string) content.GetValueForProperty("DetectorDefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionId = (string) content.GetValueForProperty("DetectorDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionName = (string) content.GetValueForProperty("DetectorDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceInstruction = (string[]) content.GetValueForProperty("DataSourceInstruction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceInstruction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionKind = (string) content.GetValueForProperty("DetectorDefinitionKind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DetectorDefinitionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Rank = (double?) content.GetValueForProperty("Rank",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).Rank, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceUri = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) content.GetValueForProperty("DataSourceUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal)this).DataSourceUri, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AnalysisData(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AnalysisData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AnalysisData(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AnalysisData" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class Representing Detector Evidence used for analysis
    [System.ComponentModel.TypeConverter(typeof(AnalysisDataTypeConverter))]
    public partial interface IAnalysisData

    {

    }
}