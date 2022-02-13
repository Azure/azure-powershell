namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of a forecast.</summary>
    public partial class ForecastDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDefinitionInternal
    {

        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Dataset" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDataset _dataset;

        /// <summary>Has definition for data in this forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDataset Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ForecastDataset()); set => this._dataset = value; }

        /// <summary>
        /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
        /// aggregated column. forecast can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregation DatasetAggregation { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Aggregation; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Aggregation = value ?? null /* model class */; }

        /// <summary>Has filter expression to use in the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Filter; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Filter = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Granularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Granularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>Backing field for <see cref="IncludeActualCost" /> property.</summary>
        private bool? _includeActualCost;

        /// <summary>a boolean determining if actualCost will be included</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public bool? IncludeActualCost { get => this._includeActualCost; set => this._includeActualCost = value; }

        /// <summary>Backing field for <see cref="IncludeFreshPartialCost" /> property.</summary>
        private bool? _includeFreshPartialCost;

        /// <summary>a boolean determining if FreshPartialCost will be included</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public bool? IncludeFreshPartialCost { get => this._includeFreshPartialCost; set => this._includeFreshPartialCost = value; }

        /// <summary>Internal Acessors for Dataset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDefinitionInternal.Dataset { get => (this._dataset = this._dataset ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ForecastDataset()); set { {_dataset = value;} } }

        /// <summary>Internal Acessors for DatasetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDefinitionInternal.DatasetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Configuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetInternal)Dataset).Configuration = value; }

        /// <summary>Internal Acessors for TimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDefinitionInternal.TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryTimePeriod()); set { {_timePeriod = value;} } }

        /// <summary>Backing field for <see cref="TimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod _timePeriod;

        /// <summary>Has time period for pulling data for the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryTimePeriod()); set => this._timePeriod = value; }

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).From; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).From = value ?? default(global::System.DateTime); }

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriodInternal)TimePeriod).To = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Timeframe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastTimeframeType _timeframe;

        /// <summary>
        /// The time frame for pulling data for the forecast. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastTimeframeType Timeframe { get => this._timeframe; set => this._timeframe = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastType _type;

        /// <summary>The type of the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ForecastDefinition" /> instance.</summary>
        public ForecastDefinition()
        {

        }
    }
    /// The definition of a forecast.
    public partial interface IForecastDefinition :
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
        /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
        /// aggregated column. forecast can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the aggregated column. forecast can have up to 2 aggregation clauses.",
        SerializedName = @"aggregation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregation) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>Has filter expression to use in the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the forecast.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the forecast.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get; set; }
        /// <summary>a boolean determining if actualCost will be included</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"a boolean determining if actualCost will be included",
        SerializedName = @"includeActualCost",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeActualCost { get; set; }
        /// <summary>a boolean determining if FreshPartialCost will be included</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"a boolean determining if FreshPartialCost will be included",
        SerializedName = @"includeFreshPartialCost",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeFreshPartialCost { get; set; }
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
        /// The time frame for pulling data for the forecast. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the forecast. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastTimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastTimeframeType Timeframe { get; set; }
        /// <summary>The type of the forecast.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the forecast.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastType Type { get; set; }

    }
    /// The definition of a forecast.
    public partial interface IForecastDefinitionInternal

    {
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Has definition for data in this forecast.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDataset Dataset { get; set; }
        /// <summary>
        /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
        /// aggregated column. forecast can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregation DatasetAggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the export. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration DatasetConfiguration { get; set; }
        /// <summary>Has filter expression to use in the forecast.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter DatasetFilter { get; set; }
        /// <summary>The granularity of rows in the forecast.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DatasetGranularity { get; set; }
        /// <summary>a boolean determining if actualCost will be included</summary>
        bool? IncludeActualCost { get; set; }
        /// <summary>a boolean determining if FreshPartialCost will be included</summary>
        bool? IncludeFreshPartialCost { get; set; }
        /// <summary>Has time period for pulling data for the forecast.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryTimePeriod TimePeriod { get; set; }
        /// <summary>The start date to pull data from.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date to pull data to.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the forecast. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastTimeframeType Timeframe { get; set; }
        /// <summary>The type of the forecast.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ForecastType Type { get; set; }

    }
}