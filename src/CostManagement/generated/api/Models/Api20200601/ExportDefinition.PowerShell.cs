namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>The definition of an export.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExportDefinitionTypeConverter))]
    public partial class ExportDefinition
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExportDefinition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExportDefinition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExportDefinition(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("TimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Timeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("Timeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Timeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExportDefinition(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("TimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Timeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("Timeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).Timeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExportDefinition" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The definition of an export.
    [System.ComponentModel.TypeConverter(typeof(ExportDefinitionTypeConverter))]
    public partial interface IExportDefinition

    {

    }
}