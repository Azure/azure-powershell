namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
    /// aggregated column. Report can have up to 2 aggregation clauses.
    /// </summary>
    public partial class ReportConfigDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregation,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetAggregationInternal
    {

        /// <summary>Creates an new <see cref="ReportConfigDatasetAggregation" /> instance.</summary>
        public ReportConfigDatasetAggregation()
        {

        }
    }
    /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
    /// aggregated column. Report can have up to 2 aggregation clauses.
    public partial interface IReportConfigDatasetAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigAggregation>
    {

    }
    /// Dictionary of aggregation expression to use in the report. The key of each item in the dictionary is the alias for the
    /// aggregated column. Report can have up to 2 aggregation clauses.
    public partial interface IReportConfigDatasetAggregationInternal

    {

    }
}