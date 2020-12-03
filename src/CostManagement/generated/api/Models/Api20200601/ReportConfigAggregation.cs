namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The aggregation expression to be used in the report.</summary>
    public partial class ReportConfigAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigAggregation,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigAggregationInternal
    {

        /// <summary>Backing field for <see cref="Function" /> property.</summary>
        private string _function= @"Sum";

        /// <summary>The name of the aggregation function to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Function { get => this._function; }

        /// <summary>Internal Acessors for Function</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigAggregationInternal.Function { get => this._function; set { {_function = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the column to aggregate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ReportConfigAggregation" /> instance.</summary>
        public ReportConfigAggregation()
        {

        }
    }
    /// The aggregation expression to be used in the report.
    public partial interface IReportConfigAggregation :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The name of the aggregation function to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The name of the aggregation function to use.",
        SerializedName = @"function",
        PossibleTypes = new [] { typeof(string) })]
        string Function { get;  }
        /// <summary>The name of the column to aggregate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the column to aggregate.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The aggregation expression to be used in the report.
    public partial interface IReportConfigAggregationInternal

    {
        /// <summary>The name of the aggregation function to use.</summary>
        string Function { get; set; }
        /// <summary>The name of the column to aggregate.</summary>
        string Name { get; set; }

    }
}