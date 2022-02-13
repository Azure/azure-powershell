namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of data present in the report.</summary>
    public partial class ReportConfigDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDataset,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal
    {

        /// <summary>Backing field for <see cref="Aggregation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation _aggregation;

        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation Aggregation { get => (this._aggregation = this._aggregation ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetAggregation()); set => this._aggregation = value; }

        /// <summary>Backing field for <see cref="Configuration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration _configuration;

        /// <summary>
        /// Has configuration information for the data in the report. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetConfiguration()); set => this._configuration = value; }

        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfigurationInternal)Configuration).Column; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfigurationInternal)Configuration).Column = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter _filter;

        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigFilter()); set => this._filter = value; }

        /// <summary>Backing field for <see cref="Granularity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? _granularity;

        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? Granularity { get => this._granularity; set => this._granularity = value; }

        /// <summary>Backing field for <see cref="Grouping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] _grouping;

        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] Grouping { get => this._grouping; set => this._grouping = value; }

        /// <summary>Internal Acessors for Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetInternal.Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ReportConfigDatasetConfiguration()); set { {_configuration = value;} } }

        /// <summary>Backing field for <see cref="Sorting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] _sorting;

        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] Sorting { get => this._sorting; set => this._sorting = value; }

        /// <summary>Creates an new <see cref="ReportConfigDataset" /> instance.</summary>
        public ReportConfigDataset()
        {

        }
    }
    /// The definition of data present in the report.
    public partial interface IReportConfigDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
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
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation Aggregation { get; set; }
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
        /// <summary>Has filter expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the report.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter Filter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the report.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? Granularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of group by expression to use in the report. Report can have up to 2 group by clauses.",
        SerializedName = @"grouping",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] Grouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of order by expression to use in the report.",
        SerializedName = @"sorting",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] Sorting { get; set; }

    }
    /// The definition of data present in the report.
    public partial interface IReportConfigDatasetInternal

    {
        /// <summary>
        /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
        /// aggregated column. Report can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation Aggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the report. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration Configuration { get; set; }
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Has filter expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigFilter Filter { get; set; }
        /// <summary>The granularity of rows in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType? Granularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the report. Report can have up to 2 group by clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigGrouping[] Grouping { get; set; }
        /// <summary>Array of order by expression to use in the report.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigSorting[] Sorting { get; set; }

    }
}