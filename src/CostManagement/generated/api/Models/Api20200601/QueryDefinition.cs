namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of a query.</summary>
    public partial class QueryDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDefinitionInternal
    {

        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Dataset" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDataset _dataset;

        /// <summary>Has definition for data in this query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDataset Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDataset()); set => this._dataset = value; }

        /// <summary>
        /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
        /// aggregated column. Query can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation DatasetAggregation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Aggregation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Aggregation = value ?? null /* model class */; }

        /// <summary>Has filter expression to use in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Filter = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Granularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Granularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] DatasetGrouping { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Grouping; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Grouping = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Dataset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDefinitionInternal.Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDataset()); set { {_dataset = value;} } }

        /// <summary>Internal Acessors for DatasetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDefinitionInternal.DatasetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Configuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal)Dataset).Configuration = value; }

        /// <summary>Internal Acessors for TimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDefinitionInternal.TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryTimePeriod()); set { {_timePeriod = value;} } }

        /// <summary>Backing field for <see cref="TimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod _timePeriod;

        /// <summary>Has time period for pulling data for the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryTimePeriod()); set => this._timePeriod = value; }

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).From; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).From = value ?? default(global::System.DateTime); }

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).To = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Timeframe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType _timeframe;

        /// <summary>
        /// The time frame for pulling data for the query. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get => this._timeframe; set => this._timeframe = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType _type;

        /// <summary>The type of the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="QueryDefinition" /> instance.</summary>
        public QueryDefinition()
        {

        }
    }
    /// The definition of a query.
    public partial interface IQueryDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query includes all columns.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConfigurationColumn { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
        /// aggregated column. Query can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the aggregated column. Query can have up to 2 aggregation clauses.",
        SerializedName = @"aggregation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>Has filter expression to use in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the query.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the query.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of group by expression to use in the query. Query can have up to 2 group by clauses.",
        SerializedName = @"grouping",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] DatasetGrouping { get; set; }
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
        /// The time frame for pulling data for the query. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the query. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get; set; }
        /// <summary>The type of the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the query.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get; set; }

    }
    /// The definition of a query.
    public partial interface IQueryDefinitionInternal

    {
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Has definition for data in this query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDataset Dataset { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
        /// aggregated column. Query can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the export. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration DatasetConfiguration { get; set; }
        /// <summary>Has filter expression to use in the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] DatasetGrouping { get; set; }
        /// <summary>Has time period for pulling data for the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod TimePeriod { get; set; }
        /// <summary>The start date to pull data from.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the query. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get; set; }
        /// <summary>The type of the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get; set; }

    }
}