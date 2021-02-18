namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>States and configurations of Cost Analysis.</summary>
    [System.ComponentModel.TypeConverter(typeof(ViewTypeConverter))]
    public partial class View
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.View"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new View(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.View"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new View(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="View" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IView FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.View"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal View(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ViewPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Query = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition) content.GetValueForProperty("Query",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Query, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Scope, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).CreatedOn = (global::System.DateTime?) content.GetValueForProperty("CreatedOn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).CreatedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ModifiedOn = (global::System.DateTime?) content.GetValueForProperty("ModifiedOn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ModifiedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Chart = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType?) content.GetValueForProperty("Chart",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Chart, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Accumulated = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType?) content.GetValueForProperty("Accumulated",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Accumulated, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Metric = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType?) content.GetValueForProperty("Metric",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Metric, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Kpi = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[]) content.GetValueForProperty("Kpi",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Kpi, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.KpiPropertiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Pivot = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[]) content.GetValueForProperty("Pivot",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Pivot, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.PivotPropertiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod) content.GetValueForProperty("QueryTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryType = (string) content.GetValueForProperty("QueryType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType) content.GetValueForProperty("QueryTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryDataset = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset) content.GetValueForProperty("QueryDataset",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryDataset, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration) content.GetValueForProperty("DatasetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType?) content.GetValueForProperty("DatasetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetAggregation = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation) content.GetValueForProperty("DatasetAggregation",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetAggregation, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetAggregationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGrouping = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[]) content.GetValueForProperty("DatasetGrouping",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGrouping, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigGroupingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetSorting = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[]) content.GetValueForProperty("DatasetSorting",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetSorting, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigSortingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter) content.GetValueForProperty("DatasetFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigFilterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.View"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal View(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ViewPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Query = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition) content.GetValueForProperty("Query",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Query, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Scope, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).CreatedOn = (global::System.DateTime?) content.GetValueForProperty("CreatedOn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).CreatedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ModifiedOn = (global::System.DateTime?) content.GetValueForProperty("ModifiedOn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ModifiedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Chart = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType?) content.GetValueForProperty("Chart",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Chart, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ChartType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Accumulated = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType?) content.GetValueForProperty("Accumulated",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Accumulated, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AccumulatedType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Metric = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType?) content.GetValueForProperty("Metric",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Metric, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.MetricType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Kpi = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties[]) content.GetValueForProperty("Kpi",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Kpi, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IKpiProperties>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.KpiPropertiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Pivot = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties[]) content.GetValueForProperty("Pivot",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).Pivot, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.PivotPropertiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimePeriod = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod) content.GetValueForProperty("QueryTimePeriod",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimePeriod, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigTimePeriodTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryType = (string) content.GetValueForProperty("QueryType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimeframe = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType) content.GetValueForProperty("QueryTimeframe",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryTimeframe, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryDataset = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset) content.GetValueForProperty("QueryDataset",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).QueryDataset, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodFrom = (global::System.DateTime) content.GetValueForProperty("TimePeriodFrom",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodFrom, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodTo = (global::System.DateTime) content.GetValueForProperty("TimePeriodTo",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).TimePeriodTo, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration) content.GetValueForProperty("DatasetConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetConfiguration, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGranularity = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType?) content.GetValueForProperty("DatasetGranularity",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGranularity, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetAggregation = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation) content.GetValueForProperty("DatasetAggregation",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetAggregation, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetAggregationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGrouping = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[]) content.GetValueForProperty("DatasetGrouping",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetGrouping, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigGroupingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetSorting = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[]) content.GetValueForProperty("DatasetSorting",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetSorting, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigSortingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter) content.GetValueForProperty("DatasetFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).DatasetFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigFilterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ConfigurationColumn = (string[]) content.GetValueForProperty("ConfigurationColumn",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IViewInternal)this).ConfigurationColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }
    }
    /// States and configurations of Cost Analysis.
    [System.ComponentModel.TypeConverter(typeof(ViewTypeConverter))]
    public partial interface IView

    {

    }
}