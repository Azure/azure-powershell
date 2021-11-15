namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>An export resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExportTypeConverter))]
    public partial class Export
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Export"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Export(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Export"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Export(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Export"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Export(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("DeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).NextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("NextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).NextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Schedule = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule) content.GetValueForProperty("Schedule",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Schedule, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportScheduleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrencePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod) content.GetValueForProperty("ScheduleRecurrencePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrencePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportRecurrencePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleStatus = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType?) content.GetValueForProperty("ScheduleStatus",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleStatus, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrence = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType?) content.GetValueForProperty("ScheduleRecurrence",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrence, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodTo = (global::System.DateTime?) content.GetValueForProperty("RecurrencePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodFrom = (global::System.DateTime) content.GetValueForProperty("RecurrencePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Export"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Export(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("DeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).NextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("NextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).NextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Schedule = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule) content.GetValueForProperty("Schedule",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).Schedule, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportScheduleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrencePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod) content.GetValueForProperty("ScheduleRecurrencePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrencePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportRecurrencePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleStatus = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType?) content.GetValueForProperty("ScheduleStatus",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleStatus, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrence = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType?) content.GetValueForProperty("ScheduleRecurrence",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ScheduleRecurrence, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodTo = (global::System.DateTime?) content.GetValueForProperty("RecurrencePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodFrom = (global::System.DateTime) content.GetValueForProperty("RecurrencePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).RecurrencePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Export" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// An export resource.
    [System.ComponentModel.TypeConverter(typeof(ExportTypeConverter))]
    public partial interface IExport

    {

    }
}