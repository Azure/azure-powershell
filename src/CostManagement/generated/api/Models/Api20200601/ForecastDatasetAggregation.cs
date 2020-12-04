namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
    /// aggregated column. forecast can have up to 2 aggregation clauses.
    /// </summary>
    public partial class ForecastDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregation,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IForecastDatasetAggregationInternal
    {

        /// <summary>Creates an new <see cref="ForecastDatasetAggregation" /> instance.</summary>
        public ForecastDatasetAggregation()
        {

        }
    }
    /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
    /// aggregated column. forecast can have up to 2 aggregation clauses.
    public partial interface IForecastDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryAggregation>
    {

    }
    /// Dictionary of aggregation expression to use in the forecast. The key of each item in the dictionary is the alias for the
    /// aggregated column. forecast can have up to 2 aggregation clauses.
    public partial interface IForecastDatasetAggregationInternal

    {

    }
}