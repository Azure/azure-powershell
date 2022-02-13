namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of data present in the query.</summary>
    public partial class QueryDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDataset,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal
    {

        /// <summary>Backing field for <see cref="Aggregation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation _aggregation;

        /// <summary>
        /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
        /// aggregated column. Query can have up to 2 aggregation clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation Aggregation { get => (this._aggregation = this._aggregation ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDatasetAggregation()); set => this._aggregation = value; }

        /// <summary>Backing field for <see cref="Configuration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration _configuration;

        /// <summary>
        /// Has configuration information for the data in the export. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDatasetConfiguration()); set => this._configuration = value; }

        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfigurationInternal)Configuration).Column; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfigurationInternal)Configuration).Column = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter _filter;

        /// <summary>Has filter expression to use in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter()); set => this._filter = value; }

        /// <summary>Backing field for <see cref="Granularity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? _granularity;

        /// <summary>The granularity of rows in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get => this._granularity; set => this._granularity = value; }

        /// <summary>Backing field for <see cref="Grouping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] _grouping;

        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] Grouping { get => this._grouping; set => this._grouping = value; }

        /// <summary>Internal Acessors for Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetInternal.Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryDatasetConfiguration()); set { {_configuration = value;} } }

        /// <summary>Creates an new <see cref="QueryDataset" /> instance.</summary>
        public QueryDataset()
        {

        }
    }
    /// The definition of data present in the query.
    public partial interface IQueryDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
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
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation Aggregation { get; set; }
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
        /// <summary>Has filter expression to use in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Has filter expression to use in the query.",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter Filter { get; set; }
        /// <summary>The granularity of rows in the query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the query.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of group by expression to use in the query. Query can have up to 2 group by clauses.",
        SerializedName = @"grouping",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] Grouping { get; set; }

    }
    /// The definition of data present in the query.
    public partial interface IQueryDatasetInternal

    {
        /// <summary>
        /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
        /// aggregated column. Query can have up to 2 aggregation clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation Aggregation { get; set; }
        /// <summary>
        /// Has configuration information for the data in the export. The configuration will be ignored if aggregation and grouping
        /// are provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration Configuration { get; set; }
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>Has filter expression to use in the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter Filter { get; set; }
        /// <summary>The granularity of rows in the query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get; set; }
        /// <summary>
        /// Array of group by expression to use in the query. Query can have up to 2 group by clauses.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryGrouping[] Grouping { get; set; }

    }
}