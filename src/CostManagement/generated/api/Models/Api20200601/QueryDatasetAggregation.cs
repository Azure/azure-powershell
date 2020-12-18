namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
    /// aggregated column. Query can have up to 2 aggregation clauses.
    /// </summary>
    public partial class QueryDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregation,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetAggregationInternal
    {

        /// <summary>Creates an new <see cref="QueryDatasetAggregation" /> instance.</summary>
        public QueryDatasetAggregation()
        {

        }
    }
    /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
    /// aggregated column. Query can have up to 2 aggregation clauses.
    public partial interface IQueryDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>
    {

    }
    /// Dictionary of aggregation expression to use in the query. The key of each item in the dictionary is the alias for the
    /// aggregated column. Query can have up to 2 aggregation clauses.
    public partial interface IQueryDatasetAggregationInternal

    {

    }
}