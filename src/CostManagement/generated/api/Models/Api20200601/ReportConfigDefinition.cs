namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of a report config.</summary>
    public partial class ReportConfigDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal
    {

        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Dataset" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset _dataset;

        /// <summary>Has definition for data in this report config.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDataset()); set => this._dataset = value; }

        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Aggregation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Aggregation = value ?? null /* model class */; }

        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Filter = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Granularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Granularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType)""); }

        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Grouping; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Grouping = value ?? null /* arrayOf */; }

        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Sorting; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Sorting = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Dataset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal.Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDataset()); set { {_dataset = value;} } }

        /// <summary>Internal Acessors for DatasetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal.DatasetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Configuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal)Dataset).Configuration = value; }

        /// <summary>Internal Acessors for TimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal.TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigTimePeriod()); set { {_timePeriod = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDefinitionInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="TimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod _timePeriod;

        /// <summary>Has time period for pulling data for the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigTimePeriod()); set => this._timePeriod = value; }

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriodInternal)TimePeriod).From; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriodInternal)TimePeriod).From = value ?? default(global::System.DateTime); }

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriodInternal)TimePeriod).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriodInternal)TimePeriod).To = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Timeframe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType _timeframe;

        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType Timeframe { get => this._timeframe; set => this._timeframe = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Usage";

        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ReportConfigDefinition" /> instance.</summary>
        public ReportConfigDefinition()
        {

        }
    }
    /// The definition of a report config.
    public partial interface IReportConfigDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report includes all columns.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConfigurationColumn { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the aggregated column. Report can have up to 2 aggregation clauses.",
        SerializedName = @"aggregation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the report.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the report.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of group by expression to use in the report. Report can have up to 2 group by clauses.",
        SerializedName = @"grouping",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of order by expression to use in the report.",
        SerializedName = @"sorting",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get; set; }
        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start date to pull data from.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end date to pull data to.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the report. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType Timeframe { get; set; }
        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The definition of a report config.
    public partial interface IReportConfigDefinitionInternal

    {
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Has definition for data in this report config.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset Dataset { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the report. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration DatasetConfiguration { get; set; }
        /// <summary>Has filter expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] DatasetGrouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] DatasetSorting { get; set; }
        /// <summary>Has time period for pulling data for the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod TimePeriod { get; set; }
        /// <summary>The start date to pull data from.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the report. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportTimeframeType Timeframe { get; set; }
        /// <summary>
        /// The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents
        /// both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates.
        /// </summary>
        string Type { get; set; }

    }
}