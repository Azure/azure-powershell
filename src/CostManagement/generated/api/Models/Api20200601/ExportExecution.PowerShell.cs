namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>An export execution.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExportExecutionTypeConverter))]
    public partial class ExportExecution
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExportExecution(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExportExecution(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExportExecution(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ExecutionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType?) content.GetValueForProperty("ExecutionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ExecutionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSetting = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties) content.GetValueForProperty("RunSetting",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSetting, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedBy = (string) content.GetValueForProperty("SubmittedBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedTime = (global::System.DateTime?) content.GetValueForProperty("SubmittedTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingStartTime = (global::System.DateTime?) content.GetValueForProperty("ProcessingStartTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingEndTime = (global::System.DateTime?) content.GetValueForProperty("ProcessingEndTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingEndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("RunSettingDeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingRunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunSettingRunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingRunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingFormat = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("RunSettingFormat",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingFormat, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingNextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("RunSettingNextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingNextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDefinition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("RunSettingDefinition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDefinition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExportExecution(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ExecutionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType?) content.GetValueForProperty("ExecutionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ExecutionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSetting = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties) content.GetValueForProperty("RunSetting",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSetting, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedBy = (string) content.GetValueForProperty("SubmittedBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedTime = (global::System.DateTime?) content.GetValueForProperty("SubmittedTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).SubmittedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingStartTime = (global::System.DateTime?) content.GetValueForProperty("ProcessingStartTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingEndTime = (global::System.DateTime?) content.GetValueForProperty("ProcessingEndTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ProcessingEndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDeliveryInfo = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo) content.GetValueForProperty("RunSettingDeliveryInfo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDeliveryInfo, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingRunHistory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult) content.GetValueForProperty("RunSettingRunHistory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingRunHistory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResultTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingFormat = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType?) content.GetValueForProperty("RunSettingFormat",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingFormat, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingNextRunTimeEstimate = (global::System.DateTime?) content.GetValueForProperty("RunSettingNextRunTimeEstimate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingNextRunTimeEstimate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDefinition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition) content.GetValueForProperty("RunSettingDefinition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunSettingDefinition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod) content.GetValueForProperty("DefinitionTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DeliveryInfoDestination = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination) content.GetValueForProperty("DeliveryInfoDestination",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DeliveryInfoDestination, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryDestinationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) content.GetValueForProperty("DefinitionTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionDataSet = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset) content.GetValueForProperty("DefinitionDataSet",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DefinitionDataSet, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunHistoryValue = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[]) content.GetValueForProperty("RunHistoryValue",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).RunHistoryValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationResourceId = (string) content.GetValueForProperty("DestinationResourceId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationContainer = (string) content.GetValueForProperty("DestinationContainer",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationContainer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration) content.GetValueForProperty("DataSetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType?) content.GetValueForProperty("DataSetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DataSetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationRootFolderPath = (string) content.GetValueForProperty("DestinationRootFolderPath",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).DestinationRootFolderPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExportExecution" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// An export execution.
    [System.ComponentModel.TypeConverter(typeof(ExportExecutionTypeConverter))]
    public partial interface IExportExecution

    {

    }
}