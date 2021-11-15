namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>The common properties of the export.</summary>
    [System.ComponentModel.TypeConverter(typeof(CommonExportPropertiesTypeConverter))]
    public partial class CommonExportProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CommonExportProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("DeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).NextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("NextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).NextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CommonExportProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("DeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).NextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("NextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).NextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CommonExportProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CommonExportProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CommonExportProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The common properties of the export.
    [System.ComponentModel.TypeConverter(typeof(CommonExportPropertiesTypeConverter))]
    public partial interface ICommonExportProperties

    {

    }
}